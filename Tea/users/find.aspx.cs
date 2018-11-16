using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class find : Tea.Web.UI.ShopPage
{
    protected string act, user;
    protected void Page_Load(object sender, EventArgs e)
    {


        Tea.BLL.users bll = new Tea.BLL.users();
        act = Request["act"];
        if (act == "act_find")
        {


            user = TWRequest.GetFormString("txt_email");
            string remember = TWRequest.GetFormString("txt_code");
            if (Session[TWKeys.SESSION_CODE] == null)
            {
                Response.Write(ljd.function.LocalHint("系統找不到驗證碼", "find.aspx"));
                return;
            }
            if (remember.ToLower() != Session[TWKeys.SESSION_CODE].ToString().ToLower())
            {
                Response.Write(ljd.function.LocalHint("驗證碼輸入不正確", "find.aspx"));
                return;

            }



            Tea.Model.users model = bll.GetModel(user);
            if (model == null)
            { 
                model= bll.GetEModel(user);
            }
            if (model == null)
            {
                Response.Write(ljd.function.LocalHint("對不起，您輸入的用戶名不存在！", "find.aspx"));
                return;
            }
            if (model.user_hei > 0)
            {
                Response.Write(ljd.function.LocalHint("您非一般註冊用戶，無法使用取回密碼功能！", "find.aspx"));
                return;
            }
            if (string.IsNullOrEmpty(model.email))
            {
                Response.Write(ljd.function.LocalHint("您尚未設定郵箱地址，無法使用取回密碼功能！", "find.aspx"));
                return;
            }

            //生成隨機碼
            string strcode = Utils.GetCheckCode(8);
            try
            {

                string mailTitle = "找回密碼通知信", mailContent = "";
                string url = weburl + "mail/find.aspx?id=" + model.id, ss = "";
                mailContent = ljd.function.GetPage(url, out ss);
                //發送郵件
                TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport, config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, model.email, mailTitle, mailContent);

                //model.password = DESEncrypt.Encrypt(strcode, model.salt);
                //new Tea.BLL.users().Update(model);
            }
            catch (Exception eee)
            {
                Response.Write(ljd.function.LocalHint("發送失敗!", "find.aspx"));
                Response.End();
            }
            Response.Write(ljd.function.LocalHint("已發送密碼至您的信箱!", "login.aspx"));
            Response.End();

        }
    }
}