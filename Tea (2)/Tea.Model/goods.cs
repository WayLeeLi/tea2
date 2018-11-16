using System;
using System.Collections.Generic;
using System.Text;

namespace Tea.Model
{
    /// <summary>
    /// 商品子件
    /// </summary>
    [Serializable]
    public partial class goods
    {
        public goods()
        { }
        #region Model
        private int _id;
        private int _parent_id = 0;
        private string _color = "";
        private string _size = "";
        private decimal _market_price = 0M;
        private decimal _sell_price = 0M;
        private int _stock_quantity = 0;
        private int _alert_quantity = 0;
        private string _goods_no = "";
        private string _img_url = "";
        private int _yu_lock = 0;
        private int _yu_day = 0;
        private int _yu_num = 0;
        private DateTime? _yu_date;
        private string _guige = "";
        private decimal _chang = 0;
        private decimal _kuan = 0;
        private decimal _gao = 0;
        private decimal _zhong = 0;
        /// <summary>
        /// 主件
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
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
        /// 市場價格
        /// </summary>
        public decimal market_price
        {
            set { _market_price = value; }
            get { return _market_price; }
        }
        /// <summary>
        /// 銷售價格
        /// </summary>
        public decimal sell_price
        {
            set { _sell_price = value; }
            get { return _sell_price; }
        }
        /// <summary>
        /// 庫存數量
        /// </summary>
        public int stock_quantity
        {
            set { _stock_quantity = value; }
            get { return _stock_quantity; }
        }
        /// <summary>
        /// 預警數量
        /// </summary>
        public int alert_quantity
        {
            set { _alert_quantity = value; }
            get { return _alert_quantity; }
        }
        /// <summary>
        /// 子件編號
        /// </summary>
        public string goods_no
        {
            set { _goods_no = value; }
            get { return _goods_no; }
        }
        /// <summary>
        /// 圖片
        /// </summary>
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
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
        public int yu_lock
        {
            set { _yu_lock = value; }
            get { return _yu_lock; }
        }
        public int yu_day
        {
            set { _yu_day = value; }
            get { return _yu_day; }
        }
        public int yu_num
        {
            set { _yu_num = value; }
            get { return _yu_num; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? yu_date
        {
            set { _yu_date = value; }
            get { return _yu_date; }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string guige
        {
            set { _guige = value; }
            get { return _guige; }
        }
        public decimal chang
        {
            set { _chang = value; }
            get { return _chang; }
        }
        public decimal kuan
        {
            set { _kuan = value; }
            get { return _kuan; }
        }
        public decimal gao
        {
            set { _gao = value; }
            get { return _gao; }
        }
        public decimal zhong
        {
            set { _zhong = value; }
            get { return _zhong; }
        }
        #endregion
    }
}
