<%@ Page Language="C#" AutoEventWireup="true" CodeFile="center.aspx.cs" Inherits="Tea.Web.admin.center" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>管理首頁</title>
<link href="skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="/js/layindex.js"></script>
<script type="text/javascript" charset="utf-8" src="/js/common.js"></script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--巡覽列-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一頁</span></a>
  <a class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>管理中心</span>
</div>
<!--/巡覽列-->

<!--內容-->
<div class="line10"></div>
<div class="nlist-1">
  <ul>
    <li>本次登入IP：<asp:Literal ID="litIP" runat="server" Text="-" /></li>
    <li>上次登入IP：<asp:Literal ID="litBackIP" runat="server" Text="-" /></li>
    <li>上次登入時間：<asp:Literal ID="litBackTime" runat="server" Text="-" /></li>
  </ul>
</div>
<div class="line10"></div>

<div class="nlist-2">
  <h3><i></i>網站訊息</h3>
  <ul>
    <li>網站名稱：<%=siteConfig.webname %></li>
    <li>公司名稱：<%=siteConfig.webcompany %></li>
    <li>網站功能變數名稱：<%=siteConfig.weburl %></li>
    <li>安裝目錄：<%=siteConfig.webpath %></li>
    <li>網站管理目錄：<%=siteConfig.webmanagepath %></li>
    <li>附件上傳目錄：<%=siteConfig.filepath %></li>
    <li>伺服器名稱：<%=Server.MachineName%></li>
    <li>伺服器IP：<%=Request.ServerVariables["LOCAL_ADDR"] %></li>
    <li>NET框架版本：<%=Environment.Version.ToString()%></li>
    <li>作業系統：<%=Environment.OSVersion.ToString()%></li>
    <li>IIS環境：<%=Request.ServerVariables["SERVER_SOFTWARE"]%></li>
    <li>伺服器埠：<%=Request.ServerVariables["SERVER_PORT"]%></li>
    <li>目錄物理路徑：<%=Request.ServerVariables["APPL_PHYSICAL_PATH"]%></li>
  </ul>
</div>
<div class="line20"></div>
<!--/內容-->

</form>
</body>
</html>
