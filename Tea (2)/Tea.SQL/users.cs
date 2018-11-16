using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using Tea.DBUtility;
using Tea.Common;

namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:用户
    /// </summary>
    public partial class users
    {
        private string databaseprefix; //数据库表名前缀
        public users(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public string getTitle(string id)
        {
            string str = "";
            try
            {
                str = GetModel(int.Parse(id)).user_name;
            }
            catch (Exception eee) { }
            return str;
        }
        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public bool Exists(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where user_name=@user_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查同一IP注册间隔(小时)内是否存在
        /// </summary>
        public bool Exists(string reg_ip, int regctrl)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where reg_ip=@reg_ip and DATEDIFF(hh,reg_time,getdate())<@regctrl ");
            SqlParameter[] parameters = {
					new SqlParameter("@reg_ip", SqlDbType.NVarChar,30),
                    new SqlParameter("@regctrl", SqlDbType.Int,4)};
            parameters[0].Value = reg_ip;
            parameters[1].Value = regctrl;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "users(");
            strSql.Append("group_id,user_name,salt,password,mobile,email,avatar,nick_name,sex,birthday,telphone,area,address,qq,msn,amount,point,exp,status,reg_time,reg_ip,company,bank,bank_pic,bank_hetong,name,tong_code,tong_more,link_name,link_nichen,link_mail,link_time,user_hei)");
            strSql.Append(" values (");
            strSql.Append("@group_id,@user_name,@salt,@password,@mobile,@email,@avatar,@nick_name,@sex,@birthday,@telphone,@area,@address,@qq,@msn,@amount,@point,@exp,@status,@reg_time,@reg_ip,@company,@bank,@bank_pic,@bank_hetong,@name,@tong_code,@tong_more,@link_name,@link_nichen,@link_mail,@link_time,@user_hei)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@group_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@salt", SqlDbType.NVarChar,20),
					new SqlParameter("@password", SqlDbType.NVarChar,100),
					new SqlParameter("@mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@avatar", SqlDbType.NVarChar,255),
					new SqlParameter("@nick_name", SqlDbType.NVarChar,100),
					new SqlParameter("@sex", SqlDbType.NVarChar,20),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@area", SqlDbType.NVarChar,255),
					new SqlParameter("@address", SqlDbType.NVarChar,255),
					new SqlParameter("@qq", SqlDbType.NVarChar,20),
					new SqlParameter("@msn", SqlDbType.NVarChar,100),
					new SqlParameter("@amount", SqlDbType.Decimal,5),
					new SqlParameter("@point", SqlDbType.Int,4),
					new SqlParameter("@exp", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@reg_time", SqlDbType.DateTime),
					new SqlParameter("@reg_ip", SqlDbType.NVarChar,20),
                    new SqlParameter("@company", SqlDbType.Int,4),
                    new SqlParameter("@bank", SqlDbType.NVarChar,512),
                    new SqlParameter("@bank_pic", SqlDbType.NVarChar,128),
                    new SqlParameter("@bank_hetong", SqlDbType.NText),
                    new SqlParameter("@name", SqlDbType.NVarChar,64),
                    new SqlParameter("@tong_code", SqlDbType.NVarChar,64),
                    new SqlParameter("@tong_more", SqlDbType.NVarChar,128),
                    new SqlParameter("@link_name", SqlDbType.NVarChar,64),
                    new SqlParameter("@link_nichen", SqlDbType.NVarChar,64),
                    new SqlParameter("@link_mail", SqlDbType.NVarChar,64),
                    new SqlParameter("@link_time", SqlDbType.NVarChar,512),
                    new SqlParameter("@user_hei", SqlDbType.Int,4)};
            parameters[0].Value = model.group_id;
            parameters[1].Value = model.user_name;
            parameters[2].Value = model.salt;
            parameters[3].Value = model.password;
            parameters[4].Value = model.mobile;
            parameters[5].Value = model.email;
            parameters[6].Value = model.avatar;
            parameters[7].Value = model.nick_name;
            parameters[8].Value = model.sex;
            parameters[9].Value = model.birthday;
            parameters[10].Value = model.telphone;
            parameters[11].Value = model.area;
            parameters[12].Value = model.address;
            parameters[13].Value = model.qq;
            parameters[14].Value = model.msn;
            parameters[15].Value = model.amount;
            parameters[16].Value = model.point;
            parameters[17].Value = model.exp;
            parameters[18].Value = model.status;
            parameters[19].Value = model.reg_time;
            parameters[20].Value = model.reg_ip;
            parameters[21].Value = model.company;
            parameters[22].Value = model.bank;
            parameters[23].Value = model.bank_pic;
            parameters[24].Value = model.bank_hetong;
            parameters[25].Value = model.name;
            parameters[26].Value = model.tong_code;
            parameters[27].Value = model.tong_more;
            parameters[28].Value = model.link_name;
            parameters[29].Value = model.link_nichen;
            parameters[30].Value = model.link_mail;
            parameters[31].Value = model.link_time;
            parameters[32].Value = model.user_hei;
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
        public bool Update(Model.users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "users set ");
            strSql.Append("group_id=@group_id,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("salt=@salt,");
            strSql.Append("password=@password,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("email=@email,");
            strSql.Append("avatar=@avatar,");
            strSql.Append("nick_name=@nick_name,");
            strSql.Append("sex=@sex,");
            strSql.Append("birthday=@birthday,");
            strSql.Append("telphone=@telphone,");
            strSql.Append("area=@area,");
            strSql.Append("address=@address,");
            strSql.Append("qq=@qq,");
            strSql.Append("msn=@msn,");
            strSql.Append("amount=@amount,");
            strSql.Append("point=@point,");
            strSql.Append("exp=@exp,");
            strSql.Append("status=@status,");
            strSql.Append("reg_time=@reg_time,");
            strSql.Append("reg_ip=@reg_ip,");
            strSql.Append("bank=@bank,");
            strSql.Append("bank_pic=@bank_pic,");
            strSql.Append("bank_hetong=@bank_hetong,");
            strSql.Append("name=@name,");
            strSql.Append("tong_code=@tong_code,");
            strSql.Append("tong_more=@tong_more,");
            strSql.Append("link_name=@link_name,");
            strSql.Append("link_nichen=@link_nichen,");
            strSql.Append("link_mail=@link_mail,");
            strSql.Append("link_time=@link_time,");
            strSql.Append("user_hei=@user_hei");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@group_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@salt", SqlDbType.NVarChar,20),
					new SqlParameter("@password", SqlDbType.NVarChar,100),
					new SqlParameter("@mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@avatar", SqlDbType.NVarChar,255),
					new SqlParameter("@nick_name", SqlDbType.NVarChar,100),
					new SqlParameter("@sex", SqlDbType.NVarChar,20),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@area", SqlDbType.NVarChar,255),
					new SqlParameter("@address", SqlDbType.NVarChar,255),
					new SqlParameter("@qq", SqlDbType.NVarChar,20),
					new SqlParameter("@msn", SqlDbType.NVarChar,100),
					new SqlParameter("@amount", SqlDbType.Decimal,5),
					new SqlParameter("@point", SqlDbType.Int,4),
					new SqlParameter("@exp", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@reg_time", SqlDbType.DateTime),
					new SqlParameter("@reg_ip", SqlDbType.NVarChar,20),
                    new SqlParameter("@bank", SqlDbType.NVarChar,512),
                    new SqlParameter("@bank_pic", SqlDbType.NVarChar,128),
                    new SqlParameter("@bank_hetong", SqlDbType.NText),
                    new SqlParameter("@name", SqlDbType.NVarChar,64),
                    new SqlParameter("@tong_code", SqlDbType.NVarChar,64),
                    new SqlParameter("@tong_more", SqlDbType.NVarChar,128),
                    new SqlParameter("@link_name", SqlDbType.NVarChar,64),
                    new SqlParameter("@link_nichen", SqlDbType.NVarChar,64),
                    new SqlParameter("@link_mail", SqlDbType.NVarChar,64),
                    new SqlParameter("@link_time", SqlDbType.NVarChar,512),
                    new SqlParameter("@user_hei", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.group_id;
            parameters[1].Value = model.user_name;
            parameters[2].Value = model.salt;
            parameters[3].Value = model.password;
            parameters[4].Value = model.mobile;
            parameters[5].Value = model.email;
            parameters[6].Value = model.avatar;
            parameters[7].Value = model.nick_name;
            parameters[8].Value = model.sex;
            parameters[9].Value = model.birthday;
            parameters[10].Value = model.telphone;
            parameters[11].Value = model.area;
            parameters[12].Value = model.address;
            parameters[13].Value = model.qq;
            parameters[14].Value = model.msn;
            parameters[15].Value = model.amount;
            parameters[16].Value = model.point;
            parameters[17].Value = model.exp;
            parameters[18].Value = model.status;
            parameters[19].Value = model.reg_time;
            parameters[20].Value = model.reg_ip;
            parameters[21].Value = model.bank;
            parameters[22].Value = model.bank_pic;
            parameters[23].Value = model.bank_hetong;
            parameters[24].Value = model.name;
            parameters[25].Value = model.tong_code;
            parameters[26].Value = model.tong_more;
            parameters[27].Value = model.link_name;
            parameters[28].Value = model.link_nichen;
            parameters[29].Value = model.link_mail;
            parameters[30].Value = model.link_time;
            parameters[31].Value = model.user_hei;
            parameters[32].Value = model.id;

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
            //获取用户旧数据
            Model.users model = GetModel(id);
            if (model == null)
            {
                return false;
            }

            List<CommandInfo> sqllist = new List<CommandInfo>();
            //删除积分记录
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from " + databaseprefix + "user_point_log ");
            strSql1.Append(" where user_id=@id");
            SqlParameter[] parameters1 = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters1[0].Value = id;
            CommandInfo cmd = new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd);

            //删除金额记录
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from " + databaseprefix + "user_amount_log ");
            strSql2.Append(" where user_id=@id");
            SqlParameter[] parameters2 = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters2[0].Value = id;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

 
            //删除登录日志
            StringBuilder strSql6 = new StringBuilder();
            strSql6.Append("delete from " + databaseprefix + "user_login_log ");
            strSql6.Append(" where user_id=@id");
            SqlParameter[] parameters6 = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters6[0].Value = id;
            cmd = new CommandInfo(strSql6.ToString(), parameters6);
            sqllist.Add(cmd);
 
 
 

            //删除用户主表
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "users ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
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
        public Model.users GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * ");
            strSql.Append(" from " + databaseprefix + "users");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

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
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.users GetModel(string user_name, string password, int emaillogin, int mobilelogin)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * ");
            strSql.Append(" from " + databaseprefix + "users");
            strSql.Append(" where (user_name=@user_name");
            if (emaillogin == 1)
            {
                strSql.Append(" or email=@user_name");
            }
            if (mobilelogin == 1)
            {
                strSql.Append(" or mobile=@user_name");
            }
            strSql.Append(") and password=@password and status<3");

            SqlParameter[] parameters = {
					    new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                        new SqlParameter("@password", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            parameters[1].Value = password;

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
        /// 根据用户名返回一个实体
        /// </summary>
        public Model.users GetModel(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * ");
            strSql.Append(" from " + databaseprefix + "users");
            strSql.Append(" where user_name=@user_name and status<3");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;

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
        /// 根据用户名返回一个实体
        /// </summary>
        public Model.users GetEModel(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * ");
            strSql.Append(" from " + databaseprefix + "users");
            strSql.Append(" where email=@user_name and status<3");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;

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
            strSql.Append(" * ");
            strSql.Append(" FROM " + databaseprefix + "users ");
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
            strSql.Append("select * FROM " + databaseprefix + "users");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion

        #region 扩展方法================================
        /// <summary>
        /// 检查Email是否存在
        /// </summary>
        public bool ExistsEmail(string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where email=@email ");
            SqlParameter[] parameters = {
					new SqlParameter("@email", SqlDbType.NVarChar,100)};
            parameters[0].Value = email;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查手机号码是否存在
        /// </summary>
        public bool ExistsMobile(string mobile)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where mobile=@mobile ");
            SqlParameter[] parameters = {
					new SqlParameter("@mobile", SqlDbType.NVarChar,20)};
            parameters[0].Value = mobile;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据用户名取得Salt
        /// </summary>
        public string GetSalt(string user_name)
        {
            //尝试用户名取得Salt
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 salt from " + databaseprefix + "users");
            strSql.Append(" where user_name=@user_name");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            string salt = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            if (!string.IsNullOrEmpty(salt))
            {
                return salt;
            }
            //尝试用手机号取得Salt
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("select top 1 salt from " + databaseprefix + "users");
            strSql1.Append(" where mobile=@mobile");
            SqlParameter[] parameters1 = {
                    new SqlParameter("@mobile", SqlDbType.NVarChar,20)};
            parameters1[0].Value = user_name;
            salt = Convert.ToString(DbHelperSQL.GetSingle(strSql1.ToString(), parameters1));
            if (!string.IsNullOrEmpty(salt))
            {
                return salt;
            }
            //尝试用邮箱取得Salt
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("select top 1 salt from " + databaseprefix + "users");
            strSql2.Append(" where email=@email");
            SqlParameter[] parameters2 = {
                    new SqlParameter("@email", SqlDbType.NVarChar,50)};
            parameters2[0].Value = user_name;
            salt = Convert.ToString(DbHelperSQL.GetSingle(strSql2.ToString(), parameters2));
            if (!string.IsNullOrEmpty(salt))
            {
                return salt;
            }
            return string.Empty;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "users set " + strValue);
            strSql.Append(" where id=" + id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.users DataRowToModel(DataRow row)
        {
            Model.users model = new Model.users();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["group_id"] != null && row["group_id"].ToString() != "")
                {
                    model.group_id = int.Parse(row["group_id"].ToString());
                }
                if (row["user_name"] != null)
                {
                    model.user_name = row["user_name"].ToString();
                }
                if (row["salt"] != null)
                {
                    model.salt = row["salt"].ToString();
                }
                if (row["password"] != null)
                {
                    model.password = row["password"].ToString();
                }
                if (row["mobile"] != null)
                {
                    model.mobile = row["mobile"].ToString();
                }
                if (row["email"] != null)
                {
                    model.email = row["email"].ToString();
                }
                if (row["avatar"] != null)
                {
                    model.avatar = row["avatar"].ToString();
                }
                if (row["nick_name"] != null)
                {
                    model.nick_name = row["nick_name"].ToString();
                }
                if (row["sex"] != null)
                {
                    model.sex = row["sex"].ToString();
                }
                if (row["birthday"] != null && row["birthday"].ToString() != "")
                {
                    model.birthday = DateTime.Parse(row["birthday"].ToString());
                }
                if (row["telphone"] != null)
                {
                    model.telphone = row["telphone"].ToString();
                }
                if (row["area"] != null)
                {
                    model.area = row["area"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["qq"] != null)
                {
                    model.qq = row["qq"].ToString();
                }
                if (row["msn"] != null)
                {
                    model.msn = row["msn"].ToString();
                }
                if (row["amount"] != null && row["amount"].ToString() != "")
                {
                    model.amount = decimal.Parse(row["amount"].ToString());
                }
                if (row["point"] != null && row["point"].ToString() != "")
                {
                    model.point = int.Parse(row["point"].ToString());
                }
                if (row["exp"] != null && row["exp"].ToString() != "")
                {
                    model.exp = int.Parse(row["exp"].ToString());
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }
                if (row["reg_time"] != null && row["reg_time"].ToString() != "")
                {
                    model.reg_time = DateTime.Parse(row["reg_time"].ToString());
                }
                if (row["reg_ip"] != null)
                {
                    model.reg_ip = row["reg_ip"].ToString();
                }
                if (row["company"] != null && row["company"].ToString() != "")
                {
                    model.company = int.Parse(row["company"].ToString());
                }
                if (row["user_hei"] != null && row["user_hei"].ToString() != "")
                {
                    model.user_hei = int.Parse(row["user_hei"].ToString());
                }
                if (row["bank"] != null && row["bank"].ToString() != "")
                {
                    model.bank = row["bank"].ToString();
                }
                if (row["bank_pic"] != null && row["bank_pic"].ToString() != "")
                {
                    model.bank_pic = row["bank_pic"].ToString();
                }
                if (row["bank_hetong"] != null && row["bank_hetong"].ToString() != "")
                {
                    model.bank_hetong = row["bank_hetong"].ToString();
                }
                if (row["name"] != null && row["name"].ToString() != "")
                {
                    model.name = row["name"].ToString();
                }
                if (row["tong_code"] != null && row["tong_code"].ToString() != "")
                {
                    model.tong_code = row["tong_code"].ToString();
                }
                if (row["tong_more"] != null && row["tong_more"].ToString() != "")
                {
                    model.tong_more = row["tong_more"].ToString();
                }
                if (row["link_name"] != null && row["link_name"].ToString() != "")
                {
                    model.link_name = row["link_name"].ToString();
                }
                if (row["link_nichen"] != null && row["link_nichen"].ToString() != "")
                {
                    model.link_nichen = row["link_nichen"].ToString();
                }
                if (row["link_mail"] != null && row["link_mail"].ToString() != "")
                {
                    model.link_mail = row["link_mail"].ToString();
                }
                if (row["link_time"] != null && row["link_time"].ToString() != "")
                {
                    model.link_time = row["link_time"].ToString();
                }
            }
            return model;
        }
        #endregion

    }
}