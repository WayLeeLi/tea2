<%@ Page Language="C#" AutoEventWireup="true" CodeFile="slide_edit.aspx.cs" Inherits="Tea.Web.admin.goods.slide_edit" ValidateRequest="false" %>
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
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script><script charset="utf-8" src="../../editor/lang/zh-TW.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表單驗證
        $("#form1").initValidform();

        //初始化上傳控制項
        $(".upload-img").InitUploader({ filesize: "<%=siteConfig.imgsize %>", sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf", filetypes: "<%=siteConfig.fileextension %>" });

    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--導航欄-->
<div class="location">
  <a href="slide_list.aspx" class="back"><i></i><span>返回列表頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>網站管理</span>
  <i class="arrow"></i>
  <span>Banner管理</span>
</div>
<div class="line10"></div>
<!--/導航欄-->

<!--內容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">編輯資料</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>標題名稱</dt>
    <dd><asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip"></span></dd>
  </dl>
  <dl>
    <dt>連結地址</dt>
    <dd><asp:TextBox ID="txtLinkUrl" runat="server" CssClass="input normal" datatype="url" nullmsg="請填寫連結地址" sucmsg=" "></asp:TextBox> <span class="Validform_checktip"></span></dd>
  </dl>
  <%if(!string.IsNullOrEmpty(pic)){ %>
  <dl>
    <dt>預覽圖片</dt>
    <dd>
       <a href="<%=pic%>" target="_blank"><img src="<%=pic%>"  width="100px" height="60px" /></a>
    </dd>
  </dl>
  <%} %>
  <dl>
    <dt>顯示圖片</dt>
    <dd>
      <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
      <div class="upload-box upload-img"></div>&nbsp;w1680*h680
    </dd>
  </dl>
  <dl style="display:none;">
    <dt>所屬品牌</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlBrand" runat="server" sucmsg=" "></asp:DropDownList>
      </div>
      <span class="Validform_checktip">不選擇品牌則在首頁展示</span>
    </dd>
  </dl>
  <dl>
  <dt>開始時間</dt>
    <dd>
      <div class="input-date">
        <asp:TextBox ID="txtStartTime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="請選擇正確的日期" sucmsg=" " />
        <i>日期</i>
      </div>
      <span class="Validform_checktip">不選擇默認當前發佈時間</span>
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
  <dl>
    <dt>排序數字</dt>
    <dd>
      <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
      <span class="Validform_checktip">*數字，越大越向前</span>
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
