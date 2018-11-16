<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reg.aspx.cs" Inherits="reg" %>
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
    <script type="text/javascript" src='/scripts/city.js'></script>
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
            if (pass.length >18) {
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
        function checkadd() {
            if ($('#userName').val() == '') {
                alert('請輸入真實姓名');
                $('#userName').focus();
                return false;
            }
            if ($('#email').val() == '') {
                alert('請輸入電子信箱');
                $('#email').focus();
                return false;
            }
            if ($('#loginPwd').val() == '') {
                alert('請輸入密碼');
                $('#loginPwd').focus();
                return false;
            }
            if (is_pwd($('#loginPwd').val()) < 2) {
                alert("請輸入格式為英數混合8~18碼的密碼");
                $('#loginPwd').focus();
                return false;
            }
            if ($('#loginPwd1').val() == '') {
                alert('請輸入確認密碼');
                $('#loginPwd1').focus();
                return false;
            }
            if ($('#loginPwd1').val() != $('#loginPwd').val()) {
                alert('密碼不一致');
                $('#loginPwd1').focus();
                return false;
            }
            if ($('#birthdayY').val() == '') {
                alert('請輸入生日');
                $('#birthdayY').focus();
                return false;
            }
            if ($('#birthdayM').val() == '') {
                alert('請輸入生日');
                $('#birthdayM').focus();
                return false;
            }
            if ($('#birthdayD').val() == '') {
                alert('請輸入生日');
                $('#birthdayD').focus();
                return false;
            }
            if ($('#cellPhone').val() == '') {
                alert('請輸入連絡電話');
                $('#cellPhone').focus();
                return false;
            }
            if ($('#txt_guo').val() == '台灣') {
                if ($('#txt_city').val() == '' || $('#txt_state').val() == '') {
                    alert('請輸入所在地');
                    $('#txt_city').focus();
                    return false;
                }
            }
            else {
                if ($('#txt_city1').val() == '' || $('#txt_state1').val() == '') {
                    alert('請輸入所在地');
                    $('#txt_city1').focus();
                    return false;
                }   
            }
            if ($('#txt_zip').val() == '') {
                alert('請輸入所在地');
                $('#txt_zip').focus();
                return false;
            }
            if ($('#address').val() == '') {
                alert('請輸入所在地');
                $('#address').focus();
                return false;
            }
            if ($('#txt_code').val() == "") {
                alert("請輸入驗証碼!");
                $('#txt_code').focus();
                return false;
            }
            if ($('#argee').prop('checked') == false) { alert('需同意隱私條款'); return false; }
        }

        function xuanze() {
            if ($('#txt_guo').val() == '台灣') {
                $('#txt_state').show();
                $('#txt_city').show();
                $('#txt_state1').hide();
                $('#txt_city1').hide();
            }
            else {
                $('#txt_state1').show();
                $('#txt_city1').show();
                $('#txt_state').hide();
                $('#txt_city').hide();
            }
        }
        $(function () { xuanze(); });
    </script>
</head>
<body>
    <public:hand ID="hand" runat="server" />
    <div class="regest width-sys">
        <form action="reg.aspx" method="post" enctype="multipart/form-data" onsubmit="return checkadd();">
        <input type="hidden" name="act" value="act_reg" />
        <div class="regest-form">
            <h1>
                加入會員</h1>
            <dl>
                <dd>
                    真實姓名：</dd>
                <dt>
                    <input type="text"  name="userName" id="userName"class="reg-ipt2"><span class="reg-tips red">註冊後不可更改。</span></dt>
            </dl>
            <dl>
                <dd>
                    電子信箱：</dd>
                <dt>
                    <input type="text" name="email" id="email" class="reg-ipt1"><span class="reg-tips red">將以此電子信箱作為登入帳號，並發送帳號啟用連結。帳號啟用後，才可使用。</span></dt>
            </dl>
            <dl>
                <dd>
                    密碼：</dd>
                <dt>
                    <input type="password" name="loginPwd" id="loginPwd" placeholder="密碼格式為英數混合8~18碼" class="reg-ipt1"></dt>
            </dl>
            <dl>
                <dd>
                    確認密碼：</dd>
                <dt>
                    <input type="password" name="loginPwd1" id="loginPwd1"  placeholder="密碼格式為英數混合8~18碼" class="reg-ipt1"></dt>
            </dl>
            <dl>
                <dd>
                    生日：</dd>
                <dt>西元<input type="text"  name="birthdayY"  id="birthdayY" class="reg-ipt3">年<input type="text"  id="birthdayM"  name="birthdayM" class="reg-ipt3">月<input
                    type="text" name="birthdayD" id="birthdayD" class="reg-ipt3">日<span class="reg-tips red">註冊後不可更改</span></dt>
            </dl>
            <dl>
                <dd>
                    性別：</dd>
                <dt>
                    <label>
                        <input type="radio"  name="rblSex"  value="男" checked >
                        男</label>
                    <label>
                        <input type="radio"  name="rblSex"  value="女">
                        女</label>
                    <dt></dt>
            </dl>
            <dl>
                <dd>
                    連絡電話：</dd>
                <dt>
                    <input type="text"  name="cellPhone" id="cellPhone" class="reg-ipt1"></dt>
            </dl>
            <dl>
                <dd>
                    所在地：</dd>
                <dt>
                    <div class="select">
                        <select name="txt_guo" id="txt_guo" class="regest-sel" onchange="javascript:xuanze();">
                        <asp:Repeater ID="data_guo" runat="server"><ItemTemplate>
                            <option value="<%#Eval("basic_label")%>"><%#Eval("basic_label")%></option>
                        </ItemTemplate></asp:Repeater>
                        </select>
                        <input type="text" name="txt_state1" id="txt_state1"  class="reg-ipt3" placeholder="省份">
                        <input type="text" name="txt_city1" id="txt_city1"  class="reg-ipt3" placeholder="城市">
                            <select name="txt_state" id="txt_state" class="regest-sel" runat="Server" onchange="changeArea

(this.value,document.all.txt_city)">
                    <option value="">請選擇縣市...</option>
                    <option value='基隆市'>基隆市</option>
                    <option value='台北市'>台北市</option>
                    <option value='新北市'>新北市</option>
                    <option value='宜蘭縣'>宜蘭縣</option>
                    <option value='新竹市'>新竹市</option>
                    <option value='新竹縣'>新竹縣</option>
                    <option value='桃園市'>桃園市</option>
                    <option value='苗栗縣'>苗栗縣</option>
                    <option value='台中市'>台中市</option>
                    <option value='彰化縣'>彰化縣</option>
                    <option value='南投縣'>南投縣</option>
                    <option value='嘉義市'>嘉義市</option>
                    <option value='嘉義縣'>嘉義縣</option>
                    <option value='雲林縣'>雲林縣</option>
                    <option value='台南市'>台南市</option>
                    <option value='高雄市'>高雄市</option>
                    <option value='屏東縣'>屏東縣</option>
                    <option value='台東縣'>台東縣</option>
                    <option value='花蓮縣'>花蓮縣</option>
                    <option value='金門縣'>金門縣</option>
                                                          <option value='連江縣'>連江縣</option>
                                                           <option value='澎湖縣'>澎湖縣</option>
                                                           <option value='南海諸島'>南海諸島</option>
                </select>
                <select name="txt_city" id="txt_city" class="regest-sel" runat="Server" onchange="changeArea1

(this.value,document.all.txt_zip)">
                    <option value="">請選擇區域...</option>
                </select>
                    </div>
                </dt>
            </dl>
            <dl>
                <dd>
                    郵遞區號：</dd>
                <dt>
                    <input name="txt_zip" id="txt_zip"  />
                </dt>
            </dl>
            <dl>
                <dd>
                    地址：</dd>
                <dt>
                    <input type="text" name="address" id="address"  class="reg-ipt1"></dt>
            </dl>
            <dl>
                <dd>驗証碼：</dd>
                <dt>
                    <input type="text" name="txt_code" id="txt_code"  placeholder="驗証碼不分大小寫" ><img src="/tools/verify_code.ashx" height="22" onclick="ToggleCode(this, '/tools/verify_code.ashx');return false;" /></dt>
            </dl>
            <div class="login-check">
                <label>
                    <input type="checkbox" name="ck" value="1" id="argee">
                    已閱讀並同意<a href="javascript:void();" onclick="javascript:opentc();">隱私條款</a></label>
                <label>
                    <input type="checkbox" name="rss" value="1" id="rss">
                    同意接收電子報</label>
            </div>
            <input name="input" type="submit" value="註冊" class="login-btn" style="width: calc(96% - 2px);"/>
            <input name="input" type="button" value="google帳號綁定" class="fblogin-btn btn-red" onclick="javascript:location.href='/google.aspx'" />
           <!-- <input name="input" type="button" value="微信帳號綁定" class="fblogin-btn btn-green" />-->
            <input name="input" type="button" value="Facebook帳號綁定" class="fblogin-btn"  id="fb_login" />
        </div>
        </form>
    </div>
    <div class="tc-box-bg">
        <div class="tc-box">
            <div class="tc-wrap">
                <h1>隱私條款</h1>
                <%=config.webcrod%>
            </div>
            <div class="tc-close"><a href="javascript:closetc();" onclick="javascript:$('#argee').prop('checked',true)">已閱讀並同意隱私條款</a></div>
        </div>
    </div>
    <public:foot ID="foot1" runat="server" />
    <script type="text/javascript" src="/js/jquery.spinner.js"></script>
    <script type="text/javascript">
        $('.spinnerExample').spinner({});
    </script>
</body>
</html>
 
    
 