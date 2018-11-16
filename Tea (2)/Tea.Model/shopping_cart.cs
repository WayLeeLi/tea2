using System;
using System.Collections.Generic;
using System.Text;

namespace Tea.Model
{
    /// <summary>
    /// 購物車實體類
    /// </summary>
    [Serializable]
    public partial class cart_items
    {
        public cart_items()
        { }
        #region Model
        private int _id;
        private string _key;
        private string _title;
        private string _sub_title;
        private string _img_url;
        private decimal _price = 0M;
        private decimal _user_price = 0M;
        private int _point = 0;
        private int _money_back = 0;
        private int _quantity = 1;
        private int _stock_quantity = 0;
        private string _goods_color;
        private string _goods_size;
        private decimal _zhong = 0;
        private decimal _chang = 0;
        private decimal _kuan = 0;
        private decimal _gao = 0;
        private int _goodsid = 0;
        private string _goods_code = "";
        protected string _by = "";
        protected string _ps = "";
        protected string _psmoney = "";
        protected string _hdcode = "";
        /// <summary>
        /// 商品ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 購物車Key
        /// </summary>
        public string key
        {
            set { _key = value; }
            get { return _key; }
        }
        /// <summary>
        /// 商品名稱
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        public string sub_title
        {
            set { _sub_title = value; }
            get { return _sub_title; }
        }
        /// <summary>
        /// 圖片路徑
        /// </summary>
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        /// <summary>
        /// 銷售單價
        /// </summary>
        public decimal price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 會員單價
        /// </summary>
        public decimal user_price
        {
            set { _user_price = value; }
            get { return _user_price; }
        }
        /// <summary>
        /// 所需/獲得積分
        /// </summary>
        public int point
        {
            set { _point = value; }
            get { return _point; }
        }

        /// <summary>
        /// 獲得回饋金
        /// </summary>
        public int money_back
        {
            set { _money_back = value; }
            get { return _money_back; }
        }
        /// <summary>
        /// 購買數量
        /// </summary>
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
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
        /// 所選顔色
        /// </summary>
        public string goods_color
        {
            set { _goods_color = value; }
            get { return _goods_color; }
        }
        /// <summary>
        /// 所選尺寸
        /// </summary>
        public string goods_size
        {
            set { _goods_size = value; }
            get { return _goods_size; }
        }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal zhong
        {
            set { _zhong = value; }
            get { return _zhong; }
        }
        /// <summary>
        /// 長
        /// </summary>
        public decimal chang
        {
            set { _chang = value; }
            get { return _chang; }
        }
        /// <summary>
        /// 寬
        /// </summary>
        public decimal kuan
        {
            set { _kuan = value; }
            get { return _kuan; }
        }
        /// <summary>
        /// 高
        /// </summary>
        public decimal gao
        {
            set { _gao = value; }
            get { return _gao; }
        }
        public int goodsid
        {
            set { _goodsid = value; }
            get { return _goodsid; }
        }
        public string goods_code
        {
            set { _goods_code = value; }
            get { return _goods_code; }
        }
        public string by
        {
            set { _by = value; }
            get { return _by; }
        }
        public string ps
        {
            set { _ps = value; }
            get { return _ps; }
        }
        public string psmoney
        {
            set { _psmoney = value; }
            get { return _psmoney; }
        }
        public string hdcode
        {
            set { _hdcode = value; }
            get { return _hdcode; }
        }
        private int _sales_id = 0;
        public int sales_id
        {
            set { _sales_id = value; }
            get { return _sales_id; }
        }

        private string _sales_where = "";
        public string sales_where
        {
            set { _sales_where = value; }
            get { return _sales_where; }
        }
        private string _sales_name = "";
        public string sales_name
        {
            set { _sales_name = value; }
            get { return _sales_name; }
        }
        private decimal _sales_money = 0M;
        public decimal sales_money
        {
            set { _sales_money = value; }
            get { return _sales_money; }
        }
        private int _sales_type = 0;
        public int sales_type
        {
            set { _sales_type = value; }
            get { return _sales_type; }
        }
        private string _sales_guizge = "";
        public string sales_guizge
        {
            set { _sales_guizge = value; }
            get { return _sales_guizge; }
        }
        private string _sales_else = "";
        public string sales_else
        {
            set { _sales_else = value; }
            get { return _sales_else; }
        }
        #endregion
    }

    /// <summary>
    /// 購物車屬性類
    /// </summary>
    [Serializable]
    public partial class cart_total
    {
        public cart_total()
        { }
        #region Model
        private int _total_num = 0;
        private int _total_quantity = 0;
        private decimal _payable_amount = 0M;
        private decimal _real_amount = 0M;
        private int _total_point = 0;
        private int _total_moneyback = 0;
        private decimal _total_zhong = 0;
        private decimal _total_chang = 0;
        private decimal _total_kuan = 0;
        private decimal _total_gao = 0;
        private int _total_chao = 0;
        private decimal _total_num_zhe = 0;
        private decimal _total_money_zhe = 0;
        private string _total_num_str ="";
        private string _total_money_str = "";
        protected string _by = "";
        protected string _sales_str = "";
        protected int _brandid = 0;
        protected int _brand_id = 0;
        /// <summary>
        /// 商品種數
        /// </summary>
        public int total_num
        {
            set { _total_num = value; }
            get { return _total_num; }
        }
        /// <summary>
        /// 商品總數量
        /// </summary>
        public int total_quantity
        {
            set { _total_quantity = value; }
            get { return _total_quantity; }
        }
        /// <summary>
        /// 應付商品總金額
        /// </summary>
        public decimal payable_amount
        {
            set { _payable_amount = value; }
            get { return _payable_amount; }
        }
        /// <summary>
        /// 實付商品總金額
        /// </summary>
        public decimal real_amount
        {
            set { _real_amount = value; }
            get { return _real_amount; }
        }
        /// <summary>
        /// 總積分
        /// </summary>
        public int total_point
        {
            set { _total_point = value; }
            get { return _total_point; }
        }
        /// <summary>
        /// 總回饋金
        /// </summary>
        public int total_moneyback
        {
            set { _total_moneyback = value; }
            get { return _total_moneyback; }
        }
        /// <summary>
        /// 總重量
        /// </summary>
        public decimal total_zhong
        {
            set { _total_zhong = value; }
            get { return _total_zhong; }
        }
        /// <summary>
        /// 總長度
        /// </summary>
        public decimal total_chang
        {
            set { _total_chang = value; }
            get { return _total_chang; }
        }
        /// <summary>
        /// 總寬
        /// </summary>
        public decimal total_kuan
        {
            set { _total_kuan = value; }
            get { return _total_kuan; }
        }
        /// <summary>
        /// 總高
        /// </summary>
        public decimal total_gao
        {
            set { _total_gao = value; }
            get { return _total_gao; }
        }
        /// <summary>
        /// 超商
        /// </summary>
        public int total_chao
        {
            set { _total_chao = value; }
            get { return _total_chao; }
        }

        public decimal total_num_zhe
        {
            set { _total_num_zhe = value; }
            get { return _total_num_zhe; }
        }
        public decimal total_money_zhe
        {
            set { _total_money_zhe = value; }
            get { return _total_money_zhe; }
        }
        public string total_num_str
        {
            set { _total_num_str = value; }
            get { return _total_num_str; }
        }
        public string total_money_str
        {
            set { _total_money_str = value; }
            get { return _total_money_str; }
        }
        public string by
        {
            set { _by = value; }
            get { return _by; }
        }
        public string sales_str
        {
            set { _sales_str = value; }
            get { return _sales_str; }
        }
        public int brandid
        {
            set { _brandid = value; }
            get { return _brandid; }
        }
        public int brand_id
        {
            set { _brand_id = value; }
            get { return _brand_id; }
        }
        #endregion
    }
}
