<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="order" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width">
    <title> <%=title%></title>
    <meta name="Keywords" content="<%=keyword%>" />
    <meta name="Description" content="<%=describe%>" />
    <link href="/jQueryAssets/jquery.ui.core.min.css" rel="stylesheet" type="text/css">
    <link href="/jQueryAssets/jquery.ui.theme.min.css" rel="stylesheet" type="text/css">
    <link href="/jQueryAssets/jquery.ui.tabs.min.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" type="text/css" href="/css/css.css" media="screen">
    <script type="text/javascript" src="/js/jquery-1.11.0.min.js"></script>
    <script src="/js/app.js"></script>
    <script src="/jQueryAssets/jquery.ui-1.10.4.tabs.min.js" type="text/javascript"></script>
    <script type="text/javascript" src='/scripts/city.js'></script>
    <script language="javascript">

        function check() {
            if ($("#txt_name").val() == "") {
                alert("請輸入訂購人姓名");
                $("#txt_name").focus();
                return false;
            }
            if ($("#txt_email").val() == "") {
                alert("請輸入Email");
                $("#txt_email").focus();
                return false;
            }
            if ($('#txt_guo').val() == '台灣') {
                if ($("#txt_state").val() == "") {
                    alert("請選擇縣市");
                    $("#txt_state").focus();
                    return false;
                }
                if ($("#txt_city").val() == "") {
                    alert("請選擇區域");
                    $("#txt_city").focus();
                    return false;
                }
            } else {

                if ($("#txt_state1").val() == "") {
                    alert("請選擇縣市");
                    $("#txt_state1").focus();
                    return false;
                }
                if ($("#txt_city1").val() == "") {
                    alert("請選擇區域");
                    $("#txt_city1").focus();
                    return false;
                }

            }
            if ($("#txt_address").val() == "") {
                alert("請輸入詳細地址");
                $("#txt_address").focus();
                return false;
            }
            if ($("#txt_zip").val() == "") {
                alert("請輸入郵遞區號");
                $("#txt_zip").focus();
                return false;
            }
            if ($("#txt_tel").val() == "") {
                alert("請輸入連絡電話");
                $("#txt_tel").focus();
                return false;
            }


            if ($("#txtname").val() == "") {
                alert("請輸入收件人姓名");
                $("#txtname").focus();
                return false;
            }
            //                if ($("#txtemail").val() == "") {
            //                    alert("請輸入Email");
            //                    $("#txtemail").focus();
            //                    return false;
            //                }
            if ($('#txtguo').val() == '台灣') {

                if ($("#txtstate").val() == "") {
                    alert("請選擇縣市");
                    $("#txtstate").focus();
                    return false;
                }
                if ($("#txtcity").val() == "") {
                    alert("請選擇區域");
                    $("#txtcity").focus();
                    return false;
                }
            }
            else {

                if ($("#txtstate1").val() == "") {
                    alert("請選擇縣市");
                    $("#txtstate1").focus();
                    return false;
                }
                if ($("#txtcity1").val() == "") {
                    alert("請選擇區域");
                    $("#txtcity1").focus();
                    return false;
                }
            }
            if ($("#txtaddress").val() == "") {
                alert("請輸入詳細地址");
                $("#txtaddress").focus();
                return false;
            }
            if ($("#txtzip").val() == "") {
                alert("請輸入郵遞區號");
                $("#txtzip").focus();
                return false;
            }
            if ($("#txtmobile").val() == "") {
                alert("請輸入手機號碼");
                $("#txtmobile").focus();
                return false;
            }
            if ($("#txtinvoice").val() == "3") {
                if ($("#txttong").prop('checked') != true && $("#txttong_2").prop('checked') != true) {
                    alert("請選擇收發票地址");
                    return false;
                }
                if ($("#txttong_2").prop('checked') == true) {
                    if ($('#txtfaaddress_guo').val() == '台灣') {
                        if ($("#txtfaaddress_state").val() == "") {
                            alert("請選擇縣市");
                            $("#txtfaaddress_state").focus();
                            return false;
                        }
                        if ($("#txtfaaddress_city").val() == "") {
                            alert("請選擇區域");
                            $("#txtfaaddress_city").focus();
                            return false;
                        }
                    }
                    else {
                        if ($("#txtfaaddress_state1").val() == "") {
                            alert("請選擇縣市");
                            $("#txtfaaddress_state1").focus();
                            return false;
                        }
                        if ($("#txtfaaddress_city1").val() == "") {
                            alert("請選擇區域");
                            $("#txtfaaddress_city1").focus();
                            return false;
                        }
                    }
                    if ($("#txtfaaddress_zip").val() == "") {
                        alert("請輸入郵編");
                        $("#txtfaaddress_zip").focus();
                        return false;
                    }
                    if ($("#txtfa_address").val() == "") {
                        alert("請輸入詳細地址");
                        $("#txtfa_address").focus();
                        return false;
                    }

                }
            }
            if ($("#txtinvoice").val() == "4") {

                if ($("#txt_invoice_4_1").val() == "") {
                    alert("請輸入統一編號");
                    $("#txt_invoice_4_1").focus();
                    return false;
                }
                if ($("#txt_invoice_4_2").val() == "") {
                    alert("請輸入公司抬頭");
                    $("#txt_invoice_4_2").focus();
                    return false;
                }
                if ($("#txttong1").prop('checked') != true && $("#txttong_3").prop('checked') != true) {
                    alert("請選擇收發票地址");
                    return false;
                }

                if ($("#txttong_3").prop('checked') == true) {
                    if ($('#txt_invoiceaddress_guo').val() == '台灣') {
                        if ($("#txt_invoiceaddress_state").val() == "") {
                            alert("請選擇縣市");
                            $("#txt_invoiceaddress_state").focus();
                            return false;
                        }
                        if ($("#txt_invoiceaddress_city").val() == "") {
                            alert("請選擇區域");
                            $("#txt_invoiceaddress_city").focus();
                            return false;
                        }
                    }
                    else {
                        if ($("#txt_invoiceaddress_state1").val() == "") {
                            alert("請選擇縣市");
                            $("#txt_invoiceaddress_state1").focus();
                            return false;
                        }
                        if ($("#txt_invoiceaddress_city1").val() == "") {
                            alert("請選擇區域");
                            $("#txt_invoiceaddress_city1").focus();
                            return false;
                        }
                    }
                    if ($("#txt_invoiceaddress_zip").val() == "") {
                        alert("請輸入郵編");
                        $("#txt_invoiceaddress_zip").focus();
                        return false;
                    }
                    if ($("#txt_invoice_address").val() == "") {
                        alert("請輸入詳細地址");
                        $("#txt_invoice_address").focus();
                        return false;
                    }


                }
            }
        }

        function ck() {
            if ($("#tong").prop('checked') == true) {

                $("#txtname").val($("#txt_name").val());
                $("#txtguo").val($("#txt_guo").val());
                $("#txtstate1").val($("#txt_state1").val());
                $("#txtcity1").val($("#txt_city1").val());
                $("#txtstate").val($("#txt_state").val());
                xuanze();
                changeArea($("#txtstate").val(), document.all.txtcity)
                // $("#txtemail").val($("#txt_email").val());
                $("#txtcity").val($("#txt_city").val());
                $("#txtaddress").val($("#txt_address").val());
                $("#txtmobile").val($("#txt_tel").val());
                $("#txtzip").val($("#txt_zip").val());
                if ($('#txt_sex_1').prop('checked') == true) {
                    $("#txtsex_1").attr("checked", "checked");
                }
                if ($('#txt_sex_0').prop('checked') == true) {
                    $("#txtsex_0").attr("checked", "checked");
                }
            } else {
                xuanze();
                $("#txtname").val('');
                //$("#txtemail").val('');
                $("#txtguo").val('');
                $("#txtstate1").val('');
                $("#txtcity1").val('');
                $("#txtstate").val('');
                $("#txtcity").val('');
                $("#txtaddress").val('');
                $("#txtmobile").val('');
                $("#txtzip").val('');
                //                    $("#txtsex_1").removeAttr("checked");
                //                    $("#txtsex_0").removeAttr("checked");
            }
        }

        function tb1() {
            if ($("#txttong").prop('checked') == true) {
              
                if ($('#txt_guo').val() == '台灣') {
                    $("#fp_address").text($('#txt_guo').val() + "," + $("#txt_state").val() + "," + $("#txt_city").val() + "," + $("#txt_zip").val() + "," + $("#txt_address").val());
                    $("#txttong").val($('#txt_guo').val() + "," + $("#txt_state").val() + "," + $("#txt_city").val() + "," + $("#txt_zip").val() + "," + $("#txt_address").val());
                }
                else 
                {
                    $("#fp_address").text($('#txt_guo').val() + "," + $("#txt_state1").val() + "," + $("#txt_city1").val() + "," + $("#txt_zip").val() + "," + $("#txt_address").val());
                    $("#txttong").val($('#txt_guo').val() + "," + $("#txt_state1").val() + "," + $("#txt_city1").val() + "," + $("#txt_zip").val() + "," + $("#txt_address").val());
                }
            }
            else {
                $("#txttong").val('');
                $("#fp_address").text('XXX 區 XXX 街 XXX 社區 XX 號')
            }
        }


        function tb2() {
            if ($("#txttong1").prop('checked') == true) {


                if ($('#txt_guo').val() == '台灣') {
                    $("#txttong1").val($('#txt_guo').val() + "," + $("#txt_state").val() + "," + $("#txt_city").val() + "," + $("#txt_zip").val() + "," + $("#txt_address").val());
                    $("#fp_address4").text($('#txt_guo').val() + "," + $("#txt_state").val() + "," + $("#txt_city").val() + "," + $("#txt_zip").val() + "," + $("#txt_address").val());
                }
                else {
                    $("#txttong1").val($('#txt_guo').val() + "," + $("#txt_state1").val() + "," + $("#txt_city1").val() + "," + $("#txt_zip").val() + "," + $("#txt_address").val());
                    $("#fp_address4").text($('#txt_guo').val() + "," + $("#txt_state1").val() + "," + $("#txt_city1").val() + "," + $("#txt_zip").val() + "," + $("#txt_address").val());
                }
            }
            else {
                $("#txttong1").val('');
                $("#fp_address4").text('XXX 區 XXX 街 XXX 社區 XX 號')
            }
        }

    </script>
    <script language="javascript">
        function jisuan() {
       
       // alert($("#sy_yuan").text());
        var real_amount = parseInt($("#real_amount").text());
        var total_zhe = parseInt($("#total_zhe").text());
        var sy_yuan = parseInt($("#sy_yuan").text());
        var sy_honglv = parseInt($("#sy_honglv").text());
        var sy_quan = parseInt($("#sy_quan").text());
        if ((real_amount - total_zhe + sy_yuan - sy_honglv - sy_quan) < 0) {
            $("#zongji").html('0');
        }
        else {
       
            $("#zongji").html(real_amount - total_zhe + sy_yuan - sy_honglv - sy_quan);
            $("#hdpoing").html(Math.round((real_amount - total_zhe - sy_honglv - sy_quan) / <%=uconfig.money_pint%>));
           
        }
            var gift_num=parseInt((parseInt($("#zongji").text())-parseInt($("#yun").val()))/<%=giftmoney%>);
                if(gift_num>0)
                {
                  //  alert(gift_num);
                    $('#giftnum').text(gift_num);
                }
                else
                { 
                // alert(gift_num);
                     $('#giftnum').text('0');
                }

         jihongli();
     
            
    }

    function jihongli()
    {
      if($("#txt_point").val().trimr().length>0 && $("#cbhonglv").prop('checked') == true && $("#txt_point").val().trimr()!="" )
     {          
          $("#dikou_honglv").html(parseInt($("#duipoint").text())+parseInt($("#txt_point").val())); 
       }
       else
       { 
          $("#dikou_honglv").html(parseInt($("#duipoint").text())); 
       }
    }
    </script>
    <script type="text/javascript">
            function get_hongli() {
                if ($("#cbhonglv").prop('checked') == true && $("#txt_point").length>0  && $("#txt_point").val()!="" ) {

   
                    var nyhl=0;
                    var zdhl=parseInt((parseInt($("#zongji").text())-parseInt($("#yun").val()))/100*<%=uconfig.pint_yong%>);//最大金額
                    var nyjine=parseInt(parseInt($('#qbpoint').val())/<%=uconfig.pint_money%>);//能用金額

//                    alert(zdhl);
//                     alert(nyjine);
                    if(zdhl<=nyjine)
                    {
                        nyhl=zdhl*<%=uconfig.pint_money%>;
                    }
                    else
                    {
                         nyhl=nyjine*<%=uconfig.pint_money%>;
                    } 
                    if(isNaN($("#txt_point").val()))
                    {
                         alert('請輸入數字');
                          $('#txt_point').val('0')  
                            $("#sy_honglv").text('0');
                             jisuan();
                    }
                     if(parseInt($('#txt_point').val())<0)
                     {
                      alert('請輸入正整數');
                          $('#txt_point').val('0')  
                            $("#sy_honglv").text('0');
                             jisuan();
                     }
                    if(parseInt($('#txt_point').val())>parseInt($('#qbpoint').val()))
                    {
                        alert('此筆訂單可以使用的紅利點數為'+nyhl+'點');
                           $('#txt_point').val(nyhl)  
                            $("#sy_honglv").text(nyhl);
                         jisuan();
                    }
                    else
                    {
                       if((parseInt($("#real_amount").text())/100*<%=uconfig.pint_yong%>) < (parseInt($('#txt_point').val())/<%=uconfig.pint_money%>))
                        {
                            alert('此筆訂單可以使用的紅利點數為'+nyhl+'點');
                            $('#txt_point').val(nyhl)  
                            $("#sy_honglv").text(nyhl);
                        }
                        if(!Number.isInteger($('#txt_point').val()/<%=uconfig.pint_money%>))
                        {       

                              alert('紅利只能輸入<%=uconfig.pint_money%>倍數');
                               alert('此筆訂單可以使用的紅利點數為'+nyhl+'點');
                            $('#txt_point').val(nyhl)  
                            $("#sy_honglv").text(nyhl);
                        }
                         $("#sy_honglv").text($('#txt_point').val()/<%=uconfig.pint_money%>); 
                          jisuan();
                    }
                    
                }
                else {
                    $("#sy_honglv").text('0');
                    jisuan();
                }
            }
            function get_code() {
                if ($("#cbquan").prop('checked') == true) {
                    $.ajax({
                        type: "post",
                        url: "/tools/code.aspx",
                        data: {
                            "key": $("#txt_zhe").val(),
                            "cart":<%=cart%>
                        },
                        dataType: "json",
                        beforeSend: function (XMLHttpRequest) {
                            //發送前動作
                        },
                        success: function (data, textStatus) {
                            if (data.status == 1) {
                                $('#sy_quan').text(data.info);
                                jisuan();
                            } else {
                                alert('折價代碼不存在或已經使用');
                                $("#txt_zhe").val("");
                                $('#sy_quan').text('0');
                                jisuan();
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert("狀態：" + textStatus + "；出錯提示：" + errorThrown);
                        },
                        timeout: 20000
                    });
                    return false;
                } else {
                $("#txt_zhe").val("");
                $('#sy_quan').text('0');
                jisuan();
                }
        }
        function get_yun() {
  
                $.ajax({
                    type: "post",
                    url: "/tools/yun.aspx",
                    data: {
                        "key": $("#txtguo").val(),
                        "cart":<%=cart%>
                    },
                    dataType: "json",
                    beforeSend: function (XMLHttpRequest) {
                        //發送前動作
                    },
                    success: function (data, textStatus) {
                        if (data.status == 1) {
                            $('#sy_yuan').text(data.info);
                            $('#yun').val(data.info);
                             jisuan();
                        } else {
                             if (data.status == 2)
                             {
                                alert('材積重超出寄送限制，請調整訂單內容');
                             }
                            $('#sy_yuan').text('0');
                            $('#yun').val('0');
                            jisuan();
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("狀態：" + textStatus + "；出錯提示：" + errorThrown);
                    },
                    timeout: 20000
                });

                 
                return false;
           
        }
        function xuan_ze() {
            if ($('#txt_guo').val() == '台灣') {
                $('#txt_state').show();
                $('#txt_city').show();
                $('#txt_state1').hide();
                $('#txt_city1').hide();
            }
            else {
                $('#txt_state1').show();
                $('#txt_city1').show();
                $('#txt_state').hide();
                $('#txt_city').hide();
            }
        }
        $(function () { xuan_ze(); });

        function xuanze() {
            get_yun();
            if ($('#txtguo').val() == '台灣') {
                $('#ysfs').html("宅配");
                $('#txtstate').show();
                $('#txtcity').show();
                $('#txtstate1').hide();
                $('#txtcity1').hide();
                $('#la_1').show();
                $('#la_2').show();
                $('#la_3').show();
                $('#la_4').show();
                $('#la_5').show();
                $('#la_6').show();
                $("#pay_2").removeAttr("checked");
                $("#pay_3").removeAttr("checked");
                $("#pay_4").removeAttr("checked");
                $("#pay_5").removeAttr("checked");
                $("#pay_6").removeAttr("checked");
                $("#pay_1").prop("checked",true);
            }
            else {
                $('#ysfs').html("國際快捷");
                get_yun();
                $('#txtstate1').show();
                $('#txtcity1').show();
                $('#txtstate').hide();
                $('#txtcity').hide();
                $('#la_1').show();
                $('#la_2').hide();
                $('#la_3').hide();
                $('#la_4').show();
                $('#la_5').hide();
                $('#la_6').hide();
                $("#pay_2").removeAttr("checked");
                $("#pay_3").removeAttr("checked");
                $("#pay_4").removeAttr("checked");
                $("#pay_5").removeAttr("checked");
                $("#pay_6").removeAttr("checked");
                $("#pay_1").prop("checked",true);
            }
        }
        $(function () { xuanze(); });



        function xuan_ze_fp() {
            if ($('#txtfaaddress_guo').val() == '台灣') {
                $('#txtfaaddress_state').show();
                $('#txtfaaddress_city').show();
                $('#txtfaaddress_state1').hide();
                $('#txtfaaddress_city1').hide();
            }
            else {
                $('#txtfaaddress_state1').show();
                $('#txtfaaddress_city1').show();
                $('#txtfaaddress_state').hide();
                $('#txtfaaddress_city').hide();
            }
        }
        $(function () { xuan_ze_fp(); });

        function xuan_ze_invo() {
            if ($('#txt_invoiceaddress_guo').val() == '台灣') {
                $('#txt_invoiceaddress_state').show();
                $('#txt_invoiceaddress_city').show();
                $('#txt_invoiceaddress_state1').hide();
                $('#txt_invoiceaddress_city1').hide();
            }
            else {
                $('#txt_invoiceaddress_state1').show();
                $('#txt_invoiceaddress_city1').show();
                $('#txt_invoiceaddress_state').hide();
                $('#txt_invoiceaddress_city').hide();
            }
        }
        $(function () { xuan_ze_invo(); });
    </script>
</head>
<body>
    <public:hand ID="hand" runat="server" />
    <div class="width-sys location">
        <div class="cart-loc wap-none">
            <img src="/images/cart2.png" alt="" /></div>
        <div class="cart-loc wap-show">
            <img src="/images/cart2-1.png" alt="" /></div>
    </div>
    <form id="order" method="post" action="order.aspx?cart=<%=cart%>" onsubmit="javascript:return check();">
    <input type="hidden" name="act" value="act_add" />
    <div class="width-sys">
        <div class=" cart-bg">
            <div class="order-box">
                <div class="order-boxw">
                    <div class="order-box-tit">
                        訂購資訊</div>
                    <div class="order-box-form">
                        <div class="col-m5 float-l">
                            <dl>
                                <dt>訂購人姓名</dt><dd><input type="text" class="ipt-m1" name="txt_name" id="txt_name"
                                    value="<%=userModel.nick_name%>" />
                                    <label>
                                        <input type="radio" name="txt_sex" id="txt_sex_1" value="男" <%=userModel.sex == "男" ? " checked" : ""%> />
                                        先生</label>
                                    <label>
                                        <input type="radio" name="txt_sex" id="txt_sex_0" value="女" <%=userModel.sex == "女" ? " checked" : ""%> />
                                        小姐</label>
                                </dd>
                            </dl>
                            <dl>
                                <dt>連絡電話</dt><dd><input type="text" name="txt_tel" id="txt_tel" class="ipt-m1" value="<%=userModel.mobile%>" /></dd>
                            </dl>
                            <dl>
                                <dt>E-mail信箱</dt><dd><input type="text" name="txt_email" id="txt_email" class="ipt-m4"
                                    value="<%=userModel.email%>" /><em>*請填寫正確電子信箱，以便收到訂單資訊</em></dd>
                            </dl>
                        </div>
                        <div class="col-m5 float-l">
                            <dl>
                                <dt>所在地<em>*</em></dt>
                                <dd>
                                    <div class="select">
                                        <select name="txt_guo" id="txt_guo" class="regest-sel" onchange="javascript:xuan_ze();">
                                            <asp:Repeater ID="data_guo" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("basic_label")%>" <%#Eval("basic_label").ToString() == guo ? " selected" : ""%>>
                                                        <%#Eval("basic_label")%></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                        <input type="text" name="txt_state1" id="txt_state1" class="reg-ipt3" placeholder="省份"
                                            value="<%=area%>">
                                        <input type="text" name="txt_city1" id="txt_city1" class="reg-ipt3" placeholder="城市"
                                            value="<%=city%>">
                                        <select name="txt_state" id="txt_state" class="regest-sel" runat="Server" onchange="changeArea(this.value,document.all.txt_city)">
                                            <option value="">請選擇縣市...</option>
                                            <option value='基隆市'>基隆市</option>
                                            <option value='台北市'>台北市</option>
                                            <option value='新北市'>新北市</option>
                                            <option value='宜蘭縣'>宜蘭縣</option>
                                            <option value='新竹市'>新竹市</option>
                                            <option value='新竹縣'>新竹縣</option>
                                            <option value='桃園市'>桃園市</option>
                                            <option value='苗栗縣'>苗栗縣</option>
                                            <option value='台中市'>台中市</option>
                                            <option value='彰化縣'>彰化縣</option>
                                            <option value='南投縣'>南投縣</option>
                                            <option value='嘉義市'>嘉義市</option>
                                            <option value='嘉義縣'>嘉義縣</option>
                                            <option value='雲林縣'>雲林縣</option>
                                            <option value='台南市'>台南市</option>
                                            <option value='高雄市'>高雄市</option>
                                            <option value='屏東縣'>屏東縣</option>
                                            <option value='台東縣'>台東縣</option>
                                            <option value='花蓮縣'>花蓮縣</option>
                                            <option value='金門縣'>金門縣</option>
                                            <option value='連江縣'>連江縣</option>
                                            <option value='澎湖縣'>澎湖縣</option>
                                            <option value='南海諸島'>南海諸島</option>
                                        </select><select name="txt_city" id="txt_city" class="regest-sel" runat="Server"
                                            onchange="changeArea1(this.value,document.all.txt_zip)">
                                            <option value="">請選擇區域...</option>
                                        </select>
                                        <%if (!string.IsNullOrEmpty(area))
                                          {%><script>                                                 changeArea('<%=area%>', document.all.txt_city)</script><%}%>
                                        <%if (!string.IsNullOrEmpty(city))
                                          {%><script>                                                 changeAreaSel(document.all.txt_city, '<%=city%>')</script><%}%>
                                        <%if (!string.IsNullOrEmpty(area))
                                          {%><script>                                                 changeAreaSel(document.all.txt_state, '<%=area%>')</script><%}%>
                                    </div>
                                </dd>
                            </dl>
                            <dl>
                                <dt>郵遞區號<em>*</em></dt>
                                <dd>
                                    <div class="select">
                                        <input name="txt_zip" id="txt_zip" type="text" class="ipt-m1" value="<%=zip%>" placeholder="郵遞區號" />(若無請填0)
                                    </div>
                                </dd>
                            </dl>
                            <dl>
                                <dt>詳細地址<em>*</em></dt>
                                <dd>
                                    <input type="text" name="txt_address" id="txt_address" class="ipt-m5" value="<%=userModel.address%>" placeholder="詳細地址"/>
                                </dd>
                            </dl>
                        </div>
                    </div>
                    <div class="order-box-tit">
                        收件人資訊
                    </div>
                    <div class="order-box-form">
                        <div class="col-m5 float-l">
                            <dl>
                                <dt></dt>
                                <dd>
                                    <label>
                                        <input type="checkbox" id="tong" onclick="javascript:ck();">
                                        同購買人</label>
                                </dd>
                            </dl>
                            <dl>
                                <dt>收件人姓名<em>*</em></dt>
                                <dd>
                                    <input type="text" name="txtname" id="txtname" class="ipt-m1" />
                                    <label>
                                        <input type="radio" name="txtsex" id="txtsex_1" value="男" checked />
                                        先生</label>
                                    <label>
                                        <input type="radio" name="txtsex" id="txtsex_0" value="女" />
                                        小姐</label>
                                </dd>
                            </dl>
                            <dl>
                                <dt>手機號碼<em>*</em></dt>
                                <dd>
                                    <input type="text" name="txtmobile" id="txtmobile" class="ipt-m1" /></dd>
                            </dl>
                            <dl>
                                <dt>市內電話</dt><dd><input type="text" class="ipt-m2" name="txttel" />
                                    -
                                    <input type="text" class="ipt-m3" name="txttel" /></dd>
                            </dl>
                            <%--  <dl>
                                <dt>E-mail信箱<em>*</em></dt><dd><input type="text" name="txtemail" id="txtemail" class="ipt-m4" /><em>請填寫正確電子信箱，以便收到訂單資訊</em></dd>
                            </dl>--%>
                            <dl>
                                <dt>備註</dt><dd><textarea class="text-m1" name="txtcontent" id="txtcontent"></textarea></dd>
                            </dl>
                        </div>
                        <div class="col-m5 float-l">
                            <dl>
                                <dt>所在地<em>*</em></dt>
                                <dd>
                                    <div class="select">
                                        <select name="txtguo" id="txtguo" class="regest-sel" onchange="javascript:xuanze();">
                                            <asp:Repeater ID="dataguo" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("basic_label")%>">
                                                        <%#Eval("basic_label")%></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                        <input type="text" name="txtstate1" id="txtstate1" class="reg-ipt3" placeholder="省份">
                                        <input type="text" name="txtcity1" id="txtcity1" class="reg-ipt3" placeholder="城市">
                                        <select name="txtstate" id="txtstate" class="regest-sel" runat="Server" onchange="changeArea(this.value,document.all.txtcity)">
                                            <option value="">請選擇縣市...</option>
                                            <option value='基隆市'>基隆市</option>
                                            <option value='台北市'>台北市</option>
                                            <option value='新北市'>新北市</option>
                                            <option value='宜蘭縣'>宜蘭縣</option>
                                            <option value='新竹市'>新竹市</option>
                                            <option value='新竹縣'>新竹縣</option>
                                            <option value='桃園市'>桃園市</option>
                                            <option value='苗栗縣'>苗栗縣</option>
                                            <option value='台中市'>台中市</option>
                                            <option value='彰化縣'>彰化縣</option>
                                            <option value='南投縣'>南投縣</option>
                                            <option value='嘉義市'>嘉義市</option>
                                            <option value='嘉義縣'>嘉義縣</option>
                                            <option value='雲林縣'>雲林縣</option>
                                            <option value='台南市'>台南市</option>
                                            <option value='高雄市'>高雄市</option>
                                            <option value='屏東縣'>屏東縣</option>
                                            <option value='台東縣'>台東縣</option>
                                            <option value='花蓮縣'>花蓮縣</option>
                                            <option value='金門縣'>金門縣</option>
                                            <option value='連江縣'>連江縣</option>
                                            <option value='澎湖縣'>澎湖縣</option>
                                            <option value='南海諸島'>南海諸島</option>
                                        </select><select name="txtcity" id="txtcity" class="regest-sel" runat="Server" onchange="changeArea1(this.value,document.all.txtzip)">
                                            <option value="">請選擇區域...</option>
                                        </select>
                                    </div>
                                </dd>
                            </dl>
                            <dl>
                                <dt>郵遞區號<em>*</em></dt>
                                <dd>
                                    <div class="select">
                                        <input name="txtzip" id="txtzip" type="text" class="ipt-m1" placeholder="郵遞區號"/>(若無請填0)
                                    </div>
                                </dd>
                            </dl>
                            <dl>
                                <dt>詳細地址<em>*</em></dt>
                                <dd>
                                    <input type="text" name="txtaddress" id="txtaddress" class="ipt-m5" placeholder="詳細地址"/>
                                </dd>
                            </dl>
                            <%if (!string.IsNullOrEmpty(yudate))
                              { %>
                            <dl>
                                <dt>到貨日期<em>*</em></dt>
                                <dd>
                                    <%=yudate%>
                                </dd>
                            </dl>
                            <%} %>
                        </div>
                    </div>
                </div>
                <div class="order-boxw">
                    <div class="order-box-tit">
                        付款方式</div>
                    <div class="order-box-form order-fukuan">
                        <asp:Repeater ID="data_pay" runat="server">
                            <ItemTemplate>
                                <label id="la_<%#Eval("id")%>">
                                    <ul>
                                        <li class="col-n1">
                                            <input type="radio" id="pay_<%#Eval("id")%>" <%#Eval("id").ToString()=="1" ? " checked" : ""%>
                                                name="txt_pay" value="<%#Eval("id")%>" /><%#Eval("title")%></li>
                                        <li class="col-n5"></li>
                                        <li class="col-n3">
                                            <%#Eval("remark")%></li>
                                    </ul>
                                </label>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="order-boxw">
                    <div class="order-box-tit">
                        發票</div>
                    <div id="Tabs1">
                        <ul>
                            <%--<li><a href="#tabs-1" onclick="javascript:$('#txtinvoice').val('1')">電子發票</a></li>
                            <li><a href="#tabs-2" onclick="javascript:$('#txtinvoice').val('2')">發票捐贈</a></li>--%>
                            <li><a href="#tabs-3" onclick="javascript:$('#txtinvoice').val('3')">二聯式發票</a></li>
                            <li><a href="#tabs-4" onclick="javascript:$('#txtinvoice').val('4')">三聯式發票</a></li>
                        </ul>
                        <div id="tabs-1" style="display: none;">
                            <input type="hidden" name="txtinvoice" id="txtinvoice" value="3" />
                            <div class="order-box-form order-fapiao">
                                <label>
                                    <ul>
                                        <li class="col-n3">
                                            <input type="radio" name="txt_invoice1" value="手機條碼載具" checked />手機條碼載具</li>
                                    </ul>
                                </label>
                                <label>
                                    <ul>
                                        <li class="col-n3">
                                            <input type="radio" name="txt_invoice1" value="自然人憑證載具" />自然人憑證載具</li>
                                    </ul>
                                </label>
                            </div>
                        </div>
                        <div id="tabs-2" style="display: none;">
                            <div class="order-box-form order-fapiao">
                                <label>
                                    <ul>
                                        <li class="col-n3">
                                            <input type="radio" name="txt_invoice2" value="財團法人創世社會福利基金會" checked />財團法人創世社會福利基金會</li>
                                    </ul>
                                </label>
                                <label>
                                    <ul>
                                        <li class="col-n3">
                                            <input type="radio" name="txt_invoice2" value="社團法人臺灣一起夢想公益協會" />社團法人臺灣一起夢想公益協會</li>
                                    </ul>
                                </label>
                                <label>
                                    <ul>
                                        <li class="col-n3">
                                            <input type="radio" name="txt_invoice2" value="其他社福團體" />其他社福團體</li>
                                    </ul>
                                </label>
                            </div>
                        </div>
                        <div id="tabs-3">
                            <div class="order-box-form order-fapiao">
                                <label>
                                    <ul>
                                        <li class="col-n1">
                                            <input type="radio" name="txtfaaddress" value="" id="txttong" onclick="tb1()" />同訂購人地址</li>
                                        <li class="col-n3"><span id="fp_address">XXX 區 XXX 街 XXX 社區 XX 號</span></li>
                                    </ul>
                                </label>
                                <label>
                                    <ul>
                                        <li class="col-n1">
                                            <input type="radio" name="txtfaaddress" value="" id="txttong_2" onclick="tb1()" />重新填寫地址</li>
                                        <li class="col-n3">
                                            <div class="select float-l mr-5">
                                                <select name="txtfaaddress_guo" id="txtfaaddress_guo" class="regest-sel" onchange="javascript:xuan_ze_fp();">
                                                    <asp:Repeater ID="data_fp_guo" runat="server">
                                                        <ItemTemplate>
                                                            <option value="<%#Eval("basic_label")%>">
                                                                <%#Eval("basic_label")%></option>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </select>
                                                </div>
                                                <input type="text" name="txtfaaddress_state1" id="txtfaaddress_state1" class="reg-ipt3"
                                                    placeholder="省份">
                                                <input type="text" name="txtfaaddress_city1" id="txtfaaddress_city1" class="reg-ipt3"
                                                    placeholder="城市">
                                                    <div class="select float-l mr-5">
                                                <select name="txtfaaddress_state" id="txtfaaddress_state" class="regest-sel" runat="Server"
                                                    onchange="changeArea(this.value,document.all.txtfaaddress_city)">
                                                    <option value="">請選擇縣市...</option>
                                                    <option value='基隆市'>基隆市</option>
                                                    <option value='台北市'>台北市</option>
                                                    <option value='新北市'>新北市</option>
                                                    <option value='宜蘭縣'>宜蘭縣</option>
                                                    <option value='新竹市'>新竹市</option>
                                                    <option value='新竹縣'>新竹縣</option>
                                                    <option value='桃園市'>桃園市</option>
                                                    <option value='苗栗縣'>苗栗縣</option>
                                                    <option value='台中市'>台中市</option>
                                                    <option value='彰化縣'>彰化縣</option>
                                                    <option value='南投縣'>南投縣</option>
                                                    <option value='嘉義市'>嘉義市</option>
                                                    <option value='嘉義縣'>嘉義縣</option>
                                                    <option value='雲林縣'>雲林縣</option>
                                                    <option value='台南市'>台南市</option>
                                                    <option value='高雄市'>高雄市</option>
                                                    <option value='屏東縣'>屏東縣</option>
                                                    <option value='台東縣'>台東縣</option>
                                                    <option value='花蓮縣'>花蓮縣</option>
                                                    <option value='金門縣'>金門縣</option>
                                                    <option value='連江縣'>連江縣</option>
                                                    <option value='澎湖縣'>澎湖縣</option>
                                                    <option value='南海諸島'>南海諸島</option>
                                                </select>
                                                </div>
                                                <div class="select float-l mr-5">
                                                <select name="txtfaaddress_city" id="txtfaaddress_city" class="regest-sel" runat="Server"
                                                    onchange="changeArea1(this.value,document.all.txtfaaddress_zip)">
                                                    <option value="">請選擇區域...</option>
                                                </select>
                                            </div>
                                            <div class="select float-l">
                                                <input name="txtfaaddress_zip" id="txtfaaddress_zip" type="text" class="ipt-f1" placeholder="郵遞區號"/>
                                            </div>
                                            <input type="text" name="txtfa_address" id="txtfa_address" class="ipt-f5 mt-5" placeholder="詳細地址"/>
                                        </li>
                                    </ul>
                                </label>
                            </div>
                        </div>
                        <div id="tabs-4">
                            <div class="order-box-form order-fapiao">
                                <label>
                                    <ul>
                                        <li class="col-n1">統一編號</li>
                                        <li class="col-n4">
                                            <input type="text" name="txt_invoice_4" id="txt_invoice_4_1" class="ipt-m1" placeholder="統一編號" />
                                        </li>
                                    </ul>
                                </label>
                                <label>
                                    <ul>
                                        <li class="col-n1">發票抬頭</li>
                                        <li class="col-n4">
                                            <input type="text" name="txt_invoice_4" id="txt_invoice_4_2" class="ipt-m1" placeholder="公司抬頭" />
                                        </li>
                                    </ul>
                                </label>
                                <label>
                                    <ul>
                                        <li class="col-n1">
                                            <input type="radio" name="txt_invoiceaddress" value="" id="txttong1" onclick="tb2()" />同訂購人地址</li>
                                        <li class="col-n3"><span id="fp_address4">XXX 區 XXX 街 XXX 社區 XX 號</span></li>
                                    </ul>
                                </label>
                                <label>
                                    <ul>
                                        <li class="col-n1">
                                            <input type="radio" name="txt_invoiceaddress" id="txttong_3" value="" onclick="tb2()" />重新填寫地址</li>
                                        <li class="col-n3">
                                            <div class="select float-l mr-5">
                                                <select name="txt_invoiceaddress_guo" id="txt_invoiceaddress_guo" class="regest-sel"
                                                    onchange="javascript:xuan_ze_invo();">
                                                    <asp:Repeater ID="data_invo_guo" runat="server">
                                                        <ItemTemplate>
                                                            <option value="<%#Eval("basic_label")%>">
                                                                <%#Eval("basic_label")%></option>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </select>
                                                </div>
                                                <input type="text" name="txt_invoiceaddress_state1" id="txt_invoiceaddress_state1"
                                                    class="reg-ipt3" placeholder="省份">
                                                <input type="text" name="txt_invoiceaddress_city1" id="txt_invoiceaddress_city1"
                                                    class="reg-ipt3" placeholder="城市">
                                                    <div class="select float-l mr-5">
                                                <select name="txt_invoiceaddress_state" id="txt_invoiceaddress_state" class="regest-sel"
                                                    runat="Server" onchange="changeArea(this.value,document.all.txt_invoiceaddress_city)">
                                                    <option value="">請選擇縣市...</option>
                                                    <option value='基隆市'>基隆市</option>
                                                    <option value='台北市'>台北市</option>
                                                    <option value='新北市'>新北市</option>
                                                    <option value='宜蘭縣'>宜蘭縣</option>
                                                    <option value='新竹市'>新竹市</option>
                                                    <option value='新竹縣'>新竹縣</option>
                                                    <option value='桃園市'>桃園市</option>
                                                    <option value='苗栗縣'>苗栗縣</option>
                                                    <option value='台中市'>台中市</option>
                                                    <option value='彰化縣'>彰化縣</option>
                                                    <option value='南投縣'>南投縣</option>
                                                    <option value='嘉義市'>嘉義市</option>
                                                    <option value='嘉義縣'>嘉義縣</option>
                                                    <option value='雲林縣'>雲林縣</option>
                                                    <option value='台南市'>台南市</option>
                                                    <option value='高雄市'>高雄市</option>
                                                    <option value='屏東縣'>屏東縣</option>
                                                    <option value='台東縣'>台東縣</option>
                                                    <option value='花蓮縣'>花蓮縣</option>
                                                    <option value='金門縣'>金門縣</option>
                                                    <option value='連江縣'>連江縣</option>
                                                    <option value='澎湖縣'>澎湖縣</option>
                                                    <option value='南海諸島'>南海諸島</option>
                                                </select>
                                                </div>
                                                <div class="select float-l mr-5">
                                                <select name="txt_invoiceaddress_city" id="txt_invoiceaddress_city" class="regest-sel"
                                                    runat="Server" onchange="changeArea1(this.value,document.all.txt_invoiceaddress_zip)">
                                                    <option value="">請選擇區域...</option>
                                                </select>
                                            </div>
                                            <div class="select">
                                                <input name="txt_invoiceaddress_zip" id="txt_invoiceaddress_zip" type="text" class="ipt-f1" placeholder="郵遞區號"/>
                                            </div>
                                            <input type="text" name="txt_invoice_address" id="txt_invoice_address" class="ipt-f5 mt-5" placeholder="詳細地址"/>
                                        </li>
                                    </ul>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=" cart-bg">
            <div class="cart-box">
                <asp:Repeater ID="data_cart" runat="server">
                    <ItemTemplate>
                        <div class="cart-lrbox">
                            <dl>
                                <dd class="col_1">
                                    <div class="c-pic float-l">
                                        <a href="<%#getpoint(Eval("by").ToString(),"show")%>.aspx?id=<%#Eval("id")%>">
                                            <img src="<%#Eval("img_url")%>" width="800" height="800" alt="<%#Eval("title")%>" /></a></div>
                                </dd>
                                <dd class="col_21">
                                    <div class="pt-box  float-l">
                                        <div class="cart-pt">
                                            <a href="<%#getpoint(Eval("by").ToString(),"show")%>.aspx?id=<%#Eval("id")%>"><strong>
                                                <%#Eval("sub_title")%></strong></a></div>
                                        <div class="cart-pt">
                                            <a href="<%#getpoint(Eval("by").ToString(),"show")%>.aspx?id=<%#Eval("id")%>">
                                                <%#Eval("title")%></a></div>
                                        <%#Eval("sales_name") == "no" ? "此商品不配送至海外" : ""%>
                                    </div>
                                </dd>
                                <dd class="col_31">
                                    <div class="cart-select">
                                        <span class="wap-show">規格：</span><%#Eval("goods_color")%>
                                    </div>
                                </dd>
                                <dd class="col_41">
                                    <div class="price-box" <%#getpoint(Eval("by").ToString(),1)%>>
                                        <span class="price">NT$<%#Eval("user_price", "{0:0.}")%></span><br>
                                        <span class="yprice">NT$<%#Eval("price", "{0:0.}")%></span>
                                    </div>
                                    <div class="price-box" <%#getpoint(Eval("by").ToString(),2)%>>
                                        <span class="price">
                                            <%#Eval("point")%>點</span>
                                    </div>
                                </dd>
                                <dd class="col_51">
                                    <div class="number-box">
                                        <span class="wap-show">數量：</span><%#Eval("quantity")%>
                                    </div>
                                </dd>
                                <dd class="col_6">
                                    <div class="price-box1" <%#getpoint(Eval("by").ToString(),1)%>>
                                        <span class="wap-show">小計：</span><span class="price">NT$<%#Tea.Common.Utils.StrToInt(Eval("quantity").ToString(), 0) * Tea.Common.Utils.StrToInt(Eval("user_price", "{0:0.}").ToString(), 0)%></span></div>
                                    <div class="price-box1" <%#getpoint(Eval("by").ToString(),2)%>>
                                        <span class="wap-show" <%#getpoint(Eval("by").ToString(),2)%>>小計：</span><span class="price"><%#Tea.Common.Utils.StrToInt(Eval("quantity").ToString(), 0) * Tea.Common.Utils.StrToInt(Eval("point", "{0:0.}").ToString(), 0)%></span>點</div>
                                </dd>
                            </dl>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="data_gift" runat="server">
                    <ItemTemplate>
                        <div class="cart-lrbox">
                            <dl>
                                <dd class="col_1">
                                    <div class="c-pic float-l">
                                        <img src="<%#Eval("img_url")%>" width="800" height="800" alt="<%#Eval("title")%>" /></div>
                                </dd>
                                <dd class="col_21">
                                    <div class="pt-box  float-l">
                                        <div class="cart-pt">
                                            <strong>
                                                <%#Eval("article_list")%></strong>
                                        </div>
                                        <div class="cart-pt">
                                            <%#Eval("title")%></div>
                                    </div>
                                </dd>
                                <dd class="col_31">
                                    <div class="cart-select">
                                        &nbsp;</div>
                                </dd>
                                <dd class="col_41">&nbsp;
                                    </dd>
                                <dd class="col_51">
                                  <div class="number-box" id="giftnum">
                                        <%=giftnum%></div>
                                </dd>
                                <dd class="col_6">
                                    <div class="price-box1">
                                        &nbsp;</div>
                                </dd>
                            </dl>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="cart-tjbox">
                    <div class="cart-tjboxl">
                        <h1>
                            <strong>符合活動</strong></h1>
                        <p>
                            <label>
                                <a>
                                    <%=cartModel.sales_str%></a></label></p>
                    </div>
                    <div class="cart-tjboxr">
                        <dl>
                            <dd>
                                合計</dd>
                            <dd class="priceh">
                                NT$<span id="real_amount"><%=cartModel.real_amount.ToString("0.")%></span></dd>
                        </dl>
                        <dl>
                            <dd>
                                紅利點數兌商品</dd>
                            <dd class="priceh">
                                <span id="duipoint">
                                    <%=cartModel.total_point.ToString("0.")%></span>點</dd>
                        </dl>
                        <dl>
                            <dd>折扣</dd>
                            <dd class="price"> -<span id="total_zhe"><%=cartModel.total_moneyback.ToString("0.")%></span></dd>
                        </dl>
                        <dl>
                            <dd>
                                運費（<span id="ysfs">宅配</span>）</dd>
                            <dd class="priceh">
                                <input type="hidden" id="yun" name="yun" />
                                NT$<span id="sy_yuan">0</span></dd>
                        </dl>
                    </div>
                </div>
                <div class="cart-tjbox">
                    <div class="cart-tjboxl">
                        <p>
                            <%if (cartModel.real_amount > uconfig.pint_mane && uconfig.pint_money > 0)
                              { %>
                            <label>
                                <input type="checkbox" id="cbhonglv" name="cb_point" value="1" onclick="javascript:get_hongli();" />我要折抵<strong><input
                                    name="txt_point" id="txt_point" value="<%=point%>" onblur="javascript:get_hongli();" />點</strong>紅利點（購物滿$<%=uconfig.pint_mane%>可使用紅利折抵，折抵上限為金額<%=uconfig.pint_yong%>%）<input
                                        type="hidden" id="ky_hongli" value="<%=Tea.Common.Utils.StrToInt((point/uconfig.pint_money).ToString(),0)%>" /></label><input
                                            type="hidden" id="qbpoint" value="<%=point%>" />
                            <%} %>
                            <label>
                                <input type="checkbox" name="cbquan" id="cbquan" value="1" />
                                使用優惠券<span class="col-n3"><input type="text" name="txt_quan" id="txt_zhe" onblur="javascript:get_code();"
                                    class="ipt-f1" placeholder="" /></span>
                            </label>
                        </p>
                    </div>
                    <div class="cart-tjboxr">
                        <dl>
                            <dd>
                                紅利折扣</dd>
                            <dd class="price">
                                -<span id="sy_honglv">0</span></dd>
                        </dl>
                        <dl>
                            <dd id="sy_quan_name">
                                優惠券</dd>
                            <dd class="price">
                                -<span id="sy_quan">0</span></dd>
                        </dl>
                    </div>
                </div>
                <div class="cart-tjbox">
                    <div class="cart-tjboxr">
                        <dl>
                            <dd>
                                總金額（含運費）</dd>
                            <dd class="priceh">
                                NT$<span id="zongji"><%=(cartModel.real_amount + yun - cartModel.total_moneyback).ToString("0.")%></span></dd>
                        </dl>
                        <dl>
                            <dd>
                                本次消費共折抵紅利</dd>
                            <dd class="priceh">
                                <span id="dikou_honglv">
                                    <%=cartModel.total_point%></span>點</dd>
                        </dl>
                        <%if (uconfig.money_pint > 0)
                          { %>
                        <dl>
                            <dd>
                                本次消費共得紅利</dd>
                            <dd class="price">
                                <span id="hdpoing">
                                    <%=((cartModel.real_amount - cartModel.total_moneyback)/uconfig.money_pint).ToString("0.")%></span>點</dd>
                        </dl>
                        <%} %>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <%if (cartModel.brand_id == 2)
          { %>
        <div class="order-btn">
            <a href="cart.aspx" class="cart-btn">上一步</a>
            <input type="submit" value="結帳" class="Collection-btn" onclick="javascript:return confirm('此訂單商品會依預購商品出貨時間一起出貨!')" /></div>
        <%}
          else
          { %>
        <div class="order-btn">
            <a href="cart.aspx" class="cart-btn">上一步</a>
            <input type="submit" value="結帳" class="Collection-btn" /></div>
        <%} %>
    </div>
    </form>
    <public:foot ID="foot" runat="server" />
    <script type="text/javascript" src="/js/jquery.spinner.js"></script>
    <script type="text/javascript">
        $('.spinnerExample').spinner({});
        $(function () {
            $("#Tabs1").tabs();
        });
    </script>
</body>
</html>
