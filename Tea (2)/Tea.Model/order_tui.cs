using System;
using System.Collections.Generic;
using System.Text;
namespace Tea.Model
{
	/// <summary>
	/// order_tui:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class order_tui
	{
		public order_tui()
		{}
		#region Model
		private int _tui_id;
		private int? _tui_order;
		private int? _tui_shop;
		private int? _tui_user;
		private int? _tui_state;
		private DateTime? _tui_add_date;
		private int? _tui_type;
		private string _tui_pic;
		private DateTime? _tui_begin_date;
		private DateTime? _tui_end_date;
		private string _tui_content;
		private string _tui_else;
		private int? _tui_admin;
		private string _tui_name;
		private int? _tui_cart;
		private string _tui_username;
		private int? _tui_lock;
		private string _tui_revert;
		/// <summary>
		/// 
		/// </summary>
		public int tui_id
		{
			set{ _tui_id=value;}
			get{return _tui_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tui_order
		{
			set{ _tui_order=value;}
			get{return _tui_order;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tui_shop
		{
			set{ _tui_shop=value;}
			get{return _tui_shop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tui_user
		{
			set{ _tui_user=value;}
			get{return _tui_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tui_state
		{
			set{ _tui_state=value;}
			get{return _tui_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? tui_add_date
		{
			set{ _tui_add_date=value;}
			get{return _tui_add_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tui_type
		{
			set{ _tui_type=value;}
			get{return _tui_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tui_pic
		{
			set{ _tui_pic=value;}
			get{return _tui_pic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? tui_begin_date
		{
			set{ _tui_begin_date=value;}
			get{return _tui_begin_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? tui_end_date
		{
			set{ _tui_end_date=value;}
			get{return _tui_end_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tui_content
		{
			set{ _tui_content=value;}
			get{return _tui_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tui_else
		{
			set{ _tui_else=value;}
			get{return _tui_else;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tui_admin
		{
			set{ _tui_admin=value;}
			get{return _tui_admin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tui_name
		{
			set{ _tui_name=value;}
			get{return _tui_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tui_cart
		{
			set{ _tui_cart=value;}
			get{return _tui_cart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tui_username
		{
			set{ _tui_username=value;}
			get{return _tui_username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tui_lock
		{
			set{ _tui_lock=value;}
			get{return _tui_lock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tui_revert
		{
			set{ _tui_revert=value;}
			get{return _tui_revert;}
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

