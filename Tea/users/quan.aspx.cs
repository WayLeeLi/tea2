using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class users_quan : Tea.Web.UI.UserPage
{
    protected int totalCount;
    protected int page;
    protected int pageSize = 20;
    protected string _sql = "quan_begin_date<=getdate() and quan_end_date>=getdate()", _orderby = "quan_add_date desc", key;

    protected void Page_Load(object sender, EventArgs e)
    {

        key = TWRequest.GetQueryString("key");
        this.page = TWRequest.GetQueryInt("page", 1);

        _sql =_sql +" and quan_where='zhe'";
        Tea.BLL.article bll = new Tea.BLL.article();
 
        Tea.Web.UI.ShopPage bll_view = new Tea.Web.UI.ShopPage();

        data_list.DataSource = bll_view.GetViewList("shop_quan", "", this.pageSize, this.page, _sql, _orderby, out this.totalCount);
        data_list.DataBind();

        string pageUrl = Utils.CombUrlTxt("quan.aspx", "key={0}&page={1}", key.ToString(), "__id__");
        PageContent.InnerHtml = Utils.OutPageListWeb(this.pageSize, this.page, this.totalCount, pageUrl, 8);

    }

    public string gettitle(string quan_des)
    {
        string str = "";
        try
        {
            DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select * from view_goods where id in(" + quan_des + ")");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                str = str + dr["title"].ToString() + ",";
            }

            str = Utils.DelLastComma(str);
        }
        catch (Exception eee) { }
        return str;
    }

}