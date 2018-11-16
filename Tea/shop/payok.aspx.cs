using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class order : Tea.Web.UI.UserPage
{
    protected int id;
    protected Tea.BLL.orders bll = new Tea.BLL.orders();
    protected Tea.Model.orders model = null;
    protected Tea.Model.payment payModel;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = TWRequest.GetQueryInt("id");
        if (id > 0)
        {
            model = bll.GetModel(id);
            if (model.user_id != userModel.id)
            {
                Response.Redirect("/");
            }
            payModel = new Tea.BLL.payment().GetModel(model.payment_id);
            if (payModel == null)
            {
                payModel = new Tea.Model.payment();
            }
            data_cart.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from shop_order_goods where order_id=" + id + "");
            data_cart.DataBind();

            data_gift.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from view_order_gift where order_id=" + id + "");
            data_gift.DataBind();
        }
    }
    public string getuseradd(string useradd,int i)
    {
        string str = "";
        try
        {
            str = useradd.Split('|')[i].ToString();
        }
        catch (Exception eee) { }
        return str;
    }

    public string getpeisong(string title)
    {
        string str = "";
        try
        {
            if (title == "台灣")
            {
                str = "宅配";
            }
            else
            {
                str = "國際快捷"; 
            }
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
    public string get_invoice(string title,int i)
    {
        string str = "";
        try
        {
            str = title.Split(',')[i].ToString();
        }
        catch (Exception eee) { }
        return str;
    }
    public string getpoint(string by, string name)
    {
        string str = name;
        try
        {
            if (by == "point" && name == "show")
            {
                str = "detail";
            }
        }
        catch (Exception eee) { }
        return str;
    }
    public string getpoint(string by, int i)
    {
        string str = "";
        try
        {
            if (by != "point" && i == 2)
            {
                str = " style=\"display:none;\"";
            }

            if (by == "point" && i != 2)
            {
                str = " style=\"display:none;\"";
            }

        }
        catch (Exception eee) { }
        return str;
    }

    public string get_sub(string id)
    {
        string str = "";
        try
        {
            str = new Tea.BLL.article().GetModel(int.Parse(id)).sub_title;
        }
        catch (Exception eee) { }
        return str;
    }
}
