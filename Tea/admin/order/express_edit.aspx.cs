using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.order
{
    public partial class express_edit : Web.UI.ManagePage
    {
        private string action = TWEnums.ActionEnum.Add.ToString(); //操作類型
        private int id = 0;

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
                if (!new BLL.express().Exists(this.id))
                {
                    JscriptMsg("記錄不存在或已被刪除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("order_express", TWEnums.ActionEnum.View.ToString()); //檢查許可權
                if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 賦值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.express bll = new BLL.express();
            Model.express model = bll.GetModel(_id);

            txtTitle.Text = model.title;
            txtExpressCode.Text = model.express_code;
            txtExpressFee.Text = model.express_fee.ToString();
            txtWebSite.Text = model.website;
            txtRemark.Text = Utils.ToTxt(model.remark);
            if (model.is_lock == 0)
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }
            txtSortId.Text = model.sort_id.ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.express model = new Model.express();
            BLL.express bll = new BLL.express();

            model.title = txtTitle.Text.Trim();
            model.express_code = txtExpressCode.Text.Trim();
            model.express_fee = Utils.StrToDecimal(txtExpressFee.Text.Trim(), 0);
            model.website = txtWebSite.Text.Trim();
            model.remark = Utils.ToHtml(txtRemark.Text);
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);

            if (bll.Add(model) > 0)
            {
                AddAdminLog(TWEnums.ActionEnum.Add.ToString(), "添加配送方式:" + model.title); //記錄日誌
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.express bll = new BLL.express();
            Model.express model = bll.GetModel(_id);

            model.title = txtTitle.Text.Trim();
            model.express_code = txtExpressCode.Text.Trim();
            model.express_fee = Utils.StrToDecimal(txtExpressFee.Text.Trim(), 0);
            model.website = txtWebSite.Text.Trim();
            model.remark = Utils.ToHtml(txtRemark.Text);
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);

            if (bll.Update(model))
            {
                AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "修改配送方式:" + model.title); //記錄日誌
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
                ChkAdminLevelEdit("order_express", "Edit");
                //ChkAdminLevel("order_express", TWEnums.ActionEnum.Edit.ToString()); //檢查許可權
                if (!DoEdit(this.id))
                {
                    JscriptMsg("儲存過程中發生錯誤！", string.Empty);
                    return;
                }
                JscriptMsg("修改物流配送成功！", "express_list.aspx");
            }
            else //添加
            {
                ChkAdminLevelEdit("order_express", "Edit");
                //ChkAdminLevel("order_express", TWEnums.ActionEnum.Add.ToString()); //檢查許可權
                if (!DoAdd())
                {
                    JscriptMsg("儲存過程中發生錯誤！", string.Empty);
                    return;
                }
                JscriptMsg("添加物流配送成功！", "express_list.aspx");
            }
        }

    }
}
