using System;
using System.Data;
using System.Collections.Generic;
using Tea.Common;
using Tea.Model;
namespace Tea.BLL
{
	/// <summary>
	/// user_address
	/// </summary>
	public partial class user_address
	{
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.user_address dal;
        public user_address()
        {
            dal = new DAL.user_address(siteConfig.sysdatabaseprefix);
        }
		#region  BasicMethod
        public string gettitle(string express_no, string express_id)
        {
            string str = "暫無資料";
            if (express_id == "1")
            {
             
                DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select top 1 address_email,address_shenfen,address_add_date from shop_user_address where address_address='" + express_no + "' order by address_add_date desc");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    str = "<span>" + ds.Tables[0].Rows[0]["address_email"].ToString() + "</span><span>" + ds.Tables[0].Rows[0]["address_shenfen"].ToString() + "</span> <span>" + Utils.StrToDateTime(ds.Tables[0].Rows[0]["address_add_date"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "</span>";
                }
              
            }
            else
            {
                Tea.Model.express model = new Tea.BLL.express().GetModel(Utils.StrToInt(express_id,0));
                if (model != null && !string.IsNullOrEmpty(express_no))
                {
                    str ="<a href='"+model.website.Replace("{express_no}", express_no)+"'  target='_blank'>查看物流</a>";
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
		public bool Exists(int address_id)
		{
			return dal.Exists(address_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tea.Model.user_address model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Tea.Model.user_address model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int address_id)
		{
			
			return dal.Delete(address_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string address_idlist )
		{
			return dal.DeleteList(address_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tea.Model.user_address GetModel(int address_id)
		{
			
			return dal.GetModel(address_id);
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
		public List<Tea.Model.user_address> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tea.Model.user_address> DataTableToList(DataTable dt)
		{
			List<Tea.Model.user_address> modelList = new List<Tea.Model.user_address>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tea.Model.user_address model;
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

