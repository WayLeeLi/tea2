<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialog_pic.aspx.cs" Inherits="Tea.Web.admin.dialog.dialog_pic" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>上傳圖片</title>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    var api = top.dialog.get(window); //獲取父表單物件
    //頁面載入完成執行
    $(function () {
        //設置按鈕及事件
        api.button([{
            value: '確定',
            callback: function () {
                execPicHtml();
            },
            autofocus: true
        }, {
            value: '取消',
            callback: function () { return true; }
        }
        ]);
        //初始化上傳控制項
        $(".upload-img").InitUploader({ sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf" });
        //修改狀態，賦值給表單
        if ($(api.data).length > 0) {
            var parentObj = $(api.data).parent().parent();
            $("#txtcolor").val(parentObj.find("input[name='item_color']").val());
            $("#txtgoods_no").val(parentObj.find("input[name='item_goods_no']").val());
            $("#txtImgUrl").val(parentObj.find("input[name='item_imgurl']").val());
            $("#txtmarket_price").val(parentObj.find("input[name='item_market_price']").val());
            $("#txtsell_price").val(parentObj.find("input[name='item_sell_price']").val());
            $("#txtchang").val(parentObj.find("input[name='item_chang']").val());
            $("#txtkuan").val(parentObj.find("input[name='item_kuan']").val());
            $("#txtgao").val(parentObj.find("input[name='item_gao']").val());
            $("#txtzhong").val(parentObj.find("input[name='item_zhong']").val());
            $("#txtstock_quantity").val(parentObj.find("input[name='item_stock_quantity']").val());
        }
    });

    //創建選項節點
    function execPicHtml() {
        var currDocument = $(document); //當前文檔
        if ($("#txtcolor").val() == "") {
            top.dialog({
                title: '提示',
                content: '規格不可為空！',
                okValue: '確定',
                ok: function () { },
                onclose: function () {
                    $("#txtcolor", currDocument).focus();
                }
            }).showModal(api);
            return false;
        }
        if ($("#txtgoods_no").val() == "") {
            top.dialog({
                title: '提示',
                content: '貨號不可為空！',
                okValue: '確定',
                ok: function () { },
                onclose: function () {
                    $("#txtgoods_no", currDocument).focus();
                }
            }).showModal(api);
            return false;
        }
        if ($("#txtImgUrl").val() == "") {
            top.dialog({
                title: '提示',
                content: '圖片路徑不可為空！',
                okValue: '確定',
                ok: function () { },
                onclose: function () {
                    $("#txtImgUrl", currDocument).focus();
                }
            }).showModal(api);
            return false;
        }
        if ($("#txtchang").val() == "") {
            top.dialog({
                title: '提示',
                content: '長度不可為空！',
                okValue: '確定',
                ok: function () { },
                onclose: function () {
                    $("#txtchang", currDocument).focus();
                }
            }).showModal(api);
            return false;
        }
        if ($("#txtkuan").val() == "") {
            top.dialog({
                title: '提示',
                content: '寬度不可為空！',
                okValue: '確定',
                ok: function () { },
                onclose: function () {
                    $("#txtkuan", currDocument).focus();
                }
            }).showModal(api);
            return false;
        }
        if ($("#txtgao").val() == "") {
            top.dialog({
                title: '提示',
                content: '高度不可為空！',
                okValue: '確定',
                ok: function () { },
                onclose: function () {
                    $("#txtgao", currDocument).focus();
                }
            }).showModal(api);
            return false;
        }
        if ($("#txtstock_quantity").val() == "") {
            top.dialog({
                title: '提示',
                content: '數量數量不可為空！',
                okValue: '確定',
                ok: function () { },
                onclose: function () {
                    $("#txtstock_quantity", currDocument).focus();
                }
            }).showModal(api);
            return false;
        }
        //創建選項節點的HTML
        if ($(api.data).length > 0) {
            var parentObj = $(api.data).parent().parent();

            parentObj.find("input[name='item_color']").val($("#txtcolor").val());
            parentObj.find("input[name='item_goods_no']").val($("#txtgoods_no").val());
            parentObj.find("input[name='item_imgurl']").val($("#txtImgUrl").val());
            parentObj.find("input[name='item_market_price']").val($("#txtmarket_price").val());
            parentObj.find("input[name='item_sell_price']").val($("#txtsell_price").val());
            parentObj.find("input[name='item_chang']").val($("#txtchang").val());
            parentObj.find("input[name='item_kuan']").val($("#txtkuan").val());
            parentObj.find("input[name='item_gao']").val($("#txtgao").val());
            parentObj.find("input[name='item_zhong']").val($("#txtzhong").val());
            parentObj.find("input[name='item_stock_quantity']").val($("#txtstock_quantity").val());

            parentObj.find(".item_color").html($("#txtcolor").val());
            parentObj.find(".item_goods_no").html($("#txtgoods_no").val());
          
            if ($("#txtImgUrl").val() == "") {
                parentObj.find(".item_imgurl").html("-");
            } else {
                parentObj.find(".item_imgurl").html('<img src="' + $("#txtImgUrl").val() + '" width="32" height="32" />');
            }
            parentObj.find(".item_market_price").html($("#txtmarket_price").val());
            parentObj.find(".item_sell_price").html($("#txtsell_price").val());
            parentObj.find(".item_chang").html($("#txtchang").val());
            parentObj.find(".item_kuan").html($("#txtkuan").val());
            parentObj.find(".item_gao").html($("#txtgao").val());
            parentObj.find(".item_zhong").html($("#txtzhong").val());
            parentObj.find(".item_stock_quantity").html($("#txtstock_quantity").val());

            api.close();
        } else {
            var liHtml = '<tr class="td_c">'
            + '<td><input type="hidden" name="item_color" value="' + $("#txtcolor").val() + '" />'
            + '<span class="item_color">' + $("#txtcolor").val() + '</span></td>'
            + '<td><input type="hidden" name="item_id" value="0" />'
            + '<input type="hidden" name="item_goods_no" value="' + $("#txtgoods_no").val() + '" />'
            + '<span class="item_goods_no">' + $("#txtgoods_no").val() + '</span></td>'

            + '<td><input type="hidden" name="item_imgurl" value="' + $("#txtImgUrl").val() + '" />'
            + '<span class="item_imgurl img-box"><img src="' + $("#txtImgUrl").val() + '" /></span></td>'
            + '<td><input type="hidden" name="item_market_price" value="' + $("#txtmarket_price").val() + '" />'
            + '<span class="item_market_price">' + $("#txtmarket_price").val() + '</span></td>'
            + '<td><input type="hidden" name="item_sell_price" value="' + $("#txtsell_price").val() + '" />'
            + '<span class="item_sell_price">' + $("#txtsell_price").val() + '</span></td>'
            + '<td><input type="hidden" name="item_chang" value="' + $("#txtchang").val() + '" />'
            + '<span class="item_chang">' + $("#txtchang").val() + '</span></td>'
            + '<td><input type="hidden" name="item_kuan" value="' + $("#txtkuan").val() + '" />'
            + '<span class="item_kuan">' + $("#txtkuan").val() + '</span></td>'
            + '<td><input type="hidden" name="item_gao" value="' + $("#txtgao").val() + '" />'
            + '<span class="item_gao">' + $("#txtgao").val() + '</span></td>'
            + '<td><input type="hidden" name="item_zhong" value="' + $("#txtzhong").val() + '" />'
            + '<span class="item_zhong">' + $("#txtzhong").val() + '</span></td>'
            + '<td><input type="hidden" name="item_stock_quantity" value="' + $("#txtstock_quantity").val() + '" />'
            + '<span class="item_stock_quantity">' + $("#txtstock_quantity").val() + '</span></td>'
            + '<td><a title="編輯" class="img-btn edit operator" onclick="showImgDialog(this);">編輯</a>'
            + '<a title="刪除" class="img-btn del operator" onclick="delItemTr(this);">刪除</a></td>';
            api.close(liHtml).remove();
        }
        return false;
    }
</script>
</head>
<body>
<form id="form1" runat="server">
<div class="div-content">
  <dl>
    <dt>規格</dt>
    <dd><input type="text" id="txtcolor" class="input txt"  /></dd>
  </dl>
  <dl>
    <dt>貨號</dt>
    <dd><input type="text" id="txtgoods_no" class="input txt" /></dd>
  </dl>
  <dl>
    <dt>上傳圖片</dt>
    <dd>
      <input type="text" id="txtImgUrl" class="input txt upload-path" />
      <div class="upload-box upload-img"></div>&nbsp;w800*h800
    </dd>
  </dl>
  <dl>
    <dt>市場價</dt>
    <dd><input type="text" id="txtmarket_price" value="99" class="input txt small" onkeydown="return checkNumber(event);" /></dd>
  </dl>
  <dl>
    <dt>銷售價</dt>
    <dd><input type="text" id="txtsell_price" value="99" class="input txt small" onkeydown="return checkNumber(event);" /></dd>
  </dl>
  <dl>
    <dt>長度</dt>
    <dd><input type="text" id="txtchang" value="99" class="input txt small" onkeydown="return checkForFloat(event);" />cm</dd>
  </dl>
  <dl>
    <dt>寬度</dt>
    <dd><input type="text" id="txtkuan" value="99" class="input txt small" onkeydown="return checkForFloat(event);" />cm</dd>
  </dl>
  <dl>
    <dt>高度</dt>
    <dd><input type="text" id="txtgao" value="99" class="input txt small" onkeydown="return checkForFloat(event);" />cm</dd>
  </dl>
  <dl>
    <dt>重量</dt>
    <dd><input type="text" id="txtzhong" value="99" class="input txt small" onkeydown="return checkForFloat(event);" />kg</dd>
  </dl>
  <dl>
    <dt>數量</dt>
    <dd><input type="text" id="txtstock_quantity" value="99" class="input txt small" onkeydown="return checkNumber(event);" /></dd>
  </dl>
</div>
</form>
</body>
</html>
