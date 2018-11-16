using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tea.DBUtility;
using Tea.Common;

namespace Tea.DAL
{
    /// <summary>
    /// ���ݷ�����:ӆ��ٛƷ
    /// </summary>
    public partial class order_gift
    {
        private string databaseprefix; //���ݿ����ǰ׺
        public order_gift(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }
        #region ��������
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "order_gift");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.order_gift model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "order_gift(");
            strSql.Append("order_id,gift_id,company)");
            strSql.Append(" values (");
            strSql.Append("@order_id,@gift_id,@company)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@order_id", SqlDbType.Int,4),
					new SqlParameter("@gift_id", SqlDbType.Int,4),
                    new SqlParameter("@company", SqlDbType.Int,4)};
            parameters[0].Value = model.order_id;
            parameters[1].Value = model.gift_id;
            parameters[2].Value = model.company;
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
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "order_gift ");
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
        /// ���ӆ��ٛƷID�б�,�Զ�̖�ָ�
        /// </summary>
        public string GetGiftList(int orderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,gift_id ");
            strSql.Append(" FROM " + databaseprefix + "order_gift ");
            strSql.Append(" where order_id=" + orderID.ToString());
            strSql.Append(" order by id desc");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string returnStr = "0";
                foreach(DataRow dr in dt.Rows) 
                {
                    returnStr += ("," + dr["gift_id"].ToString());
                }
                return returnStr;
            }
            else
            {
                return "0";
            }
        }

        #endregion  Method
    }
}