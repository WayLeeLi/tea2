using System;
using System.Data;
using System.Collections.Generic;
using Tea.Common;
using Tea.Model;
namespace Tea.BLL
{
	/// <summary>
	/// ku_log
	/// </summary>
	public partial class ku_log
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.ku_log dal;
        public ku_log()
        {
            dal = new DAL.ku_log(siteConfig.sysdatabaseprefix);
        }
		#region  BasicMethod

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
		public bool Exists(int log_id)
		{
			return dal.Exists(log_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tea.Model.ku_log model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Tea.Model.ku_log model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int log_id)
		{
			
			return dal.Delete(log_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string log_idlist )
		{
			return dal.DeleteList(log_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tea.Model.ku_log GetModel(int log_id)
		{
			
			return dal.GetModel(log_id);
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tea.Model.ku_log> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tea.Model.ku_log> DataTableToList(DataTable dt)
		{
			List<Tea.Model.ku_log> modelList = new List<Tea.Model.ku_log>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tea.Model.ku_log model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		 
	}
}

