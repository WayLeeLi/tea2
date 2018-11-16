<%@ Page Language="C#" AutoEventWireup="true"  Debug="true"  CodeFile="more_edit.aspx.cs" Inherits="Tea.Web.admin.product.edit" ValidateRequest="false" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>編輯內容</title>
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

        //計算用戶組價格
        $("#txtSell_price").change(function () {
            var sprice = parseFloat($(this).val());
            if (sprice > 0) {
                $(".groupprice").each(function () {
                    var num = parseFloat($(this).attr("discount")) * sprice / 100;
                    $(this).val(ForDight(num, 2));
                });
            }
        });

        //初始化編輯器
        var editor = KindEditor.create('.editor', {
            width: '100%',
            height: '350px',
            resizeType: 1,
            uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
            fileManagerJson: '../../tools/upload_ajax.ashx?action=ManagerFile',
            allowFileManager: true
        });
        var editorMini = KindEditor.create('.editor-mini', {
            width: '100%',
            height: '250px',
            resizeType: 1,
            uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
            items: ['image', 'link']
        });

        //初始化上傳控制項
        $(".upload-img").InitUploader({ filesize: "<%=siteConfig.imgsize %>", sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf", filetypes: "<%=siteConfig.fileextension %>" });
        $(".upload-video").InitUploader({ filesize: "<%=siteConfig.videosize %>", sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf", filetypes: "<%=siteConfig.videoextension %>" });
        $(".upload-album").InitUploader({ btntext: "批次上傳", multiple: true, water: true, thumbnail: true, filesize: "<%=siteConfig.imgsize %>", sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf" });

        //設置封面圖片的樣式
        $(".photo-list ul li .img-box img").each(function () {
            if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
                $(this).parent().addClass("selected");
            }
        });

 
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
            title: "新增組合商品",
            url: 'dialog/dialog_group.aspx?channel_id=7&goods_ids=' + goods_ids,
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
<!--巡覽列-->
<div class="location">
  <a href="more_list.aspx?channel_id=<%=this.channel_id %>" class="back"><i></i><span>返回列表頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>商品管理</span>
  <i class="arrow"></i>
  <span>組合商品管理</span>
</div>
<div class="line10"></div>
<!--/巡覽列-->
<!--內容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">基本資料</a></li>
        <li><a href="javascript:;">詳細描述</a></li>
        <li><a href="javascript:;">SEO選項</a></li>
      </ul>
    </div>
  </div>
</div>
<div class="tab-content">
  <dl>
    <dt>商品類別</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlCategoryId" runat="server" datatype="*" sucmsg=" " nullmsg="請選擇"></asp:DropDownList>
      </div>
    </dd>
  </dl>
  <dl style="display:none;">
    <dt>商品類別</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlType" runat="server" datatype="*" sucmsg=" " nullmsg="請選擇">
        <asp:ListItem Text="組合購"  Value="5"></asp:ListItem>
        </asp:DropDownList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>商品狀態</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="0" Selected="True">販售中</asp:ListItem>
        <asp:ListItem Value="1">待審核</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>
  <dl style="display:none;">
    <dt>推薦類型</dt>
    <dd>
      <div class="rule-multi-checkbox">
        <asp:CheckBoxList ID="cblItem" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1">推薦商品</asp:ListItem>
        <asp:ListItem Value="1">促銷商品</asp:ListItem>
        </asp:CheckBoxList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>更多分類</dt>
    <dd>
       <div class="rule-multi-checkbox">
        <asp:CheckBoxList ID="cbMore" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>配送⾄海外</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsLock" runat="server" />
      </div>
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>商品名稱</dt>
    <dd>
      <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*2-30" sucmsg=" "  nullmsg="請填寫商品名稱 " />
      <span class="Validform_checktip">*限制30個(含)中文字以內</span>
    </dd>
  </dl>
  <dl>
    <dt>特色標題</dt>
    <dd>
      <asp:TextBox ID="txtSub_title" runat="server" CssClass="input normal" TextMode="MultiLine" datatype="*1-115" sucmsg=" "  nullmsg="請填寫商品簡介! " />
      <span class="Validform_checktip">*字數限制為115個(含)中文字以內</span>
    </dd>
  </dl>
  <dl>
    <dt>商品主圖</dt>
    <dd>
      <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
      <div class="upload-box upload-img"></div>&nbsp;&nbsp;&nbsp;w260*h260或者w800*h800
    </dd>
  </dl>
  <dl>
    <dt>商品貨號</dt>
    <dd>
      <asp:TextBox ID="txtGoods_no" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " />
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>原價</dt>
    <dd>
      <asp:TextBox ID="txtMarket_price" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox> 元
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>優惠價</dt>
    <dd>
      <asp:TextBox ID="txtSell_price" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox> 元
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
    <dl>
    <dt>長度</dt>
    <dd>
      <asp:TextBox ID="txtChang" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox> cm
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
    <dl>
    <dt>寬度</dt>
    <dd>
      <asp:TextBox ID="txtKuan" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox> cm
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
    <dl>
    <dt>高度</dt>
    <dd>
      <asp:TextBox ID="txtGao" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox> cm
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
    <dl>
    <dt>重量</dt>
    <dd>
      <asp:TextBox ID="txtZhong" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox> kg
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>庫存</dt>
    <dd>
      <asp:TextBox ID="txtStock_quantity" runat="server" CssClass="input small" datatype="n" sucmsg=" ">0</asp:TextBox>
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>商品規格</dt>
    <dd>
      <asp:TextBox ID="txtGuige" runat="server" CssClass="input normal" sucmsg=" " />
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>組合商品</dt>
    <dd>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table">
        <thead>
        <tr>
          <th width="300">商品</th>
          <th width="100">規格</th>
          <th width="70">價格</th>
          <th width="70">数量</th>
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
              <input type="hidden" name="goods_id" value="<%#Eval("goods_id")%>" />
              <input type="hidden" name="goods_group_title" value="<%#Eval("title")%>" />
              <input type="hidden" name="goods_group_color" value="<%#Eval("color")%>" />
              <input type="hidden" name="original_price" value="<%#Eval("original_price","{0:0.}")%>" />
              <%#Eval("title")%>
          </td>
          <td><%#Eval("color")%></td>
          <td><%#Eval("original_price","{0:0.}")%></td>
          <td><input class="input small" name="new_price" onkeyup="value=value.replace(/[^\d.]/g,'')" value="<%#Eval("new_price","{0:0.}")%>" /></td>
          <td><a href="javascript:;" onclick="delGroup(this);">删除</a></td>
        </tr>
        </ItemTemplate>
         </asp:Repeater>
        </tbody>
        <tfoot>
        </tfoot>
      </table>
      <input type="button" class="small-btn" value="新增组合商品" onclick="showGroupDialog();" />
    </dd>
  </dl>
  <asp:Repeater ID="rptPrice" runat="server">
  <HeaderTemplate>
  <dl>
    <dt>會員價格</dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table">
       </HeaderTemplate>
        <ItemTemplate>
        <tr>
          <th width="20%"><%#Eval("title")%></th>
          <td width="80%">
            <asp:HiddenField ID="hidePriceId" runat="server" />
            <asp:HiddenField ID="hideGroupId" Value='<%#Eval("id") %>' runat="server" />
            <asp:TextBox ID="txtGroupPrice" runat="server" discount='<%#Eval("discount") %>' CssClass="td-input groupprice" maxlength="10" style="width:60px;" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox>
            <span class="Validform_checktip">*享受<%#Eval("discount")%>折優惠</span>
          </td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>
      </div>
    </dd>
  </dl>
  </FooterTemplate>
  </asp:Repeater>
  <dl style="display:none;">
    <dt>紅利</dt>
    <dd>
      <asp:TextBox ID="txtPoint" runat="server" CssClass="input small" datatype="/^-?\d+$/" sucmsg=" ">0</asp:TextBox>
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>排序數字</dt>
    <dd>
      <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" " nullmsg="請填寫排序數字">99</asp:TextBox>
      <span class="Validform_checktip">*數字，越大越向前</span>
    </dd>
  </dl>
  <dl style="display:none;">
    <dt>瀏覽次數</dt>
    <dd>
      <asp:TextBox ID="txtClick" runat="server" CssClass="input small" datatype="n" sucmsg=" ">0</asp:TextBox>
      <span class="Validform_checktip">點擊瀏覽該資訊自動+1</span>
    </dd>
  </dl>
  <dl>
    <dt>優惠時間</dt>
    <dd>
      <asp:TextBox ID="txtBeginTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="請選擇正確的日期" sucmsg=" " />~  <asp:TextBox ID="txtEndTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="請選擇正確的日期" sucmsg=" " />
      <span class="Validform_checktip">優惠時間不一樣才會啟用，同一天則為不限制銷售時間</span>
    </dd>
  </dl>
  <dl style="display:none;">
    <dt>預計出貨日期</dt>
    <dd>
        <asp:TextBox ID="txtUpdate" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',minDate:'%y-%M-%d'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="請選擇正確的日期" sucmsg=" " />
      <span class="Validform_checktip">不選擇默認當前發佈時間-</span>
    </dd>
  </dl>
  <dl>
    <dt>發佈時間</dt>
    <dd>
      <asp:TextBox ID="txtAddTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="請選擇正確的日期" sucmsg=" " />~  <asp:TextBox ID="txt_Xia_Date" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="請選擇正確的日期" sucmsg=" " />
      <span class="Validform_checktip">不選擇默認當前發佈時間</span>
    </dd>
  </dl>
  <dl ID="div_albums_container" runat="server">
    <dt>圖片相冊 w800*h800</dt>
    <dd>
      <div class="upload-box upload-album"></div>
      <input type="hidden" name="hidFocusPhoto" id="hidFocusPhoto" runat="server" class="focus-photo" />
      <div class="photo-list">
        <ul>
          <asp:Repeater ID="rptAlbumList" runat="server">
            <ItemTemplate>
            <li>
              <input type="hidden" name="hid_photo_name" value="<%#Eval("id")%>|<%#Eval("original_path")%>|<%#Eval("thumb_path")%>" />
              <input type="hidden" name="hid_photo_remark" value="<%#Eval("remark")%>" />
              <div class="img-box" onclick="setFocusImg(this);">
                <img src="<%#Eval("thumb_path")%>" bigsrc="<%#Eval("original_path")%>" />
                <span class="remark"><i><%#Eval("remark").ToString() == "" ? "暫無描述..." : Eval("remark").ToString()%></i></span>
              </div>
              <a href="javascript:;" onclick="setRemark(this);">描述</a>
              <a href="javascript:;" onclick="delImg(this);">刪除</a>
            </li>
            </ItemTemplate>
          </asp:Repeater>
        </ul>
      </div>
    </dd>
  </dl>
</div>
<div class="tab-content" style="display:none">
  <dl style="display:none">
    <dt>調用別名</dt>
    <dd>
      <asp:TextBox ID="txtCallIndex" runat="server" CssClass="input normal" datatype="/^\s*$|^[a-zA-Z0-9\-\_]{2,50}$/" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*別名訪問，非必填，不可重複</span>
    </dd>
  </dl>
  <dl style="display:none">
    <dt>URL連結</dt>
    <dd>
      <asp:TextBox ID="txtLinkUrl" runat="server" maxlength="255"  CssClass="input normal" />
      <span class="Validform_checktip">填寫後直接跳轉到該網址</span>
    </dd>
  </dl>
  <dl style="display:none">
    <dt>內容摘要</dt>
    <dd>
      <asp:TextBox ID="txtZhaiyao" runat="server" CssClass="input" TextMode="MultiLine" datatype="*0-255" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">不填寫則自動截取內容前255字元</span>
    </dd>
  </dl>
  <dl>
    <dt>商品介紹</dt>
    <dd><asp:TextBox ID="txtTag" runat="server"  CssClass="input normal" placeholder="說明一" /><br />
      <textarea id="txtContent" class="editor" style="visibility:hidden;" runat="server"></textarea>
    </dd>
  </dl>
    <dl>
    <dt>商品詳細規格</dt>
    <dd><asp:TextBox ID="txtTag1" runat="server"  CssClass="input normal" placeholder="說明二" /><br />
      <textarea id="txtGuigeMore" class="editor" style="visibility:hidden;" runat="server"></textarea>
    </dd>
  </dl>
    <dl>
    <dt>包裝說明</dt>
    <dd><asp:TextBox ID="txtTag2" runat="server"  CssClass="input normal" placeholder="說明三" /><br />
      <textarea id="txtShuo" class="editor" style="visibility:hidden;" runat="server"></textarea>
    </dd>
  </dl>
</div>
<div class="tab-content" style="display:none">
  <dl>
    <dt>SEO標題</dt>
    <dd>
      <asp:TextBox ID="txtSeoTitle" runat="server" maxlength="255"  CssClass="input normal" datatype="*0-100" sucmsg=" " />
      <span class="Validform_checktip">255個字元以內</span>
    </dd>
  </dl>
  <dl>
    <dt>SEO關鍵字</dt>
    <dd>
      <asp:TextBox ID="txtSeoKeywords" runat="server" CssClass="input" TextMode="MultiLine" datatype="*0-255" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">以“,”逗號區分開，255個字元以內</span>
    </dd>
  </dl>
  <dl>
    <dt>SEO描述</dt>
    <dd>
      <asp:TextBox ID="txtSeoDescription" runat="server" CssClass="input" TextMode="MultiLine" datatype="*0-255" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">255個字元以內</span>
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
