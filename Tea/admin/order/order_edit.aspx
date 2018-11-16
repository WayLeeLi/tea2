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
<script type="text/javascript">
    $(function () {
        $("#btnConfirm").click(function () { OrderConfirm(); });   //確認訂單
        $("#btnPayment").click(function () { OrderPayment(); });   //確認付款
        $("#btnExpress").click(function () { OrderExpress(); });   //確認發貨
        $("#btnComplete").click(function () { OrderComplete(); }); //完成訂單
        $("#btnCancel").click(function () { OrderCancel(); });     //取消訂單
        $("#btnInvalid").click(function () { OrderInvalid(); });   //退貨訂單
        $("#btnPrint").click(function () { OrderPrint(); });       //列印訂單

        $("#btnEditAcceptInfo").click(function () { EditAcceptInfo(); }); //修改收貨資料
        $("#btnEditRemark").click(function () { EditOrderRemark(); });    //修改訂單備註
        $("#btnEditRealAmount").click(function () { EditRealAmount(); }); //修改商品總金額
        $("#btnEditExpressFee").click(function () { EditExpressFee(); }); //修改配送費用
        $("#btnEditPaymentFee").click(function () { EditPaymentFee(); }); //修改支付手續費
        $("#btnEditInvoiceTaxes").click(function () { EditInvoiceTaxes(); }); //修改發票稅金
    });
    //確認訂單
    function OrderConfirm() {
        var winDialog = top.dialog({
            title: '提示',
            content: '確認訂單後將無法修改金額，確認要繼續嗎？',
            okValue: '確定',
            ok: function () {
                var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "order_confirm" };
                //發送AJAX請求
                sendAjaxUrl(winDialog, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
                return false;
            },
            cancelValue: '取消',
            cancel: function () { }
        }).showModal();
    }
    //確認付款
    function OrderPayment() {
        var winDialog = top.dialog({
            title: '提示',
            content: '操作提示資訊：<br />1、該訂單使用線上付款方式，付款成功後自動確認；<br />2、如客戶確實已付款而沒有自動確認可使用該功能；<br />3、確認付款後無法修改金額，確認要繼續嗎？',
            okValue: '確定',
            ok: function () {
                var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "order_payment" };
                //發送AJAX請求
                sendAjaxUrl(winDialog, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
                return false;
            },
            cancelValue: '取消',
            cancel: function () { }
        }).showModal();
    }
    //確認發貨
    function OrderExpress() {
        var winDialog = top.dialog({
            title: '提示',
            url: 'dialog/dialog_express.aspx?order_no=' + $("#spanOrderNo").text(),
            width: 450,
            data: window //傳入當前窗口
        }).showModal();
    }
    //完成訂單
    function OrderComplete() {
        var winDialog = top.dialog({
            title: '完成訂單',
            content: '訂單完成後，訂單處理完畢，確認要繼續嗎？',
            button: [{
                value: '確定',
                callback: function () {
                    var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "order_complete" };
                    //發送AJAX請求
                    sendAjaxUrl(winDialog, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
                    return false;
                },
                autofocus: true
            }, {
                value: '取消',
                callback: function () { }
            }]
        }).showModal();
    }
    //取消訂單
    function OrderCancel() {
        var winDialog = top.dialog({
            title: '提示',
            url: 'dialog/dialog_quxiao.aspx?order_no=' + $("#spanOrderNo").text(),
            width: 450,
            data: window //傳入當前窗口
        }).showModal();
    }
    //退貨訂單
    function OrderInvalid() {
        var winDialog = top.dialog({
            title: '取消訂單',
            content: '操作提示資訊：<br />1、請線下與客戶溝通；<br />2、會員用戶，自動檢測退還金額或紅利到帳戶；<br />3、請按一下相應按鈕繼續下一步操作！',
            button: [{
                value: '檢測退還',
                callback: function () {
                    var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "order_invalid", "check_revert": 1 };
                    //發送AJAX請求
                    sendAjaxUrl(winDialog, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
                    return false;
                },
                autofocus: true
            }, {
                value: '直接退貨',
                callback: function () {
                    var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "order_invalid", "check_revert": 0 };
                    //發送AJAX請求
                    sendAjaxUrl(winDialog, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
                    return false;
                }
            }, {
                value: '關閉',
                callback: function () { }
            }]
        }).showModal();
    }
    //列印訂單
    function OrderPrint() {
        var winDialog = top.dialog({
            title: '列印訂單',
            url: 'dialog/dialog_print.aspx?order_no=' + $("#spanOrderNo").text(),
            width: 850
        }).showModal();
    }
    //修改收貨資料
    function EditAcceptInfo() {
        var winDialog = top.dialog({
            title: '修改收貨資料',
            url: 'dialog/dialog_accept.aspx',
            width: 550,
            height: 320,
            data: window //傳入當前窗口
        }).showModal();
    }
    //修改訂單備註
    function EditOrderRemark() {
        var winDialog = top.dialog({
            title: '訂單備註',
            content: '<textarea id="txtOrderRemark" name="txtOrderRemark" rows="2" cols="20" class="input">' + $("#divRemark").html() + '</textarea>',
            okValue: '確定',
            ok: function () {
                var remark = $("#txtOrderRemark", parent.document).val();
                if (remark == "") {
                    top.dialog({
                        title: '提示',
                        content: '對不起，請輸入訂單備註內容！',
                        okValue: '確定',
                        ok: function () { }
                    }).showModal(winDialog);
                    return false;
                }
                var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "edit_order_remark", "remark": remark };
                //發送AJAX請求
                sendAjaxUrl(winDialog, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
                return false;
            },
            cancelValue: '取消',
            cancel: function () { }
        }).showModal();
    }

    //修改商品總金額
    function EditRealAmount() {
        var winDialog = top.dialog({
            title: '請修改商品總金額',
            content: '<input id="txtDialogAmount" type="text" value="' + $("#spanRealAmountValue").text() + '" class="input" />',
            okValue: '確定',
            ok: function () {
                var amount = $("#txtDialogAmount", parent.document).val();
                if (!checkIsMoney(amount)) {
                    top.dialog({
                        title: '提示',
                        content: '對不起，請輸入正確的商品金額！',
                        okValue: '確定',
                        ok: function () { }
                    }).showModal(winDialog);
                    return false;
                }
                var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "edit_real_amount", "real_amount": amount };
                //發送AJAX請求
                sendAjaxUrl(winDialog, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
                return false;
            },
            cancelValue: '取消',
            cancel: function () { }
        }).showModal();
    }
    //修改配送費用
    function EditExpressFee() {
        var winDialog = top.dialog({
            title: '請修改配送費用',
            content: '<input id="txtDialogAmount" type="text" value="' + $("#spanExpressFeeValue").text() + '" class="input" />',
            okValue: '確定',
            ok: function () {
                var amount = $("#txtDialogAmount", parent.document).val();
                if (!checkIsMoney(amount)) {
                    top.dialog({
                        title: '提示',
                        content: '對不起，請輸入正確的配送金額！',
                        okValue: '確定',
                        ok: function () { }
                    }).showModal(winDialog);
                    return false;
                }
                var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "edit_express_fee", "express_fee": amount };
                //發送AJAX請求
                sendAjaxUrl(winDialog, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
                return false;
            },
            cancelValue: '取消',
            cancel: function () { }
        }).showModal();
    }
    //修改手續費用
    function EditPaymentFee() {
        var winDialog = top.dialog({
            title: '請修改支付手續費用',
            content: '<input id="txtDialogAmount" type="text" value="' + $("#spanPaymentFeeValue").text() + '" class="input" />',
            okValue: '確定',
            ok: function () {
                var amount = $("#txtDialogAmount", parent.document).val();
                if (!checkIsMoney(amount)) {
                    top.dialog({
                        title: '提示',
                        content: '對不起，請輸入正確的手續費用！',
                        okValue: '確定',
                        ok: function () { }
                    }).showModal(winDialog);
                    return false;
                }
                var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "edit_payment_fee", "payment_fee": amount };
                //發送AJAX請求
                sendAjaxUrl(winDialog, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
                return false;
            },
            cancelValue: '取消',
            cancel: function () { }
        }).showModal();
    }
    //修改稅金費用
    function EditInvoiceTaxes() {
        var winDialog = top.dialog({
            title: '請修改發票稅金費用',
            content: '<input id="txtDialogAmount" type="text" value="' + $("#spanInvoiceTaxesValue").text() + '" class="input" />',
            okValue: '確定',
            ok: function () {
                var amount = $("#txtDialogAmount", parent.document).val();
                if (!checkIsMoney(amount)) {
                    top.dialog({
                        title: '提示',
                        content: '對不起，請輸入正確的稅金費用！',
                        okValue: '確定',
                        ok: function () { }
                    }).showModal(winDialog);
                    return false;
                }
                var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "edit_invoice_taxes", "invoice_taxes": amount };
                //發送AJAX請求
                sendAjaxUrl(winDialog, postData, "../../tools/admin_ajax.ashx?action=edit_order_status");
                return false;
            },
            cancelValue: '取消',
            cancel: function () { }
        }).showModal();
    }

    //=================================工具類的JS函數====================================
    //檢查是否貨幣格式
    function checkIsMoney(val) {
        var regtxt = /^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/;
        if (!regtxt.test(val)) {
            return false;
        }
        return true;
    }
    //發送AJAX請求
    function sendAjaxUrl(winObj, postData, sendUrl) {
        $.ajax({
            type: "post",
            url: sendUrl,
            data: postData,
            dataType: "json",
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                top.dialog({
                    title: '提示',
                    content: '嘗試發送失敗，錯誤資訊：' + errorThrown,
                    okValue: '確定',
                    ok: function () { }
                }).showModal(winObj);
            },
            success: function (data, textStatus) {
                if (data.status == 1) {
                    winObj.close().remove();
                    var d = dialog({ content: data.msg }).show();
                    setTimeout(function () {
                        d.close().remove();
                        location.reload(); //刷新頁面
                    }, 2000);
                } else {
                    top.dialog({
                        title: '提示',
                        content: '錯誤提示：' + data.msg,
                        okValue: '確定',
                        ok: function () { }
                    }).showModal(winObj);
                }
            }
        });
    }
</script>
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
  <dl>
    <dd style="margin-left:50px;text-align:center; display:none;">
      <div class="order-flow" style="width:560px">
        <%if (model.status < 4)
          { %>
        <div class="order-flow-left">
          <a class="order-flow-input">生成</a>
          <span><p class="name">訂單已生成</p><p><%=model.add_time%></p></span>
        </div>
        <%if (model.payment_status == 1)
          { %>
        <div class="order-flow-wait">
          <a class="order-flow-input">付款</a>
          <span><p class="name">等待付款</p></span>
        </div>
        <%}
          else if (model.payment_status == 2)
          { %>
        <div class="order-flow-arrive">
          <a class="order-flow-input">付款</a>
          <span><p class="name">已付款</p><p><%=model.payment_time%></p></span>
        </div>
        <%} %>
        <%if (model.payment_status == 0 && model.status == 1)
          { %>
        <div class="order-flow-wait">
           <a class="order-flow-input">確認</a>
           <span><p class="name">等待確認</p></span>
        </div> 
        <%}
          else if (model.payment_status == 0 && model.status > 1)
          { %>
       <div class="order-flow-arrive">
          <a class="order-flow-input">確認</a>
          <span><p class="name">已確認</p><p><%=model.confirm_time%></p></span>
        </div>
        <%} %>
        <%if (model.express_status == 1)
          { %>
        <div class="order-flow-wait">
          <a class="order-flow-input">發貨</a>
          <span><p class="name">等待發貨</p></span>
        </div>
        <%}
          else if (model.express_status == 2)
          { %>
        <div class="order-flow-arrive">
          <a class="order-flow-input">發貨</a>
          <span><p class="name">已發貨</p><p><%=model.express_time%></p></span>
         </div>
         <%} %>
         <%if (model.status == 3)
           { %>
         <div class="order-flow-right-arrive">
           <a class="order-flow-input">完成</a>
           <span><p class="name">訂單完成</p><p><%=model.complete_time%></p></span>
         </div>
         <%}
           else
           { %>
         <div class="order-flow-right-wait">
           <a class="order-flow-input">完成</a>
           <span><p class="name">等待完成</p></span>
         </div>
         <%} %>
         <%}
          else if (model.status == 4)
          {%>
          <div style="text-align:center;line-height:30px; font-size:20px; color:Red;">該訂單已取消</div>
         <%}
          else if (model.status == 5)
          { %>
          <div style="text-align:center;line-height:30px; font-size:20px; color:Red;">該訂單已退貨</div>
         <%} %>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>訂單號</dt>
    <dd><span id="spanOrderNo"><%=model.order_no %></span></dd>
  </dl>
    <dl>
    <dt>訂單狀態</dt>
    <dd><%=GetOrderStatus(model.id)%></dd>
  </dl>
  <asp:Repeater ID="rptList" runat="server">
  <HeaderTemplate>
  <dl>
    <dt>商品列表</dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
        <thead>
          <tr>
            <th style="text-align:left;">商品名稱</th>
            <th style="text-align:left;">規格</th>
            <th style="text-align:left;">貨號</th>
            <th style="text-align:left;">價格</th>
            <th style="text-align:left;">紅利</th>
            <th width="8%">數量</th>
          </tr>
        </thead>
        <tbody>
        </HeaderTemplate>
        <ItemTemplate>
          <tr class="td_c">
            <td style="text-align:left;white-space:inherit;word-break:break-all;line-height:20px;">
              <%#Eval("goods_title")%>
            </td>
            <td style="text-align:left;"><%#Eval("spec_text").ToString()%></td>
            <td style="text-align:left;"><%#Eval("goods_no").ToString()%></td>
            <td style="text-align:left;"><%#Eval("goods_where").ToString() == "point" ? "0" : Eval("real_price","{0:0.}")%></td>
            <td style="text-align:left;"><%#Eval("point").ToString()%></td>
            <td><%#Eval("quantity")%></td>
          </tr>
          </ItemTemplate>
          <FooterTemplate>
        </tbody>
        </table>
      </div>
    </dd>
  </dl>
  </FooterTemplate>
  </asp:Repeater>
  <asp:Repeater ID="data_gift" runat="server"><ItemTemplate>
  <dl><dt>贈品</dt><dd><%#Eval("title")%>&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("gift_code")%>&nbsp;&nbsp;&nbsp;&nbsp;数量(<%#Eval("ocompany")%>)</dd></dl>
  </ItemTemplate></asp:Repeater>
    <dl>
    <dt>商品金額明細</dt>
    <dd>
      <div class="table-container">
        <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
        <tr>
          <th width="20%">商品小計</th>
          <td><%=model.real_amount.ToString("0.")%></td>
        </tr>
        <tr>
          <th>優惠券抵扣</th>
          <td><%=model.payment_fee.ToString("0.")%></td>
        </tr>
          <tr>
          <th>紅利兌換</th>
          <td><%=model.point%></td>
        </tr>
        <tr>
          <th>折扣</th>
          <td><%=model.zhe%></td>
        </tr>
        <tr>
          <th>紅利抵扣</th>
          <td><%=model.tuid%></td>
        </tr>
       <tr>
          <th>運費</th>
          <td><%=model.express_fee.ToString("0.")%></td>
        </tr>
         <tr>
          <th>總計</th>
          <td><%=model.order_amount.ToString("0.")%></td>
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
          <td><%=model.accept_name%></td>
        </tr>
        <tr>
          <th width="20%">訂購人姓名</th>
          <%if(model.area.Split(',')[0].ToString()=="台灣"){ %>
          <td><%=model.area.Split(',')[0].ToString()%>,<%=model.post_code%>,<%=model.area.Split(',')[1].ToString()%>,<%=model.area.Split(',')[2].ToString()%>,<%=model.address%></td>
          <%}else{ %>
          <td><%=model.address%>,<%=model.area.Split(',')[2].ToString()%>,<%=model.area.Split(',')[1].ToString()%>,<%=model.post_code%>,<%=model.area.Split(',')[0].ToString()%></td>
          <%} %>
        </tr>
        <tr>
          <th>訂購人電話</th>
          <td><%=model.telphone%></td>
        </tr>
        <tr>
          <th> E-mail</th>
          <td> <%=model.email%></td>
        </tr>
        <tr>
          <th>付款方式</th>
          <td><%=new Tea.BLL.payment().GetTitle(model.payment_id)%></td>
        </tr>
        <tr>
          <th>發票</th>
          <td><%=getinvoice(model.is_invoice.ToString())%></td>
        </tr>
         <tr>
          <th>發票資料</th>
          <td><%=getfp(model.invoice_title.ToString(),model.is_invoice)%></td>
        </tr>
        <%if (ChkAdminLevel("order_list", "All")){%>
         <tr>
          <th>電子發票</th>
          <td><asp:TextBox ID="trade_no" runat="server"  CssClass="input normal" Width="100px"></asp:TextBox>&nbsp;&nbsp;&nbsp;是否寄出發票<asp:CheckBox ID="cbFaPiao" runat="server" />&nbsp;&nbsp;&nbsp;<asp:Button 
                  ID="bu_submit" runat="server" class="btn" Text="送出" onclick="bu_submit_Click" /> </td>
        </tr>
        <%}else{ %>
        <tr>
          <th>電子發票</th>
          <td><%=model.trade_no %>&nbsp;&nbsp;&nbsp;<%=model.invoice_taxes==1?"已經寄出":"未寄出"%></td>
        </tr>
        <%} %>
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
              <span id="spanAcceptName"><%=getuseradd(model.user_add,0)%></span>
              <input style="display:none;" id="btnEditAcceptInfo" runat="server" visible="false" type="button" class="ibtn" value="修改" />
            </div>
          </td>
        </tr>
        <tr>
          <th>收件人電話</th>
          <td><span id="spanArea"> <%=getuseradd(model.user_add,2)%>&nbsp;&nbsp;&nbsp;<%=getuseradd(model.user_add,3).Replace(",","")%></span></td>
        </tr>
        <tr>
          <th>收件人地址</th>
          <%if(getuseradd(model.user_add,5)=="台灣"){ %>
          <td><span><%=getuseradd(model.user_add,5)%>, <%=getuseradd(model.user_add,9)%>,<%=getuseradd(model.user_add,6)%>,<%=getuseradd(model.user_add,7)%>,<%=getuseradd(model.user_add,8)%></span></td>
          <%}else{ %>
          <td><span> <%=getuseradd(model.user_add,8)%>,<%=getuseradd(model.user_add,7)%>,<%=getuseradd(model.user_add,6)%>,<%=getuseradd(model.user_add,9)%>,<%=getuseradd(model.user_add,5)%></span></td>
          <%} %>
        </tr>
       <%-- <tr>
          <th>Email</th>
          <td><span> <%=getuseradd(model.user_add,4)%></span></td>
        </tr>--%>
        <tr>
          <th>預計到貨日期</th>
          <td><span> <%=model.zhe_moeny%></span></td>
        </tr>
        <tr>
          <th>運送方式</th>
          <td><span id="spanEmail"><%=new Tea.BLL.express().GetTitle(model.express_id)%></span></td>
        </tr>
       <%if(getuseradd(model.user_add,5)!="台灣"){%>
       <tr>
          <th>商品材積重</th>
          <td><%=zhong.ToString("0.00")%> kg</td>
        </tr>
       <% }%>
          <%if (model.express_status == 2)
          {%>
        <tr>
          <th>包裹規格</th>
          <td>長:<asp:TextBox ID="chang" runat="server" CssClass="input small" onkeydown="return checkForFloat(event);"  ></asp:TextBox>&nbsp;cm&nbsp;寬:<asp:TextBox ID="kuan" runat="server" CssClass="input small" onkeydown="return checkForFloat(event);"  ></asp:TextBox>&nbsp;cm&nbsp;高:<asp:TextBox ID="gao" runat="server" CssClass="input small" onkeydown="return checkForFloat(event);"  ></asp:TextBox>&nbsp;cm&nbsp;重:<asp:TextBox ID="txtzhong" runat="server" CssClass="input small" onkeydown="return checkForFloat(event);"  ></asp:TextBox>&nbsp;kg&nbsp;</td>
        </tr>
        <tr>
          <th>運送方式</th>
          <td><asp:DropDownList id="ddlExpressId" runat="server"></asp:DropDownList> </td>
        </tr>
        <tr>
          <th>物流單號</th>
          <td><asp:TextBox ID="express_no" runat="server"  CssClass="input normal" Width="100px"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Button ID="bu_no" runat="server" class="btn" Text="送出" onclick="bu_no_Click" /> </td>
        </tr>
        <tr>
          <th>物流狀態</th>
          <td><%=new Tea.BLL.user_address().gettitle(model.express_no,model.express_id.ToString())%></td>
        </tr>
        <%} %>
       <tr>
          <th>用戶留言</th>
          <td><%=model.message %></td>
        </tr>
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
          <td><%=model.add_time%></td>
        </tr>
        <tr>
          <th>付款時間</th>
          <td><%=model.payment_time%></td>
        </tr>
       <tr>
          <th>出貨時間</th>
          <td><%=model.express_time%></td>
        </tr>
       <tr>
          <th>完成訂單</th>
          <td><%=model.complete_time%></td>
        </tr>
        </table>
      </div>
    </dd>
  </dl>
</div>
<!--/內容-->


<!--工具列-->
<div class="page-footer">
  <div class="btn-wrap">
     <%if (ChkAdminLevel("order_list", "All")){%>
    <input id="btnConfirm" runat="server" visible="false" type="button" value="確認訂單" class="btn" />
    <input id="btnPayment" runat="server" visible="false" type="button" value="確認付款" class="btn" />
    <%} %>
    <%if (ChkAdminLevel("order_list", "All") || ChkAdminLevel("order_list", "Chu")){ %>
    <input id="btnExpress" runat="server" visible="false" type="button" value="確認發貨" class="btn" />
    <%}%>
    <%if (ChkAdminLevel("order_list", "All")){%>
    <input id="btnComplete" runat="server" visible="false" type="button" value="完成訂單" class="btn" />
    <input id="btnCancel" runat="server" type="button" value="取消訂單" class="btn green" />
    <input id="btnInvalid" runat="server" visible="false" type="button" value="訂單退貨" class="btn green" />
    <%} %>
    <input id="btnPrint" type="button" value="列印訂單" class="btn violet" />
    <input id="btnReturn" type="button" value="返回上一頁" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具列-->

</form>
</body>
</html>
