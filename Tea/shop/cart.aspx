<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="cart" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width">
    <title><%=title%></title>
    <meta name="Keywords" content="<%=keyword%>" />
    <meta name="Description" content="<%=describe%>" />
    <link href="/jQueryAssets/jquery.ui.core.min.css" rel="stylesheet" type="text/css">
    <link href="/jQueryAssets/jquery.ui.theme.min.css" rel="stylesheet" type="text/css">
    <link href="/jQueryAssets/jquery.ui.tabs.min.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" type="text/css" href="/css/css.css" media="screen">
    <link href="/owl-carousel/owl.carousel.css" rel="stylesheet">
    <link href="/owl-carousel/owl.theme.css" rel="stylesheet">
    <script type="text/javascript" src="/js/jquery-1.11.0.min.js"></script>
    <script src="/jQueryAssets/jquery.ui-1.10.4.tabs.min.js" type="text/javascript"></script>
	<script src="/js/app.js"></script>
</head>
<body>
    <public:hand ID="hand" runat="server" />
    <div class="width-sys location">
        <div class="cart-loc wap-none">
            <img src="/images/cart1.png" alt="" /></div>
        <div class="cart-loc wap-show">
            <img src="/images/cart1-1.png" alt="" /></div>
    </div>
    <div class="width-sys">
        <div class=" cart-bg">
             <%if (show>0){ %>
            <div class="">
            <style>
            .cart-nav{border-bottom:1px solid #ccc;}
			.cart-nav:after{content:" "; clear:both; display:block;}
			.cart-nav a{color: #666; line-height:25px; display:block; text-decoration: none;padding: .5em 2em;}
			.cart-nav li{float:left; list-style:none; padding:0; margin:0;}
			.cart-nav ul{ padding:0; margin:0;}
			.cart-nav li.cart-active a{color: #C02727; line-height:23px; border-bottom:2px solid #C02727; text-decoration: none;padding: .5em 2em;}
            </style>
            <div class="cart-nav">
                <ul><%if (cartnum > 0)
                      { %>
                    <li  <%if(cs==1){ %>class="cart-active"<%} %>><a href="cart.aspx?cs=1" onclick="javascript:$('#card').attr('href','order.aspx?cart=1');">一般商品</a></li>
                    <%} if (cartnum1 > 0)
                      { %>
                    <li <%if(cs==2){ %>class="cart-active"<%} %>><a href="cart.aspx?cs=2" onclick="javascript:$('#card').attr('href','order.aspx?cart=2');">特別活動商品</a></li>
                    <%}if(cartnum2>0){ %>
                    <li <%if(cs==3){ %>class="cart-active"<%} %>><a href="cart.aspx?cs=3" onclick="javascript:$('#card').attr('href','vorder.aspx?cart=3');">VIP專區</a></li>
                    <%} %>
                </ul>
                </div>
                <%if(cartnum>0 && cs==1){ %>
                <div id="tabs-1">
                    <div class="cart-box">
                        <asp:Repeater ID="data_cart" runat="server"><ItemTemplate>
                        <div class="cart-lrbox">
                            <dl>
                                <dd class="col_1">
                                    <div class="c-pic float-l">
                                        <a href="<%#getpoint(Eval("by").ToString(),"show")%>.aspx?id=<%#Eval("id")%>">
                                            <img src="<%#Eval("img_url")%>" width="800" height="800" alt="" /></a></div>
                                </dd>
                                <dd class="col_2">
                                    <div class="pt-box  float-l">
                                        <div class="cart-pt">
                                            <a href="<%#getpoint(Eval("by").ToString(),"show")%>.aspx?id=<%#Eval("id")%>"><strong><%#Eval("sub_title")%></strong></a>
                                        </div>
                                        <div class="cart-pt">
                                            <a href="<%#getpoint(Eval("by").ToString(),"show")%>.aspx?id=<%#Eval("id")%>"><%#Eval("title")%></a>
                                        </div>
                                        <%#Eval("sales_name") == "no" ? "此商品不配送至海外" : ""%>
                                    </div>
                                </dd>
                                <dd class="col_3">
                                    <div class="cart-select">
                                        <span class="wap-show float-l">規格：</span>
                                        <select onchange="javascript:window.location.href=this.value">
                                            <%#getcolor(Eval("id").ToString(), Eval("goodsid").ToString(),Eval("quantity").ToString(),cs)%>
                                        </select>
                                    </div>
                                </dd>
                                <dd class="col_4">
                                    <div class="price-box" <%#getpoint(Eval("by").ToString(),1)%>>
                                        <span class="price">NT$<%#Eval("user_price", "{0:0.}")%></span><br>
                                        <span class="yprice">NT$<%#Eval("price", "{0:0.}")%></span>
                                    </div>
                                    <div class="price-box" <%#getpoint(Eval("by").ToString(),2)%>>
                                        <span class="price"><%#Eval("point")%>點</span>
                                    </div>
                                </dd>
                                <dd class="col_5">
                                    <div class="number-box">
                                         <div class="spinner"><a class="decrease" href="cart.aspx?cs=<%=cs%>&key=<%#Eval("key")%>&num=<%#Eval("quantity")%>&act=del">-</a><input type="text" onblur="javascript:location.href='cart.aspx?cs=<%=cs%>&key=<%#Eval("key")%>&act=update&num='+this.value"  value="<%#Eval("quantity")%>"  class="spinnerExample value" maxlength="4"><a class="increase" href="cart.aspx?cs=<%=cs%>&key=<%#Eval("key")%>&num=<%#Eval("quantity")%>&act=add">+</a></div>
                                    </div>
                                </dd>
                                <dd class="col_6">
                                    <div class="price-box1" <%#getpoint(Eval("by").ToString(),1)%>> <span class="wap-show" >小計：</span><span class="price">NT$<%#Tea.Common.Utils.StrToInt(Eval("quantity").ToString(), 0) * Tea.Common.Utils.StrToInt(Eval("user_price", "{0:0.}").ToString(), 0)%></span></div>
                                    <div class="price-box1" <%#getpoint(Eval("by").ToString(),2)%>> <span class="wap-show" <%#getpoint(Eval("by").ToString(),2)%>>小計：</span><span class="price"><%#Tea.Common.Utils.StrToInt(Eval("quantity").ToString(), 0) * Tea.Common.Utils.StrToInt(Eval("point", "{0:0.}").ToString(), 0)%></span>點</div>
                                </dd>
                                <dd class="col_7">
                                    <div class="site-box">
                                        <a href="cart.aspx?cs=<%=cs%>&del=<%#Eval("key")%>" onclick="javascript:return confirm('確認刪除嗎')"><span class="wap-show"><img src="/images/c-cle.png" width="30" height="30" alt="" /></span><span class="wap-none">刪除</span></a></div>
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
                                <dd class="col_2">
                                    <div class="pt-box  float-l">
                                        <div class="cart-pt"><strong><%#Eval("article_list")%></strong>
                                        </div>
                                        <div class="cart-pt"><%#Eval("title")%></div>
                                    </div>
                                </dd>
                                <dd class="col_3">
                                    <div class="cart-select">&nbsp;</div>
                                </dd>
                                <dd class="col_4">&nbsp;</dd>
                                <dd class="col_5"> &nbsp;
                                   <%-- <div class="number-box"><%=giftnum%></div>--%>
                                </dd>
                                <dd class="col_6">
                                    <div class="price-box1">&nbsp;</div>
                                </dd>
                                <dd class="col_7">&nbsp;</dd>
                            </dl>
                        </div>
                       </ItemTemplate></asp:Repeater>
                       
                    </div>
                </div>
                <%} if (cartnum1 > 0 && cs == 2){ %>
                <div id="tabs-2">
                    <div class="cart-box">
                        <asp:Repeater ID="data_tejia" runat="server"><ItemTemplate>
                        <div class="cart-lrbox">
                            <dl>
                                <dd class="col_1">
                                    <div class="c-pic float-l">
                                        <a href="show.aspx?id=<%#Eval("id")%>"><img src="<%#Eval("img_url")%>" width="800" height="800" alt="" /></a></div>
                                </dd>
                                <dd class="col_2">
                                    <div class="pt-box  float-l">
                                        <div class="cart-pt"> 
                                            <a href="show.aspx?id=<%#Eval("id")%>"><strong><%#Eval("sub_title")%></strong></a>
                                        </div>
                                        <div class="cart-pt">
                                            <a href="show.aspx?id=<%#Eval("id")%>"><%#Eval("title")%></a>
                                        </div>
                                       <%#Eval("sales_name") == "no" ? "此商品不配送至海外" : ""%>
                                    </div>
                                </dd>
                                <dd class="col_3">
                                    <div class="cart-select">
                                        <span class="wap-show float-l">規格：</span>
                                        <select onchange="javascript:window.location.href=this.value">
                                             <%#getcolor(Eval("id").ToString(), Eval("goodsid").ToString(),Eval("quantity").ToString(),cs)%>
                                        </select>
                                    </div>
                                </dd>
                                <dd class="col_4">
                                    <div class="price-box">
                                        <span class="price">NT$<%#Eval("user_price", "{0:0.}")%></span><br>
                                        <span class="yprice">NT$<%#Eval("price", "{0:0.}")%></span>
                                    </div>
                                </dd>
                                <dd class="col_5">
                                    <div class="number-box">
                                        <span class="wap-show float-l">數量：</span>
                                        <div class="spinner"><a class="decrease" href="cart.aspx?cs=<%=cs%>&key=<%#Eval("key")%>&num=<%#Eval("quantity")%>&act=del">-</a><input type="text" onblur="javascript:location.href='cart.aspx?cs=<%=cs%>&key=<%#Eval("key")%>&act=update&num='+this.value"  value="<%#Eval("quantity")%>"  class="spinnerExample value" maxlength="4"><a class="increase" href="cart.aspx?cs=<%=cs%>&key=<%#Eval("key")%>&num=<%#Eval("quantity")%>&act=add">+</a></div>
                                    </div>
                                </dd>
                                <dd class="col_6">
                                    <div class="price-box1">
                                        <span class="wap-show">小計：</span><span class="price">NT$<%#Tea.Common.Utils.StrToInt(Eval("quantity").ToString(),0) * Tea.Common.Utils.StrToInt(Eval("user_price").ToString(),0)%></span></div>
                                </dd>
                                <dd class="col_7">
                                    <div class="site-box">
                                        <a href="cart.aspx?cs=<%=cs%>&del=<%#Eval("key")%>" onclick="javascript:return confirm('確認刪除嗎')"><span class="wap-show"><img src="/images/c-cle.png" width="30" height="30" alt="" /></span><span class="wap-none">刪除</span></a></div>
                                </dd>
                            </dl>
                        </div>
                        </ItemTemplate></asp:Repeater>
                           <asp:Repeater ID="datagift" runat="server"><ItemTemplate>
                        <div class="cart-lrbox">
                            <dl>
                                <dd class="col_1">
                                    <div class="c-pic float-l"><img src="<%#Eval("img_url")%>" width="800" height="800" alt="<%#Eval("title")%>" /></div>
                                </dd>
                                <dd class="col_2">
                                    <div class="pt-box  float-l">
                                        <div class="cart-pt"><strong><%#Eval("article_list")%></strong>
                                        </div>
                                        <div class="cart-pt"><%#Eval("title")%></div>
                                    </div>
                                </dd>
                                <dd class="col_3">
                                    <div class="cart-select">&nbsp;</div>
                                </dd>
                                <dd class="col_4">&nbsp;</dd>
                                <dd class="col_5"> &nbsp;
                                   <%-- <div class="number-box"><%=giftnum%></div>--%>
                                </dd>
                                <dd class="col_6">
                                    <div class="price-box1">&nbsp;</div>
                                </dd>
                                <dd class="col_7">&nbsp;</dd>
                            </dl>
                        </div>
                       </ItemTemplate></asp:Repeater>
                    </div>
                </div>
                <%} if (cartnum2 > 0 && cs == 3){ %>
                <div id="tabs-3">
                    <div class="cart-box">
                        <asp:Repeater ID="data_vip" runat="server"><ItemTemplate>
                        <div class="cart-lrbox">
                            <dl>
                                <dd class="col_1">
                                    <div class="c-pic float-l">
                                        <a href="show.aspx?id=<%#Eval("id")%>"><img src="<%#Eval("img_url")%>" width="800" height="800" alt="" /></a></div>
                                </dd>
                                <dd class="col_2">
                                    <div class="pt-box  float-l">
                                        <div class="cart-pt">
                                            <a href="show.aspx?id=<%#Eval("id")%>"><strong><%#Eval("sub_title")%></strong></a>
                                        </div>
                                        <div class="cart-pt">
                                            <a href="show.aspx?id=<%#Eval("id")%>"><%#Eval("title")%></a>
                                        </div>
                                        <%#Eval("sales_name") == "no" ? "此商品不配送至海外" : ""%>
                                    </div>
                                </dd>
                                <dd class="col_3">
                                    <div class="cart-select">
                                        <span class="wap-show float-l">規格：</span>
                                        <select onchange="javascript:window.location.href=this.value">
                                             <%#getcolor(Eval("id").ToString(), Eval("goodsid").ToString(),Eval("quantity").ToString(),cs)%>
                                        </select>
                                    </div>
                                </dd>
                                <dd class="col_4">
                                    <div class="price-box">
                                        <span class="price">NT$<%#Eval("user_price", "{0:0.}")%></span><br>
                                        <span class="yprice">NT$<%#Eval("price", "{0:0.}")%></span>
                                    </div>
                                </dd>
                                <dd class="col_5">
                                    <div class="number-box">
                                        <span class="wap-show float-l">數量：</span>
                                        <div class="spinner"><a class="decrease" href="cart.aspx?cs=<%=cs%>&key=<%#Eval("key")%>&num=<%#Eval("quantity")%>&act=del">-</a><input type="text" onblur="javascript:location.href='cart.aspx?cs=<%=cs%>&key=<%#Eval("key")%>&act=update&num='+this.value"  value="<%#Eval("quantity")%>"  class="spinnerExample value" maxlength="4"><a class="increase" href="cart.aspx?cs=<%=cs%>&key=<%#Eval("key")%>&num=<%#Eval("quantity")%>&act=add">+</a></div>
                                    </div>
                                </dd>
                                <dd class="col_6">
                                    <div class="price-box1">
                                        <span class="wap-show">小計：</span><span class="price">NT$<%#Tea.Common.Utils.StrToInt(Eval("quantity").ToString(),0) * Tea.Common.Utils.StrToInt(Eval("user_price").ToString(),0)%></span></div>
                                </dd>
                                <dd class="col_7">
                                    <div class="site-box">
                                        <a href="cart.aspx?cs=<%=cs%>&del=<%#Eval("key")%>" onclick="javascript:return confirm('確認刪除嗎')"><span class="wap-show"><img src="/images/c-cle.png" width="30" height="30" alt="" /></span><span class="wap-none">刪除</span></a></div>
                                </dd>
                            </dl>
                        </div>
                        </ItemTemplate></asp:Repeater>
                    </div>
                </div>
                <%} %>
            </div>
             <div class="cart-box">
                <div class="cart-tjbox">
                    <div class="cart-tjboxl" <%if(cs==3){ %> style="display:none;"<%} %>>
                        <h1><strong>符合活動</strong></h1>
                        <p><label><a><%=cartModel.sales_str%></a></label></p>
                    </div>
                    <div class="cart-tjboxr">
                        <dl>
                            <dd>合計</dd>
                            <dd class="priceh">
                                $<%=cartModel.real_amount.ToString("0.")%></dd>
                        </dl>
                        <dl <%if(cs==3){ %> style="display:none;"<%} %>>
                            <dd>紅利點數兌商品</dd>
                            <dd class="priceh">
                                <%=cartModel.total_point%>點</dd>
                        </dl>
                        <dl <%if(cs==3){ %> style="display:none;"<%} %>>
                            <dd>折扣</dd>
                            <dd class="price">
                                NT$-<%=cartModel.total_moneyback%></dd>
                        </dl>
                    </div>
                </div>
            </div>
            <%}else{ %>
             <div class="order-btn" style="text-align:center;">您的購物車中尚沒有商品</div>
            <%} %>
        </div>
        <div class="order-btn">
            <a href="<%=strurl%>" class="cart-btn">繼續購物</a> <%if (show>0){ %> <a id="card" href="<%if(cs==3){%>v<%} %>order.aspx?cart=<%=cs%>" class="Collection-btn">下一步</a><%} %>
        </div>
    </div>
    <%if(show>0){ %>
    <div class="width-sys detail-tj">
        <div class="index-title-box">
            商品加購<em>ADDITONAL</em></div>
        <div class="list-four-sub">
            <ul>
                <asp:Repeater ID="data_jiajia" runat="server"><ItemTemplate>
                <li><a href="show.aspx?id=<%#Eval("aid")%>"><img src="<%#Eval("img_url")%>" alt="<%#Eval("title")%>" /></a>
                    <div class="list-title">
                        <a href="show.aspx?id=<%#Eval("aid")%>"><%#Eval("title")%></a></div>
                    <div class="list-ps">
                        <span class="jiagou float-r"><a href="cart.aspx?id=<%#Eval("aid")%>_<%#Eval("id")%>_<%=cs%>">加購</a></span> <span class="price">NT$<%#getprice(Eval("aid").ToString())%></span>
                    </div>
                </li>
                </ItemTemplate></asp:Repeater>
            </ul>
        </div>
    </div>
    <%} %>
    <public:foot ID="foot" runat="server" />

    <script type="text/javascript">
        $(function () {
            $("#Tabs1").tabs();
        });
    </script>
</body>
</html>
