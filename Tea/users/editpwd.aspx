<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editpwd.aspx.cs" Inherits="users_editpwd" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>
        <%=title%></title>
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
        function is_pwd(pass) {
            if (pass.length < 8) {
                return 0;
            }
            if (pass.length > 18) {
                return 0;
            }
            var ls = 0;
            if (pass.match(/([a-zA-Z])+/)) {
                ls++;
            }
            if (pass.match(/([0-9])+/)) {
                ls++;
            }
            return ls;
        }
        function check() {
            if ($('#txt_pwd').val() == '') {
                alert('請輸入密碼');
                $('#txt_pwd').focus();
                return false;
            }
            if (is_pwd($('#txt_pwd').val()) < 2) {
                alert("請輸入格式為英數混合8~18碼的密碼");
                $('#txt_pwd').focus();
                return false;
            }
            if ($('#txt_pwd1').val() == '') {
                alert('請輸入確認密碼');
                $('#txt_pwd1').focus();
                return false;
            }
            if ($('#txt_pwd1').val() != $('#txt_pwd').val()) {
                alert('密碼不一致');
                $('#txt_pwd1').focus();
                return false;
            }
        }
    </script>
</head>
<body>
    <public:hand ID="hand" runat="server" />
    <div class="login width-sys">
        <form action="editpwd.aspx?id=<%=id%>&pwd=<%=pwd%>" method="post" onsubmit="return check();">
        <input type="hidden" name="act" value="act_edit" />
        <div class="regest-form">
            <h1>
                重設密碼</h1>
            <dl>
                <dd>
                    賬號：</dd>
                <dt>
                    <%=model.user_name %></dt>
            </dl>
            <dl>
                <dd>
                    密碼：</dd>
                <dt>
                    <input type="password" name="txt_pwd" id="txt_pwd"  class="ins-ipt1"  placeholder="密碼格式為英數混合8~18碼" />
                </dt>
            </dl>
            <dl>
                <dd>
                    確認密碼：</dd>
                <dt>
                    <input type="password" name="txt_pwd1" id="txt_pwd1" class="ins-ipt1"  placeholder="密碼格式為英數混合8~18碼" />
                </dt>
            </dl>
            <div class="login-check">
                <input name="input" type="submit" value="修改密碼" class="loginpw-btn" />
            </div>
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
