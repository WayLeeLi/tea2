using System;
using System.Text;
using System.Data;
using System.Collections;
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
        protected string _sql = "1=1";
        protected string tw_zhong = "苗栗縣|台中市|彰化縣|南投縣|嘉義市|嘉義縣|雲林縣";
        protected string tw_bei = "基隆市|台北市|新北市|桃園市|新竹市|新竹縣";
        protected string tw_dong = "宜蘭縣|台東縣|花蓮縣";
        protected string tw_nan = "高雄市|屏東縣|台南市";
        protected string tw_wai = "金門縣|連江縣|澎湖縣|南海諸島";

        protected IList _list_zhong = new ArrayList();
        protected IList _list_bei = new ArrayList();
        protected IList _list_dong = new ArrayList();
        protected IList _list_nan = new ArrayList();
        protected IList _list_wai = new ArrayList();
        protected int allnum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


            _list_zhong = tw_zhong.Split('|');
            _list_bei = tw_bei.Split('|');
            _list_dong = tw_dong.Split('|');
            _list_nan = tw_nan.Split('|');
            _list_wai = tw_wai.Split('|');


            this.begin = TWRequest.GetQueryString("begin");
            this.end = TWRequest.GetQueryString("end");
            if (string.IsNullOrEmpty(begin))
            {
                begin = System.DateTime.Now.Year.ToString();
            }
            if (string.IsNullOrEmpty(end))
            {
                end = System.DateTime.Now.Month.ToString();
            }
            _sql = "datediff(month,add_time,'" + begin + "-" + end + "-1')=0";
            allnum = Utils.StrToInt(Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where " + _sql + "").Tables[0].Rows[0][0].ToString().Replace(".00", ""), 0);

            if (!IsPostBack)
            {
                for (int i = 1; i <= 12; i++)
                {
                    ddlMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                int year = System.DateTime.Now.Year;
                for (int i = 2018; i <= year + 1; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
            if (!IsPostBack)
            {
                RptBind();
            }
            //Response.Write(allnum);
        }

        #region 資料綁定=================================
        private void RptBind()
        {

            this.page = TWRequest.GetQueryInt("page", 1);
            //Response.Write(begin+"-"+end);
            if (!string.IsNullOrEmpty(begin))
            {
                ddlYear.SelectedValue = begin;
            }
            if (!string.IsNullOrEmpty(end))
            {
                ddlMonth.SelectedValue = end;
            }

            this.rptList.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from shop_basic where basic_where='city' and basic_label!='台灣'");
            this.rptList.DataBind();


        }
        #endregion
        //關鍵字查詢
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("bao3.aspx", "begin={0}&end={1}", ddlYear.SelectedValue, ddlMonth.SelectedValue));
        }

        public string getcartpricequ(string cid)
        {
            string str = "0";
           
            string bsql = "(";
            if (cid == "zhong")
            {
                foreach (object ob in _list_zhong)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    str = Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                }
                catch (Exception eee) { }
                   // Response.Write("select sum(order_amount-express_fee) from shop_orders where  " + _sql + "  and " + bsql + "");
            }
            else if (cid == "bei")
            {
                foreach (object ob in _list_bei)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    str = Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                }
                catch (Exception eee) { }
            }
            else if (cid == "dong")
            {
                foreach (object ob in _list_dong)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    str = Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                }
                catch (Exception eee) { }
            }
            else if (cid == "nan")
            {
                foreach (object ob in _list_nan)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    str = Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                }
                catch (Exception eee) { }
            }
            else if (cid == "wai")
            {
                foreach (object ob in _list_wai)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    str = Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                }
                catch (Exception eee) { }
            }
            return str.ToString().Replace(".00","");
  
        }
        public string getcartprice(string cid)
        {
            string str = "0";
            try
            {
                str = Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where " + _sql + " and user_add like'%" + cid + "%'").Tables[0].Rows[0][0].ToString().Replace(".00", "");
            }
            catch (Exception eee) { }
            return str;
        }
        public string getcartnumqu(string cid)
        {
            string str = "0";
            string bsql = "(";
            if (cid == "zhong")
            {
                foreach (object ob in _list_zhong)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    str = Tea.DBUtility.DbHelperSQL.Query("select count(id) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                }
                catch (Exception eee) { }
            }
            else if (cid == "bei")
            {
                foreach (object ob in _list_bei)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    str = Tea.DBUtility.DbHelperSQL.Query("select count(id) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                }
                catch (Exception eee) { }
            }
            else if (cid == "dong")
            {
                foreach (object ob in _list_dong)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    str = Tea.DBUtility.DbHelperSQL.Query("select count(id) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                }
                catch (Exception eee) { }
            }
            else if (cid == "nan")
            {
                foreach (object ob in _list_nan)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    str = Tea.DBUtility.DbHelperSQL.Query("select count(id) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                }
                catch (Exception eee) { }
            }
            else if (cid == "wai")
            {
                foreach (object ob in _list_wai)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    str = Tea.DBUtility.DbHelperSQL.Query("select count(id) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                }
                catch (Exception eee) { }
            }
            return str;
        }

        public string getcartnum(string cid)
        {
            string str = "0";
            try
            {
                str = Tea.DBUtility.DbHelperSQL.Query("select count(id) from shop_orders where  " + _sql + " and user_add like'%" + cid + "%'").Tables[0].Rows[0][0].ToString();
            }
            catch (Exception eee) { }
            return str;
        }

        public string getbiqu(string cid)
        {
            string str = "0";
            string bsql = "(";
            if (cid == "zhong")
            {
                foreach (object ob in _list_zhong)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    string strstr = Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                    str = (Utils.StrToDecimal(strstr, 0) * 100 / allnum).ToString("0.00");
                }
                catch (Exception eee) { }
            }
            else if (cid == "bei")
            {
                foreach (object ob in _list_bei)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    string strstr = Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                    str = (Utils.StrToDecimal(strstr, 0) * 100 / allnum).ToString("0.00");
                }
                catch (Exception eee) { }
            }
            else if (cid == "dong")
            {
                foreach (object ob in _list_dong)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    string strstr = Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                    str = (Utils.StrToDecimal(strstr, 0) * 100 / allnum).ToString("0.00");
                }
                catch (Exception eee) { }
            }
            else if (cid == "nan")
            {
                foreach (object ob in _list_nan)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    string strstr = Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                    str = (Utils.StrToDecimal(strstr, 0) * 100 / allnum).ToString("0.00");
                }
                catch (Exception eee) { }
            }
            else if (cid == "wai")
            {
                foreach (object ob in _list_wai)
                {
                    bsql = bsql + "user_add like'%" + ob.ToString() + "%' or ";
                }
                bsql = bsql + " 1=2 )";
                try
                {
                    string strstr = Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where  " + _sql + "  and " + bsql + "").Tables[0].Rows[0][0].ToString();
                    str = (Utils.StrToDecimal(strstr, 0) * 100 / allnum).ToString("0.00");
                }
                catch (Exception eee) { }
            }

            return str;
        }

        public string getbiqu(string cid, string qu)
        {
            string str = "0";

            try
            {
                string strstr = Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where  " + _sql + "  and user_add like'%" + cid + "%'").Tables[0].Rows[0][0].ToString();
                str = (Utils.StrToDecimal(strstr, 0) * 100 / Utils.StrToDecimal(getcartpricequ(qu), 0)).ToString("0.00");

            }
            catch (Exception eee) { }

            return str;
        }
        public string getbi(string cid)
        {
            string str = "0";

            try
            {
                string strstr = Tea.DBUtility.DbHelperSQL.Query("select sum(order_amount-express_fee) from shop_orders where  " + _sql + "  and user_add like'%" + cid + "%'").Tables[0].Rows[0][0].ToString();
                str = (Utils.StrToDecimal(strstr, 0) * 100 / allnum).ToString("0.00");

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
