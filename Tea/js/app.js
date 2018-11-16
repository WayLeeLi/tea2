// JavaScript Document
function opentc(){
			$('.tc-box-bg').show();
		};
		function closetc(){
			$('.tc-box-bg').hide();
		};
$(document).ready(function() {
	

$(".go-top").click(function() {
      $("html,body").animate({scrollTop:0}, 500);
  }); 
if($(".detail-btn").length > 0) {
    $(".footer").css({"padding-bottom" : 45});
}
if($(".order-btn").length > 0) {
    $(".footer").css({"padding-bottom" : 45});
}
var winw=$(window).width();
if(winw > 800){

    $(".footer").css({"margin-bottom" : 0});

}
$(".wap-open").click(
	function(){
		if($('.hand-r').is(":hidden")){
			$('.hand-r').show();
		
			}
			else{
				$('.hand-r').hide();
				
				}
		}
);
var listpf=$(".list-four-sub li>a img").width();
  $(".list-four-sub li>a img").css({"height" : listpf});
  var listpfo=$(".list-one").width();
  $(".list-one>a img").css({"height" : listpfo});
  var listpt=$(".list-two li").width();
  $(".list-two li>a img").css({"height" : listpt});
  var listpfi=$(".list-four li").width();
  $(".list-four li>a img").css({"height" : listpfi});
  var listpd=$(".list-detail").width();
  $(".list-detail li>a img").css({"height" : listpd + "%"});
  
  var listpftj=$(".detail-tj").width()/5-40;
  $(".detail-tj .list-detail li>a img").css({"height" : listpftj});
	if(winw < 1360){
		 var listpftj=$(".detail-tj").width()/4-40;
  $(".detail-tj .list-detail li>a img").css({"height" : listpftj});
		}
		if(winw < 1024){
		 var listpftj=$(".detail-tj").width()/4-40;
  $(".detail-tj .list-detail li>a img").css({"height" : listpftj});
		}
		if(winw < 800){
		 var listpftj=$(".detail-tj").width()/2-40;
  $(".detail-tj .list-detail li>a img").css({"height" : listpftj});
		}	
if(winw < 800){
$(".fenleib").click(
	function(){
		if($('.nav-down').is(":hidden")){
			$('.nav-down').show();
		
			}
			else{
				$('.nav-down').hide();
				
				}
		}
);}
$(".wap-opens").click(
	function(){
		if($('.hand-r').is(":hidden")){
			$('.hand-r').show();
			$('.s-box').hide();
			$('.nav-box').show();
			$(".hand-r").css({"top" : "auto"});
			$(".hand-r").css({"bottom" : 57});
			}
			else{
				$('.hand-r').hide();
				$('.s-box').hide();
			$('.nav-box').hide();
			$(".hand-r").css({"top" : handt});
			$(".hand-r").css({"bottom" : "auto"});
				}
		}
);
$(".pro-lbx").click(
	function(){
		if($('.sub-left').is(":hidden")){
			$('.sub-left').show();
			}
			else{
				$('.sub-left').hide();
				}
		}
);
$(".member-mc").click(
	function(){
		if($('.member-nav').is(":hidden")){
			$('.member-nav').show();
			}
			else{
				$('.member-nav').hide();
				}
		}
);
$(".go-top").click(
	function(){
		
		}
);


});


$(document).resize(function() {
	


if($(".detail-btn").length > 0) {
    $(".footer").css({"padding-bottom" : 45});
}
if($(".order-btn").length > 0) {
    $(".footer").css({"padding-bottom" : 45});
}
var winw=$(window).width();
if(winw > 800){

    $(".footer").css({"margin-bottom" : 0});

}
$(".wap-open").click(
	function(){
		if($('.hand-r').is(":hidden")){
			$('.hand-r').show();
		
			}
			else{
				$('.hand-r').hide();
				
				}
		}
);
var listpf=$(".list-four-sub li>a img").width();
  $(".list-four-sub li>a img").css({"height" : listpf});
  var listpfo=$(".list-one").width();
  $(".list-one>a img").css({"height" : listpfo});
  var listpt=$(".list-two li").width();
  $(".list-two li>a img").css({"height" : listpt});
  var listpfi=$(".list-four li").width();
  $(".list-four li>a img").css({"height" : listpfi});
  var listpd=$(".list-detail").width();
  $(".list-detail li>a img").css({"height" : listpd + "%"});
  
  var listpftj=$(".detail-tj").width()/5-40;
  $(".detail-tj .list-detail li>a img").css({"height" : listpftj});
	if(winw < 1360){
		 var listpftj=$(".detail-tj").width()/4-40;
  $(".detail-tj .list-detail li>a img").css({"height" : listpftj});
		}
		if(winw < 1024){
		 var listpftj=$(".detail-tj").width()/4-40;
  $(".detail-tj .list-detail li>a img").css({"height" : listpftj});
		}
		if(winw < 800){
		 var listpftj=$(".detail-tj").width()/2-40;
  $(".detail-tj .list-detail li>a img").css({"height" : listpftj});
		}	
if(winw < 800){
$(".fenleib").click(
	function(){
		if($('.nav-down').is(":hidden")){
			$('.nav-down').show();
		
			}
			else{
				$('.nav-down').hide();
				
				}
		}
);}
$(".wap-opens").click(
	function(){
		if($('.hand-r').is(":hidden")){
			$('.hand-r').show();
			$('.s-box').hide();
			$('.nav-box').show();
			$(".hand-r").css({"top" : "auto"});
			$(".hand-r").css({"bottom" : 57});
			}
			else{
				$('.hand-r').hide();
				$('.s-box').hide();
			$('.nav-box').hide();
			$(".hand-r").css({"top" : handt});
			$(".hand-r").css({"bottom" : "auto"});
				}
		}
);
$(".pro-lbx").click(
	function(){
		if($('.sub-left').is(":hidden")){
			$('.sub-left').show();
			}
			else{
				$('.sub-left').hide();
				}
		}
);
$(".member-mc").click(
	function(){
		if($('.member-nav').is(":hidden")){
			$('.member-nav').show();
			}
			else{
				$('.member-nav').hide();
				}
		}
);
$(".go-top").click(
	function(){
		
		}
);


});