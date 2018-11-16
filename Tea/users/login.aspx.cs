using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class login : Tea.Web.UI.ShopPage
{
    protected int num = 0;
    protected string act, strurl, url;
    protected void Page_Load(object sender, EventArgs e)
    {
        Tea.Model.users _users = GetUserInfo();
        if (_users != null && _users.status == 0)
        {
            Response.Redirect("edituser.aspx");
        }
        url = TWRequest.GetQueryString("url");
        try
        {
            num = Convert.ToInt32(Session["LoginSun"]);
        }
        catch (Exception eee) { }

        try
        {
            strurl = Request.UrlReferrer.AbsoluteUri.ToString();

            if (strurl.Contains("tea.") && !strurl.Contains("login.aspx") && !strurl.Contains("out.aspx") && !strurl.Contains("reg"))
            {
                Utils.WriteCookie("url", strurl);
            }
        }
        catch (Exception eee)
        { }

        if (url == "cart")
        {
            Utils.WriteCookie("url", "/shop/cart.aspx");
        }


        act = TWRequest.GetFormString("act");
        Tea.BLL.users bll = new Tea.BLL.users();
        if (act == "act_login")
        {
            string remember = TWRequest.GetFormString("txt_code");
            if (Session[TWKeys.SESSION_CODE] == null)
            {
                Response.Write(ljd.function.LocalHint("系統找不到驗證碼", "login.aspx"));
                return;
            }
            if (remember.ToLower() != Session[TWKeys.SESSION_CODE].ToString().ToLower())
            {
                Response.Write(ljd.function.LocalHint("驗證碼輸入不正確", "login.aspx"));
                return;
            }
            string username = TWRequest.GetFormString("email");
            string password = TWRequest.GetFormString("password");

            //檢查用戶名密碼
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Response.Write(ljd.function.LocalHint("檢查用戶名密碼", "login.aspx"));
                return;
            }


            Tea.Model.users model = bll.GetModel(username, password, 1, 1, true);
            if (model == null)
            {
                Response.Write(ljd.function.LocalHint("檢查用戶名密碼", "login.aspx"));
                return;
            }


            else if (model.status == 2) //待審核
            {
                Response.Write(ljd.function.LocalHint("此帳號因未同意隱私條款或其他因素，已被系統限制登入，若有需要重新啟用，請連絡網站管理人員。", "login.aspx"));
                return;
            }
            Session[TWKeys.SESSION_USER_INFO] = model;
            Session.Timeout = 45;

            //防止Session提前過期
            Utils.WriteCookie(TWKeys.COOKIE_USER_NAME_REMEMBER, "Tea", model.user_name);
            Utils.WriteCookie(TWKeys.COOKIE_USER_PWD_REMEMBER, "Tea", model.password);

            //寫入登入日誌
            new Tea.BLL.user_login_log().Add(model.id, model.user_name, "會員登入");
            //返回URL
            //檢查用戶是否通過驗證
            if (model.status == 1) //待驗證
            {
                Response.Write(ljd.function.LocalHint("已發送帳號啟用信至您的電子信箱，請至信箱確認並啟用", "regno.aspx"));
                return;
            }
            //strurl = Utils.GetCookie("url");
            //if (strurl.Contains("tea.") || strurl.Contains("cart."))
            //{
            //    Response.Redirect(strurl);
            //}
            //else
            //{
            //    Response.Redirect("/users/index.aspx");
            //}
            Tea.Model.cart_total cartModel = Tea.Web.UI.ShopCart.GetTotal(1);
            if (cartModel.total_quantity == 0)
            {
                Response.Redirect("/Default.aspx");
            }
            else
            {
                Response.Redirect("/shop/cart.aspx");
            }

        }


    }
}