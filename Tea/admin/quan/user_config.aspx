<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_config.aspx.cs" Inherits="Tea.Web.admin.users.user_config" ValidateRequest="false" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>系統參數設置</title>
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
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--巡覽列-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>會員管理</span>
  <i class="arrow"></i>
  <span>紅利設定</span>
</div>
<div class="line10"></div>
<!--/巡覽列-->

<!--內容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">紅利設定</a></li>
        <li style="display:none;"><a href="javascript:;">用戶紅利策略</a></li>
      </ul>
    </div>
  </div>
</div>

<!--用戶參數設置-->
<div class="tab-content">
  <dl>
    <dt>訂單金額/紅利兌換比例</dt>
    <dd>
      <asp:TextBox ID="money_pint" runat="server" CssClass="input small" datatype="n" sucmsg=" " />元=1點紅利
      <span class="Validform_checktip">*100元等於多少個紅利，0為關閉兌換功能</span>
    </dd>
  </dl>
  <dl>
    <dt>紅利使用購物金額</dt>
    <dd>
      <asp:TextBox ID="pint_mane" runat="server" CssClass="input small" datatype="n" sucmsg=" " /> 元
      <span class="Validform_checktip">*購物滿 * 元可以使用紅利</span>
    </dd>
  </dl>
  <dl>
    <dt>紅利使用比例</dt>
    <dd>
      <asp:TextBox ID="pint_yong" runat="server" CssClass="input small" datatype="n" sucmsg=" " />%
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
    <dl>
    <dt>紅利抵扣購買金額</dt>
    <dd>
      <asp:TextBox ID="pint_money" runat="server" CssClass="input small" datatype="n" sucmsg=" " />點紅利=1元
      <span class="Validform_checktip">*多少個紅利等於1元，0為關閉兌換功能</span>
    </dd>
  </dl>
</div>
<!--/用戶參數設置-->

 
<!--內容-->

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
