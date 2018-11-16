<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lin_list.aspx.cs" Inherits="Tea.Web.admin.goods.sales_list" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>網站管理</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    //導入excel
    function importExcel() {
        var importDialog = $.dialog({
            lock: true,
            max: false,
            min: false,
            title: "批次上傳票券",
            content: 'url:dialog/dialog_quan.aspx',
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
  <span>會員管理</span>
  <i class="arrow"></i>
  <span>實體優惠券</span>
</div>
<!--/導航欄-->
<!--工具欄-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
      <ul class="icon-list">
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全選</span></a></li>
        <li style="display:none;"><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>儲存</span></asp:LinkButton></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>刪除</span></asp:LinkButton></li>
        <li><a class="import" href="javascript:;" onclick="importExcel();"><i></i><span>導入</span></a></li>
        <li><a class="save" href="quan.xls" target="_blank"><i></i><span>下載示例</span></a></li>
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
    <th align="left">名稱</th>
    <th align="left">券號</th>
    <th align="left" width="12%">折數金額</th>
    <th align="left" width="12%">數量</th>
    <th align="left" width="15%">開始時間</th>
    <th align="left" width="15%">結束時間</th>
    <th align="left" width="8%">狀態</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("quan_id")%>' runat="server" />
    </td>
    <td><a href="lin_zhe.aspx?action=<%#TWEnums.ActionEnum.Edit%>&id=<%#Eval("quan_id")%>"><%#Eval("quan_title")%></a></td>
    <td><%#Eval("quan_code")%></td>
    <td><%#(Tea.Common.Utils.StrToDecimal(Eval("quan_num").ToString(),0)).ToString("0.")%>元</td>
    <td><%#Eval("quan_sort")%></td>
    <td><%#Eval("quan_begin_date", "{0:yyyy-MM-dd}")%></td>
    <td><%#Eval("quan_end_date", "{0:yyyy-MM-dd}")%></td>
    <td><%#Eval("quan_lock").ToString()=="1"?"使用":"未使用"%></td>
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
