using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.about
{
    public partial class article_list : Web.UI.ManagePage
    {
        protected int channel_id;
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int category_id;
        protected string channel_name = string.Empty;
        protected string property = string.Empty;
        protected string keywords = string.Empty;
        protected string prolistview = string.Empty;
        protected string status = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = TWRequest.GetQueryInt("channel_id",1);
            this.category_id = TWRequest.GetQueryInt("category_id");
            this.keywords = TWRequest.GetQueryString("keywords");
            this.property = TWRequest.GetQueryString("property");
            this.status = TWRequest.GetQueryString("status");

            if (channel_id == 0)
            {
                JscriptMsg("頻道參數不正確！", "back");
                return;
            }
            statusSelect.Visible = true;

            this.channel_name = new BLL.channel().GetChannelName(this.channel_id); //取得頻道名稱
            this.pageSize = GetPageSize(50); //每頁數量
            this.prolistview = Utils.GetCookie("vip_list_view"); //顯示方式
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.View.ToString()); //檢查權限
                TreeBind(this.channel_id); //綁定類別
                RptBind(this.channel_id, this.category_id, "id>0" + CombSqlTxt(this.keywords, this.property, this.status), "sort_id,add_time desc,id desc");
            }
        }

        #region 綁定類別=================================
        private void TreeBind(int _channel_id)
        {
            ddlCategoryId.DataSource = new Tea.BLL.basic().GetList(0, "basic_where='help'", "basic_sort");
            ddlCategoryId.DataTextField = "basic_label";
            ddlCategoryId.DataValueField = "basic_value";
            ddlCategoryId.DataBind();
            ddlCategoryId.Items.Insert(0, new ListItem("所有類別", ""));
        }
        #endregion

        #region 資料綁定=================================
        private void RptBind(int _channel_id, int _category_id, string _strWhere, string _orderby)
        {
            this.page = TWRequest.GetQueryInt("page", 1);
            if (this.category_id > 0)
            {
                this.ddlCategoryId.SelectedValue = _category_id.ToString();
            }
            this.ddlProperty.SelectedValue = this.property;
            this.ddlStatus.SelectedValue = this.status.ToString();
            this.txtKeywords.Text = this.keywords;
            //圖表或列表顯示
            BLL.about bll = new BLL.about();
         
            this.rptList1.DataSource = bll.GetList(_channel_id, _category_id, this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList1.DataBind();

            //綁定頁碼
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&page={4}",
                _channel_id.ToString(), _category_id.ToString(), this.keywords, this.property, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 組合SQL查詢語句==========================
        protected string CombSqlTxt(string _keywords, string _property, string _status)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and title like '%" + _keywords + "%'");
            }

            if (!string.IsNullOrEmpty(_property))
            {
                switch (_property)
                {
                    case "isLock":
                        strTemp.Append(" and is_lock=1");
                        break;
                    case "unIsLock":
                        strTemp.Append(" and is_lock=0");
                        break;
                    case "isMsg":
                        strTemp.Append(" and is_msg=1");
                        break;
                    case "isTop":
                        strTemp.Append(" and is_tui=1");
                        break;
                    case "isRed":
                        strTemp.Append(" and is_can=1");
                        break;
                    case "isHot":
                        strTemp.Append(" and is_zhe=1");
                        break;
                    case "isSlide":
                        strTemp.Append(" and is_slide=1");
                        break;
                }
            }
            if (_status != "")
            {
                strTemp.Append(" and status=" + (Utils.StrToInt(_status, 0) - 1).ToString());
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回圖文每頁數量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("help_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //設定操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.Edit.ToString()); //檢查權限
            int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value);
            BLL.about bll = new BLL.about();
            Model.about model = bll.GetModel(id);
            switch (e.CommandName)
            {
                case "lbtnIsMsg":
                    if (model.is_msg == 1)
                        bll.UpdateField(id, "is_msg=0");
                    else
                        bll.UpdateField(id, "is_msg=1");
                    break;
                case "lbtnIsSlide":
                    if (model.is_slide == 1)
                        bll.UpdateField(id, "is_slide=0");
                    else
                        bll.UpdateField(id, "is_slide=1");
                    break;
            }
            this.RptBind(this.channel_id, this.category_id, "id>0" + CombSqlTxt(this.keywords, this.property, this.status), "sort_id desc,add_time desc,id desc");
        }

        //關鍵字查詢
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&status={4}",
                this.channel_id.ToString(), this.category_id.ToString(), txtKeywords.Text, this.property, this.status));
        }

        //篩選類別
        protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&status={4}",
                this.channel_id.ToString(), ddlCategoryId.SelectedValue, this.keywords, this.property, this.status));
        }

        //篩選屬性
        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&status={4}",
               this.channel_id.ToString(), this.category_id.ToString(), this.keywords, ddlProperty.SelectedValue, this.status));
        }

        //篩選狀態
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&status={4}",
               this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, ddlStatus.SelectedValue));
        }

        //設定文字列表顯示
        protected void lbtnViewTxt_Click(object sender, EventArgs e)
        {
            Utils.WriteCookie("vip_list_view", "Txt", 14400);
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&page={4}&status={5}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.page.ToString(), this.status));
        }

        //設定圖文列表顯示
        protected void lbtnViewImg_Click(object sender, EventArgs e)
        {
            Utils.WriteCookie("vip_list_view", "Img", 14400);
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&page={4}&status={5}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.page.ToString(), this.status));
        }

        //設定分頁數量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("help_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&status={4}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.status));
        }

        //儲存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.Edit.ToString()); //檢查權限
            BLL.about bll = new BLL.about();
            Repeater rptList = new Repeater();

            rptList = this.rptList1;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sort_id=" + sortId.ToString());
            }
            AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "儲存" + this.channel_name + "頻道內容排序"); //記錄日誌
            JscriptMsg("儲存排序成功！", Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&status={4}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.status));
        }

        //批次刪除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("site_help", "Edit");
            //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.Delete.ToString()); //檢查權限
            int sucCount = 0; //成功數量
            int errorCount = 0; //失敗數量
            BLL.about bll = new BLL.about();
            Repeater rptList = new Repeater();

            rptList = this.rptList1;

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
            JscriptMsg("刪除成功" + sucCount + "條，失敗" + errorCount + "條！", Utils.CombUrlTxt("list.aspx", "channel_id={0}&category_id={1}&keywords={2}&property={3}&status={4}",
                this.channel_id.ToString(), this.category_id.ToString(), this.keywords, this.property, this.status));
        }

    }
}