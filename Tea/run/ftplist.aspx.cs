using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using Tea.Common;
using System.Data;
using System.Threading;
public partial class test_ftplist : Tea.Web.UI.ShopPage
{
    Tea.BLL.user_address bll_address = new Tea.BLL.user_address();
    Tea.BLL.order_tui bll_tui = new Tea.BLL.order_tui();
    protected void Page_Load(object sender, EventArgs e)
    {

        string[] str = FtpHelper.GetFileList("Receive");
        foreach (object ob in str)
        {
            if (!string.IsNullOrEmpty(ob.ToString()))
            {
                if (Tea.DBUtility.DbHelperSQL.Query("select * from shop_order_tui where tui_name='" + ob.ToString() + "'").Tables[0].Rows.Count == 0)
                {
                    Tea.Model.order_tui model_tui = new Tea.Model.order_tui();
                    model_tui.tui_id = bll_tui.GetMaxId();
                    model_tui.tui_name = ob.ToString();
                    model_tui.tui_lock = 0;
                    bll_tui.Add(model_tui);

                    DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select * from shop_order_tui where tui_lock=0");

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string strstr = FtpHelper.GetFileStr(model_tui.tui_name, "Receive/").Replace("/n", "$").Replace("/s", "$").Replace("/r", "$").Replace("\r\n", "$");

                        if (!string.IsNullOrEmpty(strstr))
                        {
                            IList _list = strstr.Split('$');
                            foreach (object obb in _list)
                            {
                                if (!string.IsNullOrEmpty(obb.ToString()))
                                {
                                    Tea.Model.user_address model_address = new Tea.Model.user_address();
                                    model_address.address_user = model_tui.tui_id;
                                    model_address.address_address = obb.ToString().Split('|')[0].ToString();
                                    model_address.address_city = obb.ToString().Split('|')[1].ToString();
                                    model_address.address_email = obb.ToString().Split('|')[2].ToString();
                                    model_address.address_mobile = obb.ToString().Split('|')[3].ToString();
                                    model_address.address_name = obb.ToString().Split('|')[4].ToString();
                                    model_address.address_qu = obb.ToString().Split('|')[5].ToString();
                                    model_address.address_shenfen = obb.ToString().Split('|')[6].ToString();
                                    model_address.address_tel = obb.ToString().Split('|')[7].ToString();
                                    model_address.address_add_date = Utils.StrToDateTime(obb.ToString().Split('|')[3].ToString().Substring(0, 4) + "-" + obb.ToString().Split('|')[3].ToString().Substring(4, 2) + "-" + obb.ToString().Split('|')[3].ToString().Substring(6, 2) + " " + obb.ToString().Split('|')[3].ToString().Substring(8, 2) + ":" + obb.ToString().Split('|')[3].ToString().Substring(10, 2) + ":" + obb.ToString().Split('|')[3].ToString().Substring(12, 2));
                                    bll_address.Add(model_address);
                                }
                            }

                        }


                        Tea.Model.order_tui modeltui = bll_tui.GetModel(model_tui.tui_id);
                        modeltui.tui_lock = 1;
                        bll_tui.Update(modeltui);
                        Response.Write(dr["tui_name"].ToString() + "<br>");
                    }
 
                }
            }
        }


        Thread.Sleep(20000);

        Response.Write("<script language=\"javascript\">window.opener=null;window.open('','_self');window.close();</script>");

        Response.End();


    }
}