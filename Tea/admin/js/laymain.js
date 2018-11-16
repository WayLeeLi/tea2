// 管理內頁腳本
/*====================================
 *基於JQuery 1.10.2以上主框架
 *Tea管理介面
 *作者：一些事情
====================================*/
//頁面載入完成時執行
$(function () {
    initContentTab(); //初始化TAB
    $(".toolbar").ruleLayoutToolbar();
    $(".imglist").ruleLayoutImgList();
    $(".content-tab").ruleLayoutTab();
    $(".tab-content").ruleLayoutContent();
    //$(".table-container").ruleLayoutTable();
    $(".page-footer").ruleLayoutFooter();
    //視窗尺寸改變時
    $(window).resize(function () {
        //延遲執行,防止多次觸發
        setTimeout(function () {
            $("#floatHead").children("div").width($("#floatHead").width());
            $(".toolbar").ruleLayoutToolbar();
            $("#floatHead").height($("#floatHead").children("div").outerHeight());
            $(".imglist").ruleLayoutImgList();
            $(".content-tab").ruleLayoutTab();
            $(".tab-content").ruleLayoutContent();
            //$(".table-container").ruleLayoutTable();
            $(".page-footer").ruleLayoutFooter();
        }, 200);
    });
});

//工具列回應式
$.fn.ruleLayoutToolbar = function() {
	var fun = function(parentObj){
		//先移除事件和樣式
		parentObj.removeClass("mini");
		parentObj.removeClass("list");
		parentObj.find(".l-list").css("display","");
		parentObj.find(".menu-btn").unbind("click");
		//聲明變數
		var rightObj = parentObj.find(".r-list");
		var objWidth = parentObj.width();
		var rightWidth = 0;
		var iconWidth = 0;
		var menuWidth = 0;
		//計算寬度
		parentObj.find(".icon-list li").each(function() {
			iconWidth += $(this).width();
		});
		parentObj.find(".menu-list").children().each(function() {
			menuWidth += $(this).width();
		});
		if(rightObj.length > 0){
			rightWidth = rightObj.width();
		}
		
		//判斷及設置相應的樣式和事件
		if((iconWidth+rightWidth)<objWidth && menuWidth<objWidth && (iconWidth+menuWidth+rightWidth)>objWidth){
			parentObj.addClass("list");
		}else if((iconWidth+rightWidth)>objWidth || menuWidth>objWidth || (iconWidth+menuWidth+rightWidth)>objWidth){
			parentObj.addClass("mini");
			var listObj = parentObj.find(".l-list");
			parentObj.find(".menu-btn").click(function(e){
				e.stopPropagation();
				if(listObj.is(":hidden")){
					listObj.show();
				}else{
					listObj.hide();
				}
			});
			listObj.click(function(e) {
				if(parentObj.hasClass("mini")){
					e.stopPropagation(); 
				}
			}); 
			$(document).click(function(e){
				if(parentObj.hasClass("mini")){
					listObj.hide();
				}
			});
		}
	};
	return $(this).each(function() {
		fun($(this));						 
	});
}

//圖文列表排列回應式
$.fn.ruleLayoutImgList = function() {
	var fun = function(parentObj){
		var divWidth = parentObj.width();
		var liSpace = parseFloat(parentObj.find("ul li").css("margin-left"));
		var rankCount = Math.floor((divWidth+liSpace)/235);
		var liWidth = ((divWidth+liSpace)/rankCount) - liSpace;
		parentObj.find("ul li").width(liWidth);
	};
	return $(this).each(function() {
		fun($(this));						 
	});
}

//內容頁TAB表頭回應式
$.fn.ruleLayoutTab = function () {
    var fun = function (parentObj) {
        parentObj.removeClass("mini"); //計算前先清除一下樣式
        tabWidth = parentObj.width();
        liWidth = 0;
        parentObj.find("ul li").each(function () {
            liWidth += $(this).outerWidth();
        });
        if (liWidth > tabWidth) {
            parentObj.addClass("mini");
        } else {
            parentObj.removeClass("mini");
        }
    };
    return $(this).each(function () {
        fun($(this));
    });
}

//內容頁TAB內容回應式
$.fn.ruleLayoutContent = function () {
    var fun = function (parentObj) {
        parentObj.removeClass("mini"); //計算前先清除一下樣式
        var contentWidth = $("body").width() - parentObj.find("dl dt").eq(0).outerWidth();
        var dlMaxWidth = 0;
        parentObj.find("dl dd").children().each(function () {
            if ($(this).outerWidth() > dlMaxWidth) {
                dlMaxWidth = $(this).outerWidth();
            }
        });
        parentObj.find("dl dd table").each(function () {
            if (parseFloat($(this).css("min-width")) > dlMaxWidth) {
                dlMaxWidth = parseFloat($(this).css("min-width"));
            }
        });
        if (dlMaxWidth > contentWidth) {
            parentObj.addClass("mini");
        } else {
            parentObj.removeClass("mini");
        }
    };
    return $(this).each(function () {
        fun($(this));
    });
}

//表格處理事件
$.fn.ruleLayoutTable = function () {
    var fun = function (parentObj) {
        var tableWidth = parentObj.children("table").outerWidth();
        var minWidth = parseFloat(parentObj.children("table").css("min-width"));
        if (minWidth > tableWidth) {
            parentObj.children("table").width(minWidth);
        } else {
            parentObj.children("table").css("width", "");
        }
    };
    return $(this).each(function () {
        fun($(this));
    });
}

//頁面底部按鈕事件
$.fn.ruleLayoutFooter = function() {
	var fun = function(parentObj){
		var winHeight = $(window).height();
		var docHeight = $(document).height();
		if(docHeight > winHeight){
			parentObj.find(".btn-wrap").css("position", "fixed");
		}else{
			parentObj.find(".btn-wrap").css("position", "static");
		}
	};
	return $(this).each(function() {
		fun($(this));						 
	});
}

//初始化Tab事件
function initContentTab() {
    var parentObj = $(".content-tab");
    var tabObj = $('<div class="tab-title"><span>' + parentObj.find("ul li a.selected").text() + '</span><i></i></div>');
    parentObj.children().children("ul").before(tabObj);
    parentObj.find("ul li a").click(function () {
        var tabNum = $(this).parent().index("li")
        //設置點擊後的切換樣式
        $(this).parent().parent().find("li a").removeClass("selected");
        $(this).addClass("selected");
        tabObj.children("span").text($(this).text());
        //根據參數決定顯示內容
        $(".tab-content").hide();
        $(".tab-content").eq(tabNum).show();
        $(".page-footer").ruleLayoutFooter();
    });
}
