using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
using Tea.Common;
namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:guige
    /// </summary>
    public partial class guige
    {
        private string databaseprefix; //数据库表名前缀
        public guige(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "guige set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("guige_id", "" + databaseprefix + "guige");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int guige_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "guige");
            strSql.Append(" where guige_id=@guige_id");
            SqlParameter[] parameters = {
					new SqlParameter("@guige_id", SqlDbType.Int,4)
			};
            parameters[0].Value = guige_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tea.Model.guige model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "guige(");
            strSql.Append("guige_title,guige_content,guige_sort,guige_add_date,guige_web)");
            strSql.Append(" values (");
            strSql.Append("@guige_title,@guige_content,@guige_sort,@guige_add_date,@guige_web)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@guige_title", SqlDbType.NVarChar,128),
					new SqlParameter("@guige_content", SqlDbType.NVarChar,1024),
					new SqlParameter("@guige_sort", SqlDbType.Int,4),
					new SqlParameter("@guige_add_date", SqlDbType.DateTime),
					new SqlParameter("@guige_web", SqlDbType.Int,4)};
            parameters[0].Value = model.guige_title;
            parameters[1].Value = model.guige_content;
            parameters[2].Value = model.guige_sort;
            parameters[3].Value = model.guige_add_date;
            parameters[4].Value = model.guige_web;

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
        public bool Update(Tea.Model.guige model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "guige set ");
            strSql.Append("guige_title=@guige_title,");
            strSql.Append("guige_content=@guige_content,");
            strSql.Append("guige_sort=@guige_sort,");
            strSql.Append("guige_add_date=@guige_add_date,");
            strSql.Append("guige_web=@guige_web");
            strSql.Append(" where guige_id=@guige_id");
            SqlParameter[] parameters = {
					new SqlParameter("@guige_title", SqlDbType.NVarChar,128),
					new SqlParameter("@guige_content", SqlDbType.NVarChar,1024),
					new SqlParameter("@guige_sort", SqlDbType.Int,4),
					new SqlParameter("@guige_add_date", SqlDbType.DateTime),
					new SqlParameter("@guige_web", SqlDbType.Int,4),
					new SqlParameter("@guige_id", SqlDbType.Int,4)};
            parameters[0].Value = model.guige_title;
            parameters[1].Value = model.guige_content;
            parameters[2].Value = model.guige_sort;
            parameters[3].Value = model.guige_add_date;
            parameters[4].Value = model.guige_web;
            parameters[5].Value = model.guige_id;

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
        public bool Delete(int guige_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "guige ");
            strSql.Append(" where guige_id=@guige_id");
            SqlParameter[] parameters = {
					new SqlParameter("@guige_id", SqlDbType.Int,4)
			};
            parameters[0].Value = guige_id;

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
        public bool DeleteList(string guige_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "guige ");
            strSql.Append(" where guige_id in (" + guige_idlist + ")  ");
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
        public Tea.Model.guige GetModel(int guige_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 guige_id,guige_title,guige_content,guige_sort,guige_add_date,guige_web from " + databaseprefix + "guige ");
            strSql.Append(" where guige_id=@guige_id");
            SqlParameter[] parameters = {
					new SqlParameter("@guige_id", SqlDbType.Int,4)
			};
            parameters[0].Value = guige_id;

            Tea.Model.guige model = new Tea.Model.guige();
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
        public Tea.Model.guige DataRowToModel(DataRow row)
        {
            Tea.Model.guige model = new Tea.Model.guige();
            if (row != null)
            {
                if (row["guige_id"] != null && row["guige_id"].ToString() != "")
                {
                    model.guige_id = int.Parse(row["guige_id"].ToString());
                }
                if (row["guige_title"] != null)
                {
                    model.guige_title = row["guige_title"].ToString();
                }
                if (row["guige_content"] != null)
                {
                    model.guige_content = row["guige_content"].ToString();
                }
                if (row["guige_sort"] != null && row["guige_sort"].ToString() != "")
                {
                    model.guige_sort = int.Parse(row["guige_sort"].ToString());
                }
                if (row["guige_add_date"] != null && row["guige_add_date"].ToString() != "")
                {
                    model.guige_add_date = DateTime.Parse(row["guige_add_date"].ToString());
                }
                if (row["guige_web"] != null && row["guige_web"].ToString() != "")
                {
                    model.guige_web = int.Parse(row["guige_web"].ToString());
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
            strSql.Append("select guige_id,guige_title,guige_content,guige_sort,guige_add_date,guige_web ");
            strSql.Append(" FROM " + databaseprefix + "guige ");
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
            strSql.Append(" guige_id,guige_title,guige_content,guige_sort,guige_add_date,guige_web ");
            strSql.Append(" FROM " + databaseprefix + "guige ");
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
            strSql.Append("select count(1) FROM " + databaseprefix + "guige ");
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
                strSql.Append("order by T.guige_id desc");
            }
            strSql.Append(")AS Row, T.*  from " + databaseprefix + "guige T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "guige");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}