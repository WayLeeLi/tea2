﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="Tea.Web.admin.order.order_list" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>報表管理</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link  href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--導航欄-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>報表管理</span>
  <i class="arrow"></i>
  <span>訂單統計</span>
</div>
<!--/導航欄-->
<!--工具欄-->
<div id="floatHead" class="toolbar-wrap">
    <div class="toolbar">
        <div class="box-wrap">
            <a class="menu-btn"></a>
            <div class="l-list">
                <ul class="icon-list">
                    <li  style="display:none;"><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全選</span></a></li>
                    <li><asp:LinkButton ID="export" runat="server" CssClass="export" OnClick="btnExport_Click"><i></i><span>匯出</span></asp:LinkButton></li>
                </ul>
                <div class="menu-list">
                </div>
            </div>
            <div class="r-list">
                <asp:TextBox ID="txtbegin" runat="server" CssClass="keyword" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" />&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtend" runat="server" CssClass="keyword" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" />&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查詢</asp:LinkButton>
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
    <th width="8%">購買日期</th>
    <th align="left">訂單號碼</th>
    <th align="left">會員</th>
    <th align="left">購買人</th>
    <th align="left">商品編號</th>
    <th align="left">商品名稱</th>
    <th align="center">數量</th>
    <th align="left">單價</th>
    <th align="left">銷售金額</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center"><%#Eval("add_time","{0:yyyy-MM-dd}")%></td>
    <td><%#Eval("order_no").ToString()%></td>
    <td><%#Eval("user_name")%></td>
    <td><%#Eval("accept_name")%></td>
    
    <td><%#Eval("goods_code")%></td>
    <td><%#Eval("goods_title")%></td>
    <td align="center"><%#Eval("quantity")%></td>
    <td>$<%#Eval("real_price")%></td>
    <td>$<%#int.Parse(Eval("quantity").ToString()) * decimal.Parse(Eval("real_price").ToString())%></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暫無記錄</td></tr>" : ""%>
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