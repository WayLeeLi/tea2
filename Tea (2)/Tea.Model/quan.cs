using System;
using System.Collections.Generic;
using System.Text;
namespace Tea.Model
{
	/// <summary>
	/// quan:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class quan
	{
		public quan()
		{}
		#region Model
		private int _quan_id;
		private int? _quan_user;
		private string _quan_username;
		private string _quan_name;
		private string _quan_title;
		private int? _quan_lock;
		private DateTime? _quan_add_date;
		private DateTime? _quan_begin_date;
		private DateTime? _quan_end_date;
		private DateTime? _quan_date;
		private string _quan_code;
		private string _quan_pwd;
		private string _quan_where;
		private int? _quan_show;
		private string _quan_type;
		private string _quan_des;
		private int? _quan_sort;
		private string _quan_pic;
		private int? _quan_admin;
		private string _quan_adminname;
		private decimal? _quan_num;
		/// <summary>
		/// 
		/// </summary>
		public int quan_id
		{
			set{ _quan_id=value;}
			get{return _quan_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? quan_user
		{
			set{ _quan_user=value;}
			get{return _quan_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string quan_username
		{
			set{ _quan_username=value;}
			get{return _quan_username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string quan_name
		{
			set{ _quan_name=value;}
			get{return _quan_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string quan_title
		{
			set{ _quan_title=value;}
			get{return _quan_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? quan_lock
		{
			set{ _quan_lock=value;}
			get{return _quan_lock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? quan_add_date
		{
			set{ _quan_add_date=value;}
			get{return _quan_add_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? quan_begin_date
		{
			set{ _quan_begin_date=value;}
			get{return _quan_begin_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? quan_end_date
		{
			set{ _quan_end_date=value;}
			get{return _quan_end_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? quan_date
		{
			set{ _quan_date=value;}
			get{return _quan_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string quan_code
		{
			set{ _quan_code=value;}
			get{return _quan_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string quan_pwd
		{
			set{ _quan_pwd=value;}
			get{return _quan_pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string quan_where
		{
			set{ _quan_where=value;}
			get{return _quan_where;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? quan_show
		{
			set{ _quan_show=value;}
			get{return _quan_show;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string quan_type
		{
			set{ _quan_type=value;}
			get{return _quan_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string quan_des
		{
			set{ _quan_des=value;}
			get{return _quan_des;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? quan_sort
		{
			set{ _quan_sort=value;}
			get{return _quan_sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string quan_pic
		{
			set{ _quan_pic=value;}
			get{return _quan_pic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? quan_admin
		{
			set{ _quan_admin=value;}
			get{return _quan_admin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string quan_adminname
		{
			set{ _quan_adminname=value;}
			get{return _quan_adminname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? quan_num
		{
			set{ _quan_num=value;}
			get{return _quan_num;}
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

