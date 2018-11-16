using System;
namespace Tea.Model
{
	/// <summary>
	/// dt_chu_goods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class chu_shop_goods
	{
        public chu_shop_goods()
		{}
		#region Model
		private int _chu_id;
		private int? _chu_shop;
		private int? _chu_goods;
		private DateTime? _chu_add_date;
		private DateTime? _chu_begin_date;
		private DateTime? _chu_end_date;
		private string _chu_where;
		private int? _chu_status;
		private string _chu_type;
		private int? _chu_typeid;
		private string _chu_title;
		private int? _chu_sort;
		/// <summary>
		/// 
		/// </summary>
		public int chu_id
		{
			set{ _chu_id=value;}
			get{return _chu_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? chu_shop
		{
			set{ _chu_shop=value;}
			get{return _chu_shop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? chu_goods
		{
			set{ _chu_goods=value;}
			get{return _chu_goods;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? chu_add_date
		{
			set{ _chu_add_date=value;}
			get{return _chu_add_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? chu_begin_date
		{
			set{ _chu_begin_date=value;}
			get{return _chu_begin_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? chu_end_date
		{
			set{ _chu_end_date=value;}
			get{return _chu_end_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string chu_where
		{
			set{ _chu_where=value;}
			get{return _chu_where;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? chu_status
		{
			set{ _chu_status=value;}
			get{return _chu_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string chu_type
		{
			set{ _chu_type=value;}
			get{return _chu_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? chu_typeid
		{
			set{ _chu_typeid=value;}
			get{return _chu_typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string chu_title
		{
			set{ _chu_title=value;}
			get{return _chu_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? chu_sort
		{
			set{ _chu_sort=value;}
			get{return _chu_sort;}
		}
		#endregion Model

	}
}

