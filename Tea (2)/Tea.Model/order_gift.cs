using System;
using System.Collections.Generic;
using System.Text;

namespace Tea.Model
{
    /// <summary>
    /// 訂單贈品
    /// </summary>
    [Serializable]
    public partial class order_gift
    {
        public order_gift()
        { }
        #region Model
        private int _id;
        private int _order_id = 0;
        private int _gift_id = 0;
        private int _company = 0;
        /// <summary>
        /// 主件
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 訂單ID
        /// </summary>
        public int order_id
        {
            set { _order_id = value; }
            get { return _order_id; }
        }
        /// <summary>
        /// 贈品ID
        /// </summary>
        public int gift_id
        {
            set { _gift_id = value; }
            get { return _gift_id; }
        }
        public int company
        {
            set { _company = value; }
            get { return _company; }
        }
        #endregion
    }
}
