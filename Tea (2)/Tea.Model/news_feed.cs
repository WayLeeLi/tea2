using System;
namespace Tea.Model
{
    #region 訂閱電子報
    /// <summary>
    /// 訂閱電子報實體類
    /// </summary>
    [Serializable]
    public partial class news_feed
    {
        private int _id;
        private string _email = "";
        private DateTime _feed_time = DateTime.Now;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 郵箱
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 訂閱日期
        /// </summary>
        public DateTime feed_time
        {
            set { _feed_time = value; }
            get { return _feed_time; }
        }

    }
    
        #endregion Model
}