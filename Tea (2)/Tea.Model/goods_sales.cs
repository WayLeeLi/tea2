using System;
using System.Collections.Generic;
using System.Text;
namespace Tea.Model
{
	/// <summary>
	/// goods_sales:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class goods_sales
	{
		public goods_sales()
		{}
		#region Model
		private int _id;
		private int _main_id=0;
		private int _parent_id=0;
		private int _goods_id=0;
		private string _title="";
		private DateTime? _add_time;
		private int? _company;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int main_id
		{
			set{ _main_id=value;}
			get{return _main_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int goods_id
		{
			set{ _goods_id=value;}
			get{return _goods_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? company
		{
			set{ _company=value;}
			get{return _company;}
		}
		#endregion Model

	}
}

