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
	/// 数据访问类:文章内容
	/// </summary>
	public partial class about
	{
        private string databaseprefix; //数据库表名前缀
        public about(string _databaseprefix)
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
            strSql.Append("select count(1) from " + databaseprefix + "about");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string call_index)
        {
            if (string.IsNullOrEmpty(call_index))
            {
                return false;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "about");
            strSql.Append(" where call_index=@call_index ");
            SqlParameter[] parameters = {
					new SqlParameter("@call_index", SqlDbType.NVarChar,50)};
            parameters[0].Value = call_index;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Model.about model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        #region 添加主表数据====================
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into " + databaseprefix + "about(");
                        strSql.Append("channel_id,category_id,call_index,title,link_url,img_url,seo_title,seo_keywords,seo_description,zhaiyao,content,sort_id,click,status,is_msg,is_top,is_red,is_hot,is_slide,is_sys,user_name,add_time,update_time,company,site)");
                        strSql.Append(" values (");
                        strSql.Append("@channel_id,@category_id,@call_index,@title,@link_url,@img_url,@seo_title,@seo_keywords,@seo_description,@zhaiyao,@content,@sort_id,@click,@status,@is_msg,@is_top,@is_red,@is_hot,@is_slide,@is_sys,@user_name,@add_time,@update_time,@company,@site)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
					            new SqlParameter("@channel_id", SqlDbType.Int,4),
					            new SqlParameter("@category_id", SqlDbType.Int,4),
					            new SqlParameter("@call_index", SqlDbType.NVarChar,50),
					            new SqlParameter("@title", SqlDbType.NVarChar,100),
					            new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					            new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
					            new SqlParameter("@zhaiyao", SqlDbType.NVarChar,255),
					            new SqlParameter("@content", SqlDbType.NText),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
					            new SqlParameter("@click", SqlDbType.Int,4),
					            new SqlParameter("@status", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_msg", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_top", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_red", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_hot", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_slide", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_sys", SqlDbType.TinyInt,1),
					            new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					            new SqlParameter("@add_time", SqlDbType.DateTime),
					            new SqlParameter("@update_time", SqlDbType.DateTime),
                                new SqlParameter("@company", SqlDbType.Int,4),
                                new SqlParameter("@site", SqlDbType.Int,4)};
                        parameters[0].Value = model.channel_id;
                        parameters[1].Value = model.category_id;
                        parameters[2].Value = model.call_index;
                        parameters[3].Value = model.title;
                        parameters[4].Value = model.link_url;
                        parameters[5].Value = model.img_url;
                        parameters[6].Value = model.seo_title;
                        parameters[7].Value = model.seo_keywords;
                        parameters[8].Value = model.seo_description;
                        parameters[9].Value = model.zhaiyao;
                        parameters[10].Value = model.content;
                        parameters[11].Value = model.sort_id;
                        parameters[12].Value = model.click;
                        parameters[13].Value = model.status;
                        parameters[14].Value = model.is_msg;
                        parameters[15].Value = model.is_top;
                        parameters[16].Value = model.is_red;
                        parameters[17].Value = model.is_hot;
                        parameters[18].Value = model.is_slide;
                        parameters[19].Value = model.is_sys;
                        parameters[20].Value = model.user_name;
                        parameters[21].Value = model.add_time;
                        parameters[22].Value = model.update_time;
                        parameters[23].Value = model.company;
                        parameters[24].Value = model.site;
                        //添加主表数据
                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.id = Convert.ToInt32(obj);
                        #endregion
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }
            return model.id;
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.about model)
		{
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        #region 修改主表数据==========================
                        StringBuilder strSql=new StringBuilder();
			            strSql.Append("update " + databaseprefix + "about set ");
			            strSql.Append("channel_id=@channel_id,");
			            strSql.Append("category_id=@category_id,");
			            strSql.Append("call_index=@call_index,");
			            strSql.Append("title=@title,");
			            strSql.Append("link_url=@link_url,");
			            strSql.Append("img_url=@img_url,");
			            strSql.Append("seo_title=@seo_title,");
			            strSql.Append("seo_keywords=@seo_keywords,");
			            strSql.Append("seo_description=@seo_description,");
			            strSql.Append("zhaiyao=@zhaiyao,");
			            strSql.Append("content=@content,");
			            strSql.Append("sort_id=@sort_id,");
			            strSql.Append("click=@click,");
			            strSql.Append("status=@status,");
			            strSql.Append("is_msg=@is_msg,");
			            strSql.Append("is_top=@is_top,");
			            strSql.Append("is_red=@is_red,");
			            strSql.Append("is_hot=@is_hot,");
			            strSql.Append("is_slide=@is_slide,");
			            strSql.Append("is_sys=@is_sys,");
			            strSql.Append("user_name=@user_name,");
			            strSql.Append("add_time=@add_time,");
			            strSql.Append("update_time=@update_time");
			            strSql.Append(" where id=@id");
			            SqlParameter[] parameters = {
					            new SqlParameter("@channel_id", SqlDbType.Int,4),
					            new SqlParameter("@category_id", SqlDbType.Int,4),
					            new SqlParameter("@call_index", SqlDbType.NVarChar,50),
					            new SqlParameter("@title", SqlDbType.NVarChar,100),
					            new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					            new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
					            new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
					            new SqlParameter("@zhaiyao", SqlDbType.NVarChar,255),
					            new SqlParameter("@content", SqlDbType.NText),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
					            new SqlParameter("@click", SqlDbType.Int,4),
					            new SqlParameter("@status", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_msg", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_top", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_red", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_hot", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_slide", SqlDbType.TinyInt,1),
					            new SqlParameter("@is_sys", SqlDbType.TinyInt,1),
					            new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					            new SqlParameter("@add_time", SqlDbType.DateTime),
					            new SqlParameter("@update_time", SqlDbType.DateTime),
					            new SqlParameter("@id", SqlDbType.Int,4)};
			            parameters[0].Value = model.channel_id;
			            parameters[1].Value = model.category_id;
			            parameters[2].Value = model.call_index;
			            parameters[3].Value = model.title;
			            parameters[4].Value = model.link_url;
			            parameters[5].Value = model.img_url;
			            parameters[6].Value = model.seo_title;
			            parameters[7].Value = model.seo_keywords;
			            parameters[8].Value = model.seo_description;
			            parameters[9].Value = model.zhaiyao;
			            parameters[10].Value = model.content;
			            parameters[11].Value = model.sort_id;
			            parameters[12].Value = model.click;
			            parameters[13].Value = model.status;
			            parameters[14].Value = model.is_msg;
			            parameters[15].Value = model.is_top;
			            parameters[16].Value = model.is_red;
			            parameters[17].Value = model.is_hot;
			            parameters[18].Value = model.is_slide;
			            parameters[19].Value = model.is_sys;
			            parameters[20].Value = model.user_name;
			            parameters[21].Value = model.add_time;
			            parameters[22].Value = model.update_time;
			            parameters[23].Value = model.id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                        #endregion
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
            //删除主表
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "about ");
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
        public Model.about GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,channel_id,category_id,call_index,title,link_url,img_url,seo_title,seo_keywords,seo_description,zhaiyao,content,sort_id,click,status,is_msg,is_top,is_red,is_hot,is_slide,is_sys,user_name,add_time,update_time,company,site");
            strSql.Append(" from " + databaseprefix + "about");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.about model = new Model.about();
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
        public Model.about GetModel(string call_index)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from " + databaseprefix + "about");
            strSql.Append(" where call_index=@call_index");
            SqlParameter[] parameters = {
					new SqlParameter("@call_index", SqlDbType.NVarChar,50)};
            parameters[0].Value = call_index;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
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
            strSql.Append(" id,channel_id,category_id,call_index,title,link_url,img_url,seo_title,seo_keywords,seo_description,zhaiyao,content,sort_id,click,status,is_msg,is_top,is_red,is_hot,is_slide,is_sys,user_name,add_time,update_time ");
            strSql.Append(" FROM " + databaseprefix + "about ");
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
        public DataSet GetList(int channel_id, int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "about");
            if (channel_id > 0)
            {
                strSql.Append(" where channel_id=" + channel_id);
            }
            if (category_id > 0)
            {
                if (channel_id > 0)
                {
                    strSql.Append(" and category_id=" + category_id + "");
                }
                else
                {
                    strSql.Append(" where category_id=" + category_id + "");
                }
            }
            if (strWhere.Trim() != "")
            {
                if (channel_id > 0 || category_id > 0)
                {
                    strSql.Append(" and " + strWhere);
                }
                else
                {
                    strSql.Append(" where " + strWhere);
                }
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
		#endregion

        #region 扩展方法================================
        /// <summary>
        /// 是否存在标题
        /// </summary>
        public bool ExistsTitle(string title)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "about");
            strSql.Append(" where title=@title ");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,200)};
            parameters[0].Value = title;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在标题
        /// </summary>
        public bool ExistsTitle(string title, int category_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "about");
            strSql.Append(" where title=@title and category_id=@category_id");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,200),
                    new SqlParameter("@category_id", SqlDbType.Int,4)  }
                                        ;
            parameters[0].Value = title;
            parameters[1].Value = category_id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回信息标题
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title from " + databaseprefix + "about");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return string.Empty;
            }
            return title;
        }

        /// <summary>
        /// 返回信息内容
        /// </summary>
        public string GetContent(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 content from " + databaseprefix + "about");
            strSql.Append(" where id=" + id);
            string content = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(content))
            {
                return "";
            }
            return content;
        }

        /// <summary>
        /// 获取阅读次数
        /// </summary>
        public int GetClick(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 click from " + databaseprefix + "about");
            strSql.Append(" where id=" + id);
            string str = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            return Convert.ToInt32(str);
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from " + databaseprefix + "about");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
 
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "about set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        #endregion

        #region 私有方法================================
        /// <summary>
        /// 将对象转换为实体
        /// </summary>
        private Model.about DataRowToModel(DataRow row)
        {
            Model.about model = new Model.about();
            if (row != null)
            {
                #region 主表信息======================
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["channel_id"] != null && row["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(row["channel_id"].ToString());
                }
                if (row["category_id"] != null && row["category_id"].ToString() != "")
                {
                    model.category_id = int.Parse(row["category_id"].ToString());
                }
                if (row["call_index"] != null)
                {
                    model.call_index = row["call_index"].ToString();
                }
                if (row["title"] != null)
                {
                    model.title = row["title"].ToString();
                }
                if (row["link_url"] != null)
                {
                    model.link_url = row["link_url"].ToString();
                }
                if (row["img_url"] != null)
                {
                    model.img_url = row["img_url"].ToString();
                }
                if (row["seo_title"] != null)
                {
                    model.seo_title = row["seo_title"].ToString();
                }
                if (row["seo_keywords"] != null)
                {
                    model.seo_keywords = row["seo_keywords"].ToString();
                }
                if (row["seo_description"] != null)
                {
                    model.seo_description = row["seo_description"].ToString();
                }
                if (row["zhaiyao"] != null)
                {
                    model.zhaiyao = row["zhaiyao"].ToString();
                }
                if (row["content"] != null)
                {
                    model.content = row["content"].ToString();
                }
                if (row["sort_id"] != null && row["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(row["sort_id"].ToString());
                }
                if (row["click"] != null && row["click"].ToString() != "")
                {
                    model.click = int.Parse(row["click"].ToString());
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }
                if (row["is_msg"] != null && row["is_msg"].ToString() != "")
                {
                    model.is_msg = int.Parse(row["is_msg"].ToString());
                }
                if (row["is_top"] != null && row["is_top"].ToString() != "")
                {
                    model.is_top = int.Parse(row["is_top"].ToString());
                }
                if (row["is_red"] != null && row["is_red"].ToString() != "")
                {
                    model.is_red = int.Parse(row["is_red"].ToString());
                }
                if (row["is_hot"] != null && row["is_hot"].ToString() != "")
                {
                    model.is_hot = int.Parse(row["is_hot"].ToString());
                }
                if (row["is_slide"] != null && row["is_slide"].ToString() != "")
                {
                    model.is_slide = int.Parse(row["is_slide"].ToString());
                }
                if (row["is_sys"] != null && row["is_sys"].ToString() != "")
                {
                    model.is_sys = int.Parse(row["is_sys"].ToString());
                }
                if (row["user_name"] != null)
                {
                    model.user_name = row["user_name"].ToString();
                }
                if (row["add_time"] != null && row["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(row["add_time"].ToString());
                }
                if (row["update_time"] != null && row["update_time"].ToString() != "")
                {
                    model.update_time = DateTime.Parse(row["update_time"].ToString());
                }
                if (row["company"] != null && row["company"].ToString() != "")
                {
                    model.company = int.Parse(row["company"].ToString());
                }
                if (row["site"] != null && row["site"].ToString() != "")
                {
                    model.site = int.Parse(row["site"].ToString());
                }
                #endregion
            }
            return model;
        }
 

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "about");
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

