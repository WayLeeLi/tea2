using System;
using System.Collections.Generic;
using System.Text;

namespace Tea.Model
{
    /// <summary>
    /// 赠品管理
    /// </summary>
    [Serializable]
    public partial class gift
    {
        public gift()
        { }
        #region Model
        private int _id;
        private string _title = "";
        private string _img_url = "";
        private string _type = "";
        private string _article_list = "";
        private int _brand_id = 0;
        private int _quantity = 0;
        private decimal _amount = 0M;
        private int _sort_id = 99;
        private int _status = 0;
        private int _left_quantity = 0;
        private string _content;
        private DateTime _add_time = DateTime.Now;
        private string _gift_code = "";
        /// <summary>
        /// 主件
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
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
        /// 圖片
        /// </summary>
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        /// <summary>
        /// 贈送方式
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 主商品列表
        /// </summary>
        public string article_list
        {
            set { _article_list = value; }
            get { return _article_list; }
        }
        /// <summary>
        /// 品牌ID
        /// </summary>
        public int brand_id
        {
            set { _brand_id = value; }
            get { return _brand_id; }
        }
        /// <summary>
        /// 件數
        /// </summary>
        public int quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 金額
        /// </summary>
        public decimal amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// 狀態
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 剩餘數量
        /// </summary>
        public int left_quantity
        {
            set { _left_quantity = value; }
            get { return _left_quantity; }
        }
        /// <summary>
        /// 詳細內容
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 添加時間
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
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
        /// <summary>
        /// 名稱
        /// </summary>
        public string gift_code
        {
            set { _gift_code = value; }
            get { return _gift_code; }
        }
        #endregion
    }
}
