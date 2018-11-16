using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
using System.Text;
using System.IO;
using System.Data.OleDb;
public partial class order : Tea.Web.UI.UserPage
{
    protected int show = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string uploadPath = "/users/orders.xls";
        string filePath = Server.MapPath(uploadPath);
        string fileExt = System.IO.Path.GetExtension(filePath);
        string conn = "";
        DataTable dt = new DataTable();
        if (fileExt == ".xls")
        {
            conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;IMEX=1'";
   
        }
        OleDbConnection excelCon = new OleDbConnection(conn);
        OleDbDataAdapter odda = new OleDbDataAdapter("SELECT * FROM [orders$] where UserID='" + userModel.user_name + "' order by date desc", excelCon);
        try
        {
            odda.Fill(dt);

            data_list.DataSource = dt;
            data_list.DataBind();
            show = data_list.Items.Count;
        }
        catch (Exception ex)
        { }
        finally
        {
            excelCon.Close();
            excelCon.Dispose();
        }
    }
 
}