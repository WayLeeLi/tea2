<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="order" %>
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
                    <span class="float-l wap-none">依日期查詢</span><input name="begin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" type="text" class="float-l">
                    <span class="float-l">~</span>
                    <input type="text" class="float-l" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" name="end"><input type="submit" value="查詢" class="float-l">
                    <span class="float-l"><a href="order.aspx?day=1">顯示一年訂單</a></span>
                    <span class="float-l"><a href="oldorder.aspx">查詢歷史訂單</a></span>
                    </div>
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
                        <dd class="coln-7">
                            發票號碼</dd>
                    </dl>
                </div>
                <div class="ordern-wrap">
                    <asp:Repeater ID="data_list" runat="server"><ItemTemplate>
                    <dl>
                        <dd class="coln-1">
                            <%#Eval("add_time","{0:yyyy-MM-dd}")%></dd>
                        <dd class="coln-2">
                            <a href="ordershow.aspx?id=<%#Eval("id")%>"><%#Eval("order_no")%></a></dd>
                        <dd class="coln-3">
                            <%#GetOrderStatus(int.Parse(Eval("id").ToString()))%></dd>
                        <dd class="coln-4">
                            <div class="wuliu"><%#Eval("express_no").ToString()%><br />
                                <%#new Tea.BLL.user_address().gettitle(Eval("express_no").ToString(), Eval("express_id").ToString())%>
                            </div>
                        </dd>
                        <dd class="coln-5">
                            <div class="wuliu">
                                <span><%#new Tea.BLL.payment().GetTitle(Tea.Common.Utils.StrToInt(Eval("payment_id").ToString(),0))%></span> <span><%#Eval("payment_status").ToString()=="2"?"已經付款":""%><a href="pay.aspx?id=<%#Eval("id")%>" <%#Eval("payment_status").ToString()=="2"?" style=\"display:none;\"":""%>>去付款</a></span>

                            </div>
                        </dd>
                        <dd class="coln-6 red">
                            NT$ <%#Eval("order_amount","{0:0.}")%></dd>
                        <dd class="coln-7">
                            <%#Eval("trade_no")%></dd>
                    </dl>
                    </ItemTemplate></asp:Repeater>
                </div>
                 <%if(show==0){ %>
                <div class="ifnone">暫無訂單</div>
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
