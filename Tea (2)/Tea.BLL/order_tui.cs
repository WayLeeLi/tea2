using System;
using System.Data;
using System.Collections.Generic;
using Tea.Common;
using Tea.Model;
namespace Tea.BLL
{
	/// <summary>
	/// order_tui
	/// </summary>
	public partial class order_tui
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.order_tui dal;
        public order_tui()
        {
            dal = new DAL.order_tui(siteConfig.sysdatabaseprefix);
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
		public bool Exists(int tui_id)
		{
			return dal.Exists(tui_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tea.Model.order_tui model)
		{
			int a=dal.Add(model);
           
            //new Tea.BLL.users().JiSuan(model.tui_user.Value);
            return a;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Tea.Model.order_tui model)
		{
            bool b=dal.Update(model);
           
            //new Tea.BLL.users().JiSuan(model.tui_user.Value);
            return b;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int tui_id)
		{
            int a = GetModel(tui_id).company;
            bool b = dal.Delete(tui_id);
            return b;
			
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string tui_idlist )
		{
			return dal.DeleteList(tui_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tea.Model.order_tui GetModel(int tui_id)
		{
			
			return dal.GetModel(tui_id);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tea.Model.order_tui GetModelTui(int order_id)
        {

            return dal.GetModelTui(order_id);
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
		public List<Tea.Model.order_tui> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tea.Model.order_tui> DataTableToList(DataTable dt)
		{
			List<Tea.Model.order_tui> modelList = new List<Tea.Model.order_tui>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tea.Model.order_tui model;
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

