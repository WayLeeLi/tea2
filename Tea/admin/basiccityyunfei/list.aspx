﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="Tea.Web.admin.basic.list" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>國家設定管理</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<link  href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    //導入excel
    function importExcel() {
        var importDialog = $.dialog({
            lock: true,
            max: false,
            min: false,
            title: "批次上傳運費設定",
            content: 'url:dialog/dialog_yunfei.aspx',
            width: 600,
            height: 150
        });
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--導航欄-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>交易方式設定</span>
  <i class="arrow"></i>
  <span>運費設定</span>
</div>
<!--/導航欄-->

<!--工具欄-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar" >
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="add" href="edit.aspx?action=<%=TWEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全選</span></a></li>
        <li><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>儲存</span></asp:LinkButton></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>刪除</span></asp:LinkButton></li>
        <li><a class="import" href="javascript:;" onclick="importExcel();"><i></i><span>導入</span></a></li>
        <li><a class="save" href="yunfei.xls" target="_blank"><i></i><span>下載示例</span></a></li>
      </ul>
    </div>
    <div class="r-list">
      <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
      <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查詢</asp:LinkButton>
    </div>
  </div>
</div>
<!--/工具欄-->

<!--列表-->
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">選擇</th>
    <th align="left">分區</th>
    <th align="left">編號</th>
    <th align="left">重量</th>
    <th align="left">費用</th>
    <th width="10%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("basic_id")%>' runat="server" />
    </td>
    <td><%#new Tea.BLL.basic().get_basic("qu",Eval("basic_type").ToString())%></td>
    <td><a href="edit.aspx?action=<%=TWEnums.ActionEnum.Edit %>&id=<%#Eval("basic_id")%>"><%#Eval("basic_label")%></a></td>
    <td><asp:TextBox ID="txtYunFei" runat="server" Text='<%#Eval("basic_money","{0:0.00}")%>' CssClass="sort" onkeydown="return checkForFloat(event);" /></td>
    <td><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("basic_sort")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center"><a href="edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&id=<%#Eval("basic_id")%>">修改</a></td>
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
    <span>顯示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>條/頁</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/內容底部-->
</form>
</body>
</html>
