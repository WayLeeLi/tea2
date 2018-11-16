using System;
using System.Data;
using System.Collections.Generic;
using Tea.Common;
using Tea.Model;
using System.Text;
using Tea.DBUtility;

namespace Tea.BLL
{
    /// <summary>
    /// quan
    /// </summary>
    public partial class quan
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.quan dal;
        public quan()
        {
            dal = new DAL.quan(siteConfig.sysdatabaseprefix);
        }
        /// <summary>
        /// 發送手機簡訊
        /// </summary>
        /// <param name="mobiles">手機號碼，以英文“,”逗號分隔開</param>
        /// <param name="content">簡訊內容</param>
        /// <param name="pass">簡訊通道1驗證碼通道2廣告通道</param>
        /// <param name="msg">返回提示訊息</param>
        /// <returns>bool</returns>
        public bool Send(string mobiles, DateTime date, int num, string where,string title, out string msg)
        {

            //檢查手機號碼，如果超過2000則分批發送
            int sucCount = 0; //成功送出數量
            string errorMsg = string.Empty; //錯誤消息
            string[] oldMobileArr = mobiles.Split(',');
            int batch = oldMobileArr.Length; //2000條為一批，求出分多少批

            for (int i = 0; i < batch; i++)
            {
                StringBuilder sb = new StringBuilder();
                int sendCount = 0; //發送數量


                string mobile = oldMobileArr[i].Trim();

                sendCount++;
                try
                {
                    Model.quan model = new Model.quan();
                    model.quan_username = mobile;
                    model.quan_user = 1;
                    model.quan_code = ljd.function.RndNumRNG(10);
                    model.quan_end_date = date;
                    model.quan_add_date = System.DateTime.Now;
                    model.quan_lock = 0;
                    model.quan_num = num;
                    model.quan_where = where;
                    model.quan_name = title;
                    Add(model);
                    sucCount += sendCount; //成功數量
                }
                catch
                {

                    //沒有動作
                }



            }

            //返回狀態
            if (sucCount > 0)
            {
                msg = "成功送出" + sucCount + "條，失敗" + (oldMobileArr.Length - sucCount) + "條";
                return true;
            }
            msg = errorMsg;
            return false;
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }
        public int UpdateStatus(string qcode,int oid)
        {
            return DbHelperSQL.ExecuteSql("update dt_quan set quan_lock=1,quan_sort=" + oid + ",quan_date='"+System.DateTime.Now.ToString()+"' where quan_code='" + qcode + "' and quan_lock=0");
        }
        public int getmoney(string qcode)
        {
            int moeny = 0;
            DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select * from dt_quan where quan_code='" + qcode + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                moeny = int.Parse(ds.Tables[0].Rows[0]["quan_num"].ToString().Split('.')[0]);
            }
            return moeny;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int quan_id)
        {
            return dal.Exists(quan_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tea.Model.quan model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Tea.Model.quan model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int quan_id)
        {

            return dal.Delete(quan_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string quan_idlist)
        {
            return dal.DeleteList(quan_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tea.Model.quan GetModel(int quan_id)
        {

            return dal.GetModel(quan_id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tea.Model.quan GetModel(string code)
        {

            return dal.GetModel(code);
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
        public List<Tea.Model.quan> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tea.Model.quan> DataTableToList(DataTable dt)
        {
            List<Tea.Model.quan> modelList = new List<Tea.Model.quan>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tea.Model.quan model;
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
   
    }
}

