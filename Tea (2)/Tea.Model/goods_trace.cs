using System;
using System.Collections.Generic;
using System.Text;

namespace Tea.Model
{
    /// <summary>
    /// 跟蹤訂單
    /// </summary>
    [Serializable]
    public partial class goods_trace
    {
        public goods_trace()
        { }
        #region Model
        private int _id;
        private int _goods_id;
        private string _goods_color = "";
        private string _goods_size = "";
        private string _user_name = "";
        private DateTime _add_time = DateTime.Now;

        /// <summary>
        /// 主件
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int goods_id
        {
            set { _goods_id = value; }
            get { return _goods_id; }
        }
        /// <summary>
        /// 商品顏色
        /// </summary>
        public string goods_color
        {
            set { _goods_color = value; }
            get { return _goods_color; }
        }
        /// <summary>
        /// 商品尺寸
        /// </summary>
        public string goods_size
        {
            set { _goods_size = value; }
            get { return _goods_size; }
        }
        /// <summary>
        /// 用戶名
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 添加時間
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion
    }
}
