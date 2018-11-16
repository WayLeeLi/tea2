<%@ Page Language="C#" AutoEventWireup="true" CodeFile="help.aspx.cs" Inherits="help" %>
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
            $(".shouhe-btn").click(function () {
                if ($(this).parent().find(".shouhe-lr").is(":hidden")) {
                    $(this).parent().find(".shouhe-lr").slideDown("slow");
                }
                else {
                    $(this).parent().find(".shouhe-lr").slideUp("slow");
                }
            })
        })
    </script>
</head>
<body>
    <public:hand ID="hand" runat="server" />
    <div class="width-sys xiangguan">
        <div class="member-left">
            <div class="wap-navbg">
            </div>
            <div class="member-mc">
                常見問題
            </div>
            <div class="member-nav">
                <div class="member-navs">
                    <ul>
                        <asp:Repeater ID="data_type" runat="server"><ItemTemplate>
                        <li><a href="help.aspx?tid=<%#Eval("basic_value")%>"><%#Eval("basic_label")%></a></li>
                        </ItemTemplate></asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
        <div class="member-right news-box">
            <div class="help-box">
                <asp:Repeater ID="data_list" runat="server"><ItemTemplate>
                <div class="shouhe">
                    <div class="shouhe-btn"><%#Eval("title")%></div>
                    <div class="shouhe-lr"><%#Eval("content")%></div>
                </div>
               </ItemTemplate></asp:Repeater>
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
