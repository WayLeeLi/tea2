<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_list.aspx.cs" Inherits="Tea.Web.admin.order.order_list" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>訂單管理</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript">
    //導入excel
    function importExcel() {
        var importDialog = $.dialog({
            lock: true,
            max: false,
            min: false,
            title: "批次上傳電子發票",
            content: 'url:dialog/dialog_order.aspx',
            width: 600,
            height: 150
        });
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--巡覽列-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>訂單管理</span>
  <i class="arrow"></i>
  <span>出貨管理</span>
</div>
<!--/巡覽列-->

<!--工具列-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
        </ul>
        <div class="menu-list">
        </div>
      </div>
      <div class="r-list"> 
        <asp:TextBox ID="txtbegin" runat="server" CssClass="keyword" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" placeholder="日期篩選"/>&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtend" runat="server" CssClass="keyword" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" placeholder="日期篩選" />&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" placeholder="搜尋姓名/單號" />
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
     <th width="4%"></th>
    <th align="left">購買時間</th>
    <th align="left">訂單編號</th>
    <th align="left">訂單狀態</th>
    <th align="left">付款狀態</th>
    <th align="left">訂單金額</th>
    <th align="center">查看</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
    
    </td>
    <td><%#Eval("Date", "{0:yyyy-MM-dd}")%></td>
    <td><%#Eval("OrderNumber")%></td>
    <td><%#Eval("PayType").ToString()=="2"?"已付款":"未付款"%></td>
  
    <td><%#Eval("Status")%></td>
    <td><%#Eval("Pay")%></td>
 
    <td align="center"><a href="order_edit.aspx?id=<%#Eval("OrderNumber")%>">查看訂單</a></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暫無記錄</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
</div>
<!--/列表-->

<!--內容底部-->
<div class="line20"></div>
<div class="pagelist">
 
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/內容底部-->

</form>
</body>
</html>
