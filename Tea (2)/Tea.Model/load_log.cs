using System;
using System.Collections.Generic;
using System.Text;
namespace Tea.Model
{
	/// <summary>
	/// load_log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class load_log
	{
		public load_log()
		{}
		#region Model
		private int _log_id;
		private DateTime? _log_add_date;
		private int? _log_shop;
		private string _log_ip;
		private int? _log_num;
		private string _log_where;
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
		public DateTime? log_add_date
		{
			set{ _log_add_date=value;}
			get{return _log_add_date;}
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
		public string log_ip
		{
			set{ _log_ip=value;}
			get{return _log_ip;}
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
		public string log_where
		{
			set{ _log_where=value;}
			get{return _log_where;}
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

