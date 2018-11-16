<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bao2.aspx.cs" Inherits="Tea.Web.admin.order.order_list" %>
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
  <span>購買月報表</span>
</div>
<!--/導航欄-->
<!--工具欄-->
<div id="floatHead" class="toolbar-wrap">
    <div class="toolbar">
        <div class="box-wrap">
            <a class="menu-btn"></a>
            <div class="l-list">
                <ul class="icon-list">
                    <li style="display:none;"><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全選</span></a></li>
                    <li style="display:none;"><asp:LinkButton ID="export" runat="server" CssClass="export" OnClick="btnExport_Click"><i></i><span>匯出</span></asp:LinkButton></li>
                </ul>
                <div class="menu-list"></div>
            </div>
            <div class="r-list">
                <asp:TextBox ID="txtbegin" runat="server" CssClass="keyword" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" />&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtend" runat="server" CssClass="keyword" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" />&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查詢</asp:LinkButton>
            </div>
        </div>
    </div>
</div>
<!--/工具欄-->
<!--列表-->
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th align="center">月份</th>
    <th align="left">訂單金額</th>
    <th align="left">使用紅利點數</th>
    <th align="center">訂單筆數</th>
    <th align="left">平均訂單金額</th>
  </tr>
 <%for(int a=0;a<=month;a++){ %>
  <tr>
    <td align="center"><%=dt.AddMonths(a).ToString("yyyy-MM")%></td>
    <td><%=getcartprice(dt.AddMonths(a).ToString("yyyy-MM-dd"))%></td>
    <td><%=getcartpoint(dt.AddMonths(a).ToString("yyyy-MM-dd"))%></td>
    <td align="center"><%=getcartnum(dt.AddMonths(a).ToString("yyyy-MM-dd"))%></td>
    <td><%=getpin(dt.AddMonths(a).ToString("yyyy-MM-dd"))%></td>
  </tr>
 <%} %>
 
</table>


<!--/列表-->

<!--內容底部-->
<div class="line20"></div>

<!--/內容底部-->
</form>
</body>
</html>
