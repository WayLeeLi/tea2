using System;
using System.Collections.Generic;
using System.Text;

namespace Tea.Model
{
    /// <summary>
    /// 銷售活動管理
    /// </summary>
    [Serializable]
    public partial class sales
    {
        public sales()
        { }
        #region Model
        private int _id;
        private string _title = "";
        private string _sub_title = "";
        private string _img_url = "";
        private string _type = "";
        private int _quantity = 0;
        private decimal _amount = 0M;
        private DateTime _start_time = DateTime.Now;
        private DateTime? _end_time;
        private int _sort_id = 99;
        private int _status = 0;
        private string _summary = "";
        private string _content;

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
        }        /// <summary>
        /// 副標題
        /// </summary>
        public string sub_title
        {
            set { _sub_title = value; }
            get { return _sub_title; }
        }        /// <summary>
        /// 圖片
        /// </summary>
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        /// <summary>
        /// 活動類型
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
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
        /// 開始時間
        /// </summary>
        public DateTime start_time
        {
            set { _start_time = value; }
            get { return _start_time; }
        }
        /// <summary>
        /// 結束時間
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
        /// <summary>
        /// 狀態
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 內容摘要
        /// </summary>
        public string summary
        {
            set { _summary = value; }
            get { return _summary; }
        }
        /// <summary>
        /// 詳細內容
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
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
