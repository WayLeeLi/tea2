<%@ WebHandler Language="C#" CodeBehind="admin_ajax.ashx.cs" Class="Tea.Web.tools.admin_ajax" %>
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;
using Tea.Web.UI;
using Tea.Common;

namespace Tea.Web.tools
{
    /// <summary>
    /// admin_ajax 的摘要說明
    /// </summary>
    public class admin_ajax : IHttpHandler, IRequiresSessionState
    {
        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //系統組態資料
        Model.userconfig userConfig = new BLL.userconfig().loadConfig(); //會員配置資料

        public void ProcessRequest(HttpContext context)
        {
            //檢查管理員是否登入
            if (!new ManagePage().IsAdminLogin())
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"尚未登入或已超時，請登入後操作!\"}");
                return;
            }
            //取得處事類型
            string action = TWRequest.GetQueryString("action");
            switch (action)
            {
                case "username_validate": //驗證用戶名
                    username_validate(context);
                    break;
                case "channel_name_validate": //驗證頻道名稱是否重複
                    channel_name_validate(context);
                    break;

                case "navigation_validate": //驗證導航菜單別名是否重複
                    navigation_validate(context);
                    break;
                case "manager_validate": //驗證管理員用戶名是否重複
                    manager_validate(context);
                    break;
                case "get_navigation_list": //獲取後台導航字串
                    get_navigation_list(context);
                    break;
                case "get_remote_fileinfo": //獲取遠端檔的資訊
                    get_remote_fileinfo(context);
                    break;
                case "edit_order_status": //修改訂單資料和狀態
                    edit_order_status(context);
                    break;
                case "edit_order_tui": //退款
                    edit_order_tui(context);
                    break;
            }
        }

        #region 驗證用戶名是否可用OK============================
        private void username_validate(HttpContext context)
        {
            string username = TWRequest.GetString("param");
            //如果為Null，退出
            if (string.IsNullOrEmpty(username))
            {
                context.Response.Write("{ \"info\":\"用戶名不可為空\", \"status\":\"n\" }");
                return;
            }
            BLL.users bll = new BLL.users();
            //查詢資料庫
            if (!bll.Exists(username.Trim()))
            {
                context.Response.Write("{ \"info\":\"該用戶名可用\", \"status\":\"y\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"該用戶名已被註冊\", \"status\":\"n\" }");
            return;
        }
        #endregion

        #region 驗證頻道名稱是否是否可用========================
        private void channel_name_validate(HttpContext context)
        {
            string channel_name = TWRequest.GetString("param");
            string old_channel_name = TWRequest.GetString("old_channel_name");
            if (string.IsNullOrEmpty(channel_name))
            {
                context.Response.Write("{ \"info\":\"頻道名稱不可為空！\", \"status\":\"n\" }");
                return;
            }
            if (channel_name.ToLower() == old_channel_name.ToLower())
            {
                context.Response.Write("{ \"info\":\"該名稱可使用\", \"status\":\"y\" }");
                return;
            }
            BLL.channel bll = new BLL.channel();
            if (bll.Exists(channel_name))
            {
                context.Response.Write("{ \"info\":\"該名稱已被佔用，請更換！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"該名稱可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 驗證導航菜單別名是否重複========================
        private void navigation_validate(HttpContext context)
        {
            string navname = TWRequest.GetString("param");
            string old_name = TWRequest.GetString("old_name");
            if (string.IsNullOrEmpty(navname))
            {
                context.Response.Write("{ \"info\":\"該導航別名不可為空！\", \"status\":\"n\" }");
                return;
            }
            if (navname.ToLower() == old_name.ToLower())
            {
                context.Response.Write("{ \"info\":\"該導航別名可使用\", \"status\":\"y\" }");
                return;
            }
            //檢查保留的名稱開頭
            if (navname.ToLower().StartsWith("channel_"))
            {
                context.Response.Write("{ \"info\":\"該導航別名系統保留，請更換！\", \"status\":\"n\" }");
                return;
            }
            BLL.navigation bll = new BLL.navigation();
            if (bll.Exists(navname))
            {
                context.Response.Write("{ \"info\":\"該導航別名已被佔用，請更換！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"該導航別名可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 驗證管理員用戶名是否重複========================
        private void manager_validate(HttpContext context)
        {
            string user_name = TWRequest.GetString("param");
            if (string.IsNullOrEmpty(user_name))
            {
                context.Response.Write("{ \"info\":\"請輸入用戶名\", \"status\":\"n\" }");
                return;
            }
            BLL.manager bll = new BLL.manager();
            if (bll.Exists(user_name))
            {
                context.Response.Write("{ \"info\":\"用戶名已被佔用，請更換！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"用戶名可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 獲取後台導航字串==============================
        private void get_navigation_list(HttpContext context)
        {
            Model.manager adminModel = new ManagePage().GetAdminInfo(); //獲得當前登入管理員資訊
            if (adminModel == null)
            {
                return;
            }
            Model.manager_role roleModel = new BLL.manager_role().GetModel(adminModel.role_id); //獲得管理角色資料
            if (roleModel == null)
            {
                return;
            }
            DataTable dt = new BLL.navigation().GetList(0, TWEnums.NavigationEnum.System.ToString(), "1=1");
            this.get_navigation_childs(context, dt, 0, roleModel.role_type, roleModel.manager_role_values);

        }
        private void get_navigation_childs(HttpContext context, DataTable oldData, int parent_id, int role_type, List<Model.manager_role_value> ls)
        {
            DataRow[] dr = oldData.Select("parent_id=" + parent_id);
            bool isWrite = false; //是否輸出開始標籤
            for (int i = 0; i < dr.Length; i++)
            {
                //檢查是否顯示在介面上====================
                bool isActionPass = true;
                if (int.Parse(dr[i]["is_lock"].ToString()) == 1)
                {
                    isActionPass = false;
                }
                //檢查管理員許可權==========================
                if (isActionPass && role_type > 1)
                {
                    string[] actionTypeArr = dr[i]["action_type"].ToString().Split(',');
                    foreach (string action_type_str in actionTypeArr)
                    {
                        //如果存在顯示許可權資源，則檢查是否擁有該許可權
                        if (action_type_str == "Show")
                        {
                            Model.manager_role_value modelt = ls.Find(p => p.nav_name == dr[i]["name"].ToString() && p.action_type == "Show");
                            if (modelt == null)
                            {
                                isActionPass = false;
                            }
                        }
                    }
                }
                //如果沒有該許可權則不顯示
                if (!isActionPass)
                {
                    if (isWrite && i == (dr.Length - 1) && parent_id > 0)
                    {
                        context.Response.Write("</ul>\n");
                    }
                    continue;
                }
                //如果是頂級導航
                if (parent_id == 0)
                {
                    context.Response.Write("<div class=\"list-group\">\n");
                    context.Response.Write("<h1 title=\"" + dr[i]["sub_title"].ToString() + "\">");
                    if (!string.IsNullOrEmpty(dr[i]["icon_url"].ToString().Trim()))
                    {
                        context.Response.Write("<img src=\"" + dr[i]["icon_url"].ToString() + "\" />");
                    }
                    context.Response.Write("</h1>\n");
                    context.Response.Write("<div class=\"list-wrap\">\n");
                    context.Response.Write("<h2>" + dr[i]["title"].ToString() + "<i></i></h2>\n");
                    //調用自身反覆運算
                    this.get_navigation_childs(context, oldData, int.Parse(dr[i]["id"].ToString()), role_type, ls);
                    context.Response.Write("</div>\n");
                    context.Response.Write("</div>\n");
                }
                else //下級導航
                {
                    if (!isWrite)
                    {
                        isWrite = true;
                        context.Response.Write("<ul>\n");
                    }
                    context.Response.Write("<li>\n");
                    context.Response.Write("<a navid=\"" + dr[i]["name"].ToString() + "\"");
                    if (!string.IsNullOrEmpty(dr[i]["link_url"].ToString()))
                    {
                        if (int.Parse(dr[i]["channel_id"].ToString()) > 0)
                        {
                            context.Response.Write(" href=\"" + dr[i]["link_url"].ToString() + "?channel_id=" + dr[i]["channel_id"].ToString() + "\" target=\"mainframe\"");
                        }
                        else
                        {
                            context.Response.Write(" href=\"" + dr[i]["link_url"].ToString() + "\" target=\"mainframe\"");
                        }
                    }
                    if (!string.IsNullOrEmpty(dr[i]["icon_url"].ToString()))
                    {
                        context.Response.Write(" icon=\"" + dr[i]["icon_url"].ToString() + "\"");
                    }
                    context.Response.Write(" target=\"mainframe\">\n");
                    context.Response.Write("<span>" + dr[i]["title"].ToString() + "</span>\n");
                    context.Response.Write("</a>\n");
                    //調用自身反覆運算
                    this.get_navigation_childs(context, oldData, int.Parse(dr[i]["id"].ToString()), role_type, ls);
                    context.Response.Write("</li>\n");

                    if (i == (dr.Length - 1))
                    {
                        context.Response.Write("</ul>\n");
                    }
                }
            }
        }
        #endregion

        #region 獲取遠端檔的資料==============================
        private void get_remote_fileinfo(HttpContext context)
        {
            string filePath = TWRequest.GetFormString("remotepath");
            if (string.IsNullOrEmpty(filePath))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"沒有找到遠端附件地址！\"}");
                return;
            }
            if (!filePath.ToLower().StartsWith("http://"))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"不是遠端附件地址！\"}");
                return;
            }
            try
            {
                HttpWebRequest _request = (HttpWebRequest)WebRequest.Create(filePath);
                HttpWebResponse _response = (HttpWebResponse)_request.GetResponse();
                int fileSize = (int)_response.ContentLength;
                string fileName = filePath.Substring(filePath.LastIndexOf("/") + 1);
                string fileExt = filePath.Substring(filePath.LastIndexOf(".") + 1).ToUpper();
                context.Response.Write("{\"status\": 1, \"msg\": \"獲取遠程檔成功！\", \"name\": \"" + fileName + "\", \"path\": \"" + filePath + "\", \"size\": " + fileSize + ", \"ext\": \"" + fileExt + "\"}");
            }
            catch
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"遠程文件不存在！\"}");
                return;
            }
        }
        #endregion


        #region 發送退貨====================================
        private void edit_order_tui(HttpContext context)
        {
            string order_no = TWRequest.GetString("order_no");
            string edit_type = TWRequest.GetString("edit_type");
            if (order_no == "")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"傳輸參數有誤，無法獲取訂單號！\"}");
                return;
            }

            if (string.IsNullOrEmpty(edit_type))
            {
                BLL.orders bll = new BLL.orders();
                BLL.order_tui bll_tui = new BLL.order_tui();
                Model.orders model = bll.GetModel(order_no);
                Model.order_tui modeltui = bll_tui.GetModel(model.id);

                modeltui.tui_cart = TWRequest.GetFormInt("txtNum", 0);
                modeltui.tui_lock = 1;
                modeltui.tui_begin_date = DateTime.Now;

                if (!bll_tui.Update(modeltui))
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"訂單退貨失敗！\"}");
                    return;
                }
                else
                {
                    context.Response.Write("{\"status\": 1, \"msg\": \"訂單退貨成功！\"}");
                    return;
                }
            }
            else
            {
                BLL.orders bll = new BLL.orders();
                BLL.order_tui bll_tui = new BLL.order_tui();
                Model.orders model = bll.GetModel(order_no);
                Model.order_tui modeltui = bll_tui.GetModel(model.id);


                modeltui.tui_lock = 2;
                modeltui.tui_end_date = DateTime.Now;

                if (!bll_tui.Update(modeltui))
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"訂單退貨失敗！\"}");
                    return;
                }
                else
                {
                    context.Response.Write("{\"status\": 1, \"msg\": \"訂單退貨成功！\"}");
                    return;
                }
            }
        }
        #endregion

        #region 修改訂單資訊和狀態==============================
        private void edit_order_status(HttpContext context)
        {
            //取得管理員登入資料
            Model.manager adminInfo = new Web.UI.ManagePage().GetAdminInfo();
            if (adminInfo == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"未登入或已超時，請重新登入!\"}");
                return;
            }
            //取得訂單配置資料
            Model.orderconfig orderConfig = new BLL.orderconfig().loadConfig();

            string order_no = TWRequest.GetString("order_no");
            string edit_type = TWRequest.GetString("edit_type");
            if (order_no == "")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"傳輸參數有誤，無法獲取訂單號！\"}");
                return;
            }
            if (edit_type == "")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"無法獲取修改訂單類型！\"}");
                return;
            }

            BLL.orders bll = new BLL.orders();
            Model.orders model = bll.GetModel(order_no);
            if (model == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"訂單號不存在或已被刪除！\"}");
                return;
            }
            switch (edit_type.ToLower())
            {
                case "order_confirm": //確認訂單
                    //檢查許可權
                    //if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", TWEnums.ActionEnum.Confirm.ToString()))
                    //{
                    //    context.Response.Write("{\"status\": 0, \"msg\": \"您沒有確認訂單的許可權！\"}");
                    //    return;
                    //}
                    if (model.status > 1)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"訂單已經確認，不能重複處理！\"}");
                        return;
                    }
                    model.status = 2;
                    model.confirm_time = DateTime.Now;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"訂單確認失敗！\"}");
                        return;
                    }

                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, TWEnums.ActionEnum.Confirm.ToString(), "確認訂單號:" + model.order_no); //記錄日誌
                    #region 發送簡訊或郵件============================
                    //try
                    //{
                    //    //取得用戶的郵箱地址
                    //    if (string.IsNullOrEmpty(model.email))
                    //    {
                    //        context.Response.Write("{\"status\": 1, \"msg\": \"訂單確認成功，但無法發送郵件<br/ >該用戶沒有填寫郵箱地址。\"}");
                    //        return;
                    //    }

                    //    string mailTitle = "發貨通知", mailContent = "";
                    //    //發送郵件
                    //    TWMail.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailport, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                    //        siteConfig.emailfrom, model.email, mailTitle, mailContent);
                    //}
                    //catch (Exception eee) { }
                    #endregion
                    context.Response.Write("{\"status\": 1, \"msg\": \"訂單確認成功！\"}");
                    break;
                case "order_payment": //確認付款
                    //檢查許可權
                    //if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", TWEnums.ActionEnum.Confirm.ToString()))
                    //{
                    //    context.Response.Write("{\"status\": 0, \"msg\": \"您沒有確認付款的許可權！\"}");
                    //    return;
                    //}
                    if (model.status > 1 || model.payment_status == 2)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"訂單已確認，不能重複處理！\"}");
                        return;
                    }
                    model.payment_status = 2;
                    model.payment_time = DateTime.Now;
                    model.status = 2;
                    model.confirm_time = DateTime.Now;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"訂單確認付款失敗！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, TWEnums.ActionEnum.Confirm.ToString(), "確認付款訂單號:" + model.order_no); //記錄日誌
                    #region 發送簡訊或郵件
                    //try
                    //{
                    //    //取得用戶的郵箱地址
                    //    if (string.IsNullOrEmpty(model.email))
                    //    {
                    //        context.Response.Write("{\"status\": 1, \"msg\": \"訂單確認成功，但無法發送郵件<br/ >該用戶沒有填寫郵箱地址。\"}");
                    //        return;
                    //    }
                    //    //取得郵件範本內容
                    //    string mailTitle = "發貨通知", mailContent = "";
                    //    //發送郵件
                    //    TWMail.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailport,siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                    //        siteConfig.emailfrom, model.email, mailTitle, mailContent);
                    //}
                    //catch (Exception eee) { }
                    #endregion
                    context.Response.Write("{\"status\": 1, \"msg\": \"訂單確認付款成功！\"}");
                    break;
                case "order_express": //確認發貨
                    //檢查許可權
                    //if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", TWEnums.ActionEnum.Confirm.ToString()))
                    //{
                    //    context.Response.Write("{\"status\": 0, \"msg\": \"您沒有確認發貨的許可權！\"}");
                    //    return;
                    //}
                    if (model.status > 2 || model.express_status == 2)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"訂單已完成或已發貨，不能重複處理！\"}");
                        return;
                    }
                    int express_id = TWRequest.GetFormInt("express_id");
                    string express_no = TWRequest.GetFormString("express_no");
                    string chang = TWRequest.GetFormString("chang");
                    string kuan = TWRequest.GetFormString("kuan");
                    string gao = TWRequest.GetFormString("gao");
                    string zhong = TWRequest.GetFormString("zhong");
                    if (express_id == 0)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"請選擇促銷方式！\"}");
                        return;
                    }
                    model.express_id = express_id;
                    model.express_no = express_no;
                    model.express_status = 2;
                    model.express_time = DateTime.Now;
                    model.order_bao = chang + "|" + kuan + "|" + gao + "|" + zhong;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"訂單發貨失敗！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, TWEnums.ActionEnum.Confirm.ToString(), "確認發貨訂單號:" + model.order_no); //記錄日誌
                    #region 發送簡訊或郵件============================
                    try
                    {
                        if (string.IsNullOrEmpty(model.email))
                        {
                            context.Response.Write("{\"status\": 1, \"msg\": \"訂單確認成功，但無法發送郵件<br/ >該用戶沒有填寫郵箱地址。\"}");
                            return;
                        }
                        //取得郵件範本內容
                        string mailTitle = "發貨通知信", mailContent = "";
                        string url = siteConfig.weburl + "mail/fahuo.aspx?id=" + model.id, ss = "";
                        mailContent = ljd.function.GetPage(url, out ss);
                        //發送郵件
                        TWMail.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailport, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                            siteConfig.emailfrom, model.email, mailTitle, mailContent);
                    }
                    catch (Exception eee) { }
                    #endregion
                    context.Response.Write("{\"status\": 1, \"msg\": \"訂單發貨成功！\"}");
                    break;
                case "order_complete": //完成訂單=========================================
                    //檢查許可權
                    //if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", TWEnums.ActionEnum.All.ToString()))
                    //{
                    //    context.Response.Write("{\"status\": 0, \"msg\": \"您沒有確認完成訂單的許可權！\"}");
                    //    return;
                    //}
                    if (model.status > 2)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"訂單已經完成，不能重複處理！\"}");
                        return;
                    }
                    model.status = 3;
                    model.complete_time = DateTime.Now;

                    try
                    {
                        Tea.DBUtility.DbHelperSQL.Query("update shop_user_point_log set islock=1 where order_id=" + model.id + " and islock=0");
                    }
                    catch (Exception eee) { }

                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"確認訂單完成失敗！\"}");
                        return;
                    }
                    if (model.num > 0)
                    {
                        new Tea.BLL.user_point_log().Add(model.user_id, model.user_name, model.num, "獲得紅利：" + model.order_no, false, model.id, 0);
                        //new Tea.BLL.users().UpdateField(model.user_id, "point=point+" + model.num);
                    }
                    //給會員增加積分檢查升級
                    //if (model.user_id > 0 && model.point > 0)
                    //{
                    //    new BLL.user_point_log().Add(model.user_id, model.user_name, model.point, "購物獲得積分，訂單號：" + model.order_no, true);
                    //}
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, TWEnums.ActionEnum.Confirm.ToString(), "確認交易完成訂單號:" + model.order_no); //記錄日誌
                    #region 發送簡訊或郵件=========================
                    //try
                    //{
                    //    //取得用戶的郵箱地址
                    //    if (string.IsNullOrEmpty(model.email))
                    //    {
                    //        context.Response.Write("{\"status\": 1, \"msg\": \"訂單確認成功，但無法發送郵件<br/ >該用戶沒有填寫郵箱地址。\"}");
                    //        return;
                    //    }
                    //    //取得郵件範本內容
                    //    string mailTitle = "訂單完成通知", mailContent = "";
                    //    string url = siteConfig.weburl + "mail/fahuo.aspx?id=" + model.id, ss = "";
                    //     mailContent = ljd.function.GetPage(url, out ss);
                    //    //發送郵件
                    //    TWMail.sendMail(siteConfig.emailsmtp, siteConfig.emailssl, siteConfig.emailport,siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                    //        siteConfig.emailfrom, model.email, mailTitle, mailContent);
                    //}
                    //catch (Exception eee) { }
                    #endregion
                    context.Response.Write("{\"status\": 1, \"msg\": \"確認訂單完成成功！\"}");
                    break;
                case "order_cancel": //取消訂單==========================================
                    //檢查許可權
                    //if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", TWEnums.ActionEnum.Cancel.ToString()))
                    //{
                    //    context.Response.Write("{\"status\": 0, \"msg\": \"您沒有取消訂單的許可權！\"}");
                    //    return;
                    //}
                    if (model.status > 2)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"訂單已經完成，不能取消訂單！\"}");
                        return;
                    }
                    model.remark = TWRequest.GetFormString("txtdes");
                    model.status = 4;
                    model.confirm_time = System.DateTime.Now;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"取消訂單失敗！\"}");
                        return;
                    }
                    ////扣除購物贈送的積分
                    //if (model.user_id > 0 && model.num > 0)
                    //{
                    //    new BLL.user_point_log().Add(model.user_id, model.user_name, -model.num, "退貨訂單扣除紅利，訂單號：" + model.order_no, false, model.id, 0);

                    //}
                    //new Tea.BLL.users().UpdateField(model.user_id, "point=point+" + -model.num);
                    //退還金額到會員帳戶
                    if (model.user_id > 0 && model.point < 0)
                    {
                        new BLL.user_point_log().Add(model.user_id, model.user_name, Math.Abs(model.point), "退貨訂單返還兌換紅利，訂單號：" + model.order_no, false, model.id, 0);

                    }
                    //new Tea.BLL.users().UpdateField(model.user_id, "point=point+" + Math.Abs(model.point));
                    //退還金額到會員帳戶
                    if (model.user_id > 0 && model.company < 0)
                    {
                        new BLL.user_point_log().Add(model.user_id, model.user_name, Math.Abs(model.company), "退貨訂單返還折扣紅利，訂單號：" + model.order_no, false, model.id, 0);

                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, TWEnums.ActionEnum.Cancel.ToString(), "取消訂單號:" + model.order_no); //記錄日誌
                    context.Response.Write("{\"status\": 1, \"msg\": \"取消訂單成功！\"}");
                    break;
                case "order_invalid": //退貨訂單==========================================
                    //檢查許可權
                    //if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", TWEnums.ActionEnum.Invalid.ToString()))
                    //{
                    //    context.Response.Write("{\"status\": 0, \"msg\": \"您沒有退貨訂單的許可權！\"}");
                    //    return;
                    //}
                    if (model.status != 3)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"訂單尚未完成，不能退貨訂單！\"}");
                        return;
                    }
                    model.status = 5;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"退貨訂單失敗！\"}");
                        return;
                    }
                    int check_revert2 = TWRequest.GetFormInt("check_revert", 1);

                    //扣除購物贈送的積分
                    if (model.user_id > 0 && model.num > 0)
                    {
                        new BLL.user_point_log().Add(model.user_id, model.user_name, -model.num, "退貨訂單扣除紅利，訂單號：" + model.order_no, false, model.id, 0);

                    }
                    //new Tea.BLL.users().UpdateField(model.user_id, "point=point+" + -model.num);
                    //退還金額到會員帳戶
                    if (model.user_id > 0 && model.point < 0)
                    {
                        new BLL.user_point_log().Add(model.user_id, model.user_name, Math.Abs(model.point), "退貨訂單返還兌換紅利，訂單號：" + model.order_no, false, model.id, 0);

                    }
                    //new Tea.BLL.users().UpdateField(model.user_id, "point=point+" + Math.Abs(model.point));
                    //退還金額到會員帳戶
                    if (model.user_id > 0 && model.company < 0)
                    {
                        new BLL.user_point_log().Add(model.user_id, model.user_name, Math.Abs(model.company), "退貨訂單返還折扣紅利，訂單號：" + model.order_no, false, model.id, 0);

                    }

                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, TWEnums.ActionEnum.Invalid.ToString(), "退貨訂單號:" + model.order_no); //記錄日誌
                    context.Response.Write("{\"status\": 1, \"msg\": \"退貨訂單成功！\"}");
                    break;
                case "edit_accept_info": //修改收貨資訊====================================
                    //檢查許可權
                    //if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", TWEnums.ActionEnum.Edit.ToString()))
                    //{
                    //    context.Response.Write("{\"status\": 0, \"msg\": \"您沒有修改收貨資料的許可權！\"}");
                    //    return;
                    //}
                    if (model.express_status == 2)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"訂單已經發貨，不能修改收貨資料！\"}");
                        return;
                    }
                    string accept_name = TWRequest.GetFormString("accept_name");
                    string province = TWRequest.GetFormString("province");
                    string city = TWRequest.GetFormString("city");
                    string area = TWRequest.GetFormString("area");
                    string address = TWRequest.GetFormString("address");
                    string post_code = TWRequest.GetFormString("post_code");
                    string mobile = TWRequest.GetFormString("mobile");
                    string telphone = TWRequest.GetFormString("telphone");
                    string email = TWRequest.GetFormString("email");

                    if (accept_name == "")
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"請填寫收貨人姓名！\"}");
                        return;
                    }
                    if (area == "")
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"請選擇所在地區！\"}");
                        return;
                    }
                    if (address == "")
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"請填寫詳細的送貨地址！\"}");
                        return;
                    }
                    if (mobile == "" && telphone == "")
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"聯絡手機或電話至少填寫一項！\"}");
                        return;
                    }

                    model.accept_name = accept_name;
                    model.area = province + "," + city + "," + area;
                    model.address = address;
                    model.post_code = post_code;
                    model.mobile = mobile;
                    model.telphone = telphone;
                    model.email = email;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"修改收貨人資料失敗！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, TWEnums.ActionEnum.Edit.ToString(), "修改收貨資料，訂單號:" + model.order_no); //記錄日誌
                    context.Response.Write("{\"status\": 1, \"msg\": \"修改收貨人資料成功！\"}");
                    break;
                case "edit_order_remark": //修改訂單備註=================================
                    string remark = TWRequest.GetFormString("remark");
                    if (remark == "")
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"請填寫訂單備註內容！\"}");
                        return;
                    }
                    model.remark = remark;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"修改訂單備註失敗！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, TWEnums.ActionEnum.Edit.ToString(), "修改訂單備註，訂單號:" + model.order_no); //記錄日誌
                    context.Response.Write("{\"status\": 1, \"msg\": \"修改訂單備註成功！\"}");
                    break;
                case "edit_real_amount": //修改商品總金額================================
                    //檢查許可權
                    if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", TWEnums.ActionEnum.Edit.ToString()))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"您沒有修改商品金額的許可權！\"}");
                        return;
                    }
                    if (model.status > 1)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"訂單已經確認，不能修改金額！\"}");
                        return;
                    }
                    decimal real_amount = TWRequest.GetFormDecimal("real_amount", 0);
                    model.real_amount = real_amount;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"修改商品總金額失敗！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, TWEnums.ActionEnum.Edit.ToString(), "修改商品金額，訂單號:" + model.order_no); //記錄日誌
                    context.Response.Write("{\"status\": 1, \"msg\": \"修改商品總金額成功！\"}");
                    break;
                case "edit_express_fee": //修改促銷費用==================================
                    //檢查許可權
                    if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", TWEnums.ActionEnum.Edit.ToString()))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"您沒有促銷費用的許可權！\"}");
                        return;
                    }
                    if (model.status > 1)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"訂單已經確認，不能修改金額！\"}");
                        return;
                    }
                    decimal express_fee = TWRequest.GetFormDecimal("express_fee", 0);
                    model.express_fee = express_fee;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"修改促銷費用失敗！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, TWEnums.ActionEnum.Edit.ToString(), "修改促銷費用，訂單號:" + model.order_no); //記錄日誌
                    context.Response.Write("{\"status\": 1, \"msg\": \"修改促銷費用成功！\"}");
                    break;
                case "edit_payment_fee": //修改支付手續費=================================
                    //檢查許可權
                    if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", TWEnums.ActionEnum.Edit.ToString()))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"您沒有修改支付手續費的許可權！\"}");
                        return;
                    }
                    if (model.status > 1)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"訂單已經確認，不能修改金額！\"}");
                        return;
                    }
                    decimal payment_fee = TWRequest.GetFormDecimal("payment_fee", 0);
                    model.payment_fee = payment_fee;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"修改支付手續費失敗！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, TWEnums.ActionEnum.Edit.ToString(), "修改支付手續費，訂單號:" + model.order_no); //記錄日誌
                    context.Response.Write("{\"status\": 1, \"msg\": \"修改支付手續費成功！\"}");
                    break;
                case "edit_invoice_taxes": //修改發票稅金=================================
                    //檢查許可權
                    if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", TWEnums.ActionEnum.Edit.ToString()))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"您沒有修改發票稅金的許可權！\"}");
                        return;
                    }
                    if (model.status > 1)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"訂單已經確認，不能修改金額！\"}");
                        return;
                    }
                    decimal invoice_taxes = TWRequest.GetFormDecimal("invoice_taxes", 0);
                    model.invoice_taxes = invoice_taxes;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"修改訂單發票稅金失敗！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, TWEnums.ActionEnum.Edit.ToString(), "修改訂單發票稅金，訂單號:" + model.order_no); //記錄日誌
                    context.Response.Write("{\"status\": 1, \"msg\": \"修改發票稅金成功！\"}");
                    break;
            }

        }
        #endregion


        #region 判斷是否登入以及是否開啟靜態====================
        private int get_builder_status()
        {
            //取得管理員登入資料
            Model.manager adminInfo = new Web.UI.ManagePage().GetAdminInfo();
            if (adminInfo == null)
                return -1;
            else if (!new BLL.manager_role().Exists(adminInfo.role_id, "sys_builder_html", TWEnums.ActionEnum.Build.ToString()))
                return -2;
            else if (siteConfig.staticstatus != 2)
                return -3;
            else
                return 1;
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
