using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class show : Tea.Web.UI.ShopPage
{
    protected int id, showpic, stock_quantity;
    protected Tea.Model.article model = null;
    Tea.BLL.article bll = new Tea.BLL.article();
    protected string histroy, chutime, tname, goodlist, cartid;
    protected string goodsid = "0", goods_color = "0", market_price, sell_price, img_url, que;
    protected Tea.Model.users _users = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        _users = new Tea.Web.UI.ShopPage().GetUserInfo();

        data_type.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from shop_article_category where channel_id=7 and call_index='1' order by sort_id desc");
        data_type.DataBind();


      

        id = TWRequest.GetQueryInt("id");
        if (id != 0)
        {
            model = bll.GetModel(id);
            title = model.seo_title;
            keyword = model.seo_keywords;
            describe = model.seo_description;
            bll.UpdateField(id, "click=click+1");
           
            img_url = model.img_url;

            data_pic.DataSource = model.albums;
            data_pic.DataBind();

            data_pic1.DataSource = model.albums;
            data_pic1.DataBind();

            data_pic2.DataSource = model.albums;
            data_pic2.DataBind();

            showpic = data_pic.Items.Count;
        }



        data_tui.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from view_article_product where (datediff(day,xia_date,getdate())<=0 or xia_date is null) and status=0 and datediff(minute,add_time,getdate())>=0 and  id!=" + id + " and wheresql='tuan' and category_id=" + model.category_id + "");
        data_tui.DataBind();


        

        if (model.status == 0)
        {
            DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select * from shop_goods where parent_id=" + id + "");
            data_goods.DataSource = ds;
            data_goods.DataBind();
            goodlist="";
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                goodlist = goodlist + "\"" + dr["parent_id"].ToString() + "_" + dr["id"].ToString() + "\": { \"cartid\": \"" + dr["parent_id"].ToString() + "_" + dr["id"].ToString() + "\",\"price\": \"" + model.point + "\", \"mktprice\": \"" + model.point + "\" , \"stock_quantity\": \"" + dr["stock_quantity"].ToString() + "\", \"img_url\": \"" + dr["img_url"].ToString() + "\"},";
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
               
                cartid = ds.Tables[0].Rows[0]["parent_id"].ToString() + "_" + ds.Tables[0].Rows[0]["id"].ToString();
                stock_quantity = Utils.StrToInt(ds.Tables[0].Rows[0]["stock_quantity"].ToString(), 0);
                model.sell_price = Utils.StrToDecimal(ds.Tables[0].Rows[0]["sell_price"].ToString(), 0);
                model.market_price = Utils.StrToDecimal(ds.Tables[0].Rows[0]["market_price"].ToString(), 0);
                model.img_url = ds.Tables[0].Rows[0]["img_url"].ToString();
            }
        }
       
        try
        {
            histroy = Request.Cookies["histroy"].Value.ToString();
        }
        catch (Exception eee) { }
        if (string.IsNullOrEmpty(histroy))
        {
            Response.Cookies["histroy"].Value = id.ToString();

            Response.Cookies["histroy"].Expires = System.DateTime.Now.AddSeconds(30000000);
            histroy = Request.Cookies["histroy"].Value.ToString();
        }
        else
        {
            IList _list = histroy.Split('|');
            if (!_list.Contains(id))
            {
                Response.Cookies["histroy"].Value = histroy + "|" + id;
            }
        }
    }

    public string get_sales(string id)
    {
        string str = "";
        try
        {
            Tea.Model.article model = new Tea.BLL.article().GetModel(int.Parse(id));
            if (model.sell_price > 0 && model.sell_price < model.market_price)
            {
                str = "<a><img src=\"/images/ico-yh.gif\" alt=\"優惠中\" /></a>";
            }
            DataSet d_s_s = Tea.DBUtility.DbHelperSQL.Query("select id from shop_goods where parent_id=" + id + " and yu_lock>0");
            if (d_s_s.Tables[0].Rows.Count > 0)
            {
                str = "<a><img src=\"/images/ico-yh.gif\" alt=\"優惠中\" /></a>";
            }
            if (model.brand_id == 2)
            {
                str = str + "<a><img src=\"/images/ico-yg1.gif\" alt=\"預購\" /></a>";
            }
        }
        catch (Exception eee) { }
        return str;
    }
    public string gettag(string tags, int i)
    {
        string str = "";
        try
        {
            str = tags.Split('$')[i].ToString();
        }
        catch (Exception eee) { }
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
