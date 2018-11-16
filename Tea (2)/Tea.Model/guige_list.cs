using System;
using System.Collections.Generic;
using System.Text;
namespace Tea.Model
{
	/// <summary>
	/// guige_list:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class guige_list
	{
		public guige_list()
		{}
		#region Model
		private int _list_id;
		private int? _list_guige;
		private string _list_title;
		private string _list_pic;
		private int? _list_sort;
		private int? _list_web;
		private string _list_content;
		private DateTime? _list_add_date;
		/// <summary>
		/// 
		/// </summary>
		public int list_id
		{
			set{ _list_id=value;}
			get{return _list_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? list_guige
		{
			set{ _list_guige=value;}
			get{return _list_guige;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string list_title
		{
			set{ _list_title=value;}
			get{return _list_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string list_pic
		{
			set{ _list_pic=value;}
			get{return _list_pic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? list_sort
		{
			set{ _list_sort=value;}
			get{return _list_sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? list_web
		{
			set{ _list_web=value;}
			get{return _list_web;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string list_content
		{
			set{ _list_content=value;}
			get{return _list_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? list_add_date
		{
			set{ _list_add_date=value;}
			get{return _list_add_date;}
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

