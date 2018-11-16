using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class users_out : Tea.Web.UI.ShopPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session[TWKeys.SESSION_USER_INFO] = null;
        Utils.WriteCookie(TWKeys.COOKIE_USER_NAME_REMEMBER, "Tea", "1", -1);
        Utils.WriteCookie(TWKeys.COOKIE_USER_PWD_REMEMBER, "Tea", "1", 1);
        Response.Redirect("/users/login.aspx");
    }
}