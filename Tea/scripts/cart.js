//添加收藏
function TraceAdd(obj, webpath,linktype, goods_id) {
    if (goods_id == "") {
	    alert("本產品無此規格，請重新選擇！");
	}
	$.ajax({
		type: "post",
		url: webpath + "tools/submit_ajax.ashx?action=trace_goods_add",
		data: {
		    "goods_id": goods_id
		},
		dataType: "json",
		beforeSend: function(XMLHttpRequest) {
			//發送前動作
		},
		success: function(data, textStatus) {
			if (data.status == 1) {
				if(linktype==1){
					location.href=linkurl;
				}else{ alert('商品已成功添加到收藏'); }
			} else { alert(data.msg);}
		},
		error: function (XMLHttpRequest, textStatus, errorThrown) {
			alert("狀態：" + textStatus + "；出錯提示：" + errorThrown);
		},
		timeout: 20000
	});
	return false;
}

//添加進購物車
function CartAdd(obj, webpath, linktype, linkurl,Za){
    if ($("#cartid").val() == "" || $("#num").val() == "") {
		return false;
}
if (parseInt($("#num").val()) > Za) {
    alert("超出最大購買數量，請重新選擇!");
    return false;
}

if (parseInt($("#ku").text()) < parseInt($("#num").val())) {
    alert("該產品規格超出最大庫存，請重新選擇!");
    return false; 
}
if ($("#cartid").val() == "" || $("#ku").text() == "0") {
        alert("該產品規格無庫存，請重新選擇!");
		return false;
	}
	$.ajax({
	    type: "post",
	    url: webpath + "tools/submit_ajax.ashx?action=cart_goods_add",
	    data: {
	        "goods_id": $("#cartid").val(),
	        "goods_quantity": $("#num").val()
	    },
	    dataType: "json",
	    beforeSend: function (XMLHttpRequest) {
	        //發送前動作
	    },
	    success: function (data, textStatus) {
	        if (data.status == 1) {
	            if (linktype == 1) {
	                location.href = linkurl;
	            } else {
	                alert(data.msg);
	                $('#quantity').text(data.quantity);
	                $('#quantity1').text(data.quantity); 
	            }
	        } else {
	            alert(data.msg);
	        }
	    },
	    error: function (XMLHttpRequest, textStatus, errorThrown) {
	        alert("狀態：" + textStatus + "；出錯提示：" + errorThrown);
	    },
	    timeout: 20000
	});
	return false;
}

//刪除購物車商品
function DeleteCart(obj, webpath, goods_id){
	if(!confirm("您確認要從購物車中移除嗎？") || goods_id==""){
		return false;
	}
	$.ajax({
		type: "post",
		url: webpath + "tools/submit_ajax.ashx?action=cart_goods_delete",
		data: {"goods_id" : goods_id},
		dataType: "json",
		beforeSend: function(XMLHttpRequest) {
			//發送前動作
		},
		success: function(data, textStatus) {
			if (data.status == 1) {
				location.reload();
			} else {
				alert(data.msg);
			}
		},
		error: function (XMLHttpRequest, textStatus, errorThrown) {
			alert("狀態：" + textStatus + "；出錯提示：" + errorThrown);
		},
		timeout: 20000
	});
	return false;
}

//計算購物車金額
function CartAmountTotal(obj, webpath, goods_id,ku){
	if(isNaN($(obj).val())){
		alert('商品數量只能輸入數字!');
		$(obj).val("1");
}
if ($(obj).val()>ku) {
    alert('商品數量不能超過庫存!');
    $(obj).val(ku);
}
	$.ajax({
		type: "post",
		url: webpath + "tools/submit_ajax.ashx?action=cart_goods_update",
		data: {
			"goods_id" : goods_id,
			"goods_quantity" : $(obj).val()
		},
		dataType: "json",
		beforeSend: function(XMLHttpRequest) {
			//發送前動作
		},
		success: function(data, textStatus) {
			if (data.status == 1) {
				location.reload();
			} else {
				alert(data.msg);
				location.reload();
			}
		},
		error: function (XMLHttpRequest, textStatus, errorThrown) {
			alert("狀態：" + textStatus + "；出錯提示：" + errorThrown);
		},
		timeout: 20000
	});
	return false;
}
//購物車數量加減
function CartComputNum(aid, webpath, goods_id, num,ku) {
	if(num > 0){
	    var goods_quantity = $("#goods_quantity" + aid);
		$(goods_quantity).val(parseInt($(goods_quantity).val()) + 1);
		//計算購物車金額
		CartAmountTotal($(goods_quantity), webpath, goods_id,ku);
	}else{
    var goods_quantity = $("#goods_quantity" + aid);
		if(parseInt($(goods_quantity).val()) > 1){
			$(goods_quantity).val(parseInt($(goods_quantity).val()) - 1);
			//計算購物車金額
			CartAmountTotal($(goods_quantity), webpath, goods_id,ku);
		}
	}
}
//計算支付手續費總金額
function PaymentAmountTotal(obj){
	var payment_price = $(obj).next("input[name='payment_price']").val();
	$("#payment_fee").text(payment_price); //運費
	OrderAmountTotal();
}
//計算配送費用總金額
function FreightAmountTotal(fee,maxmoney,amount) 
{
    if (amount >= maxmoney)
    {$("#express_fee").text("0"); }//運費
    else
    {$("#express_fee").text(fee); }//運費
	OrderAmountTotal();
}
//計算使用回饋金
function PointAmountTotal(t,l){
	$("#point").text(t);
	$("#AmountList").val(l);
	OrderAmountTotal();
}

//計算訂單總金額
function OrderAmountTotal(){
	var goods_amount = $("#goods_amount").text(); //商品總金額
	var express_fee = $("#express_fee").text(); //運費
	var point_fee = $("#point").text(); //回饋金
	var order_amount = parseFloat(goods_amount) - parseFloat(point_fee) + parseFloat(express_fee); //訂單總金額 = 商品金額 - 回饋金 + 運費
	$("#order_amount").text(order_amount.toFixed(2));
}
 