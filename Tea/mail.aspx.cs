using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
public partial class mail : Tea.Web.UI.ShopPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TWMail.sendMail(config.emailsmtp, config.emailssl,config.emailport,config.emailusername, config.emailpassword, config.emailnickname, config.emailfrom, "342888806@qq.com", "我要測試一下", "我要測試一下ok");

    }
}