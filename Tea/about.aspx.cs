using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class about : Tea.Web.UI.ShopPage
{
    protected int id;
    protected Tea.Model.about model = null;
    Tea.BLL.about bll = new Tea.BLL.about();
    protected void Page_Load(object sender, EventArgs e)
    {
        id = TWRequest.GetQueryInt("id",1);
        if (id != 0)
        {
            model = bll.GetModel(id);
        }
    }
}
