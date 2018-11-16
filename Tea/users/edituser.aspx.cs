using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class edituser : Tea.Web.UI.User_Page
{
    protected string guo, area, city, zip;
    protected string act, username, year, month, day;
    protected void Page_Load(object sender, EventArgs e)
    {

        act = Request["act"];

        username = userModel.user_name;
        try
        {
            guo = userModel.area.Split(',')[0].ToString();
            area = userModel.area.Split(',')[1].ToString();
            city = userModel.area.Split(',')[2].ToString();
            zip = userModel.qq;
        }
        catch (Exception eee) { }
        try
        {
            year = userModel.birthday.Value.Year.ToString();
            month = userModel.birthday.Value.Month.ToString();
            day = userModel.birthday.Value.Day.ToString();
        }
        catch (Exception eee) { }
        data_guo.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from shop_basic where basic_where='city' order by basic_sort");
        data_guo.DataBind();
        if (act == "act_edit")
        {
            //檢查用戶是否登入
            Tea.Model.users model = new Tea.Web.UI.ShopPage().GetUserInfo();
            if (model == null)
            {
                Response.Write(ljd.function.LocalHint("對不起，用戶尚未登入或已超時！", "login.aspx"));
                return;
            }
            int user_id = model.id;
            string oldpassword = TWRequest.GetFormString("txt_pwd");
            string password = TWRequest.GetFormString("txt_pwd1");
            if (!string.IsNullOrEmpty(oldpassword) && oldpassword != "ljd110!@#")
            {
                //檢查輸入的舊密碼
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
            }
            if (model.email.Length < 2 && !string.IsNullOrEmpty(TWRequest.GetFormString("txt_email").Trim()) && TWRequest.GetFormString("txt_email").Trim().Length > 5)
            {
                if (new Tea.BLL.users().ExistsEmail(TWRequest.GetFormString("txt_email").Trim()))
                {
                    Response.Write(ljd.function.LocalHint("此帳號信箱已存在於此網站，請換新mail", ""));
                    Response.End();
                }

                model.status = 1;
                try
                {

                    string mailTitle = "驗證郵箱通知信", mailContent = "";
                    string url = weburl + "mail/reg.aspx?id=" + model.id, ss = "";
                    mailContent = ljd.function.GetPage(url, out ss);
                    //發送郵件
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport, config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, model.email, mailTitle, mailContent);

                }
                catch (Exception eee) { }
            }
            model.email = TWRequest.GetFormString("txt_email");
            model.sex = TWRequest.GetFormString("txt_sex");
            model.mobile = TWRequest.GetFormString("txt_tel");
            model.address = TWRequest.GetFormString("txt_address");
            model.exp = TWRequest.GetFormInt("txt_sub");
            model.nick_name = TWRequest.GetFormString("txt_nichen");
            string birthday = TWRequest.GetFormString("txt_year").Trim() + "-" + TWRequest.GetFormString("txt_month").Trim() + "-" + TWRequest.GetFormString("txt_day").Trim();
            try
            {
                model.birthday = System.DateTime.Parse(birthday);
            }
            catch (Exception eee)
            {
                Response.Write(ljd.function.LocalHint("請輸入正確的日期！", ""));
                Response.End();
                return;
            }
            if (TWRequest.GetFormInt("txt_year") < 1900  ||  TWRequest.GetFormInt("txt_year")>System.DateTime.Now.Year)
            {
                Response.Write(ljd.function.LocalHint("請輸入正確的日期！", ""));
                Response.End();
                return;
            }
            if (TWRequest.GetFormString("txt_guo") == "台灣")
            {
                model.area = TWRequest.GetFormString("txt_guo") + "," + TWRequest.GetFormString("txt_state") + "," + TWRequest.GetFormString("txt_city");
            }
            else
            {
                model.area = TWRequest.GetFormString("txt_guo") + "," + TWRequest.GetFormString("txt_state1") + "," + TWRequest.GetFormString("txt_city1");
            }
            if (model.reg_time == null)
            {
                model.reg_time = System.DateTime.Now;
            }
            model.qq = TWRequest.GetFormString("txt_zip");
            //執行修改操作

            new Tea.BLL.users().Update(model);
            Response.Write(ljd.function.LocalHint("送出成功", "edituser.aspx"));
            return;
        }
    }
}