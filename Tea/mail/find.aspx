<%@ Page Language="C#" AutoEventWireup="true" CodeFile="find.aspx.cs" Inherits="find" %>
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
	    <p>歡迎您加入天仁茗茶購物網</p>
	    <p>&nbsp;</p>
        <p><span class="fs">【重置密碼】</span><a href="<%=weburl%>users/editpwd.aspx?id=<%=model.id%>&pwd=<%=model.password%>">重置密碼</a> </p>
	   
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
