using System;
using System.Collections.Generic;

namespace Tea.Model
{
    /// <summary>
    /// 文章主实体类
    /// </summary>
    [Serializable]
    public partial class article
    {
        public article()
        { }
        #region Model
        private int _id;
        private string _wid = string.Empty;
        private int _channel_id = 0;
        private string _channel_name = string.Empty;
        private int _category_id = 0;
        private string _call_index = string.Empty;
        private string _title;
        private string _link_url = string.Empty;
        private string _img_url = string.Empty;
        private string _seo_title = string.Empty;
        private string _seo_keywords = string.Empty;
        private string _seo_description = string.Empty;
        private string _zhaiyao = string.Empty;
        private string _content;
        private int _sort_id = 99;
        private int _click = 0;
        private int _status = 0;
        private int _is_msg = 0;
        private int _is_tui = 0;
        private int _is_can = 0;
        private int _is_zhe = 0;
        private int _is_slide = 0;
        private int _is_sys = 0;
        private string _user_name;
        private DateTime _add_time = DateTime.Now;
        private DateTime? _update_time;
        private int _company = 0;
        private string _wheresql;
        private int _sales_id = 0;
        private int _brand_id = 0;
        private int _team_id = 0;
        private string _more_type;
        private DateTime _begin_time = DateTime.Now;
        private DateTime _end_time = DateTime.Now;
        private DateTime? _xia_date;
        private int _article_id;
        private string _weiid;
        private string _moshi = string.Empty;
        private decimal _market_price = 0M;
        private decimal _sell_price = 0M;
        private int _stock_quantity = 0;
        private int _point = 0;
        private string _goods_no = "";
        private string _sub_title = "";
        private string _shuoming = "";
        private string _zhuyi = "";
        private string _guigemore = "";
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 唯一ID
        /// </summary>
        public string wid
        {
            set { _wid = value; }
            get { return _wid; }
        }
        /// <summary>
        /// 频道ID
        /// </summary>
        public int channel_id
        {
            set { _channel_id = value; }
            get { return _channel_id; }
        }
        /// <summary>
        /// 频道字段名称
        /// </summary>
        public string channel_name
        {
            set { _channel_name = value; }
            get { return _channel_name; }
        }
        /// <summary>
        /// 类别ID
        /// </summary>
        public int category_id
        {
            set { _category_id = value; }
            get { return _category_id; }
        }
        /// <summary>
        /// 调用别名
        /// </summary>
        public string call_index
        {
            set { _call_index = value; }
            get { return _call_index; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 外部链接
        /// </summary>
        public string link_url
        {
            set { _link_url = value; }
            get { return _link_url; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string img_url
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        /// <summary>
        /// SEO标题
        /// </summary>
        public string seo_title
        {
            set { _seo_title = value; }
            get { return _seo_title; }
        }
        /// <summary>
        /// SEO关健字
        /// </summary>
        public string seo_keywords
        {
            set { _seo_keywords = value; }
            get { return _seo_keywords; }
        }
        /// <summary>
        /// SEO描述
        /// </summary>
        public string seo_description
        {
            set { _seo_description = value; }
            get { return _seo_description; }
        }
        /// <summary>
        /// 内容摘要
        /// </summary>
        public string zhaiyao
        {
            set { _zhaiyao = value; }
            get { return _zhaiyao; }
        }
        /// <summary>
        /// 详细内容
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
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
        /// 浏览次数
        /// </summary>
        public int click
        {
            set { _click = value; }
            get { return _click; }
        }
        /// <summary>
        /// 状态0正常1未审核2锁定
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 是否允许评论
        /// </summary>
        public int is_msg
        {
            set { _is_msg = value; }
            get { return _is_msg; }
        }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public int is_tui
        {
            set { _is_tui = value; }
            get { return _is_tui; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public int is_can
        {
            set { _is_can = value; }
            get { return _is_can; }
        }
        /// <summary>
        /// 是否热门
        /// </summary>
        public int is_zhe
        {
            set { _is_zhe = value; }
            get { return _is_zhe; }
        }
        /// <summary>
        /// 是否幻灯片
        /// </summary>
        public int is_slide
        {
            set { _is_slide = value; }
            get { return _is_slide; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int is_sys
        {
            set { _is_sys = value; }
            get { return _is_sys; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? update_time
        {
            set { _update_time = value; }
            get { return _update_time; }
        }
        /// <summary>
        /// 图片相册
        /// </summary>
        private List<article_albums> _albums;
        public List<article_albums> albums
        {
            set { _albums = value; }
            get { return _albums; }
        }
 
        private List<user_group_price> _group_price;
        /// <summary>
        /// 会员组价格
        /// </summary>
        public List<user_group_price> group_price
        {
            set { _group_price = value; }
            get { return _group_price; }
        }

        /// <summary>
        /// 所属用户
        /// </summary>
        public int company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string wheresql
        {
            set { _wheresql = value; }
            get { return _wheresql; }
        }
        /// <summary>
        /// 销售活动
        /// </summary>
        public int sales_id
        {
            set { _sales_id = value; }
            get { return _sales_id; }
        }
        /// <summary>
        /// 品牌
        /// </summary>
        public int brand_id
        {
            set { _brand_id = value; }
            get { return _brand_id; }
        }
        /// <summary>
        /// 隊伍
        /// </summary>
        public int team_id
        {
            set { _team_id = value; }
            get { return _team_id; }
        }
        /// <summary>
        /// 更多分類
        /// </summary>
        public string more_type
        {
            set { _more_type = value; }
            get { return _more_type; }
        }
        public DateTime begin_time
        {
            set { _begin_time = value; }
            get { return _begin_time; }
        }
        public DateTime end_time
        {
            set { _end_time = value; }
            get { return _end_time; }
        }
        private string _color;
        public string color
        {
            set { _color = value; }
            get { return _color; }
        }
        private string _guige;
        public string guige
        {
            set { _guige = value; }
            get { return _guige; }
        }
        private string _tags;
        public string tags
        {
            set { _tags = value; }
            get { return _tags; }
        }
        public DateTime? xia_date
        {
            set { _xia_date = value; }
            get { return _xia_date; }
        }
        ///////////////////////////////分表
        /// <summary>
        /// 分表主id
        /// </summary>
        public int article_id
        {
            set { _article_id = value; }
            get { return _article_id; }
        }
        /// <summary>
        /// 分表唯一ID
        /// </summary>
        public string weiid
        {
            set { _weiid = value; }
            get { return _weiid; }
        }
        /// <summary>
        /// 显示模式-所有分表
        /// </summary>
        public string moshi
        {
            set { _moshi = value; }
            get { return _moshi; }
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
        /// 庫存數量
        /// </summary>
        public int point
        {
            set { _point = value; }
            get { return _point; }
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
        /// 副标题
        /// </summary>
        public string sub_title
        {
            set { _sub_title = value; }
            get { return _sub_title; }
        }
        /// <summary>
        /// 說明
        /// </summary>
        public string shuoming
        {
            set { _shuoming = value; }
            get { return _shuoming; }
        }
        /// <summary>
        /// 規格詳情
        /// </summary>
        public string guigemore
        {
            set { _guigemore = value; }
            get { return _guigemore; }
        }
        /// <summary>
        /// 注意事項
        /// </summary>
        public string zhuyi
        {
            set { _zhuyi = value; }
            get { return _zhuyi; }
        }
 
        #endregion Model

    }
}