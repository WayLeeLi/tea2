<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gift_list.aspx.cs" Inherits="Tea.Web.admin.goods.gift_list" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>站点管理</title>
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
<!--導航欄-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>商品管理</span>
  <i class="arrow"></i>
  <span>贈品管理</span>
</div>
<!--/導航欄-->

<!--工具欄-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
        <li><a class="add" href="gift_edit.aspx?action=<%=TWEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全選</span></a></li>
        <li><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>儲存</span></asp:LinkButton></li>
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
<!--/工具欄-->

<!--列表-->
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="6%">選擇</th>
    <th align="left">適用月份</th>
    <th align="left">名稱</th>
    <th align="left">品編</th>
    <th align="left" width="12%">類型</th>
    <th align="left" width="15%">剩餘數量</th>
    <th align="left" width="15%">添加時間</th>
    <th align="left" width="10%">排序</th>
    <th width="9%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
    </td>
    <td><%#Eval("brand_id")%></td>
    <td><a href="gift_edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&id=<%#Eval("id")%>"><%#Eval("title")%></a></td>
    <td><%#Eval("gift_code")%></td>
    <td><%#ShowType(Eval("type").ToString())%></td>
    <td><%#Eval("left_quantity")%></td>
    <td><%#Eval("add_time","{0:yyyy-MM-dd}")%></td>
    <td><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center"><a href="gift_edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&id=<%#Eval("id")%>">修改</a></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暫無記錄</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->

<!--內容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>顯示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>條/頁</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/內容底部-->
</form>
</body>
</html>
