<%@ Page Language="C#" AutoEventWireup="true" CodeFile="regok.aspx.cs" Inherits="reg" %>
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
                會員帳號正式啟用</h1>
            <h2>
                您的帳號已啟用成功，請重新登入。</h2>
            <div>
                <input name="input2" type="submit" value="登入" class="success-btn" onclick="javascript:location.href='login.aspx'" /></div>
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
