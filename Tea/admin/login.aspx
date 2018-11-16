<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Tea.Web.admin.login" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no">
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>管理員登入</title>
<link href="skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript">
    $(function () {
        //檢測IE
        if ('undefined' == typeof (document.body.style.maxHeight)) {
            window.location.href = 'ie6update.html';
        }
    });
</script>
</head>

<body class="loginbody">
<form id="form1" runat="server">
<div style="width:100%; height:100%; min-width:300px; min-height:260px;"></div>
<div class="login-wrap">
  <div class="login"></div>
  <br />
  <br />
  <br />
  <div class="login"></div>
  <div class="login-form">
    <div class="col">
      <asp:TextBox ID="txtUserName" runat="server" CssClass="login-input" placeholder="管理員帳號" title="管理員帳號"></asp:TextBox>
      <label class="icon user" for="txtUserName"></label>
    </div>
    <div class="col">
      <asp:TextBox ID="txtPassword" runat="server" CssClass="login-input" TextMode="Password" placeholder="管理員密碼" title="管理員密碼"></asp:TextBox>
      <label class="icon pwd" for="txtPassword"></label>
    </div>
    <div class="col">
      <asp:Button ID="btnSubmit" runat="server" Text="登 錄" CssClass="login-btn" onclick="btnSubmit_Click" />
    </div>
  </div>
  <div class="login-tips"><i></i><p id="msgtip" runat="server">請輸入用戶名和密碼</p></div>
</div>

<div class="copy-right">
  <p>版權所有 Ljd Copyright © 2016 - 2017 dtsoft.net Inc. All Rights Reserved.</p>
</div>
</form>
</body>
</html>
