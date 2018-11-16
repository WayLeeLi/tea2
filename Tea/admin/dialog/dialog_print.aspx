<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialog_print.aspx.cs" Inherits="Tea.Web.admin.dialog.dialog_print" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>列印訂單</title>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    var api = top.dialog.get(window); //獲取父表單物件
    //頁面載入完成執行
    $(function () {
        //設置按鈕及事件
        api.button([{
            value: '確認列印',
            callback: function () {
                printWin();
            },
            autofocus: true
        }, {
            value: '取消',
            callback: function () { }
        }]);
    });
    //列印方法
    function printWin() {
        var oWin = window.open("", "_blank");
        oWin.document.write(document.getElementById("content").innerHTML);
        oWin.focus();
        oWin.document.close();
        oWin.print();
        oWin.close();
        return false;
    }
</script>
</head>

<body style="margin:0;">
<form id="form1" runat="server">
<div id="content">
<table width="800" border="0" align="center" cellpadding="3" cellspacing="0" style="font-size:12px; font-family:'微軟雅黑'; background:#fff;">
<tr>
  <td width="346" height="50" style="font-size:20px;"><%=siteConfig.webname%>商品訂單</td>
  <td width="216">訂單號：<%=model.order_no%><br />
日&nbsp;&nbsp; 期：<%=model.add_time.ToString("yyyy-MM-dd")%></td>
  <td width="220">操&nbsp; 作 人：<%=adminModel.user_name%><br />列印時間：<%=DateTime.Now%></td>
</tr>
<tr>
  <td colspan="3" style="padding:10px 0; border-top:1px solid #000;">
  <asp:Repeater ID="rptList" runat="server">
      <HeaderTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="5" style="font-size:12px; font-family:'微軟雅黑'; background:#fff;">
          <tr>
            <td align="left" style="background:#ccc;">商品名稱</th>
            <td width="10%" align="left" style="background:#ccc;">規格</td>
            <td width="10%" align="left" style="background:#ccc;">貨號</td>
            <td width="10%" align="left" style="background:#ccc;">價格</td>
            <td width="10%" align="left" style="background:#ccc;">紅利</td>
            <td width="10%" align="left" style="background:#ccc;">數量</td>
          </tr>
      </HeaderTemplate>
      <ItemTemplate>
          <tr>
            <td>
              <%#Eval("goods_title")%>
            </td>
             <td>
              <%#Eval("spec_text")%>
            </td>
             <td>
              <%#Eval("goods_no")%>
            </td>
             <td>
              <%#Eval("goods_where").ToString() == "point" ? "0" : Eval("real_price","{0:0.}")%>
            </td>
             <td>
              <%#Eval("point")%>
            </td>
            <td><%#Eval("quantity")%></td>
          </tr>
      </ItemTemplate>
      <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暫無記錄</td></tr>" : ""%>
          </table>
     </FooterTemplate>
  </asp:Repeater>
  </td>
  </tr>
<tr>
  <td colspan="3" style="border-top:1px solid #000;">
  <table width="100%" border="0" cellspacing="0" cellpadding="5" style="margin:5px auto; font-size:12px; font-family:'微軟雅黑'; background:#fff;">
    <tr>
      <td width="44%">
        會員帳戶：
        <%if (model.user_id > 0)
          { %>
          <%=model.user_name%>
        <%}
          else
          { %>
          暱名使用者
        <%} %>
      </td>
      <td width="56%">客戶姓名：<%=model.accept_name%><br /></td>
    </tr>
 
    <tr>
      <td>發票抬頭：<%=model.invoice_title%></td>
      <td>發票抬頭：<%=model.invoice_title%></td>
    </tr>
    <tr>
      <td valign="top">支付方式：<%=new Tea.BLL.payment().GetTitle(model.payment_id) %></td>
      <td valign="top">手&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 機：<%=model.mobile%></td>
    </tr>
    <tr>
      <td>配送方式：<%=new Tea.BLL.express().GetTitle(model.express_id)%></td>
      <td>送貨地址： <%=getuseradd(model.user_add,9)%><%=getuseradd(model.user_add,5)%><%=getuseradd(model.user_add,6)%><%=getuseradd(model.user_add,7)%><%=getuseradd(model.user_add,8)%><br /></td>
    </tr>
    <tr>
      <td valign="top" rowspan="2">訂單備註：<%=model.remark%></td>
   
    </tr>
  </table>
    <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" style="border-top:1px solid #000; font-size:12px; font-family:'微軟雅黑'; background:#fff;">
      <tr>
        <td align="right">商品金額：NT$<%=model.real_amount.ToString("0.")%> 優惠券抵扣：NT$<%=model.payment_fee.ToString("0.")%> 紅利兌換：<%=model.point%>點 折扣：NT$<%=model.zhe.ToString("0.")%> 紅利抵扣：NT$<%=model.tuid%>   運費：NT$<%=model.express_fee.ToString("0.")%> 訂單總額：<%=model.order_amount.ToString("0.")%></td>
      </tr>
    </table></td>
  </tr>
</table>
</div>
</form>
</body>
</html>
