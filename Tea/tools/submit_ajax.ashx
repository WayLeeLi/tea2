<%@ WebHandler Language="C#" CodeBehind="submit_ajax.ashx.cs" Class="Tea.Web.tools.submit_ajax" %>
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.SessionState;
using Tea.Web.UI;
using Tea.Common;
using LitJson;

namespace Tea.Web.tools
{
    /// <summary>
    /// AJAX送出處理
    /// </summary>
    public class submit_ajax : IHttpHandler, IRequiresSessionState
    {
        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
        Model.userconfig userConfig = new BLL.userconfig().loadConfig();
        public void ProcessRequest(HttpContext context)
        {
            //取得處事類型
            string action = TWRequest.GetQueryString("action");

            switch (action)
            {

                case "cart_goods_add": //購物車加入商品
                    cart_goods_add(context);
                    break;
                case "cart_goods_update": //購物車修改商品
                    cart_goods_update(context);
                    break;
                case "cart_goods_delete": //購物車刪除商品
                    cart_goods_delete(context);
                    break;
                case "trace_goods_add": //加入我的最愛
                    trace_goods_add(context);
                    break;
            }
        }

        #region 加入我的最愛OK=================================
        private void trace_goods_add(HttpContext context)
        {
            Model.users usermodel = new ShopPage().GetUserInfo();
            if (usermodel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"請登入後操作！\"}");
                return;
            }
            int goods_id = TWRequest.GetFormInt("goods_id", 1);
            string goods_color = TWRequest.GetFormString("goods_color");
            string goods_size = TWRequest.GetFormString("goods_size");
            BLL.goods_trace bll = new BLL.goods_trace();
            if (bll.Exists(goods_id, usermodel.user_name))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"我的最愛已存在此商品，請勿重複添加！\"}");
                return;
            }
            Model.goods_trace model = new Model.goods_trace();
            model.goods_id = goods_id;
            model.goods_color = goods_color;
            model.goods_size = goods_size;
            model.user_name = usermodel.user_name;
            model.add_time = DateTime.Now;
            bll.Add(model);
            context.Response.Write("{\"status\":1, \"msg\":\"商品已成功添加到我的最愛！\"}");
            return;
        }
        #endregion

        #region 購物車加入商品OK===============================
        private void cart_goods_add(HttpContext context)
        {
            string goods_id = TWRequest.GetFormString("goods_id");
            int goods_quantity = TWRequest.GetFormInt("goods_quantity", 1);
            if (goods_id == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"您送出的商品參數有誤！\"}");
                return;
            }
            if (goods_quantity > siteConfig.txt_Da)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"超出最大購買數量！\"}");
                return;
            }
            //查找會員組
            int group_id = 1;
            Model.users groupModel = new Web.UI.ShopPage().GetUserInfo();
            //if (groupModel != null)
            //{
            //    group_id = groupModel.group_id;
            //}
            //統計購物車
            if (!string.IsNullOrEmpty(goods_id))
            {
                int gid = Utils.StrToInt(goods_id.Split('_')[0].ToString(), 0);
                if (gid > 0)
                {
                    if (new BLL.article().GetModel(gid).wheresql == "jiajia")
                    {
                        Web.UI.ShopCart.Add(goods_id + "_1", goods_quantity);
                    }
                    else
                    {
                        Web.UI.ShopCart.Add(goods_id, goods_quantity);
                    }
                }
                else
                {
                    Web.UI.ShopCart.Add(goods_id, goods_quantity);
                }
            }
            Model.cart_total cartModel = Web.UI.ShopCart.GetTotal(group_id);
            context.Response.Write("{\"status\":1, \"msg\":\"商品已成功添加到購物車！\", \"quantity\":" + cartModel.total_quantity + ", \"amount\":" + cartModel.real_amount + "}");
            return;
        }
        #endregion

        #region 修改購物車商品OK===============================
        private void cart_goods_update(HttpContext context)
        {
            string goods_id = TWRequest.GetFormString("goods_id");
            int goods_quantity = TWRequest.GetFormInt("goods_quantity");
            if (goods_id == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"您送出的商品參數有誤！\"}");
                return;
            }
            //if (goods_id.Contains("BUY"))
            //{
            //    int a = Web.UI.ShopCart.Getku1(goods_id);
            //    if (goods_quantity > a)
            //    {
            //        context.Response.Write("{\"status\":0, \"msg\":\"這個商品只剩" + a + "個了！\"}");
            //        return;
            //    }
            //}
            //if (goods_id.Contains("YG"))
            //{
            //    int a = Web.UI.ShopCart.Getku1Yu(goods_id);
            //    if (goods_quantity > a)
            //    {
            //        context.Response.Write("{\"status\":0, \"msg\":\"這個商品只剩" + a + "個了！\"}");
            //        return;
            //    }
            //}
            if (Web.UI.ShopCart.Update(goods_id, goods_quantity))
            {
                context.Response.Write("{\"status\":1, \"msg\":\"商品數量修改成功！\"}");
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"商品數量更改失敗，請檢查操作是否有誤！\"}");
            }
            return;
        }
        #endregion

        #region 刪除購物車商品OK===============================
        private void cart_goods_delete(HttpContext context)
        {
            string goods_id = TWRequest.GetFormString("goods_id");
            if (goods_id == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"您送出的商品參數有誤！\"}");
                return;
            }
            Web.UI.ShopCart.Clear(goods_id);
            context.Response.Write("{\"status\":1, \"msg\":\"商品移除成功！\"}");
            return;
        }
        #endregion



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
