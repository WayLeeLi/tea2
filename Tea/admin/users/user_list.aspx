<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_list.aspx.cs" Inherits="Tea.Web.admin.users.user_list" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>會員管理</title>
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
            title: "批次上傳會員",
            content: 'url:dialog/dialog_users.aspx',
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
  <span>會員管理</span>
  <i class="arrow"></i>
  <span>會員列表</span>
</div>
<!--/巡覽列-->

<!--工具列-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a class="add" href="user_edit.aspx?action=<%=TWEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
          <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全選</span></a></li>
          <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>刪除</span></asp:LinkButton></li>
          <li><asp:LinkButton ID="export" runat="server" CssClass="export" onclick="btnExport_Click"><i></i><span>匯出全部</span></asp:LinkButton></li>
          <li><asp:LinkButton ID="export1" runat="server" CssClass="export" onclick="btnExport1_Click"><i></i><span>匯出訂閱會員</span></asp:LinkButton></li>
          <li><a class="import" href="javascript:;" onclick="importExcel();"><i></i><span>導入</span></a></li>
          <li><a class="save" href="user.xls" target="_blank"><i></i><span>下載示例</span></a></li>
        </ul>
        <div class="menu-list">
          <div class="rule-single-select">
              <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
              <asp:ListItem Value="-1" Text="全部"></asp:ListItem>
              <asp:ListItem Value="0" Text="正常"></asp:ListItem>
              <asp:ListItem Value="1" Text="關閉"></asp:ListItem>
            </asp:DropDownList>
          </div>
          <div class="rule-single-select">
              <asp:DropDownList ID="ddlGroupId" runat="server" AutoPostBack="True" onselectedindexchanged="ddlGroupId_SelectedIndexChanged"></asp:DropDownList>
          </div>
        </div>
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
    <th align="left">群組</th>
    <th align="left">會員名</th>
    <th align="left" width="12%">Email</th>
    <th>紅利</th>
    <th>狀態</th>
    <th>是否訂閱</th>
    <th>操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
      <input name="hidMobile" type="hidden" value="<%#Eval("mobile")%>" />
    </td>
    <td><%#new Tea.BLL.user_groups().GetTitle(Utils.StrToInt(Eval("group_id").ToString(),0))%></td>
    <td>
      <div class="user-box">
      <a href="user_edit.aspx?action=<%#TWEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>&cid=<%#Eval("id")%>">
        <h4><b><%#Eval("user_name")%></b> (名字：<%#Eval("nick_name")%>)</h4> </a>
        <i>註冊時間：<%#string.Format("{0:yyyy-MM-dd}",Eval("reg_time"))%></i>
        <span>
         <%-- <a class="point" href="point_log.aspx?keywords=<%#Eval("user_name")%>" title="紅利記錄">紅利</a>--%>
          <a class="amount" href="../order/order_list.aspx?keywords=<%#Eval("user_name")%>" title="訂單紀錄">訂單紀錄</a>
         <%-- <a class="msg" href="../quan/zhe_list.aspx?keywords=<%#Eval("user_name")%>" title="分享優惠券紀錄">分享優惠券紀錄</a>--%>
        </span>
      </div>
    </td>
    <td><%#Eval("email")%></td>
    <td align="center"><%#Eval("point")%></td>
    <td align="center"><%#GetUserStatus(Convert.ToInt32(Eval("status")))%></td>
    <td align="center"><%#Eval("exp").ToString()=="1"?"已訂閱":"未訂閱"%></td>
    <td align="center"><span <%#Eval("group_id").ToString()=="2"?"":" style=\"display:none;\""%>><a href="shop.aspx?action=<%#TWEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>&cid=<%#Eval("id")%>">設定會員商品</a>/<a href="goods.aspx?property=<%#Eval("id")%>&channel_id=7">會員下訂單</a></span></td>
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
    <span>顯示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>條/頁</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/內容底部-->
</form>
</body>
</html>
