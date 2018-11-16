using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.settings
{
    public partial class nav_edit : Web.UI.ManagePage
    {
        private string action = TWEnums.ActionEnum.Add.ToString(); //操作類型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = TWRequest.GetQueryString("action");
            this.id = TWRequest.GetQueryInt("id");

            if (!string.IsNullOrEmpty(_action) && _action == TWEnums.ActionEnum.Edit.ToString())
            {
                this.action = TWEnums.ActionEnum.Edit.ToString();//修改類型
                if (this.id == 0)
                {
                    JscriptMsg("傳輸參數不正確！", "back");
                    return;
                }
                if (!new BLL.navigation().Exists(this.id))
                {
                    JscriptMsg("導航不存在或已被刪除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("sys_navigation", TWEnums.ActionEnum.View.ToString()); //檢查許可權
                TreeBind(TWEnums.NavigationEnum.System.ToString()); //綁定導航菜單
                ActionTypeBind(); //綁定操作許可權類型
                if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    if (this.id > 0)
                    {
                        this.ddlParentId.SelectedValue = this.id.ToString();
                    }
                    txtName.Attributes.Add("ajaxurl", "../../tools/admin_ajax.ashx?action=navigation_validate");
                }
            }
        }

        #region 綁定導航菜單=============================
        private void TreeBind(string nav_type)
        {
            BLL.navigation bll = new BLL.navigation();
            DataTable dt = bll.GetList(0, nav_type);

            this.ddlParentId.Items.Clear();
            this.ddlParentId.Items.Add(new ListItem("無父級導航", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 綁定操作許可權類型=========================
        private void ActionTypeBind()
        {
            cblActionType.Items.Clear();
            foreach (KeyValuePair<string, string> kvp in Utils.ActionType())
            {
                cblActionType.Items.Add(new ListItem(kvp.Value + "(" + kvp.Key + ")", kvp.Key));
            }
        }
        #endregion

        #region 賦值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.navigation bll = new BLL.navigation();
            Model.navigation model = bll.GetModel(_id);

            ddlParentId.SelectedValue = model.parent_id.ToString();
            txtSortId.Text = model.sort_id.ToString();
            if (model.is_lock == 1)
            {
                cbIsLock.Checked = true;
            }
            txtName.Text = model.name;
            txtName.Attributes.Add("ajaxurl", "../../tools/admin_ajax.ashx?action=navigation_validate&old_name=" + Utils.UrlEncode(model.name));
            txtName.Focus(); //設置焦點，防止JS無法送出
            if (model.is_sys == 1)
            {
                ddlParentId.Enabled = false;
                txtName.ReadOnly = true;
            }
            txtTitle.Text = model.title;
            txtSubTitle.Text = model.sub_title;
            txtIconUrl.Text = model.icon_url;
            txtLinkUrl.Text = model.link_url;
            txtRemark.Text = model.remark;
            //賦值操作許可權類型
            string[] actionTypeArr = model.action_type.Split(',');
            for (int i = 0; i < cblActionType.Items.Count; i++)
            {
                for (int n = 0; n < actionTypeArr.Length; n++)
                {
                    if (actionTypeArr[n].ToLower() == cblActionType.Items[i].Value.ToLower())
                    {
                        cblActionType.Items[i].Selected = true;
                    }
                }
            }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            try
            {
                Model.navigation model = new Model.navigation();
                BLL.navigation bll = new BLL.navigation();

                model.nav_type = TWEnums.NavigationEnum.System.ToString();
                model.name = txtName.Text.Trim();
                model.title = txtTitle.Text.Trim();
                model.sub_title = txtSubTitle.Text.Trim();
                model.icon_url = txtIconUrl.Text.Trim();
                model.link_url = txtLinkUrl.Text.Trim();
                model.sort_id = int.Parse(txtSortId.Text.Trim());
                model.is_lock = 0;
                if (cbIsLock.Checked == true)
                {
                    model.is_lock = 1;
                }
                model.remark = txtRemark.Text.Trim();
                model.parent_id = int.Parse(ddlParentId.SelectedValue);

                //添加操作許可權類型
                string action_type_str = string.Empty;
                for (int i = 0; i < cblActionType.Items.Count; i++)
                {
                    if (cblActionType.Items[i].Selected && Utils.ActionType().ContainsKey(cblActionType.Items[i].Value))
                    {
                        action_type_str += cblActionType.Items[i].Value + ",";
                    }
                }
                model.action_type = Utils.DelLastComma(action_type_str);

                if (bll.Add(model) > 0)
                {
                    AddAdminLog(TWEnums.ActionEnum.Add.ToString(), "添加導航菜單:" + model.title); //記錄日誌
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            try
            {
                BLL.navigation bll = new BLL.navigation();
                Model.navigation model = bll.GetModel(_id);

                model.name = txtName.Text.Trim();
                model.title = txtTitle.Text.Trim();
                model.sub_title = txtSubTitle.Text.Trim();
                model.icon_url = txtIconUrl.Text.Trim();
                model.link_url = txtLinkUrl.Text.Trim();
                model.sort_id = int.Parse(txtSortId.Text.Trim());
                model.is_lock = 0;
                if (cbIsLock.Checked == true)
                {
                    model.is_lock = 1;
                }
                model.remark = txtRemark.Text.Trim();
                if (model.is_sys == 0)
                {
                    int parentId = int.Parse(ddlParentId.SelectedValue);
                    //如果選擇的父ID不是自己,則更改
                    if (parentId != model.id)
                    {
                        model.parent_id = parentId;
                    }
                }

                //添加操作許可權類型
                string action_type_str = string.Empty;
                for (int i = 0; i < cblActionType.Items.Count; i++)
                {
                    if (cblActionType.Items[i].Selected && Utils.ActionType().ContainsKey(cblActionType.Items[i].Value))
                    {
                        action_type_str += cblActionType.Items[i].Value + ",";
                    }
                }
                model.action_type = Utils.DelLastComma(action_type_str);

                if (bll.Update(model))
                {
                    AddAdminLog(TWEnums.ActionEnum.Add.ToString(), "修改導航菜單:" + model.title); //記錄日誌
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        //儲存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
            {
                //ChkAdminLevelEdit("", "Edit");
                //ChkAdminLevel("sys_navigation", TWEnums.ActionEnum.Edit.ToString()); //檢查許可權
                if (!DoEdit(this.id))
                {
                    JscriptMsg("儲存過程中發生錯誤！", "");
                    return;
                }
                JscriptMsg("修改導航菜單成功！", "nav_list.aspx", "parent.loadMenuTree");
            }
            else //添加
            {
                //ChkAdminLevelEdit("", "Edit");
                //ChkAdminLevel("sys_navigation", TWEnums.ActionEnum.Add.ToString()); //檢查許可權
                if (!DoAdd())
                {
                    JscriptMsg("儲存過程中發生錯誤！", "");
                    return;
                }
                JscriptMsg("添加導航菜單成功！", "nav_list.aspx", "parent.loadMenuTree");
            }
        }

    }
}
