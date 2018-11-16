using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.product
{
    public partial class list : Web.UI.ManagePage
    {
        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int category_id;
        protected int brand_id;
        protected string channel_name = string.Empty;
        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected string prolistview = string.Empty;
        protected int sort;
        protected int status;
        protected int cid;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = TWRequest.GetQueryInt("channel_id");
            this.category_id = TWRequest.GetQueryInt("category_id");
            this.brand_id = TWRequest.GetQueryInt("brand_id");
            this.keywords = TWRequest.GetQueryString("keywords");
            this.property = TWRequest.GetQueryString("property");
            this.sort = TWRequest.GetQueryInt("sort");
            this.status = TWRequest.GetQueryInt("status",-1);
            this.cid = TWRequest.GetQueryInt("cid");
            if (channel_id == 0)
            {
                JscriptMsg("頻道參數不正確！", "back");
                return;
            }
            this.channel_name = new BLL.channel().GetChannelName(this.channel_id); //取得頻道名稱
            this.pageSize = GetPageSize(10); //每頁數量
            this.prolistview = Utils.GetCookie("article_list_view"); //顯示方式
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.View.ToString()); //檢查許可權
                TreeBind(this.channel_id);
 
                BrandBind(this.channel_id);
                if (status<0)
                {
                    RptBind(this.channel_id, this.category_id, "wheresql='more'" + CombSqlTxt(this.keywords, this.property, this.brand_id, this.category_id), "sort_id desc,add_time desc,id desc");
                }
                else
                {
                    ddlStatus.SelectedValue = status.ToString();
                    if (status != 2)
                    {
                        RptBind(this.channel_id, this.category_id, "wheresql='more' and status=" + status + "" + CombSqlTxt(this.keywords, this.property, this.brand_id, this.category_id), "sort_id desc,add_time desc,id desc");
                    }
                    else
                    {
                        RptBind(this.channel_id, this.category_id, "wheresql='more' and status=0 and (datediff(day,xia_date,getdate())<=0 or xia_date is null) and datediff(minute,add_time,getdate())>=0" + CombSqlTxt(this.keywords, this.property, this.brand_id, this.category_id), "sort_id desc,add_time desc,id desc");
                    }
                }
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
        private void TreeBind1(int _channel_id)
        {
            BLL.article_category bll = new BLL.article_category();
            DataTable dt = bll.GetList(0, _channel_id);

            this.ddlProperty.Items.Clear();
            this.ddlProperty.Items.Add(new ListItem("所有特色標籤", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlProperty.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlProperty.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 綁定類別=================================
        private void BrandBind(int _channel_id)
        {
            BLL.article_tags bll = new BLL.article_tags();
            DataTable dt = bll.GetList("1=1").Tables[0];

            this.ddlBrandId.Items.Clear();
            this.ddlBrandId.Items.Add(new ListItem("所有標籤", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                string Title = dr["title"].ToString().Trim();
                this.ddlBrandId.Items.Add(new ListItem(Title, Id));
            }
        }
        #endregion

        #region 數據綁定=================================
        private void RptBind(int _channel_id, int _category_id, string _strWhere, string _orderby)
        {
            this.page = TWRequest.GetQueryInt("page", 1);
            if (this.category_id > 0)
            {
                this.ddlCategoryId.SelectedValue = _category_id.ToString();
            }
            this.ddlProperty.SelectedValue = this.property;
            this.txtKeywords.Text = this.keywords;
            if (this.brand_id > 0)
            {
                this.ddlBrandId.SelectedValue = this.brand_id.ToString();
            }
            if (sort > 0)
            {
                this.ddlSort.SelectedValue = this.sort.ToString();
                
                if (sort == 1)
                {
                    _orderby = "begin_time";
                }
                if (sort == 2)
                {
                    _orderby = "add_time";
                }
                if (sort == 3)
                {
                    _orderby = "id";
                }
            }
            //圖表或清單顯示
         
             Tea.Web.UI.ShopPage bll = new UI.ShopPage();
     
            switch (this.prolistview)
            {
                case "Txt":
                    this.rptList2.Visible = false;
                    this.rptList1.DataSource = bll.GetViewList("view_article_product", "", this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
                    this.rptList1.DataBind();
                    break;
                default:
                    this.rptList1.Visible = false;
                    this.rptList2.DataSource = bll.GetViewList("view_article_product", "", this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
                    this.rptList2.DataBind();
                    break;
            }
            //綁定頁碼
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("more_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&brand_id={4}&page={5}&status={6}", _channel_id.ToString(), _category_id.ToString(), this.keywords, this.property, this.brand_id.ToString(), "__id__", status.ToString());
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 組合SQL查詢語句==========================
        protected string CombSqlTxt(string _keywords, string _property, int _brandid, int _cid)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (title like '%" + _keywords + "%' or sub_title like'%" + _keywords + "%' or goods_no like'%" + _keywords + "%')");
            }
            if (!string.IsNullOrEmpty(_property))
            {
                strTemp.Append(" and tags like'%," + _property + ",%' ");
              
            }
            if (_brandid != 0)
            {
                strTemp.Append(" and id in(select article_id from shop_article_tags_relation where tag_id=" + _brandid + ")");

            }
            if (_cid != 0)
            {
                strTemp.Append(" and (category_id=" + _cid + "  or more_type like'%," + _cid + ",%')");
            }
            if (cid != 0)
            {
                strTemp.Append(" and brand_id=" + cid + "");
            } 
            return strTemp.ToString();
        }
        #endregion

        #region 返回圖文每頁數量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("article_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //設置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.Edit.ToString()); //檢查許可權
            int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value);
            BLL.article bll = new BLL.article();
            Model.article model = bll.GetModel(id);
            switch (e.CommandName)
            {
                case "lbtnIsMsg":
                    if (model.is_msg == 1)
                        bll.UpdateField(id, "is_msg=0");
                    else
                        bll.UpdateField(id, "is_msg=1");
                    break;
                case "lbtnIsTop":
                    if (model.is_tui == 1)
                        bll.UpdateField(id, "is_tui=0");
                    else
                        bll.UpdateField(id, "is_tui=1");
                    break;
                case "lbtnIsRed":
                    if (model.is_can == 1)
                        bll.UpdateField(id, "is_can=0");
                    else
                        bll.UpdateField(id, "is_can=1");
                    break;
                case "lbtnIsHot":
                    if (model.is_zhe == 1)
                        bll.UpdateField(id, "is_zhe=0");
                    else
                        bll.UpdateField(id, "is_zhe=1");
                    break;
                case "lbtnIsSlide":
                    if (model.is_slide == 1)
                        bll.UpdateField(id, "is_slide=0");
                    else
                        bll.UpdateField(id, "is_slide=1");
                    break;
                case "lbtnCopy":
                    string tempTitle = model.title;
                    model.title = tempTitle + "（複製）";
                    bll.Add(model);
                    break;
            }
            this.RptBind(this.channel_id, this.category_id, "wheresql='tuan' and company=0" + CombSqlTxt(this.keywords, this.property, this.brand_id,this.category_id), "sort_id desc,add_time desc,id desc");
        }

        //關健字查詢
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("more_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&brand_id={4}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property, this.brand_id.ToString()));
        }

        //篩選類別
        protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("more_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&brand_id={4}",
                this.channel_id.ToString(), ddlCategoryId.SelectedValue, this.keywords, this.property, this.brand_id.ToString()));
        }
        //篩選品牌
        protected void ddlBrandId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("more_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&brand_id={4}",
                this.channel_id.ToString(), ddlCategoryId.SelectedValue, this.keywords, this.property, ddlBrandId.SelectedValue));
        }
        //篩選屬性
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("more_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&brand_id={4}",
               this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue, this.brand_id.ToString()));
        }
        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("more_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&brand_id={4}&sort={5}",
               this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.brand_id.ToString(), ddlSort.SelectedValue));
        }
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("more_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&brand_id={4}&status={5}",
               this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.brand_id.ToString(), ddlStatus.SelectedValue));
        }
        //設置文字清單顯示
        protected void lbtnViewTxt_Click(object sender, EventArgs e)
        {
            Utils.WriteCookie("article_list_view", "Txt", 14400);
            Response.Redirect(Utils.CombUrlTxt("more_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&page={4}&brand_id={5}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.page.ToString(), this.brand_id.ToString()));
        }

        //設置圖文清單顯示
        protected void lbtnViewImg_Click(object sender, EventArgs e)
        {
            Utils.WriteCookie("article_list_view", "Img", 14400);
            Response.Redirect(Utils.CombUrlTxt("more_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&page={4}&brand_id={5}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.page.ToString(), this.brand_id.ToString()));
        }

        //設置分頁數量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("article_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("more_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&brand_id={4}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.brand_id.ToString()));
        }

        //儲存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.Edit.ToString()); //檢查許可權
            BLL.article bll = new BLL.article();
            Repeater rptList = new Repeater();
            switch (this.prolistview)
            {
                case "Txt":
                    rptList = this.rptList1;
                    break;
                default:
                    rptList = this.rptList2;
                    break;
            }
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("txt_lock");
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sort_id=" + sortId.ToString());
                //if (cb.Checked)
                //{
                //    bll.UpdateField(id, "is_slide=1");
                //}
                //else
                //{
                //    bll.UpdateField(id, "is_slide=0");
                //}
            }
            AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "儲存" + this.channel_name + "頻道內容排序"); //記錄日誌
            JscriptMsg("儲存成功！", Utils.CombUrlTxt("more_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&brand_id={4}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.brand_id.ToString()));
        }
        public string get_tags(string tags)
        {
            string str = "";
            try
            {
       
                try
                {
                    DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select  * from shop_article_category where channel_id=77 and id in(0" + tags + "0) order by sort_id desc,id desc");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        str = str+ dr["title"].ToString();
                    }
                }
                catch (Exception eee) { }
            }
            catch (Exception eee) { }
            return str;
        }
        //批次審核
        protected void btnAudit_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.Audit.ToString()); //檢查許可權
            BLL.article bll = new BLL.article();
            Repeater rptList = new Repeater();
            switch (this.prolistview)
            {
                case "Txt":
                    rptList = this.rptList1;
                    break;
                default:
                    rptList = this.rptList2;
                    break;
            }
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.UpdateField(id, "status=0");
                }
            }
            AddAdminLog(TWEnums.ActionEnum.Audit.ToString(), "審核" + this.channel_name + "頻道內容資訊"); //記錄日誌
            JscriptMsg("批次審核成功！", Utils.CombUrlTxt("more_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&brand_id={4}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.brand_id.ToString()));
        }

        //批次刪除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("te_more", "Edit");
            //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.Delete.ToString()); //檢查許可權
            int sucCount = 0; //成功數量
            int errorCount = 0; //失敗數量
            BLL.article bll = new BLL.article();
            Repeater rptList = new Repeater();
            switch (this.prolistview)
            {
                case "Txt":
                    rptList = this.rptList1;
                    break;
                default:
                    rptList = this.rptList2;
                    break;
            }
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount++;
                    }
                    else
                    {
                        errorCount++;
                    }
                }
            }
            AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "刪除" + this.channel_name + "頻道內容成功" + sucCount + "條，失敗" + errorCount + "條"); //記錄日誌
            JscriptMsg("刪除成功" + sucCount + "條，失敗" + errorCount + "條！", Utils.CombUrlTxt("more_list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&brand_id={4}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.brand_id.ToString()));
        }

        //導出excel
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string filename = "商品清單" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";
            BLL.article bll = new BLL.article();
            DataTable dt = bll.GetList(this.channel_id, this.category_id, 500, 1, "wheresql='tuan' and company=0" + CombSqlTxt(this.keywords, this.property, this.brand_id,this.category_id), "sort_id desc,add_time desc,id desc", out this.totalCount).Tables[0];
            CreateExcel(dt, filename);
        }

        protected void CreateExcel(DataTable dt, string fileName)
        {
            string[] titleCol = new string[] { "類型", "商品型號", "商品名稱", "品牌", "顔色", "尺寸", "市價", "售價", "備貨數量", "已售數量", "數量", "商品描述", "注意事項", "關鍵字", "上架日期", "分類", "前台排序" };
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "UTF-8";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            Response.Write("<metahttp-equiv=Content-Type content=application/ms-excel;charset=UTF-8>");
            Response.ContentType = "application/ms-excel;charset=UTF-8";

            ////定義表物件與行物件，同時用DataSet對其值進行初始化
            //DataTable dt = ds.Tables[0];
            DataRow[] myRow = dt.Select();//可以類似dt.Select("id>10")之形式達到資料篩選目的
            int i = 0;
            int j = 0;

            StringBuilder sb = new StringBuilder();
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            //取得資料表各列標題，各標題之間以t分割，最後一個列標題後加回車符
            for (i = 0; i < titleCol.Length; i++)
            {
                sb.Append("<th>" + titleCol[i].ToString() + "</th>");
            }
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");
            //向HTTP輸出流中寫入取得的資料資訊
            //逐行處理資料 
            DataTable goodsDt = new DataTable();
            BLL.goods goodsBll = new BLL.goods();
            BLL.article_category categoryBll = new BLL.article_category();
            foreach (DataRow row in myRow)
            {
                //當前行資料寫入HTTP輸出流，並且置空ls_item以便下行資料
                Model.article model = new BLL.article().GetModel(Utils.ObjToInt(row["id"], 0));
                sb.Append("<tr>");
                for (i = 0; i < titleCol.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            sb.Append("<td>主件</td>");
                            break;
                        case 1:
                            sb.Append("<td>" + model.guige.ToString() + "</td>");
                            break;
                        case 2:
                            sb.Append("<td>" + row["title"].ToString() + "</td>");
                            break;
                        case 3:
                            sb.Append("<td>" + model.guige + "</td>");
                            break;
                        case 4:
                            sb.Append("<td>" + model.guige + "</td>");
                            break;
                        case 5:
                            sb.Append("<td>" + model.guige + "</td>");
                            break;
                        case 6:
                            sb.Append("<td>" + model.id + "</td>");
                            break;
                        case 7:
                            sb.Append("<td>" + model.id + "</td>");
                            break;
                        case 8:
                            sb.Append("<td> </td>");
                            break;
                        case 9:
                            sb.Append("<td> </td>");
                            break;
                        case 10:
                            sb.Append("<td>" + model.id.ToString() + "</td>");
                            break;
                        case 11:
                            sb.Append("<td>" + Tea.Common.Utils.ToTxt(model.guige) + "</td>");
                            break;
                        case 12:
                            sb.Append("<td>" + Tea.Common.Utils.ToTxt(model.guige) + "</td>");
                            break;
                        case 13:
                            sb.Append("<td>" + row["seo_keywords"].ToString() + "</td>");
                            break;
                        case 14:
                            sb.Append("<td>" + row["add_time"].ToString() + "</td>");
                            break;
                        case 15:
                            sb.Append("<td>" + categoryBll.GetTitle(Utils.ObjToInt(row["category_id"], 0)) + "</td>");
                            break;
                        case 16:
                            sb.Append("<td>" + row["sort_id"].ToString() + "</td>");
                            break;
                    }
                }
                sb.Append("</tr>");
                goodsDt = goodsBll.GetList("parent_id=" + Utils.ObjToInt(row["id"], 0)).Tables[0];
                foreach (DataRow row1 in goodsDt.Rows)
                {
                    sb.Append("<tr>");
                    for (j = 0; j < titleCol.Length; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                sb.Append("<td>子件</td>");
                                break;
                            case 1:
                                sb.Append("<td>" + row1["goods_no"].ToString() + "</td>");
                                break;
                            case 2:
                                sb.Append("<td>" + row["title"].ToString() + "</td>");
                                break;
                            case 3:
                                sb.Append("<td>" + row["title"].ToString() + "</td>");
                                break;
                            case 4:
                                sb.Append("<td>" + row1["color"].ToString() + "</td>");
                                break;
                            case 5:
                                sb.Append("<td>" + row1["size"].ToString() + "</td>");
                                break;
                            case 6:
                                sb.Append("<td>" + row1["market_price"].ToString() + "</td>");
                                break;
                            case 7:
                                sb.Append("<td>" + row1["sell_price"].ToString() + "</td>");
                                break;
                            case 8:
                                sb.Append("<td>" + getku(row1["id"].ToString()) + "</td>");
                                break;
                            case 9:
                                sb.Append("<td>" + getcode(row1["id"].ToString()) + "</td>");
                                break;
                            case 10:
                                sb.Append("<td>" + row1["stock_quantity"].ToString() + "</td>");
                                break;
                        }
                    }
                    sb.Append("</tr>");
                }
            }
            sb.Append("</tbody></table>");
            Response.Write(sb.ToString());
            Response.End();
        }

        public string getku(string id)
        {
            string str = "0";
            try
            {
                str = Tea.DBUtility.DbHelperSQL.Query("select  sum(stock_quantity) from shop_goods where parent_id=" + id + "").Tables[0].Rows[0][0].ToString();

            }
            catch (Exception eee) { }
            if (string.IsNullOrEmpty(str))
            {
                str = "0";
            }
            return str;
        }
        public string getcode(string id)
        {
            string str = "";
            try
            {
                str = Tea.DBUtility.DbHelperSQL.Query("select top 1 goods_no from shop_goods where parent_id=" + id + "").Tables[0].Rows[0][0].ToString();
            }
            catch (Exception eee) { }

            return str;
        }
        public string getstatus(string id)
        {
            string str = "";
            if (id == "0")
            {
                str = "販售中";
            }
            if (id == "1")
            {
                str = "待審核";
            }
            if (id == "2")
            {
                str = "暫停販售";
            }
            return str;
        }

        public string getprice(string id)
        {
            string str = "";
            DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select more_chu from shop_goods_more_price where article_id=" + id + " order by more_chu");
            if (ds.Tables[0].Rows.Count > 0)
            {
                str = Utils.StrToDecimal(ds.Tables[0].Rows[0][0].ToString(), 0).ToString("0.");
            }
            return str;
        }
        public string gettese(string tags)
        {
            string str = "";
            try
            {
                DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select  * from shop_article_category where channel_id=77 and id in(0" + tags + "0) order by sort_id desc,id desc");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    str = str + dr["title"].ToString() + ",";
                }
            }
            catch (Exception eee) { }
            return str;
        }
    }
}
