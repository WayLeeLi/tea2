<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_edit.aspx.cs" Inherits="Tea.Web.admin.order.order_edit" ValidateRequest="false" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>查看訂單</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--巡覽列-->
<div class="location">
  <a href="order_list.aspx" class="back"><i></i><span>返回列表頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>訂單管理</span>
  <i class="arrow"></i>
  <span>出貨管理</span>
</div>
<div class="line10"></div>
<!--/巡覽列-->

<!--內容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">訂單詳細資料</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
 <asp:Repeater ID="data_list" runat="server"><ItemTemplate>
  <dl>
    <dt>訂單號</dt>
    <dd><span id="spanOrderNo"><%#Eval("OrderNumber")%></span></dd>
  </dl>
    <dl>
    <dt>訂單狀態</dt>
    <dd><%#Eval("Status")%></dd>
  </dl>

   
    <dl>
    <dt>商品金額明細</dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
        <tr>
          <th width="20%">商品小計</th>
          <td><%#Eval("Pay")%></td>
        </tr>
        
       
        <tr>
          <th>本次消費共得紅利</th>
          <td><%#Eval("AddBonus")%></td>
        </tr>
        <tr>
          <th>紅利抵扣</th>
          <td><%#Eval("PayBonus")%></td>
        </tr>
       <tr>
          <th>運費</th>
          <td><%#Eval("TransferFee")%></td>
        </tr>
         <tr>
          <th>總計</th>
          <td><%#Eval("Pay")%></td>
        </tr>
        </table>
      </div>
    </dd>
  </dl>
   <dl >
    <dt>訂購人資料</dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
        <tr>
          <th width="20%">訂購人姓名</th>
          <td><%#Eval("Buyer")%></td>
        </tr>
      
        <tr>
          <th>訂購人電話</th>
          <td><%#Eval("BTel")%></td>
        </tr>
        <tr>
          <th> E-mail</th>
          <td><%#Eval("BEmail")%></td>
        </tr>
        <tr>
          <th>訂購人地址</th>
          <td>  <%#Eval("BAddr1")%>     <%#Eval("BPostCode")%></td>
        </tr>
        
        </table>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>收貨資料</dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
        <tr>
          <th width="20%">收件人姓名</th>
          <td>
            <div class="position">
              <span id="spanAcceptName"><%#Eval("Accepter")%></span>
            
            </div>
          </td>
        </tr>
        <tr>
          <th>收件人電話</th>
          <td><span id="spanArea"> <%#Eval("ATel")%></span></td>
        </tr>
        <tr>
          <th>收件人地址</th>
          <td><span> <%#Eval("AAddr1")%> <%#Eval("APostCode")%></span></td>
        </tr>
 
    
    
       <tr>
          <th>用戶留言</th>
          <td><%#Eval("Remark")%></td>
        </tr>
          <tr>
          <th>付款方式</th>
          <td><span id="spanEmail"><%#Eval("PayType")%></span></td>
        </tr>
    >
        </table>
      </div>
    </dd>
  </dl>

    <dl>
    <dt>交易追蹤</dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
        <tr>
          <th width="20%">訂單成立</th>
          <td><%#Eval("Date")%></td>
        </tr>
        <tr>
          <th>付款時間</th>
          <td><%#Eval("PayDate")%></td>
        </tr>
  
       <tr>
          <th>完成訂單</th>
          <td><%#Eval("ProcessDate")%></td>
        </tr>
        </table>
      </div>
    </dd>
  </dl>
  </ItemTemplate></asp:Repeater>
 
  <dl>
    <dt>商品列表</dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
        <thead>
          <tr>
            <th style="text-align:left;">商品名稱</th>
 
            <th style="text-align:left;">價格</th>
 
            <th width="8%">數量</th>
          </tr>
        </thead>
        <tbody>
          <asp:Repeater ID="data_list1" runat="server">
        <ItemTemplate>
          <tr class="td_c">
            <td style="text-align:left;white-space:inherit;word-break:break-all;line-height:20px;">
             <%#Eval("ProductName")%>
            </td>
             
            <td style="text-align:left;"><%#Eval("Pay", "{0:0.}")%></td>
        
            <td><%#Eval("Num")%></td>
          </tr>
          </ItemTemplate>
          </asp:Repeater>
        </tbody>
        </table>
      </div>
    </dd>
  </dl>
 

</div>
<!--/內容-->
 
</form>
</body>
</html>
