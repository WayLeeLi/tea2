<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sales_edit.aspx.cs" Inherits="Tea.Web.admin.goods.sales_edit" ValidateRequest="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>銷售活動管理</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../scripts/webuploader/webuploader.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script><script charset="utf-8" src="../../editor/lang/zh-TW.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/uploader.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
<script type="text/javascript">
    $(function () {

        //初始化表單驗證
        $("#form1").initValidform();

        var editor = KindEditor.create('.editor', {
            width: '100%',
            height: '350px',
            resizeType: 1,
            uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
            fileManagerJson: '../../tools/upload_ajax.ashx?action=ManagerFile',
            allowFileManager: true
        });
        //初始化上傳控件
        $(".upload-img").each(function () {
            $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
        });

        //切換活動類型
        var index = $("#ddlType")[0].selectedIndex;
        $("#saleParam dd").hide().eq(index).show();
        $("#ddlType").change(function () {
            var idx = $(this)[0].selectedIndex;
            $("#saleParam dd").hide().eq(idx).show();
        })
    })
    //新增商品组合
    //新增商品组合
    function showGroupDialog() {
        var goods_ids = "0";
        $("input[name='goods_id']").each(function (i) {
            goods_ids += ("," + $(this).val());
        });
        var groupDialog = top.dialog({
            id: 'groupDialogId',
            padding: 0,
            title: "新增滿件折扣商品",
            url: 'dialog/dialog_sales.aspx?channel_id=7&goods_ids=' + goods_ids,
            onclose: function () {
                var trHtml = this.returnValue;
                if (trHtml.length > 0) {
                    $("#group_list").append(trHtml);
                }
            }
        }).showModal();

    }
    //刪除组合
    function delGroup(obj) {
        $(obj).parent().parent().remove();
    }
 

    //新增參數1
    function addGoods1() {
        var zhe1_moeny = $("#txtMoney1").val();
        var zhe1_num = $("#txtNum1").val();
        if (zhe1_moeny < 1) { alert('請輸入件數'); return; }
        if (zhe1_num < 1) { alert('請輸入折扣'); return; }
        var tr = "<tr>";
        tr += ("<td><input name=\"item1_id\" value=\"0\" type=\"hidden\">   <input class=\"input middle\" name=\"zhe1_moeny\" onkeyup=\"value=value.replace(/[^\d.]/g,'')\" value=\"" + zhe1_moeny + "\"> </td>");
        tr += ("<td> <input class=\"input middle\" name=\"zhe1_num\" onkeyup=\"value=value.replace(/[^\d.]/g,'')\" value=\"" + zhe1_num + "\"> </td>");
        tr += ("<td><a href='javascript:;' onclick='delGoods1(this);'>删除</a>");
        tr += "</tr>";
        $("#txtMoney1").val("");
        $("#txtNum1").val("");
        $("#showAttachList1 tbody").append($(tr));
    }
    //刪除參數1
    function delGoods1(obj) {
        
        $(obj).parent().parent().remove();
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--導航欄-->
<div class="location">
  <a href="sales_list.aspx" class="back"><i></i><span>返回列表頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>訂單管理</span>
  <i class="arrow"></i>
  <span>滿件折扣</span>
</div>
<div class="line10"></div>
<!--/導航欄-->

<!--內容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">編輯資料</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>活動名稱</dt>
    <dd><asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*4-255" sucmsg=" "></asp:TextBox> <span class="Validform_checktip"></span></dd>
  </dl>
  <dl  style="display:none;">
    <dt>圖片標題</dt>
    <dd><asp:TextBox ID="txtHref" runat="server" CssClass="input normal upload-path" />
      <div class="upload-box upload-img"></div></dd>
  </dl>
  <dl  style="display:none;">
    <dt>副標題</dt>
    <dd>
      <asp:TextBox ID="txtSubTitle" runat="server" CssClass="input normal"  sucmsg=" "></asp:TextBox> <span class="Validform_checktip">用於選單顯示</span></dd>
  </dl>
  <dl style="display:none;">
    <dt>封面圖片</dt>
    <dd>
      <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
      <div class="upload-box upload-img"></div>
    </dd>
  </dl>
  <dl>
    <dt>選擇商品</dt>
    <dd>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table">
        <thead>
        <tr>
          <th width="300">標題</th>
          <th width="70">編號</th>
          <th width="70">市場價</th>
          <th>操作</th>
        </tr>
        </thead>
        <tbody  id="group_list">
        <asp:Repeater ID="rptGroup" runat="server">
        <ItemTemplate>
        <tr>
          <td>
              <input name="goods_group_id" type="hidden" value="<%#Eval("id")%>" />
              <input type="hidden" name="parent_id" value="<%#Eval("parent_id")%>" />
              <input type="hidden" name="goods_id" value="<%#Eval("id")%>" />
              <%#Eval("title")%>
          </td>
          <td><%#Eval("goods_no")%></td>
          <td><%#Eval("market_price","{0:0.}")%></td>
          <td><a href="javascript:;" onclick="delGroup(this);">删除</a></td>
        </tr>
        </ItemTemplate>
          </asp:Repeater>
        </tbody>
        <tfoot>
        </tfoot>
      </table>
      <input type="button" class="small-btn" value="選擇商品" onclick="showGroupDialog();" />
    </dd>
  </dl>

  <dl style="display:none;">
    <dt>活動類型</dt>
    <dd>
        <div class="rule-single-select">
            <asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem Value="1">滿件折扣</asp:ListItem>
            </asp:DropDownList>
        </div>
    </dd>
  </dl>
  <dl>
    <dt>折扣類型</dt>
    <dd>
       <div class="rule-multi-radio">
        <asp:RadioButtonList ID="company" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="1" Selected="True">百分比</asp:ListItem>
        <asp:ListItem Value="2">固定金額</asp:ListItem>
        </asp:RadioButtonList>
       </div>
    </dd>
  </dl>
  <dl id="saleParam">
    <dt>參數設定</dt>
    <dd>
    <table border="0" cellspacing="0" cellpadding="0" class="border-table" id="showAttachList1">
        <thead>
        <tr>
          <th width="150">滿多少件</th>
          <th width="150">多少元/多少%</th>
          <th>操作</th>
        </tr> </thead>
        <tbody>
          <asp:Repeater ID="data_zhe1" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <input name="item1_id" value="<%#Eval("id")%>" type="hidden">
                        <input class="input middle" name="zhe1_moeny" onkeydown="return checkNumber(event);"
                            value="<%#Eval("parent_id","{0:0.}")%>">
                    </td>
                    <td>
                        <input class="input middle" name="zhe1_num" onkeydown="return checkNumber(event);"
                            value="<%#Eval("goods_id","{0:0.}")%>">
                    </td>
                    <td>
                        <a href="javascript:;" onclick="delGoods1(this);">删除</a>
                    </td>
                </tr>
            </ItemTemplate>
          </asp:Repeater>
         </tbody>
        <tfoot>
        </tfoot>
      </table>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table" style="margin-top:8px;">
        <tr>
          <td width="150">
            <asp:TextBox ID="txtMoney1" runat="server" CssClass="input middle" onkeydown="return checkNumber(event);">0</asp:TextBox>
          </td>
          <td width="150">
            <asp:TextBox ID="txtNum1" runat="server" CssClass="input middle" onkeydown="return checkNumber(event);">0</asp:TextBox>
          </td>
          <td><a href="javascript:;" onclick="addGoods1();">增加</a></td>
        </tr>
      </table>
    </dd>
  </dl>
  <dl>
  <dt>開始時間</dt>
    <dd>
      <div class="input-date">
        <asp:TextBox ID="txtStartTime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="請選擇正確的日期" sucmsg=" " />
        <i>日期</i>
      </div>
      <span class="Validform_checktip">不選擇默認當前發佈時間</span>
    </dd>
  </dl>
  <dl>
    <dt>結束時間</dt>
    <dd>
      <div class="input-date">
        <asp:TextBox ID="txtEndTime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="請選擇正確的日期" sucmsg=" " />
        <i>日期</i>
      </div>
      <span class="Validform_checktip"></span>
    </dd>
  </dl>
  <dl>
    <dt>是否啟用</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbStatus" runat="server" Checked="true" />
      </div>
      <span class="Validform_checktip">*不啟用則表示該活動結束</span>
    </dd>
  </dl>
  <dl style="display:none;">
    <dt>排序數字</dt>
    <dd>
      <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
      <span class="Validform_checktip">*數字，越大越向前</span>
    </dd>
  </dl>
  <dl style="display:none;">
    <dt>內容摘要</dt>
    <dd>
      <asp:TextBox ID="txtZhaiyao" runat="server" CssClass="input" TextMode="MultiLine" datatype="*0-255" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">不填寫則自動截取內容前255字元</span>
    </dd>
  </dl>
  <dl style="display:none;">
    <dt>內容描述</dt>
    <dd>
      <textarea id="txtContent" class="editor" style="visibility:hidden;" runat="server"></textarea>
    </dd>
  </dl>
</div>
<!--/內容-->


<!--工具欄-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="送出儲存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一頁" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具欄-->
</form>
</body>
</html>
