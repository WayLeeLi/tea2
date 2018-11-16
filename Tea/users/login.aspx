<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
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
    <script language="javascript" type="text/javascript">        var datas = { "fb_id": "1459431344161385" }; </script>
    <script type="text/javascript" src="/scripts/userauth.js"></script>
    <script type='text/javascript' src='//connect.facebook.net/en_US/sdk.js'></script>
    <script>        //=============================切換驗證碼======================================
        function ToggleCode(obj, codeurl) {
            $(obj).attr("src", codeurl + "?time=" + Math.random());
        }
    </script>
    <script type="text/javascript">
        function checkadd() {
            if ($('#email').val() == '') {
                alert('請輸入帳號');
                $('#email').focus();
                return false;
            }
            if ($('#password').val() == '') {
                alert('請輸入密碼');
                $('#password').focus();
                return false;
            }
            if ($('#txt_code').val() == "") {
                alert("請輸入驗証碼!");
                $('#txt_code').focus();
                return false;
            }
        }
    </script>
</head>
<body>
    <public:hand ID="hand" runat="server" />
    <div class="login width-sys">
        <div class="login-r">
            <form action="login.aspx" method="post" onsubmit="return checkadd();">
            <input type="hidden" name="act" value="act_login" />
            <h1>登入</h1>
            <input type="text" name="email" id="email" class="login-ipt" placeholder="請輸入帳號" />
            <div class="login-wbk">
                <input name="password" id="password" class="login-ipt" type="password" placeholder="密碼" />
            </div>
            <div class="login-wbk"><input type="text" name="txt_code" id="txt_code"  placeholder="驗証碼不分大小寫"  class="login-ipt1"><img src="/tools/verify_code.ashx" height="44" onclick="ToggleCode(this, '/tools/verify_code.ashx');return false;" />
            </div>
            <div class="login-bt1">
                <a class="float-l" href="find.aspx">忘記密碼？</a></div>
            <input name="input" type="submit" value="登  入" class="login-btn" style="width: calc(96% - 2px);"/>
            <input name="input" type="button" value="google帳號快速登入" class="fblogin-btn btn-red" onclick="javascript:location.href='/google.aspx'" />
            <!--<input name="input" type="button" value="微信帳號登入" class="fblogin-btn btn-green" />-->
            <input name="input" type="button" value="Facebook帳號快速登入" class="fblogin-btn" id="fb_login"  />
            <div class="login-fgx">
                <strong>or</strong></div>
            </form>
            <input name="input" type="button" value="一般Email註冊" class="emlogin-btn" onclick="javascript:location.href='reg.aspx'" />
        </div>
    </div>
    <public:foot ID="foot" runat="server" />
    <script type="text/javascript" src="/js/jquery.spinner.js"></script>
    <script type="text/javascript">
        $('.spinnerExample').spinner({});
    </script>
</body>
</html>
