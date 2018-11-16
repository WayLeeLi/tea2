using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.manager
{
    public partial class manager_log : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;
        Model.manager model = new Model.manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = TWRequest.GetQueryString("keywords");
            this.pageSize = GetPageSize(10); //每頁數量
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("manager_log", TWEnums.ActionEnum.View.ToString()); //檢查許可權
                model = GetAdminInfo(); //取得當前管理員資訊
                RptBind("id>0" + CombSqlTxt(keywords), "add_time desc,id desc");
            }
        }

        #region 組合SQL查詢語句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (user_name like  '%" + _keywords + "%' or action_type like '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 資料綁定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = TWRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.manager_log bll = new BLL.manager_log();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //綁定頁碼
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("manager_log.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 返回每頁數量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("manager_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("manager_log.aspx", "keywords={0}", txtKeywords.Text));
        }

        //設置分頁數量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("manager_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("manager_log.aspx", "keywords={0}", this.keywords));
        }

        //批次刪除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("manager_log", "Edit");
            //ChkAdminLevel("manager_log", TWEnums.ActionEnum.Delete.ToString()); //檢查許可權
            BLL.manager_log bll = new BLL.manager_log();
            int sucCount = bll.Delete(7);
            AddAdminLog(TWEnums.ActionEnum.Delete.ToString(), "刪除管理日誌" + sucCount + "條"); //記錄日誌
            JscriptMsg("刪除日誌" + sucCount + "條", Utils.CombUrlTxt("manager_log.aspx", "keywords={0}", this.keywords));
        }
    }
}
