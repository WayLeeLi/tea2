<%@ Page Language="C#" AutoEventWireup="true" CodeFile="oldordershow.aspx.cs" Inherits="ordershow" %>
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
    <script type="text/javascript">
        $(function () {
            $(".openmx").click(function () {
                $(this).parent().find(".order-mxbox").slideDown("slow");
            })
            $(".closemx").click(function () {
                $(this).parent().slideUp("slow");
            })
        })
    </script>
</head>
<body>
    <public:hand ID="hand" runat="server" />
    <div class="width-sys member-box">
        <public:left ID="left" runat="server" />
        <div class="member-right">
            <div class="right-dk">
                <div class=" cart-bg">
                    <div class="order-box">
                         <asp:Repeater ID="data_list" runat="server"><ItemTemplate>
                        <div class="col-m5 float-l">
                            <div class="order-boxw">
                                <div class="order-box-tit">
                                    購買人資訊</div>
                                <div class="order-box-table">
                                    <table width="100%" border="0" cellspacing="0">
                                        <tbody>
                                            <tr>
                                                <td width="120">
                                                    訂購人姓名
                                                </td>
                                                <td>
                                                    <%#Eval("Buyer")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120">
                                                    訂購人地址
                                                </td>
                                                <td>
                                               <%#Eval("BAddr1")%>     <%#Eval("BPostCode")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120">
                                                    連絡電話
                                                </td>
                                                <td>
                                                  <%#Eval("BTel")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120">
                                                    E-mail
                                                </td>
                                                <td>
                                                   <%#Eval("BEmail")%>
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
                                                    <%#Eval("Accepter")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120">
                                                    收件人地址
                                                </td>
                                                <td>
                                                    <%#Eval("AAddr1")%> <%#Eval("APostCode")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120">
                                                    連絡電話
                                                </td>
                                                <td>
                                                    <%#Eval("ATel")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120">
                                                    E-mail
                                                </td>
                                                <td>
                                                   <%#Eval("AEmail")%>
                                                </td>
                                            </tr>
                                           
                                            <tr>
                                                <td>
                                                    備註
                                                </td>
                                                <td>
                                                    &nbsp;<%#Eval("Remark")%>
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
                                                    <%#Eval("PayType")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    付款時間
                                                </td>
                                                <td>
                                                   <%#Eval("PayDate")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120">
                                                    運送方式
                                                </td>
                                                <td>
                                                   <%-- <%#Eval("OrderNumber")%>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="120">
                                                    發票資訊
                                                </td>
                                                <td>
                                                   <%#Eval("Invoice")%>
                                                </td>
                                            </tr>
                                           
                                            <tr>
                                                <td width="120">
                                                    紅利點數
                                                </td>
                                                <td>
                                                   <%#Eval("AddBonus")%> 點
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        </ItemTemplate></asp:Repeater>
                    </div>
                </div>
                <div class=" cart-bg">
                    <div class="cart-box">
                        <asp:Repeater ID="data_cart" runat="server"><ItemTemplate>
                        <div class="cart-lrbox">
                            <dl>
                              
                                <dd class="col_21">
                                    <div class="pt-box  float-l">
                                   
                                        <div class="cart-pt">
                                          <%#Eval("ProductName")%></div>
                                    </div>
                                </dd>
                              
                                <dd class="col_41">
                                   
                                        <span class="price">NT$<%#Eval("Pay", "{0:0.}")%></span><br>
                                      
                                </dd>
                                <dd class="col_51">
                                    <div class="number-box">
                                        <span class="wap-show">數量：</span><%#Eval("Num")%>
                                    </div>
                                </dd>
                                <dd class="col_61">
                                         <div class="price-box1"> <span class="wap-show" >小計：</span><span class="price">NT$<%#Tea.Common.Utils.StrToInt(Eval("Num").ToString(), 0) * Tea.Common.Utils.StrToInt(Eval("Pay", "{0:0.}").ToString(), 0)%></span></div>
                                  
                        
                                </dd>
                            </dl>
                        </div>
                        </ItemTemplate></asp:Repeater>
                         
                    </div>
                    <asp:Repeater ID="data_list1" runat="server"><ItemTemplate>
                    <div class="cart-tjbox">
                        
                        <div class="cart-tjboxr">
                            <dl>
                                <dd>合計</dd>
                                <dd class="priceh">
                                    NT$<%#Eval("Pay")%></dd>
                            </dl>
                          
                            <dl>
                                <dd>
                                    運費</dd>
                                <dd class="priceh">
                                    NT$<%#Eval("TransferFee")%></dd>
                            </dl>
                        </div>
                    </div>
                    <div class="cart-tjbox">
                        <div class="cart-tjboxr">
                            <dl>
                                <dd>總金額（含運費）</dd>
                                <dd class="priceh">
                                    NT$<%#Eval("Pay")%></dd>
                            </dl>
                            <dl>
                                <dd>本次消費共折抵紅利</dd>
                                <dd class="priceh">
                                    -<%#Eval("PayBonus")%>點</dd>
                            </dl>
                            <dl>
                                <dd>
                                    本次消費共得紅利</dd>
                                <dd class="price">
                                   <%#Eval("AddBonus")%>點</dd>
                            </dl>
                        </div>
                    </div>
                    </ItemTemplate></asp:Repeater>
                    <div class="clear">
                    </div>
                </div>
                <div class="clear">
                </div>
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
