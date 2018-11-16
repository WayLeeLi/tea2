<%@ Page Language="C#" AutoEventWireup="true" CodeFile="category_list.aspx.cs" Inherits="Tea.Web.admin.article.category_list" %>
<%@ Import namespace="Tea.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>後台導航管理</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
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
  <span>商品管理</span>
  <i class="arrow"></i>
  <span>分類管理</span>
</div>
<!--/巡覽列-->

<!--工具列-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a class="add" href="category_edit.aspx?action=<%=TWEnums.ActionEnum.Add %>&channel_id=<%=this.channel_id %>"><i></i><span>新增</span></a></li>
          <li><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>儲存</span></asp:LinkButton></li>
          <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全選</span></a></li>
          <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作會刪除本類別及下屬子類別，是否繼續？');" onclick="btnDelete_Click"><i></i><span>刪除</span></asp:LinkButton></li>
          <li><asp:LinkButton ID="btnOnsale" runat="server" CssClass="onsale" OnClientClick="return ExePostBack('btnOnSale','確定顯示？');"  onclick="btnOnsale_Click"><i></i><span>導航顯示</span></asp:LinkButton></li>
          <li><asp:LinkButton ID="btnOffsale" runat="server" CssClass="offsale" OnClientClick="return ExePostBack('btnOffsale','確定不顯示？');"  onclick="btnOffsale_Click"><i></i><span>導航不顯示</span></asp:LinkButton></li>
        </ul>
      </div>
    </div>
  </div>
</div>
<!--/工具列-->

<!--列表-->
<div class="table-container">
  <asp:Repeater ID="rptList" runat="server" onitemdatabound="rptList_ItemDataBound">
  <HeaderTemplate>
  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
    <tr>
      <th width="6%">選擇</th>
      <th align="left" width="6%">編號</th>
      <th align="left">類別名稱</th>
      <th align="left" width="12%">商品數量</th>
      <th align="left" width="12%">導航顯示</th>
      <th align="left" width="12%">排序</th>
      <th width="12%">操作</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center">
        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
        <asp:HiddenField ID="hidLayer" Value='<%#Eval("class_layer") %>' runat="server" />
      </td>
      <td><%#Eval("id")%></td>
      <td>
        <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
        <a href="category_edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>"><%#Eval("title")%></a>
      </td>
      <td><A href="tuan_list.aspx?channel_id=7&category_id=<%#Eval("id")%>"><%#getnum(Eval("id").ToString())%></A></td>
      <td><%#Eval("call_index").ToString()=="1"?"顯示":"不顯示"%></td>
      <td><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
      <td align="center">
        <a href="category_edit.aspx?action=<%#TWEnums.ActionEnum.Add %>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>"  style="display:none;">添加子類</a>
        <a href="category_edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>">修改</a>
      </td>
    </tr>
  </ItemTemplate>
  <FooterTemplate>
    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暫無記錄</td></tr>" : ""%>
  </table>
  </FooterTemplate>
  </asp:Repeater>
</div>
<!--/列表-->

</form>
</body>
</html>
