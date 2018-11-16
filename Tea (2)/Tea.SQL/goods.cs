using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
using Tea.Common;

namespace Tea.DAL
{
    /// <summary>
    /// 数据访问类:商品子件
    /// </summary>
    public partial class goods
    {
        private string databaseprefix; //数据库表名前缀
        public goods(string _databaseprefix)
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
            strSql.Append("select count(1) from " + databaseprefix + "goods");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回库存数量
        /// </summary>
        public int GetStock(int parent_id, string color, string size)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 stock_quantity from " + databaseprefix + "goods");
            strSql.Append(" where id=" + parent_id);
            strSql.Append(" and color='" + color + "'");
            strSql.Append(" and size='" + size + "'");
            int stock = Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
            return stock;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "goods(");
            strSql.Append("parent_id,color,size,market_price,sell_price,stock_quantity,alert_quantity,goods_no,img_url,company,yu_lock,yu_day,yu_num,yu_date,guige,chang,kuan,gao,zhong)");
            strSql.Append(" values (");
            strSql.Append("@parent_id,@color,@size,@market_price,@sell_price,@stock_quantity,@alert_quantity,@goods_no,@img_url,@company,@yu_lock,@yu_day,@yu_num,@yu_date,@guige,@chang,@kuan,@gao,@zhong)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@parent_id", SqlDbType.Int,4),
					new SqlParameter("@color", SqlDbType.NVarChar,56),
					new SqlParameter("@size", SqlDbType.NVarChar,56),
					new SqlParameter("@market_price", SqlDbType.Decimal,5),
					new SqlParameter("@sell_price", SqlDbType.Decimal,5),
					new SqlParameter("@stock_quantity", SqlDbType.Int,4),
					new SqlParameter("@alert_quantity", SqlDbType.Int,4),
					new SqlParameter("@goods_no", SqlDbType.NVarChar,50),
					new SqlParameter("@img_url", SqlDbType.NVarChar,100),
                    new SqlParameter("@company", SqlDbType.Int,4),
                    new SqlParameter("@yu_lock", SqlDbType.Int,4),
                    new SqlParameter("@yu_day", SqlDbType.Int,4),
                    new SqlParameter("@yu_num", SqlDbType.Int,4),
                    new SqlParameter("@yu_date", SqlDbType.DateTime),
                    new SqlParameter("@guige", SqlDbType.NVarChar,128),
                    new SqlParameter("@chang", SqlDbType.Decimal,5),
                    new SqlParameter("@kuan", SqlDbType.Decimal,5),
                    new SqlParameter("@gao", SqlDbType.Decimal,5),
                    new SqlParameter("@zhong", SqlDbType.Decimal,5),};
            parameters[0].Value = model.parent_id;
            parameters[1].Value = model.color;
            parameters[2].Value = model.size;
            parameters[3].Value = model.market_price;
            parameters[4].Value = model.sell_price;
            parameters[5].Value = model.stock_quantity;
            parameters[6].Value = model.alert_quantity;
            parameters[7].Value = model.goods_no;
            parameters[8].Value = model.img_url;
            parameters[9].Value = model.company;
            parameters[10].Value = model.yu_lock;
            parameters[11].Value = model.yu_day;
            parameters[12].Value = model.yu_num;
            parameters[13].Value = model.yu_date;
            parameters[14].Value = model.guige;
            parameters[15].Value = model.chang;
            parameters[16].Value = model.kuan;
            parameters[17].Value = model.gao;
            parameters[18].Value = model.zhong;
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
            strSql.Append("update " + databaseprefix + "goods set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "goods set ");
            strSql.Append("parent_id=@parent_id,");
            strSql.Append("color=@color,");
            strSql.Append("size=@size,");
            strSql.Append("market_price=@market_price,");
            strSql.Append("sell_price=@sell_price,");
            strSql.Append("stock_quantity=@stock_quantity,");
            strSql.Append("alert_quantity=@alert_quantity,");
            strSql.Append("goods_no=@goods_no,");
            strSql.Append("img_url=@img_url,");
            strSql.Append("yu_lock=@yu_lock,");
            strSql.Append("yu_day=@yu_day,");
            strSql.Append("yu_num=@yu_num,");
            strSql.Append("yu_date=@yu_date,");
            strSql.Append("guige=@guige,");
            strSql.Append("chang=@chang,");
            strSql.Append("kuan=@kuan,");
            strSql.Append("gao=@gao,");
            strSql.Append("zhong=@zhong");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@parent_id", SqlDbType.Int,4),
					new SqlParameter("@color", SqlDbType.NVarChar,56),
					new SqlParameter("@size", SqlDbType.NVarChar,56),
					new SqlParameter("@market_price", SqlDbType.Decimal,5),
					new SqlParameter("@sell_price", SqlDbType.Decimal,5),
					new SqlParameter("@stock_quantity", SqlDbType.Int,4),
					new SqlParameter("@alert_quantity", SqlDbType.Int,4),
					new SqlParameter("@goods_no", SqlDbType.NVarChar,50),
					new SqlParameter("@img_url", SqlDbType.NVarChar,100),
                    new SqlParameter("@yu_lock", SqlDbType.Int,4),
                    new SqlParameter("@yu_day", SqlDbType.Int,4),
                    new SqlParameter("@yu_num", SqlDbType.Int,4),
                    new SqlParameter("@yu_date", SqlDbType.DateTime),
                    new SqlParameter("@guige",SqlDbType.NVarChar,128),
                    new SqlParameter("@chang", SqlDbType.Decimal,5),
                    new SqlParameter("@kuan", SqlDbType.Decimal,5),
                    new SqlParameter("@gao", SqlDbType.Decimal,5),
                    new SqlParameter("@zhong", SqlDbType.Decimal,5),
                    new SqlParameter("@id", SqlDbType.Int,4)};

            parameters[0].Value = model.parent_id;
            parameters[1].Value = model.color;
            parameters[2].Value = model.size;
            parameters[3].Value = model.market_price;
            parameters[4].Value = model.sell_price;
            parameters[5].Value = model.stock_quantity;
            parameters[6].Value = model.alert_quantity;
            parameters[7].Value = model.goods_no;
            parameters[8].Value = model.img_url;
            parameters[9].Value = model.yu_lock;
            parameters[10].Value = model.yu_day;
            parameters[11].Value = model.yu_num;
            parameters[12].Value = model.yu_date;
            parameters[13].Value = model.guige;
            parameters[14].Value = model.chang;
            parameters[15].Value = model.kuan;
            parameters[16].Value = model.gao;
            parameters[17].Value = model.zhong;
            parameters[18].Value = model.id;

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
            strSql.Append("delete from " + databaseprefix + "goods ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                //删除商品组合表
                DbHelperSQL.ExecuteSql("delete from " + databaseprefix + "goods_group where goods_id=" + id.ToString());
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
        public Model.goods GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from " + databaseprefix + "goods ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.goods model = new Model.goods();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["parent_id"].ToString() != "")
                {
                    model.parent_id = int.Parse(ds.Tables[0].Rows[0]["parent_id"].ToString());
                }
                model.color = ds.Tables[0].Rows[0]["color"].ToString();
                model.size = ds.Tables[0].Rows[0]["size"].ToString();
                if (ds.Tables[0].Rows[0]["market_price"].ToString() != "")
                {
                    model.market_price = decimal.Parse(ds.Tables[0].Rows[0]["market_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sell_price"].ToString() != "")
                {
                    model.sell_price = decimal.Parse(ds.Tables[0].Rows[0]["sell_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["stock_quantity"].ToString() != "")
                {
                    model.stock_quantity = int.Parse(ds.Tables[0].Rows[0]["stock_quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["alert_quantity"].ToString() != "")
                {
                    model.alert_quantity = int.Parse(ds.Tables[0].Rows[0]["alert_quantity"].ToString());
                }
                model.goods_no = ds.Tables[0].Rows[0]["goods_no"].ToString();
                model.img_url = ds.Tables[0].Rows[0]["img_url"].ToString();
                if (ds.Tables[0].Rows[0]["company"].ToString() != "")
                {
                    model.company = int.Parse(ds.Tables[0].Rows[0]["company"].ToString());
                }
                if (ds.Tables[0].Rows[0]["yu_lock"].ToString() != "")
                {
                    model.yu_lock = int.Parse(ds.Tables[0].Rows[0]["yu_lock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["yu_day"].ToString() != "")
                {
                    model.yu_day = int.Parse(ds.Tables[0].Rows[0]["yu_day"].ToString());
                }
                if (ds.Tables[0].Rows[0]["yu_num"].ToString() != "")
                {
                    model.yu_num = int.Parse(ds.Tables[0].Rows[0]["yu_num"].ToString());
                }
                if (ds.Tables[0].Rows[0]["yu_date"].ToString() != "")
                {
                    model.yu_date = DateTime.Parse(ds.Tables[0].Rows[0]["yu_date"].ToString());
                }
                model.guige = ds.Tables[0].Rows[0]["guige"].ToString();
                if (ds.Tables[0].Rows[0]["chang"].ToString() != "")
                {
                    model.chang = Decimal.Parse(ds.Tables[0].Rows[0]["chang"].ToString());
                }
                if (ds.Tables[0].Rows[0]["kuan"].ToString() != "")
                {
                    model.kuan = Decimal.Parse(ds.Tables[0].Rows[0]["kuan"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gao"].ToString() != "")
                {
                    model.gao = Decimal.Parse(ds.Tables[0].Rows[0]["gao"].ToString());
                }
                if (ds.Tables[0].Rows[0]["zhong"].ToString() != "")
                {
                    model.zhong = Decimal.Parse(ds.Tables[0].Rows[0]["zhong"].ToString());
                }
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
            strSql.Append(" FROM " + databaseprefix + "goods ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM " + databaseprefix + "goods ");
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
            strSql.Append("select a.id as parent_id,a.title,b.id as goods_id,b.color,b.size,b.sell_price FROM " + databaseprefix + "article as a ");
            strSql.Append("left join " + databaseprefix + "goods as b on a.id=b.parent_id");
            if (channel_id > 0)
            {
                strSql.Append(" where a.channel_id=" + channel_id);
            }
            if (category_id > 0)
            {
                if (channel_id > 0)
                {
                    strSql.Append(" and a.category_id in(select id from " + databaseprefix + "article_category where class_list like '%," + category_id + ",%')");
                }
                else
                {
                    strSql.Append(" where a.category_id in(select id from " + databaseprefix + "article_category where class_list like '%," + category_id + ",%')");
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

        #endregion  Method
    }
}