using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class help : Tea.Web.UI.ShopPage
{
    protected int tid,id;
    protected string sql = "channel_id=1 and status=0 and datediff(minute,add_time,getdate())>=0";
    protected void Page_Load(object sender, EventArgs e)
    {
        tid = TWRequest.GetQueryInt("tid");
        id = TWRequest.GetQueryInt("id");
        DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select  * from shop_basic where basic_where='help' order by basic_sort");
        data_type.DataSource = ds;
        data_type.DataBind();
        if (tid == 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                tid = Utils.StrToInt(ds.Tables[0].Rows[0]["basic_value"].ToString(), 0);
            }
        }
        if (tid > 0)
        {
            sql = "channel_id=1 and category_id=" + tid + " and status=0 and datediff(minute,add_time,getdate())>=0";
        }
        if (id > 0)
        {
            sql = "id="+id+"";
        }
        data_list.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from shop_about where " + sql + "  order by sort_id desc,id desc");
        data_list.DataBind();
    }
}
