using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class goods : Tea.Web.UI.UserPage
{
    protected int totalCount;
    protected int page;
    protected int pageSize = 9;
    protected string _sql = "1=1", _orderby = "id desc", key;
    protected int id;
    protected int del,show=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = TWRequest.GetQueryInt("id");
        del = TWRequest.GetQueryInt("del", 0);
        page = TWRequest.GetQueryInt("page", 1);
        if (id > 0)
        {
            Tea.BLL.goods_trace bll_trace = new Tea.BLL.goods_trace();
            Tea.Model.goods_trace model_trace = new Tea.Model.goods_trace();
            DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select * from shop_goods_trace where user_name='" + userModel.user_name + "' and goods_id="+id+"");
            if (ds.Tables[0].Rows.Count == 0)
            {
                Tea.Model.article model = new Tea.BLL.article().GetModel(id);
                model_trace.user_name = userModel.user_name;
                model_trace.add_time = System.DateTime.Now;
                model_trace.goods_id = id;
                model_trace.goods_color = model.title;
                bll_trace.Add(model_trace);
            }
            Response.Redirect("goods.aspx");
        }
        if (del != 0)
        {
            Tea.Model.goods_trace model = new Tea.BLL.goods_trace().GetModel(del);
            if (model.user_name == userModel.user_name)
            {
                new Tea.BLL.goods_trace().Delete(del);
            }
            Response.Redirect("goods.aspx");
        }
        _sql = "username='" + userModel.user_name + "' ";

        Tea.Web.UI.ShopPage bll_view = new Tea.Web.UI.ShopPage();

        data_list.DataSource = bll_view.GetViewList("view_goods_trace", "", this.pageSize, this.page, _sql, _orderby, out this.totalCount);
        data_list.DataBind();
        show = data_list.Items.Count;
        string pageUrl = Utils.CombUrlTxt("goods.aspx", "page={0}", "__id__");
        PageContent.InnerHtml = Utils.OutPageListWeb(10, this.page, this.totalCount, pageUrl, 8);
    }

}