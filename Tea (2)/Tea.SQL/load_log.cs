using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:load_log
    /// </summary>
    public partial class load_log
    {
        private string databaseprefix; //数据库表名前缀
        public load_log(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("log_id", "" + databaseprefix + "load_log");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int log_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "load_log");
            strSql.Append(" where log_id=@log_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@log_id", SqlDbType.Int,4)			};
            parameters[0].Value = log_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Tea.Model.load_log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "load_log(");
            strSql.Append("log_id,log_add_date,log_shop,log_ip,log_num,log_where)");
            strSql.Append(" values (");
            strSql.Append("@log_id,@log_add_date,@log_shop,@log_ip,@log_num,@log_where)");
            SqlParameter[] parameters = {
					new SqlParameter("@log_id", SqlDbType.Int,4),
					new SqlParameter("@log_add_date", SqlDbType.DateTime),
					new SqlParameter("@log_shop", SqlDbType.Int,4),
					new SqlParameter("@log_ip", SqlDbType.NVarChar,32),
					new SqlParameter("@log_num", SqlDbType.Int,4),
					new SqlParameter("@log_where", SqlDbType.NVarChar,32)};
            parameters[0].Value = model.log_id;
            parameters[1].Value = model.log_add_date;
            parameters[2].Value = model.log_shop;
            parameters[3].Value = model.log_ip;
            parameters[4].Value = model.log_num;
            parameters[5].Value = model.log_where;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Tea.Model.load_log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "load_log set ");
            strSql.Append("log_add_date=@log_add_date,");
            strSql.Append("log_shop=@log_shop,");
            strSql.Append("log_ip=@log_ip,");
            strSql.Append("log_num=@log_num,");
            strSql.Append("log_where=@log_where");
            strSql.Append(" where log_id=@log_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@log_add_date", SqlDbType.DateTime),
					new SqlParameter("@log_shop", SqlDbType.Int,4),
					new SqlParameter("@log_ip", SqlDbType.NVarChar,32),
					new SqlParameter("@log_num", SqlDbType.Int,4),
					new SqlParameter("@log_where", SqlDbType.NVarChar,32),
					new SqlParameter("@log_id", SqlDbType.Int,4)};
            parameters[0].Value = model.log_add_date;
            parameters[1].Value = model.log_shop;
            parameters[2].Value = model.log_ip;
            parameters[3].Value = model.log_num;
            parameters[4].Value = model.log_where;
            parameters[5].Value = model.log_id;

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
        public bool Delete(int log_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "load_log ");
            strSql.Append(" where log_id=@log_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@log_id", SqlDbType.Int,4)			};
            parameters[0].Value = log_id;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string log_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "load_log ");
            strSql.Append(" where log_id in (" + log_idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Tea.Model.load_log GetModel(int log_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 log_id,log_add_date,log_shop,log_ip,log_num,log_where from " + databaseprefix + "load_log ");
            strSql.Append(" where log_id=@log_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@log_id", SqlDbType.Int,4)			};
            parameters[0].Value = log_id;

            Tea.Model.load_log model = new Tea.Model.load_log();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tea.Model.load_log DataRowToModel(DataRow row)
        {
            Tea.Model.load_log model = new Tea.Model.load_log();
            if (row != null)
            {
                if (row["log_id"] != null && row["log_id"].ToString() != "")
                {
                    model.log_id = int.Parse(row["log_id"].ToString());
                }
                if (row["log_add_date"] != null && row["log_add_date"].ToString() != "")
                {
                    model.log_add_date = DateTime.Parse(row["log_add_date"].ToString());
                }
                if (row["log_shop"] != null && row["log_shop"].ToString() != "")
                {
                    model.log_shop = int.Parse(row["log_shop"].ToString());
                }
                if (row["log_ip"] != null)
                {
                    model.log_ip = row["log_ip"].ToString();
                }
                if (row["log_num"] != null && row["log_num"].ToString() != "")
                {
                    model.log_num = int.Parse(row["log_num"].ToString());
                }
                if (row["log_where"] != null)
                {
                    model.log_where = row["log_where"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select log_id,log_add_date,log_shop,log_ip,log_num,log_where ");
            strSql.Append(" FROM " + databaseprefix + "load_log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            strSql.Append(" log_id,log_add_date,log_shop,log_ip,log_num,log_where ");
            strSql.Append(" FROM " + databaseprefix + "load_log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM " + databaseprefix + "load_log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.log_id desc");
            }
            strSql.Append(")AS Row, T.*  from " + databaseprefix + "load_log T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

