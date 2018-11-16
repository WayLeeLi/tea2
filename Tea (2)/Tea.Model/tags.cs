using System;
using System.Collections.Generic;
using System.Text;
namespace Tea.Model
{
	/// <summary>
	/// tags:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tags
	{
		public tags()
		{}
		#region Model
		private int _tags_id;
		private int? _tags_sort;
		private string _tags_name;
		private int? _tags_num;
		private DateTime? _tags_add_date;
		private int? _tags_show;
		private int? _tags_web;
		/// <summary>
		/// 
		/// </summary>
		public int tags_id
		{
			set{ _tags_id=value;}
			get{return _tags_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tags_sort
		{
			set{ _tags_sort=value;}
			get{return _tags_sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tags_name
		{
			set{ _tags_name=value;}
			get{return _tags_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tags_num
		{
			set{ _tags_num=value;}
			get{return _tags_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? tags_add_date
		{
			set{ _tags_add_date=value;}
			get{return _tags_add_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tags_show
		{
			set{ _tags_show=value;}
			get{return _tags_show;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tags_web
		{
			set{ _tags_web=value;}
			get{return _tags_web;}
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

