<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_config.aspx.cs" Inherits="Tea.Web.admin.order.order_config" ValidateRequest="false" %>
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
<script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
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
  <span>訂單管理</span>
  <i class="arrow"></i>
  <span>全館折扣</span>
</div>
<div class="line10"></div>
<!--/巡覽列-->
<!--內容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">基本參數設置</a></li>
      </ul>
    </div>
  </div>
</div>
<!--折扣參數設置-->
<div class="tab-content">
  <dl>
    <dt>全館折扣日期區間</dt>
    <dd>
       <asp:TextBox ID="qgbegin" runat="server"  CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" sucmsg=" "></asp:TextBox>~<asp:TextBox ID="qgend" runat="server"  CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" sucmsg=" "></asp:TextBox><span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>全館折扣類型</dt>
    <dd>
       <div class="rule-multi-radio">
        <asp:RadioButtonList ID="qgtype" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1" Selected="True">百分比</asp:ListItem>
        <asp:ListItem Value="2">固定金額</asp:ListItem>
        </asp:RadioButtonList>
       </div>
    </dd>
  </dl>
  <dl>
    <dt>全館折扣百分比</dt>
    <dd>
      <asp:TextBox ID="quanguan" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox>
      <span class="Validform_checktip">% &nbsp;*注意：百分比取值範圍：0-100</span>
    </dd>
  </dl>
  <dl>
    <dt>全館折扣金額</dt>
    <dd>
      <asp:TextBox ID="quanguanjin" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox>
      <span class="Validform_checktip">*元</span>
    </dd>
  </dl>
   <dl>
    <dt>滿額折扣日期區間</dt>
    <dd>
      <asp:TextBox ID="mebegin" runat="server"  CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" sucmsg=" "></asp:TextBox>~  <asp:TextBox ID="meend" runat="server"  CssClass="input rule-date-input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" sucmsg=" "></asp:TextBox><span class="Validform_checktip">*</span>
    </dd>
  </dl>
   <dl>
    <dt>滿額折扣類型</dt>
    <dd>
       <div class="rule-multi-radio">
        <asp:RadioButtonList ID="metype" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1" Selected="True">百分比</asp:ListItem>
        <asp:ListItem Value="2">固定金額</asp:ListItem>
        </asp:RadioButtonList>
       </div>
    </dd>
  </dl>
  <dl>
    <dt>達到滿額金額</dt>
    <dd>
      <asp:TextBox ID="maned" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox>
      <span class="Validform_checktip">*元</span>
    </dd>
  </dl>
  <dl>
    <dt>滿額折扣百分比</dt>
    <dd>
      <asp:TextBox ID="zhekou" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox>
      <span class="Validform_checktip">% &nbsp;*注意：百分比取值範圍：0-100</span>
    </dd>
  </dl>
  <dl>
    <dt>滿額折扣金額</dt>
    <dd>
      <asp:TextBox ID="zkjin" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" sucmsg=" ">0</asp:TextBox>
      <span class="Validform_checktip">*元</span>
    </dd>
  </dl>
  <dl>
    <dt>滿額免運</dt>
    <dd> 設定全館國內滿&nbsp;<asp:TextBox ID="yunmian" runat="server" CssClass="input small" datatype="n" sucmsg=" ">0</asp:TextBox>&nbsp;元,免運費國內運費。金額不足收取運費金額&nbsp;<asp:TextBox ID="yunfei" runat="server" CssClass="input small" datatype="n" sucmsg=" ">0</asp:TextBox>&nbsp;元</dd>
  </dl>
</div>
<!--/折扣參數設置-->
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
