using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
using Tea.Common;
namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:basic
    /// </summary>
    public partial class basic
    {
        private string databaseprefix; //数据库表名前缀
        public basic(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("basic_id", databaseprefix + "basic");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int basic_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "basic");
            strSql.Append(" where basic_id=@basic_id");
            SqlParameter[] parameters = {
					new SqlParameter("@basic_id", SqlDbType.Int,4)
			};
            parameters[0].Value = basic_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tea.Model.basic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "basic(");
            strSql.Append("basic_label,basic_value,basic_sort,basic_show,basic_type,basic_where,basic_pic,basic_money,basic_content)");
            strSql.Append(" values (");
            strSql.Append("@basic_label,@basic_value,@basic_sort,@basic_show,@basic_type,@basic_where,@basic_pic,@basic_money,@basic_content)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@basic_label", SqlDbType.NVarChar,128),
					new SqlParameter("@basic_value", SqlDbType.NVarChar,128),
					new SqlParameter("@basic_sort", SqlDbType.Int,4),
					new SqlParameter("@basic_show", SqlDbType.Int,4),
					new SqlParameter("@basic_type", SqlDbType.NVarChar,128),
					new SqlParameter("@basic_where", SqlDbType.NVarChar,128),
					new SqlParameter("@basic_pic", SqlDbType.NVarChar,128),
					new SqlParameter("@basic_money", SqlDbType.Money,8),
					new SqlParameter("@basic_content", SqlDbType.NText)};
            parameters[0].Value = model.basic_label;
            parameters[1].Value = model.basic_value;
            parameters[2].Value = model.basic_sort;
            parameters[3].Value = model.basic_show;
            parameters[4].Value = model.basic_type;
            parameters[5].Value = model.basic_where;
            parameters[6].Value = model.basic_pic;
            parameters[7].Value = model.basic_money;
            parameters[8].Value = model.basic_content;

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
        public bool Update(Tea.Model.basic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "basic set ");
            strSql.Append("basic_label=@basic_label,");
            strSql.Append("basic_value=@basic_value,");
            strSql.Append("basic_sort=@basic_sort,");
            strSql.Append("basic_show=@basic_show,");
            strSql.Append("basic_type=@basic_type,");
            strSql.Append("basic_where=@basic_where,");
            strSql.Append("basic_pic=@basic_pic,");
            strSql.Append("basic_money=@basic_money,");
            strSql.Append("basic_content=@basic_content");
            strSql.Append(" where basic_id=@basic_id");
            SqlParameter[] parameters = {
					new SqlParameter("@basic_label", SqlDbType.NVarChar,128),
					new SqlParameter("@basic_value", SqlDbType.NVarChar,128),
					new SqlParameter("@basic_sort", SqlDbType.Int,4),
					new SqlParameter("@basic_show", SqlDbType.Int,4),
					new SqlParameter("@basic_type", SqlDbType.NVarChar,128),
					new SqlParameter("@basic_where", SqlDbType.NVarChar,128),
					new SqlParameter("@basic_pic", SqlDbType.NVarChar,128),
					new SqlParameter("@basic_money", SqlDbType.Money,8),
					new SqlParameter("@basic_content", SqlDbType.NText),
					new SqlParameter("@basic_id", SqlDbType.Int,4)};
            parameters[0].Value = model.basic_label;
            parameters[1].Value = model.basic_value;
            parameters[2].Value = model.basic_sort;
            parameters[3].Value = model.basic_show;
            parameters[4].Value = model.basic_type;
            parameters[5].Value = model.basic_where;
            parameters[6].Value = model.basic_pic;
            parameters[7].Value = model.basic_money;
            parameters[8].Value = model.basic_content;
            parameters[9].Value = model.basic_id;

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
        public bool Delete(int basic_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "basic ");
            strSql.Append(" where basic_id=@basic_id");
            SqlParameter[] parameters = {
					new SqlParameter("@basic_id", SqlDbType.Int,4)
			};
            parameters[0].Value = basic_id;

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
        public bool DeleteList(string basic_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "basic ");
            strSql.Append(" where basic_id in (" + basic_idlist + ")  ");
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
        public Tea.Model.basic GetModel(int basic_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 basic_id,basic_label,basic_value,basic_sort,basic_show,basic_type,basic_where,basic_pic,basic_money,basic_content from " + databaseprefix + "basic ");
            strSql.Append(" where basic_id=@basic_id");
            SqlParameter[] parameters = {
					new SqlParameter("@basic_id", SqlDbType.Int,4)
			};
            parameters[0].Value = basic_id;

            Tea.Model.basic model = new Tea.Model.basic();
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
        public Tea.Model.basic GetModel(string basic_label)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 basic_id,basic_label,basic_value,basic_sort,basic_show,basic_type,basic_where,basic_pic,basic_money,basic_content from " + databaseprefix + "basic ");
            strSql.Append(" where basic_label=@basic_label and basic_where='yunfei'");
            SqlParameter[] parameters = {
					new SqlParameter("@basic_label", SqlDbType.NVarChar,128)
			};
            parameters[0].Value = basic_label;

            Tea.Model.basic model = new Tea.Model.basic();
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
        public Tea.Model.basic DataRowToModel(DataRow row)
        {
            Tea.Model.basic model = new Tea.Model.basic();
            if (row != null)
            {
                if (row["basic_id"] != null && row["basic_id"].ToString() != "")
                {
                    model.basic_id = int.Parse(row["basic_id"].ToString());
                }
                if (row["basic_label"] != null)
                {
                    model.basic_label = row["basic_label"].ToString();
                }
                if (row["basic_value"] != null)
                {
                    model.basic_value = row["basic_value"].ToString();
                }
                if (row["basic_sort"] != null && row["basic_sort"].ToString() != "")
                {
                    model.basic_sort = int.Parse(row["basic_sort"].ToString());
                }
                if (row["basic_show"] != null && row["basic_show"].ToString() != "")
                {
                    model.basic_show = int.Parse(row["basic_show"].ToString());
                }
                if (row["basic_type"] != null)
                {
                    model.basic_type = row["basic_type"].ToString();
                }
                if (row["basic_where"] != null)
                {
                    model.basic_where = row["basic_where"].ToString();
                }
                if (row["basic_pic"] != null)
                {
                    model.basic_pic = row["basic_pic"].ToString();
                }
                if (row["basic_money"] != null && row["basic_money"].ToString() != "")
                {
                    model.basic_money = decimal.Parse(row["basic_money"].ToString());
                }
                if (row["basic_content"] != null)
                {
                    model.basic_content = row["basic_content"].ToString();
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
            strSql.Append("select basic_id,basic_label,basic_value,basic_sort,basic_show,basic_type,basic_where,basic_pic,basic_money,basic_content ");
            strSql.Append(" FROM " + databaseprefix + "basic ");
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
            strSql.Append(" basic_id,basic_label,basic_value,basic_sort,basic_show,basic_type,basic_where,basic_pic,basic_money,basic_content ");
            strSql.Append(" FROM " + databaseprefix + "basic ");
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
            strSql.Append("select count(1) FROM " + databaseprefix + "basic ");
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
                strSql.Append("order by T.basic_id desc");
            }
            strSql.Append(")AS Row, T.*  from " + databaseprefix + "basic T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "basic");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}

