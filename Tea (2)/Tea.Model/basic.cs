using System;
using System.Collections.Generic;
using System.Text;
namespace Tea.Model
{
	/// <summary>
	/// basic:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class basic
	{
		public basic()
		{}
		#region Model
		private int _basic_id;
		private string _basic_label;
		private string _basic_value;
		private int? _basic_sort;
		private int? _basic_show;
		private string _basic_type;
		private string _basic_where;
		private string _basic_pic;
		private decimal? _basic_money;
		private string _basic_content;
		/// <summary>
		/// 
		/// </summary>
		public int basic_id
		{
			set{ _basic_id=value;}
			get{return _basic_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string basic_label
		{
			set{ _basic_label=value;}
			get{return _basic_label;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string basic_value
		{
			set{ _basic_value=value;}
			get{return _basic_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? basic_sort
		{
			set{ _basic_sort=value;}
			get{return _basic_sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? basic_show
		{
			set{ _basic_show=value;}
			get{return _basic_show;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string basic_type
		{
			set{ _basic_type=value;}
			get{return _basic_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string basic_where
		{
			set{ _basic_where=value;}
			get{return _basic_where;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string basic_pic
		{
			set{ _basic_pic=value;}
			get{return _basic_pic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? basic_money
		{
			set{ _basic_money=value;}
			get{return _basic_money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string basic_content
		{
			set{ _basic_content=value;}
			get{return _basic_content;}
		}
		#endregion Model

	}
}

