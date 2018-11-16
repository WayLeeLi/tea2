<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pint.aspx.cs" Inherits="goods" %>
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
                紅利點數
            </div>
            <div class="right-dk">
                <div class="">
                    <div class="hl-msbox">
                        <dl>
                            <dd>目前可使用紅利點數</dd>
                            <dt><strong><%=userModel.point%></strong></dt>
                        </dl>
                    </div>
                    <div class="hl-tabbox">
                        <div class="hl-tab">
                            <dl>
                                <dd class="hl-col1">
                                    訂單日期</dd>
                                <dd class="hl-col2">
                                    異動日期</dd>
                                <dd class="hl-col3">
                                    訂單編號</dd>
                                <dd class="hl-col4">
                                    訂單金額</dd>
                                <dd class="hl-col5">
                                    紅利點數</dd>
                            </dl>
                        </div>
                        <div class="hl-tab-wra">
                            <asp:Repeater ID="data_list" runat="server"><ItemTemplate>
                            <dl>
                                <dd class="hl-col1">
                                    <%#Eval("add_time","{0:yyyy-MM-dd}")%></dd>
                                <dd class="hl-col2">
                                    <%#Eval("add_time", "{0:yyyy-MM-dd}")%></dd>
                                <dd class="hl-col3">
                                    &nbsp;<a href="ordershow.aspx?id=<%#Eval("order_id")%>"><%#Eval("order_no")%></a></dd>
                                <dd class="hl-col4 red">
                                    &nbsp;<%#getshow(Eval("order_amount", "{0:0.}").ToString())%> <%#Eval("order_amount","{0:0.}")%></dd>
                                <dd class="hl-col5 <%#Tea.Common.Utils.StrToInt(Eval("value").ToString(), 0) < 0 ? "red" : "green"%>">
                                   &nbsp; <%#Tea.Common.Utils.StrToInt(Eval("value").ToString(), 0) > 0 ? "+" : ""%><%#Eval("value")%></dd>
                            </dl>
                            </ItemTemplate></asp:Repeater>
                        </div>
                         <%if(show==0){ %>
                <div class="ifnone">暫無紅利記錄</div>
                <%} %>
                    </div>
                   
                </div>
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
