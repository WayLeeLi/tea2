<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reg.aspx.cs" Inherits="reg" %>
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
	height: 300px;
	margin-bottom: 45px;
}
 a {
	color: #fe0000;
}
.lanse {
	color: #189eb6;
}
.rz-btn {	height: 45px;
}
</style>
</head>

<body>
<div class="embg">
	<div class="emkz">
	  <div class="emlr">
	    <p>親愛的 <span class="fs"><%=model.nick_name%></span> 您好：</p>
	    <p>感謝您申請天仁茗茶購物網會員，您必須依照以下步驟，正式啟用您的帳號後，才能完成註冊手續並開始進行交易。</p>
	    <p>&nbsp;</p>
	    <p><span class="fs">【電子郵件】</span><%=model.user_name %> </p>
	    <p>請點選啟用連結，自動正式啟用會員帳號：點此連接啟用</p>
	     <p class="rz-btn"><a href="<%=weburl%>users/regok.aspx?id=<%=model.id%>&code=<%=model.password%>" target="_blank">點此完成mail認證</a></p>
      </div>
	  <div class="xxrs">
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
