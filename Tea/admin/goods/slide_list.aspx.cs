﻿using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.goods
{
    public partial class slide_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = TWRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每頁數量
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("goods_slide", TWEnums.ActionEnum.View.ToString()); //檢查權限
                RptBind("id>0" + CombSqlTxt(keywords), "sort_id desc,id desc");
            }
        }

        #region 資料綁定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = TWRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.slide bll = new BLL.slide();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //綁定頁碼
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("slide_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 組合SQL查詢語句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (title like  '%" + _keywords + "%')");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每頁數量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("slide_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("slide_list.aspx", "keywords={0}", txtKeywords.Text));
        }

        //設定分頁數量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("slide_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("slide_list.aspx", "keywords={0}", this.keywords));
        }

        //儲存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("order_slide", TWEnums.ActionEnum.Edit.ToString()); //檢查權限
            BLL.slide bll = new BLL.slide();
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
            AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "儲存Banner排序"); //記錄日誌
            JscriptMsg("儲存排序成功！", Utils.CombUrlTxt("slide_list.aspx", "keywords={0}", this.keywords));
        }

        //批次刪除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("settings_banner", "Edit");
            //ChkAdminLevel("delete_slide", TWEnums.ActionEnum.Delete.ToString()); //檢查權限
            int sucCount = 0;
            int errorCount = 0;
            BLL.slide bll = new BLL.slide();
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
            AddAdminLog(TWEnums.ActionEnum.Delete.ToString(), "刪除Banner成功" + sucCount + "條，失敗" + errorCount + "條"); //記錄日誌
            JscriptMsg("刪除成功" + sucCount + "條，失敗" + errorCount + "條！", Utils.CombUrlTxt("slide_list.aspx", "keywords={0}", this.keywords));
        }
    }
}