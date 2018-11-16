using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:user_address
    /// </summary>
    public partial class user_address
    {
        private string databaseprefix; //数据库表名前缀
        public user_address(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("address_id", databaseprefix + "user_address");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int address_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "user_address");
            strSql.Append(" where address_id=@address_id");
            SqlParameter[] parameters = {
					new SqlParameter("@address_id", SqlDbType.Int,4)
			};
            parameters[0].Value = address_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tea.Model.user_address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "user_address(");
            strSql.Append("address_user,address_name,address_shenfen,address_city,address_qu,address_address,address_tel,address_mobile,address_email,address_zip,address_qita,address_lock,address_add_date,address_payment,show,wheresql)");
            strSql.Append(" values (");
            strSql.Append("@address_user,@address_name,@address_shenfen,@address_city,@address_qu,@address_address,@address_tel,@address_mobile,@address_email,@address_zip,@address_qita,@address_lock,@address_add_date,@address_payment,@show,@wheresql)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@address_user", SqlDbType.Int,4),
					new SqlParameter("@address_name", SqlDbType.NVarChar,128),
					new SqlParameter("@address_shenfen", SqlDbType.NVarChar,32),
					new SqlParameter("@address_city", SqlDbType.NVarChar,32),
					new SqlParameter("@address_qu", SqlDbType.NVarChar,32),
					new SqlParameter("@address_address", SqlDbType.NVarChar,256),
					new SqlParameter("@address_tel", SqlDbType.NVarChar,32),
					new SqlParameter("@address_mobile", SqlDbType.NVarChar,32),
					new SqlParameter("@address_email", SqlDbType.NVarChar,256),
					new SqlParameter("@address_zip", SqlDbType.NVarChar,32),
					new SqlParameter("@address_qita", SqlDbType.NVarChar,256),
					new SqlParameter("@address_lock", SqlDbType.Int,4),
					new SqlParameter("@address_add_date", SqlDbType.DateTime),
					new SqlParameter("@address_payment", SqlDbType.Int,4),
					new SqlParameter("@show", SqlDbType.Int,4),
					new SqlParameter("@wheresql", SqlDbType.NVarChar,32)};
            parameters[0].Value = model.address_user;
            parameters[1].Value = model.address_name;
            parameters[2].Value = model.address_shenfen;
            parameters[3].Value = model.address_city;
            parameters[4].Value = model.address_qu;
            parameters[5].Value = model.address_address;
            parameters[6].Value = model.address_tel;
            parameters[7].Value = model.address_mobile;
            parameters[8].Value = model.address_email;
            parameters[9].Value = model.address_zip;
            parameters[10].Value = model.address_qita;
            parameters[11].Value = model.address_lock;
            parameters[12].Value = model.address_add_date;
            parameters[13].Value = model.address_payment;
            parameters[14].Value = model.show;
            parameters[15].Value = model.wheresql;

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
        public bool Update(Tea.Model.user_address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "user_address set ");
            strSql.Append("address_user=@address_user,");
            strSql.Append("address_name=@address_name,");
            strSql.Append("address_shenfen=@address_shenfen,");
            strSql.Append("address_city=@address_city,");
            strSql.Append("address_qu=@address_qu,");
            strSql.Append("address_address=@address_address,");
            strSql.Append("address_tel=@address_tel,");
            strSql.Append("address_mobile=@address_mobile,");
            strSql.Append("address_email=@address_email,");
            strSql.Append("address_zip=@address_zip,");
            strSql.Append("address_qita=@address_qita,");
            strSql.Append("address_lock=@address_lock,");
            strSql.Append("address_add_date=@address_add_date,");
            strSql.Append("address_payment=@address_payment,");
            strSql.Append("show=@show,");
            strSql.Append("wheresql=@wheresql");
            strSql.Append(" where address_id=@address_id");
            SqlParameter[] parameters = {
					new SqlParameter("@address_user", SqlDbType.Int,4),
					new SqlParameter("@address_name", SqlDbType.NVarChar,128),
					new SqlParameter("@address_shenfen", SqlDbType.NVarChar,32),
					new SqlParameter("@address_city", SqlDbType.NVarChar,32),
					new SqlParameter("@address_qu", SqlDbType.NVarChar,32),
					new SqlParameter("@address_address", SqlDbType.NVarChar,256),
					new SqlParameter("@address_tel", SqlDbType.NVarChar,32),
					new SqlParameter("@address_mobile", SqlDbType.NVarChar,32),
					new SqlParameter("@address_email", SqlDbType.NVarChar,256),
					new SqlParameter("@address_zip", SqlDbType.NVarChar,32),
					new SqlParameter("@address_qita", SqlDbType.NVarChar,256),
					new SqlParameter("@address_lock", SqlDbType.Int,4),
					new SqlParameter("@address_add_date", SqlDbType.DateTime),
					new SqlParameter("@address_payment", SqlDbType.Int,4),
					new SqlParameter("@show", SqlDbType.Int,4),
					new SqlParameter("@wheresql", SqlDbType.NVarChar,32),
					new SqlParameter("@address_id", SqlDbType.Int,4)};
            parameters[0].Value = model.address_user;
            parameters[1].Value = model.address_name;
            parameters[2].Value = model.address_shenfen;
            parameters[3].Value = model.address_city;
            parameters[4].Value = model.address_qu;
            parameters[5].Value = model.address_address;
            parameters[6].Value = model.address_tel;
            parameters[7].Value = model.address_mobile;
            parameters[8].Value = model.address_email;
            parameters[9].Value = model.address_zip;
            parameters[10].Value = model.address_qita;
            parameters[11].Value = model.address_lock;
            parameters[12].Value = model.address_add_date;
            parameters[13].Value = model.address_payment;
            parameters[14].Value = model.show;
            parameters[15].Value = model.wheresql;
            parameters[16].Value = model.address_id;

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
        public bool Delete(int address_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "user_address ");
            strSql.Append(" where address_id=@address_id");
            SqlParameter[] parameters = {
					new SqlParameter("@address_id", SqlDbType.Int,4)
			};
            parameters[0].Value = address_id;

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
        public bool DeleteList(string address_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "user_address ");
            strSql.Append(" where address_id in (" + address_idlist + ")  ");
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
        public Tea.Model.user_address GetModel(int address_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 address_id,address_user,address_name,address_shenfen,address_city,address_qu,address_address,address_tel,address_mobile,address_email,address_zip,address_qita,address_lock,address_add_date,address_payment,show,wheresql from " + databaseprefix + "user_address ");
            strSql.Append(" where address_id=@address_id");
            SqlParameter[] parameters = {
					new SqlParameter("@address_id", SqlDbType.Int,4)
			};
            parameters[0].Value = address_id;

            Tea.Model.user_address model = new Tea.Model.user_address();
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
        public Tea.Model.user_address DataRowToModel(DataRow row)
        {
            Tea.Model.user_address model = new Tea.Model.user_address();
            if (row != null)
            {
                if (row["address_id"] != null && row["address_id"].ToString() != "")
                {
                    model.address_id = int.Parse(row["address_id"].ToString());
                }
                if (row["address_user"] != null && row["address_user"].ToString() != "")
                {
                    model.address_user = int.Parse(row["address_user"].ToString());
                }
                if (row["address_name"] != null)
                {
                    model.address_name = row["address_name"].ToString();
                }
                if (row["address_shenfen"] != null)
                {
                    model.address_shenfen = row["address_shenfen"].ToString();
                }
                if (row["address_city"] != null)
                {
                    model.address_city = row["address_city"].ToString();
                }
                if (row["address_qu"] != null)
                {
                    model.address_qu = row["address_qu"].ToString();
                }
                if (row["address_address"] != null)
                {
                    model.address_address = row["address_address"].ToString();
                }
                if (row["address_tel"] != null)
                {
                    model.address_tel = row["address_tel"].ToString();
                }
                if (row["address_mobile"] != null)
                {
                    model.address_mobile = row["address_mobile"].ToString();
                }
                if (row["address_email"] != null)
                {
                    model.address_email = row["address_email"].ToString();
                }
                if (row["address_zip"] != null)
                {
                    model.address_zip = row["address_zip"].ToString();
                }
                if (row["address_qita"] != null)
                {
                    model.address_qita = row["address_qita"].ToString();
                }
                if (row["address_lock"] != null && row["address_lock"].ToString() != "")
                {
                    model.address_lock = int.Parse(row["address_lock"].ToString());
                }
                if (row["address_add_date"] != null && row["address_add_date"].ToString() != "")
                {
                    model.address_add_date = DateTime.Parse(row["address_add_date"].ToString());
                }
                if (row["address_payment"] != null && row["address_payment"].ToString() != "")
                {
                    model.address_payment = int.Parse(row["address_payment"].ToString());
                }
                if (row["show"] != null && row["show"].ToString() != "")
                {
                    model.show = int.Parse(row["show"].ToString());
                }
                if (row["wheresql"] != null)
                {
                    model.wheresql = row["wheresql"].ToString();
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
            strSql.Append("select address_id,address_user,address_name,address_shenfen,address_city,address_qu,address_address,address_tel,address_mobile,address_email,address_zip,address_qita,address_lock,address_add_date,address_payment,show,wheresql ");
            strSql.Append(" FROM " + databaseprefix + "user_address ");
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
            strSql.Append(" address_id,address_user,address_name,address_shenfen,address_city,address_qu,address_address,address_tel,address_mobile,address_email,address_zip,address_qita,address_lock,address_add_date,address_payment,show,wheresql ");
            strSql.Append(" FROM " + databaseprefix + "user_address ");
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
            strSql.Append("select count(1) FROM " + databaseprefix + "user_address ");
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
                strSql.Append("order by T.address_id desc");
            }
            strSql.Append(")AS Row, T.*  from " + databaseprefix + "user_address T ");
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

