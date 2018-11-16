<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sys_config.aspx.cs" Inherits="Tea.Web.admin.settings.sys_config" ValidateRequest="false" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>系統參數設置</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
<script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
<script type="text/javascript" src="../../scripts/minicolors/jquery.minicolors.min.js"></script>
<link href="../../scripts/minicolors/jquery.minicolors.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表單驗證
        $("#form1").initValidform();
        //初始化上傳控制項
        $(".upload-img").each(function () {
            $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
        });
        $(".mini-colors").minicolors();
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--巡覽列-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>系統設定</span>
</div>
<div class="line10"></div>
<!--/巡覽列-->

<!--內容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">系統基本資訊</a></li>
        <li style="display:none;"><a href="javascript:;">功能許可權設置</a></li>
        <li style="display:none;"><a href="javascript:;">簡訊平台設置</a></li>
        <li><a href="javascript:;">郵件發送設置</a></li>
        <li style="display:none;"><a href="javascript:;">檔案上傳設置</a></li>
      </ul>
    </div>
  </div>
</div>

<!--主站基本資訊-->
<div class="tab-content">
  <dl>
    <dt>最大可購買數量</dt>
    <dd>
      <asp:TextBox ID="txt_Da" runat="server"  CssClass="input small" datatype="n" sucmsg=" " />
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
    <dl>
    <dt>剩餘商品數量</dt>
    <dd>
      <asp:TextBox ID="txt_Shen" runat="server"  CssClass="input small" datatype="n" sucmsg=" " />
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
   <dl>
    <dt>送貨天數</dt>
    <dd>
      <asp:TextBox ID="commentstatus" runat="server"  CssClass="input small" datatype="n" sucmsg=" " />
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>主站名稱</dt>
    <dd>
      <asp:TextBox ID="webname" runat="server" CssClass="input normal" datatype="*2-255" sucmsg=" " />
      <span class="Validform_checktip">*任意字元，控制在255個字元內</span>
    </dd>
  </dl>
  <dl>
    <dt>主站功能變數名稱</dt>
    <dd>
      <asp:TextBox ID="weburl" runat="server" CssClass="input normal" datatype="url" sucmsg=" " />
      <span class="Validform_checktip">*以“http://”開頭，不能綁定到頻道分類</span>
    </dd>
  </dl>
  <dl>
    <dt>網站LOGO</dt>
    <dd>
      <asp:TextBox ID="weblogo" runat="server" CssClass="input normal upload-path" />
      <div class="upload-box upload-img"></div>
    </dd>
  </dl>
 
  <dl>
    <dt>公司名稱</dt>
    <dd>
      <asp:TextBox ID="webcompany" runat="server" CssClass="input normal" />
    </dd>
  </dl>
  <dl>
    <dt>通訊地址</dt>
    <dd>
      <asp:TextBox ID="webaddress" runat="server" CssClass="input normal" />
    </dd>
  </dl>
  <dl>
    <dt>客服電話</dt>
    <dd>
      <asp:TextBox ID="webtel" runat="server" CssClass="input normal" />
      <span class="Validform_checktip">*非必填，區號+電話號碼</span>
    </dd>
  </dl>
  <dl>
    <dt>傳真號碼</dt>
    <dd>
      <asp:TextBox ID="webfax" runat="server" CssClass="input normal" />
      <span class="Validform_checktip">*非必填，區號+傳真號碼</span>
    </dd>
  </dl>
  <dl>
    <dt>管理員郵箱</dt>
    <dd>
      <asp:TextBox ID="webmail" runat="server" CssClass="input normal" />
    </dd>
  </dl>

  <dl>
    <dt>首頁標題(SEO)</dt>
    <dd>
      <asp:TextBox ID="webtitle" runat="server" CssClass="input normal" />
      <span class="Validform_checktip">*自定義的首頁標題</span>
    </dd>
  </dl>
  <dl>
    <dt>頁面關鍵字(SEO)</dt>
    <dd>
      <asp:TextBox ID="webkeyword" runat="server" CssClass="input normal" />
      <span class="Validform_checktip">頁面關鍵字(keyword)</span>
    </dd>
  </dl>
  <dl>
    <dt>頁面描述(SEO)</dt>
    <dd>
      <asp:TextBox ID="webdescription" runat="server" CssClass="input normal" />
      <span class="Validform_checktip">頁面描述(description)</span>
    </dd>
  </dl>
  <dl>
    <dt>網站版權訊息</dt>
    <dd>
      <asp:TextBox ID="webcopyright" runat="server" CssClass="input" TextMode="MultiLine" />
      <span class="Validform_checktip">支持HTML</span>
    </dd>
  </dl>
  <dl>
    <dt>隱私條款</dt>
    <dd>
      <asp:TextBox ID="webcrod" runat="server" CssClass="input" TextMode="MultiLine" />
    </dd>
  </dl>
  <dl  style="display:none">
    <dt>系統公告</dt>
    <dd>
      <asp:TextBox ID="webclosereason" runat="server" CssClass="input" TextMode="MultiLine" />
      <span class="Validform_checktip">支持HTML</span>
    </dd>
  </dl>
</div>
<!--/網站基本資訊-->


<!--功能許可權設置-->
<div class="tab-content" style="display:none">
  <dl>
    <dt>網站安裝目錄</dt>
    <dd>
      <asp:TextBox ID="webpath" runat="server" CssClass="input txt" datatype="*1-100" sucmsg=" " />
      <span class="Validform_checktip">*根目錄輸入“/”，其它輸入“/目錄名/”</span>
    </dd>
  </dl>
  <dl>
    <dt>後台管理目錄</dt>
    <dd>
      <asp:TextBox ID="webmanagepath" runat="server" CssClass="input txt" datatype="*1-100" sucmsg=" " />
      <span class="Validform_checktip">*默認admin，其它請輸入目錄名，否則無法進入後臺</span>
    </dd>
  </dl>
  <dl>
    <dt>URL重寫開關</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="staticstatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="0" Selected="True">關閉</asp:ListItem>
        <asp:ListItem Value="1">偽URL重寫</asp:ListItem>
        <asp:ListItem Value="2">生成靜態</asp:ListItem>
        </asp:RadioButtonList>
      </div>
      <span class="Validform_checktip">*URL配置規則，點擊這裡查看說明</span>
    </dd>
  </dl>
  <dl>
    <dt>靜態URL尾碼</dt>
    <dd>
      <asp:TextBox ID="staticextension" runat="server" CssClass="input small" datatype="*1-100" sucmsg=" " />
      <span class="Validform_checktip">*副檔名，不包括“.”，訪問或生成時將會替換此值，如：aspx、html</span>
    </dd>
  </dl>
  <dl>
    <dt>開啟會員功能</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="memberstatus" runat="server" />
      </div>
      <span class="Validform_checktip">*關閉後關聯會員的內容將失效</span>
    </dd>
  </dl>

  <dl>
    <dt>開啟管理日誌</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="logstatus" runat="server" />
      </div>
      <span class="Validform_checktip">*開啟後將會記錄管理員在後台的操作日誌</span>
    </dd>
  </dl>
  <dl>
    <dt>是否開啟網站</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="webstatus" runat="server" />
      </div>
      <span class="Validform_checktip">*關閉後網站前台將不能訪問</span>
    </dd>
  </dl>

  <dl>
    <dt>網站統計代碼</dt>
    <dd>
      <asp:TextBox ID="webcountcode" runat="server" CssClass="input" TextMode="MultiLine" />
      <span class="Validform_checktip">支持HTML</span>
    </dd>
  </dl>
</div>
<!--/功能許可權設置-->

<!--手機簡訊設置-->
<div class="tab-content" style="display:none">
  <dl>
    <dt>簡訊剩餘數量</dt>
    <dd>
      <asp:Label ID="labSmsCount" runat="server" />
      <span class="Validform_checktip">尚未申請？<a href="http://sms.dtcms.net" target="_blank">請點擊這裡註冊</a></span>
    </dd>
  </dl>
  <dl>
    <dt>簡訊API地址</dt>
    <dd>
      <asp:TextBox ID="smsapiurl" runat="server" CssClass="input normal" />
      <span class="Validform_checktip">*以“http://”開頭</span>
    </dd>
  </dl>
  <dl>
    <dt>平台登入帳戶</dt>
    <dd>
      <asp:TextBox ID="smsusername" runat="server" CssClass="input txt" />
      <span class="Validform_checktip">*簡訊平台註冊的用戶名</span>
    </dd>
  </dl>
  <dl>
    <dt>平台登入密碼</dt>
    <dd>
      <asp:TextBox ID="smspassword" runat="server" CssClass="input txt" TextMode="Password" />
      <span class="Validform_checktip">*簡訊平台註冊的密碼</span>
    </dd>
  </dl>
</div>
<!--/手機簡訊設置-->

<!--郵件發送設置-->
<div class="tab-content" style="display:none">
  <dl>
    <dt>SMTP伺服器</dt>
    <dd>
      <asp:TextBox ID="emailsmtp" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " />
      <span class="Validform_checktip">*發送郵件的SMTP伺服器地址</span>
    </dd>
  </dl>
  <dl>
    <dt>SSL加密連接</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="emailssl" runat="server" />
      </div>
      <span class="Validform_checktip">*是否啟用SSL加密連接</span>
    </dd>
  </dl>
  <dl>
    <dt>SMTP埠</dt>
    <dd>
      <asp:TextBox ID="emailport" runat="server" CssClass="input small" datatype="n" sucmsg=" " />
      <span class="Validform_checktip">*SMTP伺服器的埠，大部分服務商都支援25埠</span>
    </dd>
  </dl>
  <dl>
    <dt>寄件者地址</dt>
    <dd>
      <asp:TextBox ID="emailfrom" runat="server" CssClass="input normal" datatype="e" sucmsg=" " />
      <span class="Validform_checktip">*寄件者的郵箱地址</span>
    </dd>
  </dl>
  <dl>
    <dt>Email</dt>
    <dd>
      <asp:TextBox ID="emailusername" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " />
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>郵箱密碼</dt>
    <dd>
      <asp:TextBox ID="emailpassword" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " TextMode="Password" />
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>寄件者暱稱</dt>
    <dd>
      <asp:TextBox ID="emailnickname" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " />
      <span class="Validform_checktip">*對方收到郵件時顯示的暱稱</span>
    </dd>
  </dl>
</div>
<!--/郵件發送設置-->

<!--上傳配置-->
<div class="tab-content" style="display:none">
  <dl>
    <dt>檔上傳目錄</dt>
    <dd>
      <asp:TextBox ID="filepath" runat="server" CssClass="input txt" datatype="*2-100" sucmsg=" " />
      <span class="Validform_checktip">*檔儲存的目錄名，自動創建根目錄下</span>
    </dd>
  </dl>
  <dl>
    <dt>檔案儲存方式</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="filesave" runat="server" datatype="*" sucmsg=" ">
          <asp:ListItem Value="1">按年月日每天一個目錄</asp:ListItem>
          <asp:ListItem Value="2" Selected="True">按年月/日/存入不同目錄</asp:ListItem>
        </asp:DropDownList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>文件上傳類型</dt>
    <dd>
      <asp:TextBox ID="fileextension" runat="server" CssClass="input normal" datatype="*1-500" sucmsg=" " />
      <span class="Validform_checktip">*以英文的逗號分隔開，如：“zip,rar”</span>
    </dd>
  </dl>
  <dl>
    <dt>視頻上傳類型</dt>
    <dd>
      <asp:TextBox ID="videoextension" runat="server" CssClass="input normal" datatype="*1-500" sucmsg=" " />
      <span class="Validform_checktip">*以英文的逗號分隔開，如：“mp4,flv”</span>
    </dd>
  </dl>
  <dl>
    <dt>附件上傳大小</dt>
    <dd>
      <asp:TextBox ID="attachsize" runat="server" CssClass="input small" datatype="n" sucmsg=" " /> KB
      <span class="Validform_checktip">*超過設定的檔大小不予上傳，0不限制</span>
    </dd>
  </dl>
  <dl>
    <dt>視頻上傳大小</dt>
    <dd>
      <asp:TextBox ID="videosize" runat="server" CssClass="input small" datatype="n" sucmsg=" " /> KB
      <span class="Validform_checktip">*超過設定的檔大小不予上傳，0不限制</span>
    </dd>
  </dl>
  <dl>
    <dt>圖片上傳大小</dt>
    <dd>
      <asp:TextBox ID="imgsize" runat="server" CssClass="input small" datatype="n" sucmsg=" " /> KB
      <span class="Validform_checktip">*超過設定的圖片大小不予上傳，0不限制</span>
    </dd>
  </dl>
  <dl>
    <dt>圖片最大尺寸</dt>
    <dd>
      <asp:TextBox ID="imgmaxheight" runat="server" CssClass="input small" datatype="n" sucmsg=" " /> ×
      <asp:TextBox ID="imgmaxwidth" runat="server" CssClass="input small" datatype="n" sucmsg=" " /> px
      <span class="Validform_checktip">*左邊高度，右邊寬度，超出自動裁剪，0為不受限制</span>
    </dd>
  </dl>
  <dl>
    <dt>縮略圖生成尺寸</dt>
    <dd>
      <asp:TextBox ID="thumbnailheight" runat="server" CssClass="input small" datatype="n" sucmsg=" " /> ×
      <asp:TextBox ID="thumbnailwidth" runat="server" CssClass="input small" datatype="n" sucmsg=" " /> px
      <span class="Validform_checktip">*左邊高度，右邊寬度，0為不生成縮略圖</span>
    </dd>
  </dl>
  <dl>
    <dt>圖片浮水印類型</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="watermarktype" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="0">關閉浮水印</asp:ListItem>
        <asp:ListItem Value="1">文字浮水印</asp:ListItem>
        <asp:ListItem Value="2">圖片浮水印</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>圖片浮水印位置</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="watermarkposition" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1">左上</asp:ListItem>
        <asp:ListItem Value="2">中上</asp:ListItem>
        <asp:ListItem Value="3">右上</asp:ListItem>
        <asp:ListItem Value="4">左中</asp:ListItem>
        <asp:ListItem Value="5">居中</asp:ListItem>
        <asp:ListItem Value="6">右中</asp:ListItem>
        <asp:ListItem Value="7">左下</asp:ListItem>
        <asp:ListItem Value="8">中下</asp:ListItem>
        <asp:ListItem Value="9">右下</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>圖片生成品質</dt>
    <dd>
      <asp:TextBox ID="watermarkimgquality" runat="server" CssClass="input small" datatype="n" sucmsg=" " />
      <span class="Validform_checktip">*只適用於加浮水印的jpeg格式圖片.取值範圍 0-100, 0品質最低, 100品質最高, 默認80</span>
    </dd>
  </dl>
  <dl>
    <dt>圖片浮水印檔</dt>
    <dd>
      <asp:TextBox ID="watermarkpic" runat="server" CssClass="input txt" datatype="s2-100" sucmsg=" " />
      <span class="Validform_checktip">*需存放在網站目錄下，如圖片不存在將使用文字浮水印</span>
    </dd>
  </dl>
  <dl>
    <dt>浮水印透明度</dt>
    <dd>
      <asp:TextBox ID="watermarktransparency" runat="server" CssClass="input small" datatype="n" sucmsg=" " />
      <span class="Validform_checktip">*取值範圍1--10 (10為不透明)</span>
    </dd>
  </dl>
  <dl>
    <dt>浮水印文字</dt>
    <dd>
      <asp:TextBox ID="watermarktext" runat="server" CssClass="input txt" datatype="s2-100" sucmsg=" " />
      <span class="Validform_checktip">*文字浮水印的內容</span>
    </dd>
  </dl>
  <dl>
    <dt>文字字體</dt>
    <dd>
      <div class="rule-single-select up">
        <asp:DropDownList id="watermarkfont" runat="server">
          	<asp:ListItem Value="Arial">Arial</asp:ListItem>
	        <asp:ListItem Value="Arial Black">Arial Black</asp:ListItem>
	        <asp:ListItem Value="Batang">Batang</asp:ListItem>
	        <asp:ListItem Value="BatangChe">BatangChe</asp:ListItem>
	        <asp:ListItem Value="Comic Sans MS">Comic Sans MS</asp:ListItem>
	        <asp:ListItem Value="Courier New">Courier New</asp:ListItem>
	        <asp:ListItem Value="Dotum">Dotum</asp:ListItem>
	        <asp:ListItem Value="DotumChe">DotumChe</asp:ListItem>
	        <asp:ListItem Value="Estrangelo Edessa">Estrangelo Edessa</asp:ListItem>
	        <asp:ListItem Value="Franklin Gothic Medium">Franklin Gothic Medium</asp:ListItem>
	        <asp:ListItem Value="Gautami">Gautami</asp:ListItem>
	        <asp:ListItem Value="Georgia">Georgia</asp:ListItem>
	        <asp:ListItem Value="Gulim">Gulim</asp:ListItem>
	        <asp:ListItem Value="GulimChe">GulimChe</asp:ListItem>
	        <asp:ListItem Value="Gungsuh">Gungsuh</asp:ListItem>
	        <asp:ListItem Value="GungsuhChe">GungsuhChe</asp:ListItem>
	        <asp:ListItem Value="Impact">Impact</asp:ListItem>
	        <asp:ListItem Value="Latha">Latha</asp:ListItem>
	        <asp:ListItem Value="Lucida Console">Lucida Console</asp:ListItem>
	        <asp:ListItem Value="Lucida Sans Unicode">Lucida Sans Unicode</asp:ListItem>
	        <asp:ListItem Value="Mangal">Mangal</asp:ListItem>
	        <asp:ListItem Value="Marlett">Marlett</asp:ListItem>
	        <asp:ListItem Value="Microsoft Sans Serif">Microsoft Sans Serif</asp:ListItem>
	        <asp:ListItem Value="MingLiU">MingLiU</asp:ListItem>
	        <asp:ListItem Value="MS Gothic">MS Gothic</asp:ListItem>
	        <asp:ListItem Value="MS Mincho">MS Mincho</asp:ListItem>
	        <asp:ListItem Value="MS PGothic">MS PGothic</asp:ListItem>
	        <asp:ListItem Value="MS PMincho">MS PMincho</asp:ListItem>
	        <asp:ListItem Value="MS UI Gothic">MS UI Gothic</asp:ListItem>
	        <asp:ListItem Value="MV Boli">MV Boli</asp:ListItem>
	        <asp:ListItem Value="Palatino Linotype">Palatino Linotype</asp:ListItem>
	        <asp:ListItem Value="PMingLiU">PMingLiU</asp:ListItem>
	        <asp:ListItem Value="Raavi">Raavi</asp:ListItem>
	        <asp:ListItem Value="Shruti">Shruti</asp:ListItem>
	        <asp:ListItem Value="Sylfaen">Sylfaen</asp:ListItem>
	        <asp:ListItem Value="Symbol">Symbol</asp:ListItem>
	        <asp:ListItem Value="Tahoma" Selected="True">Tahoma</asp:ListItem>
	        <asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
	        <asp:ListItem Value="Trebuchet MS">Trebuchet MS</asp:ListItem>
	        <asp:ListItem Value="Tunga">Tunga</asp:ListItem>
	        <asp:ListItem Value="Verdana">Verdana</asp:ListItem>
	        <asp:ListItem Value="Webdings">Webdings</asp:ListItem>
	        <asp:ListItem Value="Wingdings">Wingdings</asp:ListItem>
	        <asp:ListItem Value="仿宋_GB2312">仿宋_GB2312</asp:ListItem>
	        <asp:ListItem Value="宋體">宋體</asp:ListItem>
	        <asp:ListItem Value="新宋體">新宋體</asp:ListItem>
	        <asp:ListItem Value="楷體_GB2312">楷體_GB2312</asp:ListItem>
	        <asp:ListItem Value="黑體">黑體</asp:ListItem>
        </asp:DropDownList>
      </div>
      <asp:TextBox ID="watermarkfontsize" runat="server" CssClass="input small" datatype="n" sucmsg=" " /> px
      <span class="Validform_checktip">*文字浮水印的字體和大小 </span>
    </dd>
  </dl>
</div>
<!--/上傳配置-->

<!--/內容-->

<!--工具列-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSubmit" runat="server" Text="確認送出" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn"  style="display:none;"type="button" value="返回上一頁" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/工具列-->
</form>
</body>
</html>
