using System;
using System.Data;
using System.Collections.Generic;
using Tea.Common;

namespace Tea.BLL
{
    /// <summary>
    /// ӆ��ٛƷ
    /// </summary>
    public partial class order_gift
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.order_gift dal;
        public order_gift()
        {
            dal = new DAL.order_gift(siteConfig.sysdatabaseprefix);
        }

        #region  ��������
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.order_gift model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// ���ӆ��ٛƷID�б�,�Զ�̖�ָ�
        /// </summary>
        public string GetGiftList(int orderID)
        {
            return dal.GetGiftList(orderID);
        }

        #endregion  Method
    }
}