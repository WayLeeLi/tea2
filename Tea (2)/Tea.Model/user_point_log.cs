using System;
namespace Tea.Model
{
    /// <summary>
    /// 会员积分日志表
    /// </summary>
    [Serializable]
    public partial class user_point_log
    {
        public user_point_log()
        { }
        #region Model
        private int _id;
        private int _user_id;
        private string _user_name;
        private int _value = 0;
        private string _remark;
        private DateTime _add_time = DateTime.Now;
        private int _order_id = 0;
        private int _islock = 0;
        private string _bank = "";
        private int _show = 0;
        private int _admin_id = 0;
        private DateTime? _admin_time;
        private int _jieyu = 0;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int user_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 增减积分
        /// </summary>
        public int value
        {
            set { _value = value; }
            get { return _value; }
        }
        /// <summary>
        /// 备注说明
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        /// <summary>
        /// 增减积分
        /// </summary>
        public int order_id
        {
            set { _order_id = value; }
            get { return _order_id; }
        }
        /// <summary>
        /// 增减积分
        /// </summary>
        public int islock
        {
            set { _islock = value; }
            get { return _islock; }
        }
        public string bank
        {
            set { _bank = value; }
            get { return _bank; }
        }
        public int show
        {
            set { _show = value; }
            get { return _show; }
        }
        public int admin_id
        {
            set { _admin_id = value; }
            get { return _admin_id; }
        }
        public DateTime? admin_time
        {
            set { _admin_time = value; }
            get { return _admin_time; }
        }
        public int jieyu
        {
            set { _jieyu = value; }
            get { return _jieyu; }
        }
 
        #endregion Model

    }
}