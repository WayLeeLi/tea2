using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class order : Tea.Web.UI.UserPage
{
    protected int totalCount;
    protected int page;
    protected int pageSize = 20;
    protected string _sql = "1=1", _orderby = "add_time desc,id desc", begin,end;
    protected int state;
    protected int day;
    protected int del, show = 0;
    Tea.BLL.orders bll = new Tea.BLL.orders();
    protected void Page_Load(object sender, EventArgs e)
    {
        _sql = "user_id='" + userModel.id + "' and status!=4";
        end = TWRequest.GetQueryString("end");
        begin = TWRequest.GetQueryString("begin");
        this.page = TWRequest.GetQueryInt("page", 1);
        this.state = TWRequest.GetQueryInt("state", 0);
        this.day = TWRequest.GetQueryInt("day", 0);
        del = TWRequest.GetQueryInt("del");
        if (del > 0)
        {
            try
            {
                Tea.Model.orders model = bll.GetModel(del);
                if (model.user_id == userModel.id)
                {
                    if (model.status == 1)
                    {
                        model.status = 4;
                        bll.Update(model);
                        Response.Write(ljd.function.LocalHint("訂單取消成功!", "order.aspx"));
                    }
                    else
                    {
                        Response.Write(ljd.function.LocalHint("只是未確認的訂單才能取消!", "order.aspx"));

                    }

                }
            }
            catch (Exception eee) { }

        }


        if (state != 0)
        {
            if (state == 1)
            {
                _sql = _sql + " and payment_status=2";
            }
            if (state == 2)
            {
                _sql = _sql + " and express_status=2";
            }
            if (state == 3)
            {
                _sql = _sql + " and payment_status!=2";
            }
        }
        if (!string.IsNullOrEmpty(begin))
        {
            _sql = _sql + " and (add_time between '" + begin + "' and '" + end + "')";
        }
        if (day == 1)
        {
            _sql = "user_id='" + userModel.id + "' and status!=4 and datediff(year,add_time,getdate())=0";
        }


        Tea.Web.UI.ShopPage bll_view = new Tea.Web.UI.ShopPage();

        data_list.DataSource = bll_view.GetViewList("shop_orders", "", this.pageSize, this.page, _sql, _orderby, out this.totalCount);
        data_list.DataBind();
        show = data_list.Items.Count;

        string pageUrl = Utils.CombUrlTxt("order.aspx", "state={0}&day={1}&begin={2}&end={3}&page={4}", state.ToString(),day.ToString(),begin,end,"__id__");
        PageContent.InnerHtml = Utils.OutPageListWeb(this.pageSize, this.page, this.totalCount, pageUrl, 8);

    }
    #region 返回訂單狀態=============================
    protected string GetOrderStatus(int _id)
    {
        string _title = string.Empty;
        Tea.Model.orders model = new Tea.BLL.orders().GetModel(_id);
        switch (model.status)
        {
            case 1: //如果是線下支付，支付狀態為0，如果是線上支付，支付成功後會自動改變訂單狀態為已確認
                if (model.payment_status > 0)
                {
                    _title = "前往付款";
                }
                else
                {
                    _title = "前往付款";
                }
                break;
            case 2: //如果訂單為已確認狀態，則進入發貨狀態
                if (model.express_status > 1)
                {
                    _title = "貨已寄出";
                }
                else
                {
                    _title = "待出貨";
                }
                break;
            case 3:
                _title = "交易完成";
                break;
            case 4:
                _title = "交易取消";
                break;
            case 5:
                _title = "退貨完成";
                break;
        }

        return _title;
    }
    #endregion
}