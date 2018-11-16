<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quan.aspx.cs" Inherits="users_quan" %>
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
                    <div class="zjq-tabbox">
                        <div class="zjq-tab">
                            <dl>
                                <dd class="zjq-col1">
                                    優惠券名稱</dd>
                                <dd class="zjq-col2">
                                    折價金額</dd>
                                <dd class="zjq-col3">
                                    序號</dd>
                                <dd class="zjq-col4">
                                    有效期限</dd>
                                <dd class="zjq-col5">
                                    適用商品</dd>
                            </dl>
                        </div>
                        <div class="zjq-tab-wra">
                            <asp:Repeater ID="data_list" runat="server"><ItemTemplate>
                            <dl>
                                <dd class="zjq-col1">
                                    <%#Eval("quan_title")%></dd>
                                <dd class="zjq-col2">
                                    <%#Eval("quan_num","{0:0.}")%>元</dd>
                                <dd class="zjq-col3">
                                    <%#Eval("quan_code")%></dd>
                                <dd class="zjq-col4">
                                    <%#Eval("quan_begin_date", "{0:yyyy-MM-dd}")%>~<%#Eval("quan_end_date","{0:yyyy-MM-dd}")%></dd>
                                <dd class="zjq-col5">
                                    <span class="zjp-line"><%#gettitle(Eval("quan_des").ToString())%></span></dd>
                            </dl>
                            </ItemTemplate></asp:Repeater>
                        </div>
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