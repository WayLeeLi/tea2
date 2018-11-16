using System;
using System.Collections.Generic;
using System.Text;

namespace Tea.Model
{
    /// <summary>
    /// 最近瀏覽實體類
    /// </summary>
    [Serializable]
    public partial class view_items
    {
        public view_items()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _img_url;
        private decimal _price = 0M;
        private decimal _sell_price = 0M;
        private DateTime _view_time = DateTime.Now;

        /// <summary>
        /// 商品ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 商品名稱
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
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
        public decimal sell_price
        {
            set { _sell_price = value; }
            get { return _sell_price; }
        }
        /// <summary>
        /// 瀏覽時間
        /// </summary>
        public DateTime view_time
        {
            set { _view_time = value; }
            get { return _view_time; }
        }
        #endregion
    }
}
