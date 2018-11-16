<%@ Page Language="C#" AutoEventWireup="true"  Debug="true"  CodeFile="tuan_edit.aspx.cs" Inherits="Tea.Web.admin.product.edit" ValidateRequest="false" %>
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

        //添加按鈕(點擊綁定)
        $("#itemAddButton").click(function () {
            showImgDialog();
        });


        //切換活動類型
        var index = $("#ddlType")[0].selectedIndex;
        if (index == 0) {
            $("#type1").hide();
            $("#type2").hide();
            $("#type3").hide();
            $("#type4").hide();
            $("#type1").hide();
        }
        if (index == 1) {
            $("#type1").hide();
            $("#type2").hide();
            $("#type3").hide();
            $("#type4").hide();
            $("#type2").show();
        }
        if (index == 2) {
            $("#type1").hide();
            $("#type2").hide();
            $("#type3").hide();
            $("#type4").hide();
            $("#type3").show();
            $("#type4").show();
        }
        $("#ddlType").change(function () {
            var idx = $(this)[0].selectedIndex;
            if (idx == 0) {
                $("#type1").hide();
                $("#type2").hide();
                $("#type3").hide();
                $("#type4").hide();
                $("#type1").hide();
            }
            if (idx == 1) {
                $("#type1").hide();
                $("#type2").hide();
                $("#type3").hide();
                $("#type4").hide();
                $("#type2").show();
            }
            if (idx == 2) {
                $("#type1").hide();
                $("#type2").hide();
                $("#type3").hide();
                $("#type4").hide();
                $("#type3").show();
                $("#type4").show();
            }
        })

    });
 

    //創建窗口
    function showImgDialog(obj) {
        var objNum = arguments.length;
        var d = top.dialog({
            width: 500,
            title: '設定商品規格',
            url: 'dialog/dialog_pic.aspx',
            onclose: function () {
                var trHtml = this.returnValue;
                if (trHtml.length > 0) {
                    $("#item_box").append(trHtml);
                }
            }
        }).showModal();
        //檢查是否修改狀態
        if (objNum == 1) {
            d.data = obj;
        }
    }

    //刪除節點
    function delItemTr(obj) {
        $(obj).parent().parent().remove();
    }
    function joindate() {
        var parentCnt = $("#txtZhuyi").val();
        if (parentCnt.indexOf($("#txtdate").val()) == -1) {
            $("#txtZhuyi").val(parentCnt + $("#txtdate").val() + "\n");
        }
        else {
            alert('該日期已經存在');
            return;
        }
       
    }
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--巡覽列-->
<div class="location">
  <a href="tuan_list.aspx?channel_id=<%=this.channel_id %>" class="back"><i></i><span>返回列表頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>商品管理</span>
  <i class="arrow"></i>
  <span>商品上下架</span>
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
  <dl>
    <dt>商品類別</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlType" runat="server" datatype="*" sucmsg=" " nullmsg="請選擇">
        <asp:ListItem Text="一般商品" Value="1"></asp:ListItem>
        <asp:ListItem Text="預購商品"  Value="2"></asp:ListItem>
        <asp:ListItem Text="特別活動商品"  Value="3"></asp:ListItem>
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
  <dl>
    <dt>推薦類型</dt>
    <dd>
      <div class="rule-multi-checkbox">
        <asp:CheckBoxList ID="cblItem" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1">推薦商品</asp:ListItem>
        <asp:ListItem Value="1">特惠商品</asp:ListItem>
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
  <dl id="type4">
    <dt>活動編號</dt>
    <dd>
      <asp:TextBox ID="txtGuige" runat="server" CssClass="input normal" sucmsg=" " />
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl style="display:none;">
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
    <dt>商品規格</dt>
    <dd>
      <a id="itemAddButton" class="icon-btn add"><i></i><span>設定商品規格</span></a>
      <span class="Validform_checktip">*設定商品規格</span>
    </dd>
  </dl>
  <dl>
    <dt></dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
          <thead>
              <tr>
                <th width="12%">規格</th>
                <th width="12%">貨號</th>
                <th width="20%">圖片</th>
                <th width="12%">市場價</th>
                <th width="12%">銷售價</th>
                <th width="12%">長度</th>
                <th width="12%">寬度</th>
                <th width="12%">高度</th>
                <th width="12%">重量</th>
                <th width="12%">數量</th>
                <th width="10%">操作</th>
              </tr>
            </thead>
            <tbody id="item_box">
                <asp:Repeater ID="data_list" runat="server">
                    <ItemTemplate>
                        <tr class="td_c">
                            <td>
                                <input name="item_color" value="<%#Eval("color")%>" type="hidden">
                                <span class="item_color"><%#Eval("color")%></span>
                            </td>
                            <td>
                                <input name="item_id" value="<%#Eval("id")%>" type="hidden">
                                <input name="item_goods_no" value="<%#Eval("goods_no")%>" type="hidden">
                                <span class="item_goods_no"><%#Eval("goods_no")%></span>
                            </td>
                            <td>
                                <input name="item_imgurl" value="<%#Eval("img_url")%>" type="hidden">
                                <span class="item_imgurl img-box"><img src="<%#Eval("img_url")%>"></span>
                            </td>
                            <td>
                                <input name="item_market_price" value="<%#Eval("market_price","{0:0.}")%>" type="hidden">
                                <span class="item_market_price"><%#Eval("market_price","{0:0.}")%></span>
                            </td>
                            <td>
                                <input name="item_sell_price" value="<%#Eval("sell_price","{0:0.}")%>" type="hidden">
                                <span class="item_sell_price"><%#Eval("sell_price","{0:0.}")%></span>
                            </td>
                            <td>
                                <input name="item_chang" value="<%#Eval("chang")%>" type="hidden">
                                <span class="item_chang"><%#Eval("chang")%></span>
                            </td>
                            <td>
                                <input name="item_kuan" value="<%#Eval("kuan")%>" type="hidden">
                                <span class="item_kuan"><%#Eval("kuan")%></span>
                            </td>
                            <td>
                                <input name="item_gao" value="<%#Eval("gao")%>" type="hidden">
                                <span class="item_gao"><%#Eval("gao")%></span>
                            </td>
                            <td>
                                <input name="item_zhong" value="<%#Eval("zhong")%>" type="hidden">
                                <span class="item_zhong"><%#Eval("zhong")%></span>
                            </td>
                            <td>
                                <input name="item_stock_quantity" value="<%#Eval("stock_quantity")%>" type="hidden">
                                <span class="item_stock_quantity"><%#Eval("stock_quantity")%></span>
                            </td>
                            <td>
                                <a title="編輯" class="img-btn edit operator" onclick="showImgDialog(this);">編輯</a>
                                <a title="刪除" class="img-btn del operator" onclick="delItemTr(this);">刪除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
      </div>
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
  <dl id="type1" style="display:none;">
    <dt>優惠時間</dt>
    <dd>
      <asp:TextBox ID="txtBeginTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="請選擇正確的日期" sucmsg=" " />~  <asp:TextBox ID="txtEndTime" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="請選擇正確的日期" sucmsg=" " />
      <span class="Validform_checktip">優惠時間</span>
    </dd>
  </dl>
  <dl id="type2">
    <dt>預計出貨日期</dt>
    <dd>
        <asp:TextBox ID="txtUpdate" runat="server" CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',minDate:'%y-%M-%d'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="請選擇正確的日期" sucmsg=" " />
      <span class="Validform_checktip">不選擇默認當前發佈時間</span>
    </dd>
  </dl>
  <dl id="type3">
    <dt>期望到貨日期</dt>
    <dd>
     <asp:TextBox ID="txtZhuyi" runat="server" CssClass="input" TextMode="MultiLine"  sucmsg=" "></asp:TextBox><br />
     <input type="text" id="txtdate" class="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',minDate:'%y-%M-%d'})" /><input type="button" value="加入" onclick="joindate()" class="btn" />
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
