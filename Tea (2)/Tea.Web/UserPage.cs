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
    public partial class UserPage : ShopPage
    {
        protected Model.users userModel;
        /// <summary>
        /// 重寫父類的虛方法,此方法將在Init事件前執行
        /// </summary>
        protected override void ShowPage()
        {
            this.Init += new EventHandler(UserPage_Init); //加入IInit事件
        }

        /// <summary>
        /// OnInit事件,檢查用戶是否登入
        /// </summary>
        void UserPage_Init(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(userModel.email) || userModel.email.Length<5)
            {
                HttpContext.Current.Response.Write(ljd.function.LocalHint("請填寫和完善您的電子郵箱資料", "/users/index.aspx"));
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
