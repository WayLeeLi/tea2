<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edituser.aspx.cs" Inherits="edituser" %>
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
    <script src="/js/app.js"></script>
    <script type="text/javascript" src='/scripts/city.js'></script>
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
        function checkadd() {
          <%if(userModel.user_name.Contains("@")){ %>
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
            <%} %>
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
    <div class="width-sys member-box">
        <public:left ID="left" runat="server" />
        <div class="member-right">
            <div class="member-tit">
                個人資料修改
            </div>
            <form method="post" action="edituser.aspx" onsubmit="return checkadd();">
            <input type="hidden" name="act" value="act_edit" />
            <div class="memberzl form-box">
                <dl>
                    <dd>
                        真實姓名：</dd>
                    <dt>
                        <input type="text"  name="txt_nichen" id="txt_nichen" class="ins-ipt1" placeholder="王大明" value="<%=userModel.nick_name%>" />
                    </dt>
                </dl>
                <dl>
                    <dd>
                        電子信箱：</dd>
                    <dt>
                        <input type="text" name="txt_email" id="txt_email" class="ins-ipt1" placeholder="d548163@yahoo.com.tw" value="<%=userModel.email%>"
                          <%=userModel.email.Length>4?" readonly":"" %>   />
                        <span class="zl-tips"></span><%=userModel.email.Length > 4 ? " E-mail為帳號無法修改" : ""%> </dt>
                </dl>
                <%if(userModel.user_name.Contains("@")){ %>
                <dl>
                    <dd>
                        密碼：</dd>
                    <dt>
                        <input type="password" name="txt_pwd" id="txt_pwd" value="ljd110!@#" class="ins-ipt1" placeholder="密碼格式為英數混合8~18碼" />
                    </dt>
                </dl>
                <dl>
                    <dd>
                        確認密碼：</dd>
                    <dt>
                        <input type="password" name="txt_pwd1" id="txt_pwd1" value="ljd110!@#" class="ins-ipt1" placeholder="密碼格式為英數混合8~18碼" />
                    </dt>
                </dl>
                <%} %>
                <dl>
                    <dd>
                        生日：</dd>
                    <dt>西元
                        <input name="txt_year" type="text" class="zlr-ipt1" value="<%=year%>" <%if(!string.IsNullOrEmpty(year)) {%>readonly<%} %> />
                        年
                        <input type="text" name="txt_month" value="<%=month%>" class="zlr-ipt1" <%if(!string.IsNullOrEmpty(month)) {%>readonly<%} %> />
                        月
                        <input type="text" name="txt_day" value="<%=day%>" class="zlr-ipt1" <%if(!string.IsNullOrEmpty(day)) {%>readonly<%} %> />
                        日 <span class="zl-tips">註冊後不可更改</span></dt>
                </dl>
                <dl>
                    <dd>
                        性別：</dd>
                    <dt>
                        <label>
                            <input name="txt_sex" type="radio" value="女" <%=userModel.sex == "女" ? " checked" : ""%> />
                            女</label>
                        <label>
                            <input  name="txt_sex" type="radio" value="男" <%=userModel.sex == "男" ? " checked" : ""%>  />
                            男</label>
                    </dt>
                </dl>
                <dl>
                    <dd>
                        連絡電話：</dd>
                    <dt>
                        <input type="text" name="txt_tel" id="txt_tel" class="ins-ipt1" placeholder="08-12345678" value="<%=userModel.mobile%>" />
                    </dt>
                </dl>
                <dl>
                    <dd>
                        所在地：</dd>
                    <dt>
                        <div class="select">
                          <select name="txt_guo" id="txt_guo" class="regest-sel" onchange="javascript:xuanze();">
                        <asp:Repeater ID="data_guo" runat="server"><ItemTemplate>
                            <option value="<%#Eval("basic_label")%>" <%#Eval("basic_label").ToString() == guo ? " selected" : ""%>><%#Eval("basic_label")%></option>
                        </ItemTemplate></asp:Repeater>
                        </select>
                        <input type="text" name="txt_state1" id="txt_state1"  class="reg-ipt3" placeholder="省份" value="<%=area%>">
                        <input type="text" name="txt_city1" id="txt_city1"  class="reg-ipt3" placeholder="城市"  value="<%=city%>">
                          <select name="txt_state" id="txt_state" class="regest-sel" runat="Server" onchange="changeArea(this.value,document.all.txt_city)">
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
             </select><select name="txt_city" id="txt_city" class="regest-sel" runat="Server" onchange="changeArea1(this.value,document.all.txt_zip)">
                                                    <option value="">請選擇區域...</option>
             </select>
                        </div>
                    </dt>
                </dl>
                <dl>
                    <dd>
                        郵遞區號：</dd>
                    <dt>
                        <div class="select">
                           <%if (!string.IsNullOrEmpty(area)){%><script>                                                                    changeArea('<%=area%>', document.all.txt_city)</script><%}%>
                        <%if (!string.IsNullOrEmpty(city)){%><script>                                                                 changeAreaSel(document.all.txt_city, '<%=city%>')</script><%}%>
                        <%if (!string.IsNullOrEmpty(area)){%><script>                                                                 changeAreaSel(document.all.txt_state, '<%=area%>')</script><%}%>
           <input name="txt_zip" type="text" class="ins-ipt1" id="txt_zip" value="<%=zip%>"  />
                        </div>
                    </dt>
                </dl>
                <dl>
                    <dd>
                        地址：</dd>
                    <dt>
                        <input type="text" name="txt_address" id="txt_address" value="<%=userModel.address%>" class="ins-ipt1" placeholder="臺北市新光路二段30號" />
                    </dt>
                </dl>
                <dl>
                    <dd>
                        訂閱電子報：</dd>
                    <dt>
                        <label>
                            <input name="txt_sub" type="radio" value="1" <%=userModel.exp == 1 ? " checked" : ""%> />
                            是</label>
                        <label>
                            <input name="txt_sub" type="radio"  value="0" <%=userModel.exp == 0 ? " checked" : ""%> />
                            否</label>
                    </dt>
                </dl>
                <dl>
                    <dd>&nbsp;
                        </dd>
                    <dt>
                        <input type="submit" name="button" id="Submit1" value="儲存變更" class="thh-btn btm" />
                    </dt>
                </dl>
                <div class="clear">
                </div>
            </div>
            </form>
        </div>
    </div>
    <public:foot ID="foot" runat="server" />
    <script type="text/javascript" src="/js/jquery.spinner.js"></script>
    <script type="text/javascript">
        $('.spinnerExample').spinner({});
    </script>
</body>
</html>