﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.manager
{
    public partial class manager_pwd : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Model.manager model = GetAdminInfo();
                ShowInfo(model.id);
            }
        }

        #region 賦值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.manager bll = new BLL.manager();
            Model.manager model = bll.GetModel(_id);
            txtUserName.Text = model.user_name;
            txtRealName.Text = model.real_name;
            txtTelephone.Text = model.telephone;
            txtEmail.Text = model.email;
        }
        #endregion

        //儲存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL.manager bll = new BLL.manager();
            Model.manager model = GetAdminInfo();

            if (DESEncrypt.Encrypt(txtOldPassword.Text.Trim(), model.salt) != model.password)
            {
                JscriptMsg("舊密碼不正確！", "");
                return;
            }
            if (txtPassword.Text.Trim() != txtPassword1.Text.Trim())
            {
                JscriptMsg("兩次密碼不一致！", "");
                return;
            }
            model.password = DESEncrypt.Encrypt(txtPassword.Text.Trim(), model.salt);
            model.real_name = txtRealName.Text.Trim();
            model.telephone = txtTelephone.Text.Trim();
            model.email = txtEmail.Text.Trim();

            if (!bll.Update(model))
            {
                JscriptMsg("儲存過程中發生錯誤！", "");
                return;
            }
            Session[TWKeys.SESSION_ADMIN_INFO] = null;
            JscriptMsg("密碼修改成功！", "manager_pwd.aspx");
        }
    }
}
