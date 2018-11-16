using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.goods
{
    public partial class slide_edit : Web.UI.ManagePage
    {
        private string action = TWEnums.ActionEnum.Add.ToString(); //操作類型
        private int id = 0;
        protected string pic;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = TWRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == TWEnums.ActionEnum.Edit.ToString())
            {
                this.action = TWEnums.ActionEnum.Edit.ToString();//修改類型
                this.id = TWRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("傳輸參數不正確！", "back");
                    return;
                }
                if (!new BLL.slide().Exists(this.id))
                {
                    JscriptMsg("記錄不存在或已被刪除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("goods_slide", TWEnums.ActionEnum.View.ToString()); //檢查權限
 
                if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 賦值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.slide bll = new BLL.slide();
            Model.slide model = bll.GetModel(_id);

            pic = model.img_url;
            txtTitle.Text = model.title;
            txtLinkUrl.Text = model.link_url;
            txtImgUrl.Text = model.img_url;
            ddlBrand.SelectedValue = model.brand_id.ToString();
            txtStartTime.Text = model.start_time.ToString("yyyy-M-d");
            if (model.end_time != null)
            {
                txtEndTime.Text = model.end_time.GetValueOrDefault().ToString("yyyy-M-d");
            }
            txtSortId.Text = model.sort_id.ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.slide model = new Model.slide();
            BLL.slide bll = new BLL.slide();

            model.title = txtTitle.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.img_url = txtImgUrl.Text.Trim();
            model.brand_id = Utils.StrToInt(ddlBrand.SelectedValue, 0);
            model.start_time = Utils.StrToDateTime(txtStartTime.Text.Trim());
            DateTime _end_time;
            if (DateTime.TryParse(txtEndTime.Text.Trim(), out _end_time))
            {
                model.end_time = _end_time;
            }
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);

            if (bll.Add(model) > 0)
            {
                AddAdminLog(TWEnums.ActionEnum.Add.ToString(), "添加Banner:" + model.title); //記錄日誌
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.slide bll = new BLL.slide();
            Model.slide model = bll.GetModel(_id);

            model.title = txtTitle.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.img_url = txtImgUrl.Text.Trim();
            model.brand_id = Utils.StrToInt(ddlBrand.SelectedValue, 0);
            model.start_time = Utils.StrToDateTime(txtStartTime.Text.Trim());
            DateTime _end_time;
            if (DateTime.TryParse(txtEndTime.Text.Trim(), out _end_time))
            {
                model.end_time = _end_time;
            }
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);

            if (bll.Update(model))
            {
                AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "修改Banner:" + model.title); //記錄日誌
                result = true;
            }

            return result;
        }
        #endregion

        //儲存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevelEdit("settings_banner", "Edit");
                //ChkAdminLevel("goods_slide", TWEnums.ActionEnum.Edit.ToString()); //檢查權限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("儲存過程中發生錯誤！", string.Empty);
                    return;
                }
                JscriptMsg("修改Banner成功！", "slide_list.aspx");
            }
            else //添加
            {
                ChkAdminLevelEdit("settings_banner", "Edit");
                //ChkAdminLevel("goods_slide", TWEnums.ActionEnum.Add.ToString()); //檢查權限
                if (!DoAdd())
                {
                    JscriptMsg("儲存過程中發生錯誤！", string.Empty);
                    return;
                }
                JscriptMsg("添加Banner成功！", "slide_list.aspx");
            }
        }
    }
}