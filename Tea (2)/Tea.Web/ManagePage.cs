using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.UI
{
    public class ManagePage : System.Web.UI.Page
    {
        protected internal Model.userconfig uconfig = new BLL.userconfig().loadConfig();
        protected internal Model.siteconfig siteConfig;
        protected string domain = ".uartu.com";
        protected internal string title, keyword, describe;
        protected string weburl = "http://" + ljd.function.GetHomeUrl() + "/";
        public ManagePage()
        {
            this.Load += new EventHandler(ManagePage_Load);
            siteConfig = new BLL.siteconfig().loadConfig();
            weburl = siteConfig.weburl;
            title = siteConfig.webname;
            keyword = siteConfig.webname;
            describe = siteConfig.webname;
        }

        private void ManagePage_Load(object sender, EventArgs e)
        {
            //判斷管理員是否登入
            if (!IsAdminLogin())
            {
                Response.Write("<script>parent.location.href='" + siteConfig.webpath + siteConfig.webmanagepath + "/login.aspx'</script>");
                Response.End();
            }
        }

        #region 管理員============================================
        /// <summary>
        /// 判斷管理員是否已經登錄(解決Session超時問題)
        /// </summary>
        public bool IsAdminLogin()
        {
            //如果Session為Null
            if (Session[TWKeys.SESSION_ADMIN_INFO] != null)
            {
                return true;
            }
            else
            {
                //檢查Cookies
                string adminname = Utils.GetCookie("AdminName", "Tea");
                string adminpwd = Utils.GetCookie("AdminPwd", "Tea");
                if (adminname != "" && adminpwd != "")
                {
                    BLL.manager bll = new BLL.manager();
                    Model.manager model = bll.GetModel(adminname, adminpwd);
                    if (model != null)
                    {
                        Session[TWKeys.SESSION_ADMIN_INFO] = model;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 取得管理員資訊
        /// </summary>
        public Model.manager GetAdminInfo()
        {
            if (IsAdminLogin())
            {
                Model.manager model = Session[TWKeys.SESSION_ADMIN_INFO] as Model.manager;
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }

        /// <summary>
        /// 檢查管理員許可權
        /// </summary>
        /// <param name="nav_name">菜單名稱</param>
        /// <param name="action_type">操作類型</param>
        public bool ChkAdminLevel(string nav_name, string action_type)
        {
            Model.manager model = GetAdminInfo();
            BLL.manager_role bll = new BLL.manager_role();
            bool result = bll.Exists(model.role_id, nav_name, action_type);
            return result;
            //if (!result)
            //{
            //    string msgbox = "parent.jsdialog(\"錯誤提示\", \"您沒有管理該頁面的許可權，無法進入！\", \"back\")";
            //    Response.Write("<script type=\"text/javascript\">" + msgbox + "</script>");
            //    Response.End();
            //}
        }
        public void ChkAdminLevelEdit(string nav_name, string action_type)
        {
            Model.manager model = GetAdminInfo();
            BLL.manager_role bll = new BLL.manager_role();
            bool result = bll.Exists(model.role_id, nav_name, action_type);
            if (!result)
            {
                string msgbox = "parent.jsdialog(\"錯誤提示\", \"您沒有管理該頁面的操作許可權，無法操作！\", \"back\")";
                Response.Write("<script type=\"text/javascript\">" + msgbox + "</script>");
                Response.End();
            }
        }
        /// <summary>
        /// 寫入管理日誌
        /// </summary>
        /// <param name="action_type"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public bool AddAdminLog(string action_type, string remark)
        {
            if (siteConfig.logstatus > 0)
            {
                Model.manager model = GetAdminInfo();
                int newId = new BLL.manager_log().Add(model.id, model.user_name, action_type, remark);
                if (newId > 0)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region JS提示============================================
        /// <summary>
        /// 添加編輯刪除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        protected void JscriptMsg(string msgtitle, string url)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }
        /// <summary>
        /// 帶回傳函數的添加編輯刪除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="callback">JS回呼函數</param>
        protected void JscriptMsg(string msgtitle, string url, string callback)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", " + callback + ")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }
        #endregion

        public string get_yuqi(DateTime bdt, DateTime edt)
        {
            string str = "";
            try
            {
                str = "逾期:" + Utils.DateDiff(bdt, edt, "h") + "小時" + Utils.DateDiff(bdt, edt, "m") + "分" + Utils.DateDiff(bdt, edt, "s") + "秒";
;
            }
            catch (Exception eee) { }
            return str;
        }
    }
}
