using System;
using System.Collections.Generic;
using System.Text;
namespace Tea.Model
{
    /// <summary>
    /// goods_more_price:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class goods_more_price
    {
        public goods_more_price()
        { }
        #region Model
        private int _id;
        private int? _article_id = 0;
        private int? _goods_id = 0;
        private int? _goods_num = 0;
        private int? _goods_lock = 0;
        private decimal? _price = 0M;
        private int? _more_chu;
        private string _more_title = "";
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? article_id
        {
            set { _article_id = value; }
            get { return _article_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? goods_id
        {
            set { _goods_id = value; }
            get { return _goods_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? goods_num
        {
            set { _goods_num = value; }
            get { return _goods_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? goods_lock
        {
            set { _goods_lock = value; }
            get { return _goods_lock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? more_chu
        {
            set { _more_chu = value; }
            get { return _more_chu; }
        }
        public string more_title
        {
            set { _more_title = value; }
            get { return _more_title; }
        }
        #endregion Model

    }
}

