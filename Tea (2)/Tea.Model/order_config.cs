using System;
using System.Collections.Generic;
using System.Text;

namespace Tea.Model
{
    /// <summary>
    /// 订单配置信息
    /// </summary>
    [Serializable]
    public class orderconfig
    {
        public orderconfig()
        { }
        private int _maned = 0;
        private int _zhekou = 1;
        private decimal _quanguan = 0;
        private int _yunmian = 0;
        private int _yunfei = 0;
        private DateTime? _mebegin;
        private DateTime? _meend;
        private int _metype = 1;
        private int _zkjin = 1;

        private DateTime? _qgbegin;
        private DateTime? _qgend;
        private int _qgtype = 1;
        private int _quanguanjin = 1;
 
        /// <summary>
        /// 滿額度
        /// </summary>
        public int maned
        {
            get { return _maned; }
            set { _maned = value; }
        }
        /// <summary>
        /// 滿額度折扣
        /// </summary>
        public int zhekou
        {
            get { return _zhekou; }
            set { _zhekou = value; }
        }
        /// <summary>
        /// 全館折扣
        /// </summary>
        public decimal quanguan
        {
            get { return _quanguan; }
            set { _quanguan = value; }
        }
        public int yunmian
        {
            get { return _yunmian; }
            set { _yunmian = value; }
        }
        public int yunfei
        {
            get { return _yunfei; }
            set { _yunfei = value; }
        }

        public DateTime? mebegin
        {
            get { return _mebegin; }
            set { _mebegin = value; }
        }
        public DateTime? meend
        {
            get { return _meend; }
            set { _meend = value; }
        }
        public int metype
        {
            get { return _metype; }
            set { _metype = value; }
        }
        public int zkjin
        {
            get { return _zkjin; }
            set { _zkjin = value; }
        }
        public DateTime? qgbegin
        {
            get { return _qgbegin; }
            set { _qgbegin = value; }
        }
        public DateTime? qgend
        {
            get { return _qgend; }
            set { _qgend = value; }
        }
        public int qgtype
        {
            get { return _qgtype; }
            set { _qgtype = value; }
        }
        public int quanguanjin
        {
            get { return _quanguanjin; }
            set { _quanguanjin = value; }
        }
    }
}
