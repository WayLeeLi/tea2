using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.users
{
    public partial class user_money : Web.UI.ManagePage
    {
        string mobiles = string.Empty;
        BLL.quan bll_quan = new BLL.quan();
        protected int id;
        protected Tea.Model.quan model_quan = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = TWRequest.GetQueryInt("id");
            if (id > 0)
            {
                model_quan = bll_quan.GetModel(id);
            }
            if (!Page.IsPostBack)
            {

                if (model_quan != null)
                {
                    try
                    {
                        txtBeginTime.Text = model_quan.quan_begin_date.Value.ToString("yyyy-MM-dd");
                    }
                    catch (Exception eee) { }
                    try
                    {
                        txtEndTime.Text = model_quan.quan_end_date.Value.ToString("yyyy-MM-dd");
                    }
                    catch (Exception eee) { }
                    txtTitle.Text = model_quan.quan_title;
                    amount.Text = model_quan.quan_num.Value.ToString("0.");



                    txtJin.Text = model_quan.quan_sort.GetValueOrDefault().ToString();

                    if (!string.IsNullOrEmpty(model_quan.quan_des))
                    {
                        rptGroup.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from view_goods where id in(" + model_quan.quan_des + ")");
                        rptGroup.DataBind();
                    }

                }
                //ChkAdminLevel("user_sms", TWEnums.ActionEnum.View.ToString()); //檢查權限

            }
        }



        //發送折扣券
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("sys_settings", "Edit");
            //ChkAdminLevel("user_sms", TWEnums.ActionEnum.Add.ToString()); //檢查權限
            //檢查折扣券內容
            if (amount.Text.Trim() == "")
            {
                JscriptMsg("請輸入金額！", "");
                return;
            }
            if (txtEndTime.Text.Trim() == "")
            {
                JscriptMsg("請輸入到期時間！", "");
                return;
            }
            //開始發送折扣券
            string msg = string.Empty;
            bool result = false;

            Tea.Model.quan model = null;
            bool update = true;
            if (id > 0)
            {
                model = bll_quan.GetModel(id);
            }
            if (model == null)
            {
                model = new Model.quan();
                update = false;
            }

            model.quan_title = txtTitle.Text;
            model.quan_add_date = System.DateTime.Now;
            model.quan_begin_date = Utils.StrToDateTime(txtBeginTime.Text, System.DateTime.Now);
            model.quan_end_date = Utils.StrToDateTime(txtEndTime.Text, System.DateTime.Now);
            model.quan_where = "lin";
            model.quan_num = Utils.StrToDecimal(amount.Text, 0);
            #region 保存组合商品==============
            BLL.goods_group bll_good_group = new BLL.goods_group();
            StringBuilder idList = new StringBuilder();
            string[] goodsGroupIdArr = Request.Form.GetValues("goods_group_id");
            string[] parentIdArr = Request.Form.GetValues("parent_id");
            string[] goodsIdArr = Request.Form.GetValues("goods_id");

            if (goodsGroupIdArr != null && parentIdArr != null && goodsIdArr != null && goodsGroupIdArr.Length > 0 && parentIdArr.Length > 0 && goodsIdArr.Length > 0)
            {

                for (int i = 0; i < goodsGroupIdArr.Length; i++)
                {
                    int groupGoodsId = Utils.StrToInt(goodsGroupIdArr[i], 0);
                    int parentId = Utils.StrToInt(parentIdArr[i], 0);
                    int goodsId = Utils.StrToInt(goodsIdArr[i], 0);
                    idList.Append(goodsId + ",");

                }

            }
            model.quan_des = idList.ToString() + "0";

            #endregion

            model.quan_sort = Utils.StrToInt(txtJin.Text, 0);

            if (update)
            {
                bll_quan.Update(model);
            }
            else
            {
                model.quan_code = ljd.function.getUUIDString(12);
                bll_quan.Add(model);
            }
            if (result)
            {
                AddAdminLog(TWEnums.ActionEnum.Add.ToString(), "折扣券"); //記錄日誌
                JscriptMsg("設定優惠券", "lin_list.aspx");
                return;
            }
            else
            {
                JscriptMsg("設定優惠券", "lin_list.aspx");
                return;
            }

        }

    }
}