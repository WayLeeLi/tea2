using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
using Tea.Common;
namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:guige_list
    /// </summary>
    public partial class guige_list
    {
        private string databaseprefix; //数据库表名前缀
        public guige_list(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "guige_list set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("list_id", "" + databaseprefix + "guige_list");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int list_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "guige_list");
            strSql.Append(" where list_id=@list_id");
            SqlParameter[] parameters = {
					new SqlParameter("@list_id", SqlDbType.Int,4)
			};
            parameters[0].Value = list_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tea.Model.guige_list model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "guige_list(");
            strSql.Append("list_guige,list_title,list_pic,list_sort,list_web,list_content,list_add_date)");
            strSql.Append(" values (");
            strSql.Append("@list_guige,@list_title,@list_pic,@list_sort,@list_web,@list_content,@list_add_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@list_guige", SqlDbType.Int,4),
					new SqlParameter("@list_title", SqlDbType.NVarChar,128),
					new SqlParameter("@list_pic", SqlDbType.NVarChar,128),
					new SqlParameter("@list_sort", SqlDbType.Int,4),
					new SqlParameter("@list_web", SqlDbType.Int,4),
					new SqlParameter("@list_content", SqlDbType.NVarChar,1024),
					new SqlParameter("@list_add_date", SqlDbType.DateTime)};
            parameters[0].Value = model.list_guige;
            parameters[1].Value = model.list_title;
            parameters[2].Value = model.list_pic;
            parameters[3].Value = model.list_sort;
            parameters[4].Value = model.list_web;
            parameters[5].Value = model.list_content;
            parameters[6].Value = model.list_add_date;

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
        public bool Update(Tea.Model.guige_list model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "guige_list set ");
            strSql.Append("list_guige=@list_guige,");
            strSql.Append("list_title=@list_title,");
            strSql.Append("list_pic=@list_pic,");
            strSql.Append("list_sort=@list_sort,");
            strSql.Append("list_web=@list_web,");
            strSql.Append("list_content=@list_content,");
            strSql.Append("list_add_date=@list_add_date");
            strSql.Append(" where list_id=@list_id");
            SqlParameter[] parameters = {
					new SqlParameter("@list_guige", SqlDbType.Int,4),
					new SqlParameter("@list_title", SqlDbType.NVarChar,128),
					new SqlParameter("@list_pic", SqlDbType.NVarChar,128),
					new SqlParameter("@list_sort", SqlDbType.Int,4),
					new SqlParameter("@list_web", SqlDbType.Int,4),
					new SqlParameter("@list_content", SqlDbType.NVarChar,1024),
					new SqlParameter("@list_add_date", SqlDbType.DateTime),
					new SqlParameter("@list_id", SqlDbType.Int,4)};
            parameters[0].Value = model.list_guige;
            parameters[1].Value = model.list_title;
            parameters[2].Value = model.list_pic;
            parameters[3].Value = model.list_sort;
            parameters[4].Value = model.list_web;
            parameters[5].Value = model.list_content;
            parameters[6].Value = model.list_add_date;
            parameters[7].Value = model.list_id;

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
        public bool Delete(int list_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "guige_list ");
            strSql.Append(" where list_id=@list_id");
            SqlParameter[] parameters = {
					new SqlParameter("@list_id", SqlDbType.Int,4)
			};
            parameters[0].Value = list_id;

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
        public bool DeleteList(string list_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "guige_list ");
            strSql.Append(" where list_id in (" + list_idlist + ")  ");
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
        public Tea.Model.guige_list GetModel(int list_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 list_id,list_guige,list_title,list_pic,list_sort,list_web,list_content,list_add_date from " + databaseprefix + "guige_list ");
            strSql.Append(" where list_id=@list_id");
            SqlParameter[] parameters = {
					new SqlParameter("@list_id", SqlDbType.Int,4)
			};
            parameters[0].Value = list_id;

            Tea.Model.guige_list model = new Tea.Model.guige_list();
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
        public Tea.Model.guige_list DataRowToModel(DataRow row)
        {
            Tea.Model.guige_list model = new Tea.Model.guige_list();
            if (row != null)
            {
                if (row["list_id"] != null && row["list_id"].ToString() != "")
                {
                    model.list_id = int.Parse(row["list_id"].ToString());
                }
                if (row["list_guige"] != null && row["list_guige"].ToString() != "")
                {
                    model.list_guige = int.Parse(row["list_guige"].ToString());
                }
                if (row["list_title"] != null)
                {
                    model.list_title = row["list_title"].ToString();
                }
                if (row["list_pic"] != null)
                {
                    model.list_pic = row["list_pic"].ToString();
                }
                if (row["list_sort"] != null && row["list_sort"].ToString() != "")
                {
                    model.list_sort = int.Parse(row["list_sort"].ToString());
                }
                if (row["list_web"] != null && row["list_web"].ToString() != "")
                {
                    model.list_web = int.Parse(row["list_web"].ToString());
                }
                if (row["list_content"] != null)
                {
                    model.list_content = row["list_content"].ToString();
                }
                if (row["list_add_date"] != null && row["list_add_date"].ToString() != "")
                {
                    model.list_add_date = DateTime.Parse(row["list_add_date"].ToString());
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
            strSql.Append("select list_id,list_guige,list_title,list_pic,list_sort,list_web,list_content,list_add_date ");
            strSql.Append(" FROM " + databaseprefix + "guige_list ");
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
            strSql.Append(" list_id,list_guige,list_title,list_pic,list_sort,list_web,list_content,list_add_date ");
            strSql.Append(" FROM " + databaseprefix + "guige_list ");
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
            strSql.Append("select count(1) FROM " + databaseprefix + "guige_list ");
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
                strSql.Append("order by T.list_id desc");
            }
            strSql.Append(")AS Row, T.*  from " + databaseprefix + "guige_list T ");
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
            strSql.Append("select * FROM " + databaseprefix + "tags");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}