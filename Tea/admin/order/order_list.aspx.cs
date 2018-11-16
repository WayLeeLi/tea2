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
        protected int cid;
        protected int status;
        protected int payment_status;
        protected int express_status;
        protected string keywords = string.Empty;
        protected string data, begin, end;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.cid = TWRequest.GetQueryInt("cid");
            this.status = TWRequest.GetQueryInt("status");
            this.payment_status = TWRequest.GetQueryInt("payment_status");
            this.express_status = TWRequest.GetQueryInt("express_status");
            this.keywords = TWRequest.GetQueryString("keywords");
            this.data = TWRequest.GetQueryString("data");
            this.begin = TWRequest.GetQueryString("begin");
            this.end = TWRequest.GetQueryString("end");
            this.pageSize = GetPageSize(10); //每頁數量
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("order_list", TWEnums.ActionEnum.View.ToString()); //檢查許可權
                if (cid > 0)
                {
                    RptBind("company=" + cid + "" + CombSqlTxt(this.status, this.payment_status, this.express_status, this.keywords, data, begin, end), "add_time desc,id desc");
                }
                else
                {
                    RptBind("id>0" + CombSqlTxt(this.status, this.payment_status, this.express_status, this.keywords, data, begin, end), "add_time desc,id desc");
                }
            }
        }

        #region 資料綁定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = TWRequest.GetQueryInt("page", 1);
            if (this.status > 0)
            {
                this.ddlStatus.SelectedValue = this.status.ToString();
            }
            if (this.payment_status > 0)
            {
                this.ddlPaymentStatus.SelectedValue = this.payment_status.ToString();
            }
            if (this.express_status > 0)
            {
                this.ddlExpressStatus.SelectedValue = this.express_status.ToString();
            }
            txtKeywords.Text = this.keywords;
            txtdate.SelectedValue = data;
            txtbegin.Text = begin;
            txtend.Text = end;
            Tea.Web.UI.ShopPage bll = new UI.ShopPage();

            this.rptList.DataSource = bll.GetViewList("shop_orders", "", this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //綁定頁碼
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("order_list.aspx", "status={0}&payment_status={1}&express_status={2}&keywords={3}&page={4}&cid={5}&data={6}&begin={7}&end={8}", this.status.ToString(), this.payment_status.ToString(), this.express_status.ToString(), this.keywords, "__id__", cid.ToString(), data, begin, end);
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 組合SQL查詢語句==========================
        protected string CombSqlTxt(int _status, int _payment_status, int _express_status, string _keywords, string _date, string _begin, string _end)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_status > 0)
            {
                if (_status == 1)
                {
                    strTemp.Append(" and status=1");
                }
                if (_status == 2)
                {
                    strTemp.Append(" and status=2  and express_status!=2");
                }
                if (_status == 3)
                {
                    strTemp.Append(" and status=2  and express_status=2");
                }
                if (_status == 4)
                {
                    strTemp.Append(" and status=3");
                }
                if (_status == 5)
                {
                    strTemp.Append(" and status=4");
                }
                if (_status == 6)
                {
                    strTemp.Append(" and status=5");
                }
            }
            if (_payment_status > 0)
            {
                if (_payment_status == 2)
                {
                    strTemp.Append(" and payment_status=" + _payment_status);
                }
                else
                {
                    strTemp.Append(" and payment_status!=2");
                }
            }
            if (_express_status > 0)
            {
                if (_express_status == 2)
                {
                    strTemp.Append(" and express_status=" + _express_status);
                }
                else
                {
                    strTemp.Append(" and express_status!=2");
                }
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (order_no like '%" + _keywords + "%' or user_name like '%" + _keywords + "%' or accept_name like '%" + _keywords + "%')");
            }
            if (!string.IsNullOrEmpty(_begin) && !string.IsNullOrEmpty(_end))
            {
                string eend = System.DateTime.Parse(_end).AddDays(1).ToString("yyyy-MM-dd");

                strTemp.Append(" and (add_time between '" + _begin + "' and '" + eend + "')");

                //if (data == "2")
                //{
                //    strTemp.Append(" and (express_time between '" + _begin + "' and '" + eend + "')");
                //}
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

        public string get_order(string area, string address)
        {
            string str = "";
            if (area.Split(',')[0].ToString() == "台灣")
            {
                str = area.Split(',')[0].ToString() + "," + area.Split(',')[1].ToString() + "," + area.Split(',')[2].ToString() + "," + address;
            }
            else
            {
                str = address + "," + area.Split(',')[2].ToString() + "," + area.Split(',')[1].ToString() + "," + area.Split(',')[0].ToString();
            }
            return str;
        }

        //關鍵字查詢
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("order_list.aspx", "status={0}&payment_status={1}&express_status={2}&keywords={3}&data={4}&begin={5}&end={6}",
                this.status.ToString(), this.payment_status.ToString(), this.express_status.ToString(), txtKeywords.Text, txtdate.SelectedValue, txtbegin.Text, txtend.Text));
        }

        //訂單狀態
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("order_list.aspx", "status={0}&payment_status={1}&express_status={2}&keywords={3}&data={4}&begin={5}&end={6}",
                ddlStatus.SelectedValue, this.payment_status.ToString(), this.express_status.ToString(), this.keywords, data, begin, end));
        }

        //付款狀態
        protected void ddlPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("order_list.aspx", "status={0}&payment_status={1}&express_status={2}&keywords={3}&data={4}&begin={5}&end={6}",
                this.status.ToString(), ddlPaymentStatus.SelectedValue, this.express_status.ToString(), this.keywords, data, begin, end));
        }

        //發貨狀態
        protected void ddlExpressStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("order_list.aspx", "status={0}&payment_status={1}&express_status={2}&keywords={3}&data={4}&begin={5}&end={6}",
                this.status.ToString(), this.payment_status.ToString(), ddlExpressStatus.SelectedValue, this.keywords, data, begin, end));
        }

        //設定分頁數量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("order_list_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("order_list.aspx", "status={0}&payment_status={1}&express_status={2}&keywords={3}&data={4}&begin={5}&end={6}",
                this.status.ToString(), this.payment_status.ToString(), this.express_status.ToString(), this.keywords, data, begin, end));
        }


        //批次刪除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("order_list", "Edit");
            //ChkAdminLevel("order_list", TWEnums.ActionEnum.Delete.ToString()); //檢查許可權
            int sucCount = 0;
            int errorCount = 0;
            BLL.orders bll = new BLL.orders();
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
            AddAdminLog(TWEnums.ActionEnum.Delete.ToString(), "刪除訂單成功" + sucCount + "條，失敗" + errorCount + "條"); //記錄日誌
            JscriptMsg("刪除成功" + sucCount + "條，失敗" + errorCount + "條！", Utils.CombUrlTxt("order_list.aspx", "status={0}&payment_status={1}&express_status={2}&keywords={3}&data={4}&begin={5}&end={6}",
               this.status.ToString(), this.payment_status.ToString(), this.express_status.ToString(), this.keywords));
        }
        //匯出CSV

        protected void btnExport_Click(object sender, EventArgs e)
        {

            string fileName = "訂單資料" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";
            Tea.Web.UI.ShopPage bll = new UI.ShopPage();

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
            if (strurl.Length > 1)
            {
                dt = bll.GetViewList("shop_orders", "", 0, "id in(" + strurl + ")" + CombSqlTxt(this.status, this.payment_status, this.express_status, this.keywords, data, begin, end), "add_time desc,id desc").Tables[0];
            }
            else
            {
                dt = bll.GetViewList("shop_orders", "", 0, "id>0" + CombSqlTxt(this.status, this.payment_status, this.express_status, this.keywords, data, begin, end), "add_time desc,id desc").Tables[0];
            }



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

            //向HTTP输出流中写入取得的数据信息
            //逐行处理数据 
            int a = 1;

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<table borderColor='black' border='1' >");

                sb.Append("<tbody>");
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append("<table borderColor='black' border='1' >");
                string strtable = "";
                DataSet ddss = Tea.DBUtility.DbHelperSQL.Query("select * from shop_order_goods where order_id=" + dr["id"].ToString() + "");
                DataSet ddssds = Tea.DBUtility.DbHelperSQL.Query("select * from view_order_gift where order_id=" + dr["id"].ToString() + "");
                if (ddss.Tables[0].Rows.Count > 0)
                {
                    strtable = strtable + "<table borderColor='black' border='1' >";
                    strtable = strtable + "<tr><td>序號</td><td>商品編號</td><td>商品名稱</td><td>數量</td><td>金額</td><td>備註</td></tr>";
                    int ab = 1;
                    foreach (DataRow ddrr in ddss.Tables[0].Rows)
                    {
                        strtable = strtable + "<tr><td>" + ab + "</td><td>" + ddrr["goods_no"].ToString() + "</td><td>" + ddrr["goods_title"].ToString() + "</td><td>" + ddrr["quantity"].ToString() + "</td><td>" + ddrr["real_price"].ToString().Replace(".00", "") + "</td><td></td></tr>";
                        ab = ab + 1;
                    }
                    foreach (DataRow ddrr in ddssds.Tables[0].Rows)
                    {
                        strtable = strtable + "<tr><td>" + ab + "</td><td>" + ddrr["gift_code"].ToString() + "</td><td>" + ddrr["title"].ToString() + "</td><td>" + ddrr["ocompany"].ToString() + "</td><td>0</td><td></td></tr>";
                        ab = ab + 1;
                    }
                    strtable = strtable + "<tr><td>--</td><td>DPT-8990</td><td>運費</td><td></td><td>" + dr["express_fee"].ToString().Replace(".00", "") + "</td><td></td></tr>";
                    strtable = strtable + "<tr><td>--</td><td>總計</td><td></td><td></td><td>" + dr["order_amount"].ToString().Replace(".00", "") + "</td><td></td></tr>";
                    strtable = strtable + "<tr><td>--</td><td>" + dr["zhe_else"].ToString() + "</td><td></td><td></td><td>" + dr["zhe"].ToString().Replace(".00", "") + "</td><td></td></tr>";
                    strtable = strtable + "<tr><td>--</td><td>優惠券</td><td></td><td></td><td>" + dr["payment_fee"].ToString().Replace(".00", "") + "</td><td></td></tr>";
                    strtable = strtable + "<tr><td>--</td><td>紅利</td><td></td><td></td><td>" + dr["tuid"].ToString().Replace(".00", "") + "</td><td></td></tr>";
                    strtable = strtable + "</table>";
                }
                sb.Append("<tr>");
                sb.Append("<td>訂單編號:</td>");
                sb.Append("<td>" + dr["order_no"].ToString() + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>購買商品清單:</td>");
                sb.Append("<td>" + strtable + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>備註事項:</td>");
                sb.Append("<td>" + dr["message"].ToString() + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>購買人:</td>");
                sb.Append("<td>寄送發票：" + getinvoice(dr["is_invoice"].ToString()) + "<br>發票資料：" + dr["invoice_title"].ToString().Replace("|", ",").Replace(",", " ") + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>收貨人:</td>");
                sb.Append("<td>姓名：" + getuseradd(dr["user_add"].ToString(), 0) + "<br>聯絡電話：" + getuseradd(dr["user_add"].ToString(), 2) + "<br>郵遞區號：" + getuseradd(dr["user_add"].ToString(), 9) + "<br>地址：" + getuseradd(dr["user_add"].ToString(), 5) + getuseradd(dr["user_add"].ToString(), 6) + getuseradd(dr["user_add"].ToString(), 7) + getuseradd(dr["user_add"].ToString(), 8) + "</td>");
                sb.Append("</tr>");
                sb.Append("</tbody></table>");
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("</tbody></table>");
                sb.Append("<br>");

                sb.Append("<br>");
            }


            Response.Write(sb.ToString());
            Response.End();
        }

        //匯出CSV
        protected void btnExportTwo_Click(object sender, EventArgs e)
        {

            string fileName = "訂單資料" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";
            Tea.Web.UI.ShopPage bll = new UI.ShopPage();

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
            if (strurl.Length > 1)
            {
                dt = bll.GetViewList("shop_orders", "", 0, "id in(" + strurl + ")" + CombSqlTxt(this.status, this.payment_status, this.express_status, this.keywords, data, begin, end), "add_time desc,id desc").Tables[0];
            }
            else
            {
                dt = bll.GetViewList("shop_orders", "", 0, "id>0" + CombSqlTxt(this.status, this.payment_status, this.express_status, this.keywords, data, begin, end), "add_time desc,id desc").Tables[0];
            }

            //
            string[] titleCol = new string[] { "order", "訂單編號", "會員編號", "訂單金額", "購買時間", "收貨人", "收貨地", "產品代號", "產品名稱", "數量", "單價", "小計", "產品類別" };

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
            foreach (DataRow d_r in dt.Rows)
            {
                DataSet ddss = Tea.DBUtility.DbHelperSQL.Query("select * from view_order_goods where id=" + d_r["id"].ToString() + "");
                DataSet ddssds = Tea.DBUtility.DbHelperSQL.Query("select * from view_order_gift where order_id=" + d_r["id"].ToString() + "");


                foreach (DataRow dr in ddss.Tables[0].Rows)
                {
                    sb.Append("<tr>");
                    for (i = 0; i < titleCol.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                sb.Append("<td>" + getno(a.ToString()) + "</td>");
                                break;
                            case 1:
                                sb.Append("<td>" + dr["order_no"].ToString() + "</td>");
                                break;
                            case 2:
                                sb.Append("<td>" + dr["user_name"].ToString() + "</td>");
                                break;
                            case 3:
                                sb.Append("<td>" + (Utils.StrToInt(dr["order_amount"].ToString(), 0) - Utils.StrToInt(dr["express_fee"].ToString(), 0)).ToString() + "</td>");
                                break;
                            case 4:
                                sb.Append("<td>" + dr["add_time"].ToString() + "</td>");
                                break;
                            case 5:
                                sb.Append("<td>" + getuseradd(dr["user_add"].ToString(), 0) + "</td>");
                                break;
                            case 6:
                                sb.Append("<td>" + getuseradd(dr["user_add"].ToString(), 9) + getuseradd(dr["user_add"].ToString(), 5) + getuseradd(dr["user_add"].ToString(), 6) + getuseradd(dr["user_add"].ToString(), 7) + getuseradd(dr["user_add"].ToString(), 8) + "</td>");
                                break;
                            case 7:
                                sb.Append("<td>" + dr["goods_no"].ToString() + "</td>");
                                break;
                            case 8:
                                sb.Append("<td>" + dr["goods_title"].ToString() + "</td>");
                                break;
                            case 9:
                                sb.Append("<td>" + dr["quantity"].ToString() + "</td>");
                                break;
                            case 10:
                                sb.Append("<td>" + dr["real_price"].ToString() + "</td>");
                                break;
                            case 11:
                                sb.Append("<td>" + Utils.StrToInt(dr["quantity"].ToString(), 0) * Utils.StrToInt(dr["real_price"].ToString(), 0) + "</td>");
                                break;
                            case 12:
                                sb.Append("<td>" + gettype(Utils.StrToInt(dr["article_id"].ToString(), 0)) + "</td>");
                                break;
                        }

                    }
                    sb.Append("</tr>");
                    a = a + 1;
                }
                foreach (DataRow dr in ddssds.Tables[0].Rows)
                {
                    sb.Append("<tr>");
                    for (i = 0; i < titleCol.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                sb.Append("<td>" + getno(a.ToString()) + "</td>");
                                break;
                            case 1:
                                sb.Append("<td>" + d_r["order_no"].ToString() + "</td>");
                                break;
                            case 2:
                                sb.Append("<td>" + d_r["user_name"].ToString() + "</td>");
                                break;
                            case 3:
                                sb.Append("<td>" + (Utils.StrToInt(d_r["order_amount"].ToString(), 0) - Utils.StrToInt(d_r["express_fee"].ToString(), 0)).ToString() + "</td>");
                                break;
                            case 4:
                                sb.Append("<td>" + d_r["add_time"].ToString() + "</td>");
                                break;
                            case 5:
                                sb.Append("<td>" + getuseradd(d_r["user_add"].ToString(), 0) + "</td>");
                                break;
                            case 6:
                                sb.Append("<td>" + getuseradd(d_r["user_add"].ToString(), 9) + getuseradd(d_r["user_add"].ToString(), 5) + getuseradd(d_r["user_add"].ToString(), 6) + getuseradd(d_r["user_add"].ToString(), 7) + getuseradd(d_r["user_add"].ToString(), 8) + "</td>");
                                break;
                            case 7:
                                sb.Append("<td>" + dr["gift_code"].ToString() + "</td>");
                                break;
                            case 8:
                                sb.Append("<td>" + dr["title"].ToString() + "</td>");
                                break;
                            case 9:
                                sb.Append("<td>" + dr["ocompany"].ToString() + "</td>");
                                break;
                            case 10:
                                sb.Append("<td>0</td>");
                                break;
                            case 11:
                                sb.Append("<td>0</td>");
                                break;
                            case 12:
                                sb.Append("<td></td>");
                                break;
                        }

                    }
                    sb.Append("</tr>");
                    a = a + 1;
                }
            }
            sb.Append("</tbody></table>");
            Response.Write(sb.ToString());
            Response.End();
        }
        public string getinvoice(string id)
        {
            string str = "";
            if (id == "1")
            {
                str = "電子發票";
            }
            if (id == "2")
            {
                str = "發票捐贈";
            }
            if (id == "3")
            {
                str = "二聯式發票";
            }
            if (id == "4")
            {
                str = "三聯式發票";
            }
            return str;
        }
        public string get_invoice(string title, int i)
        {
            string str = "";
            try
            {
                str = title.Split(',')[i].ToString();
            }
            catch (Exception eee) { }
            return str;
        }
        public string getno(string id)
        {
            return "B" + ljd.function.bunum(id);
        }
        public string getuseradd(string useradd, int i)
        {
            string str = "";
            try
            {
                str = useradd.Split('|')[i].ToString();
            }
            catch (Exception eee) { }
            return str;
        }
        public string gettype(int aid)
        {
            string str = "";
            try
            {
                str = new Tea.BLL.article_category().GetTitle(new Tea.BLL.article().GetModel(aid).category_id);
            }
            catch (Exception eee) { }
            return str;
        }
    }

}

