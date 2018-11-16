using System;
using System.Collections.Generic;
using System.Text;

namespace Tea.Model
{
    /// <summary>
    /// 商品組合
    /// </summary>
    [Serializable]
    public partial class goods_group
    {
        public goods_group()
        { }
        #region Model
        private int _id;
        private int _main_id = 0;
        private int _parent_id = 0;
        private int _goods_id = 0;
        private string _title = "";
        private string _color = "";
        private string _size = "";
        private decimal _original_price = 0M;
        private decimal _new_price = 0M;

        /// <summary>
        /// 主件
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 組合主件ID
        /// </summary>
        public int main_id
        {
            set { _main_id = value; }
            get { return _main_id; }
        }
        /// <summary>
        /// 主件ID
        /// </summary>
        public int parent_id
        {
            set { _parent_id = value; }
            get { return _parent_id; }
        }
        /// <summary>
        /// 商品子件ID
        /// </summary>
        public int goods_id
        {
            set { _goods_id = value; }
            get { return _goods_id; }
        }
        /// <summary>
        /// 名稱
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 商品顏色
        /// </summary>
        public string color
        {
            set { _color = value; }
            get { return _color; }
        }
        /// <summary>
        /// 商品尺寸
        /// </summary>
        public string size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 原始價格
        /// </summary>
        public decimal original_price
        {
            set { _original_price = value; }
            get { return _original_price; }
        }
        /// <summary>
        /// 組合價格
        /// </summary>
        public decimal new_price
        {
            set { _new_price = value; }
            get { return _new_price; }
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
        #endregion
    }
}
