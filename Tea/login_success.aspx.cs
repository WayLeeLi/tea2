using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.SessionState;
using Tea.Web.UI;
using Tea.Common;
using MultiOAuth.Core;
public partial class user_login_success : Tea.Web.UI.ShopPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region google fb登入返回

        if (MultiOAuthContext.Current == null || MultiOAuthContext.Current.Token == "")
        {
            Response.Write(ljd.function.LocalHint("帳號異常，請清除cookie後重試。", "/Default.aspx"));
            return;
        }
        //try
        //{
        //string token = MultiOAuthContext.Current.Token;
        //if (token != "")
        //{
        var profile = MultiOAuthContext.Current.Profile;
        string id = profile["id"].ToString();
        string source = profile["source"].ToString();
        string name = profile["name"].ToString();
        string email = "";
        try
        {
            email = profile["email"].ToString();
        }
        catch { }

   
        //Response.Write(source + "--" + name + "__" + email+"__" +id);
        //Response.End();
        switch (source)
        {
            case "Google":
                id = "gl_" + id;
                break;
            case "Facebook":
                id = "fb_" + id;
                break;
            case "WindowsLive":
                id = "wl" + id;
                break;
            case "XuiteClient":
                id = "xc_" + id;
                break;
        }
        multi_login(id, name, email, source);
        // }
        // else
        //Response.Write(Tea.Common.Utils.LocalHint("獲取用戶資料失敗，請重試！", "/index.aspx"));
        // }
        // catch(Exception ex) { Response.Write(Tea.Common.Utils.LocalHint(ex.Message, "/index.aspx")); }
        #endregion
    }
    //第三方登入後處理
    protected void multi_login(string id, string name, string email, string source)
    {
        Tea.Model.users model = new Tea.Model.users();
        Tea.BLL.users bll = new Tea.BLL.users();
        //自動加入會員
        DataSet ds = bll.GetList(1, "user_name='" + id + "'", "id");
        //Response.Write(ds.Tables[0].Rows.Count);
        if (ds.Tables[0].Rows.Count == 0)
        {
            if (!string.IsNullOrEmpty(email) && email.Length > 5)
            {
                if (new Tea.BLL.users().ExistsEmail(email))
                {
                    Response.Write(ljd.function.LocalHint("此帳號信箱已存在於此網站，請以新mail註冊", "/users/login.aspx"));
                    Response.End();
                }
            }
            model.group_id = 1;
            model.status = 0;
            model.user_name = id;
            model.password = DESEncrypt.Encrypt(ljd.function.getUUIDString(12));
            model.email = email;// txtEmail.Text;
            //model.birthday = DateTime.Parse("1980-1-1");
            model.nick_name = name;//txtNickName.Text;
            model.mobile = "";//txtTelphone.Text.Trim();
            model.address = "";//Request["txtcity"] + "|" + Request["txtcity1"] + "|" + txtZip.Text + "|" + txtAddress.Text.Trim();
            model.reg_time = DateTime.Now;
            model.reg_ip = TWRequest.GetIP();
            model.user_hei = 2;
            int uid = bll.Add(model);

            model = bll.GetModel(uid);

            //model.id = uid;

        }
        else
        {
            model = bll.GetModel(id);
            if (model == null)
            {
                Response.Write(ljd.function.LocalHint("您已更改本站密碼，請用本站密碼登入！", "/users/login.aspx"));
                Response.End();
            }
        }
        //防止Session提前過期
        try
        {
            Session[TWKeys.SESSION_USER_INFO] = model;
            Session.Timeout = 4500;

            //防止Session提前過期
            Utils.WriteCookie(TWKeys.COOKIE_USER_NAME_REMEMBER, "Tea", model.user_name);
            Utils.WriteCookie(TWKeys.COOKIE_USER_PWD_REMEMBER, "Tea", model.password);
            
            Tea.Model.cart_total cartModel = Tea.Web.UI.ShopCart.GetTotal(1);
            if (cartModel.total_quantity == 0)
            {
                Response.Redirect("/Default.aspx");
            }
            else
            {
                Response.Redirect("/shop/cart.aspx");
            }
            //寫入登入日誌
            // new Tea.BLL.user_login_log().Add(model.id, model.user_name, "會員登入", TWRequest.GetIP());
        }
        catch { Response.Write("no"); }

        //寫入登入日誌
        //new Tea.BLL.user_login_log().Add(model.id, model.user_name, id + "會員登入", TWRequest.GetIP());
        //Response.Write(model.id+"--"+model.user_name+"--"+model.email);

    }
}