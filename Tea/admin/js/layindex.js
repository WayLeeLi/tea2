// 管理首頁腳本
/*====================================
 *基於JQuery 1.10.2以上主框架
 *Tea管理介面
 *作者：一些事情
====================================*/
//頁面載入完成時執行
$(function () {
    //點擊切換按鈕
    $(".icon-menu").click(function () {
        toggleMainMenu(); //切換按鈕顯示事件
    });
    loadMenuTree(true); //載入管理首頁左邊導航功能表
    mainPageResize(); //主頁面回應式

    //頁面尺寸改變時
    $(window).resize(function () {
        //延遲執行,防止多次觸發
        setTimeout(function () {
            mainPageResize(); //主頁面回應式
            popMenuTreeResize(); //快顯功能表的設置
        }, 100);
    });
});

//導航功能表顯示和隱藏
function mainPageResize() {
    var docWidth = $(window).width();
    if (docWidth > 800) {
        $("body").removeClass("lay-mini");
        $("#main-nav").show();
        $(".nav-right").show();
    } else {
        $("body").addClass("lay-mini");
        $("#main-nav").hide();
    }
}

//切換按鈕顯示事件
function toggleMainMenu(){
	$("body").toggleClass("lay-mini");
	if(!$("body").hasClass("lay-mini") && $(window).width() > 800){
		$("#main-nav").show();
		$(".nav-right").show();
	}else{
		$("#main-nav").hide();
		if(($(".main-top").width()-42) < $(".nav-right").width()){
			$(".nav-right").hide();
		}else{
			$(".nav-right").show();
		}
	}
}

//載入管理首頁左邊導航功能表
function loadMenuTree(_islink) {
	//判斷是否跳轉連結
	var islink = false;
	if (arguments.length == 1 && _islink) {
		islink = true;
	}
    //發送AJAX請求
    $.ajax({
        type: "post",
        url: "../tools/admin_ajax.ashx?action=get_navigation_list&time=" + Math.random(),
        dataType: "html",
        success: function (data, textStatus) {
            //將得到的資料外掛程式到頁面中
            $("#sidebar-nav").html(data);
            $("#pop-menu .list-box").html(data);
            //初始化導航菜單
            initMenuTree(islink);
            initPopMenuTree();
        }
    });
}

//初始化導航菜單
function initMenuTree(islink) {
	var navObj = $("#main-nav");
	var navGroupObj = $("#sidebar-nav .list-group");
	var navItemObj = $("#sidebar-nav .list-group .list-wrap");
	//先清空NAV功能表內容
	navObj.html('');
	navGroupObj.each(function (i) {
		//添加菜單導航
        var navHtml = $('<a>' + $(this).children("h1").attr("title") + '</a>').appendTo(navObj);
		//默認選中第一項
		if (i == 0) {
			$(this).show();
			navHtml.addClass("selected");
		}
		//為菜單添加事件
		navHtml.click(function () {
			navObj.children("a").removeClass("selected");
			$(this).addClass("selected");
			navGroupObj.hide();
			navGroupObj.eq(navObj.children("a").index($(this))).show();
        });
		//首先隱藏所有的UL
		$(this).find("ul").hide();
		//綁定樹菜單事件.開始
		$(this).find("ul").each(function (j) { //遍歷所有的UL
			//遍歷UL第一層LI
			$(this).children("li").each(function () {
				var liObj = $(this);
				var spanObj = liObj.children("a").children("span");
				//判斷是否有子功能表和設置距左距離
				var parentIconLenght = liObj.parent().parent().children("a").children(".icon").length; //父節點的左距離
				//設置左距離
				var lastIconObj;
				for (var n = 0; n <= parentIconLenght; n++) { //注意<=
					lastIconObj = $('<i class="icon"></i>').insertBefore(spanObj); //插入到span前面
				}

				//如果有下級功能表
				if (liObj.children("ul").length > 0) {
					liObj.children("a").removeAttr("href"); //刪除連結，防止跳轉
					liObj.children("a").append('<b class="expandable close"></b>'); //最後外掛程式一個+-
					//如果a有自訂圖示則將圖示插入，否則使用預設的樣式
					if(typeof(liObj.children("a").attr("icon"))!="undefined"){
						lastIconObj.append('<img src="' + liObj.children("a").attr("icon") + '" />')
					}else{
						lastIconObj.addClass("folder");
					}
					//隱藏下級的UL
					liObj.children("ul").hide();
					//綁定按一下事件
					liObj.children("a").click(function () {
						//如果功能表已展開則閉合
						if($(this).children(".expandable").hasClass("open")){
							//設置自身的右圖示為+號
							$(this).children(".expandable").removeClass("open");
							$(this).children(".expandable").addClass("close");
							//隱藏自身父節點的UL子功能表
							$(this).parent().children("ul").slideUp(300);
						}else{
							//搜索所有同級LI且有子功能表的右圖示為+號及隱藏子功能表
							$(this).parent().siblings().each(function () {
								if ($(this).children("ul").length > 0) {
									//設置自身的右圖示為+號
									$(this).children("a").children(".expandable").removeClass("open");
									$(this).children("a").children(".expandable").addClass("close");
									//隱藏自身子菜單
									$(this).children("ul").slideUp(300);
								}
							});
							//設置自身的右圖示為-號
							$(this).children(".expandable").removeClass("close");
							$(this).children(".expandable").addClass("open");
							//顯示自身父節點的UL子功能表
							$(this).parent().children("ul").slideDown(300);
						}
					});
					
				}else{
					//如果a有自訂圖示則將圖示插入，否則使用預設的樣式
					if(typeof(liObj.children("a").attr("icon"))!="undefined"){
						lastIconObj.append('<img src="' + liObj.children("a").attr("icon") + '" />');
		            } else if (typeof (liObj.children("a").attr("href")) == "undefined" || liObj.children("a").attr("href").length < 2) { //如果沒有連結
						liObj.children("a").removeAttr("href");
						lastIconObj.addClass("folder");
					}else{
						lastIconObj.addClass("file");
					}
					if(typeof(liObj.children("a").attr("href"))!="undefined"){
						//綁定按一下事件
						liObj.children("a").click(function () {
							//刪除所有的選中樣式
							navGroupObj.find("ul li a").removeClass("selected");
							//刪除所有的list-group選中樣式
							navGroupObj.removeClass("selected");
							//刪除所有的main-nav選中樣式
							navObj.children("a").removeClass("selected");
							//自身添加樣式
							$(this).addClass("selected");
							//設置父list-group選中樣式
							$(this).parents(".list-group").addClass("selected");
							//設置父main-nav選中樣式
							navObj.children("a").eq(navGroupObj.index($(this).parents(".list-group"))).addClass("selected");
							//隱藏所有的list-group
							navGroupObj.hide();
							//顯示自己的父list-group
							$(this).parents(".list-group").show();
							//儲存到cookie
							if(typeof($(this).attr("navid"))!="undefined"){
								addCookie("shop_manage_navigation_cookie", $(this).attr("navid"), 240);
							}
						});
					}
				}

			});
			//顯示第一個UL
			if (j == 0) {
				$(this).show();
				//展開第一個菜單
				if ($(this).children("li").first().children("ul").length > 0) {
					$(this).children("li").first().children("a").children(".expandable").removeClass("close");
					$(this).children("li").first().children("a").children(".expandable").addClass("open");
					$(this).children("li").first().children("ul").show();
				}
			}
		});
		//綁定樹菜單事件.結束
	});
	//定位或跳轉到相應的菜單
    linkMenuTree(islink);
}

//定位或跳轉到相應的菜單
function linkMenuTree(islink, navid) {
	var navObj = $("#main-nav");
	var navGroupObj = $("#sidebar-nav .list-group");
	var navItemObj = $("#sidebar-nav .list-group .list-wrap");
	
	//讀取Cookie,如果存在該ID則定位到對應的導航
	var cookieObj;
	var argument = arguments.length;
	if (argument == 2) {
		cookieObj = navGroupObj.find('a[navid="' + navid + '"]');
	} else {
		cookieObj = navGroupObj.find('a[navid="' + getCookie("shop_manage_navigation_cookie") + '"]');
	}
	if (cookieObj.length > 0) {
		//顯示所在的導航和組
		//刪除所有的選中樣式
		navGroupObj.find("ul li a").removeClass("selected");
		//刪除所有的list-group選中樣式
		navGroupObj.removeClass("selected");
		//刪除所有的main-nav選中樣式
		navObj.children("a").removeClass("selected");
		//自身添加樣式
		cookieObj.addClass("selected");
		//設置父list-group選中樣式
		cookieObj.parents(".list-group").addClass("selected");
		//設置父main-nav選中樣式
		navObj.children("a").eq(navGroupObj.index(cookieObj.parents(".list-group"))).addClass("selected");
		//隱藏所有的list-group
		navGroupObj.hide();
		//顯示自己的父list-group
		cookieObj.parents(".list-group").show();
		//遍歷所有的LI父節點
		cookieObj.parents("li").each(function () {
			//搜索所有同級LI且有子功能表的右圖示為+號及隱藏子功能表
			$(this).siblings().each(function () {
				if ($(this).children("ul").length > 0) {
					//設置自身的右圖示為+號
					$(this).children("a").children(".expandable").removeClass("open");
					$(this).children("a").children(".expandable").addClass("close");
					//隱藏自身子菜單
					$(this).children("ul").hide();
				}
			});
			//設置自身的右圖示為-號
			if ($(this).children("ul").length > 0) {
				$(this).children("a").children(".expandable").removeClass("close");
				$(this).children("a").children(".expandable").addClass("open");
			}
			//顯示自身的UL
			$(this).children("ul").show();
		});
		//檢查是否需要儲存到cookie
		if (argument == 2) {
			addCookie("shop_manage_navigation_cookie", navid, 240);
		}
		//檢查是否需要跳轉連結
		if (islink == true && cookieObj.attr("href") != "" && cookieObj.attr("href")!= "#") {
			frames["mainframe"].location.href = cookieObj.attr("href");
		}
	} else if (argument == 2) {
		//刪除所有的選中樣式
		navGroupObj.find("ul li a").removeClass("selected");
		//儲存到cookie
		addCookie("shop_manage_navigation_cookie", "", 240);
	}
}

//初始化快捷導航菜單
function initPopMenuTree() {
	//遍歷及載入事件
	$("#pop-menu .pop-box .list-box li").each(function () {
		var linkObj = $(this).children("a");
		linkObj.removeAttr("href");
		if ($(this).children("ul").length > 0) { //如果無下級功能表
			linkObj.addClass("nolink");
		}else{
			linkObj.addClass("link");
			linkObj.click(function () {
				linkMenuTree(true, linkObj.attr("navid")); //載入函數
			});
		}
	});
	//設置快顯功能表容器的大小
	popMenuTreeResize();
}

//設置快顯功能表容器的大小
function popMenuTreeResize() {
	//計算容器的寬度
	var groupWidth = $("#pop-menu .list-box .list-group").outerWidth();
	var divWidth = $("#pop-menu .list-box .list-group").length * groupWidth;
	var winWidth = $(window).width();
	if(divWidth > winWidth){
		var groupCount = Math.floor(winWidth/groupWidth);
		if(groupCount > 0){
			groupWidth = groupWidth*groupCount;
		}
	}else{
		groupWidth = divWidth;
	}
	$("#pop-menu .pop-box").width(groupWidth);
	//只有顯示的時候才能設置高度
	if($("#pop-menu").css("display") == "block"){
		setPopMenuHeight();
	}
}

//設置快顯功能表的高度
function setPopMenuHeight(){
	//計算容器的高度
	var divHeight = $(window).height() * 0.6;
	var groupHeight = 0;
	$("#pop-menu .list-box .list-group").each(function () {
		if($(this).height() > groupHeight) {
			groupHeight = $(this).height();
		}
	});
	if (divHeight > groupHeight) {
		divHeight = groupHeight;
	}
	$("#pop-menu .list-box .list-group").height(groupHeight);
	$("#pop-menu .pop-box").height(divHeight);
}

//快顯功能表的顯示與隱藏
function togglePopMenu() {
	if($("#pop-menu").css("display")=="none"){
		$("#pop-menu").show();
		//只有顯示的時候才能設置高度
		setPopMenuHeight();
		//設置導航捲軸
		$("#pop-menu .list-box").niceScroll({ touchbehavior:false, cursorcolor:"#ccc", cursoropacitymax:0.6, cursorwidth:5, autohidemode:false });
	}else{
		$("#pop-menu").hide();
		$("#pop-menu .list-box").getNiceScroll().remove();
	}
}
