<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manager_list.aspx.cs" Inherits="Tea.Web.admin.manager.manager_list" %>
<%@ Import namespace="Tea.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>管理員列表</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--巡覽列-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>管理員列表</span>
</div>
<!--/巡覽列-->

<!--工具列-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a class="add" href="manager_edit.aspx?action=<%=TWEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
          <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全選</span></a></li>
          <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>刪除</span></asp:LinkButton></li>
        </ul>
      </div>
      <div class="r-list">
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
      <th align="left">用戶名</th>
      <th align="left" width="12%">姓名</th>
      <th align="left" width="12%">角色</th>
      <th align="left" width="12%">電話</th>
      <th align="left" width="16%">添加時間</th>
      <th width="8%">狀態</th>
      <th width="8%">操作</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center">
        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
      </td>
      <td><a href="manager_edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&id=<%#Eval("id")%>"><%# Eval("user_name") %></a></td>
      <td><%# Eval("real_name") %></td>
      <td><%#new Tea.BLL.manager_role().GetTitle(Convert.ToInt32(Eval("role_id")))%></td>
      <td><%# Eval("telephone") %></td>
      <td><%#Eval("add_time","{0:yyyy-MM-dd}")%></td>
      <td align="center"><%#Eval("is_lock").ToString().Trim() == "0" ? "正常" : "關閉"%></td>
      <td align="center"><a href="manager_edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&id=<%#Eval("id")%>">修改</a></td>
    </tr>
  </ItemTemplate>
  <FooterTemplate>
    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暫無記錄</td></tr>" : ""%>
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
