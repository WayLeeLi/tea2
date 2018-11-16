using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
using Tea.Common;

namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:門市資訊
    /// </summary>
    public partial class store
    {
        private string databaseprefix; //数据库表名前缀
        public store(string _databaseprefix)
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
            strSql.Append("select count(1) from " + databaseprefix + "store");
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
            strSql.Append("select top 1 title from " + databaseprefix + "store");
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
        public int Add(Model.store model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "store(");
            strSql.Append("title,area_id,brand_id,address,tel,flagship,coordinate)");
            strSql.Append(" values (");
            strSql.Append("@title,@area_id,@brand_id,@address,@tel,@flagship,@coordinate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@area_id", SqlDbType.Int,4),
					new SqlParameter("@brand_id", SqlDbType.NVarChar,100),
                    new SqlParameter("@address",SqlDbType.NVarChar,200),
					new SqlParameter("@tel", SqlDbType.NVarChar,30),
					new SqlParameter("@flagship", SqlDbType.TinyInt,1),
					new SqlParameter("@coordinate", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.area_id;
            parameters[2].Value = model.brand_id;
            parameters[3].Value = model.address;
            parameters[4].Value = model.tel;
            parameters[5].Value = model.flagship;
            parameters[6].Value = model.coordinate;

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
            strSql.Append("update " + databaseprefix + "store set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.store model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "store set ");
            strSql.Append("title=@title,");
            strSql.Append("area_id=@area_id,");
            strSql.Append("brand_id=@brand_id,");
            strSql.Append("address=@address,");
            strSql.Append("tel=@tel,");
            strSql.Append("flagship=@flagship,");
            strSql.Append("coordinate=@coordinate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@area_id", SqlDbType.Int,4),
					new SqlParameter("@brand_id", SqlDbType.NVarChar,100),
                    new SqlParameter("@address",SqlDbType.NVarChar,200),
					new SqlParameter("@tel", SqlDbType.NVarChar,30),
					new SqlParameter("@flagship", SqlDbType.TinyInt,1),
					new SqlParameter("@coordinate", SqlDbType.NVarChar,50),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            
            parameters[0].Value = model.title;
            parameters[1].Value = model.area_id;
            parameters[2].Value = model.brand_id;
            parameters[3].Value = model.address;
            parameters[4].Value = model.tel;
            parameters[5].Value = model.flagship;
            parameters[6].Value = model.coordinate;
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
            strSql.Append("delete from " + databaseprefix + "store ");
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
        public Model.store GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,area_id,brand_id,address,tel,flagship,coordinate from " + databaseprefix + "store ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.store model = new Model.store();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                if (ds.Tables[0].Rows[0]["area_id"].ToString() != "")
                {
                    model.area_id = int.Parse(ds.Tables[0].Rows[0]["area_id"].ToString());
                }
                model.brand_id = ds.Tables[0].Rows[0]["brand_id"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                if (ds.Tables[0].Rows[0]["flagship"].ToString() != "")
                {
                    model.flagship = int.Parse(ds.Tables[0].Rows[0]["flagship"].ToString());
                }
                model.coordinate = ds.Tables[0].Rows[0]["coordinate"].ToString();
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
            strSql.Append("select id,title,area_id,brand_id,address,tel,flagship,coordinate ");
            strSql.Append(" FROM " + databaseprefix + "store ");
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
            strSql.Append(" id,title,area_id,brand_id,address,tel,flagship,coordinate ");
            strSql.Append(" FROM " + databaseprefix + "store ");
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
            strSql.Append("select * FROM " + databaseprefix + "store");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method
    }
}