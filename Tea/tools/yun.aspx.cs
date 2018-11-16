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
    protected string key,group,city,type;
    protected Tea.Model.cart_total cartModel = new Tea.Model.cart_total();
    protected string yun;
    protected int cart;
    protected void Page_Load(object sender, EventArgs e)
    {
        key = TWRequest.GetFormString("key");
        cart= TWRequest.GetFormInt("cart");
        DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select basic_value,basic_type from  shop_basic where basic_label='" + key + "' and basic_where='city'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            city = ds.Tables[0].Rows[0]["basic_type"].ToString();       
        }
        if (key == "台灣")
        {
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
            if (cartModel.real_amount > oconfig.yunmian)
            {
                Response.Write("{\"info\":\"0\", \"status\":\"1\" }");
            }
            else
            {
                Response.Write("{\"info\":\""+oconfig.yunfei+"\", \"status\":\"1\" }");
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(key) && cart > 0)
            {
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

                DataSet d_s = Tea.DBUtility.DbHelperSQL.Query("select top 1 basic_sort from shop_basic where basic_money>=" + cartModel.total_num_zhe.ToString("0.00") + " and basic_where='yunfei' and basic_type='" + city + "' order by basic_money");

               
                if (d_s.Tables[0].Rows.Count > 0)
                {
                    yun = Utils.StrToInt(d_s.Tables[0].Rows[0][0].ToString(), 0).ToString();
                    Response.Write("{\"info\":\"" + yun +"\", \"status\":\"1\" }");
                }
                else
                {
                    Response.Write("{\"status\":\"2\" }");
                }

                //Response.Write(cartModel.total_num_zhe.ToString("0.") + city);
            }
            else
            {
                Response.Write("{\"info\":\"0\", \"status\":\"1\" }");
            }
        }
    }
}