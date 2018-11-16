using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class index : Tea.Web.UI.User_Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("edituser.aspx");
    }
}
