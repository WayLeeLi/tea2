<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialog_sales.aspx.cs" Inherits="Tea.Web.admin.dialog.dialog_group" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>內容列表</title>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    var api = top.dialog.get(window); //獲取父表單物件
    api.button([{
        value: '確定',
        callback: function () {
            execGroupHtml();
        },
        autofocus: true
    }, {
        value: '取消',
        callback: function () { return true; }
    }
        ]);

    //確認選擇組合
    //確認選擇組合
    function execGroupHtml() {
        var trhtml = "";
        $(".checkall :checked").each(function (i) {
            var checkedTD = $(this).parents("tr").find("td");
            var parent_id = checkedTD.eq(0).find("input[type='hidden']").eq(1).val();
            var goods_id = checkedTD.eq(0).find("input[type='hidden']").eq(0).val();
            var title = checkedTD.eq(1).html();
            var color = checkedTD.eq(2).html();
            var size = checkedTD.eq(3).html();
            var original_price = checkedTD.eq(4).html();
            trhtml += "<tr>";
            trhtml += "<td>";
            trhtml += "<input name=\"goods_group_id\" type=\"hidden\" value=\"0\" \/>";
            trhtml += "<input type=\"hidden\" name=\"parent_id\" value=\"" + parent_id + "\" \/>";
            trhtml += "<input type=\"hidden\" name=\"goods_id\" value=\"" + goods_id + "\" \/>";
            trhtml += "<input type=\"hidden\" name=\"goods_group_title\" value=\"" + title + "\" \/>";
            trhtml += "<input type=\"hidden\" name=\"goods_group_color\" value=\"" + color + "\" \/>";
            trhtml += "<input type=\"hidden\" name=\"goods_group_size\" value=\"" + size + "\" \/>";
            trhtml += "" + title + "</td>";
            trhtml += "<td>" + color + "</td>";
            trhtml += "<td>" + size + "</td>";
            trhtml += "<td><a href=\"javascript:;\" onclick=\"delGroup(this);\">删除</a></td>";
            trhtml += "</tr>";
        })
        if (trhtml != "") {
            api.close(trhtml).remove();
        }
        else {
            top.dialog({
                title: '提示',
                content: '沒有選擇任何產品！',
                okValue: '確定',
                ok: function () { }
            }).showModal(api);
            return false;
        }
    }
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--工具欄-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <div class="menu-list">
         <div class="rule-single-select">
          <asp:DropDownList ID="ddlCategoryId" runat="server" AutoPostBack="True" onselectedindexchanged="ddlCategoryId_SelectedIndexChanged"></asp:DropDownList>
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
<asp:Repeater ID="rptList1" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%"><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全選</span></a></th>
    <th align="left">產品</th>
    <th align="left">規格</th>
    <th align="left" width="12%">價格</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" /><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /><asp:HiddenField ID="pId" Value='<%#Eval("aid")%>' runat="server" /></td>
    <td><%#Eval("title")%></td>
    <td><%#Eval("guige")%></td>
    <td><%#Eval("sell_price","{0:0.}")%></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
<%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暫無記錄</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/文字清單-->
<!--內容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>顯示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>條/頁</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/內容底部-->
</form>
</body>
</html>
