 
var isEmail=function(str){var pat=/^(.+)@(.+)$/;return pat.exec(str)!=null;};
var hz=function(str){var pat=/^[\u4e00-\u9fa5]{0,}$/;return pat.test(str);};
var isTel=function(s){var pat=/^[+]?[0-9]+[-]?[0-9]+([-]?[0-9]+)+$/;return pat.exec(s)!=null;};
var isQq=function(s){var p=/^[0-9]{8,10}$/;return p.exec(s)!=null;};
var ispwd=function(s){var p=/^[A-Za-z0-9]{6,12}$/;return p.exec(s)!=null;};

var ispwd1=function(s){var p=/^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,12}$/;return p.exec(s)!=null;};
  

var isFloat=function(s){var pat=/^\d{0,10}.?\d{0,5}$/; return pat.exec(s)!=null;};
var isInt=function(s){var pat=/^\d{0,10}$/;return pat.exec(s)!=null;};
var isNull=function(str){return str==null||str.length<1};
var isDate=function(str){var p=/^[12]{1}\d{3}[-\/\\]{1,}\d{1,2}[-\\\/]{1,}[123]?\d{1}$/; return p.exec(str)!=null;};
var isLeapYear=function(y){return (y%4==0&&0!=y%100)||0==y%400;};
var isCode=function(str){return str.match(/[\/|!|#|$|%|&|\(|\)|\*|+|,|\-|.|:|<|>|\?|@|\/|\"|\'|\\|\[|\]|\^|`|\{|\=|\;|\||\}]/ig)};
 
var isMob=function(v){
   var a = /^[0]{1}[0-9]{9}$/;
   return a.exec(v)!=null;
};
 
var _check_={
    a:10,
	b:11,
	c:12,
	d:13,
	e:14,
	f:15,
	g:16,
	h:17,
	j:18,
	k:19,
	l:20,
	m:21,
	n:22,
	p:23,
	q:24,
	r:25,
	s:26,
	t:27,
	u:28,
	v:29,
	w:32,
	x:30,
	y:31,
	z:33,
	i:34,
	o:35
};
//驗證身份證編號ss
var checkNo=function(e){
    var f=checkNo_chatector(e);
	   if(f){
          var s=e.substring(0,1).toLowerCase();
          var _s=_check_[s];
		  var _x1=_s%10;
		  var _x2=parseInt(_s/10);
		  var no=e.substring(1,e.length-1);
		  var v=_x2+_x1*9;
		  var j=8;
		  for(var i=0;i<no.length;i++){
		      var temp=no.substring(i,i+1);
		      v+=j--*temp;
		  }
		  v=v%10;
		  v=v%10;
		  if(v>0){
		  v=10-v;
		  }
		  f=(v==e.substring(9));
	  }
	  return f;
};
var checkNo_chatector=function(s){
   var v= /^[a-zA-Z]{1}[1-2]{1}[a-zA-Z0-9]{8}$/;
   return v.exec(s)!=null;
};

 