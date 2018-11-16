using System;
using System.Data;
using System.Collections.Generic;
using Tea.Common;
namespace Tea.BLL
{
    /// <summary>
    /// 积分记录日志
    /// </summary>
    public partial class user_point_log
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.user_point_log dal;
        public user_point_log()
        {
            dal = new DAL.user_point_log(siteConfig.sysdatabaseprefix);
        }

        #region 基本方法==============================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }
        /// <summary>
        /// 增加积分及检查升级
        /// </summary>
        /// <param name="user_id">用户ID</param>
        /// <param name="user_name">用户名</param>
        /// <param name="value">积分值可为正负</param>
        /// <param name="remark">备注</param>
        /// <param name="is_upgrade">是否检查升级</param>
        public int Add(int user_id, string user_name, int value, string remark, bool is_upgrade, int order_id, int islock)
        {
            Model.user_point_log model = new Model.user_point_log();
            model.user_id = user_id;
            model.user_name = user_name;
            model.value = value;
            model.remark = remark;
            model.order_id = order_id;
            model.islock = islock;

            int result = dal.Add(model);
            //new Tea.BLL.users().JiSuan(model.user_id);

            //int point = new Tea.BLL.users().GetModel(model.user_id).point;
            //UpdateField(result, "jieyu=" + point + "");

            try
            {
                //購物金
                int all = Utils.StrToInt(Tea.DBUtility.DbHelperSQL.Query("select sum(value) as c from shop_user_point_log where user_id=" + user_id + "").Tables[0].Rows[0][0].ToString(), 0);
                new Tea.BLL.users().UpdateField(user_id, "point=" + all + "");

            }
            catch (Exception eee) { }

            return result;
        }
        public int Add(Model.user_point_log model)
        {

            int result = dal.Add(model);
            new Tea.BLL.users().JiSuan(model.user_id);
            return result;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.user_point_log GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            int c = GetModel(id).user_id;
            bool b = dal.Delete(id);
            new Tea.BLL.users().JiSuan(c);
            return b;
        }

        /// <summary>
        /// 根据删除一条数据
        /// </summary>
        public bool Delete(int id, string user_name)
        {
            int c = GetModel(id).user_id;
            bool b = dal.Delete(id, user_name);
            new Tea.BLL.users().JiSuan(c);
            return b;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion
    }
}