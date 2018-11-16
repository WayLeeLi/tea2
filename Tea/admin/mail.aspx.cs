using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;

public partial class admin_mail : Tea.Web.UI.ManagePage
{

    protected Tea.Model.users model = null;
    Tea.BLL.users bll = new Tea.BLL.users();
    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds = bll.GetList(100, "msn='" + System.DateTime.Now.ToString("yyyyMMdd") + "'", "id");
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            model = bll.GetModel(int.Parse(dr["id"].ToString()));
            try
            {
                string title = "積分清零提醒";
                string str = "您還有" + dr["point"] + "積分年底到期請注意使用。";
                TWMail.sendMail(siteConfig.emailsmtp,siteConfig.emailssl,siteConfig.emailport, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                           siteConfig.emailfrom, dr["email"].ToString(), title + " - " + siteConfig.webname + "", str);
            }
            catch (Exception eee) { }

            model.msn = System.DateTime.Now.ToString("yyyyMMdd");
            bll.Update(model);
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("正在發送請勿關閉本頁");
            Response.Redirect("mail.aspx");
        }
        else
        {



            Response.Write("發送完畢可以關閉本頁");
            Response.End();
        }
    }

}
