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
            txtSortId.Text = model.basic_sort.Value.ToString();
            txtbasic_label.Text = model.basic_label;
            if (model.basic_type == "2")
            {
                cbIsLock.Checked = true;
            }
           
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.basic model = new Model.basic();
            BLL.basic bll = new BLL.basic();

            model.basic_label = txtbasic_label.Text.Trim();
            model.basic_sort = int.Parse(txtSortId.Text);
            model.basic_show = 1;
            if (cbIsLock.Checked)
            { model.basic_type = "2"; }
            else
            { model.basic_type ="1"; }

            model.basic_where = "news";
            int a = bll.Add(model);
            Model.basic model1 = bll.GetModel(a);
            if (a > 0)
            {
                model1.basic_value = a.ToString();
                bll.Update(model1);
                AddAdminLog(TWEnums.ActionEnum.Add.ToString(), "添加相關分類：" + model.basic_label); //記錄日誌
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
            model.basic_sort = int.Parse(txtSortId.Text);
            if (cbIsLock.Checked)
            { model.basic_type = "2"; }
            else
            { model.basic_type = "1"; }
            if (bll.Update(model))
            {
                AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "修改相關分類：" + model.basic_label); //記錄日誌
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
                ChkAdminLevelEdit("basicnews", "Edit");
                //ChkAdminLevel("plugin_link", TWEnums.ActionEnum.Edit.ToString()); //檢查權限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("儲存過程中發生錯誤！", string.Empty);
                    return;
                }
                JscriptMsg("修改相關分類成功！", "list.aspx");
            }
            else //添加
            {
                ChkAdminLevelEdit("basicnews", "Edit");
                //ChkAdminLevel("plugin_link", TWEnums.ActionEnum.Add.ToString()); //檢查權限
                if (!DoAdd())
                {
                    JscriptMsg("儲存過程中發生錯誤！", string.Empty);
                    return;
                }
                JscriptMsg("添加相關分類成功！", "list.aspx");
            }
        }

    }
}
