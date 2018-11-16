<%@ Page Language="C#" AutoEventWireup="true" CodeFile="goods.aspx.cs" Inherits="goods" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
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
            <div class="member-tit">
                我的最愛
            </div>
            <div class="love-box">
                <asp:Repeater ID="data_list" runat="server"><ItemTemplate>
                <div class="cart-lrbox">
                    <dl>
                        <dd class="col_1">
                            <div class="c-pic float-l"><a href="/shop/<%#Eval("wheresql").ToString() == "point"?"detail":"show"%>.aspx?id=<%#Eval("id")%>"><img src="<%#Eval("img_url")%>" width="800" height="800" alt="<%#Eval("title")%>" /></a></div>
                        </dd>
                        <dd class="col_2">
                            <div class="pt-box  float-l">
                                <div class="cart-pt"><a href="/shop/<%#Eval("wheresql").ToString() == "point"?"detail":"show"%>.aspx?id=<%#Eval("id")%>"><%#Eval("title")%></a></div>
                            </div>
                        </dd>
                        <dd class="col_3">
                            <div class="price-box1" <%#Eval("wheresql").ToString() == "point"?" style=\"display:none;\"":""%>><span class="wap-show">價格：</span><span class="price">NT$<%#Eval("market_price", "{0:0.}")%></span></div>
                            <div class="price-box1" <%#Eval("wheresql").ToString() == "point" ? "" : " style=\"display:none;\""%>><span class="wap-show">點數：</span><span class="price"><%#Eval("point", "{0:0.}")%> 點</span></div>
                        </dd>
                        <dd class="col_4">
                            <a href="goods.aspx?del=<%#Eval("tid")%>" onclick="javascript:return confirm('確定刪除嗎');">刪除</a>
                        </dd>
                    </dl>
                </div>
                </ItemTemplate></asp:Repeater>
                
                <%if(show==0){ %>
                <div class="ifnone">我的最愛中目前沒有商品</div>
                <%} %>
               
                <div class="clear"></div>
                <div class="page-c" id="PageContent" runat="server"></div>
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
