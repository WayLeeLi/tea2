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
          <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全選</span></a></li>
          <li style="display:none;"><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','只允許刪除已退貨訂單，是否繼續？');" onclick="btnDelete_Click"><i></i><span>刪除</span></asp:LinkButton></li>
          <li><asp:LinkButton ID="export" runat="server" CssClass="export" onclick="btnExport_Click"><i></i><span>匯出一</span></asp:LinkButton></li>
           <li><asp:LinkButton ID="exportTwo" runat="server" CssClass="export" onclick="btnExportTwo_Click"><i></i><span>匯出二</span></asp:LinkButton></li>
          <%if (ChkAdminLevel("order_list", "All")){%>
          <li><a class="import" href="javascript:;" onclick="importExcel();"><i></i><span>匯入電子發票號碼</span></a></li>
          <li><a class="save" href="order.xls" target="_blank"><i></i><span>下載示例</span></a></li>
          <%} %>
        </ul>
        <div class="menu-list">
          <div class="rule-single-select">
            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
              <asp:ListItem Value="" Selected="True">全部</asp:ListItem>
             <asp:ListItem Value="1">前往付款</asp:ListItem>
            <asp:ListItem Value="2">待出貨</asp:ListItem>
            <asp:ListItem Value="3">貨已寄出</asp:ListItem>
            <asp:ListItem Value="4">交易完成</asp:ListItem>
            <asp:ListItem Value="5">交易取消</asp:ListItem>
            <asp:ListItem Value="6">退貨完成</asp:ListItem>
            </asp:DropDownList>
          </div>
          <div class="rule-single-select">
            <asp:DropDownList ID="ddlPaymentStatus" runat="server" AutoPostBack="True" onselectedindexchanged="ddlPaymentStatus_SelectedIndexChanged">
              <asp:ListItem Value="0" Selected="True">支付狀態</asp:ListItem>
              <asp:ListItem Value="1">待付款</asp:ListItem>
              <asp:ListItem Value="2">已付款</asp:ListItem>
            </asp:DropDownList>
          </div>
          <div class="rule-single-select">
            <asp:DropDownList ID="ddlExpressStatus" runat="server" AutoPostBack="True" onselectedindexchanged="ddlExpressStatus_SelectedIndexChanged">
              <asp:ListItem Value="0" Selected="True">發貨狀態</asp:ListItem>
              <asp:ListItem Value="1">待發貨</asp:ListItem>
              <asp:ListItem Value="2">已發貨</asp:ListItem>
            </asp:DropDownList>
          </div>
        </div>
      </div>
      <div class="r-list"><div class="rule-single-select" style="float:left; display:none;">
       <asp:DropDownList ID="txtdate" runat="server">
            <asp:ListItem Value="0" Selected="True">請選擇</asp:ListItem>
            <asp:ListItem Value="1">前往付款</asp:ListItem>
            <asp:ListItem Value="2">待出貨</asp:ListItem>
            <asp:ListItem Value="3">貨已寄出</asp:ListItem>
            <asp:ListItem Value="4">交易完成</asp:ListItem>
            <asp:ListItem Value="5">交易取消</asp:ListItem>
            <asp:ListItem Value="6">退貨完成</asp:ListItem>
          </asp:DropDownList> </div>
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
    <th width="8%">選擇</th>
    <th align="left">訂單狀態</th>
    <th align="left">訂單日期</th>
    <th align="left">出貨日期</th>
    <th align="left">訂單編號</th>
    <th align="left">總售價</th>
    <th align="left">收貨人</th>
    <th align="left">手機</th>
    <th align="left">地址</th>
    <th align="left">電子發票</th>
    <th width="8%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
    </td>
    <td><%#GetOrderStatus(Convert.ToInt32(Eval("id")))%></td>
    <td><%#Eval("add_time","{0:yyyy-MM-dd}")%></td>
    <td><%#Eval("express_time", "{0:yyyy-MM-dd}")%></td>
    <td><a href="order_edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&id=<%#Eval("id")%>"><%#Eval("order_no")%></a></td>
    <td><%#Eval("order_amount", "{0:0.}")%></td>
    <td><%#Eval("accept_name")%></td>
    <td><%#Eval("mobile")%></td>
    <td><%#get_order(Eval("area").ToString(),Eval("address").ToString())%></td>
    <td><%#Eval("trade_no")%></td>
    <td align="center"><a href="order_edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&id=<%#Eval("id")%>">查看訂單</a></td>
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
  <div class="l-btns">
    <span>顯示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"  OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>條/頁</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/內容底部-->

</form>
</body>
</html>
