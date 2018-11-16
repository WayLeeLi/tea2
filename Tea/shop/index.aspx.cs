using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class index : Tea.Web.UI.ShopPage
{
    protected Tea.Model.article model = null;
    Tea.BLL.article bll = new Tea.BLL.article();
    protected int totalCount;
    protected int page;
    protected int pageSize = 20;
    protected string _sql = "(datediff(day,xia_date,getdate())<=0 or xia_date is null) and status=0 and datediff(minute,add_time,getdate())>=0 and brand_id in(1,2,3,5)", _orderby = "add_time desc,id desc", key, tname;
    protected int tid;
    protected int hid;
    protected int sort;
    protected Tea.Model.users _users = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        _users = new Tea.Web.UI.ShopPage().GetUserInfo();
        data_type.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from shop_article_category where channel_id=7 and call_index='1' order by sort_id desc");
        data_type.DataBind();
 
        key = TWRequest.GetQueryString("key");
        this.page = TWRequest.GetQueryInt("page", 1);
        this.tid = TWRequest.GetQueryInt("tid", 0);
        this.hid = TWRequest.GetQueryInt("hid", 0);
        this.sort = TWRequest.GetQueryInt("sort", 0);
      
 
        if (sort == 1)
        {
            _orderby = "add_time desc,id desc";
        }
        if (sort == 2)
        {
            _orderby = "click desc";
        }
        if (sort == 3)
        {
            _orderby = "market_price,id";
        }
        if (sort == 4)
        {
            _orderby = "market_price desc,id";
        }
        if (tid != 0)
        {
            _sql = _sql + " and (category_id=" + tid + " or more_type like'%," + tid + ",%')";
            tname = new Tea.BLL.article_category().GetTitle(tid);
            try
            {
                Tea.Model.article_category model = new Tea.BLL.article_category().GetModel(tid);
                title = model.seo_title;
                keyword = model.seo_keywords;
                describe = model.seo_description;
            }
            catch (Exception eee) { }
        }
        if (!string.IsNullOrEmpty(key))
        {
            _sql = _sql + " and title like'%" + key + "%'";
            tname = key;
        }
        Tea.Web.UI.ShopPage bll_view = new Tea.Web.UI.ShopPage();

        data_list.DataSource = bll_view.GetViewList("view_article_product", "", this.pageSize, this.page, _sql, _orderby, out this.totalCount);
        data_list.DataBind();

        string pageUrl = Utils.CombUrlTxt("index.aspx", "tid={0}&key={1}&sort={2}&page={3}", tid.ToString(), key.ToString(),sort.ToString(), "__id__");
        PageContent.InnerHtml = Utils.OutPageListWeb(this.pageSize, this.page, this.totalCount, pageUrl, 8);

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