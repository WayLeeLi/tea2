using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Text;
using System.Xml;
using System.Data;
public partial class pay : Tea.Web.UI.ShopPage
{
    Tea.BLL.orders bll = new Tea.BLL.orders();
    protected int id;
    protected Tea.Model.orders model = null;
    protected Tea.Model.payment modelpay = null;
    protected string tFdId, ACTNO, AMT;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = TWRequest.GetQueryInt("id");
        if (id > 0)
        {
            model = bll.GetModel(id);
            if (model.order_pay.Length > 10)
            {
                Response.Redirect("ordershow.aspx?id=" + model.id);
                return;
            }
            if (model.payment_status==2)
            {
                Response.Redirect("ordershow.aspx?id=" + model.id);
                return;
            }
            else
            {
                model.order_pay_code = model.order_no + Utils.Number(4);
                bll.Update(model);
                model = bll.GetModel(id);
            }
            modelpay = new Tea.BLL.payment().GetModel(model.payment_id);

            string ptype = "ALL";
            if (modelpay != null)
            {
                ptype = modelpay.api_path;
            }
            string ok_urlall = weburl + "allpay_ok.aspx"; //返回地址

            string ClientBackURL = weburl + "shop/payok.aspx?id=" + id;
            string ClientRedirectURL = weburl + "shop/payok.aspx?id=" + id;

            string OrderResultURL = weburl + "shop/payok.aspx?id=" + id;
            string PaymentInfoURL = weburl + "allpayok.aspx";
            StringBuilder sb = new StringBuilder();
            StringBuilder sbHtml = new StringBuilder();

       
            XmlDocument doc = new XmlDocument();
            if (ptype == "WeiXinpay")
            {
                ok_urlall = weburl + "allpay_okweixin.aspx"; //返回地址
                doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(config.webpath + "xmlconfig/ofubao.config"));
            }
            else
            {
                doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(config.webpath + "xmlconfig/lvjie.config"));
            }

            string merchantid = doc.SelectSingleNode(@"Root/merID").InnerText;
            string HashKey = doc.SelectSingleNode(@"Root/MerchantID").InnerText;
            string HashIV = doc.SelectSingleNode(@"Root/TerminalID").InnerText;

            string ItemName = "";
            DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select * from shop_order_goods where order_id=" + id + "");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ItemName = ItemName + dr["goods_title"].ToString() + dr["real_price"].ToString().Replace(".00", "") + "元X" + dr["quantity"] + "#";
            }
            ItemName = Utils.DelLastChar(ItemName, "#");
            string url = "";
            //url
            sb.Append("HashKey=" + HashKey + "");

            sb.Append("&ChoosePayment=" + ptype + "");
            //if (ptype != "WeiXinpay")
            //{
            sb.Append("&ClientBackURL=" + ClientBackURL + "");
            sb.Append("&ClientRedirectURL=" + ClientRedirectURL + "");
            //}
            sb.Append("&ItemName=" + ItemName + "");
            sb.Append("&MerchantID=" + merchantid + "");
            sb.Append("&MerchantTradeDate=" + model.add_time.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/") + "");
            sb.Append("&MerchantTradeNo=" + model.order_pay_code + "");
            sb.Append("&OrderResultURL=" + OrderResultURL + "");
            sb.Append("&PaymentInfoURL=" + PaymentInfoURL + "");
            sb.Append("&PaymentType=aio");
            sb.Append("&Remark=" + model.order_no + "");
            sb.Append("&ReturnURL=" + ok_urlall + "");
            sb.Append("&TotalAmount=" + (model.order_amount).ToString("0.") + "");
            sb.Append("&TradeDesc=" + model.order_no + "");
            sb.Append("&HashIV=" + HashIV + "");
            url = sb.ToString();
            url = getstr(url).ToLower();
            sb.Append("&CheckMacValue=" + ljd.function.md5(url, 32) + "");
            string CheckMacValue = ljd.function.md5(url, 32);
            if (ptype == "WeiXinpay")
            {
                sbHtml.Append("<form id='paysubmit' name='ecbanksubmit' action='https://payment.opay.tw/Cashier/AioCheckOut/V5' method='post'>");
            }
            else
            {
                sbHtml.Append("<form id='paysubmit' name='ecbanksubmit' action='https://payment.ecpay.com.tw/Cashier/AioCheckOut/V5' method='post'>");
            }
            sbHtml.Append("<input type='hidden' name='ChoosePayment' value='" + ptype + "'/>");
            //if (ptype != "WeiXinpay")
            //{
            sbHtml.Append("<input type='hidden' name='ClientBackURL' value='" + ClientBackURL + "'/>");
            sbHtml.Append("<input type='hidden' name='ClientRedirectURL' value='" + ClientRedirectURL + "'/>");
            // }
            sbHtml.Append("<input type='hidden' name='ItemName' value='" + ItemName + "'/>");
            sbHtml.Append("<input type='hidden' name='MerchantID' value='" + merchantid + "'/>");
            sbHtml.Append("<input type='hidden' name='MerchantTradeDate' value='" + model.add_time.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/") + "'/>");
            sbHtml.Append("<input type='hidden' name='MerchantTradeNo' value='" + model.order_pay_code + "'/>");
            sbHtml.Append("<input type='hidden' name='OrderResultURL' value='" + OrderResultURL + "'/>");
            sbHtml.Append("<input type='hidden' name='PaymentInfoURL' value='" + PaymentInfoURL + "'/>");
            sbHtml.Append("<input type='hidden' name='PaymentType' value='aio'/>");
            sbHtml.Append("<input type='hidden' name='Remark' value='" + model.order_no + "'/>");
            sbHtml.Append("<input type='hidden' name='ReturnURL' value='" + ok_urlall + "'/>");
            sbHtml.Append("<input type='hidden' name='TotalAmount' value='" + (model.order_amount).ToString("0.") + "'/>");
            sbHtml.Append("<input type='hidden' name='TradeDesc' value='" + model.order_no + "'/>");
            sbHtml.Append("<input type='hidden' name='CheckMacValue' value='" + CheckMacValue + "'/>");
            sbHtml.Append("<input type='Submit' style='display:none;'></form>");//
            sbHtml.Append("<script>document.forms['paysubmit'].submit();</script>");
            Response.Write(sbHtml);
            Response.End();
        }
    }
    public string getstr(string str)
    {
        return System.Web.HttpUtility.UrlEncode(str, System.Text.Encoding.GetEncoding("UTF-8"));
    }
}
