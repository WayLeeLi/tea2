using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin
{
    public partial class index : Web.UI.ManagePage
    {
        protected Model.manager admin_info; //管理員資料
        protected string url = "center.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                admin_info = GetAdminInfo();
                if (admin_info.role_id != 1)
                {
                    url = "order/order_list.aspx";
                }
            }
        }

        //安全退出
        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            Session[TWKeys.SESSION_ADMIN_INFO] = null;
            Utils.WriteCookie("AdminName", "Tea", -14400);
            Utils.WriteCookie("AdminPwd", "Tea", -14400);
            Response.Redirect("login.aspx");
        }

    }
}