using System;
using System.Collections.Generic;
using System.Text;

namespace Tea.Model
{
    /// <summary>
    /// 門市資訊
    /// </summary>
    [Serializable]
    public partial class store
    {
        public store()
        { }
        #region Model
        private int _id;
        private string _title = "";
        private int _area_id = 0;
        private string _brand_id = "";
        private string _address = "";
        private string _tel = "";
        private int _flagship = 0;
        private string _coordinate = "";

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
        /// 區域
        /// </summary>
        public int area_id
        {
            set { _area_id = value; }
            get { return _area_id; }
        }        /// <summary>
        /// 品牌
        /// </summary>
        public string brand_id
        {
            set { _brand_id = value; }
            get { return _brand_id; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 電話
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 是否是旗舰店
        /// </summary>
        public int flagship
        {
            set { _flagship = value; }
            get { return _flagship; }
        }
        /// <summary>
        /// 地圖坐標
        /// </summary>
        public string coordinate
        {
            set { _coordinate = value; }
            get { return _coordinate; }
        }
        #endregion
    }
}
