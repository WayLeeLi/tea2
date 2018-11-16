<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="index" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title><%=title%></title>
    <meta name="Keywords" content="<%=keyword%>" />
    <meta name="Description" content="<%=describe%>" />
    <link rel="stylesheet" type="text/css" href="/css/slider-pro.min.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/examples.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/css.css" media="screen">
    <script type="text/javascript" src="/js/jquery-1.11.0.min.js"></script>
    <script src="/js/app.js"></script>
</head>
<body>
    <public:hand ID="hand" runat="server" />
    <div class="width-sys location">
        <a href="/">首頁</a> &gt; 紅利兌換專區</div>
    <div class="width-sys">
        <div class="sub-left">
            <div class="pro-lb wap-none">
                <a href="/shop/index.aspx">商品類別</a></div>
            <div class="nav-down"><asp:Repeater ID="data_type" runat="server"><ItemTemplate><a href="index.aspx?tid=<%#Eval("id")%>"><%#Eval("title")%></a></ItemTemplate></asp:Repeater><%if (_users!=null &&_users.group_id == 2)
                                                                                                                                                                                                 { %><a href="/shop/users.aspx">VIP專區</a><%} %><a href="/shop/list.aspx">紅利兌換專區</a></div>
        </div>
        <div class="sub-right">
            <div class="sub-search">
                <div class="sub-search-sx">
                    <a href="list.aspx?tid=<%=tid%>&key=<%=key%>&sort=1">最新上架</a></div>
                <div class="sub-search-sx">
                    <a href="list.aspx?tid=<%=tid%>&key=<%=key%>&sort=2">熱門排行</a></div>
                <div class="sub-search-sx">
                    <a href="list.aspx?tid=<%=tid%>&key=<%=key%>&sort=3">價格由低至高</a></div>
                <div class="sub-search-sx">
                    <a href="list.aspx?tid=<%=tid%>&key=<%=key%>&sort=4">價格由高至低</a></div>
            </div>
            <div class="list-four-sub">
                <ul>
                    <asp:Repeater ID="data_list" runat="server"><ItemTemplate>
                    <li><a href="/shop/detail.aspx?id=<%#Eval("id")%>">
                        <img src="<%#Eval("img_url")%>" alt="<%#Eval("title")%>" /></a>
                        <div class="list-title">
                            <a href="/shop/detail.aspx?id=<%#Eval("id")%>"><%#Eval("title")%></a></div>
                        <div class="list-ps">
                            <span class="sale"><%#get_sales(Eval("id").ToString())%></span> <span class="price"><%#Eval("point")%>點</span>
                        </div>
                    </li>
                    </ItemTemplate></asp:Repeater>
                </ul>
            </div>
            <div class="page-c" id="PageContent" runat="server"></div>
        </div>
    </div>
    <public:foot ID="foot" runat="server" />
</body>
</html>
