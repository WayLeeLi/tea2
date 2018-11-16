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
    public partial class user_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected int status;
        protected int group_id;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //ChkAdminLevel("user_list", TWEnums.ActionEnum.View.ToString()); //檢查許可權
            this.group_id = TWRequest.GetQueryInt("group_id");
            this.keywords = TWRequest.GetQueryString("keywords");
            this.status = TWRequest.GetQueryInt("status",-1);

            this.pageSize = GetPageSize(10); //每頁數量
            if (!Page.IsPostBack)
            {
                TreeBind("is_lock=0"); //綁定類別
                if (status > -1)
                {
                    ddlStatus.SelectedValue = status.ToString();

                    RptBind("status="+status+"" + CombSqlTxt(this.group_id, this.keywords), "reg_time desc,id desc");
                }
                else
                {
                    RptBind("id>0" + CombSqlTxt(this.group_id, this.keywords), "reg_time desc,id desc");
                }
            }
        }

        #region 綁定組別=================================
        private void TreeBind(string strWhere)
        {
            BLL.user_groups bll = new BLL.user_groups();
            DataTable dt = bll.GetList(0, strWhere, "id desc").Tables[0];

            this.ddlGroupId.Items.Clear();
            this.ddlGroupId.Items.Add(new ListItem("所有會員組", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlGroupId.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
            }
        }
        #endregion

        #region 資料綁定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = TWRequest.GetQueryInt("page", 1);
            if (this.group_id > 0)
            {
                this.ddlGroupId.SelectedValue = this.group_id.ToString();
            }
            this.txtKeywords.Text = this.keywords;
            BLL.users bll = new BLL.users();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //綁定頁碼
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("user_list.aspx", "group_id={0}&keywords={1}&page={2}",
                this.group_id.ToString(), this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 組合SQL查詢語句==========================
        protected string CombSqlTxt(int _group_id, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_group_id > 0)
            {
                strTemp.Append(" and group_id=" + _group_id);
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (user_name like '%" + _keywords + "%' or mobile like '%" + _keywords + "%' or email like '%" + _keywords + "%' or nick_name like '%" + _keywords + "%')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用戶每頁數量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("user_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        #region 返回使用者狀態=============================
 
        protected string GetUserStatus(int status)
        {
            string result = string.Empty;
            switch (status)
            {
                case 0:
                    result = "正常";
                    break;
                case 1:
                    result = "郵件核驗中";
                    break;
                case 2:
                    result = "關閉";
                    break;
            }
            return result;
        }
        #endregion

        //關鍵字查詢
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("user_list.aspx", "group_id={0}&keywords={1}",
                this.group_id.ToString(), txtKeywords.Text));
        }

        //篩選類別
        protected void ddlGroupId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("user_list.aspx", "group_id={0}&keywords={1}",
                ddlGroupId.SelectedValue, this.keywords));
        }
        //篩選類別
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("user_list.aspx", "status={0}&keywords={1}",
                ddlStatus.SelectedValue, this.keywords));
        }
        //設置分頁數量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("user_list_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("user_list.aspx", "group_id={0}&keywords={1}",
                this.group_id.ToString(), this.keywords));
        }

        //批次刪除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("user_list", "Edit");
            //ChkAdminLevel("user_list", TWEnums.ActionEnum.Delete.ToString()); //檢查許可權
            int sucCount = 0;
            int errorCount = 0;
            BLL.users bll = new BLL.users();
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
            AddAdminLog(TWEnums.ActionEnum.Delete.ToString(), "刪除用戶" + sucCount + "條，失敗" + errorCount + "條"); //記錄日誌
            JscriptMsg("刪除成功" + sucCount + "條，失敗" + errorCount + "條！",
                Utils.CombUrlTxt("user_list.aspx", "group_id={0}&keywords={1}", this.group_id.ToString(), this.keywords));
        }
        //匯出CSV
        protected void btnExport_Click(object sender, EventArgs e)
        {

            string fileName = "用戶資料" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";
            BLL.users bll = new BLL.users();

            string strurl = "0";
            for (int ai = 0; ai < rptList.Items.Count; ai++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[ai].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[ai].FindControl("chkId");
                if (cb.Checked)
                {
                    strurl = strurl + "," + id.ToString(); ;
                }
            }
            DataTable dt = new DataTable();
            //if (strurl.Length > 1)
            //{
            //    dt = bll.GetList(0, "id in(" + strurl + ")" + CombSqlTxt(this.group_id, this.keywords), "reg_time desc,id desc").Tables[0];
            //}
            //else
            //{
                dt = bll.GetList(0, "id>0" + CombSqlTxt(this.group_id, this.keywords), "reg_time desc,id desc").Tables[0];
            //}


            string[] titleCol = new string[] { "姓名","性別","⽣⽇_年","⽣⽇_⽉","⽣⽇_⽇","電話1","電話2","傳真1","傳真2","⼿機1","⼿機2","Email1","Email2","Email3","郵遞區號","住址","即時通訊","群組","啟⽤電⼦報","公司名稱","部⾨職稱","公司電話","公司傳真","公司地址1","公司地址2","統⼀編號","網站","備註"};

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "UTF-8";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            Response.Write("<metahttp-equiv=Content-Type content=application/ms-excel;charset=UTF-8>");
            Response.ContentType = "application/ms-excel;charset=UTF-8";

            ////定义表对象与行对象，同时用DataSet对其值进行初始化
            //DataTable dt = ds.Tables[0];
            DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的
            int i = 0;
            int j = 0;

            StringBuilder sb = new StringBuilder();
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            //取得数据表各列标题，各标题之间以t分割，最后一个列标题后加回车符
            for (i = 0; i < titleCol.Length; i++)
            {
                sb.Append("<th>" + titleCol[i].ToString() + "</th>");
            }
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");
            //向HTTP输出流中写入取得的数据信息
            //逐行处理数据 
            
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                for (i = 0; i < titleCol.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            sb.Append("<td>" + dr["nick_name"].ToString() + "</td>");
                            break;
                        case 1:
                            sb.Append("<td>" + dr["sex"].ToString() + "</td>");
                            break;
                        case 2:
                            sb.Append("<td>" + Utils.StrToDateTime(dr["birthday"].ToString()).Year + "</td>");
                            break;
                        case 3:
                            sb.Append("<td>" + Utils.StrToDateTime(dr["birthday"].ToString()).Month + "</td>");
                            break;
                        case 4:
                            sb.Append("<td>" + Utils.StrToDateTime(dr["birthday"].ToString()).Day + "</td>");
                            break;
                        case 5:
                            sb.Append("<td>" + dr["mobile"].ToString() + "</td>");
                            break;
                        case 6:
                            sb.Append("<td></td>");
                            break;
                        case 7:
                            sb.Append("<td></td>");
                            break;
                        case 8:
                            sb.Append("<td></td>");
                            break;
                        case 9:
                            sb.Append("<td>" + dr["mobile"].ToString() + "</td>");
                            break;
                        case 10:
                            sb.Append("<td></td>");
                            break;
                        case 11:
                            sb.Append("<td>" + dr["email"].ToString() + "</td>");
                            break;
                        case 12:
                            sb.Append("<td></td>");
                            break;
                        case 13:
                            sb.Append("<td></td>");
                            break;
                        case 14:
                            sb.Append("<td>" + dr["qq"].ToString() + "</td>");
                            break;
                        case 15:
                            sb.Append("<td>" + dr["area"].ToString() + "," + dr["address"].ToString() + "</td>");
                            break;
                        case 16:
                            sb.Append("<td></td>");
                            break;
                        case 17:
                            sb.Append("<td></td>");
                            break;
                        case 18:
                            sb.Append("<td>" + getexp(dr["exp"].ToString())+ "</td>");
                            break;
                        case 19:
                            sb.Append("<td></td>");
                            break;
                        case 20:
                            sb.Append("<td></td>");
                            break;
                        case 21:
                            sb.Append("<td></td>");
                            break;
                        case 22:
                            sb.Append("<td></td>");
                            break;
                        case 23:
                            sb.Append("<td></td>");
                            break;
                        case 24:
                            sb.Append("<td></td>");
                            break;
                        case 25:
                            sb.Append("<td></td>");
                            break;
                        case 26:
                            sb.Append("<td></td>");
                            break;
                        case 27:
                            sb.Append("<td></td>");
                            break;
                    }
                }
                sb.Append("</tr>");

            }
            sb.Append("</tbody></table>");
            Response.Write(sb.ToString());
            Response.End();
        }

        protected void btnExport1_Click(object sender, EventArgs e)
        {

            string fileName = "用戶資料" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";
            BLL.users bll = new BLL.users();

            string strurl = "0";
            for (int ai = 0; ai < rptList.Items.Count; ai++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[ai].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[ai].FindControl("chkId");
                if (cb.Checked)
                {
                    strurl = strurl + "," + id.ToString(); ;
                }
            }
            DataTable dt = new DataTable();
            //if (strurl.Length > 1)
            //{
            //    dt = bll.GetList(0, "id in(" + strurl + ")" + CombSqlTxt(this.group_id, this.keywords), "reg_time desc,id desc").Tables[0];
            //}
            //else
            //{
            dt = bll.GetList(0, "id>0 and exp=1" + CombSqlTxt(this.group_id, this.keywords), "reg_time desc,id desc").Tables[0];
            //}


            string[] titleCol = new string[] { "姓名", "性別", "⽣⽇_年", "⽣⽇_⽉", "⽣⽇_⽇", "電話1", "電話2", "傳真1", "傳真2", "⼿機1", "⼿機2", "Email1", "Email2", "Email3", "郵遞區號", "住址", "即時通訊", "群組", "啟⽤電⼦報", "公司名稱", "部⾨職稱", "公司電話", "公司傳真", "公司地址1", "公司地址2", "統⼀編號", "網站", "備註" };

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "UTF-8";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            Response.Write("<metahttp-equiv=Content-Type content=application/ms-excel;charset=UTF-8>");
            Response.ContentType = "application/ms-excel;charset=UTF-8";

            ////定义表对象与行对象，同时用DataSet对其值进行初始化
            //DataTable dt = ds.Tables[0];
            DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的
            int i = 0;
            int j = 0;

            StringBuilder sb = new StringBuilder();
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            //取得数据表各列标题，各标题之间以t分割，最后一个列标题后加回车符
            for (i = 0; i < titleCol.Length; i++)
            {
                sb.Append("<th>" + titleCol[i].ToString() + "</th>");
            }
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");
            //向HTTP输出流中写入取得的数据信息
            //逐行处理数据 

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                for (i = 0; i < titleCol.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            sb.Append("<td>" + dr["nick_name"].ToString() + "</td>");
                            break;
                        case 1:
                            sb.Append("<td>" + dr["sex"].ToString() + "</td>");
                            break;
                        case 2:
                            sb.Append("<td>" + Utils.StrToDateTime(dr["birthday"].ToString()).Year + "</td>");
                            break;
                        case 3:
                            sb.Append("<td>" + Utils.StrToDateTime(dr["birthday"].ToString()).Month + "</td>");
                            break;
                        case 4:
                            sb.Append("<td>" + Utils.StrToDateTime(dr["birthday"].ToString()).Day + "</td>");
                            break;
                        case 5:
                            sb.Append("<td>" + dr["mobile"].ToString() + "</td>");
                            break;
                        case 6:
                            sb.Append("<td></td>");
                            break;
                        case 7:
                            sb.Append("<td></td>");
                            break;
                        case 8:
                            sb.Append("<td></td>");
                            break;
                        case 9:
                            sb.Append("<td>" + dr["mobile"].ToString() + "</td>");
                            break;
                        case 10:
                            sb.Append("<td></td>");
                            break;
                        case 11:
                            sb.Append("<td>" + dr["email"].ToString() + "</td>");
                            break;
                        case 12:
                            sb.Append("<td></td>");
                            break;
                        case 13:
                            sb.Append("<td></td>");
                            break;
                        case 14:
                            sb.Append("<td>" + dr["qq"].ToString() + "</td>");
                            break;
                        case 15:
                            sb.Append("<td>" + dr["area"].ToString() + "," + dr["address"].ToString() + "</td>");
                            break;
                        case 16:
                            sb.Append("<td></td>");
                            break;
                        case 17:
                            sb.Append("<td></td>");
                            break;
                        case 18:
                            sb.Append("<td>" + getexp(dr["exp"].ToString()) + "</td>");
                            break;
                        case 19:
                            sb.Append("<td></td>");
                            break;
                        case 20:
                            sb.Append("<td></td>");
                            break;
                        case 21:
                            sb.Append("<td></td>");
                            break;
                        case 22:
                            sb.Append("<td></td>");
                            break;
                        case 23:
                            sb.Append("<td></td>");
                            break;
                        case 24:
                            sb.Append("<td></td>");
                            break;
                        case 25:
                            sb.Append("<td></td>");
                            break;
                        case 26:
                            sb.Append("<td></td>");
                            break;
                        case 27:
                            sb.Append("<td></td>");
                            break;
                    }
                }
                sb.Append("</tr>");

            }
            sb.Append("</tbody></table>");
            Response.Write(sb.ToString());
            Response.End();
        }

        public string getexp(string exp)
        {
            return exp == "1" ? "是" : "否";
        }
    }
}
