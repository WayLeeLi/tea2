using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:quan
    /// </summary>
    public partial class quan
    {
        private string databaseprefix; //数据库表名前缀
        public quan(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("quan_id", databaseprefix + "quan");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int quan_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "quan");
            strSql.Append(" where quan_id=@quan_id");
            SqlParameter[] parameters = {
					new SqlParameter("@quan_id", SqlDbType.Int,4)
			};
            parameters[0].Value = quan_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tea.Model.quan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "quan(");
            strSql.Append("quan_user,quan_username,quan_name,quan_title,quan_lock,quan_add_date,quan_begin_date,quan_end_date,quan_date,quan_code,quan_pwd,quan_where,quan_show,quan_type,quan_des,quan_sort,quan_pic,quan_admin,quan_adminname,quan_num)");
            strSql.Append(" values (");
            strSql.Append("@quan_user,@quan_username,@quan_name,@quan_title,@quan_lock,@quan_add_date,@quan_begin_date,@quan_end_date,@quan_date,@quan_code,@quan_pwd,@quan_where,@quan_show,@quan_type,@quan_des,@quan_sort,@quan_pic,@quan_admin,@quan_adminname,@quan_num)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@quan_user", SqlDbType.Int,4),
					new SqlParameter("@quan_username", SqlDbType.NVarChar,64),
					new SqlParameter("@quan_name", SqlDbType.NVarChar,256),
					new SqlParameter("@quan_title", SqlDbType.NVarChar,256),
					new SqlParameter("@quan_lock", SqlDbType.Int,4),
					new SqlParameter("@quan_add_date", SqlDbType.DateTime),
					new SqlParameter("@quan_begin_date", SqlDbType.DateTime),
					new SqlParameter("@quan_end_date", SqlDbType.DateTime),
					new SqlParameter("@quan_date", SqlDbType.DateTime),
					new SqlParameter("@quan_code", SqlDbType.NVarChar,64),
					new SqlParameter("@quan_pwd", SqlDbType.NVarChar,64),
					new SqlParameter("@quan_where", SqlDbType.NVarChar,32),
					new SqlParameter("@quan_show", SqlDbType.Int,4),
					new SqlParameter("@quan_type", SqlDbType.NVarChar,32),
					new SqlParameter("@quan_des", SqlDbType.NText),
					new SqlParameter("@quan_sort", SqlDbType.Int,4),
					new SqlParameter("@quan_pic", SqlDbType.NVarChar,128),
					new SqlParameter("@quan_admin", SqlDbType.Int,4),
					new SqlParameter("@quan_adminname", SqlDbType.NVarChar,64),
					new SqlParameter("@quan_num", SqlDbType.Money,8)};
            parameters[0].Value = model.quan_user;
            parameters[1].Value = model.quan_username;
            parameters[2].Value = model.quan_name;
            parameters[3].Value = model.quan_title;
            parameters[4].Value = model.quan_lock;
            parameters[5].Value = model.quan_add_date;
            parameters[6].Value = model.quan_begin_date;
            parameters[7].Value = model.quan_end_date;
            parameters[8].Value = model.quan_date;
            parameters[9].Value = model.quan_code;
            parameters[10].Value = model.quan_pwd;
            parameters[11].Value = model.quan_where;
            parameters[12].Value = model.quan_show;
            parameters[13].Value = model.quan_type;
            parameters[14].Value = model.quan_des;
            parameters[15].Value = model.quan_sort;
            parameters[16].Value = model.quan_pic;
            parameters[17].Value = model.quan_admin;
            parameters[18].Value = model.quan_adminname;
            parameters[19].Value = model.quan_num;

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
        public bool Update(Tea.Model.quan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "quan set ");
            strSql.Append("quan_user=@quan_user,");
            strSql.Append("quan_username=@quan_username,");
            strSql.Append("quan_name=@quan_name,");
            strSql.Append("quan_title=@quan_title,");
            strSql.Append("quan_lock=@quan_lock,");
            strSql.Append("quan_add_date=@quan_add_date,");
            strSql.Append("quan_begin_date=@quan_begin_date,");
            strSql.Append("quan_end_date=@quan_end_date,");
            strSql.Append("quan_date=@quan_date,");
            strSql.Append("quan_code=@quan_code,");
            strSql.Append("quan_pwd=@quan_pwd,");
            strSql.Append("quan_where=@quan_where,");
            strSql.Append("quan_show=@quan_show,");
            strSql.Append("quan_type=@quan_type,");
            strSql.Append("quan_des=@quan_des,");
            strSql.Append("quan_sort=@quan_sort,");
            strSql.Append("quan_pic=@quan_pic,");
            strSql.Append("quan_admin=@quan_admin,");
            strSql.Append("quan_adminname=@quan_adminname,");
            strSql.Append("quan_num=@quan_num");
            strSql.Append(" where quan_id=@quan_id");
            SqlParameter[] parameters = {
					new SqlParameter("@quan_user", SqlDbType.Int,4),
					new SqlParameter("@quan_username", SqlDbType.NVarChar,64),
					new SqlParameter("@quan_name", SqlDbType.NVarChar,256),
					new SqlParameter("@quan_title", SqlDbType.NVarChar,256),
					new SqlParameter("@quan_lock", SqlDbType.Int,4),
					new SqlParameter("@quan_add_date", SqlDbType.DateTime),
					new SqlParameter("@quan_begin_date", SqlDbType.DateTime),
					new SqlParameter("@quan_end_date", SqlDbType.DateTime),
					new SqlParameter("@quan_date", SqlDbType.DateTime),
					new SqlParameter("@quan_code", SqlDbType.NVarChar,64),
					new SqlParameter("@quan_pwd", SqlDbType.NVarChar,64),
					new SqlParameter("@quan_where", SqlDbType.NVarChar,32),
					new SqlParameter("@quan_show", SqlDbType.Int,4),
					new SqlParameter("@quan_type", SqlDbType.NVarChar,32),
					new SqlParameter("@quan_des", SqlDbType.NText),
					new SqlParameter("@quan_sort", SqlDbType.Int,4),
					new SqlParameter("@quan_pic", SqlDbType.NVarChar,128),
					new SqlParameter("@quan_admin", SqlDbType.Int,4),
					new SqlParameter("@quan_adminname", SqlDbType.NVarChar,64),
					new SqlParameter("@quan_num", SqlDbType.Money,8),
					new SqlParameter("@quan_id", SqlDbType.Int,4)};
            parameters[0].Value = model.quan_user;
            parameters[1].Value = model.quan_username;
            parameters[2].Value = model.quan_name;
            parameters[3].Value = model.quan_title;
            parameters[4].Value = model.quan_lock;
            parameters[5].Value = model.quan_add_date;
            parameters[6].Value = model.quan_begin_date;
            parameters[7].Value = model.quan_end_date;
            parameters[8].Value = model.quan_date;
            parameters[9].Value = model.quan_code;
            parameters[10].Value = model.quan_pwd;
            parameters[11].Value = model.quan_where;
            parameters[12].Value = model.quan_show;
            parameters[13].Value = model.quan_type;
            parameters[14].Value = model.quan_des;
            parameters[15].Value = model.quan_sort;
            parameters[16].Value = model.quan_pic;
            parameters[17].Value = model.quan_admin;
            parameters[18].Value = model.quan_adminname;
            parameters[19].Value = model.quan_num;
            parameters[20].Value = model.quan_id;

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
        public bool Delete(int quan_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "quan ");
            strSql.Append(" where quan_id=@quan_id");
            SqlParameter[] parameters = {
					new SqlParameter("@quan_id", SqlDbType.Int,4)
			};
            parameters[0].Value = quan_id;

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
        public bool DeleteList(string quan_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "quan ");
            strSql.Append(" where quan_id in (" + quan_idlist + ")  ");
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
        public Tea.Model.quan GetModel(int quan_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 quan_id,quan_user,quan_username,quan_name,quan_title,quan_lock,quan_add_date,quan_begin_date,quan_end_date,quan_date,quan_code,quan_pwd,quan_where,quan_show,quan_type,quan_des,quan_sort,quan_pic,quan_admin,quan_adminname,quan_num from " + databaseprefix + "quan ");
            strSql.Append(" where quan_id=@quan_id");
            SqlParameter[] parameters = {
					new SqlParameter("@quan_id", SqlDbType.Int,4)
			};
            parameters[0].Value = quan_id;

            Tea.Model.quan model = new Tea.Model.quan();
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
        public Tea.Model.quan GetModel(string quan_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 quan_id,quan_user,quan_username,quan_name,quan_title,quan_lock,quan_add_date,quan_begin_date,quan_end_date,quan_date,quan_code,quan_pwd,quan_where,quan_show,quan_type,quan_des,quan_sort,quan_pic,quan_admin,quan_adminname,quan_num from " + databaseprefix + "quan ");
            strSql.Append(" where quan_code=@quan_code");
            SqlParameter[] parameters = {
					new SqlParameter("@quan_code",SqlDbType.NVarChar,64)
			};
            parameters[0].Value = quan_code;

            Tea.Model.quan model = new Tea.Model.quan();
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
        public Tea.Model.quan DataRowToModel(DataRow row)
        {
            Tea.Model.quan model = new Tea.Model.quan();
            if (row != null)
            {
                if (row["quan_id"] != null && row["quan_id"].ToString() != "")
                {
                    model.quan_id = int.Parse(row["quan_id"].ToString());
                }
                if (row["quan_user"] != null && row["quan_user"].ToString() != "")
                {
                    model.quan_user = int.Parse(row["quan_user"].ToString());
                }
                if (row["quan_username"] != null)
                {
                    model.quan_username = row["quan_username"].ToString();
                }
                if (row["quan_name"] != null)
                {
                    model.quan_name = row["quan_name"].ToString();
                }
                if (row["quan_title"] != null)
                {
                    model.quan_title = row["quan_title"].ToString();
                }
                if (row["quan_lock"] != null && row["quan_lock"].ToString() != "")
                {
                    model.quan_lock = int.Parse(row["quan_lock"].ToString());
                }
                if (row["quan_add_date"] != null && row["quan_add_date"].ToString() != "")
                {
                    model.quan_add_date = DateTime.Parse(row["quan_add_date"].ToString());
                }
                if (row["quan_begin_date"] != null && row["quan_begin_date"].ToString() != "")
                {
                    model.quan_begin_date = DateTime.Parse(row["quan_begin_date"].ToString());
                }
                if (row["quan_end_date"] != null && row["quan_end_date"].ToString() != "")
                {
                    model.quan_end_date = DateTime.Parse(row["quan_end_date"].ToString());
                }
                if (row["quan_date"] != null && row["quan_date"].ToString() != "")
                {
                    model.quan_date = DateTime.Parse(row["quan_date"].ToString());
                }
                if (row["quan_code"] != null)
                {
                    model.quan_code = row["quan_code"].ToString();
                }
                if (row["quan_pwd"] != null)
                {
                    model.quan_pwd = row["quan_pwd"].ToString();
                }
                if (row["quan_where"] != null)
                {
                    model.quan_where = row["quan_where"].ToString();
                }
                if (row["quan_show"] != null && row["quan_show"].ToString() != "")
                {
                    model.quan_show = int.Parse(row["quan_show"].ToString());
                }
                if (row["quan_type"] != null)
                {
                    model.quan_type = row["quan_type"].ToString();
                }
                if (row["quan_des"] != null)
                {
                    model.quan_des = row["quan_des"].ToString();
                }
                if (row["quan_sort"] != null && row["quan_sort"].ToString() != "")
                {
                    model.quan_sort = int.Parse(row["quan_sort"].ToString());
                }
                if (row["quan_pic"] != null)
                {
                    model.quan_pic = row["quan_pic"].ToString();
                }
                if (row["quan_admin"] != null && row["quan_admin"].ToString() != "")
                {
                    model.quan_admin = int.Parse(row["quan_admin"].ToString());
                }
                if (row["quan_adminname"] != null)
                {
                    model.quan_adminname = row["quan_adminname"].ToString();
                }
                if (row["quan_num"] != null && row["quan_num"].ToString() != "")
                {
                    model.quan_num = decimal.Parse(row["quan_num"].ToString());
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
            strSql.Append("select quan_id,quan_user,quan_username,quan_name,quan_title,quan_lock,quan_add_date,quan_begin_date,quan_end_date,quan_date,quan_code,quan_pwd,quan_where,quan_show,quan_type,quan_des,quan_sort,quan_pic,quan_admin,quan_adminname,quan_num ");
            strSql.Append(" FROM " + databaseprefix + "quan ");
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
            strSql.Append(" quan_id,quan_user,quan_username,quan_name,quan_title,quan_lock,quan_add_date,quan_begin_date,quan_end_date,quan_date,quan_code,quan_pwd,quan_where,quan_show,quan_type,quan_des,quan_sort,quan_pic,quan_admin,quan_adminname,quan_num ");
            strSql.Append(" FROM " + databaseprefix + "quan ");
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
            strSql.Append("select count(1) FROM " + databaseprefix + "quan ");
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
                strSql.Append("order by T.quan_id desc");
            }
            strSql.Append(")AS Row, T.*  from " + databaseprefix + "quan T ");
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

