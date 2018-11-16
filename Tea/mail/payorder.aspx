<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payorder.aspx.cs" Inherits="order" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title></title>
<style type="text/css">
.embg {
	background-image: url(enbg.jpg);
	width: 770px;
	background-color: #E3E3E3;
	background-repeat: no-repeat;
	background-position: center top;
	padding-top: 130px;
	padding-right: 15px;
	padding-bottom: 15px;
	padding-left: 15px;
}
.embg .emkz {
	background-color: #FFF;
	padding: 10px;
	background-image: url(wl.png);
	background-position: 550px bottom;
	background-repeat: no-repeat;
	font-size: 16px;
	-moz-border-radius: 8px;   /* 圆的半径为边长的一半，即300px */
	-webkit-border-radius: 8px;
	border-radius: 8px;
}
.fs {
	color: #fe0000;
	font-family: "Microsoft JhengHei";
}
.embg .emkz .emlr {
	min-height: 300px;
	margin-bottom: 45px;
}
 a {
	color: #fe0000;
}
.lanse {
	color: #189eb6;
}
.rz-btn {height: 45px;
}
.tit{ border-bottom:1px dashed #ccc;border-top:1px dashed #ccc; padding:10px 0}
</style>
</head>

<body>
<div class="embg">
  <div class="emkz">
    <div class="emlr">
      <p>親愛的 <span class="fs"><%=model.accept_name%></span> 您好：</p>
<p>您的訂單已經下單請盡快付款</p>
   	  <p class="fs">天仁茗茶購物網提醒您，天仁茗茶購物網不會以電話通知更改付款方式或要求重新轉帳，亦不會要求提供信用卡帳號或ATM匯款帳號等，更無提供信用卡分期付款機制。</p>
   <p class="tit">以下是您本次的交易明細</p>
      <p>交易時間：	<span class="fs"><%=model.add_time.ToString("yyyy-MM-dd HH:mm:ss")%></span></p>
      <p>訂單編號：<span class="fs"><%=model.order_no %></span></p>
      <p>商品明細：</p>
      <div><table width="100%" border="1" cellpadding="3" cellspacing="0">
  <tbody>
    <tr>
      <td width="60" height="40" align="center">商品</td>
      <td height="40" align="center">&nbsp;</td>
      <td height="40" align="center">數量</td>
      <td height="40" align="center">規格</td>
      <td height="40" align="center">價格</td>
    </tr>
    <asp:Repeater ID="data_cart" runat="server"><ItemTemplate>
    <tr>
      <td width="60" align="center"><img src="<%=weburl%><%#Eval("goods_img")%>" width="46" height="37" alt=""/></td>
      <td align="left"><%#Eval("goods_title")%></td>
      <td align="center"><%#Eval("quantity")%></td>
      <td align="center"><%#Eval("spec_text")%></td>
      <td align="center">NT$ <%#Tea.Common.Utils.StrToInt(Eval("quantity").ToString(), 0) * Tea.Common.Utils.StrToInt(Eval("real_price").ToString(), 0)%></td>
    </tr>
    </ItemTemplate></asp:Repeater>
  </tbody>
</table>
<div style="clear:both"></div>
</div>
<p class="tit">送貨資料</p>
      <p>購買人姓名：<span class="fs">  <%=model.accept_name%></span></p>
      <p>聯絡電話：<span class="fs"> <%=model.telphone%></span></p>
      <p>郵遞區號：<span class="fs"> <%=model.post_code %></span></p>
      <p>所在地：<span class="fs">  <%=model.area%><%=model.address%></span></p>
      <p>發票：<span class="fs">  <%=getinvoice(model.is_invoice.ToString())%></span></p>
 
      <p>發票資料</p>
    <p>收貨人姓名：<span class="fs">  <%=getuseradd(model.user_add,0)%></span><%=getuseradd(model.user_add,1)%></p>
      <p>聯絡電話：<span class="fs">  <%=getuseradd(model.user_add,2)%>  <%=getuseradd(model.user_add,3)%></span></p>
      <p>郵遞區號：<span class="fs"> <%=getuseradd(model.user_add,9)%></span></p>
      <p>所在地：<span class="fs">  <%=getuseradd(model.user_add,5)%><%=getuseradd(model.user_add,6)%> <%=getuseradd(model.user_add,7)%></span></p>
      <p>收件地址：<span class="fs"><%=getuseradd(model.user_add,8)%></span></p>

<%--
      <p>為了保護您個人資料的安全性			
        GOGO SPORTS CENTER不會在e-mail中顯示您的訂購明細        </p>--%>
      <p>您可以至「 <span class="fs">訂單查詢」</span>查詢您的訂購明細及最新訂單處理進度 </p>
    </div>
    <div class="xxrs">
    <p class="tit">反詐騙宣導：</p>
      <p>詐騙猖獗，任何可疑電話說您訂單有問題、要您操作提款機等等，請千萬不要理會，任何訂單問題請直接透過官網客服方式與我們聯繫。</p>
      <p>謝謝您的訂購</p>
      <p>&nbsp;</p>
      <p class="tit">天仁茗茶購物網-客服部</p>
	    <p>網址： <a href="http://mytenren.com/">http://mytenren.com/</a></p>
	    <p>客服信箱：<span class="fs"> service@tenren.com.tw</span></p>
	    <p>免付費服務電話：<span class="fs">0800-212-542</span></p>
	    <p>天仁茗茶購物網提醒您，天仁茗茶購物網不會以電話通知更改付款方式或要求重新轉帳，亦不會要求提供信用卡帳號或ATM 匯款帳號等，更無提供信用卡分期付款機制。</p>
	    <p>&nbsp;</p>
	    <p><span class="lanse">※此郵件為系統自動傳送，請勿直接回覆此郵件</span></p>
      </div>
  </div>
</div>
</body>
</html>
