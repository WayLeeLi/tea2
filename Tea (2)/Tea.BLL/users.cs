using System;
using System.Data;
using System.Collections.Generic;
using Tea.Common;

namespace Tea.BLL
{
    /// <summary>
    /// �û���Ϣ
    /// </summary>
    public partial class users
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.users dal;
        public users()
        {
            dal = new DAL.users(siteConfig.sysdatabaseprefix);
        }

        #region ��������===================================
        public void JiSuan(int id)
        {
            //if (id > 0)
            //{
            //    Model.users model = GetModel(id);
            //    if (model != null)
            //    {
            //        try
            //        {
            //            //ُ���
            //            int all =Utils.StrToInt(Tea.DBUtility.DbHelperSQL.Query("select sum(value) as c from shop_user_point_log where user_id=" + id + " and islock=1").Tables[0].Rows[0][0].ToString(),0);
            //            int yong = Utils.StrToInt(Tea.DBUtility.DbHelperSQL.Query("select sum(value) as c from shop_user_point_log where user_id=" + id + " and islock=4").Tables[0].Rows[0][0].ToString(), 0);
            //            int ti = Utils.StrToInt(Tea.DBUtility.DbHelperSQL.Query("select sum(value) as c from shop_user_point_log where user_id=" + id + " and islock=3").Tables[0].Rows[0][0].ToString(), 0);
            //            int qu = Utils.StrToInt(Tea.DBUtility.DbHelperSQL.Query("select sum(value) as c from shop_user_point_log where user_id=" + id + " and islock=2").Tables[0].Rows[0][0].ToString(), 0);

            //            model.point = all - yong - ti - qu;
            //        }
            //        catch (Exception eee) { }
            //        try
            //        {
 
            //            //��Ӌ����Fُ���
            //            model.amount = Utils.StrToInt(Tea.DBUtility.DbHelperSQL.Query("select sum(value) as c from shop_user_point_log where user_id=" + id + " and islock=3").Tables[0].Rows[0][0].ToString(), 0); ;
            //        }
            //        catch (Exception eee) { }
            //        try
            //        {
            //            //��Ӌُ����~
            //            model.exp = Utils.StrToInt(Tea.DBUtility.DbHelperSQL.Query("select sum(value) as c from shop_user_point_log where user_id=" + id + " and islock=1").Tables[0].Rows[0][0].ToString(), 0);
            //        }
            //        catch (Exception eee) { }
            //        try
            //        {
                        
            //            //���ӆ�Δ�
            //            model.user_hei = Utils.StrToInt(Tea.DBUtility.DbHelperSQL.Query("select count(id) as c from shop_orders where user_id=" + id + " and status=3").Tables[0].Rows[0][0].ToString(), 0);
            //        }
            //        catch (Exception eee) { }

            //        try
            //        {
            //            //ȡ���Δ�
            //            int quxiao = Utils.StrToInt(Tea.DBUtility.DbHelperSQL.Query("select count(id) as c from shop_orders where user_id=" + id + " and status=4").Tables[0].Rows[0][0].ToString(), 0);
            //            UpdateField(id, "quxiao=" + quxiao + "");
                       
            //        }
            //        catch (Exception eee) { }

            //        try
            //        {
            //            //�˿�Δ�

            //            int tui = Utils.StrToInt(Tea.DBUtility.DbHelperSQL.Query("select count(id) as c from shop_order_tui where user_id=" + id + " and status=3").Tables[0].Rows[0][0].ToString(), 0);
            //            UpdateField(id, "tui="+tui+"");
                       
            //        }
            //        catch (Exception eee) { }
                    
            //    }
            //    Update(model);
            //}
        }
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public string getTitle(string id)
        {
            return dal.getTitle(id);
        }
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����û����Ƿ����
        /// </summary>
        public bool Exists(string user_name)
        {
            return dal.Exists(user_name);
        }

        /// <summary>
        /// ���ͬһIPע����(Сʱ)���Ƿ����
        /// </summary>
        public bool Exists(string reg_ip, int regctrl)
        {
            return dal.Exists(reg_ip, regctrl);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.users model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.users model)
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
        public Model.users GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// �����û������뷵��һ��ʵ��
        /// </summary>
        /// <param name="user_name">�û���(����)</param>
        /// <param name="password">����</param>
        /// <param name="emaillogin">�Ƿ�����������Ϊ��¼</param>
        /// <param name="mobilelogin">�Ƿ������ֻ���Ϊ��¼</param>
        /// <param name="is_encrypt">�Ƿ���Ҫ��������</param>
        /// <returns></returns>
        public Model.users GetModel(string user_name, string password, int emaillogin, int mobilelogin, bool is_encrypt)
        {
            //���һ���Ƿ���Ҫ����
            if (is_encrypt)
            {
                //��ȡ�ø��û��������Կ
                string salt = dal.GetSalt(user_name);
                if (string.IsNullOrEmpty(salt))
                {
                    return null;
                }
                //�����Ľ��м������¸�ֵ
                password = DESEncrypt.Encrypt(password, salt);
            }
            return dal.GetModel(user_name, password, emaillogin, mobilelogin);
        }

        /// <summary>
        /// �����û�������һ��ʵ��
        /// </summary>
        public Model.users GetModel(string user_name)
        {
            return dal.GetModel(user_name);
        }
          /// <summary>
        /// �����û�������һ��ʵ��
        /// </summary>
        public Model.users GetEModel(string user_name)
        {
            return dal.GetEModel(user_name);
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

        #region ��չ����===================================
        /// <summary>
        /// ���Email�Ƿ����
        /// </summary>
        public bool ExistsEmail(string email)
        {
            return dal.ExistsEmail(email);
        }

        /// <summary>
        /// ����ֻ������Ƿ����
        /// </summary>
        public bool ExistsMobile(string mobile)
        {
            return dal.ExistsMobile(mobile);
        }

        /// <summary>
        /// ����һ������û���
        /// </summary>
        public string GetRandomName(int length)
        {
            string temp = Utils.Number(length, true);
            if (Exists(temp))
            {
                return GetRandomName(length);
            }
            return temp;
        }

        /// <summary>
        /// �����û���ȡ��Salt
        /// </summary>
        public string GetSalt(string user_name)
        {
            return dal.GetSalt(user_name);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            return dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// �û�����
        /// </summary>
        public bool Upgrade(int id)
        {
            if (!Exists(id))
            {
                return false;
            }
            Model.users model = GetModel(id);
            Model.user_groups groupModel = new user_groups().GetUpgrade(model.group_id, model.exp);
            if (groupModel == null)
            {
                return false;
            }
            int result = UpdateField(id, "group_id=" + groupModel.id);
            if (result > 0)
            {
                ////���ӻ���
                //if (groupModel.point > 0)
                //{
                //    new BLL.user_point_log().Add(model.id, model.user_name, groupModel.point, "������û���", true,0,0);
                //}
                ////���ӽ��
                //if (groupModel.amount > 0)
                //{
                //    new BLL.user_amount_log().Add(model.id, model.user_name, groupModel.amount, "�������ͽ��");
                //}
            }
            return true;
        }
        #endregion
        
    }
}