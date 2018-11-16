using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class public_foot : System.Web.UI.UserControl
{
    protected internal Tea.Model.siteconfig config = new Tea.BLL.siteconfig().loadConfig();
    protected Tea.Model.users _users = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        _users = new Tea.Web.UI.ShopPage().GetUserInfo();

    }
}