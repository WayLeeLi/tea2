using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
using System.Text;
using System.IO;
using System.Data.OleDb;
namespace Tea.Web.admin.order
{
    public partial class order_list : Web.UI.ManagePage
    {
        protected int totalCount, pageCount;
        protected int page;
        protected int pageSize = 300;
        protected string keywords = string.Empty;
        protected string begin, end;
        protected int bnum = 0, nnum = 0;
        protected DataTable dtlist = new DataTable();
        protected DataTable dt_list = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            this.keywords = TWRequest.GetQueryString("keywords");
            this.begin = TWRequest.GetQueryString("begin");
            this.end = TWRequest.GetQueryString("end");

            if (!Page.IsPostBack)
            {
                RptBind();
            }
        }

        #region 資料綁定=================================
        private void RptBind()
        {
            this.page = TWRequest.GetQueryInt("page", 1);

            txtKeywords.Text = this.keywords;
            txtbegin.Text = begin;
            txtend.Text = end;
            string uploadPath = "/users/orders.xls";
            string filePath = Server.MapPath(uploadPath);
            string fileExt = System.IO.Path.GetExtension(filePath);
            string conn = "";
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            if (fileExt == ".xls")
            {
                conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;IMEX=1'";

            }
            OleDbConnection excelCon = new OleDbConnection(conn);
            string sql = "1=1";
            string sqlsql = "1=1";

            if (!string.IsNullOrEmpty(begin))
            {
                string bbegin = System.DateTime.Parse(begin).ToString("yyMMdd");
                bnum = Utils.StrToInt(bbegin + "001", 0);
            }
            if (!string.IsNullOrEmpty(end))
            {
                string eend = System.DateTime.Parse(end).ToString("yyMMdd");
                nnum = Utils.StrToInt(eend + "999", 0);
            }

            if (!string.IsNullOrEmpty(keywords))
            {
                sql = sql + " and (OrderNumber like'%" + keywords + "%' or Accepter like'%" + keywords + "%' or UserID like'%" + keywords + "%' or Buyer like'%" + keywords + "%')";
            }

            //Response.Write("SELECT * FROM [orders$] where " + sql + " order by date desc");
            //Response.End();
            OleDbDataAdapter odda1 = new OleDbDataAdapter("SELECT  * FROM [orders$] where " + sql + " order by date desc", excelCon);


            try
            {
                odda1.Fill(dt);

                dtlist.Columns.Add("Date", typeof(DateTime));//
                dtlist.Columns.Add("OrderNumber", typeof(long));//
                dtlist.Columns.Add("PayType", typeof(string));//
                dtlist.Columns.Add("Status", typeof(string));//
                dtlist.Columns.Add("Pay", typeof(string));//

                dt_list.Columns.Add("Date", typeof(DateTime));//
                dt_list.Columns.Add("OrderNumber", typeof(long));//
                dt_list.Columns.Add("PayType", typeof(string));//
                dt_list.Columns.Add("Status", typeof(string));//
                dt_list.Columns.Add("Pay", typeof(string));//

                DataRow drlist = null;
                foreach (DataRow dr in dt.Rows)
                {
                    drlist = dtlist.NewRow();
                    drlist["Date"] = Utils.StrToDateTime(dr["Date"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    drlist["OrderNumber"] = Utils.StrToDecimal(dr["OrderNumber"].ToString(), 0);
                    drlist["PayType"] = dr["PayType"];
                    drlist["Status"] = dr["Status"];
                    drlist["Pay"] = dr["Pay"];
                    dtlist.Rows.Add(drlist);
                }
                if (bnum > 0)
                {
                    sqlsql = "OrderNumber>=" + bnum + "";
                }
                if (bnum > 0 && nnum > 0)
                {
                    sqlsql = "OrderNumber>=" + bnum + " and OrderNumber<=" + nnum + "";
                }

               // Response.Write(sqlsql);

                DataRow[] D_R = dtlist.Select(sqlsql);
                DataRow dr_list = null;
                foreach (DataRow dr in D_R)
                {
                    dr_list = dt_list.NewRow();
                    dr_list["Date"] = Utils.StrToDateTime(dr["Date"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    dr_list["OrderNumber"] = Utils.StrToDecimal(dr["OrderNumber"].ToString(), 0);
                    dr_list["PayType"] = dr["PayType"];
                    dr_list["Status"] = dr["Status"];
                    dr_list["Pay"] = dr["Pay"];
                    dt_list.Rows.Add(dr_list);
                }

                DataView dv = dt_list.DefaultView;
                dv.Sort = "date desc";

                totalCount = dv.Count;//總條數
                if (totalCount > 0)
                {

                    pageCount = (totalCount % pageSize == 0) ? (totalCount / pageSize) : (totalCount / pageSize + 1);//總頁數

                    int currPage = this.page; //當前頁數

                    if (currPage < 1)
                    { currPage = 1; }

                    if (currPage > pageCount)
                    { currPage = pageCount; }



                    //從查詢出的所有記錄中篩選出即將呈現的當前頁的數據集合
                    int loopCount = (currPage == pageCount) ? totalCount - (currPage - 1) * pageSize : pageSize; //顯示的記錄條數
                    DataRowView[] drwsToBind = new DataRowView[loopCount];
                    for (int i = 0; i < loopCount; i++)
                    { drwsToBind[i] = dv[(currPage - 1) * pageSize + i]; }


                    rptList.DataSource = drwsToBind;
                    rptList.DataBind();

                }
            }
            catch (Exception ex)
            { }
            finally
            {
                excelCon.Close();
                excelCon.Dispose();
            }


            //綁定頁碼

            string pageUrl = Utils.CombUrlTxt("order_list.aspx", "keywords={0}&page={1}&begin={2}&end={3}", this.keywords, "__id__", begin, end);
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion



        #region 返回用戶每頁數量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("order_list_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("order_list.aspx", "keywords={0}&begin={1}&end={2}", txtKeywords.Text, txtbegin.Text, txtend.Text));
        }


    }

}

