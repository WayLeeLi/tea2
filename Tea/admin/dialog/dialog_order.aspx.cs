﻿using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data.OleDb;

namespace Tea.Web.admin.dialog
{
    public partial class dialog_import : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            string uploadPath = excelPath.Text;
            string filePath = "";
            string getErrorMsg = "";
            string conn = "";
            DataTable dt = new DataTable();
            if (string.IsNullOrEmpty(uploadPath))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "importErr", "<script>W.$.dialog.alert('請選擇要導入的Excel文件！', function () { }, api);</script>");
                return;
            }
            filePath = Server.MapPath(uploadPath);
            //獲取文件的尾碼名
            string fileExt = System.IO.Path.GetExtension(filePath);
            if (!(fileExt == ".xls" || fileExt == ".xlsx"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "importMsg", "<script>W.$.dialog.alert('檔案格式錯誤！', function () { }, api);</script>");
                return;
            }

            if (!System.IO.File.Exists(filePath))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "importMsg", "<script>W.$.dialog.alert('請確認正確的文件路徑！', function () { }, api);</script>");
                return;
            }

            if (fileExt == ".xlsx")
            {
                conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;IMEX=1'";
            }
            else if (fileExt == ".xls")
            {
                conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;IMEX=1'";
            }
            OleDbConnection excelCon = new OleDbConnection(conn);
            //中括號裏的內容是Excel檔裡面工作表名 默認為Sheet1,後面需要加上$符號
            OleDbDataAdapter odda = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", excelCon);
            try
            {
                odda.Fill(dt);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "importMsg", "<script>W.$.dialog.alert('" + ex.Message.Replace("'", "") + "！', function () { }, api);</script>");
            }
            finally
            {
                excelCon.Close();
                excelCon.Dispose();
            }
            //將資料寫到資料庫裡面
            if (dt.Rows.Count != 0)
            {
                getErrorMsg = InsertGoods(dt);
                if (getErrorMsg == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "importMsg", "<script>W.location.reload();</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "importMsg", "<script>W.$.dialog.alert('" + getErrorMsg + "！', function () { }, api);</script>");
                }
            }
        }

        //將excel的資料寫入資料庫
        private string InsertGoods(DataTable dt)
        {
            string result = "";
            BLL.orders bll = new BLL.orders();
            Model.orders model = null;

            //判斷列名是否規範
            string[] strColumn = { "訂單號", "發票號"};
            int num = 0;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                foreach (string str in strColumn)
                {
                    if (str == dt.Columns[i].ColumnName)
                    {
                        num++;
                    }
                }
            }

            if (num == strColumn.Length)
            {
                //遍歷主件

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString().Trim() != "" && dr[1].ToString().Trim() != "")
                    {
                        bool update = true;
                        try
                        {
                            model = bll.GetModel(dr[0].ToString());
                        }
                        catch (Exception eee) { }
                        if (model != null)
                        {
                            model.trade_no = dr[1].ToString();

                            if (update)
                            {
                                bll.Update(model);
                            }
                        }
                    }

                }

            }
            else
            {
                result = "請檢查excel檔案格式！" + num + strColumn.Length;
            }
            return result;
        }
    }
}
