<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newshow.aspx.cs" Inherits="newshow" %>
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
            <div class="news-detail">
                <div class="news-title"><%=model.title%></div>
                <div class="news-dtime"><%=model.add_time.ToString("yyyy-MM-dd")%></div>
                 <%=model.content%>
            </div>
        </div>
    </div>
    <public:foot ID="foot" runat="server" />
</body>
</html>
