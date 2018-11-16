using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tea.Common;
using LitJson;

namespace Tea.Web.UI
{
    /// <summary>
    /// 購物車幫助類
    /// </summary>
    public partial class ShopCart
    {
        #region 基本增刪改方法====================================
        /// <summary>
        /// 獲得購物車列表
        /// </summary>
        public static IList<Model.cart_items> GetList(int group_id)
        {
            BLL.goods bllgoods = new BLL.goods();
            BLL.article bll = new BLL.article();
            BLL.user_group_price bll_group = new BLL.user_group_price();
            Tea.Model.users _users = new Tea.Web.UI.UserPage().GetUserInfo();

            IDictionary<string, int> dic = GetCart();
            if (dic != null)
            {
                int hong = 0, lv = 0;

                IList<Model.cart_items> i_List = new List<Model.cart_items>();
                string[] CartKey = new string[2];
                foreach (var item in dic)
                {
                    CartKey = item.Key.Split('_');
                    Model.cart_items modelt = new Model.cart_items();
                    if (CartKey.Length > 1)
                    {
                        Model.article model = bll.GetModel(Convert.ToInt32(CartKey[0]));
                        Model.goods modelgoods = bllgoods.GetModel(Convert.ToInt32(CartKey[1]));

                        if (model == null || modelgoods == null)
                        {
                            continue;
                        }
                        if (model.status != 0)
                        {
                            continue;
                        }
                        if (model.add_time > System.DateTime.Now || modelgoods.stock_quantity < 1)
                        {
                            continue;
                        }
                        if (model.xia_date != null && model.xia_date.Value.AddDays(1) < System.DateTime.Now)
                        {
                            continue;
                        }
                        modelt.ps = model.call_index;
                        modelt.id = model.id;
                        modelt.key = item.Key;
                        modelt.title = model.title;
                        modelt.sub_title = model.sub_title;
                        modelt.img_url = model.img_url;
                        modelt.goods_color = modelgoods.color;
                        modelt.goods_size = modelgoods.size;
                        modelt.zhong = modelgoods.zhong;
                        modelt.chang = modelgoods.chang;
                        modelt.kuan = modelgoods.kuan;
                        modelt.gao = modelgoods.gao;
                        modelt.point = model.point;
                        modelt.price = modelgoods.market_price;
                        modelt.user_price = modelgoods.sell_price;
                        if (modelgoods.yu_lock > 0)
                        {
                            Tea.Model.sales models = new Tea.BLL.sales().GetModel(modelgoods.yu_lock);
                            if (models != null && models.type == "2" && models.status == 1 && models.start_time < System.DateTime.Now && (models.end_time == null || models.end_time > System.DateTime.Now))
                            {
                                modelt.user_price = modelgoods.yu_num;
                            }
                        }
                        modelt.goodsid = modelgoods.id;
                        modelt.goods_code = modelgoods.goods_no;
                        modelt.stock_quantity = modelgoods.stock_quantity;
                        modelt.quantity = item.Value;
                        modelt.sales_id = modelgoods.yu_lock;
                        modelt.by = model.wheresql;
                        modelt.hdcode = model.guige;
                        if (model.is_msg == 0)
                        {
                            modelt.sales_name = "no";
                        }
                        modelt.psmoney = model.brand_id.ToString();
                        if (group_id > 0)
                        {
                            if (model.brand_id == 1)
                            {
                                if (_users != null && _users.group_id == 2)
                                {
                                    Model.user_group_price userPriceModel = bll_group.GetModel(modelt.goodsid, _users.id);
                                    if (userPriceModel != null)
                                    {
                                        modelt.user_price = userPriceModel.price;
                                    }
                                }
                            }
                            i_List.Add(modelt);
                        }
                        else
                        {

                            if (model.brand_id == 1 && group_id == -3)
                            {
                                if (_users != null && _users.group_id == 2)
                                {
                                    Model.user_group_price userPriceModel = bll_group.GetModel(modelt.goodsid, _users.id);
                                    if (userPriceModel != null)
                                    {
                                        modelt.user_price = userPriceModel.price;
                                        modelt.by = "vip";
                                        i_List.Add(modelt);
                                    }
                                }
                            }

                            if (model.brand_id == 3 && group_id == -2)
                            {
                                i_List.Add(modelt);
                            }
                            if (model.brand_id != 3 && group_id == -1 && model.wheresql != "jiajia")
                            {
                                if (_users.group_id == 1)
                                {
                                    i_List.Add(modelt);
                                }
                                else
                                {
                                    Model.user_group_price userPriceModel = bll_group.GetModel(modelt.goodsid, _users.id);
                                    if (userPriceModel == null)
                                    {
                                        i_List.Add(modelt);
                                    }
                                }
                            }
                            try
                            {
                                if (model.wheresql == "jiajia" && group_id == -1 && Convert.ToInt32(CartKey[2]) == 1)
                                {
                                    i_List.Add(modelt);
                                }
                                if (model.wheresql == "jiajia" && group_id == -2 && Convert.ToInt32(CartKey[2]) == 2)
                                {
                                    i_List.Add(modelt);
                                }
                                if (model.wheresql == "jiajia" && group_id == -3 && Convert.ToInt32(CartKey[2]) == 3)
                                {
                                    i_List.Add(modelt);
                                }

                            }
                            catch (Exception eee)
                            {

                            }
                        }
                    }
                }
                return i_List;
            }
            return null;
        }


        /// <summary>
        /// 添加到購物車
        /// </summary>
        public static bool Add(string Key, int Quantity)
        {
            IDictionary<string, int> dic = GetCart();
            if (dic != null)
            {
                if (dic.ContainsKey(Key))
                {
                    dic[Key] = Quantity;
                    AddCookies(JsonMapper.ToJson(dic));
                    return true;
                }
           
            }
            else
            {
                dic = new Dictionary<string, int>();
            }
            //不存在的則新增
            dic.Add(Key, Quantity);
            AddCookies(JsonMapper.ToJson(dic));
            return true;
        }
        public static bool Exists(string Key)
        {
            IDictionary<string, int> dic = GetCart();
            if (dic != null)
            {
                if (dic.ContainsKey(Key))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 更新購物車數量
        /// </summary>
        public static bool Update(string Key, int Quantity)
        {
            if (Quantity == 0)
            {
                Clear(Key);
                return true;
            }
            IDictionary<string, int> dic = GetCart();
            if (dic != null && dic.ContainsKey(Key))
            {
                dic[Key] = Quantity;
                AddCookies(JsonMapper.ToJson(dic));
                return true;
            }
            return false;
        }

        /// <summary>
        /// 移除購物車
        /// </summary>
        /// <param name="Key">主鍵 0為清理所有的購物車資料</param>
        public static void Clear(string Key)
        {
            if (Key == "0")//為0的時候清理全部購物車cookies
            {
                Utils.WriteCookie(TWKeys.COOKIE_SHOPPING_CART, "", -43200);
            }
            else
            {
                IDictionary<string, int> dic = GetCart();
                if (dic != null)
                {
                    dic.Remove(Key);
                    AddCookies(JsonMapper.ToJson(dic));
                }
            }
        }
        public static void ClearShop(string Key)
        {
            if (Key == "1")
            {
                foreach (Tea.Model.cart_items item in GetList(-1))
                {
                    IDictionary<string, int> dic = GetCart();
                    if (dic != null)
                    {
                        dic.Remove(item.key);
                        AddCookies(JsonMapper.ToJson(dic));
                    }
                }
            }
            if (Key == "2")
            {
                foreach (Tea.Model.cart_items item in GetList(-2))
                {
                    IDictionary<string, int> dic = GetCart();
                    if (dic != null)
                    {
                        dic.Remove(item.key);
                        AddCookies(JsonMapper.ToJson(dic));
                    }
                }
            }
            if (Key == "3")
            {
                foreach (Tea.Model.cart_items item in GetList(-3))
                {
                    IDictionary<string, int> dic = GetCart();
                    if (dic != null)
                    {
                        dic.Remove(item.key);
                        AddCookies(JsonMapper.ToJson(dic));
                    }
                }
            }
        }
        #endregion

        #region 擴展方法==========================================
        public static Model.cart_total GetTotal(int group_id)
        {
            string by = "", sid1 = "0", gid = "0";
            int g = 0, zz = 0;
            int a = 0, b = 0;
            decimal zc = 0, k = 0, c = 0;
            Model.cart_total model = new Model.cart_total();
            IList<Model.cart_items> i_List = GetList(group_id);
            if (i_List != null)
            {
                foreach (Model.cart_items modelt in i_List)
                {
                    model.total_num++;
                    model.total_quantity += modelt.quantity;
                    if (modelt.point == 0)
                    {
                        model.payable_amount += modelt.price * modelt.quantity;
                        model.real_amount += modelt.user_price * modelt.quantity;
                    }
                    if (modelt.by == "point")
                    {
                        model.total_point += modelt.point * modelt.quantity;
                    }
                    //model.total_moneyback += modelt.money_back * modelt.quantity;
                    if (modelt.chang > c)
                    {
                        c = modelt.chang;
                        model.total_chang = modelt.chang;
                    }
                    if (modelt.kuan > k)
                    {
                        k = modelt.kuan;
                        model.total_kuan = modelt.kuan;
                    }
                    model.total_gao += modelt.gao * modelt.quantity;
                    model.total_zhong += modelt.zhong * modelt.quantity;




                    if (modelt.point == 0 && modelt.sales_id > 0)
                    {
                        sid1 = sid1 + "," + modelt.sales_id;
                    }
                    gid = gid + "," + modelt.goodsid;

                    if (modelt.psmoney == "2")
                    {
                        IList _list = new ArrayList();
                        if (!_list.Contains(modelt.id))
                        {
                            _list.Add(modelt.id);
                        }
                        if (_list.Count > 0)
                        {
                            model.brand_id = 2;
                        }
                    }

                    if (modelt.sales_name == "no")
                    {
                        a = 1;
                    }
                    if (string.IsNullOrEmpty(modelt.sales_name))
                    {
                        b = 1;
                    }
                }
                if (a == 1)
                {
                    model.brandid = 3;
                }
            }
            zc = model.total_kuan * model.total_gao * model.total_chang;
            decimal zcall = zc / 6000;
            if (zcall > model.total_zhong)
            {
                model.total_num_zhe = zcall;
            }
            else
            {
                model.total_num_zhe = model.total_zhong;
            }
            int moenynum1 = 0, moenynum2 = 0, moenynum3 = 0;
            string sales_str = "";

            //滿件
            if (sid1.Length > 2)
            {
                DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select id from shop_sales where id in(" + sid1 + ") and status=1 and datediff(day,start_time,getdate())>=0 and datediff(day,end_time,getdate())<=0  group by id");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int num = zhe_num_jian(group_id, dr["id"].ToString());
                    decimal pnum = zhe_num_jian_zhe(group_id, dr["id"].ToString());
                    DataSet d_s = Tea.DBUtility.DbHelperSQL.Query("select top 1 * from view_goods_sales where main_id=" + dr["id"].ToString() + " and parent_id<=" + num + " order by parent_id desc");
                    if (d_s.Tables[0].Rows.Count > 0)
                    {
                        //
                        if (d_s.Tables[0].Rows[0]["scompany"].ToString() == "2")
                        {
                            sales_str = sales_str + d_s.Tables[0].Rows[0]["stitle"].ToString() + "&nbsp;滿" + decimal.Parse(d_s.Tables[0].Rows[0]["parent_id"].ToString()).ToString("0.") + "件減" + d_s.Tables[0].Rows[0]["goods_id"].ToString() + "元";// +"|";
                            decimal listm = decimal.Parse(d_s.Tables[0].Rows[0]["goods_id"].ToString());
                            moenynum1 = moenynum1 + int.Parse(listm.ToString("0."));
                        }
                        else
                        {
                            sales_str = sales_str + d_s.Tables[0].Rows[0]["stitle"].ToString() + "&nbsp;滿" + decimal.Parse(d_s.Tables[0].Rows[0]["parent_id"].ToString()).ToString("0.") + "件折扣" + d_s.Tables[0].Rows[0]["goods_id"].ToString() + "%";// +"|";
                            decimal listm = decimal.Parse(d_s.Tables[0].Rows[0]["goods_id"].ToString());
                            moenynum1 = moenynum1 + Utils.StrToInt((pnum * (100-Utils.StrToInt(listm.ToString("0."),0)) / 100).ToString(), 0);

                        }
                    }

                }
            }
            Model.orderconfig oconfig = new BLL.orderconfig().loadConfig();
            if (oconfig.qgbegin < System.DateTime.Now && oconfig.qgend.Value.AddDays(1) > System.DateTime.Now)
            {
                if (oconfig.qgtype == 1 && oconfig.quanguan < 100)
                {
                    moenynum2 = Utils.StrToInt(model.real_amount.ToString("0."), 0) - Utils.StrToInt((model.real_amount * oconfig.quanguan / 100).ToString(), 0);
                }
                if (oconfig.qgtype == 2 && oconfig.quanguanjin > 0)
                {
                    moenynum2 = oconfig.quanguanjin;
                }
            }
            if (model.real_amount > oconfig.maned && oconfig.mebegin < System.DateTime.Now && oconfig.meend.Value.AddDays(1) > System.DateTime.Now)
            {
                if (oconfig.metype == 1 && oconfig.zhekou < 100)
                {
                    moenynum3 = Utils.StrToInt(model.real_amount.ToString("0."), 0) - Utils.StrToInt((model.real_amount * oconfig.zhekou / 100).ToString(), 0);
                }
                if (oconfig.metype == 2 && oconfig.zkjin > 0)
                {
                    moenynum3 = oconfig.zkjin;
                }
            }
            if (moenynum1 > moenynum2 && moenynum1 > moenynum3)
            {
                model.total_moneyback = moenynum1;
                model.sales_str = sales_str;
            }
            if (moenynum2 > moenynum1 && moenynum2 > moenynum3)
            {
                model.total_moneyback = moenynum2;
                if (oconfig.qgtype == 1)
                {
                    sales_str = "全館折扣" + oconfig.quanguan + "%";
                }
                if (oconfig.qgtype == 2)
                {
                    sales_str = "全館折扣" + oconfig.quanguanjin + "元";
                }
                model.sales_str = sales_str;
            }
            if (moenynum3 > moenynum1 && moenynum3 > moenynum2)
            {
                model.total_moneyback = moenynum3;
                if (oconfig.metype == 1)
                {
                    model.sales_str = "滿額折扣滿" + oconfig.maned + "元折扣" + oconfig.zhekou + "%";
                }
                if (oconfig.metype == 2)
                {
                    model.sales_str = "滿額折扣滿" + oconfig.maned + "元折扣" + oconfig.zkjin + "元";
                }
            }
            model.by = sid1;



            model.total_num_str = gid;
            return model;
        }

        public static int zhe_num(int group_id, string sid)
        {
            decimal num = 0;
            Model.cart_total model = new Model.cart_total();
            IList<Model.cart_items> i_List = GetList(group_id);
            if (i_List != null)
            {
                foreach (Model.cart_items modelt in i_List)
                {
                    if (modelt.sales_id.ToString() == sid)
                    {
                        num = num + (modelt.user_price * modelt.quantity);
                    }
                }
            }
            return int.Parse(num.ToString("0."));
        }

        public static int zhe_num_jian(int group_id, string sid)
        {
            int num = 0;
            Model.cart_total model = new Model.cart_total();
            IList<Model.cart_items> i_List = GetList(group_id);
            if (i_List != null)
            {
                foreach (Model.cart_items modelt in i_List)
                {
                    if (modelt.sales_id.ToString() == sid)
                    {
                        num = num + modelt.quantity;
                    }
                }
            }
            return num;
        }

        public static decimal zhe_num_jian_zhe(int group_id, string sid)
        {

            decimal moeny = 0;
            Model.cart_total model = new Model.cart_total();
            IList<Model.cart_items> i_List = GetList(group_id);
            if (i_List != null)
            {
                foreach (Model.cart_items modelt in i_List)
                {
                    if (modelt.sales_id.ToString() == sid)
                    {
                        moeny = moeny + (modelt.user_price * modelt.quantity);
                    }
                }
            }
            return moeny;
        }

        public static string GetCartGoods(int group_id)
        {
            string CartGoodsList = "";
            IDictionary<string, int> dic = GetCart();
            if (dic != null)
            {
                string[] CartKey = new string[4];
                foreach (var item in dic)
                {
                    CartKey = item.Key.Split('@');
                    if (CartKey.Length < 4)
                    {
                        CartGoodsList += CartKey[0] + ",";
                    }
                }
                CartGoodsList = Utils.DelLastComma(CartGoodsList);
            }
            return CartGoodsList;
        }

        public static decimal getprice(string goods, string gid)
        {


            decimal ku = 0;
            try
            {
                DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select new_price from dt_goods_group where main_id=" + goods + " and goods_id=" + gid + "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ku = decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
            }
            catch (Exception eee) { }
            return ku;
        }


        #endregion

        #region 私有方法==========================================
        /// <summary>
        /// 獲取cookies值
        /// </summary>
        private static IDictionary<string, int> GetCart()
        {
            IDictionary<string, int> dic = new Dictionary<string, int>();
            if (!string.IsNullOrEmpty(GetCookies()))
            {
                return JsonMapper.ToObject<Dictionary<string, int>>(GetCookies());
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 添加對象到cookies
        /// </summary>
        /// <param name="strValue"></param>
        private static void AddCookies(string strValue)
        {
            Utils.WriteCookie(TWKeys.COOKIE_SHOPPING_CART, strValue, 43200); //儲存一個月
        }

        /// <summary>
        /// 獲取cookies
        /// </summary>
        /// <returns></returns>
        private static string GetCookies()
        {
            return Utils.GetCookie(TWKeys.COOKIE_SHOPPING_CART);
        }

        #endregion
    }

}
