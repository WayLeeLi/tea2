using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
public partial class error : Tea.Web.UI.ShopPage
{
    protected internal Tea.Model.siteconfig config = new Tea.BLL.siteconfig().loadConfig();
    protected string msg = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        msg = Utils.ToHtml(TWRequest.GetQueryString("msg"));
        if (string.IsNullOrEmpty(msg))
        {
            msg = "參數錯誤請返回!";
        }
    }
}