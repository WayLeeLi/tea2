<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialog_quxiao.aspx.cs" Inherits="Tea.Web.admin.dialog.dialog_express" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>訂單發貨</title>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    var api = top.dialog.get(window); //獲取表單物件
    var W = api.data; //獲取父物件
    //頁面載入完成執行
    $(function () {
        //設置按鈕及事件
        api.button([{
            value: '確定',
            callback: function () {
                submitForm();
            },
            autofocus: true
        }, {
            value: '取消',
            callback: function () { }
        }]);
    });

    //送出表單處理
    function submitForm() {
        var currDocument = $(document); //當前文件
       
        //組合參數
        var postData = {
            "order_no": $("#spanOrderNo", W.document).text(), "edit_type": "order_cancel", "txtdes": $("#txtdes").val()
        };
        //判斷是否需要輸入物流單號
        if ($("#txtdes").val() == "") {
            top.dialog({
                title: '提示',
                content: '請輸入取消訂單理由？',
                okValue: '確定',
                cancelValue: '取消',
                cancel: function () {
                    $("#txtNum", currDocument).focus();
                }
            }).showModal(api);
            return false;
        } else {
            //發送AJAX請求
            W.sendAjaxUrl(api, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
            return false;
        }
        return false;
    }
</script>
</head>

<body>
<form id="form1" runat="server">
<div class="div-content">
  <dl>
    <dt>取消訂單理由</dt>
    <dd><asp:TextBox ID="txtdes" runat="server" TextMode="MultiLine" CssClass="input txt"></asp:TextBox></dd>
  </dl>
</div>
</form>
</body>
</html>
