<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Tea.Web.admin.index" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>後台管理中心</title>
<link href="../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery.nicescroll.js"></script>
<script type="text/javascript" charset="utf-8" src="../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="js/layindex.js"></script>
<script type="text/javascript" charset="utf-8" src="js/common.js"></script>
<script type="text/javascript">
//頁面載入完成時
$(function () {
    //檢測IE
    if ('undefined' == typeof(document.body.style.maxHeight)){
        window.location.href = 'ie6update.html';
    }
});
</script>
</head>

<body class="indexbody">
<form id="form1" runat="server">
  <!--全域菜單-->
  <a class="btn-paograms" onclick="togglePopMenu();"></a>
  <div id="pop-menu" class="pop-menu">
    <div class="pop-box">
      <h1 class="title"><i></i>導航菜單</h1>
      <i class="close" onclick="togglePopMenu();">關閉</i>
      <div class="list-box"></div>
    </div>
    <i class="arrow">箭頭</i>
  </div>
  <!--/全域菜單-->
  <div class="main-top">
    <a class="icon-menu"></a>
    <div id="main-nav" class="main-nav"></div>
    <div class="nav-right">
      <div class="info">
        <i></i>
        <span>
          您好，<%=admin_info.user_name %><br>
          <%=new Tea.BLL.manager_role().GetTitle(admin_info.role_id) %>
        </span>
      </div>
      <div class="option">
        <i></i>
        <div class="drop-wrap">
          <div class="arrow"></div>
          <ul class="item">
            <li>
              <a href="../" target="_blank">預覽網站</a>
            </li>
            <li>
              <a href="center.aspx" target="mainframe">管理中心</a>
            </li>
            <li>
              <a href="manager/manager_pwd.aspx" onclick="linkMenuTree(false, '');" target="mainframe">修改密碼</a>
            </li>
            <li>
              <asp:LinkButton ID="lbtnExit" runat="server" onclick="lbtnExit_Click">登出</asp:LinkButton>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
  
  <div class="main-left">
    <h1 class="logo"></h1>
    <div id="sidebar-nav" class="sidebar-nav"></div>
  </div>
  
  <div class="main-container">
    <iframe id="mainframe" name="mainframe" frameborder="0" src="<%=url%>"></iframe>
  </div>

</form>
</body>
</html>
