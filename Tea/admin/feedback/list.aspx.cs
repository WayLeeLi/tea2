using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.shop_feedback
{
    public partial class list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected string keywords = string.Empty;
        protected int Status;
        protected string data, begin, end;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = TWRequest.GetQueryString("keywords");
            Status = TWRequest.GetQueryInt("Status",-1);
            this.data = TWRequest.GetQueryString("data");
            this.begin = TWRequest.GetQueryString("begin");
            this.end = TWRequest.GetQueryString("end");
            this.pageSize = GetPageSize(50); //每頁數量
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("plugin_feedback", TWEnums.ActionEnum.View.ToString()); //檢查權限
                RptBind("id>0" + CombSqlTxt(this.keywords, Status, data, begin, end), "add_time desc");
            }
        }

        #region 資料綁定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            if (!int.TryParse(Request.QueryString["page"] as string, out this.page))
            {
                this.page = 1;
            }
            this.txtKeywords.Text = this.keywords;
            if (Status >-1)
            {
                this.ddlPaymentStatus.SelectedValue = Status.ToString();
            }
            txtdate.SelectedValue = data;
            txtbegin.Text = begin;
            txtend.Text = end;

            //Response.Write(_strWhere);

            BLL.feedback bll = new BLL.feedback();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();
            //綁定頁碼
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list.aspx", "keywords={0}&page={1}&Status={2}&data={3}&begin={4}&end={5}", this.keywords, "__id__", Status.ToString(), data, begin, end);
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 組合SQL查詢語句==========================
        protected string CombSqlTxt(string _keywords, int _Status, string _date, string _begin, string _end)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (title like '%" + _keywords + "%' or user_name like '%" + _keywords + "%')");
            }
            if (_Status > -1)
            {
                strTemp.Append(" and is_lock=" + _Status);
            }
            if (!string.IsNullOrEmpty(_begin) && !string.IsNullOrEmpty(_end))
            {
                string eend = System.DateTime.Parse(_end).AddDays(1).ToString("yyyy-MM-dd");
                if (data == "1")
                {
                    strTemp.Append(" and (add_time between '" + _begin + "' and '" + eend + "')");
                }
                if (data == "2")
                {
                    strTemp.Append(" and (reply_time between '" + _begin + "' and '" + eend + "')");
                }
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回每頁數量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("feedback_page_size"), out _pagesize))
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
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "keywords={0}&Status={1}&data={2}&begin={3}&end={4}", txtKeywords.Text, Status.ToString(), txtdate.SelectedValue, txtbegin.Text, txtend.Text));
        }

        //設定分頁數量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("feedback_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "keywords={0}", this.keywords));
        }

        //批次審核
        protected void lbtnUnLock_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("plugin_feedback", TWEnums.ActionEnum.Audit.ToString()); //檢查權限
            BLL.feedback bll = new BLL.feedback();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.UpdateField(id, "site_path='no'");
                }
            }
            AddAdminLog(TWEnums.ActionEnum.Audit.ToString(), "審核留言內容"); //記錄日誌
            JscriptMsg("批次審核成功！", Utils.CombUrlTxt("list.aspx", "keywords={0}", this.keywords));
        }

        //批次刪除
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("site_contact", "Edit");
            //ChkAdminLevel("plugin_feedback", TWEnums.ActionEnum.Delete.ToString()); //檢查權限
            int sucCount = 0;
            int errorCount = 0;
            BLL.feedback bll = new BLL.feedback();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
        
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                   
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(TWEnums.ActionEnum.Delete.ToString(), "刪除留言成功" + sucCount + "條，失敗" + errorCount + "條"); //記錄日誌
            JscriptMsg("刪除成功" + sucCount + "條，失敗" + errorCount + "條！", Utils.CombUrlTxt("list.aspx", "keywords={0}", this.keywords));
        }
        //付款狀態
        protected void ddlPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "keywords={0}&Status={1}", this.keywords, this.ddlPaymentStatus.SelectedValue));
        }

        public string get_lock(string lid)
        {
            string str = "";
            if (lid == "0")
            {
                str = "處理中";
            }
            if (lid == "1")
            {
                str = "未回覆";
            }
            if (lid == "2")
            {
                str = "已回覆";
            }
            return str;
        }
        public string getqi(string date, string reply_time)
        {
            string str = "";
            try
            {
                int qx = Utils.StrToInt(siteConfig.webcountcode.Split('|')[0].ToString(), 0);
                str = DateTime.Parse(date).AddHours(qx).ToString("yyyy-MM-dd HH:mm:ss");
                str = str + "/";
                if (!string.IsNullOrEmpty(reply_time))
                {
                    str = str + (Tea.Common.Utils.DateDiff(DateTime.Parse(date), DateTime.Parse(reply_time), "h") / qx).ToString();
                }
                else
                {
                    str = str + (Tea.Common.Utils.DateDiff(DateTime.Parse(date),System.DateTime.Now, "h") / qx).ToString();
                }

            }
            catch (Exception eee) { }
            return str;
        }
    }
}
