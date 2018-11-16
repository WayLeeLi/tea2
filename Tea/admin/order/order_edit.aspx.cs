using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
namespace Tea.Web.admin.order
{
    public partial class order_edit : Web.UI.ManagePage
    {
        private int id = 0;
        protected Model.orders model = new Model.orders();
        protected Model.article modelart = new Model.article();
        protected Model.order_tui modeltui = new Model.order_tui();
        protected decimal zhong, c_chang, c_kuan, c_gao, zc;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = TWRequest.GetQueryInt("id");
            if (this.id == 0)
            {
                JscriptMsg("傳輸參數不正確！", "back");
                return;
            }
            if (!new BLL.orders().Exists(this.id))
            {
                JscriptMsg("記錄不存在或已被刪除！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                BLL.express bll2 = new BLL.express();
                DataTable dt = bll2.GetList("").Tables[0];
                ddlExpressId.Items.Clear();
                ddlExpressId.Items.Add(new ListItem("請選擇配送方式", ""));
                foreach (DataRow dr in dt.Rows)
                {
                    ddlExpressId.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
                }
                //ChkAdminLevel("order_list", TWEnums.ActionEnum.View.ToString()); //檢查許可權
                ShowInfo(this.id);
            }
        }

        #region 賦值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.orders bll = new BLL.orders();
            model = bll.GetModel(_id);
            modelart = new Tea.BLL.article().GetModel(model.artid);
            if (modelart == null)
            {
                modelart = new Model.article();
            }
            //綁定商品列表
            this.rptList.DataSource = model.order_goods;
            this.rptList.DataBind();
            foreach (Tea.Model.order_goods goods in model.order_goods)
            {

                Tea.Model.goods mgoods = new Tea.BLL.goods().GetModel(goods.goodsid);
                try
                {

                    zhong = zhong + (goods.quantity * mgoods.zhong);
                    if (mgoods.chang > c_chang)
                    {
                        c_chang = mgoods.chang;

                    }
                    if (mgoods.kuan > c_kuan)
                    {
                        c_kuan = mgoods.kuan;

                    }
                    c_gao += mgoods.gao * goods.quantity;

                   

                }
                catch (Exception eee) { }
            }

            //Response.Write(zhong);
            //Response.Write("-"+c_chang + "-" + c_kuan + "-" + c_gao);
            zc = c_chang * c_kuan * c_gao / 6000;
            if (zc > zhong)
            {
                zhong = zc;
            }

            data_gift.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from view_order_gift where order_id=" + id + "");
            data_gift.DataBind();
            //根據訂單狀態，顯示各類操作按鈕
            switch (model.status)
            {
                case 1: //如果是線下支付，支付狀態為0，如果是線上支付，支付成功後會自動改變訂單狀態為已確認
                    if (model.payment_status != 2)
                    {
                        //確認付款、取消訂單、修改收貨按鈕顯示
                        btnPayment.Visible = btnEditAcceptInfo.Visible = true;
                    }
                    else
                    {
                        btnCancel.Visible = false;
                        //確認訂單、取消訂單、修改收貨按鈕顯示
                        btnConfirm.Visible = btnEditAcceptInfo.Visible = true;
                    }
                    //修改訂單備註、修改商品總金額、修改配送費用、修改支付手續費、修改發票稅金按鈕顯示
                    break;
                case 2: //如果訂單為已確認狀態，則進入發貨狀態
                    if (model.express_status != 2)
                    {
                        //確認發貨、取消訂單、修改收貨資訊按鈕顯示
                        btnExpress.Visible = btnEditAcceptInfo.Visible = true;
                    }
                    else
                    {
                        btnCancel.Visible = false;
                        //完成訂單、取消訂單按鈕可見
                        btnComplete.Visible = true;
                    }
                    if (model.payment_status == 2)
                    {
                        btnCancel.Visible = false;
                    }
                    //修改訂單備註按鈕可見
                    //btnEditRemark.Visible = true;
                    break;
                case 3:
                    //退貨訂單、修改訂單備註按鈕可見
                    btnInvalid.Visible = true;
                    btnCancel.Visible = false;
                    break;
                case 5:
                    //退貨訂單、修改訂單備註按鈕可見
                    btnCancel.Visible = false;
                    break;
            }
            //根據訂單狀態和物流單號跟蹤物流資訊
            if (model.express_status == 2)
            {
                ddlExpressId.SelectedValue = model.express_id.ToString();
                //長:<%=getbao(model.order_bao,0) %> 寬:<%=getbao(model.order_bao,1) %> 高:<%=getbao(model.order_bao,2) %> 重:<%=getbao(model.order_bao,3) %>
                chang.Text = getbao(model.order_bao, 0);
                kuan.Text = getbao(model.order_bao, 1);
                gao.Text = getbao(model.order_bao, 2);
                txtzhong.Text = getbao(model.order_bao,3);
                express_no.Text = model.express_no;
                Model.express modelt = new BLL.express().GetModel(model.express_id);
                Model.orderconfig orderConfig = new BLL.orderconfig().loadConfig();
            }

            trade_no.Text = model.trade_no;
            if (model.invoice_taxes == 1)
            {
                cbFaPiao.Checked = true;
            }
        }
        #endregion
        #region 返回訂單狀態=============================
        protected string GetOrderStatus(int _id)
        {
            string _title = string.Empty;
            Model.orders model1 = new BLL.orders().GetModel(_id);
            if (model1 != null)
            {
                switch (model1.status)
                {
                    case 1: //如果是線下支付，支付狀態為0，如果是線上支付，支付成功後會自動改變訂單狀態為已確認
                        if (model1.payment_status > 0)
                        {
                            _title = "前往付款";
                        }
                        else
                        {
                            _title = "前往付款";
                        }
                        break;
                    case 2: //如果訂單為已確認狀態，則進入發貨狀態
                        if (model1.express_status > 1)
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
            }

            return _title;
        }
        #endregion
        public string getfp(string title, int i)
        {
            string str = title.Replace("|", ",").Replace(",", " ").Replace("null", "");
            try
            {
                if (i == 3 || i==4)
                {
                    if (title.Contains("台灣"))
                    {
                        str = title.Replace("|", ",").Replace(",", " ").Replace("null", "");
                    }
                    else
                    {
                        str = title.Replace("|", ",").Replace(",", " ").Replace("null", "");
                    }
                }
               
            }
            catch (Exception eee) { }
            return str;
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
        public string getbao(string bao, int i)
        {
            string str = "";
            try
            {
                str = bao.Split('|')[i].ToString();
            }
            catch (Exception eee) { }
            return str;
        }
        public string getpoint(string by, string name)
        {
            string str = name;
            try
            {
                if (by == "point" && name == "show")
                {
                    str = "detail";
                }
            }
            catch (Exception eee) { }
            return str;
        }
        public string getpoint(string by, int i)
        {
            string str = "";
            try
            {
                if (by != "point" && i == 2)
                {
                    str = " style=\"display:none;\"";
                }

                if (by == "point" && i != 2)
                {
                    str = " style=\"display:none;\"";
                }

            }
            catch (Exception eee) { }
            return str;
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
        protected void bu_submit_Click(object sender, EventArgs e)
        {
            id = TWRequest.GetQueryInt("id");
            ChkAdminLevelEdit("order_list", "Edit");
            int invoice_taxes = 0;
            if (cbFaPiao.Checked)
            {
                invoice_taxes = 1;
            }


            new Tea.BLL.orders().UpdateField(id, "trade_no='" + trade_no.Text.Trim() + "',invoice_taxes=" + invoice_taxes + "");

            Response.Write(ljd.function.LocalHint("成功送出", "order_edit.aspx?action=Edit&id=" + id));
            Response.End();
        }
        protected void bu_no_Click(object sender, EventArgs e)
        {
            id = TWRequest.GetQueryInt("id");
            ChkAdminLevelEdit("order_list", "Edit");
            string order_bao = chang.Text.Trim() + "|" + kuan.Text.Trim() + "|" + gao.Text.Trim() + "|" + txtzhong.Text.Trim();
            new Tea.BLL.orders().UpdateField(id, "express_no='" + express_no.Text.Trim() + "',order_bao='" + order_bao + "',express_id=" + ddlExpressId.SelectedValue + "");

            Response.Write(ljd.function.LocalHint("成功送出", "order_edit.aspx?action=Edit&id=" + id));
            Response.End();
        }
    }
}
