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
    protected int id;
    protected Tea.Model.users model = null;
    Tea.BLL.users bll = new Tea.BLL.users();
    protected string weburl;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = TWRequest.GetQueryInt("id");
        if (id != 0)
        {
            model = bll.GetModel(id);
            weburl = config.weburl;
        }
    }
}
