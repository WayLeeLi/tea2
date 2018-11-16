using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class goods : Tea.Web.UI.UserPage
{
    protected int totalCount;
    protected int page;
    protected int pageSize = 15, show = 0;
    protected string _sql = "1=1", _orderby = "id desc", key;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        
        key = TWRequest.GetQueryString("key");
        this.page = TWRequest.GetQueryInt("page", 1);
       
        _sql = "user_id=" + userModel.id + "";
        Tea.BLL.article bll = new Tea.BLL.article();
        
        if (!string.IsNullOrEmpty(key))
        {
            _sql = _sql + " and title like'%" + key + "%'";
        }
        Tea.Web.UI.ShopPage bll_view = new Tea.Web.UI.ShopPage();

        data_list.DataSource = bll_view.GetViewList("view_order_point", "", this.pageSize, this.page, _sql, _orderby, out this.totalCount);
        data_list.DataBind();
        show = data_list.Items.Count;
        string pageUrl = Utils.CombUrlTxt("pint.aspx", "key={0}&page={1}", key.ToString(), "__id__");
        PageContent.InnerHtml = Utils.OutPageListWeb(this.pageSize, this.page, this.totalCount, pageUrl, 8);

    }
    public string getshow(string num)
    { 
        string str="NT$";
        if(Utils.StrToInt(num,0)==0)
        {
            str = "";
        }
        return str;
    }
}