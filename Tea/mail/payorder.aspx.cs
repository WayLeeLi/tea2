using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class order : Tea.Web.UI.ShopPage
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
            weburl = Utils.DelLastChar(weburl, "/");
            model = bll.GetModel(id);
            data_cart.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from shop_order_goods where order_id=" + id + "");
            data_cart.DataBind();
        }
    }

    public string getuseradd(string useradd, int i)
    {
        string str = "";
        try
        {
            str = useradd.Split('|')[i].ToString();
        }
        catch (Exception eee) { }
        return str;
    }
    public string getinvoice(string id)
    {
        string str = "";
        if (id == "1")
        {
            str = "電子發票";
        }
        if (id == "2")
        {
            str = "發票捐贈";
        }
        if (id == "3")
        {
            str = "二聯式發票";
        }
        if (id == "4")
        {
            str = "三聯式發票";
        }
        return str;
    }
    public string get_invoice(string title, int i)
    {
        string str = "";
        try
        {
            str = title.Split(',')[i].ToString();
        }
        catch (Exception eee) { }
        return str;
    }
}