<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payok.aspx.cs" Inherits="order" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width">
    <title><%=title%></title>
    <meta name="Keywords" content="<%=keyword%>" />
    <meta name="Description" content="<%=describe%>" />
    <link rel="stylesheet" type="text/css" href="/css/css.css" media="screen">
    <script type="text/javascript" src="/js/jquery-1.11.0.min.js"></script>
    <script src="/js/app.js"></script>
</head>
<body>
    <public:hand ID="hand" runat="server" />
    <div class="width-sys location">
        <div class="cart-loc wap-none">
            <img src="/images/cart3.png" alt="" /></div>
        <div class="cart-loc wap-show">
            <img src="/images/cart3-1.png" alt="" /></div>
    </div>
    <div class="width-sys">
        <div class=" cart-bg">
            <div class="order-box">
                <div class="col-m5 float-l">
                    <div class="order-boxw">
                        <div class="order-box-tit">
                            購買人資訊</div>
                        <div class="order-box-table">
                            <table width="100%" border="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td width="120">
                                            訂單號
                                        </td>
                                        <td>
                                            <%=model.order_no%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="120">
                                            訂購人姓名
                                        </td>
                                        <td>
                                            <%=model.accept_name%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="120">
                                            訂購人地址
                                        </td>
                                        <%if(model.area.Split(',')[0].ToString()=="台灣"){ %>
          <td><%=model.area.Split(',')[0].ToString()%>,<%=model.post_code%>,<%=model.area.Split(',')[1].ToString()%>,<%=model.area.Split(',')[2].ToString()%>,<%=model.address%></td>
          <%}else{ %>
          <td><%=model.address%>,<%=model.area.Split(',')[2].ToString()%>,<%=model.area.Split(',')[1].ToString()%>,<%=model.post_code%>,<%=model.area.Split(',')[0].ToString()%></td>
          <%} %>
                                    </tr>
                                    <tr>
                                        <td width="120">
                                            連絡電話
                                        </td>
                                        <td>
                                            <%=model.telphone%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="120">
                                            E-mail
                                        </td>
                                        <td>
                                            <%=model.email%>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="order-boxw">
                        <div class="order-box-tit">
                            收件人資訊</div>
                        <div class="order-box-table">
                            <table width="100%" border="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td width="120">
                                            收件人姓名
                                        </td>
                                        <td>
                                            <%=getuseradd(model.user_add,0)%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="120">
                                            收件人地址
                                        </td>
                                          <%if(getuseradd(model.user_add,5)=="台灣"){ %>
          <td><span><%=getuseradd(model.user_add,5)%>, <%=getuseradd(model.user_add,9)%>,<%=getuseradd(model.user_add,6)%>,<%=getuseradd(model.user_add,7)%>,<%=getuseradd(model.user_add,8)%></span></td>
          <%}else{ %>
          <td><span> <%=getuseradd(model.user_add,8)%>,<%=getuseradd(model.user_add,7)%>,<%=getuseradd(model.user_add,6)%>,<%=getuseradd(model.user_add,9)%>,<%=getuseradd(model.user_add,5)%></span></td>
          <%} %>
                                    </tr>
                                    <tr>
                                        <td width="120">
                                            連絡電話
                                        </td>
                                        <td>
                                          <%=getuseradd(model.user_add,2)%>&nbsp;&nbsp;&nbsp;<%=getuseradd(model.user_add,3).Replace(",","")%>
                                        </td>
                                    </tr>
             <%--                       <tr>
                                        <td width="120">
                                            E-mail
                                        </td>
                                        <td>
                                            <%=getuseradd(model.user_add,4)%>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td width="120">
                                            預計到貨日期
                                        </td>
                                        <td><%=model.zhe_moeny%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            備註
                                        </td>
                                        <td>
                                            <%=model.message%>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="col-m5 float-r">
                    <div class="order-boxw">
                        <div class="order-box-tit">
                            交易資訊</div>
                        <div class="order-box-table">
                            <table width="100%" border="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td width="120">
                                            付款方式
                                        </td>
                                        <td>
                                            <p><%=new Tea.BLL.payment().GetTitle(model.payment_id)%></p>
                                        </td>
                                    </tr>
                                       <%if(model.order_pay.Length>10 && model.payment_status!=2){ %>
                                            <tr>
                                                <td width="120">
                                                    付款信息
                                                </td>
                                                <td>
                                                      <%if (payModel.api_path == "ATM")
                                                        { %>
                                                       繳費銀行代碼:<%=getuseradd(model.order_pay,0)%><br />
                                                       繳費虛擬帳號:<%=getuseradd(model.order_pay,1)%><br />
                                                       繳費期限:<%=getuseradd(model.order_pay,2)%>
                                                    
                                                      <%} %>
                                                       <%if (payModel.api_path == "CVS")
                                                         { %>
                                                         繳費代碼:<%=getuseradd(model.order_pay,0)%><br />
                                                         繳費期限:<%=getuseradd(model.order_pay,1)%>
                                                      <%} %>
                                                       <%if (payModel.api_path == "BARCODE")
                                                         { %>
                                                    
                                                         繳費期限<%=getuseradd(model.order_pay,1)%><br />
                                                     <img src="https://pay-stage.ecpay.com.tw/Barcode/GenerateBarcode?barcode=<%=getuseradd(model.order_pay,2)%>" /><br />
                                                      <img src="https://pay-stage.ecpay.com.tw/Barcode/GenerateBarcode?barcode=<%=getuseradd(model.order_pay,3)%>" /><br />
                                                      <img src=" https://pay-stage.ecpay.com.tw/Barcode/GenerateBarcode?barcode=<%=getuseradd(model.order_pay,4)%>" /><br />  
                                           
                                                      <%} %>
                                                </td>
                                            </tr>
                                            <%} %>
                                    <tr>
                                        <td width="120">
                                            運送方式
                                        </td>
                                        <td>
                                            <%=new Tea.BLL.express().GetTitle(model.express_id)%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="120">
                                            發票資訊
                                        </td>
                                        <td>
                                            <%=getinvoice(model.is_invoice.ToString())%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="120">
                                            紅利點數
                                        </td>
                                        <td>
                                            <%=model.num%> 點
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=" cart-bg">
            <div class="cart-box">
                <asp:Repeater ID="data_cart" runat="server"><ItemTemplate>
                <div class="cart-lrbox">
                    <dl>
                        <dd class="col_1">
                            <div class="c-pic float-l"><a href="<%#getpoint(Eval("goods_where").ToString(),"show")%>.aspx?id=<%#Eval("article_id")%>"><img src="<%#Eval("goods_img")%>" width="800" height="800" alt="<%#Eval("goods_title")%>" /></a></div>
                        </dd>
                        <dd class="col_21">
                            <div class="pt-box  float-l">
                                <div class="cart-pt">
                                    <a href="<%#getpoint(Eval("goods_where").ToString(),"show")%>.aspx?id=<%#Eval("article_id")%>"><strong><%#get_sub(Eval("article_id").ToString())%></strong></a></div>
                                <div class="cart-pt">
                                    <a href="<%#getpoint(Eval("goods_where").ToString(),"show")%>.aspx?id=<%#Eval("article_id")%>"><%#Eval("goods_title")%></a></div>
                            </div>
                        </dd>
                        <dd class="col_31">
                            <div class="cart-select">
                                <span class="wap-show">規格：</span><%#Eval("spec_text")%>
                            </div>
                        </dd>
                        <dd class="col_41">
                           <div class="price-box" <%#getpoint(Eval("goods_where").ToString(),1)%>>
                                        <span class="price">NT$<%#Eval("real_price", "{0:0.}")%></span><br>
                                        <span class="yprice">NT$<%#Eval("goods_price", "{0:0.}")%></span>
                                    </div>
                                    <div class="price-box" <%#getpoint(Eval("goods_where").ToString(),2)%>>
                                        <span class="price"><%#Eval("point")%>點</span>
                                    </div>
                        </dd>
                        <dd class="col_51">
                            <div class="number-box">
                                <span class="wap-show">數量：</span><%#Eval("quantity")%>
                            </div>
                        </dd>
                        <dd class="col_61">
                             <div class="price-box1" <%#getpoint(Eval("goods_where").ToString(),1)%>> <span class="wap-show" >小計：</span><span class="price">NT$<%#Tea.Common.Utils.StrToInt(Eval("quantity").ToString(), 0) * Tea.Common.Utils.StrToInt(Eval("real_price", "{0:0.}").ToString(), 0)%></span></div>
                                    <div class="price-box1" <%#getpoint(Eval("goods_where").ToString(),2)%>> <span class="wap-show">小計：</span><span class="price"><%#Tea.Common.Utils.StrToInt(Eval("quantity").ToString(), 0) * Tea.Common.Utils.StrToInt(Eval("point", "{0:0.}").ToString(), 0)%></span>點</div>
                        
                        </dd>
                    </dl>
                </div>
                </ItemTemplate></asp:Repeater>
                <asp:Repeater ID="data_gift" runat="server"><ItemTemplate>
                        <div class="cart-lrbox">
                            <dl>
                                <dd class="col_1">
                                    <div class="c-pic float-l"><img src="<%#Eval("img_url")%>" width="800" height="800" alt="<%#Eval("title")%>" /></div>
                                </dd>
                                <dd class="col_21">
                                    <div class="pt-box  float-l">
                                        <div class="cart-pt"><strong><%#Eval("article_list")%></strong>
                                        </div>
                                        <div class="cart-pt"><%#Eval("title")%></div>
                                    </div>
                                </dd>
                                <dd class="col_31">
                                    <div class="cart-select">&nbsp;</div>
                                </dd>
                                <dd class="col_41">&nbsp;</dd>
                                <dd class="col_51">
                                    <div class="number-box"><%#Eval("ocompany")%></div>
                                </dd>
                                <dd class="col_61">
                                    <div class="price-box1">&nbsp;</div>
                                </dd>
                          
                            </dl>
                        </div>
                       </ItemTemplate></asp:Repeater>
                <div class="clear">
                </div>
            </div><!--这部分请程序套数据-->
            <div class="cart-tjbox">
        <div class="cart-tjboxl">
          <h1><strong>符合活動</strong></h1>
          <p>
            <label><%=model.zhe_else%></label>
            
          </p>
        </div>
        <div class="cart-tjboxr">
          <dl>
            <dd>合計</dd>
            <dd class="priceh">NT$<%=model.real_amount.ToString("0.")%></dd>
          </dl>
          <dl>
            <dd>紅利點數兌商品</dd>
            <dd class="priceh"><%=model.point%>點</dd>
          </dl>
          <dl>
            <dd>折扣</dd>
            <dd class="price">$<%=model.zhe%></dd>
          </dl>
          <dl>
            <dd>運費（<%=getpeisong(getuseradd(model.user_add, 5))%>）</dd>
            <dd class="priceh">NT$<%=model.express_fee.ToString("0.")%></dd>
          </dl>
        </div>
      </div>
      <div class="cart-tjbox">
        <div class="cart-tjboxr">
          <dl>
            <dd>紅利折扣</dd>
            <dd class="price">$<%=model.tuid%></dd>
          </dl>
          <dl>
            <dd>優惠券</dd>
            <dd class="price">$<%=model.payment_fee.ToString("0.")%></dd>
          </dl>
        </div>
      </div>
      <div class="cart-tjbox">
        <div class="cart-tjboxr">
          <dl>
            <dd>總金額（含運費）</dd>
            <dd class="priceh">NT$<%=model.order_amount.ToString("0.")%></dd>
          </dl>
          <dl>
            <dd>本次消費共折抵紅利</dd>
            <dd class="priceh"><%=model.company+model.point%>點</dd>
          </dl>
          <dl>
            <dd>本次消費共得紅利</dd>
            <dd class="price"><%=model.num%>點</dd>
          </dl>
        </div>
      </div>
     
      <!--这部分请程序套数据-->
            <div class="clear">
            </div>
        </div>
    </div>
    <public:foot ID="foot" runat="server" />
    <script type="text/javascript" src="/js/jquery.spinner.js"></script>
    <script type="text/javascript">
        $('.spinnerExample').spinner({});
    </script>
</body>
</html>
