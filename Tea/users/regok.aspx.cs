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
    protected string act,code;
    protected int id;
    Tea.BLL.users bll = new Tea.BLL.users();
    protected void Page_Load(object sender, EventArgs e)
    {
        id = TWRequest.GetQueryInt("id");
        code=TWRequest.GetQueryString("code");
        Tea.Model.users model = bll.GetModel(id);
        if (model.password != code)
        {
            Response.Write(ljd.function.LocalHint("郵箱驗證失敗,請重新驗證", "reg.aspx"));
        }
        else
        {
            model.status = 0;
            bll.Update(model);
        }
    }
}