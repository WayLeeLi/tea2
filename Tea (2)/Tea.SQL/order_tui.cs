
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:order_tui
    /// </summary>
    public partial class order_tui
    {
        private string databaseprefix; //数据库表名前缀
        public order_tui(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("tui_id", "" + databaseprefix + "order_tui");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int tui_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "order_tui");
            strSql.Append(" where tui_id=@tui_id");
            SqlParameter[] parameters = {
					new SqlParameter("@tui_id", SqlDbType.Int,4)
			};
            parameters[0].Value = tui_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tea.Model.order_tui model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "order_tui(");
            strSql.Append("tui_id,tui_order,tui_shop,tui_user,tui_state,tui_add_date,tui_type,tui_pic,tui_begin_date,tui_end_date,tui_content,tui_else,tui_admin,tui_name,tui_cart,tui_username,tui_lock,tui_revert,company)");
            strSql.Append(" values (");
            strSql.Append("@tui_id,@tui_order,@tui_shop,@tui_user,@tui_state,@tui_add_date,@tui_type,@tui_pic,@tui_begin_date,@tui_end_date,@tui_content,@tui_else,@tui_admin,@tui_name,@tui_cart,@tui_username,@tui_lock,@tui_revert,@company)");
            SqlParameter[] parameters = {
                    new SqlParameter("@tui_id", SqlDbType.Int,4),
					new SqlParameter("@tui_order", SqlDbType.Int,4),
					new SqlParameter("@tui_shop", SqlDbType.Int,4),
					new SqlParameter("@tui_user", SqlDbType.Int,4),
					new SqlParameter("@tui_state", SqlDbType.Int,4),
					new SqlParameter("@tui_add_date", SqlDbType.DateTime),
					new SqlParameter("@tui_type", SqlDbType.Int,4),
					new SqlParameter("@tui_pic", SqlDbType.NVarChar,128),
					new SqlParameter("@tui_begin_date", SqlDbType.DateTime),
					new SqlParameter("@tui_end_date", SqlDbType.DateTime),
					new SqlParameter("@tui_content", SqlDbType.NText),
					new SqlParameter("@tui_else", SqlDbType.NVarChar,512),
					new SqlParameter("@tui_admin", SqlDbType.Int,4),
					new SqlParameter("@tui_name", SqlDbType.NVarChar,64),
					new SqlParameter("@tui_cart", SqlDbType.Int,4),
					new SqlParameter("@tui_username", SqlDbType.NVarChar,64),
					new SqlParameter("@tui_lock", SqlDbType.Int,4),
					new SqlParameter("@tui_revert", SqlDbType.NText),
                    new SqlParameter("@company", SqlDbType.Int,4)};
            parameters[0].Value = model.tui_id;
            parameters[1].Value = model.tui_order;
            parameters[2].Value = model.tui_shop;
            parameters[3].Value = model.tui_user;
            parameters[4].Value = model.tui_state;
            parameters[5].Value = model.tui_add_date;
            parameters[6].Value = model.tui_type;
            parameters[7].Value = model.tui_pic;
            parameters[8].Value = model.tui_begin_date;
            parameters[9].Value = model.tui_end_date;
            parameters[10].Value = model.tui_content;
            parameters[11].Value = model.tui_else;
            parameters[12].Value = model.tui_admin;
            parameters[13].Value = model.tui_name;
            parameters[14].Value = model.tui_cart;
            parameters[15].Value = model.tui_username;
            parameters[16].Value = model.tui_lock;
            parameters[17].Value = model.tui_revert;
            parameters[18].Value = model.company;
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
        public bool Update(Tea.Model.order_tui model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "order_tui set ");
            strSql.Append("tui_order=@tui_order,");
            strSql.Append("tui_shop=@tui_shop,");
            strSql.Append("tui_user=@tui_user,");
            strSql.Append("tui_state=@tui_state,");
            strSql.Append("tui_add_date=@tui_add_date,");
            strSql.Append("tui_type=@tui_type,");
            strSql.Append("tui_pic=@tui_pic,");
            strSql.Append("tui_begin_date=@tui_begin_date,");
            strSql.Append("tui_end_date=@tui_end_date,");
            strSql.Append("tui_content=@tui_content,");
            strSql.Append("tui_else=@tui_else,");
            strSql.Append("tui_admin=@tui_admin,");
            strSql.Append("tui_name=@tui_name,");
            strSql.Append("tui_cart=@tui_cart,");
            strSql.Append("tui_username=@tui_username,");
            strSql.Append("tui_lock=@tui_lock,");
            strSql.Append("tui_revert=@tui_revert");
            strSql.Append(" where tui_id=@tui_id");
            SqlParameter[] parameters = {
					new SqlParameter("@tui_order", SqlDbType.Int,4),
					new SqlParameter("@tui_shop", SqlDbType.Int,4),
					new SqlParameter("@tui_user", SqlDbType.Int,4),
					new SqlParameter("@tui_state", SqlDbType.Int,4),
					new SqlParameter("@tui_add_date", SqlDbType.DateTime),
					new SqlParameter("@tui_type", SqlDbType.Int,4),
					new SqlParameter("@tui_pic", SqlDbType.NVarChar,128),
					new SqlParameter("@tui_begin_date", SqlDbType.DateTime),
					new SqlParameter("@tui_end_date", SqlDbType.DateTime),
					new SqlParameter("@tui_content", SqlDbType.NText),
					new SqlParameter("@tui_else", SqlDbType.NVarChar,512),
					new SqlParameter("@tui_admin", SqlDbType.Int,4),
					new SqlParameter("@tui_name", SqlDbType.NVarChar,64),
					new SqlParameter("@tui_cart", SqlDbType.Int,4),
					new SqlParameter("@tui_username", SqlDbType.NVarChar,64),
					new SqlParameter("@tui_lock", SqlDbType.Int,4),
					new SqlParameter("@tui_revert", SqlDbType.NText),
					new SqlParameter("@tui_id", SqlDbType.Int,4)};
            parameters[0].Value = model.tui_order;
            parameters[1].Value = model.tui_shop;
            parameters[2].Value = model.tui_user;
            parameters[3].Value = model.tui_state;
            parameters[4].Value = model.tui_add_date;
            parameters[5].Value = model.tui_type;
            parameters[6].Value = model.tui_pic;
            parameters[7].Value = model.tui_begin_date;
            parameters[8].Value = model.tui_end_date;
            parameters[9].Value = model.tui_content;
            parameters[10].Value = model.tui_else;
            parameters[11].Value = model.tui_admin;
            parameters[12].Value = model.tui_name;
            parameters[13].Value = model.tui_cart;
            parameters[14].Value = model.tui_username;
            parameters[15].Value = model.tui_lock;
            parameters[16].Value = model.tui_revert;
            parameters[17].Value = model.tui_id;

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
        public bool Delete(int tui_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "order_tui ");
            strSql.Append(" where tui_id=@tui_id");
            SqlParameter[] parameters = {
					new SqlParameter("@tui_id", SqlDbType.Int,4)
			};
            parameters[0].Value = tui_id;

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
        public bool DeleteList(string tui_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "order_tui ");
            strSql.Append(" where tui_id in (" + tui_idlist + ")  ");
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
        public Tea.Model.order_tui GetModel(int tui_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 tui_id,tui_order,tui_shop,tui_user,tui_state,tui_add_date,tui_type,tui_pic,tui_begin_date,tui_end_date,tui_content,tui_else,tui_admin,tui_name,tui_cart,tui_username,tui_lock,tui_revert from " + databaseprefix + "order_tui ");
            strSql.Append(" where tui_id=@tui_id");
            SqlParameter[] parameters = {
					new SqlParameter("@tui_id", SqlDbType.Int,4)
			};
            parameters[0].Value = tui_id;

            Tea.Model.order_tui model = new Tea.Model.order_tui();
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

        public Tea.Model.order_tui GetModelTui(int order_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 tui_id,tui_order,tui_shop,tui_user,tui_state,tui_add_date,tui_type,tui_pic,tui_begin_date,tui_end_date,tui_content,tui_else,tui_admin,tui_name,tui_cart,tui_username,tui_lock,tui_revert from " + databaseprefix + "order_tui ");
            strSql.Append(" where tui_order=@tui_order");
            SqlParameter[] parameters = {
					new SqlParameter("@tui_order", SqlDbType.Int,4)
			};
            parameters[0].Value = order_id;

            Tea.Model.order_tui model = new Tea.Model.order_tui();
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
        public Tea.Model.order_tui DataRowToModel(DataRow row)
        {
            Tea.Model.order_tui model = new Tea.Model.order_tui();
            if (row != null)
            {
                if (row["tui_id"] != null && row["tui_id"].ToString() != "")
                {
                    model.tui_id = int.Parse(row["tui_id"].ToString());
                }
                if (row["tui_order"] != null && row["tui_order"].ToString() != "")
                {
                    model.tui_order = int.Parse(row["tui_order"].ToString());
                }
                if (row["tui_shop"] != null && row["tui_shop"].ToString() != "")
                {
                    model.tui_shop = int.Parse(row["tui_shop"].ToString());
                }
                if (row["tui_user"] != null && row["tui_user"].ToString() != "")
                {
                    model.tui_user = int.Parse(row["tui_user"].ToString());
                }
                if (row["tui_state"] != null && row["tui_state"].ToString() != "")
                {
                    model.tui_state = int.Parse(row["tui_state"].ToString());
                }
                if (row["tui_add_date"] != null && row["tui_add_date"].ToString() != "")
                {
                    model.tui_add_date = DateTime.Parse(row["tui_add_date"].ToString());
                }
                if (row["tui_type"] != null && row["tui_type"].ToString() != "")
                {
                    model.tui_type = int.Parse(row["tui_type"].ToString());
                }
                if (row["tui_pic"] != null)
                {
                    model.tui_pic = row["tui_pic"].ToString();
                }
                if (row["tui_begin_date"] != null && row["tui_begin_date"].ToString() != "")
                {
                    model.tui_begin_date = DateTime.Parse(row["tui_begin_date"].ToString());
                }
                if (row["tui_end_date"] != null && row["tui_end_date"].ToString() != "")
                {
                    model.tui_end_date = DateTime.Parse(row["tui_end_date"].ToString());
                }
                if (row["tui_content"] != null)
                {
                    model.tui_content = row["tui_content"].ToString();
                }
                if (row["tui_else"] != null)
                {
                    model.tui_else = row["tui_else"].ToString();
                }
                if (row["tui_admin"] != null && row["tui_admin"].ToString() != "")
                {
                    model.tui_admin = int.Parse(row["tui_admin"].ToString());
                }
                if (row["tui_name"] != null)
                {
                    model.tui_name = row["tui_name"].ToString();
                }
                if (row["tui_cart"] != null && row["tui_cart"].ToString() != "")
                {
                    model.tui_cart = int.Parse(row["tui_cart"].ToString());
                }
                if (row["tui_username"] != null)
                {
                    model.tui_username = row["tui_username"].ToString();
                }
                if (row["tui_lock"] != null && row["tui_lock"].ToString() != "")
                {
                    model.tui_lock = int.Parse(row["tui_lock"].ToString());
                }
                if (row["tui_revert"] != null)
                {
                    model.tui_revert = row["tui_revert"].ToString();
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
            strSql.Append("select tui_id,tui_order,tui_shop,tui_user,tui_state,tui_add_date,tui_type,tui_pic,tui_begin_date,tui_end_date,tui_content,tui_else,tui_admin,tui_name,tui_cart,tui_username,tui_lock,tui_revert ");
            strSql.Append(" FROM " + databaseprefix + "order_tui ");
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
            strSql.Append(" tui_id,tui_order,tui_shop,tui_user,tui_state,tui_add_date,tui_type,tui_pic,tui_begin_date,tui_end_date,tui_content,tui_else,tui_admin,tui_name,tui_cart,tui_username,tui_lock,tui_revert ");
            strSql.Append(" FROM " + databaseprefix + "order_tui ");
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
            strSql.Append("select count(1) FROM " + databaseprefix + "order_tui ");
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
                strSql.Append("order by T.tui_id desc");
            }
            strSql.Append(")AS Row, T.*  from " + databaseprefix + "order_tui T ");
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

