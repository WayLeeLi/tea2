using System;
using System.Data;
using System.Collections.Generic;
using Tea.Common;

namespace Tea.BLL
{
    /// <summary>
    /// ��Ʒ�Ӽ�
    /// </summary>
    public partial class goods
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.goods dal;
        public goods()
        {
            dal = new DAL.goods(siteConfig.sysdatabaseprefix);
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
        /// ���ؿ������
        /// </summary>
        public int GetStock(int id, string color, string size)
        {
            return dal.GetStock(id, color, size);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.goods model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.goods model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tea.Model.goods GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int channel_id, int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(channel_id, category_id, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion  Method
    }
}