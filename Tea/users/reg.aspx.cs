using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class reg : Tea.Web.UI.ShopPage
{
    protected string act;
    protected void Page_Load(object sender, EventArgs e)
    {
        act = Request["act"];
        Tea.BLL.users bll = new Tea.BLL.users();

        data_guo.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from shop_basic where basic_where='city' order by basic_sort");
        data_guo.DataBind();


        if (act == "act_reg")
        {
            string remember = TWRequest.GetFormString("txt_code");
            if (Session[TWKeys.SESSION_CODE] == null)
            {
                Response.Write(ljd.function.LocalHint("系統找不到驗證碼", "reg.aspx"));
                return;
            }
            if (remember.ToLower() != Session[TWKeys.SESSION_CODE].ToString().ToLower())
            {
                Response.Write(ljd.function.LocalHint("驗證碼輸入不正確", "reg.aspx"));
                return;
            }

            string username = Utils.ToHtml(TWRequest.GetFormString("email").Trim());
            string password = TWRequest.GetFormString("loginPwd").Trim();
            string email = Utils.ToHtml(TWRequest.GetFormString("email").Trim());
            string mobile = Utils.ToHtml(TWRequest.GetFormString("cellPhone").Trim());
            string address = Utils.ToHtml(TWRequest.GetFormString("address").Trim());
            string area = Utils.ToHtml(TWRequest.GetFormString("txt_state").Trim());
            string city = Utils.ToHtml(TWRequest.GetFormString("txt_city").Trim());
            string area1 = Utils.ToHtml(TWRequest.GetFormString("txt_state1").Trim());
            string city1 = Utils.ToHtml(TWRequest.GetFormString("txt_city1").Trim());
            string guo = Utils.ToHtml(TWRequest.GetFormString("txt_guo").Trim());
            string sex = TWRequest.GetFormString("rblSex").Trim();
            string birthday = TWRequest.GetFormString("birthdayY").Trim() + "-" + TWRequest.GetFormString("birthdayM").Trim() + "-" + TWRequest.GetFormString("birthdayD").Trim();
            string nickname = TWRequest.GetFormString("userName").Trim();
            int rss = TWRequest.GetFormInt("rss", 0);
            string userip = TWRequest.GetIP();


            //檢查用戶輸入資料是否為空
            if (username == "" || password == "")
            {
                Response.Write(ljd.function.LocalHint("用戶名和密碼不能為空！", ""));
                return;
            }


            //檢查用戶名

            Tea.Model.users model = new Tea.Model.users();

            if (new Tea.BLL.users().ExistsEmail(email))
            {
                Response.Write(ljd.function.LocalHint("此帳號信箱已存在於此網站，請以新mail註冊", ""));
                Response.End();
                return;
            }
            if (bll.Exists(username))
            {
                Response.Write(ljd.function.LocalHint("對不起，該用戶名已經存在！", ""));
                Response.End();
                return;
            }




            //儲存註冊資料
            model.group_id = 1;
            model.user_name = username;
            model.salt = Utils.GetCheckCode(6);
            model.status = 1;
            model.password = DESEncrypt.Encrypt(password, model.salt);
            model.email = email;
            model.mobile = mobile;
            if (guo == "台灣")
            {
                model.area = guo + "," + area + "," + city;
            }
            else
            {
                model.area = guo + "," + area1 + "," + city1; 
            }
            model.qq = TWRequest.GetFormString("txt_zip");
            model.sex = sex;
            model.address = address;
 
            try
            {
                model.birthday = System.DateTime.Parse(birthday);
            }
            catch (Exception eee)
            {
                Response.Write(ljd.function.LocalHint("請輸入正確的日期！", ""));
                return;
            }
            if (TWRequest.GetFormInt("birthdayY") < 1900 || TWRequest.GetFormInt("birthdayY") > System.DateTime.Now.Year)
            {
                Response.Write(ljd.function.LocalHint("請輸入正確的日期！", ""));
                Response.End();
                return;
            }
            model.nick_name = nickname;
            model.reg_ip = userip;
            model.reg_time = DateTime.Now;
            model.exp = rss;
            model.user_hei =0;
 
            int newId = bll.Add(model);
            if (newId < 1)
            {
                Response.Write(ljd.function.LocalHint("系統故障，請聯絡網站管理員！", ""));
                return;
            }

            model = bll.GetModel(newId);

            try
            {

                string mailTitle = "驗證郵箱通知信", mailContent = "";
                string url = weburl + "mail/reg.aspx?id=" + newId, ss = "";
                mailContent = ljd.function.GetPage(url, out ss);
                //發送郵件
                TWMail.sendMail(config.emailsmtp, config.emailssl,config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, model.email, mailTitle, mailContent);

            }
            catch (Exception eee) { }

            if (model != null)
            {


                Session[TWKeys.SESSION_USER_INFO] = model;
                Session.Timeout = 45;

                //防止Session提前過期
                Utils.WriteCookie(TWKeys.COOKIE_USER_NAME_REMEMBER, "Tea", model.user_name);
                Utils.WriteCookie(TWKeys.COOKIE_USER_PWD_REMEMBER, "Tea", model.password);

                //寫入登入日誌
                new Tea.BLL.user_login_log().Add(model.id, model.user_name, "會員登入");


                Response.Write(ljd.function.LocalHint("已發送帳號啟用信至您的電子信箱，請至信箱確認並啟用。", "regno.aspx"));
                Response.End();
            }

        }
    }
}