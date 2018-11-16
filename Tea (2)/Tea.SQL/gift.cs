using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
using Tea.Common;
using System.Collections.Generic;

namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:贈品
    /// </summary>
    public partial class gift
    {
        private string databaseprefix; //数据库表名前缀
        public gift(string _databaseprefix)
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
            strSql.Append("select count(1) from " + databaseprefix + "gift");
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
            strSql.Append("select top 1 title from " + databaseprefix + "gift");
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
        public int Add(Model.gift model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "gift(");
            strSql.Append("title,img_url,type,article_list,brand_id,quantity,amount,sort_id,status,left_quantity,content,add_time,company,gift_code)");
            strSql.Append(" values (");
            strSql.Append("@title,@img_url,@type,@article_list,@brand_id,@quantity,@amount,@sort_id,@status,@left_quantity,@content,@add_time,@company,@gift_code)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@article_list", SqlDbType.NVarChar,255),
					new SqlParameter("@brand_id", SqlDbType.Int,4),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@amount", SqlDbType.Decimal,5),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@left_quantity", SqlDbType.Int,4),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@add_time", SqlDbType.DateTime),
                    new SqlParameter("@company", SqlDbType.Int,4),
                    new SqlParameter("@gift_code", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.img_url;
            parameters[2].Value = model.type;
            parameters[3].Value = model.article_list;
            parameters[4].Value = model.brand_id;
            parameters[5].Value = model.quantity;
            parameters[6].Value = model.amount;
            parameters[7].Value = model.sort_id;
            parameters[8].Value = model.status;
            parameters[9].Value = model.left_quantity;
            parameters[10].Value = model.content;
            parameters[11].Value = model.add_time;
            parameters[12].Value = model.company;
            parameters[13].Value = model.gift_code;
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
            strSql.Append("update " + databaseprefix + "gift set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.gift model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "gift set ");
            strSql.Append("title=@title,");
            strSql.Append("img_url=@img_url,");
            strSql.Append("type=@type,");
            strSql.Append("article_list=@article_list,");
            strSql.Append("brand_id=@brand_id,");
            strSql.Append("quantity=@quantity,");
            strSql.Append("amount=@amount,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("status=@status,");
            strSql.Append("left_quantity=@left_quantity,");
            strSql.Append("content=@content,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("gift_code=@gift_code");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,255),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@article_list", SqlDbType.NVarChar,255),
					new SqlParameter("@brand_id", SqlDbType.Int,4),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@amount", SqlDbType.Decimal,5),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@left_quantity", SqlDbType.Int,4),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@add_time", SqlDbType.DateTime),
                    new SqlParameter("@gift_code", SqlDbType.NVarChar,100),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            
            parameters[0].Value = model.title;
            parameters[1].Value = model.img_url;
            parameters[2].Value = model.type;
            parameters[3].Value = model.article_list;
            parameters[4].Value = model.brand_id;
            parameters[5].Value = model.quantity;
            parameters[6].Value = model.amount;
            parameters[7].Value = model.sort_id;
            parameters[8].Value = model.status;
            parameters[9].Value = model.left_quantity;
            parameters[10].Value = model.content;
            parameters[11].Value = model.add_time;
            parameters[12].Value = model.gift_code;
            parameters[13].Value = model.id;

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
            strSql.Append("delete from " + databaseprefix + "gift ");
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
        public Model.gift GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from " + databaseprefix + "gift ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.gift model = new Model.gift();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.img_url = ds.Tables[0].Rows[0]["img_url"].ToString();
                model.type = ds.Tables[0].Rows[0]["type"].ToString();
                model.article_list = ds.Tables[0].Rows[0]["article_list"].ToString();
                if (ds.Tables[0].Rows[0]["brand_id"].ToString() != "")
                {
                    model.brand_id = int.Parse(ds.Tables[0].Rows[0]["brand_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["quantity"].ToString() != "")
                {
                    model.quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["amount"].ToString() != "")
                {
                    model.amount = decimal.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["left_quantity"].ToString() != "")
                {
                    model.left_quantity = int.Parse(ds.Tables[0].Rows[0]["left_quantity"].ToString());
                }
                model.content = ds.Tables[0].Rows[0]["content"].ToString();
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["company"].ToString() != "")
                {
                    model.company = int.Parse(ds.Tables[0].Rows[0]["company"].ToString());
                }
                model.gift_code = ds.Tables[0].Rows[0]["gift_code"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM " + databaseprefix + "gift ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by sort_id asc,id desc");
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
            strSql.Append(" * ");
            strSql.Append(" FROM " + databaseprefix + "gift ");
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
            strSql.Append("select * FROM " + databaseprefix + "gift");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method

        #region 前台方法
        /// <summary>
        /// 加載購物車贈品
        /// </summary>
        public IList<Model.gift> LoadCartGift(string GoodsList, int quantity, decimal amount, int flag)
        {
            IList<Model.gift> ls = new List<Model.gift>();
            Model.gift model;
            int rowsCount;
            //獲取買就送贈品
            if (!string.IsNullOrEmpty(GoodsList))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select id from " + databaseprefix + "gift ");
                strSql.Append(" where left_quantity>0 and status=1 and article_id in(" + GoodsList + ")");
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                rowsCount = dt.Rows.Count;
                if (rowsCount > 0)
                {
                    for (int n = 0; n < rowsCount; n++)
                    {
                        model = this.GetModel(int.Parse(dt.Rows[n]["id"].ToString()));
                        ls.Add(model);
                    }
                }
            }

            //依據權重（flag）獲取滿件/滿額贈品
            //flag為1時優先贈送滿件模式贈品，flag為2時優先贈送滿額模式贈品
            StringBuilder strSql2 = new StringBuilder();
            if (flag == 1)
            {
                strSql2.Append("select top 1 id from " + databaseprefix + "gift ");
                strSql2.Append(" where quantity<=" + quantity.ToString());
                strSql2.Append(" and status=1 and type=2 and left_quantity>0 and article_id not in(" + GoodsList + ")");
                strSql2.Append(" order by quantity desc");
            }
            else
            {
                strSql2.Append("select top 1 id from " + databaseprefix + "gift ");
                strSql2.Append(" where amount<=" + amount.ToString());
                strSql2.Append(" and status=1 and type=3 and left_quantity>0 and article_id not in(" + GoodsList + ")");
                strSql2.Append(" order by amount desc");
            }
            DataTable dt2 = DbHelperSQL.Query(strSql2.ToString()).Tables[0];
            rowsCount = dt2.Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    model = this.GetModel(int.Parse(dt2.Rows[n]["id"].ToString()));
                    ls.Add(model);
                }
            }

            return ls;
        }
        #endregion Method
    }
}