using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net.Mime;
using Microsoft.Win32;
using System.Collections;
using System.Net;
using System.Data;
using System.Collections;
using Tea.Common;
using System.Xml;
using System.Security.Cryptography;
public partial class allpay_ok : Tea.Web.UI.ShopPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = "";
        XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(config.webpath + "xmlconfig/lvjie.config"));
        string mid = doc.SelectSingleNode(@"Root/merID").InnerText;
        string HashKey = doc.SelectSingleNode(@"Root/MerchantID").InnerText;
        string HashIV = doc.SelectSingleNode(@"Root/TerminalID").InnerText;

        string MerchantID = Request["MerchantID"];
        string MerchantTradeNo = Request["MerchantTradeNo"];
        string StoreID = Request["StoreID"];
        string PaymentType = Request["PaymentType"];
        string RtnCode = Request["RtnCode"];
        string RtnMsg = Request["RtnMsg"];
        string TradeAmt = Request["TradeAmt"];
        string TradeDate = Request["TradeDate"];
        string TradeNo = Request["TradeNo"];
        string CheckMacValue = Request["CheckMacValue"];


        string BankCode = Request["BankCode"];
        string vAccount = Request["vAccount"];
        string ExpireDate = Request["ExpireDate"];



        string PaymentNo = Request["PaymentNo"];
        string Barcode1 = Request["Barcode1"];
        string Barcode2 = Request["Barcode2"];
        string Barcode3 = Request["Barcode3"];



        StringBuilder sb = new StringBuilder();
        sb.Append("HashKey=" + HashKey + "");
        sb.Append("&MerchantID=" + Request["MerchantID"] + "");
        sb.Append("&MerchantTradeNo=" + Request["MerchantTradeNo"] + "");
        sb.Append("&StoreID=" + Request["StoreID"] + "");
        sb.Append("&PaymentType=" + Request["PaymentType"] + "");
        sb.Append("&RtnCode=" + Request["RtnCode"] + "");
        sb.Append("&RtnMsg=" + Request["RtnMsg"] + "");
        sb.Append("&TradeAmt=" + Request["TradeAmt"] + "");
        sb.Append("&TradeDate=" + Request["TradeDate"] + "");
        sb.Append("&TradeNo=" + Request["TradeNo"] + "");
        sb.Append("&HashIV=" + HashIV + "");
        url = sb.ToString();
        url = getstr(url).ToLower();
        string CMValue = ljd.function.md5(url, 32);

        if (MerchantID == mid && !string.IsNullOrEmpty(MerchantTradeNo))// && CheckMacValue == CMValue
        {
            Tea.Model.orders model = new Tea.BLL.orders().GetModelPayCode(MerchantTradeNo);
            Tea.Model.payment modelpay = new Tea.BLL.payment().GetModel(model.payment_id);
            if (model != null)
            {
               
                if (modelpay.api_path == "ATM" && RtnCode == "2")
                {
                    model.order_pay = BankCode + "|" + vAccount + "|" + ExpireDate;
                }
                if ((modelpay.api_path == "CVS") || (modelpay.api_path == "BARCODE"))
                {
                    if (RtnCode == "10100073")
                    {
                        model.order_pay = PaymentNo + "|" + ExpireDate + "|" + Barcode1 + "|" + Barcode2 + "|" + Barcode3+"-----";
                    }
                }
                //model.order_pay = PaymentNo + "|" + ExpireDate + "|" + Barcode1 + "|" + Barcode2 + "|" + Barcode3 + "--" + RtnCode+"--"+PaymentType;
                new Tea.BLL.orders().Update(model);
                Response.Write("1|OK");
  
            }
        }
        else
        {
            Response.Write("0|ErrorMessage");
            //Response.End();
        }
    }
    public string getstr(string str)
    {
        return System.Web.HttpUtility.UrlEncode(str, System.Text.Encoding.GetEncoding("UTF-8"));
    }
}
