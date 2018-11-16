using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tea.Common;
namespace Tea.BLL
{
    public partial class sendmail
    {
        protected internal Model.siteconfig config = new BLL.siteconfig().loadConfig();
        protected string weburl = "";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="ucid"></param>
        /// <param name="where"></param>
        /// <param name="mialtitle"></param>
        /// <param name="emailurl"></param>
        /// <returns></returns>
        public string send(string email, int ucid,string where,string mialtitle,string emailurl)
        {
            weburl = config.weburl;
            //bool b = false;
            string allstr = "";
            try
            {
                if (emailurl == "Email認證通知")
                {
                    string url = weburl + "mail_com/Email認證通知.aspx?id=" + ucid, ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "廠商結算報表通知")
                {
                    string url = weburl + "mail_com/廠商結算報表通知.aspx?id=" + ucid + "&date=date&datestr=datestr", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "廠商結算已匯款通知")
                {
                    string url = weburl + "mail_com/廠商結算已匯款通知.aspx?id=" + ucid + "&date=date", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "訂單待出貨通知")
                {
                    string url = weburl + "mail_com/訂單待出貨通知.aspx?id=" + ucid + "&orderno=orderno&orderdate=orderdate", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "訂單待出貨通知_逾期")
                {
                    string url = weburl + "mail_com/訂單待出貨通知_逾期.aspx?id=" + ucid + "&orderno=orderno&orderdate=orderdate", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "訂單退訂通知信")
                {
                    string url = weburl + "mail_com/訂單退訂通知信.aspx?id=" + ucid + "&orderno=orderno&orderdate=orderdate", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "公告")
                {
                    string url = weburl + "mail_com/公告.aspx?id=" + ucid + "&aid=1", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "客服系統信")
                {
                    string url = weburl + "mail_com/客服系統信.aspx?id=" + ucid + "&cid=5", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "密碼變更通知信")
                {
                    string url = weburl + "mail_com/密碼變更通知信.aspx?id=" + ucid, ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "七天內不接受顧客辦退申訴")
                {
                    string url = weburl + "mail_com/七天內不接受顧客辦退申訴.aspx?id=" + ucid + "&orderno=orderno&orderstatus=orderstatus", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "重設密碼")
                {
                    string url = weburl + "mail_com/重設密碼.aspx?id=" + ucid, ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "訂單_成立通知_ATM")
                {
                    string url = weburl + "mail_user/訂單_成立通知_ATM.aspx?id=" + ucid + "&oid=6", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "訂單_退訂通知")
                {
                    string url = weburl + "mail_user/訂單_退訂通知.aspx?id=" + ucid + "&oid=6", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "訂單_已出貨通知")
                {
                    string url = weburl + "mail_user/訂單_已出貨通知.aspx?id=" + ucid + "&oid=6", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "訂單_已收到款項通知")
                {
                    string url = weburl + "mail_user/訂單_已收到款項通知.aspx?id=" + ucid + "&oid=6", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "訂單_已退款通知_信用卡")
                {
                    string url = weburl + "mail_user/訂單_已退款通知_信用卡.aspx?id=" + ucid + "&oid=6", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "訂單_已退款通知_帳戶匯款")
                {
                    string url = weburl + "mail_user/訂單_已退款通知_帳戶匯款.aspx?id=" + ucid + "&oid=6", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "購物金_獲得了購物金通知")
                {
                    string url = weburl + "mail_user/購物金_獲得了購物金通知.aspx?id=" + ucid + "&pid=11", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "購物金_即將到期通知")
                {
                    string url = weburl + "mail_user/購物金_即將到期通知.aspx?id=" + ucid + "&pid=11", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "購物金_提現申請已撥款通知")
                {
                    string url = weburl + "mail_user/購物金_提現申請已撥款通知.aspx?id=" + ucid + "&pid=11", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "客服_系統信")
                {
                    string url = weburl + "mail_user/客服_系統信.aspx?id=" + ucid, ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "帳號_密碼變更通知")
                {
                    string url = weburl + "mail_user/帳號_密碼變更通知.aspx?id=" + ucid, ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "帳號_重設密碼")
                {
                    string url = weburl + "mail_user/帳號_重設密碼.aspx?id=" + ucid, ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "折價券_即將到期通知")
                {
                    string url = weburl + "mail_user/折價券_即將到期通知.aspx?id=" + ucid + "&qid=5", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "折價券_領取了通知")
                {
                    string url = weburl + "mail_user/折價券_領取了通知.aspx?id=" + ucid + "&qid=5", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }
                if (emailurl == "折價券_有人領取了分享的通知")
                {
                    string url = weburl + "mail_user/折價券_有人領取了分享的通知.aspx?id=" + ucid + "&qid=5", ss = "";
                    allstr = ljd.function.GetPage(url, out ss);
                    TWMail.sendMail(config.emailsmtp, config.emailssl, config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, email, mialtitle, allstr);
                }


            }
            catch (Exception eee) { }
            return allstr;
        }
    }
}
