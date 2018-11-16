using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tea.Common;
using System.Text;
public partial class admin_users_goods : Tea.Web.UI.ManagePage
{
    protected int channel_id;
    protected int totalCount;
    protected int page;
    protected int pageSize;
    protected int category_id;
    protected string channel_name = string.Empty;
    protected string property = string.Empty;
    protected string keywords = string.Empty;
    protected string goods_ids = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        ChkAdminLevelEdit("user_list", "Edit");
        this.channel_id = TWRequest.GetQueryInt("channel_id");
        this.category_id = TWRequest.GetQueryInt("category_id");
        this.keywords = TWRequest.GetQueryString("keywords");
        this.property = TWRequest.GetQueryString("property");
        this.goods_ids = TWRequest.GetQueryString("goods_ids");

        if (channel_id == 0)
        {
            JscriptMsg("頻道參數不正確！", "back", "Error");
            return;
        }
        this.channel_name = new Tea.BLL.channel().GetChannelName(this.channel_id); //取得頻道名稱
        this.pageSize = GetPageSize(50); //每頁數量
        if (!Page.IsPostBack)
        {
            TreeBind(this.channel_id); //綁定類別
            if (!string.IsNullOrEmpty(goods_ids))
            {
                RptBind(this.channel_id, this.category_id, "wheresql='tuan' and brand_id=1" + CombSqlTxt(this.keywords, this.property), "id desc");
            }
            else
            {
                RptBind(this.channel_id, this.category_id, "wheresql='tuan' and brand_id=1" + CombSqlTxt(this.keywords, this.property), "id desc");
            }
        }
    }

    #region 綁定類別=================================
    private void TreeBind(int _channel_id)
    {
        Tea.BLL.article_category bll = new Tea.BLL.article_category();
        DataTable dt = bll.GetList(0, _channel_id);

        this.ddlCategoryId.Items.Clear();
        this.ddlCategoryId.Items.Add(new ListItem("所有類別", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            int ClassLayer = int.Parse(dr["class_layer"].ToString());
            string Title = dr["title"].ToString().Trim();

            if (ClassLayer == 1)
            {
                this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
            }
            else
            {
                Title = "├ " + Title;
                Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
            }
        }
    }
    #endregion

    #region 資料綁定=================================
    private void RptBind(int _channel_id, int _category_id, string _strWhere, string _orderby)
    {
        string _sql = "";
        this.page = TWRequest.GetQueryInt("page", 1);
        if (this.category_id > 0)
        {
            this.ddlCategoryId.SelectedValue = _category_id.ToString();
            _sql = _sql + " and category_id in(select id from shop_article_category where class_list like '%," + _category_id + ",%')";
        }
        this.txtKeywords.Text = this.keywords;
        //圖表或列表顯示
        Tea.Web.UI.ShopPage bll_view = new Tea.Web.UI.ShopPage();
        this.rptList1.DataSource = bll_view.GetViewList("view_user_group_price", "", this.pageSize, this.page, _strWhere + _sql, _orderby, out this.totalCount);
        this.rptList1.DataBind();
        //綁定頁碼
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("goods.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&page={4}&goods_ids={5}", _channel_id.ToString(), _category_id.ToString(), this.keywords, this.property, "__id__", this.goods_ids);
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
    }
    #endregion

    #region 組合SQL查詢語句==========================
    protected string CombSqlTxt(string _keywords, string _property)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");

        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and (title like '%" + _keywords + "%' or goods_no like '%" + _keywords + "%')");
        }
        if (!string.IsNullOrEmpty(_property))
        {
            strTemp.Append(" and group_id=" + _property + "");
        }
        return strTemp.ToString();
    }
    #endregion

    #region 返回圖文每頁數量=========================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("group_page_size"), out _pagesize))
        {
            if (_pagesize > 0)
            {
                return _pagesize;
            }
        }
        return _default_size;
    }
    #endregion

    //關鍵字查詢
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("goods.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&goods_ids={4}", this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property, this.goods_ids));
    }

    //篩選類別
    protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("goods.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&goods_ids={4}", this.channel_id.ToString(), ddlCategoryId.SelectedValue, this.keywords, this.property, this.goods_ids));
    }

    //設定分頁數量
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("group_page_size", _pagesize.ToString(), 43200);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("goods.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&property={3}", this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.goods_ids));
    }
    //匯出CSV
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ChkAdminLevelEdit("user_list", "Edit");
        string strurl = "0";
        Utils.WriteCookie("shop_cart_list", "");
        for (int ai = 0; ai < rptList1.Items.Count; ai++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList1.Items[ai].FindControl("hidId")).Value);
            int pid = Convert.ToInt32(((HiddenField)rptList1.Items[ai].FindControl("pId")).Value);
            CheckBox cb = (CheckBox)rptList1.Items[ai].FindControl("chkId");
            int sortId;
            if (!int.TryParse(((TextBox)rptList1.Items[ai].FindControl("txtSortId")).Text.Trim(), out sortId))
            {
                sortId = 1;
            }
            if (cb.Checked)
            {
                Tea.Web.UI.AdminCart.Add(pid + "_" + id, sortId);
                strurl = strurl + "," + id.ToString();
            }
        }
        if (strurl.Length > 1)
        {
            Response.Write(ljd.function.Hint("去下單", "/shop/adminorder.aspx?uid=" + property));
            Response.End();
        }
    }
}