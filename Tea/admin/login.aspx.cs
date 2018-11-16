using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using Tea.Common;

namespace Tea.Web.admin
{
    public partial class login : Tea.Web.UI.ShopPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUserName.Text = Utils.GetCookie("DTRememberName");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string userPwd = txtPassword.Text.Trim();

            if (userName.Equals("") || userPwd.Equals(""))
            {
                msgtip.InnerHtml = "請輸入用戶名或密碼";
                return;
            }
            if (Session["AdminLoginSun"] == null)
            {
                Session["AdminLoginSun"] = 1;
            }
            else
            {
                Session["AdminLoginSun"] = Convert.ToInt32(Session["AdminLoginSun"]) + 1;
            }
            //判斷登入錯誤次數
            if (Session["AdminLoginSun"] != null && Convert.ToInt32(Session["AdminLoginSun"]) > 5)
            {
                msgtip.InnerHtml = "登入錯誤超過5次，關閉瀏覽器重新登入！";
                return;
            }
            BLL.manager bll = new BLL.manager();
            Model.manager model = bll.GetModel(userName, userPwd, true);
            if (model == null)
            {
                msgtip.InnerHtml = "用戶名或密碼有誤，請重再試！";
                return;
            }
            Session[TWKeys.SESSION_ADMIN_INFO] = model;
            Session.Timeout = 45;
            //寫入登錄日誌
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
            if (siteConfig.logstatus > 0)
            {
                new BLL.manager_log().Add(model.id, model.user_name, TWEnums.ActionEnum.Login.ToString(), "用戶登入");
            }
            //寫入Cookies
            Utils.WriteCookie("DTRememberName", model.user_name, 14400);
            Utils.WriteCookie("AdminName", "Tea", model.user_name);
            Utils.WriteCookie("AdminPwd", "Tea", model.password);
            Response.Redirect("index.aspx");
            return;
        }

    }
}
