// 佈局腳本
/*====================================
 *基於JQuery 1.9.0主框架
 *Tea管理介面
 *作者：一些事情
====================================*/
//綁定需要浮動的表頭
$(function(){
    $(".ltable tr:nth-child(odd)").addClass("odd_bg"); //隔行變色
    $("#floatHead").smartFloat();
	$(".rule-single-checkbox").ruleSingleCheckbox();
	$(".rule-multi-checkbox").ruleMultiCheckbox();
	$(".rule-multi-radio").ruleMultiRadio();
	$(".rule-single-select").ruleSingleSelect();
	$(".rule-multi-porp").ruleMultiPorp();
	$(".rule-date-input").ruleDateInput();
});
//全選取消按鈕函數
function checkAll(chkobj) {
    if ($(chkobj).text() == "全選") {
        $(chkobj).children("span").text("取消");
        $(".checkall input:enabled").prop("checked", true);
    } else {
        $(chkobj).children("span").text("全選");
        $(".checkall input:enabled").prop("checked", false);
    }
}

//===========================工具類函數============================
//只允許輸入數位
function checkNumber(e) {
    var keynum = window.event ? e.keyCode : e.which;
    if ((48 <= keynum && keynum <= 57) || (96 <= keynum && keynum <= 105) || keynum == 8) {
        return true;
    } else {
        return false;
    }
}
//只允許輸入小數
function checkForFloat(obj, e) {
    var isOK = false;
    var key = window.event ? e.keyCode : e.which;
    if ((key > 95 && key < 106) || //小鍵盤上的0到9  
        (key > 47 && key < 60) ||  //大鍵盤上的0到9  
        (key == 110 && obj.value.indexOf(".") < 0) || //小鍵盤上的.而且以前沒有輸入.  
        (key == 190 && obj.value.indexOf(".") < 0) || //大鍵盤上的.而且以前沒有輸入.  
         key == 8 || key == 9 || key == 46 || key == 37 || key == 39) {
        isOK = true;
    } else {
        if (window.event) { //IE
            e.returnValue = false;   //event.returnValue=false 效果相同.    
        } else { //Firefox 
            e.preventDefault();
        }
    }  
    return isOK;  
}
//檢查短信字數
function checktxt(obj, txtId) {
    var txtCount = $(obj).val().length;
    if (txtCount < 1) {
        return false;
    }
    var smsLength = Math.ceil(txtCount / 62);
    $("#" + txtId).html("您已輸入<b>" + txtCount + "</b>個字元，將以<b>" + smsLength + "</b>條短信扣取費用。");
}
//四捨五入函數
function ForDight(Dight, How) {
    Dight = Math.round(Dight * Math.pow(10, How)) / Math.pow(10, How);
    return Dight;
}
//寫Cookie
function addCookie(objName, objValue, objHours) {
    var str = objName + "=" + escape(objValue);
    if (objHours > 0) {//為0時不設定過期時間，瀏覽器關閉時cookie自動消失
        var date = new Date();
        var ms = objHours * 3600 * 1000;
        date.setTime(date.getTime() + ms);
        str += "; expires=" + date.toGMTString();
    }
    document.cookie = str;
}

//讀Cookie
function getCookie(objName) {//獲取指定名稱的cookie的值
    var arrStr = document.cookie.split("; ");
    for (var i = 0; i < arrStr.length; i++) {
        var temp = arrStr[i].split("=");
        if (temp[0] == objName) return unescape(temp[1]);
    }
    return "";
}

//========================基於artdialog外掛程式========================
//可以自動關閉的提示，基於artdialog外掛程式
function jsprint(msgtitle, url, callback) {
    var d = dialog({ content: msgtitle }).show();
    setTimeout(function () {
        d.close().remove();
    }, 2000);
    if (url == "back") {
        frames["mainframe"].history.back(-1);
    } else if (url != "") {
        frames["mainframe"].location.href = url;
    }
    //執行回呼函數
    if (arguments.length == 3) {
        callback();
    }
}
//彈出一個Dialog視窗
function jsdialog(msgtitle, msgcontent, url, callback) {
    var d = dialog({
        title: msgtitle,
        content: msgcontent,
        okValue: '確定',
        ok: function () { },
        onclose: function () {
            if (url == "back") {
                history.back(-1);
            } else if (url != "") {
                location.href = url;
            }
            //執行回呼函數
            if (argnum == 5) {
                callback();
            }
        }
    }).showModal();
}
//打開一個最大化的Dialog
function ShowMaxDialog(tit, url) {
    dialog({
        title: tit,
        url: url
    }).showModal();
}
//執行回傳函數
function ExePostBack(objId, objmsg) {
    if ($(".checkall input:checked").size() < 1) {
        parent.dialog({
            title: '提示',
            content: '對不起，請選中您要操作的記錄！',
            okValue: '確定',
            ok: function () { }
        }).showModal();
        return false;
    }
    var msg = "刪除記錄後不可恢復，您確定嗎？";
    if (arguments.length == 2) {
        msg = objmsg;
    }
    parent.dialog({
        title: '提示',
        content: msg,
        okValue: '確定',
        ok: function () {
            __doPostBack(objId, '');
        },
        cancelValue: '取消',
        cancel: function () { }
    }).showModal();

    return false;
}
//檢查是否有選中再決定回傳
function CheckPostBack(objId, objmsg) {
    var msg = "對不起，請選中您要操作的記錄！";
    if (arguments.length == 2) {
        msg = objmsg;
    }
    if ($(".checkall input:checked").size() < 1) {
        parent.dialog({
            title: '提示',
            content: msg,
            okValue: '確定',
            ok: function () { }
        }).showModal();
        return false;
    }
    __doPostBack(objId, '');
    return false;
}
//執行回傳無核取方塊確認函數
function ExeNoCheckPostBack(objId, objmsg) {
    var msg = "刪除記錄後不可恢復，您確定嗎？";
    if (arguments.length == 2) {
        msg = objmsg;
    }
    parent.dialog({
        title: '提示',
        content: msg,
        okValue: '確定',
        ok: function () {
            __doPostBack(objId, '');
        },
        cancelValue: '取消',
        cancel: function () { }
    }).showModal();

    return false;
}
//======================以上基於artdialog外掛程式======================

//========================基於Validform外掛程式========================
//初始化驗證表單
$.fn.initValidform = function () {
    var checkValidform = function (formObj) {
        $(formObj).Validform({
            tiptype: function (msg, o, cssctl) {
                /*msg：提示資訊;
                o:{obj:*,type:*,curform:*}
                obj指向的是當前驗證的表單元素（或表單物件）；
                type指示提示的狀態，值為1、2、3、4， 1：正在檢測/提交資料，2：通過驗證，3：驗證失敗，4：提示ignore狀態；
                curform為當前form物件;
                cssctl:內置的提示資訊樣式控制函數，該函數需傳入兩個參數：顯示提示資訊的物件 和 當前提示的狀態（既形參o中的type）；*/
                //全部驗證通過提交表單時o.obj為該表單對象;
                if (!o.obj.is("form")) {
                    //定位到相應的Tab頁面
                    if (o.obj.is(o.curform.find(".Validform_error:first"))) {
                        var tabobj = o.obj.parents(".tab-content"); //顯示當前的選項
                        var tabindex = $(".tab-content").index(tabobj); //顯示當前選項索引
                        if (!$(".content-tab ul li").eq(tabindex).children("a").hasClass("selected")) {
                            $(".content-tab ul li a").removeClass("selected");
                            $(".content-tab ul li").eq(tabindex).children("a").addClass("selected");
                            $(".tab-content").hide();
                            tabobj.show();
                        }
                    }
                    //頁面上不存在提示資訊的標籤時，自動創建;
                    if (o.obj.parents("dd").find(".Validform_checktip").length == 0) {
                        o.obj.parents("dd").append("<span class='Validform_checktip' />");
                        o.obj.parents("dd").next().find(".Validform_checktip").remove();
                    }
                    var objtip = o.obj.parents("dd").find(".Validform_checktip");
                    cssctl(objtip, o.type);
                    objtip.text(msg);
                }
            },
            showAllError: true
        });
    };
    return $(this).each(function () {
        checkValidform($(this));
    });
}
//======================以上基於Validform外掛程式======================

//智慧浮動層函數
$.fn.smartFloat = function() {
	var position = function(element) {
		var obj = element.children("div");
		var top = obj.position().top;
		var pos = obj.css("position");
		$(window).scroll(function() {
			var scrolls = $(this).scrollTop();
			if (scrolls > top) {
				obj.width(element.width());
				element.height(obj.outerHeight());
				if (window.XMLHttpRequest) {
					obj.css({
						position: "fixed",
						top: 0
					});	
				} else {
					obj.css({
						top: scrolls
					});	
				}
			}else {
				obj.css({
					position: pos,
					top: top
				});	
			}
		});
	};
	return $(this).each(function() {
		position($(this));						 
	});
};

//核取方塊
$.fn.ruleSingleCheckbox = function () {
    var singleCheckbox = function (parentObj) {
        //查找核取方塊
        var checkObj = parentObj.children('input:checkbox').eq(0);
        parentObj.children().hide();
        //添加元素及樣式
        var newObj = $('<a href="javascript:;">'
		+ '<i class="off">否</i>'
		+ '<i class="on">是</i>'
		+ '</a>').prependTo(parentObj);
        parentObj.addClass("single-checkbox");
        //判斷是否選中
        if (checkObj.prop("checked") == true) {
            newObj.addClass("selected");
        }
        //檢查控制項是否啟用
        if (checkObj.prop("disabled") == true) {
            newObj.css("cursor", "default");
            return;
        }
        //綁定事件
        newObj.click(function () {
            if ($(this).hasClass("selected")) {
                $(this).removeClass("selected");
            } else {
                $(this).addClass("selected");
            }
            checkObj.trigger("click"); //觸發對應的checkbox的click事件
        });
        //綁定反監聽事件
        checkObj.on('click', function () {
            if ($(this).prop("checked") == true && !newObj.hasClass("selected")) {
                alert();
                newObj.addClass("selected");
            } else if ($(this).prop("checked") == false && newObj.hasClass("selected")) {
                newObj.removeClass("selected");
            }
        });
    };
    return $(this).each(function () {
        singleCheckbox($(this));
    });
};

//多項核取方塊
$.fn.ruleMultiCheckbox = function() {
	var multiCheckbox = function(parentObj){
		parentObj.addClass("multi-checkbox"); //添加樣式
		parentObj.children().hide(); //隱藏內容
		var divObj = $('<div class="boxwrap"></div>').prependTo(parentObj); //前插入一個DIV
		parentObj.find(":checkbox").each(function(){
			var indexNum = parentObj.find(":checkbox").index(this); //當前索引
			var newObj = $('<a href="javascript:;">' + parentObj.find('label').eq(indexNum).text() + '</a>').appendTo(divObj); //查找對應Label創建選項
			if($(this).prop("checked") == true){
				newObj.addClass("selected"); //默認選中
			}
			//檢查控制項是否啟用
			if($(this).prop("disabled") == true){
				newObj.css("cursor","default");
				return;
			}
			//綁定事件
			$(newObj).click(function(){
				if($(this).hasClass("selected")){
					$(this).removeClass("selected");
					//parentObj.find(':checkbox').eq(indexNum).prop("checked",false);
				}else{
					$(this).addClass("selected");
					//parentObj.find(':checkbox').eq(indexNum).prop("checked",true);
				}
				parentObj.find(':checkbox').eq(indexNum).trigger("click"); //觸發對應的checkbox的click事件
				//alert(parentObj.find(':checkbox').eq(indexNum).prop("checked"));
			});
		});
	};
	return $(this).each(function() {
		multiCheckbox($(this));						 
	});
}

//多項選項PROP
$.fn.ruleMultiPorp = function() {
	var multiPorp = function(parentObj){
		parentObj.addClass("multi-porp"); //添加樣式
		parentObj.children().hide(); //隱藏內容
		var divObj = $('<ul></ul>').prependTo(parentObj); //前插入一個DIV
		parentObj.find(":checkbox").each(function(){
			var indexNum = parentObj.find(":checkbox").index(this); //當前索引
			var liObj = $('<li></li>').appendTo(divObj)
			var newObj = $('<a href="javascript:;">' + parentObj.find('label').eq(indexNum).text() + '</a><i></i>').appendTo(liObj); //查找對應Label創建選項
			if($(this).prop("checked") == true){
				liObj.addClass("selected"); //默認選中
			}
			//檢查控制項是否啟用
			if($(this).prop("disabled") == true){
				newObj.css("cursor","default");
				return;
			}
			//綁定事件
			$(newObj).click(function(){
				if($(this).parent().hasClass("selected")){
					$(this).parent().removeClass("selected");
				}else{
					$(this).parent().addClass("selected");
				}
				parentObj.find(':checkbox').eq(indexNum).trigger("click"); //觸發對應的checkbox的click事件
				//alert(parentObj.find(':checkbox').eq(indexNum).prop("checked"));
			});
		});
	};
	return $(this).each(function() {
		multiPorp($(this));						 
	});
}

//多項單選
$.fn.ruleMultiRadio = function() {
	var multiRadio = function(parentObj){
		parentObj.addClass("multi-radio"); //添加樣式
		parentObj.children().hide(); //隱藏內容
		var divObj = $('<div class="boxwrap"></div>').prependTo(parentObj); //前插入一個DIV
		parentObj.find('input[type="radio"]').each(function(){
			var indexNum = parentObj.find('input[type="radio"]').index(this); //當前索引
			var newObj = $('<a href="javascript:;">' + parentObj.find('label').eq(indexNum).text() + '</a>').appendTo(divObj); //查找對應Label創建選項
			if($(this).prop("checked") == true){
				newObj.addClass("selected"); //默認選中
			}
			//檢查控制項是否啟用
			if($(this).prop("disabled") == true){
				newObj.css("cursor","default");
				return;
			}
			//綁定事件
			$(newObj).click(function(){
				$(this).siblings().removeClass("selected");
				$(this).addClass("selected");
				parentObj.find('input[type="radio"]').prop("checked",false);
				parentObj.find('input[type="radio"]').eq(indexNum).prop("checked",true);
				parentObj.find('input[type="radio"]').eq(indexNum).trigger("click"); //觸發對應的radio的click事件
				//alert(parentObj.find('input[type="radio"]').eq(indexNum).prop("checked"));
			});
		});
	};
	return $(this).each(function() {
		multiRadio($(this));						 
	});
}

//單選下拉清單
$.fn.ruleSingleSelect = function () {
    var singleSelect = function (parentObj) {
        parentObj.addClass("single-select"); //添加樣式
        parentObj.children().hide(); //隱藏內容
        var divObj = $('<div class="boxwrap"></div>').prependTo(parentObj); //前插入一個DIV
        //創建元素
        var titObj = $('<a class="select-tit" href="javascript:;"><span></span><i></i></a>').appendTo(divObj);
        var itemObj = $('<div class="select-items"><ul></ul></div>').appendTo(divObj);
        var arrowObj = $('<i class="arrow"></i>').appendTo(divObj);
        var selectObj = parentObj.find("select").eq(0); //取得select對象
        //遍歷option選項
        selectObj.find("option").each(function (i) {
            var indexNum = selectObj.find("option").index(this); //當前索引
            var liObj = $('<li>' + $(this).text() + '</li>').appendTo(itemObj.find("ul")); //創建LI
            if ($(this).prop("selected") == true) {
                liObj.addClass("selected");
                titObj.find("span").text($(this).text());
            }
            //檢查控制項是否啟用
            if ($(this).prop("disabled") == true) {
                liObj.css("cursor", "default");
                return;
            }
            //綁定事件
            liObj.click(function () {
                $(this).siblings().removeClass("selected");
                $(this).addClass("selected"); //添加選中樣式
                selectObj.find("option").prop("selected", false);
                selectObj.find("option").eq(indexNum).prop("selected", true); //賦值給對應的option
                titObj.find("span").text($(this).text()); //賦值選中值
                arrowObj.hide();
                itemObj.hide(); //隱藏下拉清單
                selectObj.trigger("change"); //觸發select的onchange事件
                //alert(selectObj.find("option:selected").text());
            });
        });
        //設置樣式
        //titObj.css({ "width": titObj.innerWidth(), "overflow": "hidden" });
        //itemObj.children("ul").css({ "max-height": $(document).height() - titObj.offset().top - 62 });
        
        //檢查控制項是否啟用
        if (selectObj.prop("disabled") == true) {
            titObj.css("cursor", "default");
            return;
        }
        //綁定按一下事件
        titObj.click(function (e) {
            e.stopPropagation();
            if (itemObj.is(":hidden")) {
                //隱藏其它的下位框菜單
                $(".single-select .select-items").hide();
                $(".single-select .arrow").hide();
                //位於其它無素的上面
                arrowObj.css("z-index", "1");
                itemObj.css("z-index", "1");
                //顯示下拉清單
                arrowObj.show();
                itemObj.show();
            } else {
                //位於其它無素的上面
                arrowObj.css("z-index", "");
                itemObj.css("z-index", "");
                //隱藏下拉清單
                arrowObj.hide();
                itemObj.hide();
            }
        });
        //綁定頁面點擊事件
        $(document).click(function (e) {
            selectObj.trigger("blur"); //觸發select的onblure事件
            arrowObj.hide();
            itemObj.hide(); //隱藏下拉清單
        });
    };
    return $(this).each(function () {
        singleSelect($(this));
    });
}

//日期控制項
$.fn.ruleDateInput = function() {
	var dateInput = function(parentObj){
		parentObj.wrap('<div class="date-input"></div>');
		parentObj.before('<i></i>');
	};
	return $(this).each(function() {
		dateInput($(this));						 
	});
}
