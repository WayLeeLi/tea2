using System;
using System.Data;
using System.Collections.Generic;
using Tea.Common;

namespace Tea.BLL
{
    /// <summary>
    /// ������
    /// </summary>
    public partial class orders
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private DAL.orders dal;
        public orders()
        {
            dal = new DAL.orders(siteConfig.sysdatabaseprefix);
        }

        #region ��������================================
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        #region ����ӆ�Π�B=============================
        public string GetOrderStatus(string  _id)
        {
            string _title = string.Empty;
            try
            {
                Model.orders model = new BLL.orders().GetModel(int.Parse(_id));
                switch (model.status)
                {
                    case 1: //����Ǿ��¸�������B��0������Ǿ��ϸ������ɹ�����ԄӸ�׃ӆ�Π�B���Ѵ_�J
                        if (model.payment_status > 0)
                        {
                            _title = "������";
                        }
                        else
                        {
                            _title = "���_�J";
                        }
                        break;
                    case 2: //���ӆ�Ξ��Ѵ_�J��B���t�M��l؛��B
                        if (model.express_status > 1)
                        {
                            _title = "�Ѱl؛";
                        }
                        else
                        {
                            _title = "���l؛";
                        }
                        break;
                    case 3:
                        _title = "�������";
                        break;
                    case 4:
                        _title = "��ȡ��";
                        break;
                    case 5:
                        _title = "�����U";
                        break;
                }

            }
            catch (Exception eee) { }
            return _title;
        }
        #endregion
        public string GetTitle(string id)
        {
            string str = "";
            DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select * from shop_order_goods where order_id="+id+"");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                str = str + dr["goods_no"].ToString() + "/" + dr["spec_text"].ToString() + "/" + dr["quantity"].ToString() + "��<br>";
            }
            return str;
        }
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string order_no)
        {
            return dal.Exists(order_no);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.orders model)
        {
            int a= dal.Add(model);
            new Tea.BLL.users().JiSuan(model.user_id);
           
            return a;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.orders model)
        {
            //���㶩���ܽ��:��Ʒ�ܽ��+���ͷ���+֧��������
            //model.order_amount = model.real_amount + model.express_fee + model.payment_fee + model.invoice_taxes;
            bool b=dal.Update(model);
            new Tea.BLL.users().JiSuan(model.user_id);
           
            return b;
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
        public Model.orders GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// ���ݶ����ŷ���һ��ʵ��
        /// </summary>
        public Model.orders GetModel(string order_no)
        {
            return dal.GetModel(order_no);
        }
        /// <summary>
        /// ���ݶ����ŷ���һ��ʵ��
        /// </summary>
        public Model.orders GetModelPayCode(string order_pay_code)
        {
            return dal.GetModelPayCode(order_pay_code);
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

        #endregion

        #region ��չ����================================
        /// <summary>
        /// ����������
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public bool UpdateField(string order_no, string strValue)
        {
            return dal.UpdateField(order_no, strValue);
        }
        #endregion
    }
}