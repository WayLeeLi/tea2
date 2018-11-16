using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data.OleDb;
using System.Collections;
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
            BLL.quan bll = new BLL.quan();
            Model.quan model = null;

            //判斷列名是否規範
            string[] strColumn = { "名稱", "券號", "金額", "數量", "開始時間", "結束時間", "適用商品" };
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
                    if (dr[0].ToString().Trim() != "" && dr[1].ToString().Trim() != "" && dr[2].ToString().Trim() != "" && dr[3].ToString().Trim() != "")
                    {
                        bool updatea = true;
                        try
                        {
                            model = bll.GetModel(dr[1].ToString());
                        }
                        catch (Exception eee) { }
                        if (model == null)
                        {
                            model = new Model.quan();
                            updatea = false;
                        }
  
                        model.quan_code = dr[1].ToString();
                        model.quan_title = dr[0].ToString();
                        model.quan_name = dr[0].ToString();
                        model.quan_num = Utils.StrToDecimal(dr[2].ToString(), 0);
                        model.quan_sort = Utils.StrToInt(dr[3].ToString(), 0);
                        model.quan_add_date = System.DateTime.Now;
                        model.quan_begin_date = Utils.StrToDateTime(dr[4].ToString());
                        model.quan_end_date = Utils.StrToDateTime(dr[5].ToString());
                        model.quan_des = getcode(dr[6].ToString());
                        model.quan_where = "lin";
                        int pid = 0;
                        if (updatea)
                        {
                            bll.Update(model);
                        }
                        else
                        {
                            pid = bll.Add(model);
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

        public string getcode(string no)
        {
            string str = "";
            IList _list = no.Split(',');
            foreach(object ob in _list)
            {
                if (!string.IsNullOrEmpty(ob.ToString()))
                {
                    str = str + Tea.DBUtility.DbHelperSQL.Query("select id from shop_goods where goods_no='"+ob.ToString()+"'").Tables[0].Rows[0][0].ToString()+",";
                }
            }
            return Utils.DelLastComma(str);
        }
    }
}
