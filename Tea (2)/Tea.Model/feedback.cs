using System;
using System.Collections.Generic;
using System.Text;
namespace Tea.Model
{
	/// <summary>
	/// feedback:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class feedback
	{
		public feedback()
		{}
		#region Model
		private int _id;
        private string _type;
		private string _title;
		private string _content;
		private string _user_name;
		private string _user_tel;
		private string _user_qq;
		private string _user_email;
		private DateTime _add_time= DateTime.Now;
		private string _reply_content="";
		private DateTime? _reply_time;
		private int _is_lock=0;
        private string _beizhu = "";
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_name
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_tel
		{
			set{ _user_tel=value;}
			get{return _user_tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_qq
		{
			set{ _user_qq=value;}
			get{return _user_qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_email
		{
			set{ _user_email=value;}
			get{return _user_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string reply_content
		{
			set{ _reply_content=value;}
			get{return _reply_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? reply_time
		{
			set{ _reply_time=value;}
			get{return _reply_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_lock
		{
			set{ _is_lock=value;}
			get{return _is_lock;}
		}
        public string beizhu
        {
            set { _beizhu = value; }
            get { return _beizhu; }
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

