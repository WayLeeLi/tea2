<%@ Page Language="C#" AutoEventWireup="true" CodeFile="oldorder.aspx.cs" Inherits="order" %>
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
    <script type="text/javascript" charset="utf-8" src="/scripts/datepicker/WdatePicker.js"></script>
    <script src="/js/app.js"></script>
</head>
<body>
    <public:hand ID="hand" runat="server" />
    <div class="width-sys member-box">
        <public:left ID="left" runat="server" />
        <div class="member-right">
            <div class="right-dk">
                <div class="ordern-search">
                    <form action="order.aspx" method="get">
                   <%-- <span class="float-l wap-none">依日期查詢</span><input name="begin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" type="text" class="float-l">
                    <span class="float-l">~</span>
                    <input type="text" class="float-l" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" name="end"><input type="submit" value="查詢" class="float-l">--%>
                    <span class="float-l"><a href="order.aspx">顯示新訂單</a></span></div>
                    </form>
                <div class="ordern-tab">
                    <dl>
                        <dd class="coln-1">
                            購買時間</dd>
                        <dd class="coln-2">
                            訂單編號</dd>
                        <dd class="coln-3">
                            訂單狀態</dd>
                        <dd class="coln-4">
                            物流追蹤</dd>
                        <dd class="coln-5">
                            付款狀態</dd>
                        <dd class="coln-6">
                            訂單金額</dd>
                       
                    </dl>
                </div>
                <div class="ordern-wrap">
                    <asp:Repeater ID="data_list" runat="server"><ItemTemplate>
                    <dl>
                        <dd class="coln-1">
                            <%#Eval("Date", "{0:yyyy-MM-dd}")%></dd>
                        <dd class="coln-2">
                            <a href="oldordershow.aspx?id=<%#Eval("OrderNumber")%>"><%#Eval("OrderNumber")%></a></dd>
                        <dd class="coln-3">
                            訂單完成</dd>
                        <dd class="coln-4">
                             配送完成
                        </dd>
                        <dd class="coln-5">
                            <div class="wuliu">&nbsp;
                                <span><%#Eval("PayType")%></span> <span><%#Eval("PayResult").ToString() == "2" ? "已經付款" : "未付款"%></span>
                            </div>
                        </dd>
                        <dd class="coln-6 red">
                            NT$ <%#Eval("Pay", "{0:0.}")%></dd>
                         
                    </dl>
                    </ItemTemplate></asp:Repeater>
                </div>
                 <%if(show==0){ %>
                <div class="ifnone">暫無訂單</div>
                <%} %>
                <div class="clear"></div>
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
