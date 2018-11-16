using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.order
{
    public partial class order_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;
        protected Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
        protected Model.orderconfig orderConfig = new BLL.orderconfig().loadConfig();
        protected int status;
        protected int payment_status;
        protected int express_status;
        protected string keywords = string.Empty;
        protected string data, begin, end;
        protected int peisong;
        protected int month = 0;
        protected string _sql = "1=1";
        protected DateTime dt = new DateTime();
        protected void Page_Load(object sender, EventArgs e)
        {

            this.begin = TWRequest.GetQueryString("begin");
            this.end = TWRequest.GetQueryString("end");
            if (!string.IsNullOrEmpty(begin) && !string.IsNullOrEmpty(end))
            {
                dt = System.DateTime.Parse(begin);
                DateTime dt1 = System.DateTime.Parse(begin);

                DateTime dt2 = System.DateTime.Parse(end);

                int Year = dt2.Year - dt1.Year;

                month = (dt2.Year - dt1.Year) * 12 + (dt2.Month - dt1.Month);
            }
            if (!IsPostBack)
            {
                RptBind();
            }
        }

        #region 資料綁定=================================
        private void RptBind()
        {

            this.page = TWRequest.GetQueryInt("page", 1);
            txtbegin.Text = begin;
            txtend.Text = end;
        }
        #endregion


        //關鍵字查詢
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("bao2.aspx", "begin={0}&end={1}", txtbegin.Text, txtend.Text));
        }


        public string getcartnum(string cid)
        {
            string str = "0";
            try
            {
                str = Tea.DBUtility.DbHelperSQL.Query("select count(id) from shop_orders where " + _sql + " and datediff(month,add_time,'" + cid + "')=0").Tables[0].Rows[0][0].ToString();
            }
            catch (Exception eee) { }
            return str;
        }
        public string getcartprice(string cid)
        {
            string str = "0";
            try
            {
                str = Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where  " + _sql + " and datediff(month,add_time,'" + cid + "')=0").Tables[0].Rows[0][0].ToString().Replace(".00", "");
            }
            catch (Exception eee) { }
            return str;
        }
        public string getcartpoint(string cid)
        {
            string str = "0";
            try
            {
                str = Tea.DBUtility.DbHelperSQL.Query("select sum(point+tuid) from shop_orders where " + _sql + " and  datediff(month,add_time,'" + cid + "')=0").Tables[0].Rows[0][0].ToString();
            }
            catch (Exception eee) { }
            return str;
        }
        public string getpin(string cid)
        {
            string str = "0";
            try
            {
                int p = Utils.StrToInt(Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee)from shop_orders where " + _sql + " and  datediff(month,add_time,'" + cid + "')=0").Tables[0].Rows[0][0].ToString(), 0);
                int n = Utils.StrToInt(Tea.DBUtility.DbHelperSQL.Query("select count(id) from shop_orders where " + _sql + " and datediff(month,add_time,'" + cid + "')=0").Tables[0].Rows[0][0].ToString(), 0);
                str = (p / n).ToString("0.");
            }
            catch (Exception eee) { }
            return str;
        }
        //匯出CSV
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("baobiao_2", "Edit");
            string fileName = "訂單" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";
            Tea.Web.UI.ShopPage bll_view = new Tea.Web.UI.ShopPage();

            DataTable dt = new DataTable();// bll_view.GetViewList("view_channel_goods", "", 10000, this.page, "1=1 " + CombSqlTxt(this.status, this.payment_status, this.express_status, this.keywords, data, begin, end, peisong), "id desc", out this.totalCount).Tables[0];

            string[] titleCol = new string[] { "商品編號", "商品名稱", "銷售規格", "銷售數量", "銷售金額" };

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
            int a = 1;
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                for (i = 0; i < titleCol.Length; i++)
                {
                    switch (i)
                    {

                        case 0:
                            sb.Append("<td>" + dr["goods_no"].ToString() + "</td>");
                            break;
                        case 1:
                            sb.Append("<td>" + dr["title"].ToString() + "</td>");
                            break;
                        case 2:
                            sb.Append("<td>" + dr["goods_color"].ToString() + "</td>");
                            break;
                        case 3:
                            sb.Append("<td>" + getcartnum(dr["id"].ToString()) + "</td>");
                            break;
                        case 4:
                            sb.Append("<td>" + getcartprice(dr["id"].ToString()) + "</td>");
                            break;
                    }
                }
                sb.Append("</tr>");
                a = a + 1;
            }
            sb.Append("</tbody></table>");
            Response.Write(sb.ToString());
            Response.End();
        }


    }
}
