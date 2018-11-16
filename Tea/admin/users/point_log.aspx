<%@ Page Language="C#" AutoEventWireup="true" CodeFile="point_log.aspx.cs" Inherits="Tea.Web.admin.users.point_log" %>
<%@ Import namespace="Tea.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>紅利記錄</title>
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
<!--巡覽列-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>會員管理</span>
  <i class="arrow"></i>
  <span>紅利記錄</span>
</div>
<!--/巡覽列-->

<!--工具列-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li style="display:none;"><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全選</span></a></li>
          <li style="display:none;"><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>刪除</span></asp:LinkButton></li>
        </ul>
        <div class="menu-list">
        <div class="rule-single-select" style="display:none;">
          <asp:DropDownList ID="ddlPaymentStatus" runat="server" AutoPostBack="True" onselectedindexchanged="ddlPaymentStatus_SelectedIndexChanged">
            <asp:ListItem Value="" Selected="True">全部狀態</asp:ListItem>
            <asp:ListItem Value="0">等待中</asp:ListItem>
            <asp:ListItem Value="1">可用</asp:ListItem>
            <asp:ListItem Value="2">已取消</asp:ListItem>
            <asp:ListItem Value="3">已提現</asp:ListItem>
            <asp:ListItem Value="4">已使用</asp:ListItem>
          </asp:DropDownList>
        </div>
        </div>
      </div>
      <div class="r-list"><div class="rule-single-select" style="float:left; display:none;">
          <asp:DropDownList ID="txtdate" runat="server">
            <asp:ListItem Value="1">發生時間</asp:ListItem>
            <asp:ListItem Value="2">確認時間</asp:ListItem>
          </asp:DropDownList> </div>
      <asp:TextBox ID="txtbegin" runat="server" CssClass="keyword" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" />&nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="txtend" runat="server" CssClass="keyword" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" />&nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
      <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查詢</asp:LinkButton>
      </div>
    </div>
  </div>
</div>
<!--/工具列-->

<!--列表-->
<div class="table-container">
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">選擇</th>
    <th align="left">會員帳號</th>
    <th align="left">紅利</th>
    <th align="left">備註</th>
    <th align="left">發生時間</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
    </td>
    <td><a href="user_edit.aspx?action=<%#TWEnums.ActionEnum.Edit %>&id=<%#Eval("user_id")%>&cid=<%#Eval("user_name")%>"><%#Eval("user_name")%></a></td>
    <td><%#Eval("value")%></td>
    <td><%#Eval("remark")%><a href="../order/order_edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&id=<%#Eval("order_id")%>"><%#getcode(Eval("order_id").ToString())%></a></td>
    <td><%#string.Format("{0:yyyy-MM-dd}", Eval("add_time"))%></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暫無記錄</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
</div>
<!--/列表-->

<!--內容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>顯示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>條/頁</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/內容底部-->

</form>
</body>
</html>
