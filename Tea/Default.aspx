<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title><%=title%></title>
    <meta name="Keywords" content="<%=keyword%>" />
    <meta name="Description" content="<%=describe%>" />
    <link rel="stylesheet" type="text/css" href="/css/slider-pro.min.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/examples.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/css.css" media="screen">
    <script type="text/javascript" src="/js/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="/js/jquery.sliderPro.min.js"></script>
    <script src="/js/app.js"></script>
    <script type="text/javascript">
        $(document).ready(function ($) {
            $('#index-slider').sliderPro({
                width: 1680,
                height: 680,
                arrows: false,
                buttons: true,
                waitForLayers: true,
                thumbnailWidth: 200,
                thumbnailHeight: 100,
                thumbnailPointer: true,
                autoplay: true,
                autoScaleLayers: false,
                breakpoints: {
                    500: {
                        thumbnailWidth: 120,
                        thumbnailHeight: 50
                    }
                }
            });
        });
    </script>
</head>
<body>
    <public:hand ID="hand" runat="server" />
    <div id="index-slider" class="slider-pro">
        <div class="sp-slides">
            <asp:Repeater ID="data_banner" runat="server"><ItemTemplate>
            <div class="sp-slide">
                <a href="<%#Eval("link_url")%>"><img class="sp-image" src="css/images/blank.gif" data-src="<%#Eval("img_url")%>" data-retina="<%#Eval("img_url")%>" /></a>
            </div>
           </ItemTemplate></asp:Repeater>
        </div>
    </div>
    <%if(showte>0){ %>
    <div class="width-sys">
        <div class="index-title-box">
            特惠專區<em>Special zone</em></div>
        <div class="list-box">
            <asp:Repeater ID="data_one" runat="server"><ItemTemplate>
            <div class="list-one">
                <a href="/shop/show.aspx?id=<%#Eval("id")%>">
                    <img src="<%#Eval("img_url")%>" alt="<%#Eval("title")%>" /></a>
                <div class="list-title">
                    <a href="/shop/show.aspx?id=<%#Eval("id")%>"><%#Eval("title")%></a></div>
                <div class="list-ps">
                    <span class="sale"><%#get_sales(Eval("id").ToString())%></span> <span class="price">NT$<%#getprice(Eval("id").ToString())%></span>
                </div>
            </div>
            </ItemTemplate></asp:Repeater>
            <asp:Repeater ID="data_one1" runat="server"><ItemTemplate>
            <div class="list-one wap-show">
                <a href="/shop/show.aspx?id=<%#Eval("id")%>">
                    <img src="<%#Eval("img_url")%>" alt="<%#Eval("title")%>" /></a>
                <div class="list-title">
                    <a href="/shop/show.aspx?id=<%#Eval("id")%>"><%#Eval("title")%></a></div>
                <div class="list-ps">
                    <span class="sale"><%#get_sales(Eval("id").ToString())%></span> <span class="price">NT$<%#getprice(Eval("id").ToString())%></span>
                </div>
            </div>
            </ItemTemplate></asp:Repeater>
            <div class="list-two">
                <ul>
                    <asp:Repeater ID="data_two" runat="server"><ItemTemplate>
                    <li><a href="/shop/show.aspx?id=<%#Eval("id")%>">
                        <img src="<%#Eval("img_url")%>" alt="<%#Eval("title")%>" /></a>
                        <div class="list-title">
                            <a href="/shop/show.aspx?id=<%#Eval("id")%>"><%#Eval("title")%></a></div>
                        <div class="list-ps">
                            <span class="sale"><%#get_sales(Eval("id").ToString())%></span> <span class="price">NT$<%#getprice(Eval("id").ToString())%></span>
                        </div>
                    </li>
                    </ItemTemplate></asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <%} %>
    <%if(showtui>0){ %>
    <div class="width-sys">
        <div class="index-title-box">
            推薦專區<em>Recommended goods</em></div>
        <div class="list-box">
            <div class="list-four">
                <ul>
                    <asp:Repeater ID="data_tui" runat="server"><ItemTemplate>
                    <li><a href="/shop/show.aspx?id=<%#Eval("id")%>">
                        <img src="<%#Eval("img_url")%>" alt="<%#Eval("title")%>" /></a>
                        <div class="list-title">
                            <a href="/shop/show.aspx?id=<%#Eval("id")%>"><%#Eval("title")%></a></div>
                        <div class="list-ps">
                            <span class="sale"><%#get_sales(Eval("id").ToString())%></span> <span class="price">NT$<%#getprice(Eval("id").ToString())%></span>
                        </div>
                    </li>
                   </ItemTemplate></asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <%} %>
    <public:foot ID="foot" runat="server" />
</body>
</html>
