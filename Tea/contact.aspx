<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>
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
    <script type="text/javascript" src="/scripts/validatorBase.js"></script>
    <script type="text/javascript">
        function checkadd() {
            if ($('#txt_title').val() == '') {
                alert('請輸入主旨');
                $('#txt_title').focus();
                return false;
            }
            if ($('#txt_name').val() == '') {
                alert('請輸入您的姓名');
                $('#txt_name').focus();
                return false;
            }
            if ($('#txt_email').val() == '') {
                alert('請輸入您的電子郵件');
                $('#txt_email').focus();
                return false;
            }
            if (!isEmail($('#txt_email').val())) {
                alert("請輸入正確電子郵件!");
                $('#txt_email').focus();
                return false;
            }
            if ($('#txt_tel').val() == '') {
                alert('請輸入您的電話');
                $('#txt_tel').focus();
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
    <div class="regest width-sys">
        <form action="contact.aspx" method="post"   onsubmit="return checkadd();">
        <input type="hidden" name="act" value="add" />
        <div class="contact-form">
            <h1>
                聯絡我們</h1>
            <dl>
                <dd>
                    <span class="red">＊</span>主旨：</dd>
                <dt>
                    <input type="text" name="txt_title" id="txt_title" class="reg-ipt2"></dt>
            </dl>
            <dl>
                <dd>
                    <span class="red">＊</span>您的姓名：</dd>
                <dt>
                    <input type="text" name="txt_name" id="txt_name" class="reg-ipt1"></dt>
            </dl>
            <dl>
                <dd>
                    <span class="red">＊</span>您的電子郵件：</dd>
                <dt>
                    <input type="text" name="txt_email" id="txt_email" class="reg-ipt1"></dt>
            </dl>
            <dl>
                <dd>
                    <span class="red">＊</span>您的電話：</dd>
                <dt>
                    <input type="text" name="txt_tel" id="txt_tel" class="reg-ipt1"></dt>
            </dl>
            <dl>
                <dd>
                    內容：</dd>
                <dt>
                    <textarea class="reg-text" name="txt_content" id="txt_content"></textarea></dt>
            </dl>
            <dl>
                <dd>
                    <span class="red">＊</span>驗証碼：</dd>
                <dt>
                    <input type="text" name="txt_code" id="txt_code"  placeholder="驗証碼不分大小寫" class="reg-ipt1" ><img src="/tools/verify_code.ashx" height="22" onclick="ToggleCode(this, '/tools/verify_code.ashx');return false;" /></dt>
            </dl>
            <dl>
                <dd>
                    &nbsp;</dd>
                <dt>
                    <input name="input2" type="submit" value="確定送出" class="contact-btn" /><input name="input2" type="reset" value="取消重填" class="contact-btn" />
                </dt>
            </dl>
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
