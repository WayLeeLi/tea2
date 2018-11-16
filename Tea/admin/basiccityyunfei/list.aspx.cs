using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.basic
{
    public partial class list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = TWRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(50); //每頁數量
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("plugin_link", TWEnums.ActionEnum.View.ToString()); //檢查權限
                RptBind("basic_where='yunfei'" + CombSqlTxt(this.keywords), "basic_type,basic_id asc");
            }
        }

        #region 資料綁定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = TWRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            BLL.basic bll = new BLL.basic();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();
            //綁定頁碼
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
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
                strTemp.Append(" and basic_label like '%" + _keywords + "%'");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回圖文每頁數量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("link_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "keywords={0}", txtKeywords.Text));
        }

        //設定分頁數量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
          
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("link_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("list.aspx", "keywords={0}", this.keywords));
        }

        //儲存運費設定
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("plugin_link", TWEnums.ActionEnum.Edit.ToString()); //檢查權限
            BLL.basic bll = new BLL.basic();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                Model.basic model = bll.GetModel(id);
                model.basic_sort = sortId;
                model.basic_money = Utils.StrToInt(((TextBox)rptList.Items[i].FindControl("txtYunFei")).Text.Trim(),0);
                bll.Update(model);
            }
            AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "修改運費設定運費設定:"); //記錄日誌
            JscriptMsg("儲存運費設定成功！", Utils.CombUrlTxt("list.aspx", "keywords={0}", this.keywords));
        }

        //批次審核
        protected void lbtnUnLock_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("plugin_link", TWEnums.ActionEnum.Audit.ToString()); //檢查權限
            BLL.basic bll = new BLL.basic();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                   // bll.UpdateField(id, "is_lock=0");
                }
            }
            AddAdminLog(TWEnums.ActionEnum.Audit.ToString(), "審核運費設定"); //記錄日誌
            JscriptMsg("批次審核成功！", Utils.CombUrlTxt("list.aspx", "keywords={0}", this.keywords));
        }

        //批次刪除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("basiccityyunfei", "Edit");
            //ChkAdminLevel("plugin_link", TWEnums.ActionEnum.Delete.ToString()); //檢查權限
            int sucCount = 0;
            int errorCount = 0;
            BLL.basic bll = new BLL.basic();
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
            AddAdminLog(TWEnums.ActionEnum.Delete.ToString(), "刪除運費設定成功" + sucCount + "條，失敗" + errorCount + "條"); //記錄日誌
            JscriptMsg("刪除成功" + sucCount + "條，失敗" + errorCount + "條！", Utils.CombUrlTxt("list.aspx", "keywords={0}", this.keywords));
        }

    }
}
