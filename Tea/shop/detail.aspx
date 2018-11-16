<%@ Page Language="C#" AutoEventWireup="true" CodeFile="detail.aspx.cs" Inherits="show" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width">
    <title><%=title%></title>
    <meta name="Keywords" content="<%=keyword%>" />
    <meta name="Description" content="<%=describe%>" />
    <meta property="og:title" content="<%=model.title%>">  
    <meta property="og:type" content="website">  
    <meta property="og:image" content="<%=model.img_url%>" />
    <meta property="og:description" content="<%=describe%>" />
    <meta property="og:url" content="<%=weburl%>/shop/show.aspx?id=<%=id%>" /> 
    <link href="/jQueryAssets/jquery.ui.core.min.css" rel="stylesheet" type="text/css">
    <link href="/jQueryAssets/jquery.ui.theme.min.css" rel="stylesheet" type="text/css">
    <link href="/jQueryAssets/jquery.ui.tabs.min.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" type="text/css" href="/css/slider-pro.min.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/examples.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/css.css" media="screen">
    <link href="/owl-carousel/owl.carousel.css" rel="stylesheet">
    <link href="/owl-carousel/owl.theme.css" rel="stylesheet">
    <link href="/css/etalage.css" rel="stylesheet">
    <script type="text/javascript" src="/js/jquery-1.11.0.min.js"></script>
    <script src="/js/app.js"></script>
    <script type="text/javascript" src="/js/jquery.sliderPro.min.js"></script>
    <script src="/jQueryAssets/jquery.ui-1.10.4.tabs.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/scripts/cart.js"></script>
    <link href="/css/cloudzoom.css" rel="stylesheet"/>
<script src="/js/cloudzoom.js"></script>
<!--启动CloudZoom就可以了，quickStart()立即启动-->
<script type="text/javascript">
	CloudZoom.quickStart();
</script>
    <script type="text/javascript">
	$( document ).ready(function( $ ) {
		

		$( '#detail' ).sliderPro({
			width: 530,
			height: 530,
			
			loop: false,
			arrows: true,
			buttons: false,
			autoplay: false,
			thumbnailsPosition: 'bottom',
			thumbnailPointer: true,
			thumbnailWidth: 120,
			thumbnailHeight: 120,
			breakpoints: {
				
				800: {
					thumbnailsPosition: 'bottom',
					thumbnailWidth: 80,
					thumbnailHeight: 80
				},
				500: {
					thumbnailsPosition: 'bottom',
					thumbnailWidth: 80,
					thumbnailHeight: 80
				}
			}
		});
	});
</script>
</head>
<body>
    <public:hand ID="hand" runat="server" />
    <div class="width-sys location">
        <a href="/">首頁</a> &gt; 紅利兌換專區 &gt; <%=model.title%></div>
    <div class="width-sys">
        <div class="sub-left">
            <div class="pro-lb">
                商品類別</div>
            <div class="nav-down">
                <asp:Repeater ID="data_type" runat="server"><ItemTemplate><a href="index.aspx?tid=<%#Eval("id")%>"><%#Eval("title")%></a></ItemTemplate></asp:Repeater><%if (_users!=null &&_users.group_id == 2)
                                                                                                                                                                                                 { %><a href="/shop/users.aspx">VIP專區</a><%} %><a href="/shop/list.aspx">紅利兌換專區</a></div>
        </div>
        <div class="sub-right detail">
        <div class="detail-l wap-none">
<div class="detail_pic" id="detail-p">

  <div class="jqueryzoom">
	<img id="img" class="cloudzoom" src="<%=model.img_url%>" data-cloudzoom="zoomSizeMode:'image',zoomImage: '<%=model.img_url%>',autoInside: 0," alt="<%=model.title%>" title=""/> </div>
   <div id="detail_pic" class="owl-carousel">
   <asp:Repeater ID="data_pic" runat="server">
    <ItemTemplate>
    <div class="item">
		<img class="cloudzoom-gallery" src="<%#Eval("original_path")%>" data-cloudzoom="useZoom:'.cloudzoom',image:'<%#Eval("original_path")%>',zoomImage:'<%#Eval("original_path")%>'"/> 
    </div>
    </ItemTemplate>
      </asp:Repeater>
    </div>
</div>

</div>

            <div class="detail-l wap-show">
                <div id="detail" class="slider-pro">
                    <div class="sp-slides">
                        <asp:Repeater ID="data_pic1" runat="server"><ItemTemplate>
                        <div class="sp-slide">
                            <img class="sp-image" src="/css/images/blank.gif" data-src="<%#Eval("original_path")%>" data-retina="<%#Eval("original_path")%>" />
                        </div>
                        </ItemTemplate></asp:Repeater>
                    </div>
                    <div class="sp-thumbnails">
                        <asp:Repeater ID="data_pic2" runat="server"><ItemTemplate>
                        <div class="sp-thumbnail">
                            <img src="<%#Eval("original_path")%>" alt="" />
                        </div>
                        </ItemTemplate></asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="detail-r">
                <div class="iteminfo_buying">
                    <div class="detail-title1"><%=model.sub_title%></div>
                    <div class="detail-title">
                        <span class="tit-ico float-l"><%=get_sales(model.id.ToString())%></span><%=model.title%></div>
                    <!--规格属性-->
                    <div class="sys_item_spec">
                        <dl class="clearfix iteminfo_parameter lh32">
                            <dd><span class="float-r share-ico"><a href="javascript:window.open('http://www.facebook.com/sharer.php?u='+encodeURIComponent(document.location.href)+'&t='+encodeURIComponent(document.title));void(0)"><img src="/images/Facebook.png" alt="分享到Facebook" width="29" height="30" /><a href="javascript:;" onclick="TraceAdd(this, '/', 0, '<%=id%>')"><img src="/images/xinx.png" width="29" height="30" alt="加入最愛" /></a></span><span class="all_price"><b class="sys_item_mktprice"><%=model.point.ToString("0.")%>點</b></span><span class="iteminfo_price"> <b class="sys_item_price"><%=model.point.ToString("0.")%>點</b></span></dd>
                        </dl>
                    </div>
                    <div class="sys_item_spec guige">
                        <div class="hr"></div>
                        <dl class="clearfix iteminfo_parameter sys_item_specpara" data-sid="2">
                            <dd>
                                <ul class="sys_spec_text">
                                    <asp:Repeater ID="data_goods" runat="server"><ItemTemplate>
                                    <li data-aid="<%#Eval("parent_id")%>_<%#Eval("id")%>" <%#Container.ItemIndex==0?" class=\"selected\"":""%>><a href="javascript:;" title="<%#Eval("guige")%>"><%#Eval("guige")%></a><i></i></li>
                                    </ItemTemplate></asp:Repeater>
                                </ul>
                            </dd>
                        </dl>
                        <dl class="clearfix iteminfo_parameter lh32">
                            <dd>
                                <div class="float-l"><form id="carform" action="cart.aspx" method="get"><input type="hidden" id="cartid" name="id" value="<%=cartid%>" />
                                    <span class="shul-s">數量:</span><div class="shul-box"><input type="text" name="num" id="num" class="spinnerExample" /></div>
                                    <span class="kucun">還剩<span id="ku"><%=stock_quantity%></span>件</span></form>
                                </div>
                            </dd>
                        </dl>
                        <div class="hr">
                        </div>
                    </div>
                    <!--规格属性-->
                </div>
                <script>
                    //价格json
                    var sys_item = {
                        "mktprice": "<%=model.point.ToString("0.")%>",
                        "price": "<%=model.point.ToString("0.")%>",
                        "cartid": "<%=cartid%>",
                        "stock_quantity": "<%=stock_quantity%>",
                        "img_url": "<%=img_url%>",
                        "sys_attrprice": { <%=goodlist%>}
                    };
                        $(function () {
                         if(<%=stock_quantity%><1)
                            {$('#gwc').hide();$('#quehuo').show();}else {$('#gwc').show();$('#quehuo').hide(); }
                             })

                    //商品规格选择
                    $(function () {
                        $(".sys_item_spec .sys_item_specpara").each(function () {
                            var i = $(this);
                            var p = i.find("ul>li");
                            p.click(function () {
                                if (!!$(this).hasClass("selected")) {
                                    $(this).removeClass("selected");
                                    i.removeAttr("data-attrval");
                                } else {
                                    $(this).addClass("selected").siblings("li").removeClass("selected");
                                    i.attr("data-attrval", $(this).attr("data-aid"))
                                }
                                getattrprice() //输出价格
                            })
                        })

                        //获取对应属性的价格
                        function getattrprice() {
                            var defaultstats = true;
                            var _val = '';
                            var _resp = {
                                mktprice: ".sys_item_mktprice",
                                price: ".sys_item_price"
                            }  //输出对应的class
                            $(".sys_item_spec .sys_item_specpara").each(function () {
                                var i = $(this);
                                var v = i.attr("data-attrval");
                                if (!v) {
                                    defaultstats = false;
                                } else {
                                    _val += _val != "" ? "_" : "";
                                    _val += v;
                                }
                            })
                            if (!!defaultstats) {
                                _mktprice = sys_item['sys_attrprice'][_val]['mktprice'];
                                _price = sys_item['sys_attrprice'][_val]['price'];
                                _cartid = sys_item['sys_attrprice'][_val]['cartid'];
                                _stock_quantity = sys_item['sys_attrprice'][_val]['stock_quantity'];
                                _img_url =sys_item['sys_attrprice'][_val]['img_url'];
                                
                            } else {
                                _mktprice = sys_item['mktprice'];
                                _price = sys_item['price'];
                                _cartid = sys_item['cartid'];
                                _stock_quantity = sys_item['stock_quantity'];
                                _img_url = sys_item['img_url'];
                            }
                            //输出价格
                            $(_resp.mktprice).text(_mktprice);  ///其中的math.round为截取小数点位数
                            $(_resp.price).text(_price);
                            $('#cartid').val(_cartid);
                            $('#ku').text(_stock_quantity);
                            $('#da_img').attr("src",_img_url);
                            $('#xiao_img').attr("src",_img_url);
							$('.cloudzoom').attr("src",_img_url);
							$('.cloudzoom').attr("zoomImage",_img_url);
							$('.cloudzoom').attr("Image",_img_url);
						  if(_stock_quantity><%=config.txt_Shen%>)
                            {$('#kc').hide();}else {$('#kc').show(); }

                              if(_stock_quantity<1)
                            {$('#gwc').hide();$('#quehuo').show();}else {$('#gwc').show();$('#quehuo').hide(); }
							
                        }
                    })
                </script>
                <div class="detail-btn" id="gwc">

                    <a href="javascript:;" onClick="CartAdd(this, '/', 0, '/shop/show.aspx?id=<%=model.id%>');" class="cart-btn">加入購物車</a> <a href="javascript:;" onclick="javascript:$('#carform').submit();" class="Collection-btn">直接結帳</a>
                </div>
                <div class="detail-btn" id="quehuo" style="display:none;">
                    <a href="javascript:;" class="Collection-btn">無庫存補貨中</a>
                </div>
                <%if (model.is_msg ==0)
                  { %>
                <span class="detail-tips red">❈此商品不配送至海外</span>
                <%} %>
                <%if (model.brand_id == 2)
                  { %>
                <span class="detail-tips red"><%=model.update_time.GetValueOrDefault().ToString("yyyy-MM-dd")%></span>
                <%} %>
            </div>
            <div class="clear">
            </div>
            <div id="Tabs1">
                <ul>
                    <li><a href="#tabs-1"><%=gettag(model.tags,0)%></a></li>
                    <li><a href="#tabs-2"><%=gettag(model.tags,1)%></a></li>
                    <li><a href="#tabs-3"><%=gettag(model.tags,2)%></a></li>
                </ul>
                <div id="tabs-1">
                    <div class="detail-detail">
                        <%=model.content%>
                    </div>
                </div>
                <div id="tabs-2">
                    <div class="detail-detail">
                        <%=model.guigemore%>
                    </div>
                </div>
                <div id="tabs-3">
                    <div class="detail-detail">
                         <%=model.shuoming%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
    <div class="width-sys detail-tj">
        <div class="index-title-box">
            推薦商品<em>Recommended goods</em></div>
        <div id="owl-demo1" class="owl-carousel">
            <asp:Repeater ID="data_tui" runat="server"><ItemTemplate>
            <div class="item">
                <div class="list-detail">
                    <ul>
                        <li><a href="show.aspx?id=<%#Eval("id")%>"><img src="<%#Eval("img_url")%>" alt="<%#Eval("title")%>" /></a>
                            <div class="list-title"><a href="show.aspx?id=<%#Eval("id")%>"><%#Eval("title")%></a></div>
                            <div class="list-ps"><span class="sale"><%#get_sales(Eval("id").ToString())%></span> <span class="price">NT$<%#getprice(Eval("id").ToString())%></span></div>
                        </li>
                    </ul>
                </div>
            </div>
            </ItemTemplate></asp:Repeater>
        </div>
    </div>
    <public:foot ID="foot" runat="server" />
    <script src="/owl-carousel/owl.carousel.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <script src="/assets/js/bootstrap-collapse.js"></script>
    <script src="/assets/js/bootstrap-transition.js"></script>
    <script src="/assets/js/bootstrap-tab.js"></script>
    <script src="/assets/js/google-code-prettify/prettify.js"></script>
    <script src="/assets/js/application.js"></script>
    <script type="text/javascript">
$( document ).ready(function($) {
	$("#owl-demo1").owlCarousel({
        items :5,
        lazyLoad : true,
        navigation : true,
		autoPlay : true,
		buttons: false,
		arrows: false,
		itemsDesktop : [1530,5],
		itemsDesktopSmall : [1360,4],
		itemsTablet : [1024,3],
		itemsTablet : [800,2],
		itemsTabletSmall : false,
		itemsMobile : [470,2],
      });
  $("#detail_pic").owlCarousel({
        items :5,
        lazyLoad : true,
        navigation : true,
		autoPlay : false,
		buttons: false,
		arrows: false,
		itemsDesktop : [1530,5],
		itemsDesktopSmall : [1360,4],
		itemsTablet : [1024,3],
		itemsTablet : [800,2],
		itemsTabletSmall : false,
		itemsMobile : [470,2],
      });
});
    </script>
    <script type="text/javascript" src="/js/jquery.spinner.js"></script>
    <script type="text/javascript">
        $('.spinnerExample').spinner({});
        $(function () {
            $("#Tabs1").tabs();
        });
    </script>
</body>
</html>
