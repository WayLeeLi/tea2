<%@ Page Language="C#" AutoEventWireup="true" CodeFile="find.aspx.cs" Inherits="find" %>
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
    <script>        //=============================切換驗證碼======================================
        function ToggleCode(obj, codeurl) {
            $(obj).attr("src", codeurl + "?time=" + Math.random());
        }
    </script>
    <script type="text/javascript">
        function check() {
            if ($('#txt_email').val() == '') {
                alert('請輸入註冊時的信箱');
                $('#txt_email').focus();
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
        <form action="find.aspx" method="post" onsubmit="return check();">
        <input type="hidden" name="act" value="act_find" />
        <div class="login-r">
            <h1>忘記密碼</h1>
            <input name="txt_email" id="txt_email" type="text" class="login-ipt" placeholder="請輸入註冊時的信箱" />
            <div class="login-wbk"><input type="text" name="txt_code" id="txt_code"  placeholder="驗証碼不分大小寫"  class="login-ipt1"><img src="/tools/verify_code.ashx" height="44" onclick="ToggleCode(this, '/tools/verify_code.ashx');return false;" />
            </div>
            <div class="login-bt1">
                <a class="float-l" href="javascript:void">密碼將發送至您的郵箱</a><br>
                <br>
            </div>
            <input name="input" type="submit" value="找回密碼" class="loginpw-btn" />
        </div>
        </form>
    </div>
    <public:foot ID="foot" runat="server" />
    <script type="text/javascript" src="/js/jquery.spinner.js"></script>
    <script type="text/javascript">
        $('.spinnerExample').spinner({});
    </script>
</body>
</html>