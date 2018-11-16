using System;
using System.Collections.Generic;
using System.Text;
namespace Tea.Model
{
	/// <summary>
	/// user_address:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class user_address
	{
		public user_address()
		{}
		#region Model
		private int _address_id=0;
        private int _address_user = 0;
        private string _address_name = "";
        private string _address_shenfen = "";
        private string _address_city = "";
        private string _address_qu = "";
        private string _address_address = "";
        private string _address_tel = "";
        private string _address_mobile = "";
        private string _address_email = "";
        private string _address_zip = "";
        private string _address_qita = "";
        private int _address_lock = 0;
        private DateTime _address_add_date = System.DateTime.Now;
		private int _address_payment=0;
        private int _show = 0;
		private string _wheresql="";
		/// <summary>
		/// 
		/// </summary>
		public int address_id
		{
			set{ _address_id=value;}
			get{return _address_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int address_user
		{
			set{ _address_user=value;}
			get{return _address_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address_name
		{
			set{ _address_name=value;}
			get{return _address_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address_shenfen
		{
			set{ _address_shenfen=value;}
			get{return _address_shenfen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address_city
		{
			set{ _address_city=value;}
			get{return _address_city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address_qu
		{
			set{ _address_qu=value;}
			get{return _address_qu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address_address
		{
			set{ _address_address=value;}
			get{return _address_address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address_tel
		{
			set{ _address_tel=value;}
			get{return _address_tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address_mobile
		{
			set{ _address_mobile=value;}
			get{return _address_mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address_email
		{
			set{ _address_email=value;}
			get{return _address_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address_zip
		{
			set{ _address_zip=value;}
			get{return _address_zip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address_qita
		{
			set{ _address_qita=value;}
			get{return _address_qita;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int address_lock
		{
			set{ _address_lock=value;}
			get{return _address_lock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime address_add_date
		{
			set{ _address_add_date=value;}
			get{return _address_add_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int address_payment
		{
			set{ _address_payment=value;}
			get{return _address_payment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int show
		{
			set{ _show=value;}
			get{return _show;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wheresql
		{
			set{ _wheresql=value;}
			get{return _wheresql;}
		}
		#endregion Model

	}
}

