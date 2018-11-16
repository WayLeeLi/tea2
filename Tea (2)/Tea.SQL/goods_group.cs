using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
using Tea.Common;

namespace Tea.DAL
{
	/// <summary>
	/// 商品组合
	/// </summary>
	public partial class goods_group
	{
        private string databaseprefix; //数据库表名前缀
        public goods_group(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tea.Model.goods_group model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "goods_group(");
            strSql.Append("main_id,parent_id,goods_id,title,color,size,original_price,new_price,company)");
            strSql.Append(" values (");
            strSql.Append("@main_id,@parent_id,@goods_id,@title,@color,@size,@original_price,@new_price,@company)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@main_id", SqlDbType.Int,4),
					new SqlParameter("@parent_id", SqlDbType.Int,4),
					new SqlParameter("@goods_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@color", SqlDbType.NVarChar,20),
					new SqlParameter("@size", SqlDbType.NVarChar,20),
					new SqlParameter("@original_price", SqlDbType.Decimal,5),
					new SqlParameter("@new_price", SqlDbType.Decimal,5),
					new SqlParameter("@company", SqlDbType.Int,4)};
            parameters[0].Value = model.main_id;
            parameters[1].Value = model.parent_id;
            parameters[2].Value = model.goods_id;
            parameters[3].Value = model.title;
            parameters[4].Value = model.color;
            parameters[5].Value = model.size;
            parameters[6].Value = model.original_price;
            parameters[7].Value = model.new_price;
            parameters[8].Value = model.company;

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
        public bool Update(Tea.Model.goods_group model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "goods_group set ");
            strSql.Append("main_id=@main_id,");
            strSql.Append("parent_id=@parent_id,");
            strSql.Append("goods_id=@goods_id,");
            strSql.Append("title=@title,");
            strSql.Append("color=@color,");
            strSql.Append("size=@size,");
            strSql.Append("original_price=@original_price,");
            strSql.Append("new_price=@new_price,");
            strSql.Append("company=@company");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@main_id", SqlDbType.Int,4),
					new SqlParameter("@parent_id", SqlDbType.Int,4),
					new SqlParameter("@goods_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@color", SqlDbType.NVarChar,20),
					new SqlParameter("@size", SqlDbType.NVarChar,20),
					new SqlParameter("@original_price", SqlDbType.Decimal,5),
					new SqlParameter("@new_price", SqlDbType.Decimal,5),
					new SqlParameter("@company", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.main_id;
            parameters[1].Value = model.parent_id;
            parameters[2].Value = model.goods_id;
            parameters[3].Value = model.title;
            parameters[4].Value = model.color;
            parameters[5].Value = model.size;
            parameters[6].Value = model.original_price;
            parameters[7].Value = model.new_price;
            parameters[8].Value = model.company;
            parameters[9].Value = model.id;

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
            strSql.Append("delete from " + databaseprefix + "goods_group ");
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
        /// 得到一个对象实体
        /// </summary>
        public Tea.Model.goods_group GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,main_id,parent_id,goods_id,title,color,size,original_price,new_price,company from " + databaseprefix + "goods_group ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Tea.Model.goods_group model = new Tea.Model.goods_group();
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
        public Tea.Model.goods_group DataRowToModel(DataRow row)
        {
            Tea.Model.goods_group model = new Tea.Model.goods_group();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["main_id"] != null && row["main_id"].ToString() != "")
                {
                    model.main_id = int.Parse(row["main_id"].ToString());
                }
                if (row["parent_id"] != null && row["parent_id"].ToString() != "")
                {
                    model.parent_id = int.Parse(row["parent_id"].ToString());
                }
                if (row["goods_id"] != null && row["goods_id"].ToString() != "")
                {
                    model.goods_id = int.Parse(row["goods_id"].ToString());
                }
                if (row["title"] != null)
                {
                    model.title = row["title"].ToString();
                }
                if (row["color"] != null)
                {
                    model.color = row["color"].ToString();
                }
                if (row["size"] != null)
                {
                    model.size = row["size"].ToString();
                }
                if (row["original_price"] != null && row["original_price"].ToString() != "")
                {
                    model.original_price = decimal.Parse(row["original_price"].ToString());
                }
                if (row["new_price"] != null && row["new_price"].ToString() != "")
                {
                    model.new_price = decimal.Parse(row["new_price"].ToString());
                }
                if (row["company"] != null && row["company"].ToString() != "")
                {
                    model.company = int.Parse(row["company"].ToString());
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
            strSql.Append("select id,main_id,parent_id,goods_id,title,color,size,original_price,new_price ");
            strSql.Append(" FROM " + databaseprefix + "goods_group ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by id desc");
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
            strSql.Append(" id,main_id,parent_id,goods_id,title,color,size,original_price,new_price ");
            strSql.Append(" FROM " + databaseprefix + "goods_group ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.goods_group> GetList(int article_id)
        {
            List<Model.goods_group> modelList = new List<Model.goods_group>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,main_id,parent_id,goods_id,title,color,size,original_price,new_price ");
            strSql.Append(" FROM " + databaseprefix + "goods_group ");
            strSql.Append(" where main_id=" + article_id);
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.goods_group model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.goods_group();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["main_id"] != null && dt.Rows[n]["main_id"].ToString() != "")
                    {
                        model.main_id = int.Parse(dt.Rows[n]["main_id"].ToString());
                    }
                    if (dt.Rows[n]["parent_id"] != null && dt.Rows[n]["parent_id"].ToString() != "")
                    {
                        model.parent_id = int.Parse(dt.Rows[n]["parent_id"].ToString());
                    }
                    if (dt.Rows[n]["goods_id"] != null && dt.Rows[n]["goods_id"].ToString() != "")
                    {
                        model.goods_id = int.Parse(dt.Rows[n]["goods_id"].ToString());
                    }
                    model.title = dt.Rows[n]["title"].ToString();
                    model.color = dt.Rows[n]["color"].ToString();
                    model.size = dt.Rows[n]["size"].ToString();
                    if (dt.Rows[n]["original_price"] != null && dt.Rows[n]["original_price"].ToString() != "")
                    {
                        model.original_price = Decimal.Parse(dt.Rows[n]["original_price"].ToString());
                    }
                    if (dt.Rows[n]["new_price"] != null && dt.Rows[n]["new_price"].ToString() != "")
                    {
                        model.new_price = Decimal.Parse(dt.Rows[n]["new_price"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 查找不存在的组合并删除已删除的数据
        /// </summary>
        public void DeleteList(SqlConnection conn, SqlTransaction trans, List<Model.goods_group> models, int article_id)
        {
            StringBuilder idList = new StringBuilder();
            if (models != null)
            {
                foreach (Model.goods_group modelt in models)
                {
                    if (modelt.id > 0)
                    {
                        idList.Append(modelt.id + ",");
                    }
                }
            }
            string id_list = Utils.DelLastChar(idList.ToString(), ",");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "goods_group where main_id=" + article_id);
            if (!string.IsNullOrEmpty(id_list))
            {
                strSql.Append(" and id not in(" + id_list + ")");
            }
            DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString()); //删除数据库
        }

	}
}

