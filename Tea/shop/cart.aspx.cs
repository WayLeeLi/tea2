using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class cart : Tea.Web.UI.UserPage
{
    protected string yun, strurl = "/Default.aspx", strurl1 = "/Default.aspx", act, key, kdel, kup;
    protected int show = 0, show1 = 0, show2 = 0, hong, num, cartnum, cartnum1, cartnum2, cs;
    protected decimal honglv = 1;
    protected Tea.Model.cart_total cartModel = new Tea.Model.cart_total();
    protected int giftnum = 0;
    protected string id, cid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(userModel.sex) || string.IsNullOrEmpty(userModel.birthday.GetValueOrDefault().ToString()))
        {
            HttpContext.Current.Response.Write(ljd.function.LocalHint("請完善您的性別和生日資料", "/users/index.aspx"));
            HttpContext.Current.Response.End();
        }
        num = TWRequest.GetQueryInt("num", 1);
        act = TWRequest.GetQueryString("act");
        key = TWRequest.GetQueryString("key");
        kdel = TWRequest.GetQueryString("kdel");
        kup = TWRequest.GetQueryString("kup");
        cs = TWRequest.GetQueryInt("cs");

        //Response.Write(Utils.GetCookie(TWKeys.COOKIE_SHOPPING_CART));
        if (!string.IsNullOrEmpty(kdel) && !string.IsNullOrEmpty(kup))
        {
            int gid = Utils.StrToInt(kup.Split('_')[1].ToString(), 0);
            Tea.Model.goods modelg = new Tea.BLL.goods().GetModel(gid);
            if (modelg.stock_quantity <= num)
            {
                Response.Write(ljd.function.LocalHint("超出庫存無法購買", "cart.aspx?cs=" + cs));
                Response.End();
            }
            if (num > config.txt_Da)
            {
                Response.Write(ljd.function.LocalHint("超出最大購買數量", "cart.aspx?cs=" + cs));
                Response.End();
            }
            Tea.Web.UI.ShopCart.Add(kup, num);

            Tea.Web.UI.ShopCart.Clear(kdel);


            Response.Redirect("cart.aspx?cs=" + cs);
        }
        if (!string.IsNullOrEmpty(key) && num > 0 && !string.IsNullOrEmpty(act))
        {
            if (act == "update" && num > 0)
            {
                int gid = Utils.StrToInt(key.Split('_')[1].ToString(), 0);
                Tea.Model.goods modelg = new Tea.BLL.goods().GetModel(gid);
                if (modelg.stock_quantity < num)
                {
                    Response.Write(ljd.function.LocalHint("超出庫存無法購買", "cart.aspx?cs=" + cs));
                    Response.End();
                }
                if (num > config.txt_Da)
                {
                    Response.Write(ljd.function.LocalHint("超出最大購買數量", "cart.aspx?cs=" + cs));
                    Response.End();
                }
                Tea.Web.UI.ShopCart.Update(key, num);
            }
            if (act == "add")
            {
                int gid = Utils.StrToInt(key.Split('_')[1].ToString(), 0);
                Tea.Model.goods modelg = new Tea.BLL.goods().GetModel(gid);
                if (modelg.stock_quantity <= num)
                {
                    Response.Write(ljd.function.LocalHint("超出庫存無法購買", "cart.aspx?cs=" + cs));
                    Response.End();
                }
                if ((num + 1) > config.txt_Da)
                {
                    Response.Write(ljd.function.LocalHint("超出最大購買數量", "cart.aspx?cs=" + cs));
                    Response.End();
                }
                Tea.Web.UI.ShopCart.Update(key, num = num + 1);
            }
            if (act == "del" && num > 1)
            {
                int gid = Utils.StrToInt(key.Split('_')[1].ToString(), 0);
                Tea.Model.goods modelg = new Tea.BLL.goods().GetModel(gid);
                if (modelg.stock_quantity < 1)
                {
                    Response.Write(ljd.function.LocalHint("超出庫存無法購買", "cart.aspx?cs=" + cs));
                    Response.End();
                }
                Tea.Web.UI.ShopCart.Update(key, num = num - 1);
            }
            Response.Redirect("cart.aspx?cs=" + cs);
        }
        id = TWRequest.GetQueryString("id");
        if (!string.IsNullOrEmpty(id))
        {
            try
            {
                int g_id = Utils.StrToInt(id.Split('_')[0].ToString(), 0);
                int gid = Utils.StrToInt(id.Split('_')[1].ToString(), 0);
                Tea.Model.goods modelg = new Tea.BLL.goods().GetModel(gid);
                if (modelg.stock_quantity < 1)
                {
                    Response.Write(ljd.function.LocalHint("超出庫存無法購買", "cart.aspx?cs=" + cs));
                    Response.End();
                }

                if (num > config.txt_Da)
                {
                    Response.Write(ljd.function.LocalHint("超出最大購買數量", "cart.aspx?cs=" + cs));
                    Response.End();
                }
                if (new Tea.BLL.article().GetModel(g_id).wheresql == "jiajia")
                {
                    if (id.ToString().Split('_').Length == 2)
                    {
                        Tea.Web.UI.ShopCart.Add(id + "_1", num);
                    }
                    else
                    {
                        Tea.Web.UI.ShopCart.Add(id, num);
                    }
                }
                else
                {
                    Tea.Web.UI.ShopCart.Add(id, num);
                }
            }
            catch (Exception eee) { }
            Response.Redirect("cart.aspx?cs=" + cs);
        }
        try
        {
            strurl = Request.UrlReferrer.AbsoluteUri.ToString();

            if (strurl.Contains("tea.") && !strurl.Contains("login.aspx") && !strurl.Contains("out.aspx") && !strurl.Contains("member"))
            {
                Utils.WriteCookie("carturl", strurl);
            }
        }
        catch (Exception eee)
        { }



        strurl = Utils.GetCookie("carturl");
        if (string.IsNullOrEmpty(strurl))
        {
            strurl = "/shop/index.aspx";
        }
        strurl = "/shop/index.aspx";
        string del = TWRequest.GetQueryString("del");
        if (!string.IsNullOrEmpty(del))
        {
            Tea.Web.UI.ShopCart.Clear(del);

            Response.Redirect("cart.aspx?cs=" + cs);
        }
        if (cs == 0)
        {
            try
            {
                if (Tea.Web.UI.ShopCart.GetList(-3).Count > 0)
                {
                    cs = 3;
                }
            }
            catch (Exception eee) { }
            try
            {
                if (Tea.Web.UI.ShopCart.GetList(-2).Count > 0)
                {
                    cs = 2;
                }
            }
            catch (Exception eee) { }
            try
            {
                if (Tea.Web.UI.ShopCart.GetList(-1).Count > 0)
                {
                    cs = 1;
                }
            }
            catch (Exception eee) { }

        }
        if (cs == 1)
        {
            cartModel = Tea.Web.UI.ShopCart.GetTotal(-1);
        }
        if (cs == 2)
        {
            cartModel = Tea.Web.UI.ShopCart.GetTotal(-2);
        }
        if (cs == 3)
        {
            cartModel = Tea.Web.UI.ShopCart.GetTotal(-3);
        }

        data_cart.DataSource = Tea.Web.UI.ShopCart.GetList(-1);
        data_cart.DataBind();

        data_tejia.DataSource = Tea.Web.UI.ShopCart.GetList(-2);
        data_tejia.DataBind();


        data_vip.DataSource = Tea.Web.UI.ShopCart.GetList(-3);
        data_vip.DataBind();

        cartnum = data_cart.Items.Count;
        cartnum1 = data_tejia.Items.Count;
        cartnum2 = data_vip.Items.Count;

        show = cartnum + cartnum1 + cartnum2;
        if (cartnum > 0)
        {
            cid = "1";
        }
        else
        {
            if (cartnum2 > 0)
            {
                cid = "3";
            }
            if (cartnum1 > 0)
            {
                cid = "2";
            }
        }

        data_jiajia.DataSource = Tea.DBUtility.DbHelperSQL.Query("select top 12 * from view_goods where (datediff(day,xia_date,getdate())<=0 or xia_date is null) and  status=0 and wheresql='jiajia' and datediff(minute,add_time,getdate())>=0 and stock_quantity>0 order by sort_id desc");
        data_jiajia.DataBind();

        string year = System.DateTime.Now.ToString("yyyyMM");

        DataSet ddss = Tea.DBUtility.DbHelperSQL.Query("select top 1 * from shop_gift where brand_id=" + year + " and status=1 and left_quantity>0 and amount<=" + (cartModel.real_amount - cartModel.total_moneyback) + "");

        if (ddss.Tables[0].Rows.Count > 0)
        {
            decimal amount = Utils.StrToDecimal(ddss.Tables[0].Rows[0]["amount"].ToString(), 0);
            data_gift.DataSource = ddss;
            data_gift.DataBind();

            datagift.DataSource = ddss;
            datagift.DataBind();

            giftnum = Utils.StrToInt(((cartModel.real_amount - cartModel.total_moneyback) / amount).ToString().Split('.')[0].ToString(), 0);
        }
        //Response.Write("select top 1 * from shop_gift where brand_id=" + year + " and status=1 and left_quantity>0 and amount<=" + cartModel.real_amount + "");

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
    public string getcolor(string id, string gid, string num, int cs)
    {
        string str = "";
        try
        {
            DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select * from shop_goods where parent_id=" + id + "");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                str = str + "<option " + getcheck(dr["id"].ToString(), gid) + " value=\"cart.aspx?cs=" + cs + "&num=" + num + "&kdel=" + id + "_" + gid + "&kup=" + dr["parent_id"].ToString() + "_" + dr["id"].ToString() + "\">" + dr["guige"].ToString() + "</option>";
            }
        }
        catch (Exception eee) { }
        return str;
    }
    public string getcheck(string id, string gid)
    {
        string str = "";
        if (id == gid)
        {
            str = " selected=\"selected\"";
        }
        return str;
    }
    public string get_price(string market, string sell)
    {
        string str = market;
        try
        {
            if (Utils.StrToInt(sell, 0) > 0 && Utils.StrToInt(sell, 0) < Utils.StrToInt(market, 0))
            {
                str = sell;
            }
        }
        catch (Exception eee) { }
        return str;
    }
    public string getprice(string id)
    {
        string str = "異常";
        try
        {
            DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select * from shop_goods where parent_id=" + id + " order by sell_price");

            if (ds.Tables[0].Rows.Count > 0)
            {
                str = getyunum(Utils.StrToInt(ds.Tables[0].Rows[0]["yu_lock"].ToString(), 0), Utils.StrToDecimal(ds.Tables[0].Rows[0]["sell_price"].ToString(), 0), Utils.StrToDecimal(ds.Tables[0].Rows[0]["yu_num"].ToString(), 0)).ToString("0.");
            }
        }
        catch (Exception eee) { }
        return str;
    }
}
