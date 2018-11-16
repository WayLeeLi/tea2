using System;
using System.Data;
using System.Collections.Generic;
using Tea.Common;

namespace Tea.BLL
{
    /// <summary>
    /// �N�ۻ��
    /// </summary>
    public partial class sales
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.sales dal;
        public sales()
        {
            dal = new DAL.sales(siteConfig.sysdatabaseprefix);
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
        /// ���ر�������
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.sales model)
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
        public bool Update(Model.sales model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            Tea.DBUtility.DbHelperSQL.ExecuteSql("update shop_goods set yu_lock=0 where yu_lock="+id+"");
            return dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tea.Model.sales GetModel(int id)
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
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion  Method

        #region  ǰ̨����
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetMenuList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        #endregion  Method
    }
}