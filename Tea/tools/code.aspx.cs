using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tea.Common;
using System.Collections;
public partial class tools_code : Tea.Web.UI.ShopPage
{
    protected int cart;
    protected string key;
    protected Tea.Model.cart_total cartModel = new Tea.Model.cart_total();
    protected void Page_Load(object sender, EventArgs e)
    {
        cart = TWRequest.GetFormInt("cart");
        if (cart == 1)
        {
            cart = -1;
        }
        if (cart == 2)
        {
            cart = -2;
        }
        if (cart == 3)
        {
            cart = -3;
        }
        cartModel = Tea.Web.UI.ShopCart.GetTotal(cart);
        key = TWRequest.GetFormString("key");
        if (!string.IsNullOrEmpty(key))
        {
            int a = 0;
            Tea.Model.quan model= new Tea.BLL.quan().GetModel(key);
            if (model != null)
            {
                if (model.quan_des.Trim().Length < 2)
                {
                    a = 1;
                }
                IList _list = model.quan_des.Split(',');
                IList c_list = cartModel.total_num_str.Split(',');
                foreach (object ob in c_list)
                {
                    if (!string.IsNullOrEmpty(ob.ToString()) && ob.ToString() != "0")
                    {
                        if (_list.Contains(ob.ToString()))
                        {
                            a = 1;
                        }
                    }
                }
                int zhe_code = Tea.DBUtility.DbHelperSQL.Query("select id from shop_orders where zhe_code='" + key + "'").Tables[0].Rows.Count;
                //Response.Write(a+"--"+model.quan_des + "--" + cartModel.total_num_str);
                if (model.quan_where == "zhe")
                {
                    if (a > 0 && model != null && model.quan_sort > zhe_code && model.quan_end_date >= System.DateTime.Now && model.quan_begin_date <= System.DateTime.Now)
                    {
                        Response.Write("{\"info\":\"" + model.quan_num.GetValueOrDefault().ToString("0.") + "\", \"status\":\"1\" }");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("{\"status\":\"0\",\"info\":\"1\" }");
                        Response.End();
                    }
                }
                if (model.quan_where == "lin")
                {
                    if (a > 0 &&  model.quan_end_date >= System.DateTime.Now && model.quan_begin_date <= System.DateTime.Now &&  model.quan_sort > zhe_code)
                    {
                        Response.Write("{\"info\":\"" + model.quan_num.GetValueOrDefault().ToString("0.") + "\", \"status\":\"1\" }");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("{\"status\":\"0\",\"info\":\"" + a + "\" }");
                        Response.End();
                    }
                }
                Response.Write("{\"status\":\"0\",\"info\":\"3\" }");
                Response.End();
            }
            else
            {
                Response.Write("{\"status\":\"0\",\"info\":\"4\" }");
                Response.End();
            }

        }
        else
        {
            Response.Write("{\"status\":\"0\",\"info\":\"5\"}");
            Response.End();
        }
    }
}