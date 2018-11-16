using System;
using System.Collections.Generic;
using System.Text;

namespace Tea.Model
{
    /// <summary>
    /// 会员配置信息
    /// </summary>
    [Serializable]
    public class userconfig
    {
        public userconfig()
        { }
 
        private int _pint_mane = 10;
        private decimal _money_pint = 0;
        private int _pint_yong = 0;
        private int _pint_money = 0;

 
        /// <summary>
        /// 
        /// </summary>
        public int pint_mane
        {
            get { return _pint_mane; }
            set { _pint_mane = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal money_pint
        {
            get { return _money_pint; }
            set { _money_pint = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pint_yong
        {
            get { return _pint_yong; }
            set { _pint_yong = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pint_money
        {
            get { return _pint_money; }
            set { _pint_money = value; }
        }
        
    }
}
