using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class news : Tea.Web.UI.ShopPage
{
    protected int totalCount;
    protected int page;
    protected int pageSize = 20;
    protected string _sql = "channel_id=3 and status=0 and datediff(minute,add_time,getdate())>=0 and (datediff(day,update_time,getdate())<=0 or update_time is null) ", _orderby = "sort_id desc,add_time desc,id desc", key;
    protected int tid;
    protected int sort;
    protected void Page_Load(object sender, EventArgs e)
    {


        key = TWRequest.GetQueryString("key");
        this.page = TWRequest.GetQueryInt("page", 1);
        this.tid = TWRequest.GetQueryInt("tid", 0);
        this.sort = TWRequest.GetQueryInt("sort", 0);
        DataSet ds = new Tea.BLL.basic().GetList(0, "basic_where='news'", "basic_sort");
        data_news.DataSource = ds;
        data_news.DataBind();
        if (tid == 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                tid = Utils.StrToInt(ds.Tables[0].Rows[0]["basic_value"].ToString(), 0);
            }
        }
        if (sort == 1)
        {
            _orderby = "add_time desc,id desc";
        }
        if (sort == 2)
        {
            _orderby = "add_time,id";
        }
        if (tid != 0)
        {
            _sql = _sql + " and category_id=" + tid + "";
        }
        if (!string.IsNullOrEmpty(key))
        {
            _sql = _sql + " and title like'%" + key + "%'";
        }
        Tea.Web.UI.ShopPage bll_view = new Tea.Web.UI.ShopPage();

 
        data_list.DataSource = bll_view.GetViewList("shop_about", "", this.pageSize, this.page, _sql, _orderby, out this.totalCount);
        data_list.DataBind();

        string pageUrl = Utils.CombUrlTxt("news.aspx", "tid={0}&sort={1}&page={2}", sort.ToString(), "__id__");
        PageContent.InnerHtml = Utils.OutPageListWeb(this.pageSize, this.page, this.totalCount, pageUrl, 8);

    }
}