using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tea.Common;
public partial class users_editpwd : Tea.Web.UI.ShopPage
{
    protected int id;
    protected string pwd,act;
    protected Tea.Model.users model = null;
    Tea.BLL.users bll = new Tea.BLL.users();
    protected void Page_Load(object sender, EventArgs e)
    {
        pwd = TWRequest.GetQueryString("pwd");
        id = TWRequest.GetQueryInt("id");
        act = TWRequest.GetFormString("act");
        if (id > 0)
        {
            model = bll.GetModel(id);
            if (model.password != pwd)
            {
                Response.Write(ljd.function.LocalHint("該鏈接已經失效", "login.aspx"));
                Response.End();
            }
        }
        if (act == "act_edit")
        {
            model = bll.GetModel(id);
            //檢查輸入的舊密碼
            string oldpassword = TWRequest.GetFormString("txt_pwd");
            string password = TWRequest.GetFormString("txt_pwd1");
            if (string.IsNullOrEmpty(oldpassword))
            {
                Response.Write(ljd.function.LocalHint("請輸入您的密碼！", ""));
                return;
            }
            //檢查輸入的新密碼
            if (string.IsNullOrEmpty(password))
            {
                Response.Write(ljd.function.LocalHint("請輸入確認密碼！", ""));
                return;
            }
            //舊密碼是否正確
            if (password != oldpassword)
            {
                Response.Write(ljd.function.LocalHint("對不起，您輸入的密碼不正確！", ""));
                return;
            }
            model.password = DESEncrypt.Encrypt(password, model.salt);
            bll.Update(model);
            Response.Write(ljd.function.LocalHint("重置密碼成功,請用新密碼登入","login.aspx"));
            Response.End();
        }
    }
}