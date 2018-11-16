<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gift_edit.aspx.cs" Inherits="Tea.Web.admin.goods.gift_edit" ValidateRequest="false" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑站点</title>
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

        //初始化编辑器
        var editor = KindEditor.create('.editor', {
            width: '100%',
            height: '350px',
            resizeType: 1,
            uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
            fileManagerJson: '../../tools/upload_ajax.ashx?action=ManagerFile',
            allowFileManager: true
        });

        //初始化上傳控件
        $(".upload-img").InitUploader({ filesize: "<%=siteConfig.imgsize %>", sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf", filetypes: "<%=siteConfig.fileextension %>" });

        //切換活動類型
        var index = $("#ddlType")[0].selectedIndex;
        $("#saleParam dd").hide().eq(index).show();
        $("#ddlType").change(function () {
            var idx = $(this)[0].selectedIndex;
            $("#saleParam dd").hide().eq(idx).show();
          
        })
    })
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--導航欄-->
<div class="location">
  <a href="gift_list.aspx" class="back"><i></i><span>返回列表頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>商品管理</span>
  <i class="arrow"></i>
  <span>贈品管理</span>
</div>
<div class="line10"></div>
<!--/巡覽列-->

<!--內容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">編輯資料</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>適用月份</dt>
    <dd> <div class="rule-single-select">
        <asp:DropDownList id="ddlYear" runat="server"></asp:DropDownList>  
      </div><div class="rule-single-select"><asp:DropDownList id="ddlMonth" runat="server"></asp:DropDownList></div></dd>
  </dl>
  <dl>
    <dt>贈品名稱</dt>
    <dd><asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*4-255" sucmsg=" "></asp:TextBox> <span class="Validform_checktip"></span></dd>
  </dl>
  <dl>
    <dt>品編</dt>
    <dd><asp:TextBox ID="txtCode" runat="server" CssClass="input normal" datatype="*0-255" sucmsg=" "></asp:TextBox> <span class="Validform_checktip"></span></dd>
  </dl>
    <dl>
    <dt>特色標題</dt>
    <dd><asp:TextBox ID="article_list" runat="server" CssClass="input normal" datatype="*4-255" sucmsg=" "></asp:TextBox> <span class="Validform_checktip"></span></dd>
  </dl>
  <dl>
    <dt>封面圖片</dt>
    <dd>
      <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
      <div class="upload-box upload-img"></div>&nbsp;&nbsp;&nbsp;w260*h260
    </dd>
  </dl>
  <dl>
    <dt>贈送方式</dt>
    <dd>
        <div class="rule-single-select">
            <asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem Value="1">滿額贈送</asp:ListItem>
           <%--     <asp:ListItem Value="2">滿件贈送</asp:ListItem>--%>
            </asp:DropDownList>
        </div>
    </dd>
  </dl>
  <dl id="saleParam">
    <dt>參數設定</dt>
    <dd>
      總額滿 <asp:TextBox ID="amount" runat="server" CssClass="input small" onkeyup="value=value.replace(/[^\d.]/g,'')">500</asp:TextBox> 元贈送
    </dd>
    <dd>
      滿 <asp:TextBox ID="quantity" runat="server" CssClass="input small" onkeyup="value=value.replace(/\D/g,'')">2</asp:TextBox> 件贈送
    </dd>
  </dl>
  <dl>
    <dt>是否啟用</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbStatus" runat="server" Checked="false" />
      </div>
      <span class="Validform_checktip">*不啟用則表示該活動結束</span>
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
    <dt>剩餘數量</dt>
    <dd>
      <asp:TextBox ID="txtLeftQuantity" runat="server" CssClass="input small" datatype="n" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip"></span>
    </dd>
  </dl>
  <dl>
    <dt>內容描述</dt>
    <dd>
      <textarea id="txtContent" class="editor" style="visibility:hidden;" runat="server"></textarea>
    </dd>
  </dl>
</div>
<!--/內容-->


<!--工具欄-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="送出儲存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一頁" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具欄-->
</form>
</body>
</html>
