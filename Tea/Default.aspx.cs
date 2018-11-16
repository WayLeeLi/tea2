using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class Default : Tea.Web.UI.ShopPage
{
    protected string sql = "status=0 and datediff(minute,add_time,getdate())>=0 and datediff(minute,end_time,getdate())<=0";
    protected int showte = 0, showtui = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        data_banner.DataSource = Tea.DBUtility.DbHelperSQL.Query("select top 40 * from shop_slide where (datediff(day,start_time,getdate())>=0 or start_time is null) and (datediff(day,end_time,getdate())<=0 or end_time is null) order by sort_id desc,id desc");
        data_banner.DataBind();

        DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select top 1 * from view_article_product where  (datediff(day,xia_date,getdate())<=0 or xia_date is null) and  status=0 and datediff(minute,add_time,getdate())>=0 and is_zhe=1 order by sort_id desc");
        data_one.DataSource = ds;
        data_one.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataSet ds1 = Tea.DBUtility.DbHelperSQL.Query("select top 1 * from view_article_product where  (datediff(day,xia_date,getdate())<=0 or xia_date is null) and status=0 and datediff(minute,add_time,getdate())>=0 and is_zhe=1 and id!=" + ds.Tables[0].Rows[0]["id"].ToString() + " order by sort_id desc");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                data_one1.DataSource = ds1;
                data_one1.DataBind();
            }

            if (ds1.Tables[0].Rows.Count > 0)
            {
                data_two.DataSource = Tea.DBUtility.DbHelperSQL.Query("select top 4 * from view_article_product where  (datediff(day,xia_date,getdate())<=0 or xia_date is null) and status=0 and datediff(minute,add_time,getdate())>=0 and is_zhe=1 and id!=" + ds.Tables[0].Rows[0]["id"].ToString() + " and id!=" + ds1.Tables[0].Rows[0]["id"].ToString() + " order by sort_id desc");
                data_two.DataBind();

            }
        }
        data_tui.DataSource = Tea.DBUtility.DbHelperSQL.Query("select top 12 * from view_article_product where  (datediff(day,xia_date,getdate())<=0 or xia_date is null) and  status=0 and datediff(minute,add_time,getdate())>=0 and is_tui=1 order by sort_id desc");
        data_tui.DataBind();

        showte = ds.Tables[0].Rows.Count;
        showtui = data_tui.Items.Count;
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
            DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select top 1 * from shop_goods where parent_id=" + id + " order by sell_price");

            if (ds.Tables[0].Rows.Count > 0)
            {
                str = getyunum(Utils.StrToInt(ds.Tables[0].Rows[0]["yu_lock"].ToString(), 0), Utils.StrToDecimal(ds.Tables[0].Rows[0]["sell_price"].ToString(), 0), Utils.StrToDecimal(ds.Tables[0].Rows[0]["yu_num"].ToString(), 0)).ToString("0.");
            }
        }
        catch (Exception eee) { }
        return str;
    }
}
