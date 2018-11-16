<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="lin_zhe.aspx.cs" Inherits="Tea.Web.admin.users.user_money" ValidateRequest="false" %>
<%@ Import Namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>編輯網站</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表單驗證
        $("#form1").initValidform();
    });
    //新增商品组合
    function showGroupDialog() {
        var goods_ids = "0";
        $("input[name='goods_id']").each(function (i) {
            goods_ids += ("," + $(this).val());
        });
        var groupDialog = top.dialog({
            id: 'groupDialogId',
            padding: 0,
            title: "選擇商品",
            url: 'dialog/dialog_quan_goods.aspx?channel_id=7&goods_ids=' + goods_ids,
            onclose: function () {
                var trHtml = this.returnValue;
                if (trHtml.length > 0) {
                    $("#group_list").append(trHtml);
                }
            }
        }).showModal();

    }
    //刪除组合
    function delGroup(obj) {
        $(obj).parent().parent().remove();
    }
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--導航欄-->
<div class="location">
  <a href="user_list.aspx" class="back"><i></i><span>返回列表頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>會員管理</span>
  <i class="arrow"></i>
  <span>優惠券設定</span>
</div>
<div class="line10"></div>
<!--/導航欄-->

<!--內容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">批次折扣券</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>名稱</dt>
    <dd>
      <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" " />
      <span class="Validform_checktip">*最多100個字元</span>
    </dd>
  </dl>
 <dl>
    <dt>適用商品</dt>
    <dd>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table">
        <thead>
        <tr>
          <th width="300">商品</th>
          <th width="100">規格</th>
          <th width="70">價格</th>
          <th width="70" style="display:none;">数量</th>
          <th>操作</th>
        </tr>
        </thead>
        <tbody  id="group_list">
        <asp:Repeater ID="rptGroup" runat="server">
        <ItemTemplate>
        <tr>
          <td>
              <input name="goods_group_id" type="hidden" value="<%#Eval("id")%>" />
              <input type="hidden" name="parent_id" value="<%#Eval("parent_id")%>" />
              <input type="hidden" name="goods_id" value="<%#Eval("id")%>" />
              <input type="hidden" name="goods_group_title" value="<%#Eval("title")%>" />
              <input type="hidden" name="goods_group_color" value="<%#Eval("color")%>" />
              <input type="hidden" name="original_price" value="<%#Eval("sell_price","{0:0.}")%>" />
              <%#Eval("title")%>
          </td>
          <td><%#Eval("color")%></td>
          <td><%#Eval("sell_price","{0:0.}")%></td>
          <td  style="display:none;"><input class="input small" name="new_price" onkeyup="value=value.replace(/[^\d.]/g,'')" value="<%#Eval("sell_price","{0:0.}")%>" /></td>
          <td><a href="javascript:;" onclick="delGroup(this);">删除</a></td>
        </tr>
        </ItemTemplate>
         </asp:Repeater>
        </tbody>
        <tfoot>
        </tfoot>
      </table>
      <input type="button" class="small-btn" value="選擇商品" onclick="showGroupDialog();" />
    </dd>
  </dl>
  <dl>
    <dt>金額</dt>
    <dd><asp:TextBox id="amount" runat="server" CssClass="input small" datatype="n" sucmsg=" "></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>數量</dt>
    <dd>
        <asp:TextBox ID="txtJin" runat="server" CssClass="input small" datatype="n" sucmsg=" ">0</asp:TextBox>
    </dd>
  </dl>
   <dl>
    <dt>開始時間</dt>
    <dd>
      <div class="input-date">
        <asp:TextBox ID="txtBeginTime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="請選擇正確的日期" sucmsg=" " />
        <i>日期</i>
      </div>
      <span class="Validform_checktip"></span>
    </dd>
  </dl>
  <dl>
    <dt>結束時間</dt>
    <dd>
      <div class="input-date">
        <asp:TextBox ID="txtEndTime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="請選擇正確的日期" sucmsg=" " />
        <i>日期</i>
      </div>
      <span class="Validform_checktip"></span>
    </dd>
  </dl>
</div>
<!--/內容-->

<!--工具欄-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="確認送出" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn"  style="display:none;"type="button" value="返回上一頁" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具欄-->
</form>
</body>
</html>
