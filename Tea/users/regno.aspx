<%@ Page Language="C#" AutoEventWireup="true" CodeFile="regno.aspx.cs" Inherits="reg" %>
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
</head>
<body>
    <public:hand ID="hand" runat="server" />
    <div class="regest width-sys">
        <div class="regest-success">
            <h1>
                會員帳號尚未正式啟用</h1>
            <h2>
                已發送帳號啟用信至您的電子信箱 <span class="red"><%=_users.email%></span> ，帳號於啟用後才可使用，請至信箱確認。</h2>
            <h3>
                <a href="regno.aspx?act=send">重新發送帳號啟用信</a></h3>
        </div>
    </div>
    <div class="tc-box-bg">
        <div class="tc-box">
            <div class="tc-wrap">
                <h1>隱私條款</h1>
                <%=config.webcrod%>
            </div>
            <div class="tc-close">
                <a href="javascript:closetc();">我已閱讀並同意</a></div>
        </div>
    </div>
    <public:foot ID="foot" runat="server" />
    <script type="text/javascript" src="/js/jquery.spinner.js"></script>
    <script type="text/javascript">
        $('.spinnerExample').spinner({});
    </script>
</body>
</html>