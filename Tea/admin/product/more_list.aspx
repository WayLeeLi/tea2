<%@ Page Language="C#" AutoEventWireup="true" CodeFile="more_list.aspx.cs" Inherits="Tea.Web.admin.product.list" %>
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
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
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
    //導入excel
    function importExcel() {
        var importDialog = $.dialog({
            lock: true,
            max: false,
            min: false,
            title: "批次上傳商品",
            content: 'url:dialog/dialog_import.aspx',
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
  <span>商品管理</span>
  <i class="arrow"></i>
  <span>組合商品管理</span>
</div>
<!--/巡覽列-->

<!--工具列-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a class="add" href="more_edit.aspx?action=<%=TWEnums.ActionEnum.Add %>&channel_id=<%=this.channel_id %>"><i></i><span>新增</span></a></li>
          <li><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>儲存</span></asp:LinkButton></li>
          <li style="display:none;"><asp:LinkButton ID="btnAudit" runat="server" CssClass="lock" OnClientClick="return ExePostBack('btnAudit','審核後前台將顯示該資訊，確定繼續嗎？');" onclick="btnAudit_Click"><i></i><span>審核</span></asp:LinkButton></li>
          <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全選</span></a></li>
          <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>刪除</span></asp:LinkButton></li>
          <li style="display:none;"><a class="import" href="javascript:;" onclick="importExcel();"><i></i><span>導入</span></a></li>
          <li style="display:none;"><asp:LinkButton ID="export" runat="server" CssClass="export" onclick="btnExport_Click"><i></i><span>導出</span></asp:LinkButton></li>
<%--      <li><a class="save" href="case.xls" target="_blank"><i></i><span>下載示例</span></a></li>--%>
        </ul>
        <div class="menu-list">
          <div class="rule-single-select">
            <asp:DropDownList ID="ddlCategoryId" runat="server" AutoPostBack="True" onselectedindexchanged="ddlCategoryId_SelectedIndexChanged"></asp:DropDownList>
          </div>
          <div class="rule-single-select" style="display:none;">
            <asp:DropDownList ID="ddlBrandId" runat="server" AutoPostBack="True" onselectedindexchanged="ddlBrandId_SelectedIndexChanged"></asp:DropDownList>
          </div>
          <div class="rule-single-select"  style="display:none;">
            <asp:DropDownList ID="ddlProperty" runat="server" AutoPostBack="True" onselectedindexchanged="ddlProperty_SelectedIndexChanged"></asp:DropDownList>
          </div>
          <div class="rule-single-select">
            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
            <asp:ListItem Text="全部" Value=""></asp:ListItem>
            <asp:ListItem Text="販售中" Value="0"></asp:ListItem>
            <asp:ListItem Text="待審核" Value="1"></asp:ListItem>
            <asp:ListItem Text="上架中" Value="2"></asp:ListItem>
            </asp:DropDownList>
          </div>
          <div class="rule-single-select"  style="display:none;">
            <asp:DropDownList ID="ddlSort" runat="server" AutoPostBack="True" onselectedindexchanged="ddlSort_SelectedIndexChanged">
            <asp:ListItem Text="默認" Value=""></asp:ListItem>
            <asp:ListItem Text="依優惠結束時間" Value="1"></asp:ListItem>
            <asp:ListItem Text="依更新時間" Value="2"></asp:ListItem>
            <asp:ListItem Text="依商品編號" Value="3"></asp:ListItem>
            </asp:DropDownList>
          </div>
        </div>
      </div>
      <div class="r-list">
        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查詢</asp:LinkButton>
        <asp:LinkButton ID="lbtnViewImg" runat="server" CssClass="img-view" onclick="lbtnViewImg_Click" ToolTip="圖像清單視圖" />
        <asp:LinkButton ID="lbtnViewTxt" runat="server" CssClass="txt-view" onclick="lbtnViewTxt_Click" ToolTip="文字清單視圖" />
      </div>
    </div>
  </div>
</div>
<!--/工具列-->

<!--列表-->
<div class="table-container">
  <!--文字清單-->
  <asp:Repeater ID="rptList1" runat="server" onitemcommand="rptList_ItemCommand">
  <HeaderTemplate>
  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
    <tr>
      <th width="6%">選擇</th>
      <th align="left">商品狀態</th>
      <th align="left">商品名稱</th>
      <th align="left">主圖</th>
      <th align="left">原價</th>
      <th align="left">現價</th>
      <th align="left">商品類別</th>
      <th align="left">發佈時間</th>
      <th align="left" width="65">排序</th>
      <th width="10%">操作</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center">
        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
        <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
      </td>
      <td><%#getstatus(Eval("status").ToString())%></td>
      <td><a href="more_edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>&url=page|<%=page%>-category_id|<%=category_id%>-status|<%=status%>-keywords|<%=keywords%>"><%#Eval("title")%></a>(<a href="/shop/show.aspx?id=<%#Eval("id")%>" target="_blank">預覽</a>)</td>
      <td><img src="<%#Eval("img_url")%>" width="100px" height="80px" /></td>
      <td><%#Eval("market_price", "{0:0.}")%></td>
      <td><%#Eval("sell_price", "{0:0.}")%></td>
      <td><%#new Tea.BLL.article_category().GetTitle(Convert.ToInt32(Eval("category_id")))%></td>
      <td><%#Eval("add_time", "{0:yyyy-MM-dd}")%></td>
      <td><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
      <td align="center">
        <a href="more_edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>&url=page|<%=page%>-category_id|<%=category_id%>-status|<%=status%>-keywords|<%=keywords%>">修改</a> <asp:LinkButton ID="lbtnCopy" CommandName="lbtnCopy" runat="server" Text="複製"  style="display:none;" />
      </td>
    </tr>
  </ItemTemplate>
  <FooterTemplate>
  <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暫無記錄</td></tr>" : ""%>
  </table>
  </FooterTemplate>
  </asp:Repeater>
  <!--/文字清單-->

  <!--圖片清單-->
  <asp:Repeater ID="rptList2" runat="server" onitemcommand="rptList_ItemCommand">
  <HeaderTemplate>
  <div class="imglist">
    <ul>
  </HeaderTemplate>
  <ItemTemplate>
      <li>
        <div class="details<%#Eval("img_url").ToString() != "" ? "" : " nopic"%>">
          <div class="check">
            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
          </div>
          <%#Eval("img_url").ToString() != "" ? "<div class=\"pic\"><img width=\"100px\" height=\"180px\"  src=\"../skin/default/loadimg.gif\" data-original=\"" + Eval("img_url") + "\" /></div><i class=\"absbg\"></i>" : ""%>
          <h1><span><a href="more_edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>&url=page|<%=page%>-category_id|<%=category_id%>-status|<%=status%>-keywords|<%=keywords%>"><%#Eval("title")%></a>(<a href="/shop/show.aspx?id=<%#Eval("id")%>" target="_blank">預覽</a>)</span></h1>
          <div class="remark">
            <%#Eval("zhaiyao").ToString() == "" ? "暫無內容摘要說明..." : Eval("zhaiyao").ToString()%>
          </div>
          <div class="tools"  style="display:none;">
            <asp:LinkButton ID="lbtnIsMsg" CommandName="lbtnIsMsg" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_msg")) == 1 ? "msg selected" : "msg"%>' ToolTip='<%# Convert.ToInt32(Eval("is_msg")) == 1 ? "取消評論" : "設置評論"%>' />
            
            <asp:LinkButton ID="lbtnIsSlide" CommandName="lbtnIsSlide" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_slide")) == 1 ? "pic selected" : "pic"%>' ToolTip='<%# Convert.ToInt32(Eval("is_slide")) == 1 ? "取消幻燈片" : "設置幻燈片"%>' />
            <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" />
          </div>
          <div class="foot">
            <p class="time"><%#string.Format("{0:yyyy-MM-dd HH:mm:ss}", Eval("add_time"))%></p>
            <a href="more_edit.aspx?action=<%#TWEnums.ActionEnum.Edit%>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>&url=page|<%=page%>-category_id|<%=category_id%>-status|<%=status%>-keywords|<%=keywords%>" title="編輯" class="edit">編輯</a> <asp:LinkButton ID="lbtnCopy"   style="display:none;" CommandName="lbtnCopy" runat="server" Text="複製" />
          </div>
        </div>
      </li>
  </ItemTemplate>
  <FooterTemplate>
      <%#rptList2.Items.Count == 0 ? "<div align=\"center\" style=\"font-size:12px;line-height:30px;color:#666;\">暫無記錄</div>" : ""%>
    </ul>
  </div>
  </FooterTemplate>
  </asp:Repeater>
  <!--/圖片清單-->
</div>
<!--/列表-->

<!--內容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>顯示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>條/頁</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/內容底部-->

</form>
</body>
</html>
