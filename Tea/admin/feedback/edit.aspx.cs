using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.shop_feedback
{
    public partial class edit : Web.UI.ManagePage
    {
        private int id = 0;
        protected Model.feedback model = new Model.feedback();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = TWRequest.GetQueryInt("id");
            if (this.id == 0)
            {
                JscriptMsg("傳輸參數不正確！", "back");
                return;
            }
            if (!new BLL.feedback().Exists(this.id))
            {
                JscriptMsg("資料不存在或已被刪除！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("plugin_feedback", TWEnums.ActionEnum.View.ToString()); //檢查權限
                ShowInfo(this.id);
            }
        }

        #region 賦值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.feedback bll = new BLL.feedback();
            model = bll.GetModel(_id);
            rblStatus.SelectedValue = model.is_lock.ToString();
            txtReContent.Text = Utils.ToTxt(model.reply_content);
            txtBeiZhu.Text = model.beizhu;
        }
        #endregion

        //儲存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("site_contact", "Edit");
            //ChkAdminLevel("plugin_feedback", TWEnums.ActionEnum.Reply.ToString()); //檢查權限

            Model.manager _admin = new Tea.Web.UI.ManagePage().GetAdminInfo();

            BLL.feedback bll = new BLL.feedback();
            model = bll.GetModel(this.id);
            model.reply_content = Utils.ToHtml(txtReContent.Text);
            model.reply_time = DateTime.Now;
            model.company = _admin.id;
            model.is_lock = Utils.StrToInt(rblStatus.SelectedValue, 0);
            model.beizhu = Utils.ToHtml(txtBeiZhu.Text);
            bll.Update(model);

            try
            {
                //if (model.is_lock == 2)
                //{
                    TWMail.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailport, siteConfig.emailusername, siteConfig.emailpassword,
                    siteConfig.emailnickname,
                    siteConfig.emailfrom,
                    model.user_email,
                    model.title + ":回答", model.reply_content);

                    TWMail.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailport, siteConfig.emailusername, siteConfig.emailpassword,
                   siteConfig.emailnickname,
                   siteConfig.emailfrom,
                   siteConfig.webmail,
                   model.title + ":回答", model.reply_content);
               // }
            }
            catch (Exception eee) { }
            AddAdminLog(TWEnums.ActionEnum.Reply.ToString(), "回覆留言內容：" + model.title); //記錄日誌
            JscriptMsg("留言回覆成功！", "list.aspx");
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            BLL.feedback bll = new BLL.feedback();
            model = bll.GetModel(this.id);
            model.is_lock = Utils.StrToInt(rblStatus.SelectedValue, 0);
            model.reply_content = Utils.ToHtml(txtReContent.Text);
            model.beizhu = Utils.ToHtml(txtBeiZhu.Text);
            bll.Update(model);
            AddAdminLog(TWEnums.ActionEnum.Reply.ToString(), "儲存留言內容：" + model.title); //記錄日誌
            JscriptMsg("留言儲存成功！", "list.aspx");
        }
    }
}
