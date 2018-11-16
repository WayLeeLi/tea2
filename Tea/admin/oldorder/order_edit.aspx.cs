using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
using System.Text;
using System.IO;
using System.Data.OleDb;
namespace Tea.Web.admin.order
{
    public partial class order_edit : Web.UI.ManagePage
    {
        protected string id;
       
        protected void Page_Load(object sender, EventArgs e)
        {
             
            id = TWRequest.GetQueryString("id");
            string uploadPath = "/users/orders.xls";
            string filePath = Server.MapPath(uploadPath);
            string fileExt = System.IO.Path.GetExtension(filePath);
            string conn = "", conn1 = "";
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            if (fileExt == ".xls")
            {
                conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;IMEX=1'";
            }
            OleDbConnection excelCon = new OleDbConnection(conn);
            OleDbDataAdapter odda = new OleDbDataAdapter("SELECT * FROM [orders$] where OrderNumber='" + id + "'", excelCon);

            OleDbConnection excelCon1 = new OleDbConnection(conn);
            OleDbDataAdapter odda1 = new OleDbDataAdapter("SELECT * FROM [orderslist$] where OrderNumber='" + id + "' and Num>0", excelCon1);
            try
            {
                odda.Fill(dt);
                data_list.DataSource = dt;
                data_list.DataBind();
 
            }
            catch (Exception ex)
            {

            }
            finally
            {
                excelCon.Close();
                excelCon.Dispose();
            }

            try
            {
                odda1.Fill(dt1);

                data_list1.DataSource = dt1;
                data_list1.DataBind();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                excelCon.Close();
                excelCon.Dispose();
            }

          
        }
 
    }
}
