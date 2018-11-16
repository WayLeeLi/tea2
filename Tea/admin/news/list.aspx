<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="Tea.Web.admin.about.article_list" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>內容管理</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
<script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //圖片延遲載入
        $(".pic img").lazyload({ effect: "fadeIn" });
        //點擊圖片連結
        $(".pic img").click(function () {
            var linkUrl = $(this).parent().parent().find(".foot a").attr("href");
            if (linkUrl != "") {
                location.href = linkUrl; //跳轉到修改頁面
            }
        });
    });
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--導航欄-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>網站管理</span>
  <i class="arrow"></i>
  <span>相關信息</span>
</div>
<!--/導航欄-->

<!--工具欄-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
        <li><a class="add" href="edit.aspx?action=<%=TWEnums.ActionEnum.Add %>&channel_id=<%=this.channel_id %>"><i></i><span>新增</span></a></li>
        <li><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>儲存</span></asp:LinkButton></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全選</span></a></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>刪除</span></asp:LinkButton></li>
      </ul>
      <div class="menu-list">
        <div class="rule-single-select">
          <asp:DropDownList ID="ddlCategoryId" runat="server" AutoPostBack="True" onselectedindexchanged="ddlCategoryId_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="rule-single-select" style="display:none;">
          <asp:DropDownList ID="ddlProperty" runat="server" AutoPostBack="True" onselectedindexchanged="ddlProperty_SelectedIndexChanged">
            <asp:ListItem Value="" Selected="True">所有屬性</asp:ListItem>
            <asp:ListItem Value="isMsg">允許評論</asp:ListItem>
            <asp:ListItem Value="isTop">置頂</asp:ListItem>
            <asp:ListItem Value="isRed">推薦</asp:ListItem>
            <asp:ListItem Value="isHot">熱門</asp:ListItem>
            <asp:ListItem Value="isSlide">幻燈片</asp:ListItem>
          </asp:DropDownList>
        </div>
        <div class="rule-single-select" id="statusSelect" runat="server">
          <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
            <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
            <asp:ListItem Value="1">上架</asp:ListItem>
            <asp:ListItem Value="2">下架</asp:ListItem>
          </asp:DropDownList>
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
<!--/工具欄-->
<!--文字清單-->
<asp:Repeater ID="rptList1" runat="server" onitemcommand="rptList_ItemCommand">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">選擇</th>
    <th align="left">標題</th>
    <th align="left">所屬分類</th>
    <th align="left" width="16%">發佈時間</th>
    <th align="left" width="65">排序</th>
    <th width="8%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center"><asp:CheckBox ID="chkId"  CssClass="checkall" runat="server" style="vertical-align:middle;" /><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /></td>
    <td><a href="edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>&url=page|<%=page%>-category_id|<%=category_id%>"><%#Eval("title")%></a>(<a href="/newshow.aspx?id=<%#Eval("id")%>" target="_blank">預覽</a>)</td>
    <td><%#new Tea.BLL.basic().get_basic("news",Eval("category_id").ToString())%></td>
    <td><%#Eval("add_time","{0:yyyy-MM-dd}")%></td>
    <td><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
    <td align="center"><a href="edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>&url=page|<%=page%>-category_id|<%=category_id%>">修改</a> <asp:LinkButton ID="lbtnCopy" Visible="false" CommandName="lbtnCopy" runat="server" Text="複製" /></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
<%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暫無記錄</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/文字清單-->
 
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
