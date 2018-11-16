using System;
using System.Collections.Generic;
using System.Text;
namespace Tea.Model
{
	/// <summary>
	/// ku_log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ku_log
	{
		public ku_log()
		{}
		#region Model
		private int _log_id;
		private int? _log_shop;
		private int? _log_goods;
		private DateTime? _log_add_date;
		private int? _log_num;
		private int? _log_old_num;
		private int? _log_new_num;
		private string _log_where;
		private int? _log_user;
		private string _log_name;
		private string _log_title;
		/// <summary>
		/// 
		/// </summary>
		public int log_id
		{
			set{ _log_id=value;}
			get{return _log_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? log_shop
		{
			set{ _log_shop=value;}
			get{return _log_shop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? log_goods
		{
			set{ _log_goods=value;}
			get{return _log_goods;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? log_add_date
		{
			set{ _log_add_date=value;}
			get{return _log_add_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? log_num
		{
			set{ _log_num=value;}
			get{return _log_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? log_old_num
		{
			set{ _log_old_num=value;}
			get{return _log_old_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? log_new_num
		{
			set{ _log_new_num=value;}
			get{return _log_new_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string log_where
		{
			set{ _log_where=value;}
			get{return _log_where;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? log_user
		{
			set{ _log_user=value;}
			get{return _log_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string log_name
		{
			set{ _log_name=value;}
			get{return _log_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string log_title
		{
			set{ _log_title=value;}
			get{return _log_title;}
		}
        private int _company = 0;
        /// <summary>
        /// 所属用户
        /// </summary>
        public int company
        {
            set { _company = value; }
            get { return _company; }
        }
		#endregion Model

	}
}

