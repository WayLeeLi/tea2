using System;
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
            BLL.article_category categoryBll = new BLL.article_category();
            BLL.article articleBll = new BLL.article();
            BLL.goods goodsBll = new BLL.goods();
 
            Model.article articleModel = null;
            Model.goods goodsModel = null;
            //判斷列名是否規範
            string[] strColumn = { "類別*", "品牌", "商品型號*", "商品名稱", "隊伍", "顏色*", "尺寸*", "數量量*", "市價", "售價", "商品描述", "商品說明", "注意事項", "商品分類1", "商品分類2", "商品分類3", "關鍵字", "上架日期", "下架日期", "每人限購數量*", "前臺排序", "重量", "長", "寬", "高", "紅利" };
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
                DataRow[] drArr = dt.Select("[類別*]='商品主件'");
                foreach (DataRow dr in drArr)
                {
                    if (dr[0].ToString().Trim() != "")
                    {
                        bool updatea = true;
                        DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select * from shop_article where goods_no='" + dr[2].ToString().Trim() + "'");

                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            articleModel = articleBll.GetModel(int.Parse(ds.Tables[0].Rows[0]["id"].ToString()));
                        }
                        if (articleModel == null)
                        {
                            articleModel = new Model.article();
                            updatea = false;
                        }
                        articleModel.channel_id = 2;
                        if (string.IsNullOrEmpty(dr[13].ToString()))
                        {
                            articleModel.category_id = 0;
                        }
                        else
                        {
                            articleModel.category_id = int.Parse(dr[13].ToString());// categoryBll.GetID(dr[13].ToString().Split(',')[0]);
                        }
                        //articleModel.more_type = dr[15].ToString();
                        articleModel.call_index = "";
                        articleModel.title = dr[3].ToString();
                        articleModel.link_url = "";
                        if (string.IsNullOrEmpty(dr[1].ToString()))
                        {
                            //articleModel.brand_id = 0;
                        }
                        else
                        {
                            //articleModel.brand_id = brandBll.GetID(dr[1].ToString());
                        }
                        if (string.IsNullOrEmpty(dr[4].ToString()))
                        {
                           // articleModel.team_id = 0;
                        }
                        else
                        {
                            //articleModel.team_id = teamBll.GetID(dr[4].ToString());
                        }
                        articleModel.img_url = "";
                        articleModel.seo_title = "";
                        articleModel.seo_keywords = dr[16].ToString();
                        articleModel.seo_description = "";
                        articleModel.zhaiyao = "";
                        articleModel.content = "";// dr[10].ToString();
                        articleModel.sort_id = Utils.ObjToInt(dr[20], 999);
                        articleModel.click = 0;
                        articleModel.status = 1;
                        articleModel.is_msg = 0;
                        articleModel.is_tui = 0;
                        articleModel.is_can = 0;
                        articleModel.is_zhe = 0;
                        articleModel.is_slide = 0;
                        articleModel.is_sys = 1; //管理員發佈
                        articleModel.user_name = "admin"; //獲得當前登入用戶名
                        articleModel.add_time = DateTime.Now;
                        //articleModel.sales_id = 0;
                        int pid = 0;
                        if (updatea)
                        {
                            articleBll.Update(articleModel);
                            pid = articleModel.id;
                        }
                        else
                        {
                            pid = articleBll.Add(articleModel);
                        }


                        //匯入子件
                        DataRow[] drArr1 = dt.Select("[類別*]='子件' and [商品型號*] like '" + dr[2].ToString() + "%'");
                        foreach (DataRow dr1 in drArr1)
                        {
                            bool updateg = true;
                            DataSet dsg = Tea.DBUtility.DbHelperSQL.Query("select * from shop_goods where goods_no='" + dr1[2].ToString().Trim() + "'");
                            if (dsg.Tables[0].Rows.Count > 0)
                            {
                                goodsModel = goodsBll.GetModel(int.Parse(dsg.Tables[0].Rows[0]["id"].ToString()));
                            }
                            if (goodsModel == null)
                            {
                                goodsModel = new Model.goods();
                                updateg = false;
                            }

                            goodsModel.parent_id = pid;
                            goodsModel.color = dr1[5].ToString();
                            goodsModel.size = dr1[6].ToString();
                            goodsModel.goods_no = dr1[2].ToString();
                            if (dr1[8].ToString().Trim() != "")
                            {
                                goodsModel.market_price = Utils.ObjToDecimal(dr1[8], 0M);
                            }
                            else
                            {
                                goodsModel.market_price = Utils.ObjToDecimal(dr[8], 0M);
                            }
                            if (dr1[9].ToString().Trim() != "")
                            {
                                goodsModel.sell_price = Utils.ObjToDecimal(dr1[9], 0M);
                            }
                            else
                            {
                                goodsModel.sell_price = Utils.ObjToDecimal(dr[9], 0M);
                            }
                            if (dr1[7].ToString().Trim() != "")
                            {
                                goodsModel.stock_quantity = Utils.ObjToInt(dr1[7], 0);
                            }
                            else
                            {
                                goodsModel.stock_quantity = Utils.ObjToInt(dr[7], 0);
                            }
                            goodsModel.alert_quantity = 0;
                            goodsModel.img_url = "";
                            if (goodsModel.goods_no.Trim().Length > 4)
                            {
                                if (updateg)
                                {
                                    goodsBll.Update(goodsModel);
                                }
                                else
                                {
                                    goodsBll.Add(goodsModel);
                                }
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
