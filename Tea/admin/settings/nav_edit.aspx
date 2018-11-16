<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nav_edit.aspx.cs" Inherits="Tea.Web.admin.settings.nav_edit" ValidateRequest="false" %>
<%@ Import namespace="Tea.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>編輯後台導航</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" src="../../scripts/webuploader/webuploader.min.js"></script>
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
  <a href="nav_list.aspx" class="back"><i></i><span>返回列表頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <a href="nav_list.aspx"><span>導航列表</span></a>
  <i class="arrow"></i>
  <span>編輯後台導航</span>
</div>
<div class="line10"></div>
<!--/巡覽列-->

<!--內容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">基本資料</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
   <dl>
    <dt>上級導航</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlParentId" runat="server"></asp:DropDownList>
      </div>
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
    <dt>是否隱藏</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsLock" runat="server" />
      </div>
      <span class="Validform_checktip">*隱藏後不顯示在介面導航功能表中。</span>
    </dd>
  </dl>
  <dl>
    <dt>調用別名</dt>
    <dd>
      <asp:TextBox ID="txtName" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/" errormsg="請填寫正確的ID" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">許可權控制名稱，只允許字母、數字、底線</span>
    </dd>
  </dl>
  <dl>
    <dt>導航標題</dt>
    <dd><asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*導航中文標題，100字元內</span></dd>
  </dl>
  <dl>
    <dt>副標題</dt>
    <dd>
      <asp:TextBox ID="txtSubTitle" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " />
      <span class="Validform_checktip">非必填，當導航擁有兩個名稱時使用</span>
    </dd>
  </dl>
  <dl>
    <dt>自訂圖示</dt>
    <dd>
      <asp:TextBox ID="txtIconUrl" runat="server" maxlength="255"  CssClass="input normal" />
      <div class="upload-box upload-img"></div>
    </dd>
  </dl>
  <dl>
    <dt>連結位址</dt>
    <dd>
      <asp:TextBox ID="txtLinkUrl" runat="server" maxlength="255"  CssClass="input normal upload-path" />
      <span class="Validform_checktip">當前管理目錄，有子導航不用填</span>
    </dd>
  </dl>
  <dl>
    <dt>備註說明</dt>
    <dd>
      <asp:TextBox ID="txtRemark" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
      <span class="Validform_checktip">非必填，可為空</span>
    </dd>
  </dl>
  <dl>
    <dt>許可權資源</dt>
    <dd>
      <div class="rule-multi-porp">
          <asp:CheckBoxList ID="cblActionType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
      </div>
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
