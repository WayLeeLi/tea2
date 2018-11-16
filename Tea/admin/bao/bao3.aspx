<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bao3.aspx.cs" Inherits="Tea.Web.admin.order.order_list" %>
<%@ Import namespace="Tea.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>報表管理</title>
<link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" charset="utf-8" src="../js/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/common.js"></script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--導航欄-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一頁</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首頁</span></a>
  <i class="arrow"></i>
  <span>報表管理</span>
  <i class="arrow"></i>
  <span>購買區域報表</span>
</div>
<!--/導航欄-->
<!--工具欄-->
<div id="floatHead" class="toolbar-wrap">
    <div class="toolbar">
        <div class="box-wrap">
            <a class="menu-btn"></a>
            <div class="l-list">
                <ul class="icon-list">
                    <li style="display: none;"><a class="all" href="javascript:;" onclick="checkAll(this);">
                        <i></i><span>全選</span></a></li>
                    <li style="display: none;">
                        <asp:LinkButton ID="export" runat="server" CssClass="export" OnClick="btnExport_Click"><i></i><span>匯出</span></asp:LinkButton></li>
                </ul>
                <div class="menu-list">
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlYear" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlMonth" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="r-list">
                <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查詢</asp:LinkButton>
            </div>
        </div>
    </div>
</div>
<!--/工具欄-->

<!--列表-->


<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th align="left">地區</th>
    <th align="left">消費金額</th>
    <th align="left">消費次數</th>
    <th align="left">佔比</th>
  </tr>
     <tr>
    <td>中區</td>
    <td><%=getcartpricequ("zhong")%></td>
    <td><%=getcartnumqu("zhong")%></td>
    <td><%=getbiqu("zhong")%></td>
  </tr>
  <%foreach(object ob in _list_zhong){ %>

 <tr>
    <td><%=ob.ToString()%></td>
    <td><%=getcartprice(ob.ToString())%></td>
    <td><%=getcartnum(ob.ToString())%></td>
    <td><%=getbiqu(ob.ToString(), "zhong")%></td>
  </tr>
  <%} %>
     <tr>
    <td>北區</td>
    <td><%=getcartpricequ("bei")%></td>
    <td><%=getcartnumqu("bei")%></td>
    <td><%=getbiqu("bei")%></td>
  </tr>
    <%foreach (object ob in _list_bei)
      { %>

 <tr>
    <td><%=ob.ToString()%></td>
    <td><%=getcartprice(ob.ToString())%></td>
    <td><%=getcartnum(ob.ToString())%></td>
    <td><%=getbiqu(ob.ToString(),"bei")%></td>
  </tr>
  <%} %>
     <tr>
    <td>東區</td>
    <td><%=getcartpricequ("dong")%></td>
    <td><%=getcartnumqu("dong")%></td>
    <td><%=getbiqu("dong")%></td>
  </tr>
    <%foreach (object ob in _list_dong)
      { %>
 
 <tr>
    <td><%=ob.ToString()%></td>
    <td><%=getcartprice(ob.ToString())%></td>
    <td><%=getcartnum(ob.ToString())%></td>
    <td><%=getbiqu(ob.ToString(),"dong")%></td>
  </tr>
  <%} %>   <tr>
    <td>南區</td>
    <td><%=getcartpricequ("nan")%></td>
    <td><%=getcartnumqu("nan")%></td>
    <td><%=getbiqu("nan")%></td>
  </tr>
    <%foreach (object ob in _list_nan)
      { %>
 
 <tr>
    <td><%=ob.ToString()%></td>
    <td><%=getcartprice(ob.ToString())%></td>
    <td><%=getcartnum(ob.ToString())%></td>
    <td><%=getbiqu(ob.ToString(),"nan")%></td>
  </tr>
  <%} %>
     <tr>
    <td>外島</td>
    <td><%=getcartpricequ("wai")%></td>
    <td><%=getcartnumqu("wai")%></td>
    <td><%=getbiqu("wai")%></td>
  </tr>
    <%foreach (object ob in _list_wai)
      { %>
 
 <tr>
    <td><%=ob.ToString()%></td>
    <td><%=getcartprice(ob.ToString())%></td>
    <td><%=getcartnum(ob.ToString())%></td>
    <td><%=getbiqu(ob.ToString(),"wai")%></td>
  </tr>
  <%} %>
<asp:Repeater ID="rptList" runat="server">
<ItemTemplate>
  <tr>
    <td><%#Eval("basic_label").ToString()%></td>
    <td><%#getcartprice(Eval("basic_label").ToString())%></td>
    <td><%#getcartnum(Eval("basic_label").ToString())%></td>
    <td><%#getbi(Eval("basic_label").ToString())%></td>
  </tr>
</ItemTemplate>
</asp:Repeater>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暫無記錄</td></tr>" : ""%>
</table>
<!--/列表-->
<!--內容底部-->
<div class="line20"></div>
 
<!--/內容底部-->
</form>
</body>
</html>
