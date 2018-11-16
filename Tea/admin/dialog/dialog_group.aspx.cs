using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.dialog
{
    public partial class dialog_group : Web.UI.ManagePage
    {
        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int category_id;
        protected string channel_name = string.Empty;
 
        protected string keywords = string.Empty;
        protected string goods_ids = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = TWRequest.GetQueryInt("channel_id");
            this.category_id = TWRequest.GetQueryInt("category_id");
            this.keywords = TWRequest.GetQueryString("keywords");
            this.goods_ids = TWRequest.GetQueryString("goods_ids");

            if (channel_id == 0)
            {
                JscriptMsg("頻道參數不正確！", "back");
                return;
            }
            this.channel_name = new BLL.channel().GetChannelName(this.channel_id); //取得頻道名稱
            this.pageSize = GetPageSize(10); //每頁數量
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.View.ToString()); //檢查權限
                TreeBind(this.channel_id); //綁定類別
                RptBind(this.channel_id, this.category_id, "id not in(" + goods_ids + ") and wheresql='tuan' and brand_id=1" + CombSqlTxt(this.keywords, this.category_id), "id desc");
            }
        }

        #region 綁定類別=================================
        private void TreeBind(int _channel_id)
        {
            BLL.article_category bll = new BLL.article_category();
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
        private void RptBind(int _channel_id, int _category_id,string _strWhere, string _orderby)
        {
 
            this.page = TWRequest.GetQueryInt("page", 1);
            if (this.category_id > 0)
            {
                this.ddlCategoryId.SelectedValue = _category_id.ToString();
            }
            this.txtKeywords.Text = this.keywords;
            //圖表或列表顯示
            Tea.Web.UI.ShopPage bll_view = new Tea.Web.UI.ShopPage();
            this.rptList1.DataSource = bll_view.GetViewList("view_goods", "", this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList1.DataBind();
            //綁定頁碼
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("dialog_group.aspx", "channel_id={0}&category_id={1}&keywords={2}&page={3}&goods_ids={4}",
                _channel_id.ToString(), _category_id.ToString(), this.keywords, "__id__", this.goods_ids);
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 組合SQL查询語句==========================
        protected string CombSqlTxt(string _keywords, int _category_id)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and title like '%" + _keywords + "%'");
            }
            if (_category_id>0)
            {
                strTemp.Append(" and (category_id=" + _category_id + " or more_type like'%," + _category_id + ",%')");
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
            Response.Redirect(Utils.CombUrlTxt("dialog_group.aspx", "channel_id={0}&category_id={1}&keywords={2}&goods_ids={3}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.goods_ids));
        }

        //篩選類別
        protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("dialog_group.aspx", "channel_id={0}&category_id={1}&keywords={2}&goods_ids={3}",
                this.channel_id.ToString(), ddlCategoryId.SelectedValue, this.keywords, this.goods_ids));
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
            Response.Redirect(Utils.CombUrlTxt("dialog_group.aspx", "channel_id={0}&category_id={1}&keywords={2}&goods_ids={3}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords,  this.goods_ids));
        }
    }
}