using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
using Tea.Common;

namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:销售活动
    /// </summary>
    public partial class sales
    {
        private string databaseprefix; //数据库表名前缀
        public sales(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }
        #region 基本方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "sales");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回标题名称
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title from " + databaseprefix + "sales");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "-";
            }
            return title;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.sales model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "sales(");
            strSql.Append("title,sub_title,img_url,type,quantity,amount,start_time,end_time,sort_id,status,summary,content,company)");
            strSql.Append(" values (");
            strSql.Append("@title,@sub_title,@img_url,@type,@quantity,@amount,@start_time,@end_time,@sort_id,@status,@summary,@content,@company)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,255),
					new SqlParameter("@sub_title", SqlDbType.NVarChar,100),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@amount", SqlDbType.Decimal,5),
					new SqlParameter("@start_time", SqlDbType.DateTime),
					new SqlParameter("@end_time", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@summary", SqlDbType.NVarChar,255),
					new SqlParameter("@content", SqlDbType.NText),
                    new SqlParameter("@company", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.sub_title;
            parameters[2].Value = model.img_url;
            parameters[3].Value = model.type;
            parameters[4].Value = model.quantity;
            parameters[5].Value = model.amount;
            parameters[6].Value = model.start_time;
            parameters[7].Value = model.end_time;
            parameters[8].Value = model.sort_id;
            parameters[9].Value = model.status;
            parameters[10].Value = model.summary;
            parameters[11].Value = model.content;
            parameters[12].Value = model.company;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "sales set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.sales model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "sales set ");
            strSql.Append("title=@title,");
            strSql.Append("sub_title=@sub_title,");
            strSql.Append("img_url=@img_url,");
            strSql.Append("type=@type,");
            strSql.Append("quantity=@quantity,");
            strSql.Append("amount=@amount,");
            strSql.Append("start_time=@start_time,");
            strSql.Append("end_time=@end_time,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("status=@status,");
            strSql.Append("summary=@summary,");
            strSql.Append("content=@content,");
             strSql.Append("company=@company");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,255),
					new SqlParameter("@sub_title", SqlDbType.NVarChar,100),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@amount", SqlDbType.Decimal,5),
					new SqlParameter("@start_time", SqlDbType.DateTime),
					new SqlParameter("@end_time", SqlDbType.DateTime),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@summary", SqlDbType.NVarChar,255),
					new SqlParameter("@content", SqlDbType.NText),
                    new SqlParameter("@company", SqlDbType.Int,4),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            
            parameters[0].Value = model.title;
            parameters[1].Value = model.sub_title;
            parameters[2].Value = model.img_url;
            parameters[3].Value = model.type;
            parameters[4].Value = model.quantity;
            parameters[5].Value = model.amount;
            parameters[6].Value = model.start_time;
            parameters[7].Value = model.end_time;
            parameters[8].Value = model.sort_id;
            parameters[9].Value = model.status;
            parameters[10].Value = model.summary;
            parameters[11].Value = model.content;
            parameters[12].Value = model.company;
            parameters[13].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "sales ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.sales GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,sub_title,img_url,type,quantity,amount,start_time,end_time,sort_id,status,summary,content,company from " + databaseprefix + "sales ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.sales model = new Model.sales();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.sub_title = ds.Tables[0].Rows[0]["sub_title"].ToString();
                model.img_url = ds.Tables[0].Rows[0]["img_url"].ToString();
                model.type = ds.Tables[0].Rows[0]["type"].ToString();
                if (ds.Tables[0].Rows[0]["quantity"].ToString() != "")
                {
                    model.quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["amount"].ToString() != "")
                {
                    model.amount = decimal.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["start_time"].ToString() != "")
                {
                    model.start_time = DateTime.Parse(ds.Tables[0].Rows[0]["start_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["end_time"].ToString() != "")
                {
                    model.end_time = DateTime.Parse(ds.Tables[0].Rows[0]["end_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                model.summary = ds.Tables[0].Rows[0]["summary"].ToString();
                model.content = ds.Tables[0].Rows[0]["content"].ToString();
                if (ds.Tables[0].Rows[0]["company"].ToString() != "")
                {
                    model.company = int.Parse(ds.Tables[0].Rows[0]["company"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,sub_title,img_url,type,quantity,amount,start_time,end_time,sort_id,status,summary,content,company ");
            strSql.Append(" FROM " + databaseprefix + "sales ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by sort_id asc,id desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,title,sub_title,img_url,type,quantity,amount,start_time,end_time,sort_id,status,summary,content,company ");
            strSql.Append(" FROM " + databaseprefix + "sales ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "sales");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method

        #region 前台方法
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetMenuList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,title,sub_title,img_url,type,company ");
            strSql.Append(" FROM " + databaseprefix + "sales ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion Method
    }
}