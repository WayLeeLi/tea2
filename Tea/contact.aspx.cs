using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class contact : Tea.Web.UI.ShopPage
{
    protected string act;
    Tea.BLL.feedback bll = new Tea.BLL.feedback();
    protected void Page_Load(object sender, EventArgs e)
    {
        act = TWRequest.GetFormString("act");
        if (act == "add")
        {
            string remember = TWRequest.GetFormString("txt_code");
            if (Session[TWKeys.SESSION_CODE] == null)
            {
                Response.Write(ljd.function.LocalHint("系統找不到驗證碼", ""));
                return;
            }
            if (remember.ToLower() != Session[TWKeys.SESSION_CODE].ToString().ToLower())
            {
                Response.Write(ljd.function.LocalHint("驗證碼輸入不正確", ""));
                return;
            }

            Tea.Model.feedback model = new Tea.Model.feedback();
            model.title = TWRequest.GetFormString("txt_title");
            model.user_tel = TWRequest.GetFormString("txt_tel");
            model.user_name = TWRequest.GetFormString("txt_name");
            model.user_email = TWRequest.GetFormString("txt_email");
            model.content = TWRequest.GetFormString("txt_content");
            model.company = 1;
            bll.Add(model);
            Response.Write(ljd.function.LocalHint("成功送出", "contact.aspx"));
            return;
        }
    }
}
