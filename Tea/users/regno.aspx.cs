using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class reg : Tea.Web.UI.ShopPage
{
    protected string act;
    protected Tea.Model.users _users = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        _users = new Tea.Web.UI.ShopPage().GetUserInfo();
        act = TWRequest.GetQueryString("act");
        if (act == "send")
        {
            try
            {
                string mailTitle = "驗證郵箱通知信", mailContent = "";
                string url = weburl + "mail/reg.aspx?id=" + _users.id, ss = "";

                //Response.Write(url);
                //Response.End();
                mailContent = ljd.function.GetPage(url, out ss);
               // 發送郵件
                TWMail.sendMail(config.emailsmtp, config.emailssl,config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, _users.email, mailTitle, mailContent);
            }
            catch (Exception eee) { }
            Response.Write(ljd.function.LocalHint("已發送帳號啟用信至您的電子信箱，請至信箱確認並啟用。", "regno.aspx"));
            Response.End();
        }
    }
}