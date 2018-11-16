using System;
using System.Collections.Generic;
using System.Text;
namespace Tea.Model
{
	/// <summary>
	/// guige:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class guige
	{
		public guige()
		{}
		#region Model
		private int _guige_id;
		private string _guige_title;
		private string _guige_content;
		private int? _guige_sort;
		private DateTime? _guige_add_date;
		private int? _guige_web;
		/// <summary>
		/// 
		/// </summary>
		public int guige_id
		{
			set{ _guige_id=value;}
			get{return _guige_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string guige_title
		{
			set{ _guige_title=value;}
			get{return _guige_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string guige_content
		{
			set{ _guige_content=value;}
			get{return _guige_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? guige_sort
		{
			set{ _guige_sort=value;}
			get{return _guige_sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? guige_add_date
		{
			set{ _guige_add_date=value;}
			get{return _guige_add_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? guige_web
		{
			set{ _guige_web=value;}
			get{return _guige_web;}
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

