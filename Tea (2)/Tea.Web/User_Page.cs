using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Configuration;
using Tea.Common;

namespace Tea.Web.UI
{
    public partial class User_Page : ShopPage
    {
        protected Model.users userModel;
        /// <summary>
        /// 重寫父類的虛方法,此方法將在Init事件前執行
        /// </summary>
        protected override void ShowPage()
        {
            this.Init += new EventHandler(User_Page_Init); //加入IInit事件
        }

        /// <summary>
        /// OnInit事件,檢查用戶是否登入
        /// </summary>
        void User_Page_Init(object sender, EventArgs e)
        {
            if (!IsUserLogin())
            {
                //跳轉URL
                HttpContext.Current.Response.Write(ljd.function.LocalHint("請登入", "/users/login.aspx"));
                HttpContext.Current.Response.End();
                return;
            }
            //獲得登入使用者資訊
            userModel = GetUserInfo();
            if (userModel.status != 0)
            {
                HttpContext.Current.Response.Write(ljd.function.LocalHint("已發送帳號啟用信至您的電子信箱，請至信箱確認並啟用", "/users/regno.aspx"));
                HttpContext.Current.Response.End();
            }
            
            InitPage();
        }

        /// <summary>
        /// 構建一個虛方法，供子類重寫
        /// </summary>
        protected virtual void InitPage()
        {
            //無任何代碼
        }
    }
}
