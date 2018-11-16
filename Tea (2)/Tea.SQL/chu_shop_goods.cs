using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
using Tea.Common;
namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:chu_shop_goods
    /// </summary>
    public partial class chu_shop_goods
    {
        private string databaseprefix; //数据库表名前缀
        public chu_shop_goods(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region 基本方法============================
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("chu_id", databaseprefix + "chu_shop_goods");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int chu_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "chu_shop_goods");
            strSql.Append(" where chu_id=@chu_id");
            SqlParameter[] parameters = {
					new SqlParameter("@chu_id", SqlDbType.Int,4)
			};
            parameters[0].Value = chu_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tea.Model.chu_shop_goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "chu_shop_goods(");
            strSql.Append("chu_shop,chu_goods,chu_add_date,chu_begin_date,chu_end_date,chu_where,chu_status,chu_type,chu_typeid,chu_title,chu_sort)");
            strSql.Append(" values (");
            strSql.Append("@chu_shop,@chu_goods,@chu_add_date,@chu_begin_date,@chu_end_date,@chu_where,@chu_status,@chu_type,@chu_typeid,@chu_title,@chu_sort)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@chu_shop", SqlDbType.Int,4),
					new SqlParameter("@chu_goods", SqlDbType.Int,4),
					new SqlParameter("@chu_add_date", SqlDbType.DateTime),
					new SqlParameter("@chu_begin_date", SqlDbType.DateTime),
					new SqlParameter("@chu_end_date", SqlDbType.DateTime),
					new SqlParameter("@chu_where", SqlDbType.NVarChar,32),
					new SqlParameter("@chu_status", SqlDbType.Int,4),
					new SqlParameter("@chu_type", SqlDbType.NVarChar,64),
					new SqlParameter("@chu_typeid", SqlDbType.Int,4),
					new SqlParameter("@chu_title", SqlDbType.NVarChar,256),
					new SqlParameter("@chu_sort", SqlDbType.Int,4)};
            parameters[0].Value = model.chu_shop;
            parameters[1].Value = model.chu_goods;
            parameters[2].Value = model.chu_add_date;
            parameters[3].Value = model.chu_begin_date;
            parameters[4].Value = model.chu_end_date;
            parameters[5].Value = model.chu_where;
            parameters[6].Value = model.chu_status;
            parameters[7].Value = model.chu_type;
            parameters[8].Value = model.chu_typeid;
            parameters[9].Value = model.chu_title;
            parameters[10].Value = model.chu_sort;

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
        public bool Update(Tea.Model.chu_shop_goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "chu_shop_goods set ");
            strSql.Append("chu_shop=@chu_shop,");
            strSql.Append("chu_goods=@chu_goods,");
            strSql.Append("chu_add_date=@chu_add_date,");
            strSql.Append("chu_begin_date=@chu_begin_date,");
            strSql.Append("chu_end_date=@chu_end_date,");
            strSql.Append("chu_where=@chu_where,");
            strSql.Append("chu_status=@chu_status,");
            strSql.Append("chu_type=@chu_type,");
            strSql.Append("chu_typeid=@chu_typeid,");
            strSql.Append("chu_title=@chu_title,");
            strSql.Append("chu_sort=@chu_sort");
            strSql.Append(" where chu_id=@chu_id");
            SqlParameter[] parameters = {
					new SqlParameter("@chu_shop", SqlDbType.Int,4),
					new SqlParameter("@chu_goods", SqlDbType.Int,4),
					new SqlParameter("@chu_add_date", SqlDbType.DateTime),
					new SqlParameter("@chu_begin_date", SqlDbType.DateTime),
					new SqlParameter("@chu_end_date", SqlDbType.DateTime),
					new SqlParameter("@chu_where", SqlDbType.NVarChar,32),
					new SqlParameter("@chu_status", SqlDbType.Int,4),
					new SqlParameter("@chu_type", SqlDbType.NVarChar,64),
					new SqlParameter("@chu_typeid", SqlDbType.Int,4),
					new SqlParameter("@chu_title", SqlDbType.NVarChar,256),
					new SqlParameter("@chu_sort", SqlDbType.Int,4),
					new SqlParameter("@chu_id", SqlDbType.Int,4)};
            parameters[0].Value = model.chu_shop;
            parameters[1].Value = model.chu_goods;
            parameters[2].Value = model.chu_add_date;
            parameters[3].Value = model.chu_begin_date;
            parameters[4].Value = model.chu_end_date;
            parameters[5].Value = model.chu_where;
            parameters[6].Value = model.chu_status;
            parameters[7].Value = model.chu_type;
            parameters[8].Value = model.chu_typeid;
            parameters[9].Value = model.chu_title;
            parameters[10].Value = model.chu_sort;
            parameters[11].Value = model.chu_id;

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
        public bool Delete(int chu_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "chu_shop_goods ");
            strSql.Append(" where chu_id=@chu_id");
            SqlParameter[] parameters = {
					new SqlParameter("@chu_id", SqlDbType.Int,4)
			};
            parameters[0].Value = chu_id;

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
        public bool DeleteList(string chu_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "chu_shop_goods ");
            strSql.Append(" where chu_id in (" + chu_idlist + ")  ");
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
        public Tea.Model.chu_shop_goods GetModel(int chu_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 chu_id,chu_shop,chu_goods,chu_add_date,chu_begin_date,chu_end_date,chu_where,chu_status,chu_type,chu_typeid,chu_title,chu_sort from " + databaseprefix + "chu_shop_goods ");
            strSql.Append(" where chu_id=@chu_id");
            SqlParameter[] parameters = {
					new SqlParameter("@chu_id", SqlDbType.Int,4)
			};
            parameters[0].Value = chu_id;

            Tea.Model.chu_shop_goods model = new Tea.Model.chu_shop_goods();
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
        public Tea.Model.chu_shop_goods DataRowToModel(DataRow row)
        {
            Tea.Model.chu_shop_goods model = new Tea.Model.chu_shop_goods();
            if (row != null)
            {
                if (row["chu_id"] != null && row["chu_id"].ToString() != "")
                {
                    model.chu_id = int.Parse(row["chu_id"].ToString());
                }
                if (row["chu_shop"] != null && row["chu_shop"].ToString() != "")
                {
                    model.chu_shop = int.Parse(row["chu_shop"].ToString());
                }
                if (row["chu_goods"] != null && row["chu_goods"].ToString() != "")
                {
                    model.chu_goods = int.Parse(row["chu_goods"].ToString());
                }
                if (row["chu_add_date"] != null && row["chu_add_date"].ToString() != "")
                {
                    model.chu_add_date = DateTime.Parse(row["chu_add_date"].ToString());
                }
                if (row["chu_begin_date"] != null && row["chu_begin_date"].ToString() != "")
                {
                    model.chu_begin_date = DateTime.Parse(row["chu_begin_date"].ToString());
                }
                if (row["chu_end_date"] != null && row["chu_end_date"].ToString() != "")
                {
                    model.chu_end_date = DateTime.Parse(row["chu_end_date"].ToString());
                }
                if (row["chu_where"] != null)
                {
                    model.chu_where = row["chu_where"].ToString();
                }
                if (row["chu_status"] != null && row["chu_status"].ToString() != "")
                {
                    model.chu_status = int.Parse(row["chu_status"].ToString());
                }
                if (row["chu_type"] != null)
                {
                    model.chu_type = row["chu_type"].ToString();
                }
                if (row["chu_typeid"] != null && row["chu_typeid"].ToString() != "")
                {
                    model.chu_typeid = int.Parse(row["chu_typeid"].ToString());
                }
                if (row["chu_title"] != null)
                {
                    model.chu_title = row["chu_title"].ToString();
                }
                if (row["chu_sort"] != null && row["chu_sort"].ToString() != "")
                {
                    model.chu_sort = int.Parse(row["chu_sort"].ToString());
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
            strSql.Append("select chu_id,chu_shop,chu_goods,chu_add_date,chu_begin_date,chu_end_date,chu_where,chu_status,chu_type,chu_typeid,chu_title,chu_sort ");
            strSql.Append(" FROM " + databaseprefix + "chu_shop_goods ");
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
            strSql.Append(" chu_id,chu_shop,chu_goods,chu_add_date,chu_begin_date,chu_end_date,chu_where,chu_status,chu_type,chu_typeid,chu_title,chu_sort ");
            strSql.Append(" FROM " + databaseprefix + "chu_shop_goods ");
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
            strSql.Append("select count(1) FROM " + databaseprefix + "chu_shop_goods ");
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
                strSql.Append("order by T.chu_id desc");
            }
            strSql.Append(")AS Row, T.*  from " + databaseprefix + "chu_shop_goods T ");
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
            strSql.Append("select * FROM " + databaseprefix + "chu_shop_goods");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion
    }
}

