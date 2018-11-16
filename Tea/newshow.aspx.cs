using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class newshow : Tea.Web.UI.ShopPage
{
    protected int id;
    protected Tea.Model.about model = null;
    Tea.BLL.about bll = new Tea.BLL.about();
    protected void Page_Load(object sender, EventArgs e)
    {
        id = TWRequest.GetQueryInt("id");
        if (id != 0)
        {
            model = bll.GetModel(id);
            title = model.seo_title;
            keyword = model.seo_keywords;
            describe = model.seo_description;
            bll.UpdateField(id, "click=click+1");
        }

        data_news.DataSource = new Tea.BLL.basic().GetList(0, "basic_where='news'", "basic_sort");
        data_news.DataBind();
    }
}
