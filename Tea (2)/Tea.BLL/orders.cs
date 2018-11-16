using System;
using System.Data;
using System.Collections.Generic;
using Tea.Common;

namespace Tea.BLL
{
    /// <summary>
    /// 订单表
    /// </summary>
    public partial class orders
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private DAL.orders dal;
        public orders()
        {
            dal = new DAL.orders(siteConfig.sysdatabaseprefix);
        }

        #region 基本方法================================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        #region 返回訂單狀態=============================
        public string GetOrderStatus(string  _id)
        {
            string _title = string.Empty;
            try
            {
                Model.orders model = new BLL.orders().GetModel(int.Parse(_id));
                switch (model.status)
                {
                    case 1: //如果是線下付款，付款狀態為0，如果是線上付款，付款成功後會自動改變訂單狀態為已確認
                        if (model.payment_status > 0)
                        {
                            _title = "待付款";
                        }
                        else
                        {
                            _title = "待確認";
                        }
                        break;
                    case 2: //如果訂單為已確認狀態，則進入發貨狀態
                        if (model.express_status > 1)
                        {
                            _title = "已發貨";
                        }
                        else
                        {
                            _title = "待發貨";
                        }
                        break;
                    case 3:
                        _title = "交易完成";
                        break;
                    case 4:
                        _title = "已取消";
                        break;
                    case 5:
                        _title = "已作廢";
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
                str = str + dr["goods_no"].ToString() + "/" + dr["spec_text"].ToString() + "/" + dr["quantity"].ToString() + "件<br>";
            }
            return str;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string order_no)
        {
            return dal.Exists(order_no);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.orders model)
        {
            int a= dal.Add(model);
            new Tea.BLL.users().JiSuan(model.user_id);
           
            return a;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.orders model)
        {
            //计算订单总金额:商品总金额+配送费用+支付手续费
            //model.order_amount = model.real_amount + model.express_fee + model.payment_fee + model.invoice_taxes;
            bool b=dal.Update(model);
            new Tea.BLL.users().JiSuan(model.user_id);
           
            return b;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.orders GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 根据订单号返回一个实体
        /// </summary>
        public Model.orders GetModel(string order_no)
        {
            return dal.GetModel(order_no);
        }
        /// <summary>
        /// 根据订单号返回一个实体
        /// </summary>
        public Model.orders GetModelPayCode(string order_pay_code)
        {
            return dal.GetModelPayCode(order_pay_code);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion

        #region 扩展方法================================
        /// <summary>
        /// 返回数据数
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(string order_no, string strValue)
        {
            return dal.UpdateField(order_no, strValue);
        }
        #endregion
    }
}