using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.shop
{
    public partial class ku : Web.UI.ManagePage
    {
        protected string action = TWEnums.ActionEnum.Add.ToString(); //操作類型
        private int id = 0;
        protected string uid, user_name;
        protected int cid;
        protected string area, city, zip;
        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("user_list", "Edit");
            this.id = TWRequest.GetQueryInt("id");
            cid = TWRequest.GetQueryInt("cid");
            string _action = TWRequest.GetQueryString("action");
            uid = TWRequest.GetQueryString("uid");
            if (!string.IsNullOrEmpty(uid))
            {
                _action = TWEnums.ActionEnum.Edit.ToString();
                id = new BLL.users().GetModel(uid).id;
            }

            if (!string.IsNullOrEmpty(_action) && _action == TWEnums.ActionEnum.Edit.ToString())
            {
                this.action = TWEnums.ActionEnum.Edit.ToString();//修改類型

                if (this.id == 0)
                {
                    JscriptMsg("傳輸參數不正確！", "back");
                    return;
                }
                if (!new BLL.users().Exists(this.id))
                {
                    JscriptMsg("資料不存在或已被刪除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("user_list", TWEnums.ActionEnum.View.ToString()); //檢查許可權

                if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }


        #region 賦值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.users bll = new BLL.users();
            Model.users model = bll.GetModel(_id);
            user_name = model.user_name;

            txtAmount.Text = model.amount.ToString("0.");
            rptGroup.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from view_user_group_price where group_id=" + model.id + "");
            rptGroup.DataBind(); 
        }
        #endregion



        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.users bll = new BLL.users();
            Model.users model = bll.GetModel(_id);
            BLL.user_group_price bll_group = new BLL.user_group_price();
            #region 會員價==============
            StringBuilder idListA = new StringBuilder();
            string[] goodsid = Request.Form.GetValues("goods_id");
            string[] goodsgroupid = Request.Form.GetValues("goods_group_id");
            string[] newprice = Request.Form.GetValues("new_price");
            if (goodsgroupid != null && goodsgroupid.Length > 0 && goodsid != null && goodsid.Length > 0 && newprice != null && newprice.Length > 0)
            {
                for (int i = 0; i < goodsid.Length; i++)
                {
                    int pid = int.Parse(goodsgroupid[i].ToString());
                    bool update = true;
                    Model.user_group_price model_group = null;
                    if (pid > 0)
                    {
                        model_group = bll_group.GetModel(pid);
                    }
                    else
                    {
                        model_group = new Model.user_group_price();
                        update = false;
                    }
 
                    model_group.article_id = Utils.StrToInt(goodsid[i].ToString(), 0);
                    model_group.group_id = model.id;
                    model_group.price = Utils.StrToInt(newprice[i].ToString(), 0);

                    if (update)
                    {
                        bll_group.Update(model_group);
                        idListA.Append(model_group.id + ",");
                    }
                    else
                    {
                        int a = bll_group.Add(model_group);
                        idListA.Append(a + ",");
                    }
                   
                }
            }
            string id_listA = Utils.DelLastChar(idListA.ToString(), ",");

            if (!string.IsNullOrEmpty(id_listA))
            {
                Tea.DBUtility.DbHelperSQL.ExecuteSql("delete from shop_user_group_price where group_id=" + model.id + " and id not in(select id from shop_user_group_price where id in(" + id_listA + "))");
            }
            else
            {
                Tea.DBUtility.DbHelperSQL.ExecuteSql("delete from shop_user_group_price where group_id=" + model.id + "");
            }
 
            #endregion

            model.amount = Utils.StrToDecimal(txtAmount.Text.Trim(), 0);

            if (bll.Update(model))
            {
                AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "設定會員折扣:" + model.user_name); //記錄日誌
                result = true;
            }
            return result;
        }
        #endregion

        //儲存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevelEdit("user_list", "Edit");
                //ChkAdminLevel("user_list", TWEnums.ActionEnum.Edit.ToString()); //檢查許可權
                if (!DoEdit(this.id))
                {
                    JscriptMsg("儲存過程中發生錯誤！", "");
                    return;
                }
                JscriptMsg("設定會員折扣成功！", "user_list.aspx");
            }

        }

    }
}
