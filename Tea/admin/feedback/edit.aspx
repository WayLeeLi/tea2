<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit.aspx.cs" Inherits="Tea.Web.admin.shop_feedback.edit" ValidateRequest="false" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>回覆留言訊息</title>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
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
<!--導航欄-->
<div class="location">
  <a href="list.aspx" class="back"><i></i><span>返回列表頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>網站管理</span>
  <i class="arrow"></i>
  <span>聯繫我們</span>
</div>
<div class="line10"></div>
<!--/導航欄-->

<!--內容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">查看留言</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>姓名</dt>
    <dd><%=model.user_name%></dd>
  </dl>
  <dl>
    <dt>電子郵箱</dt>
    <dd><%=model.user_email%></dd>
  </dl>
  <dl>
    <dt>電話</dt>
    <dd><%=model.user_tel%></dd>
  </dl>
  <dl>
    <dt>主旨</dt>
    <dd><%=model.title %></dd>
  </dl>
  <dl>
    <dt>提問內容</dt>
    <dd><%=model.content %></dd>
  </dl>
  <dl>
    <dt>提問時間</dt>
    <dd><%=model.add_time %></dd>
  </dl>
  <dl>
    <dt>處理狀態</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="0" Selected="True">處理中</asp:ListItem>
        <asp:ListItem Value="1">未回覆</asp:ListItem>
        <asp:ListItem Value="2">已回覆</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>回覆內容</dt>
    <dd><asp:TextBox ID="txtReContent" runat="server" CssClass="input" TextMode="MultiLine"  sucmsg=" " /></dd>
  </dl>
    <dl>
    <dt>備註</dt>
    <dd><asp:TextBox ID="txtBeiZhu" runat="server" CssClass="input" TextMode="MultiLine"  sucmsg=" " /></dd>
  </dl>
  <dl>
    <dt></dt>
    <dd>
    <asp:Button ID="btnSubmit" runat="server" Text="送出回覆" CssClass="btn" onclick="btnSubmit_Click" OnClientClick="javascript:return confirm('是否確定送出回覆?')" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_Submit" runat="server" Text="儲存" CssClass="btn" onclick="btn_Submit_Click" /></dd>
  </dl>
</div>
<!--/內容-->

<!--工具欄-->
<div class="page-footer">
  <div class="btn-list">
   
    <input name="btnReturn"  style="display:none;"type="button" value="返回上一頁" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具欄-->
</form>
</body>
</html>
