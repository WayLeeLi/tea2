using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using Tea.Common;
using Tea.Model;
namespace Tea.BLL
{
    /// <summary>
    /// basic
    /// </summary>
    public partial class basic
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.basic dal;
        public basic()
        {
            dal = new DAL.basic(siteConfig.sysdatabaseprefix);
        }
        protected static bool basic_update_basic = true;
        protected static Hashtable basic_ht_basic = new Hashtable();
        protected static bool basic_picupdate_basic = true;
        protected static Hashtable basic_picht_basic = new Hashtable();
        public virtual string get_basic(string where, string cmid)
        {
            string str = "";

            if (!string.IsNullOrEmpty(cmid) && !string.IsNullOrEmpty(where))
            {
                if (basic_update_basic)
                {
                    basic_ht_basic.Clear();
                    DataSet ds = GetAllList();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        basic_ht_basic.Add(dr["basic_where"].ToString().Trim() + dr["basic_value"].ToString().Trim(), dr["basic_label"].ToString().Trim());
                    }
                    basic_update_basic = false;
                }

                try
                {
                    if (!string.IsNullOrEmpty(cmid))
                    {
                        str = basic_ht_basic[where + cmid].ToString();
                    }
                }
                catch (Exception eee)
                {
                    str = "";
                    basic_update_basic = true;
                }

            }
            return str;

        }
        public virtual string get_picbasic(string where, string cmid)
        {
            string str = "";

            if (!string.IsNullOrEmpty(cmid) && !string.IsNullOrEmpty(where))
            {
                if (basic_picupdate_basic)
                {
                    basic_picht_basic.Clear();
                    DataSet ds = GetAllList();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        basic_picht_basic.Add(dr["basic_where"].ToString().Trim() + dr["basic_value"].ToString().Trim(), dr["basic_pic"].ToString().Trim());
                    }
                    basic_picupdate_basic = false;
                }

                try
                {
                    if (!string.IsNullOrEmpty(cmid))
                    {
                        str = basic_picht_basic[where + cmid].ToString();
                    }
                }
                catch (Exception eee)
                {
                    str = "#";
                    basic_picupdate_basic = true;
                }

            }
            return str;

        }
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int basic_id)
        {
            return dal.Exists(basic_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tea.Model.basic model)
        {
            basic_update_basic = true;
            basic_picupdate_basic = true;
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Tea.Model.basic model)
        {
            basic_update_basic = true;
            basic_picupdate_basic = true;
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int basic_id)
        {
            basic_update_basic = true;
            basic_picupdate_basic = true;
            return dal.Delete(basic_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string basic_idlist)
        {
            basic_update_basic = true;
            basic_picupdate_basic = true;
            return dal.DeleteList(basic_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tea.Model.basic GetModel(int basic_id)
        {

            return dal.GetModel(basic_id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tea.Model.basic GetModel(string basic_label)
        {

            return dal.GetModel(basic_label);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tea.Model.basic> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tea.Model.basic> DataTableToList(DataTable dt)
        {
            List<Tea.Model.basic> modelList = new List<Tea.Model.basic>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tea.Model.basic model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
    }
}

