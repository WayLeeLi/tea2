<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_edit.aspx.cs" Inherits="Tea.Web.admin.users.user_edit" ValidateRequest="false" %>
<%@ Import namespace="Tea.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>編輯會員</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
 <script src="/scripts/city.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        //初始化表單驗證
        $("#form1").initValidform();
        //初始化上傳控制項
        $(".upload-img").InitUploader({ sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf" });
    });
    function xuanze() {
        if ($('#txt_guo').val() == '台灣') {
            $('#txt_state').show();
            $('#txt_city').show();
            $('#txt_state1').hide();
            $('#txt_city1').hide();
//            $('#txt_state1').val('');
//            $('#txt_city1').val('');
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

<body class="mainbody">
<form id="form1" runat="server">
<!--巡覽列-->
<div class="location">
  <a href="user_list.aspx" class="back"><i></i><span>返回列表頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <a href="user_list.aspx"><span>會員管理</span></a>
  <i class="arrow"></i>
  <span>編輯會員</span>
</div>
<div class="line10"></div>
<!--/巡覽列-->

<!--內容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">基本資料</a></li>
        <li style="display:none;"><a href="javascript:;">帳戶資料</a></li>
       
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>所屬組別</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlGroupId" runat="server" datatype="*" errormsg="請選擇組別" sucmsg=" "></asp:DropDownList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>使用者狀態</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="0" Selected="True">正常</asp:ListItem>
        <asp:ListItem Value="1">郵件核驗中</asp:ListItem>
        <asp:ListItem Value="2">關閉</asp:ListItem>
        </asp:RadioButtonList>
      </div>
      <span class="Validform_checktip">*關閉帳戶無法登入</span>
    </dd>
  </dl>
  <dl>
    <dt>會員帳號</dt>
    <dd><asp:TextBox ID="txtUserName" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " ajaxurl="../../tools/admin_ajax.ashx?action=username_validate"></asp:TextBox> <span class="Validform_checktip">*登入的用戶名，支援中文</span></dd>
  </dl> 
  <dl>
    <dt>登入密碼</dt>
    <dd><asp:TextBox ID="txtPassword" runat="server" CssClass="input normal" TextMode="Password" datatype="*8-18" nullmsg="請設置密碼" errormsg="密碼範圍在6-20位之間" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*登入的密碼，密碼格式為英數混合 8~18 碼</span></dd>
  </dl>
  <dl>
    <dt>確認密碼</dt>
    <dd><asp:TextBox ID="txtPassword1" runat="server" CssClass="input normal" TextMode="Password" nullmsg="請再輸入一次密碼" errormsg="兩次輸入的密碼不一致" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*再次輸入密碼</span> <%--datatype="*" recheck="txtPassword"--%></dd>
  </dl>
  <dl>
    <dt>Email</dt>
    <dd><asp:TextBox ID="txtEmail" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*取回密碼時用到</span></dd>
  </dl>
  <dl>
    <dt>真實姓名</dt>
    <dd><asp:TextBox ID="txtNickName" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
 
  <dl style="display:none;">
    <dt>上傳頭像</dt>
    <dd>
      <asp:TextBox ID="txtAvatar" runat="server" CssClass="input normal upload-path"></asp:TextBox>
      <div class="upload-box upload-img"></div>
    </dd>
  </dl>
  <dl>
    <dt>用戶性別</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">

        <asp:ListItem Value="男">男</asp:ListItem>
        <asp:ListItem Value="女">女</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>生日日期</dt>
    <dd>
      <asp:TextBox ID="txtBirthday" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="請選擇正確的日期" sucmsg=" " />
    </dd>
  </dl>
  <dl>
    <dt>連絡電話</dt>
    <dd><asp:TextBox ID="txtMobile" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
  <dl style="display:none;">
    <dt>電話號碼</dt>
    <dd><asp:TextBox ID="txtTelphone" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
 
    <dl>
    <dt>通訊地址</dt>
    <dd>
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
             </select>
             <select name="txt_city" id="txt_city" class="regest-sel" runat="Server" onchange="changeArea1(this.value,document.all.txt_zip)">
                                                    <option value="">請選擇區域...</option>
             </select>
          <%if (!string.IsNullOrEmpty(area)){%><script>                                                             changeArea('<%=area%>', document.all.txt_city)</script><%}%>
                        <%if (!string.IsNullOrEmpty(city)){%><script>                                                                           changeAreaSel(document.all.txt_city, '<%=city%>')</script><%}%>
                        <%if (!string.IsNullOrEmpty(area)){%><script>                                                                           changeAreaSel(document.all.txt_state, '<%=area%>')</script><%}%>
           <input name="txt_zip" type="text" class="login-ipt"  value="<%=zip%>" /></dd>
  </dl>
  <dl>
    <dt>通訊地址</dt>
    <dd><asp:TextBox ID="txtAddress" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>訂閱電子報</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbExp" runat="server" />
      </div>
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
    <dl style="display:none;">
    <dt>目前紅利 </dt>
    <dd> <asp:Label ID="txtPoint" runat="server"></asp:Label></dd>
  </dl>
    <dl style="display:none;">
    <dt>累計紅利額 </dt>
    <dd><asp:Label ID="txtAmount" runat="server"></asp:Label></dd>
  </dl>
    <dl style="display:none;">
    <dt>成功分享優惠券次數</dt>
    <dd><asp:Label ID="txtCompany" runat="server"></asp:Label></dd>
  </dl>
 
</div>
<div class="tab-content" style="display:none;">
  <dl>
    <dt>升級經驗值</dt>
    <dd>
      <asp:TextBox ID="txtExp" runat="server" CssClass="input small" datatype="n" sucmsg=" ">0</asp:TextBox>
      <span class="Validform_checktip">*根據紅利計算得來，與紅利不同的是只增不減</span>
    </dd>
  </dl>
  <dl>
    <dt>註冊時間</dt>
    <dd><asp:Label ID="lblRegTime" Text="-" runat="server"></asp:Label></dd>
  </dl>
  <dl>
    <dt>註冊IP</dt>
    <dd><asp:Label ID="lblRegIP" Text="-" runat="server"></asp:Label></dd>
  </dl>
  <dl>
    <dt>最近登入時間</dt>
    <dd><asp:Label ID="lblLastTime" Text="-" runat="server"></asp:Label></dd>
  </dl>
  <dl>
    <dt>最近登入IP</dt>
    <dd><asp:Label ID="lblLastIP" Text="-" runat="server"></asp:Label></dd>
  </dl>
</div>
<!--/內容-->
 
<!--工具列-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSubmit" runat="server" Text="確認送出" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn"  style="display:none;"type="button" value="返回上一頁" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具列-->

</form>
</body>
</html>
