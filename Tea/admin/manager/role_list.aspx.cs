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
    public partial class role_list : Web.UI.ManagePage
    {
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = TWRequest.GetQueryString("keywords");
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("manager_role", TWEnums.ActionEnum.View.ToString()); //檢查許可權
                Model.manager model = GetAdminInfo(); //取得當前管理員資訊
                RptBind("role_type>=" + model.role_type + CombSqlTxt(this.keywords));
            }
        }

        #region 資料綁定=================================
        private void RptBind(string _strWhere)
        {
            this.txtKeywords.Text = this.keywords;
            BLL.manager_role bll = new BLL.manager_role();
            this.rptList.DataSource = bll.GetList(_strWhere);
            this.rptList.DataBind();
        }
        #endregion

        #region 組合SQL查詢語句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and role_name like '%" + _keywords + "%'");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回角色類型名稱=========================
        protected string GetTypeName(int role_type)
        {
            string str = "";
            switch (role_type)
            {
                case 1:
                    str = "超級用戶";
                    break;
                default:
                    str = "系統使用者";
                    break;
            }
            return str;
        }
        #endregion

        //查詢操作
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("role_list.aspx", "keywords={0}", txtKeywords.Text.Trim()));
        }

        //批次刪除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("manager_role", "Edit");
            //ChkAdminLevel("manager_role", TWEnums.ActionEnum.Delete.ToString()); //檢查許可權
            int sucCount = 0; //成功數量
            int errorCount = 0; //失敗數量
            BLL.manager_role bll = new BLL.manager_role();
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
            AddAdminLog(TWEnums.ActionEnum.Delete.ToString(), "刪除管理角色" + sucCount + "條，失敗" + errorCount + "條"); //記錄日誌
            JscriptMsg("刪除成功" + sucCount + "條，失敗" + errorCount + "條！", Utils.CombUrlTxt("role_list.aspx", "keywords={0}", this.keywords));
        }

    }
}
