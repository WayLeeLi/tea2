<%@ Page Language="C#" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" %>
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
    <div class="width-sys xiangguan">
        <div class="member-left">
            <div class="wap-navbg">
            </div>
            <div class="member-mc">
                相關訊息
            </div>
            <div class="member-nav">
                <div class="member-navs">
                    <ul>
                        <asp:Repeater ID="data_news" runat="server"><ItemTemplate>
                        <li><a href="/news.aspx?tid=<%#Eval("basic_value")%>"><%#Eval("basic_label")%></a></li>
                        </ItemTemplate></asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
        <div class="member-right news-box">
            <div class="sub-search">
                <div class="sub-search-sx">
                    <a href="news.aspx?sort=1&tid=<%=tid%>">時間新到舊</a></div>
                <div class="sub-search-sx">
                    <a href="news.aspx?sort=2&tid=<%=tid%>">時間舊到新</a></div>
            </div>
            <asp:Repeater ID="data_list" runat="server"><ItemTemplate>
            <div class="news-list">
                <div class="news-pic">
                    <a href="newshow.aspx?id=<%#Eval("id")%>"><img src="<%#Eval("img_url")%>" alt="<%#Eval("title")%>" /></a></div>
                <div class="news-wz">
                    <h1><%#Eval("title")%></h1>
                    <span class="news-time"><%#Eval("add_time","{0:yyyy-MM-dd}")%></span>
                    <div class="news-jj"><%#Eval("zhaiyao")%></div>
                    <div class="news-more"><a href="newshow.aspx?id=<%#Eval("id")%>">更多</a></div>
                </div>
            </div>
            </ItemTemplate></asp:Repeater>
            <div class="page-c" id="PageContent" runat="server"></div>
        </div>
    </div>
    <public:foot ID="foot" runat="server" />
</body>
</html>
