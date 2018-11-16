using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
public partial class public_hand : System.Web.UI.UserControl
{
    protected internal Tea.Model.siteconfig config = new Tea.BLL.siteconfig().loadConfig();
    protected int quan = 0,id;
    protected int tcode;
    protected Tea.Model.users _users = null;
    protected Tea.Model.cart_total cartModel = new Tea.Model.cart_total();
    protected void Page_Load(object sender, EventArgs e)
    {
        data_type.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from shop_article_category where channel_id=7 and call_index='1' order by sort_id desc");
        data_type.DataBind();
 
        _users = new Tea.Web.UI.ShopPage().GetUserInfo();
       
        cartModel = Tea.Web.UI.ShopCart.GetTotal(1);
    }
}