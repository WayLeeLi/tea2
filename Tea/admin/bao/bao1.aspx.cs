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
        protected int pageCount;
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
        protected string _sql = "status=3";
        protected DataTable dtlist = new DataTable();
        protected DataTable dt_list = new DataTable();
        protected DataTable dt_list1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            this.keywords = TWRequest.GetQueryString("keywords");
            this.begin = TWRequest.GetQueryString("begin");
            this.end = TWRequest.GetQueryString("end");
            this.pageSize = GetPageSize(50); //每頁數量
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("order_list", TWEnums.ActionEnum.View.ToString()); //檢查權限
                RptBind("id>0" + CombSqlTxt(this.status, this.payment_status, this.express_status, this.keywords, data, begin, end, peisong), "id desc");
            }

          
        }

        #region 資料綁定=================================
        private void RptBind(string _strWhere, string _orderby)
        {

            this.page = TWRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            txtbegin.Text = begin;
            txtend.Text = end;
            if (!string.IsNullOrEmpty(begin) && !string.IsNullOrEmpty(end))
            {
                string eend = System.DateTime.Parse(end).AddDays(1).ToString("yyyy-MM-dd");

             _sql=_sql+ " and (add_time between '" + begin + "' and '" + eend + "')";
            }
            dt_list = Tea.DBUtility.DbHelperSQL.Query("select * from view_order where " + _sql + "").Tables[0];
            dt_list1 = Tea.DBUtility.DbHelperSQL.Query("select * from shop_orders where " + _sql + "").Tables[0];
            
            DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select user_name,id from shop_users");


            //Response.Write(dt_list.Rows.Count);
            dtlist.Columns.Add("user_name", typeof(string));//
            dtlist.Columns.Add("cartnum", typeof(int));//
            dtlist.Columns.Add("cartbi", typeof(int));//
          
            DataRow drlist = null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                drlist = dtlist.NewRow();
                drlist["user_name"] = dr["user_name"].ToString();
                drlist["cartnum"] = Utils.StrToInt(getcartnum(dr["id"].ToString()),0);
                drlist["cartbi"] = Utils.StrToInt(getcartbi(dr["id"].ToString()),0);

                if (Utils.StrToInt(drlist["cartnum"].ToString(), 0) > 1)
                {
                    dtlist.Rows.Add(drlist);
                }
            }
            DataView dv = dtlist.DefaultView;
            dv.Sort = "cartnum";
            dtlist = dv.ToTable();
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



            //綁定頁碼
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("bao1.aspx","begin={0}&end={1}&keywords={2}&page={3}",this.begin.ToString(),this.end.ToString(),this.keywords,"__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);

        }
        #endregion

        #region 組合SQL查詢語句==========================
        protected string CombSqlTxt(int _status, int _payment_status, int _express_status, string _keywords, string _date, string _begin, string _end, int _peisong)
        {
            StringBuilder strTemp = new StringBuilder();

            _keywords = _keywords.Replace("'", "");

            if (!string.IsNullOrEmpty(_begin) && !string.IsNullOrEmpty(_end))
            {
                string eend = System.DateTime.Parse(_end).AddDays(1).ToString("yyyy-MM-dd");

                _sql = ("(add_time between '" + _begin + "' and '" + eend + "')");

            }

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

        #region 返回訂單狀態=============================
        protected string GetOrderStatus(int _id)
        {
            string _title = string.Empty;
            Model.orders model = new BLL.orders().GetModel(_id);
            switch (model.status)
            {
                case 1: //如果是線下支付，支付狀態為0，如果是線上支付，支付成功後會自動改變訂單狀態為已確認
                    if (model.payment_status > 0)
                    {
                        _title = "前往付款";
                    }
                    else
                    {
                        _title = "前往付款";
                    }
                    break;
                case 2: //如果訂單為已確認狀態，則進入發貨狀態
                    if (model.express_status > 1)
                    {
                        _title = "貨已寄出";
                    }
                    else
                    {
                        _title = "待出貨";
                    }
                    break;
                case 3:
                    _title = "交易完成";
                    break;
                case 4:
                    _title = "交易取消";
                    break;
                case 5:
                    _title = "退貨完成";
                    break;
            }

            return _title;
        }
        #endregion
        //關鍵字查詢
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("bao1.aspx", "keywords={0}&begin={1}&end={2}", txtKeywords.Text, txtbegin.Text, txtend.Text));
        }

        //設定分頁數量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("order_list_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("bao1.aspx", "keywords={0}&begin={1}&end={2}", txtKeywords.Text, txtbegin.Text, txtend.Text));
        }

        public  string getcartnum(string cid)
        {
            string str = "0";
            try
            {
                DataRow[] DR = dt_list1.Select("user_id=" + cid + "");
                if (DR.Length > 0)
                {
                    str = DR.Length.ToString();
                }

               // str = Tea.DBUtility.DbHelperSQL.Query("select count(id) from shop_orders where " + _sql + " and user_id=" + cid + "").Tables[0].Rows[0][0].ToString();
            }
            catch (Exception eee) { }
            return str;
        }
        public  string getcartbi(string cid)
        {
            string str = "0";
            try
            {
                int num = 0;
                DataRow[] DR = dt_list.Select("user_id=" + cid + "");
                if (DR.Length > 0)
                {
                    foreach (DataRow dr in DR)
                    {
                        num = num + Utils.StrToInt(dr["quantity"].ToString(), 0);
                    }
                }

                str = num.ToString();// //Tea.DBUtility.DbHelperSQL.Query("select sum(quantity) from view_order where " + _sql + " and  user_id=" + cid + "").Tables[0].Rows[0][0].ToString();
            }
            catch (Exception eee) { }
            return str;
        }
        public string getname(string cid,string cb)
        {
            string str = "";
            DataRow[] DR = dtlist.Select("cartnum='" + cid + "' and cartbi='"+cb+"'");
            if (DR.Length > 0)
            {
                foreach (DataRow dr in DR)
                {
                    str = str + dr["user_name"].ToString() + ",";
                }
            }
            return str;
        }
        //匯出CSV
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("baobiao_2", "Edit");
            string fileName = "訂單" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";
            Tea.Web.UI.ShopPage bll_view = new Tea.Web.UI.ShopPage();

            DataTable dt = bll_view.GetViewList("view_channel_goods", "", 10000, this.page, "1=1 " + CombSqlTxt(this.status, this.payment_status, this.express_status, this.keywords, data, begin, end, peisong), "id desc", out this.totalCount).Tables[0];

            string[] titleCol = new string[] { "商品編號", "商品名稱", "銷售規格", "銷售數量", "銷售金額"};

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
                            sb.Append("<td>" + getcartbi(dr["id"].ToString()) + "</td>");
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

        public string getstate(string sid)
        {
            string str = "";
            if (sid == "2")
            {
                str = "是";
            }
            else
            {
                str = "否";
            }
            return str;
        }


        public string getstate1(DateTime sid)
        {
            string str = "0";
            try
            {
                str = Tea.DBUtility.DbHelperSQL.Query("select sum(real_amount) from shop_orders where datediff(day,add_time,'" + sid + "')=0").Tables[0].Rows[0][0].ToString();
            }
            catch (Exception eee) { }
            return str;
        }
        public string getstate2(DateTime sid)
        {
            string str = "0";

            return str;
        }

    }
}
