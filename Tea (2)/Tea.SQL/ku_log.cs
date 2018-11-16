using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:ku_log
    /// </summary>
    public partial class ku_log
    {
        private string databaseprefix; //数据库表名前缀
        public ku_log(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("log_id",databaseprefix + "ku_log");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int log_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "ku_log");
            strSql.Append(" where log_id=@log_id");
            SqlParameter[] parameters = {
					new SqlParameter("@log_id", SqlDbType.Int,4)
			};
            parameters[0].Value = log_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tea.Model.ku_log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "ku_log(");
            strSql.Append("log_shop,log_goods,log_add_date,log_num,log_old_num,log_new_num,log_where,log_user,log_name,log_title)");
            strSql.Append(" values (");
            strSql.Append("@log_shop,@log_goods,@log_add_date,@log_num,@log_old_num,@log_new_num,@log_where,@log_user,@log_name,@log_title)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@log_shop", SqlDbType.Int,4),
					new SqlParameter("@log_goods", SqlDbType.Int,4),
					new SqlParameter("@log_add_date", SqlDbType.DateTime),
					new SqlParameter("@log_num", SqlDbType.Int,4),
					new SqlParameter("@log_old_num", SqlDbType.Int,4),
					new SqlParameter("@log_new_num", SqlDbType.Int,4),
					new SqlParameter("@log_where", SqlDbType.NVarChar,32),
					new SqlParameter("@log_user", SqlDbType.Int,4),
					new SqlParameter("@log_name", SqlDbType.NVarChar,64),
					new SqlParameter("@log_title", SqlDbType.NVarChar,256)};
            parameters[0].Value = model.log_shop;
            parameters[1].Value = model.log_goods;
            parameters[2].Value = model.log_add_date;
            parameters[3].Value = model.log_num;
            parameters[4].Value = model.log_old_num;
            parameters[5].Value = model.log_new_num;
            parameters[6].Value = model.log_where;
            parameters[7].Value = model.log_user;
            parameters[8].Value = model.log_name;
            parameters[9].Value = model.log_title;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Tea.Model.ku_log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "ku_log set ");
            strSql.Append("log_shop=@log_shop,");
            strSql.Append("log_goods=@log_goods,");
            strSql.Append("log_add_date=@log_add_date,");
            strSql.Append("log_num=@log_num,");
            strSql.Append("log_old_num=@log_old_num,");
            strSql.Append("log_new_num=@log_new_num,");
            strSql.Append("log_where=@log_where,");
            strSql.Append("log_user=@log_user,");
            strSql.Append("log_name=@log_name,");
            strSql.Append("log_title=@log_title");
            strSql.Append(" where log_id=@log_id");
            SqlParameter[] parameters = {
					new SqlParameter("@log_shop", SqlDbType.Int,4),
					new SqlParameter("@log_goods", SqlDbType.Int,4),
					new SqlParameter("@log_add_date", SqlDbType.DateTime),
					new SqlParameter("@log_num", SqlDbType.Int,4),
					new SqlParameter("@log_old_num", SqlDbType.Int,4),
					new SqlParameter("@log_new_num", SqlDbType.Int,4),
					new SqlParameter("@log_where", SqlDbType.NVarChar,32),
					new SqlParameter("@log_user", SqlDbType.Int,4),
					new SqlParameter("@log_name", SqlDbType.NVarChar,64),
					new SqlParameter("@log_title", SqlDbType.NVarChar,256),
					new SqlParameter("@log_id", SqlDbType.Int,4)};
            parameters[0].Value = model.log_shop;
            parameters[1].Value = model.log_goods;
            parameters[2].Value = model.log_add_date;
            parameters[3].Value = model.log_num;
            parameters[4].Value = model.log_old_num;
            parameters[5].Value = model.log_new_num;
            parameters[6].Value = model.log_where;
            parameters[7].Value = model.log_user;
            parameters[8].Value = model.log_name;
            parameters[9].Value = model.log_title;
            parameters[10].Value = model.log_id;

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
            strSql.Append("delete from " + databaseprefix + "ku_log ");
            strSql.Append(" where log_id=@log_id");
            SqlParameter[] parameters = {
					new SqlParameter("@log_id", SqlDbType.Int,4)
			};
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
            strSql.Append("delete from " + databaseprefix + "ku_log ");
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
        public Tea.Model.ku_log GetModel(int log_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 log_id,log_shop,log_goods,log_add_date,log_num,log_old_num,log_new_num,log_where,log_user,log_name,log_title from " + databaseprefix + "ku_log ");
            strSql.Append(" where log_id=@log_id");
            SqlParameter[] parameters = {
					new SqlParameter("@log_id", SqlDbType.Int,4)
			};
            parameters[0].Value = log_id;

            Tea.Model.ku_log model = new Tea.Model.ku_log();
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
        public Tea.Model.ku_log DataRowToModel(DataRow row)
        {
            Tea.Model.ku_log model = new Tea.Model.ku_log();
            if (row != null)
            {
                if (row["log_id"] != null && row["log_id"].ToString() != "")
                {
                    model.log_id = int.Parse(row["log_id"].ToString());
                }
                if (row["log_shop"] != null && row["log_shop"].ToString() != "")
                {
                    model.log_shop = int.Parse(row["log_shop"].ToString());
                }
                if (row["log_goods"] != null && row["log_goods"].ToString() != "")
                {
                    model.log_goods = int.Parse(row["log_goods"].ToString());
                }
                if (row["log_add_date"] != null && row["log_add_date"].ToString() != "")
                {
                    model.log_add_date = DateTime.Parse(row["log_add_date"].ToString());
                }
                if (row["log_num"] != null && row["log_num"].ToString() != "")
                {
                    model.log_num = int.Parse(row["log_num"].ToString());
                }
                if (row["log_old_num"] != null && row["log_old_num"].ToString() != "")
                {
                    model.log_old_num = int.Parse(row["log_old_num"].ToString());
                }
                if (row["log_new_num"] != null && row["log_new_num"].ToString() != "")
                {
                    model.log_new_num = int.Parse(row["log_new_num"].ToString());
                }
                if (row["log_where"] != null)
                {
                    model.log_where = row["log_where"].ToString();
                }
                if (row["log_user"] != null && row["log_user"].ToString() != "")
                {
                    model.log_user = int.Parse(row["log_user"].ToString());
                }
                if (row["log_name"] != null)
                {
                    model.log_name = row["log_name"].ToString();
                }
                if (row["log_title"] != null)
                {
                    model.log_title = row["log_title"].ToString();
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
            strSql.Append("select log_id,log_shop,log_goods,log_add_date,log_num,log_old_num,log_new_num,log_where,log_user,log_name,log_title ");
            strSql.Append(" FROM " + databaseprefix + "ku_log ");
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
            strSql.Append(" log_id,log_shop,log_goods,log_add_date,log_num,log_old_num,log_new_num,log_where,log_user,log_name,log_title ");
            strSql.Append(" FROM " + databaseprefix + "ku_log ");
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
            strSql.Append("select count(1) FROM " + databaseprefix + "ku_log ");
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
            strSql.Append(")AS Row, T.*  from " + databaseprefix + "ku_log T ");
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

