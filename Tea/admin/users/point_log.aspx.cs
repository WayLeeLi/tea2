using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.users
{
    public partial class point_log : Web.UI.ManagePage
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

            this.pageSize = GetPageSize(10); //每頁數量
            Status = TWRequest.GetQueryInt("Status", -1);
            this.data = TWRequest.GetQueryString("data");
            this.begin = TWRequest.GetQueryString("begin");
            this.end = TWRequest.GetQueryString("end");
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("user_point_log", TWEnums.ActionEnum.View.ToString()); //檢查許可權


                RptBind("id>0" + CombSqlTxt(keywords, Status, data, begin, end), "add_time desc,id desc");
            }
        }

        #region 資料綁定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = TWRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            if (Status > -1)
            {
                this.ddlPaymentStatus.SelectedValue = Status.ToString();
            }
            txtdate.SelectedValue = data;
            txtbegin.Text = begin;
            txtend.Text = end;

            Tea.Web.UI.ShopPage bll = new UI.ShopPage();

            this.rptList.DataSource = bll.GetViewList("view_order_point", "", this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //綁定頁碼
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("point_log.aspx", "keywords={0}&page={1}&Status={2}&data={3}&begin={4}&end={5}", this.keywords, "__id__", Status.ToString(), data, begin, end);
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
                strTemp.Append(" and (user_name='" + _keywords + "' or remark like '%" + _keywords + "%')");
            }
            if (_Status > -1)
            {
                strTemp.Append(" and islock=" + _Status);
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
                    strTemp.Append(" and (admin_time between '" + _begin + "' and '" + eend + "')");
                }
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回每頁數量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("user_point_log_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("point_log.aspx", "keywords={0}&Status={1}&data={2}&begin={3}&end={4}", txtKeywords.Text, Status.ToString(), txtdate.SelectedValue, txtbegin.Text, txtend.Text));
        }

        //設置分頁數量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("user_point_log_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("point_log.aspx", "keywords={0}", this.keywords));
        }

        //批次刪除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("user_point_log", "Edit");
            //ChkAdminLevel("user_point_log", TWEnums.ActionEnum.Delete.ToString()); //檢查許可權
            int sucCount = 0;
            int errorCount = 0;
            BLL.user_point_log bll = new BLL.user_point_log();
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
            AddAdminLog(TWEnums.ActionEnum.Delete.ToString(), "刪除紅利日誌成功" + sucCount + "條，失敗" + errorCount + "條"); //記錄日誌
            JscriptMsg("刪除成功" + sucCount + "條，失敗" + errorCount + "條！", Utils.CombUrlTxt("point_log.aspx", "keywords={0}", this.keywords));
        }
        protected void ddlPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("point_log.aspx", "keywords={0}&Status={1}", this.keywords, this.ddlPaymentStatus.SelectedValue));
        }

        public string getlock(string lid)
        {
            string str = "";
            if (lid == "0")
            {
                str = "等待中";
            }
            if (lid == "1")
            {
                str = "可用";
            }
            if (lid == "4")
            {
                str = "已使用";
            }
            if (lid == "2")
            {
                str = "已取消";
            }
            if (lid == "3")
            {
                str = "已提現";
            }
            return str;
        }

        public string getcode(string id)
        {
            string str = "";
            try
            {
                str = new Tea.BLL.orders().GetModel(int.Parse(id)).order_no;
            }
            catch (Exception eee) { }
            return str;
        }
        public string getshow(string l)
        {
            string str = "";
            try
            {
                if (l == "3" || l == "4")
                {
                    str = "-";
                }
                else
                {
                    str = "+";
                }
            }
            catch (Exception exx) { }
            return str;
        }
    }
}
