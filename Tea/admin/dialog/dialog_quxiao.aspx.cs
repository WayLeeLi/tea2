using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.dialog
{
    public partial class dialog_express : Web.UI.ManagePage
    {
        private string order_no = string.Empty;

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
                JscriptMsg("訂單不存在或已被刪除！", "back");
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
            Model.orders model = bll.GetModel(_order_no);

            txtdes.Text = model.remark; ;
           
        }
        #endregion
    }
}
