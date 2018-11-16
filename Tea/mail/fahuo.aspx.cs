using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class fahuo : Tea.Web.UI.ShopPage
{
    protected int id;
    protected Tea.Model.orders model = null;
    Tea.BLL.orders bll = new Tea.BLL.orders();
    protected string weburl;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = TWRequest.GetQueryInt("id");
        if (id != 0)
        {
            weburl = config.weburl;
            model = bll.GetModel(id);
        }
    }
}
