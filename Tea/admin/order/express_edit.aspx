<%@ Page Language="C#" AutoEventWireup="true" CodeFile="express_edit.aspx.cs" Inherits="Tea.Web.admin.order.express_edit" ValidateRequest="false" %>
<%@ Import namespace="Tea.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>編輯OAuth應用</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表單驗證
        $("#form1").initValidform();
        //物流編碼賦值
        $("#ddlExpressCode").change(function () {
            if ($(this).find("option:selected").attr("value") != "") {
                $("#txtExpressCode").val($(this).find("option:selected").attr("value"));
                $("#txtExpressCode").focus();
            }
        });
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--巡覽列-->
<div class="location">
  <a href="express_list.aspx" class="back"><i></i><span>返回列表頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>交易方式設定</span>
  <i class="arrow"></i>
  <span>配送設定</span>
</div>
<div class="line10"></div>
<!--/巡覽列-->

<!--內容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">編輯物流配送</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>標題名稱</dt>
    <dd><asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*物流公司的中文名稱</span></dd>
  </dl>
  <dl style="display:none;">
    <dt>物流編碼</dt>
    <dd>
      <asp:TextBox ID="txtExpressCode" runat="server" CssClass="input normal"   sucmsg=" "></asp:TextBox>
      <div class="rule-single-select">
      </div>
    </dd>
  </dl>

  <dl style="display:none;">
    <dt>配送費用</dt>
    <dd>
      <asp:TextBox ID="txtExpressFee" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox>
      <span class="Validform_checktip">*貨幣格式，單位為元</span>
    </dd>
  </dl>
  <dl>
    <dt>是否啟用</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsLock" runat="server" />
      </div>
      <span class="Validform_checktip">*不啟用則不顯示該配送方式</span>
    </dd>
  </dl>
  <dl>
    <dt>排序數字</dt>
    <dd>
      <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
      <span class="Validform_checktip">*數字，越大越向前</span>
    </dd>
  </dl>
  <dl>
    <dt>描述說明</dt>
    <dd>
      <asp:TextBox ID="txtRemark" runat="server" CssClass="input normal" TextMode="MultiLine" />
      <span class="Validform_checktip">物流配送的描述說明，支持HTML代碼</span>
    </dd>
  </dl>
  <dl>
    <dt>追蹤鏈接</dt>
    <dd>
      <asp:TextBox ID="txtWebSite" runat="server" CssClass="input normal"  errormsg="請輸入正確的網址" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">以“http://”開頭,單號請輸入“{express_no}”</span>
    </dd>
  </dl>
</div>
<!--/內容-->

<!--工具列-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSubmit" runat="server" Text="確認送出" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn"  style="display:none;"type="button" value="返回上一頁" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具列-->

</form>
</body>
</html>
