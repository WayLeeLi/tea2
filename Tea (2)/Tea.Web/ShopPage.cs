using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Configuration;
using Tea.Common;
using Tea.DBUtility;
namespace Tea.Web.UI
{
    public partial class ShopPage : System.Web.UI.Page
    {
        protected internal Model.siteconfig config = new BLL.siteconfig().loadConfig();
        protected internal Model.userconfig uconfig = new BLL.userconfig().loadConfig();
        protected internal Model.orderconfig oconfig = new BLL.orderconfig().loadConfig();
        protected internal string title, keyword, describe;
        protected string domain = ".uartu.com";
        protected string weburl = "http://" + ljd.function.GetHomeUrl() + "/";
        /// <summary>
        /// 父類的構造函數
        /// </summary>
        public ShopPage()
        {
            weburl = config.weburl;
            //是否關閉網站
            if (config.webstatus == 0)
            {
                HttpContext.Current.Response.Redirect(weburl + "error.aspx?msg=" + Utils.UrlEncode(config.webclosereason));
                return;
            }
            //是否關閉網站
            title = config.webname;
            keyword = config.webname;
            describe = config.webname;

            //DataSet ds=Tea.DBUtility.DbHelperSQL.Query("select * from view_article_product where stock_quantity>0 and datediff(day,end_time,getdate())>0");
            //BLL.article bll = new BLL.article();
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    Tea.Model.article model = bll.GetModel(int.Parse(dr["id"].ToString()));
            //    model.end_time = model.end_time.AddDays(int.Parse(dr["stock_quantity"].ToString()));
            //    bll.Update(model);
            //}
            ShowPage();
        }

        /// <summary>
        /// 頁面處理虛方法
        /// </summary>
        protected virtual void ShowPage()
        {
            //虛方法代碼
        }

        public decimal getyunum(int id, decimal p, decimal m)
        {
            decimal str = p;
            if (id > 0)
            {
                Tea.Model.sales models = new Tea.BLL.sales().GetModel(id);
                if (models != null && models.type == "2" && models.status == 1 && models.start_time < System.DateTime.Now && (models.end_time == null || models.end_time.Value.AddDays(1) > System.DateTime.Now))
                {
                    str = m;
                }
            }
            return str;
        }
        public string getzhe(string m, string s)
        {
            string str = "10";
            try
            {
                str = (Utils.StrToDecimal(s, 0) / Utils.StrToDecimal(m, 0) * 10).ToString("0.0");
                if (str.Split('.')[1] == "0")
                {
                    str = str.Split('.')[0].ToString();
                }
            }
            catch (Exception eee)
            { }
            return str;
        }
        public string getshen(string m, string s)
        {
            string str = "0";
            try
            {
                str = (Utils.StrToInt(m, 0) - Utils.StrToInt(s, 0)).ToString();
            }
            catch (Exception eee)
            { }
            return str;
        }


        #region 會員用戶方法==========================================
        /// <summary>
        /// 判斷用戶是否已經登入(解決Session超時問題)
        /// </summary>
        public bool IsUserLogin()
        {
            //如果Session為Null
            if (HttpContext.Current.Session[TWKeys.SESSION_USER_INFO] != null)
            {
                return true;
            }
            else
            {
                //檢查Cookies
                string username = Utils.GetCookie(TWKeys.COOKIE_USER_NAME_REMEMBER, "Tea");
                string password = Utils.GetCookie(TWKeys.COOKIE_USER_PWD_REMEMBER, "Tea");
                if (username != "" && password != "")
                {
                    BLL.users bll = new BLL.users();
                    Model.users model = bll.GetModel(username, password, 0, 0, false);
                    if (model != null)
                    {
                        HttpContext.Current.Session[TWKeys.SESSION_USER_INFO] = model;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 取得用戶資料
        /// </summary>
        public Model.users GetUserInfo()
        {
            if (IsUserLogin())
            {
                Model.users model = HttpContext.Current.Session[TWKeys.SESSION_USER_INFO] as Model.users;
                if (model != null)
                {
                    //為了能查詢到最新的用戶資料，必須查詢最新的用戶資料
                    model = new BLL.users().GetModel(model.id);
                    return model;
                }
            }
            return null;
        }
        #endregion

        #region 視圖查詢============================================
        /// <summary>
        /// 根據視圖顯示前幾條資料
        /// </summary>
        public DataSet GetViewList(string view_name, string view_field, int Top, string strWhere, string filedOrder)
        {
            return DalGetList(view_name, view_field, Top, strWhere, filedOrder);
        }
        public decimal GetQuan(decimal xian)
        {
            decimal zhe = xian;
            try
            {
                zhe = xian * oconfig.quanguan / 100;
            }
            catch (Exception eee) { }
            return zhe;
        }
        /// <summary>
        /// 根據視圖獲得查詢分頁資料
        /// </summary>
        public DataSet GetViewList(string view_name, string view_field, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return DalGetList(view_name, view_field, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// 根據視圖獲取總記錄數
        /// </summary>
        public int GetViewCount(string view_name, string view_field, string strWhere)
        {
            return DalGetCount(view_name, view_field, strWhere);
        }


        /// <summary>
        /// 根據視圖獲取總記錄數
        /// </summary>
        public int DalGetCount(string view_name, string view_field, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" count(1) FROM " + view_name);
            if (strWhere.Length > 2)
            {
                strSql.Append(" where " + strWhere);
            }

            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        /// <summary>
        /// 根據視圖顯示前幾條資料
        /// </summary>
        public DataSet DalGetList(string view_name, string view_field, int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            if (view_field.Length > 0)
            {
                strSql.Append(view_field);
            }
            else
            {
                strSql.Append(" *");
            }

            strSql.Append(" FROM " + view_name);
            if (strWhere.Length > 2)
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根據視圖獲得查詢分頁資料
        /// </summary>
        public DataSet DalGetList(string view_name, string view_field, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (view_field.Length > 0)
            {
                strSql.Append(view_field);
            }
            else
            {
                strSql.Append(" * ");
            }

            strSql.Append(" FROM " + view_name);
            if (strWhere.Length > 2)
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion
    }
}
