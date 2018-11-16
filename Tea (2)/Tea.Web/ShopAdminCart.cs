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
    public partial class AdminCart
    {
        #region 基本增刪改方法====================================
        /// <summary>
        /// 獲得購物車列表
        /// </summary>
        public static IList<Model.cart_items> GetList(int group_id,int uid)
        {
            BLL.goods bllgoods = new BLL.goods();
            BLL.article bll = new BLL.article();
            BLL.user_group_price bll_group = new BLL.user_group_price();
            Tea.Model.users _users = new BLL.users().GetModel(uid);

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
                        modelt.goodsid = modelgoods.id;
                        modelt.goods_code = modelgoods.goods_no;
                        modelt.stock_quantity = modelgoods.stock_quantity;
                        modelt.quantity = item.Value;
                        modelt.sales_id = modelgoods.yu_lock;
                        modelt.by = model.wheresql;
                        modelt.psmoney = model.brand_id.ToString();
                        if (group_id > 0)
                        {
                            if (model.brand_id == 1)
                            {
                                if (_users!=null && _users.group_id == 2)
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
                            if (model.brand_id != 3 && group_id == -1)
                            {
                                if (_users.group_id==1)
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
                    dic[Key] += Quantity;
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
                Utils.WriteCookie("shop_cart_list", "", -43200);
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
        public static void ClearShop(string Key,int uid)
        {
            if (Key == "1")
            {
                foreach (Tea.Model.cart_items item in GetList(-1,uid))
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
                foreach (Tea.Model.cart_items item in GetList(-2,uid))
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
                foreach (Tea.Model.cart_items item in GetList(-3,uid))
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
        public static Model.cart_total GetTotal(int group_id,int uid)
        {
            string by = "", sid1 = "0", gid = "0";
            int  g = 0,  zz = 0;
            decimal zc = 0, k = 0, c = 0;
            Model.cart_total model = new Model.cart_total();
            IList<Model.cart_items> i_List = GetList(group_id,uid);
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
                    model.total_point += modelt.point * modelt.quantity;
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
                        model.brandid = 2;
                    }
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
            int moenynum1 = 0;
            string sales_str = "";

            //滿件
            if (sid1.Length > 2)
            {
                DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select id from shop_sales where id in(" + sid1 + ") and status=1 and datediff(day,start_time,getdate())>=0 and datediff(day,end_time,getdate())<=0  group by id");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int num = zhe_num_jian(group_id, dr["id"].ToString());
                    DataSet d_s = Tea.DBUtility.DbHelperSQL.Query("select top 1 * from shop_goods_sales where main_id=" + dr["id"].ToString() + " and parent_id<=" + num + " order by parent_id desc");
                    if (d_s.Tables[0].Rows.Count > 0)
                    {
                        sales_str = sales_str + "滿" + decimal.Parse(d_s.Tables[0].Rows[0]["parent_id"].ToString()).ToString("0.") + "件減" + d_s.Tables[0].Rows[0]["goods_id"].ToString();// +"|";
                        decimal listm = decimal.Parse(d_s.Tables[0].Rows[0]["goods_id"].ToString());
                        moenynum1 = moenynum1 + int.Parse(listm.ToString("0."));
                    }

                }
            }


            model.by = sid1;
            model.total_moneyback = moenynum1;
      
            model.sales_str = sales_str;
            model.total_num_str = gid;
            return model;
        }

        public static int zhe_num(int group_id, string sid)
        {
            decimal num = 0;
            //Model.cart_total model = new Model.cart_total();
            //IList<Model.cart_items> i_List = GetList(group_id);
            //if (i_List != null)
            //{
            //    foreach (Model.cart_items modelt in i_List)
            //    {
            //        if (modelt.sales_id.ToString() == sid)
            //        {
            //            num = num + (modelt.user_price * modelt.quantity);
            //        }
            //    }
            //}
            return int.Parse(num.ToString("0."));
        }

        public static int zhe_num_jian(int group_id, string sid)
        {
            int num = 0;
            //Model.cart_total model = new Model.cart_total();
            //IList<Model.cart_items> i_List = GetList(group_id);
            //if (i_List != null)
            //{
            //    foreach (Model.cart_items modelt in i_List)
            //    {
            //        if (modelt.sales_id.ToString() == sid)
            //        {
            //            num = num + modelt.quantity;
            //        }
            //    }
            //}
            return num;
        }

        public static string zhe_num_jian_zhe(int group_id, string sid)
        {
            int num = 0;
            decimal moeny = 0;
            //Model.cart_total model = new Model.cart_total();
            //IList<Model.cart_items> i_List = GetList(group_id);
            //if (i_List != null)
            //{
            //    foreach (Model.cart_items modelt in i_List)
            //    {
            //        if (modelt.sales_id.ToString() == sid)
            //        {
            //            num = num + modelt.quantity;
            //            moeny = moeny + (modelt.user_price * modelt.quantity);
            //        }
            //    }
            //}
            return num + "|" + moeny.ToString("0.");
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
            Utils.WriteCookie("shop_cart_list", strValue, 43200); //儲存一個月
        }

        /// <summary>
        /// 獲取cookies
        /// </summary>
        /// <returns></returns>
        private static string GetCookies()
        {
            return Utils.GetCookie("shop_cart_list");
        }

        #endregion
    }

}
