using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Web.UI;
using Tea.Common;
using System.Data;

public partial class fb : Tea.Web.UI.ShopPage
{
    protected string id,name;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        name = Request["name"];
        if (!string.IsNullOrEmpty(id))
        {
            Tea.Model.users model = new Tea.Model.users();
            Tea.BLL.users bll = new Tea.BLL.users();
            //自動加入會員
            DataSet ds = bll.GetList(1, "user_name='" + id + "'", "id");
 
            if (ds.Tables[0].Rows.Count == 0)
            {
                model.group_id =1;
                model.status = 0;
                model.user_name = id;
                model.password = DESEncrypt.Encrypt(ljd.function.getUUIDString(12));
                //model.birthday = DateTime.Parse("1980-1-1");
                if (!string.IsNullOrEmpty(name))
                {
                    model.nick_name = name;
                }
                else
                {
                    model.nick_name = "暱名";
                }
                model.mobile = ""; 
                model.address = ""; 
                model.reg_time = DateTime.Now;
                model.reg_ip =TWRequest.GetIP();
                model.user_hei = 1;
                model.point = 0;
                model.avatar = "https://graph.facebook.com/" + id + "/picture";
                try
                {
                    string tcode = Utils.GetCookie("tcode");
                    model.company = Utils.StrToInt(tcode, 0);

                }
                catch (Exception eee) { }
                int uid = bll.Add(model);

                model.id = uid;
                Session[TWKeys.SESSION_USER_INFO] = model;
                Session.Timeout = 4500;

                //防止Session提前過期
                Utils.WriteCookie(TWKeys.COOKIE_USER_NAME_REMEMBER, "Tea", model.user_name);
                Utils.WriteCookie(TWKeys.COOKIE_USER_PWD_REMEMBER, "Tea", model.password);
       


                //寫入登入日誌
                //new Tea.BLL.user_login_log().Add();
                if (model.email.Length < 2)
                {
                    Response.Write("2");
                    Response.End();
                }
                Response.Write("1");
                Response.End();
            }
            else
            {
                model = bll.GetModel(id);
                model.avatar = "https://graph.facebook.com/"+ id +"/picture";
             
                bll.Update(model);
                if (model == null)
                {
                    //Response.Write(Tea.Common.Utils.LocalHint("您已更改本站密碼，請用本站密碼登入！", "/login.aspx"));
                    //Response.End();
                }
            }
            //防止Session提前過期
            try
            {
                Session[TWKeys.SESSION_USER_INFO] = model;
                Session.Timeout = 4500;

                //防止Session提前過期
                Utils.WriteCookie(TWKeys.COOKIE_USER_NAME_REMEMBER, "Tea", model.user_name);
                Utils.WriteCookie(TWKeys.COOKIE_USER_PWD_REMEMBER, "Tea", model.password);
              

                //寫入登入日誌
                //new Tea.BLL.user_login_log().Add(model.id, model.user_name, "會員登入", TWRequest.GetIP());
                if (model.email.Length < 2)
                {
                    Response.Write("2");
                    Response.End();
                }
                Response.Write("1");
                Response.End();

                Tea.Model.cart_total cartModel = Tea.Web.UI.ShopCart.GetTotal(1);
                if (cartModel.total_quantity == 0)
                {
                    Response.Write("3");
                    Response.End();
                }
                else
                {
                    Response.Write("4");
                    Response.End();
                }
            }
            catch {// Response.Write("no"); Response.End(); 
            }


        

        }
    }
}