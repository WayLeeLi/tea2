<%@ Control Language="C#" AutoEventWireup="true" CodeFile="hand.ascx.cs" Inherits="public_hand" %>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <script type="text/javascript">
        function checkkey() {
            if ($('#key').val() == '') {
                alert('請輸入商品關鍵字');
                $('#key').focus();
                return false;
            }
        }
    </script>
<div class="hand">
  <div class="width-sys">
  <div class="wap-show cart-fix"><a href="/shop/cart.aspx"><img src="/images/cart-fix.png" width="240" height="240" alt=""/><i id="quantity1"><%=cartModel.total_quantity %></i></a></div>
  <div class="wap-show float-r wap-open"><img src="/images/menu.png" alt=""/></div>
    <div class="logo"><a href="/"><img src="<%=config.weblogo%>" width="660" height="156" alt=""/></a></div>
    <div class="hand-r">
      <div class="s-box">
        <div class="google-s">
        <div id="google_translate_element">
    </div>
<%--    <script type="text/javascript">
                             function googleTranslateElementInit() {
                                 new google.translate.TranslateElement({ pageLanguage: 'zh-TW', layout: google.translate.TranslateElement.InlineLayout.SIMPLE }, 'google_translate_element');
                             }
</script><script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>--%>
        </div>
        <form action="/shop/search.aspx" method="get" onsubmit="return checkkey()">
        <div class="search-box nav-site">
          <input type="text" name="key" id="key" placeholder="請輸入商品關鍵字">
          <input type="submit">
        </div>
        </form>
      </div>
      <div class="nav-box">
        <ul>
          <li><a href="javascript:void()"><img src="/images/ico4.png" class="wap-show" alt=""/>商品類別</a>
            <div class="nav-down"><asp:Repeater ID="data_type" runat="server"><ItemTemplate><a href="/shop/index.aspx?tid=<%#Eval("id")%>"><%#Eval("title")%></a></ItemTemplate></asp:Repeater><%if (_users!=null &&_users.group_id == 2)
                                                                                                                                                                                                 { %><a href="/shop/users.aspx">VIP專區</a><%} %><a href="/shop/list.aspx">紅利兌換專區</a></div>
          </li>
          <li><a href="/help.aspx"><img src="/images/ico5.png"  class="wap-show"  alt=""/> 購物說明</a></li>
          <%if (_users != null){%>
          <li><a href="/users/index.aspx"><img src="/images/ico1.png" width="30" height="30" alt=""/>會員中心</a>/<a href="/users/out.aspx">登出</a></li>
          <%}else{ %>
          <li><a href="/users/login.aspx"><img src="/images/ico1.png" width="30" height="30" alt=""/>會員登入</a>/<a href="/users/reg.aspx">註冊</a></li>
          <%} %>
          <li><a href="/shop/cart.aspx"><img src="/images/ico2.png" width="30" height="30" alt=""/>購物車（<span id="quantity"><%=cartModel.total_quantity %></span>）</a></li>
          <li class="wap-show"><a href="/about.aspx"><img src="/images/about.png" alt=""/>關於天仁</a></li>
          <li class="wap-show"><a href="/news.aspx"><img src="/images/news.png" alt=""/>相關訊息</a></li>
         <li class="wap-show"><a href="/contact.aspx"><img src="/images/contact.png" alt=""/>聯絡我們</a></li> 
          <li class="wap-show"><a href="http://www.tenren.com.tw/Content/Distributors/distributors.aspx?SiteID=10&MmmID=654265734224637430" target="_blank"><img src="/images/map.png" alt=""/>門市查詢</a></li>
        </ul>
      </div>
    </div>
  </div>
</div>