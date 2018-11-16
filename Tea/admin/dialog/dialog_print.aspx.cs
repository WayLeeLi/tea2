using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.dialog
{
    public partial class dialog_print : Web.UI.ManagePage
    {
        private string order_no = string.Empty;
        protected Model.orders model = new Model.orders();
        protected Model.manager adminModel = new Model.manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            order_no = TWRequest.GetQueryString("order_no");
            if (order_no == "")
            {
                JscriptMsg("傳輸參數不正確！", "back");
                return;
            }
            if (!new BLL.orders().Exists(order_no))
            {
                JscriptMsg("訂單不存在或已被删除！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                ShowInfo(order_no);
            }
        }

        #region 賦值操作=================================
        private void ShowInfo(string _order_no)
        {
            BLL.orders bll = new BLL.orders();
            model = bll.GetModel(_order_no);
            adminModel = GetAdminInfo();
            this.rptList.DataSource = model.order_goods;
            this.rptList.DataBind();
        }
        #endregion

        public string getuseradd(string useradd, int i)
        {
            string str = "";
            try
            {
                str = useradd.Split('|')[i].ToString();
            }
            catch (Exception eee) { }
            return str;
        }
    }
}