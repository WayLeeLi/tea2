using System;
namespace Tea.Model
{
    #region 網站banner
    /// <summary>
    /// banner實體類
    /// </summary>
    [Serializable]
    public partial class slide
    {
        private int _id;
        private string _title = "";
        private string _link_url = "";
        private string _img_url = "";
        private int _brand_id = 0;
        private DateTime _start_time = DateTime.Now;
        private DateTime? _end_time;
        private int _sort_id = 99;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 文字描述
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 連結地址
        /// </summary>
        public string link_url
        {
            set { _link_url = value; }
            get { return _link_url; }
        }
        /// <summary>
        /// 圖片地址
        /// </summary>
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        /// <summary>
        /// 所屬品牌
        /// </summary>
        public int brand_id
        {
            set { _brand_id = value; }
            get { return _brand_id; }
        }
        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime start_time
        {
            set { _start_time = value; }
            get { return _start_time; }
        }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime? end_time
        {
            set { _end_time = value; }
            get { return _end_time; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
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
    }
    
        #endregion Model
}
