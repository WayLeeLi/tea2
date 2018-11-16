using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class order : Tea.Web.UI.UserPage
{
    protected int show = 0, show1 = 0, hong, show2 = 0;
    protected int payment_id, express_id;
    protected string act, pnum, quan;
    protected Tea.Model.cart_total cartModel = new Tea.Model.cart_total();
    Tea.BLL.user_oauth bll = new Tea.BLL.user_oauth();
    protected int back = 0;
    protected decimal fee = 0, yun = 0;
    protected string guo, area, city, zip;
    protected string cbquan, cart;
    protected void Page_Load(object sender, EventArgs e)
    {
        cart = TWRequest.GetQueryString("cart");
        if (string.IsNullOrEmpty(cart))
        {
            cart = "3";
        }
        cbquan = TWRequest.GetFormString("cbquan");
      
        if (cart == "3")
        {
            cartModel = Tea.Web.UI.ShopCart.GetTotal(-3);
        }
        if (cartModel.total_point > userModel.point)
        {
            Response.Write(ljd.function.LocalHint("紅利不足,請重新選擇商品！", "cart.aspx"));
            Response.End();
            return;
        }
        try
        {
            guo = userModel.area.Split(',')[0].ToString();
            area = userModel.area.Split(',')[1].ToString();
            city = userModel.area.Split(',')[2].ToString();
            zip = userModel.qq;
        }
        catch (Exception eee) { }

        DataSet ds_guo = Tea.DBUtility.DbHelperSQL.Query("select * from shop_basic where basic_where='city' order by basic_sort");
        data_guo.DataSource = ds_guo;
        data_guo.DataBind();

        dataguo.DataSource = ds_guo;
        dataguo.DataBind();

        data_fp_guo.DataSource = ds_guo;
        data_fp_guo.DataBind();

        data_invo_guo.DataSource = ds_guo;
        data_invo_guo.DataBind();

        try
        {
            Tea.Model.express expModel = new Tea.BLL.express().GetModel(express_id);
            if (decimal.Parse(expModel.maxmoney.ToString()) > cartModel.real_amount)
            {
                yun = expModel.express_fee;
            }
            else
            {
                yun = 0;
            }
        }
        catch (Exception eee) { }

        if (cart == "3")
        {
            data_cart.DataSource = Tea.Web.UI.ShopCart.GetList(-3);
            data_cart.DataBind();
        }
        //string year = System.DateTime.Now.ToString("yyyyMM");

        //data_gift.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from shop_gift where brand_id=" + year + " and status=1 and left_quantity>0 and amount<=" + cartModel.real_amount + "");
        //data_gift.DataBind();

        ////檢查物流方式
        if (data_cart.Items.Count == 0)
        {
            Response.Write(ljd.function.LocalHint("購物車為空,請選購商品！", "cart.aspx"));
            Response.End();
            return;
        }

        data_pay.DataSource = new Tea.BLL.payment().GetList(0, "is_lock=0", "sort_id desc,id desc");
        data_pay.DataBind();


        act = Request["act"];

        if (act == "act_add")
        {
            if (TWRequest.GetFormString("txtguo") != "台灣")
            {
                string ycity = "";
                DataSet yds = Tea.DBUtility.DbHelperSQL.Query("select basic_value,basic_type from  shop_basic where basic_label='" + TWRequest.GetFormString("txtguo") + "' and basic_where='city'");
                if (yds.Tables[0].Rows.Count > 0)
                {
                    ycity = yds.Tables[0].Rows[0]["basic_type"].ToString();
                    DataSet yd_s = Tea.DBUtility.DbHelperSQL.Query("select top 1 basic_sort from shop_basic where basic_money>" + cartModel.total_num_zhe.ToString("0.") + " and basic_where='yunfei' and basic_type='" + ycity + "' order by basic_money");
                    if (yd_s.Tables[0].Rows.Count == 0)
                    {
                        Response.Write(ljd.function.LocalHint("材積重超出寄送限制，請調整訂單內容", "cart.aspx"));
                        Response.End();
                    }
                }
            }
            yun = TWRequest.GetFormInt("yun");

            //券
            quan = TWRequest.GetFormString("txt_quan");
            if (!string.IsNullOrEmpty(quan) && cbquan == "1")
            {

                Tea.Model.quan modelquan = new Tea.BLL.quan().GetModel(quan);
                if (modelquan != null)
                {
                    if (modelquan.quan_show > 0 || int.Parse(modelquan.quan_end_date.Value.ToString("yyyyMMdd")) < int.Parse(System.DateTime.Now.ToString("yyyyMMdd")))
                    {
                        Response.Write(ljd.function.LocalHint("優惠券無效", "vorder.aspx"));
                        Response.End();
                    }
                    fee = modelquan.quan_num.Value;
                }
                else
                {
                    Response.Write(ljd.function.LocalHint("優惠券無效", "vorder.aspx"));
                    Response.End();
                }


            }
            ////紅利
            //hong = TWRequest.GetFormInt("cb_point");
            //int txt_point = TWRequest.GetFormInt("txt_point");
            //if (hong > 0 && txt_point > 0)
            //{


            //    int zuida = Utils.StrToInt((cartModel.real_amount * uconfig.pint_yong / 100).ToString(), 0);
            //    if (cartModel.real_amount < uconfig.pint_mane && userModel.point > zuida)
            //    {
            //        Response.Write(ljd.function.LocalHint("紅利超出限制！", "vorder.aspx"));
            //        return;
            //    }
            //    else
            //    {
            //        back = Utils.StrToInt((userModel.point / uconfig.pint_money).ToString(), 0);
            //    }

            //}


            payment_id = TWRequest.GetFormInt("txt_pay");



            //獲得傳參信息


            string accept_name = Utils.ToHtml(TWRequest.GetFormString("txt_name"));
            string post_code = Utils.ToHtml(TWRequest.GetFormString("txt_zip"));
            string mobile = Utils.ToHtml(TWRequest.GetFormString("txt_mobile"));
            string address = Utils.ToHtml(TWRequest.GetFormString("txt_address"));
            string email = Utils.ToHtml(TWRequest.GetFormString("txt_email"));
            string guo = Utils.ToHtml(TWRequest.GetFormString("txt_guo").Trim());
            string selcity = Utils.ToHtml(TWRequest.GetFormString("txt_state"));
            string selarea = Utils.ToHtml(TWRequest.GetFormString("txt_city"));
            string selcity1 = Utils.ToHtml(TWRequest.GetFormString("txt_state1"));
            string selarea1 = Utils.ToHtml(TWRequest.GetFormString("txt_city1"));
            string telphone = Utils.ToHtml(TWRequest.GetFormString("txt_tel"));


            //獲取訂單配置資料
            Tea.Model.orderconfig orderConfig = new Tea.BLL.orderconfig().loadConfig();



            //檢查付款方式
            if (payment_id == 0)
            {
                Response.Write(ljd.function.LocalHint("對不起，請選擇付款方式！", ""));
                Response.End();
                return;
            }
            Tea.Model.payment payModel = new Tea.BLL.payment().GetModel(payment_id);
            if (payModel == null)
            {
                Response.Write(ljd.function.LocalHint("對不起，付款方式不存在或已刪除！", ""));
                Response.End();
                return;
            }
            //檢查收貨人
            if (string.IsNullOrEmpty(accept_name))
            {
                Response.Write(ljd.function.LocalHint("對不起，請輸入收貨人姓名！", ""));
                Response.End();
                return;
            }
            //檢查手機和電話
            if (string.IsNullOrEmpty(telphone) && string.IsNullOrEmpty(mobile))
            {
                Response.Write(ljd.function.LocalHint("對不起，請輸入收貨人聯絡電話或手機！", ""));
                Response.End();
                return;
            }
            if (string.IsNullOrEmpty(selarea) && string.IsNullOrEmpty(selarea1))
            {
                Response.Write(ljd.function.LocalHint("對不起，請選擇收貨區域！", ""));
                Response.End();
                return;
            }
            //檢查地址
            if (string.IsNullOrEmpty(address) && string.IsNullOrEmpty(address))
            {
                Response.Write(ljd.function.LocalHint("對不起，請輸入詳細的收貨地址！", ""));
                Response.End();
                return;
            }
            ////檢查郵箱
            if (string.IsNullOrEmpty(email))
            {
                Response.Write(ljd.function.LocalHint("對不起，請輸入郵箱！", ""));
                Response.End();
                return;
            }
            //如果開啟暱名購物則不檢查會員是否登入
            int user_id = 0;
            int user_group_id = 0;
            string user_name = string.Empty;
            //檢查用戶是否登入

            if (userModel != null)
            {
                user_id = userModel.id;
                user_group_id = userModel.group_id;
                user_name = userModel.user_name;

            }
            if (orderConfig.maned == 0 && userModel == null)
            {
                Response.Write(ljd.function.LocalHint("對不起，用戶尚未登入或已超時！", ""));
                Response.End();
                return;
            }
            //檢查購物車商品
            IList<Tea.Model.cart_items> iList = Tea.Web.UI.ShopCart.GetList(-3);
            if (iList == null)
            {
                Response.Write(ljd.function.LocalHint("對不起，購物車為空，無法結帳！", ""));
                Response.End();
                return;
            }
            //統計購物車

            //儲存訂單=======================================================================
            Tea.Model.orders model = new Tea.Model.orders();
            model.order_no = "V" + Utils.GetOrderNumber(); //訂單號B開頭為商品訂單
            model.user_id = user_id;
            model.user_name = user_name;
            model.payment_id = 0;
            model.express_id = express_id;
            model.accept_name = accept_name;
            model.post_code = post_code;
            model.telphone = telphone;
            model.mobile = mobile;
            model.email = email;
            if (guo == "台灣")
            {
                model.area = guo + "," + selcity + "," + selarea;
            }
            else
            {
                model.area = guo + "," + selcity1 + "," + selarea1;
            }
            model.address = address;
            model.payable_amount = cartModel.payable_amount;
            model.real_amount = cartModel.real_amount;
            model.express_status = 1;
            model.express_fee = yun; //物流費用
            model.payment_id = payment_id;
            model.message = TWRequest.GetFormString("txtcontent");
            if (TWRequest.GetFormString("txtguo") == "台灣")
            {
                model.user_add = TWRequest.GetFormString("txtname") + "|" + TWRequest.GetFormString("txtsex") + "|" + TWRequest.GetFormString("txtmobile") + "|" + TWRequest.GetFormString("txttel") + "|" + TWRequest.GetFormString("txtemail") + "|" + TWRequest.GetFormString("txtguo") + "|" + TWRequest.GetFormString("txtstate") + "|" + TWRequest.GetFormString("txtcity") + "|" + TWRequest.GetFormString("txtaddress") + "|" + TWRequest.GetFormString("txtzip");
            }
            else
            {
                model.user_add = TWRequest.GetFormString("txtname") + "|" + TWRequest.GetFormString("txtsex") + "|" + TWRequest.GetFormString("txtmobile") + "|" + TWRequest.GetFormString("txttel") + "|" + TWRequest.GetFormString("txtemail") + "|" + TWRequest.GetFormString("txtguo") + "|" + TWRequest.GetFormString("txtstate1") + "|" + TWRequest.GetFormString("txtcity1") + "|" + TWRequest.GetFormString("txtaddress") + "|" + TWRequest.GetFormString("txtzip");
            }
            model.point = -cartModel.total_point;
            model.is_invoice = TWRequest.GetFormInt("txtinvoice");
            if (model.is_invoice == 1)
            {
                model.invoice_title = TWRequest.GetFormString("txt_invoice1");
            }
            if (model.is_invoice == 2)
            {
                model.invoice_title = TWRequest.GetFormString("txt_invoice2");
            }
            if (model.is_invoice == 3)
            {

                if (TWRequest.GetFormString("txtfaaddress_guo") == "台灣")
                {
                    model.invoice_title = TWRequest.GetFormString("txt_invoice3") + "," + TWRequest.GetFormString("txtfaaddress") + "," + TWRequest.GetFormString("txtfaaddress_guo") + "," + TWRequest.GetFormString("txtfaaddress_state") + "," + TWRequest.GetFormString("txtfaaddress_city") + "," + TWRequest.GetFormString("txtfaaddress_zip") + "," + TWRequest.GetFormString("txtfa_address");
                }
                else
                {
                    model.invoice_title = TWRequest.GetFormString("txt_invoice3") + "," + TWRequest.GetFormString("txtfaaddress") + "," + TWRequest.GetFormString("txtfaaddress_guo") + "," + TWRequest.GetFormString("txtfaaddress_state1") + "," + TWRequest.GetFormString("txtfaaddress_city1") + "," + TWRequest.GetFormString("txtfaaddress_zip") + "," + TWRequest.GetFormString("txtfa_address");
                }
            }
            if (model.is_invoice == 4)
            {
                if (TWRequest.GetFormString("txt_invoiceaddress_guo") == "台灣")
                {
                    model.invoice_title = TWRequest.GetFormString("txt_invoice_4") + "," + TWRequest.GetFormString("txt_invoiceaddress") + "," + TWRequest.GetFormString("txt_invoiceaddress_guo") + "," + TWRequest.GetFormString("txt_invoiceaddress_state") + "," + TWRequest.GetFormString("txt_invoiceaddress_city") + "," + TWRequest.GetFormString("txt_invoiceaddress_zip") + "," + TWRequest.GetFormString("txt_invoice_address");
                }
                else
                {
                    model.invoice_title = TWRequest.GetFormString("txt_invoice_4") + "," + TWRequest.GetFormString("txt_invoiceaddress") + "," + TWRequest.GetFormString("txt_invoiceaddress_guo") + "," + TWRequest.GetFormString("txt_invoiceaddress_state1") + "," + TWRequest.GetFormString("txt_invoiceaddress_city1") + "," + TWRequest.GetFormString("txt_invoiceaddress_zip") + "," + TWRequest.GetFormString("txt_invoice_address");
                }
            }



            if (!string.IsNullOrEmpty(quan))
            {
                Tea.Model.quan modelquan1 = new Tea.BLL.quan().GetModel(quan);
                if (modelquan1 != null)
                {
                    model.zhe_code = modelquan1.quan_code;
                }
            }
            //model.zhe_else = cartModel.sales_str;
            // model.point = -cartModel.total_point;//紅利兌換
            //model.express_fee = yun;//運費
            //model.payment_fee = -fee;//優惠券
            //model.tuid = -back;//紅利折扣
            //model.zhe = -cartModel.total_moneyback; //折價金額
            model.num = 0;// Utils.StrToInt((cartModel.real_amount / uconfig.money_pint).ToString("0."), 0); //獲得紅利

            //訂單總金額=實付商品金額+運費+支付手續費-回饋金
           
            if (model.order_amount < 0)
            {
                model.order_amount = 0;
            }

            model.add_time = DateTime.Now;
            //商品詳細列表
            List<Tea.Model.order_goods> gls = new List<Tea.Model.order_goods>();
            foreach (Tea.Model.cart_items item in iList)
            {

                gls.Add(new Tea.Model.order_goods { article_id = item.id, goods_title = item.title, goods_price = item.price, real_price = item.user_price, quantity = item.quantity, point = item.point, goods_where = item.by, goods_code = item.goods_code, goods_no = item.goods_code, goods_img = item.img_url, spec_text = item.goods_color, img_url = item.img_url,goodsid = item.goodsid });

            }
            model.order_goods = gls;
            model.order_amount = model.real_amount + model.express_fee + model.payment_fee + model.tuid + model.zhe;
            model.order_pay_code = model.order_no + Utils.Number(4);
            int result = new Tea.BLL.orders().Add(model);

    
            if (result < 1)
            {
                Response.Write(ljd.function.LocalHint("訂單儲存過程中發生錯誤，請重新送出！", ""));
                Response.End();
                return;
            }
            try
            {
                string mailTitle = "訂單通知信", mailContent = "";
                string url = weburl + "mail/order.aspx?id=" + result, ss = "";
                mailContent = ljd.function.GetPage(url, out ss);
                //發送郵件
                TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport, config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, model.email, mailTitle, mailContent);
            }
            catch (Exception eee) { }
            //if (email != TWRequest.GetFormString("txtemail"))
            //{
            //    try
            //    {
            //        string mailTitle = "訂單通知信", mailContent = "";
            //        string url = weburl + "mail/order.aspx?id=" + result, ss = "";
            //        mailContent = ljd.function.GetPage(url, out ss);
            //        //發送郵件
            //        TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport, config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, TWRequest.GetFormString("txtemail"), mailTitle, mailContent);
            //    }
            //    catch (Exception eee) { }
            //}
            //string yearmonth = System.DateTime.Now.ToString("yyyyMM");
            //DataSet ds_gift = Tea.DBUtility.DbHelperSQL.Query("select top 1 * from shop_gift where brand_id=" + yearmonth + " and status=1 and left_quantity>0 and amount<=" + cartModel.real_amount + "");
            //if (ds_gift.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow dr in ds_gift.Tables[0].Rows)
            //    {
            //        int gid = Utils.StrToInt(dr["id"].ToString(), 0);
            //        Tea.Model.order_gift model_gift = new Tea.Model.order_gift();
            //        model_gift.gift_id =
            //        model_gift.order_id = result;
            //        new Tea.BLL.order_gift().Add(model_gift);
            //    }
            //}

            //扣除紅利
            if (model.point < 0)
            {
                new Tea.BLL.user_point_log().Add(model.user_id, model.user_name, model.point, "紅利兌換商品：" + model.order_no, false, 0, 0);
            }

            //if (!string.IsNullOrEmpty(quan))
            //{
            //    Tea.Model.quan modelquan = new Tea.BLL.quan().GetModel(quan);
            //    if (modelquan != null)
            //    {
            //        modelquan.quan_lock = 1;
            //        modelquan.quan_date = System.DateTime.Now;
            //        new Tea.BLL.quan().Update(modelquan);
            //    }
            //}
            //userModel.point = userModel.point + model.point;
            //new Tea.BLL.users().Update(userModel);

            //清空購物車
            Tea.Web.UI.ShopCart.ClearShop(cart);
            // Tea.Web.UI.ShopCart.Clear("0");
            //送出成功，返回URL
            if (model.payment_id != 1)
            {
                Response.Write(ljd.function.LocalHint("訂單已成功送出！", "pay.aspx?id=" + result));
                Response.End();
                return;
            }
            else
            {
                Response.Write(ljd.function.LocalHint("訂單已成功送出！", "pay.aspx?id=" + result));
                Response.End();
                return;

            }

        }
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

}
