<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payment_edit.aspx.cs" Inherits="Tea.Web.admin.order.payment_edit" ValidateRequest="false" %>
<%@ Import namespace="Tea.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>編輯付款方式</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
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
        //初始化上傳控制項
        $(".upload-img").InitUploader({ sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf" });
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--巡覽列-->
<div class="location">
  <a href="payment_list.aspx" class="back"><i></i><span>返回列表頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>交易方式設定</span>
  <i class="arrow"></i>
  <span>支付設定</span>
</div>
<div class="line10"></div>
<!--/巡覽列-->

<!--內容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">設定付款方式</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>付款名稱</dt>
    <dd><asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
  <dl style="display:none;">
    <dt>付款類型</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1" Selected="True">線上付款</asp:ListItem>
        <asp:ListItem Value="2">線下付款</asp:ListItem>
        </asp:RadioButtonList>
      </div>
      <span class="Validform_checktip">*線上付款自動驗證付款狀態</span>
    </dd>
  </dl>
  <dl>
    <dt>是否啟用</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsLock" runat="server" />
      </div>
      <span class="Validform_checktip">*不啟用則不顯示該付款方式</span>
    </dd>
  </dl>
  <dl>
    <dt>排序數字</dt>
    <dd>
      <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
      <span class="Validform_checktip">*數字，越大越向前</span>
    </dd>
  </dl>
  <dl  style="display:none;">
    <dt>手續費類型</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblPoundageType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1" Selected="True">百分比</asp:ListItem>
        </asp:RadioButtonList>
      </div>
      <span class="Validform_checktip">*百分比的計算公式：商品總金額+(商品總金額*百分比)+配送費用=訂單總金額</span>
    </dd>
  </dl>
  <dl style="display:none;">
    <dt>付款手續費</dt>
    <dd>
      <asp:TextBox ID="txtPoundageAmount" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox>
      <span class="Validform_checktip">*注意：百分比取值範圍：0-100</span>
    </dd>
  </dl>
  <%if (model.api_path.ToLower()=="alipaypc")
    { %>
  <dl>
    <dt>付款寶帳號</dt>
    <dd>
      <asp:TextBox ID="txtAlipaySellerEmail" runat="server" CssClass="input normal" datatype="*" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*簽約付款寶帳號或賣家付款寶帳戶</span>
    </dd>
  </dl>
  <dl>
    <dt>合作者身份(partner ID)</dt>
    <dd>
      <asp:TextBox ID="txtAlipayPartner" runat="server" CssClass="input normal" datatype="*" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*合作身份者ID，以2088開頭由16位純數字組成的字串</span>
    </dd>
  </dl>
  <dl>
    <dt>交易安全校驗碼(key)</dt>
    <dd>
      <asp:TextBox ID="txtAlipayKey" runat="server" CssClass="input normal" datatype="*" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*交易安全檢驗碼，由數字和字母組成的32位字串</span>
    </dd>
  </dl>
  <dl>
    <dt>介面類別型</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblAlipayType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1" Selected="True">即時到帳</asp:ListItem>
        <asp:ListItem Value="2">擔保交易</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>
  <%}
    else if (model.api_path.ToLower()=="tenpaypc")
    { %>
  <dl>
    <dt>財付通商戶號</dt>
    <dd>
      <asp:TextBox ID="txtTenpayBargainorId" runat="server" CssClass="input normal" datatype="*" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*財付通商家服務商戶號</span>
    </dd>
  </dl>
  <dl>
    <dt>財付通金鑰</dt>
    <dd>
      <asp:TextBox ID="txtTenpayKey" runat="server" CssClass="input normal" datatype="*" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*財付通商家服務金鑰</span>
    </dd>
  </dl>
  <dl>
    <dt>介面類別型</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblTenpayType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1" Selected="True">即時到帳</asp:ListItem>
        <asp:ListItem Value="2">擔保交易</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>
  <%} %>
  <dl>
    <dt>顯示圖示</dt>
    <dd>
      <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
      <div class="upload-box upload-img"></div>
    </dd>
  </dl>
  <dl>
    <dt>描述說明</dt>
    <dd>
      <asp:TextBox ID="txtRemark" runat="server" CssClass="input normal" TextMode="MultiLine" />
      <span class="Validform_checktip">付款方式的描述說明，支援HTML代碼</span>
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
