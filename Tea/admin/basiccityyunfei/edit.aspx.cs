using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.basic
{
    public partial class edit : Web.UI.ManagePage
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
                if (!new BLL.basic().Exists(this.id))
                {
                    JscriptMsg("資料不存在或已被刪除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ddlCategoryId.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from shop_basic where basic_where='qu' order by basic_sort");
                ddlCategoryId.DataTextField = "basic_label";
                ddlCategoryId.DataValueField = "basic_value";
                ddlCategoryId.DataBind();
                //ChkAdminLevel("plugin_link", TWEnums.ActionEnum.View.ToString()); //檢查權限
                if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 賦值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.basic bll = new BLL.basic();
            Model.basic model = bll.GetModel(_id);
            txtSortId.Text = model.basic_money.GetValueOrDefault().ToString("0.00");
            txtbasic_label.Text = model.basic_label;
            txtYun.Text = model.basic_sort.Value.ToString();
            ddlCategoryId.SelectedValue = model.basic_type;
            //txtbasic_pic.Text = model.basic_pic;
           
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.basic model = new Model.basic();
            BLL.basic bll = new BLL.basic();

            model.basic_label = txtbasic_label.Text.Trim();
            model.basic_sort = Utils.StrToInt(txtYun.Text, 0);
            model.basic_money = Utils.StrToDecimal(txtSortId.Text, 0);
            model.basic_type=ddlCategoryId.SelectedValue;
            //model.basic_pic = txtbasic_pic.Text;
            model.basic_where = "yunfei";
            int a = bll.Add(model);
            Model.basic model1 = bll.GetModel(a);
            if (a > 0)
            {
                model1.basic_value = a.ToString();
                bll.Update(model1);
                AddAdminLog(TWEnums.ActionEnum.Add.ToString(), "添加運費設定：" + model.basic_label); //記錄日誌
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.basic bll = new BLL.basic();
            Model.basic model = bll.GetModel(_id);
            model.basic_label = txtbasic_label.Text.Trim();
            model.basic_sort = Utils.StrToInt(txtYun.Text, 0);
            model.basic_money = Utils.StrToDecimal(txtSortId.Text, 0);
            //model.basic_pic = txtbasic_pic.Text;
            model.basic_type = ddlCategoryId.SelectedValue;
            if (bll.Update(model))
            {
                AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "修改運費設定：" + model.basic_label); //記錄日誌
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
                ChkAdminLevelEdit("basiccityyunfei", "Edit");
                //ChkAdminLevel("plugin_link", TWEnums.ActionEnum.Edit.ToString()); //檢查權限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("儲存過程中發生錯誤！", string.Empty);
                    return;
                }
                JscriptMsg("修改運費設定成功！", "list.aspx");
            }
            else //添加
            {
                ChkAdminLevelEdit("basiccityyunfei", "Edit");
                //ChkAdminLevel("plugin_link", TWEnums.ActionEnum.Add.ToString()); //檢查權限
                if (!DoAdd())
                {
                    JscriptMsg("儲存過程中發生錯誤！", string.Empty);
                    return;
                }
                JscriptMsg("添加運費設定成功！", "list.aspx");
            }
        }

    }
}
