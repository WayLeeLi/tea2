<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="Tea.Web.admin.shop_feedback.list" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>一般提問管理</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--導航欄-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>網站管理</span>
  <i class="arrow"></i>
  <span>聯繫我們</span>
</div>
<!--/導航欄-->
<!--工具列-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全選</span></a></li>
          <li style="display:none;"><asp:LinkButton ID="lbtnUnLock" runat="server" CssClass="lock" OnClientClick="return ExePostBack('lbtnUnLock','關閉後前台看不到，確定繼續嗎？');" onclick="lbtnUnLock_Click"><i></i><span>關閉</span></asp:LinkButton></li>
          <li><asp:LinkButton ID="lbtnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('lbtnDelete');" onclick="lbtnDelete_Click"><i></i><span>刪除</span></asp:LinkButton></li>
        </ul>
        <div class="menu-list">
        <div class="rule-single-select">
          <asp:DropDownList ID="ddlPaymentStatus" runat="server" AutoPostBack="True" onselectedindexchanged="ddlPaymentStatus_SelectedIndexChanged">
            <asp:ListItem Value="-1" Selected="True">處理狀態</asp:ListItem>
            <asp:ListItem Value="0">處理中</asp:ListItem>
            <asp:ListItem Value="1">未回覆</asp:ListItem>
            <asp:ListItem Value="2">已回覆</asp:ListItem>
          </asp:DropDownList>
        </div>
        </div>
      </div>
      <div class="r-list"><div class="rule-single-select" style="float:left;">
          <asp:DropDownList ID="txtdate" runat="server">
            <asp:ListItem Value="1">新增時間</asp:ListItem>
            <asp:ListItem Value="2">回覆期限</asp:ListItem>
          </asp:DropDownList> </div>
      <asp:TextBox ID="txtbegin" runat="server" CssClass="keyword" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" />&nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="txtend" runat="server" CssClass="keyword" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" />&nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
      <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="lbtnSearch_Click">查詢</asp:LinkButton>
      </div>
    </div>
  </div>
</div>
<!--/工具列-->
<!--列表-->
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">選擇</th>
    <th align="left">主旨</th>
    <th align="left">狀態</th>
    <th align="left">姓名</th>
    <th align="left">電話</th>
    <th width="16%" align="left">提問時間</th>
    <th width="16%" align="left">回覆時間</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
    </td>
    <td><a href="edit.aspx?id=<%#Eval("id")%>" title="<%#Eval("title")%>"><%#ljd.function.leftx(Eval("title").ToString(),64,"..")%></a></td>
    <td><%#get_lock(Eval("is_lock").ToString())%></td>
    <td><%#Eval("user_name")%></td>
    <td><%#Eval("user_tel")%></td>
    <td><%#Eval("add_time","{0:yyyy-MM-dd}")%></td>
    <td><%#Eval("reply_time", "{0:yyyy-MM-dd}")%></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暫無記錄</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->

<!--內容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>顯示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>條/頁</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/內容底部-->
</form>
</body>
</html>
