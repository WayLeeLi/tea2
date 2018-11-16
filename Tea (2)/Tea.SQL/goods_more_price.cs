using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:goods_more_price
    /// </summary>
    public partial class goods_more_price
    {
        private string databaseprefix; //数据库表名前缀
        public goods_more_price(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tea.Model.goods_more_price model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "goods_more_price(");
            strSql.Append("article_id,goods_id,goods_num,goods_lock,price,more_chu,more_title)");
            strSql.Append(" values (");
            strSql.Append("@article_id,@goods_id,@goods_num,@goods_lock,@price,@more_chu,@more_title)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@goods_id", SqlDbType.Int,4),
					new SqlParameter("@goods_num", SqlDbType.Int,4),
					new SqlParameter("@goods_lock", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Decimal,5),
					new SqlParameter("@more_chu", SqlDbType.Int,4),
                    new SqlParameter("@more_title", SqlDbType.NVarChar,128)};
            parameters[0].Value = model.article_id;
            parameters[1].Value = model.goods_id;
            parameters[2].Value = model.goods_num;
            parameters[3].Value = model.goods_lock;
            parameters[4].Value = model.price;
            parameters[5].Value = model.more_chu;
            parameters[6].Value = model.more_title;
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
        public bool Update(Tea.Model.goods_more_price model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "goods_more_price set ");
            strSql.Append("article_id=@article_id,");
            strSql.Append("goods_id=@goods_id,");
            strSql.Append("goods_num=@goods_num,");
            strSql.Append("goods_lock=@goods_lock,");
            strSql.Append("price=@price,");
            strSql.Append("more_chu=@more_chu,");
            strSql.Append("more_title=@more_title");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@article_id", SqlDbType.Int,4),
					new SqlParameter("@goods_id", SqlDbType.Int,4),
					new SqlParameter("@goods_num", SqlDbType.Int,4),
					new SqlParameter("@goods_lock", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Decimal,5),
					new SqlParameter("@more_chu", SqlDbType.Int,4),
                    new SqlParameter("@more_title", SqlDbType.NVarChar,128),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.article_id;
            parameters[1].Value = model.goods_id;
            parameters[2].Value = model.goods_num;
            parameters[3].Value = model.goods_lock;
            parameters[4].Value = model.price;
            parameters[5].Value = model.more_chu;
            parameters[6].Value = model.more_title;
            parameters[7].Value = model.id;

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
            strSql.Append("delete from " + databaseprefix + "goods_more_price ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "goods_more_price ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public Tea.Model.goods_more_price GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,article_id,goods_id,goods_num,goods_lock,price,more_chu,more_title from " + databaseprefix + "goods_more_price ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Tea.Model.goods_more_price model = new Tea.Model.goods_more_price();
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
        public Tea.Model.goods_more_price DataRowToModel(DataRow row)
        {
            Tea.Model.goods_more_price model = new Tea.Model.goods_more_price();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["article_id"] != null && row["article_id"].ToString() != "")
                {
                    model.article_id = int.Parse(row["article_id"].ToString());
                }
                if (row["goods_id"] != null && row["goods_id"].ToString() != "")
                {
                    model.goods_id = int.Parse(row["goods_id"].ToString());
                }
                if (row["goods_num"] != null && row["goods_num"].ToString() != "")
                {
                    model.goods_num = int.Parse(row["goods_num"].ToString());
                }
                if (row["goods_lock"] != null && row["goods_lock"].ToString() != "")
                {
                    model.goods_lock = int.Parse(row["goods_lock"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["more_chu"] != null && row["more_chu"].ToString() != "")
                {
                    model.more_chu = int.Parse(row["more_chu"].ToString());
                }
                if (row["more_title"] != null && row["more_title"].ToString() != "")
                {
                    model.more_title =row["more_title"].ToString();
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
            strSql.Append("select id,article_id,goods_id,goods_num,goods_lock,price,more_chu,more_title ");
            strSql.Append(" FROM " + databaseprefix + "goods_more_price ");
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
            strSql.Append(" id,article_id,goods_id,goods_num,goods_lock,price,more_chu,more_title ");
            strSql.Append(" FROM " + databaseprefix + "goods_more_price ");
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
            strSql.Append("select count(1) FROM " + databaseprefix + "goods_more_price ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from " + databaseprefix + "goods_more_price T ");
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

