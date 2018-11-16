<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialog_import.aspx.cs" Inherits="Tea.Web.admin.dialog.dialog_import" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>導入excel</title>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link  href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    //窗口API
    var api = frameElement.api, W = api.opener;
    api.button({
        name: '確定',
        focus: true,
        callback: function () {
            execImportExcel();
            return false;
        }
    }, { name: '取消'
    });

    //確認事件
    function execImportExcel() {
        if ($("#excelPath").val() != "") {
            $("#btnImport").click();
        }
        else {
            W.$.dialog.alert('請選擇要匯入的Excel文件！', function () { }, api);
            return false;
        }
    };
    $(function () {
    //初始化上傳控件
        $(".upload-img").InitUploader({ sendurl: "../../tools/upload_ajax.ashx", swf: "../../scripts/webuploader/uploader.swf",filetypes: "<%=siteConfig.fileextension %>" });
    });
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div style="margin:50px 0 0 90px;">
        <asp:TextBox ID="excelPath" runat="server" CssClass="input normal upload-path" />
        <div class="upload-box upload-img"></div>
        <asp:Button ID="btnImport" runat="server" Text="upload" OnClick="btnImport_Click" style="display:none;" />
    </div>
</form>
</body>
</html>

