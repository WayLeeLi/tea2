using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;
using System.Data;
using System.Text;

namespace Tea.Web.admin.goods
{
    public partial class gift_edit : Web.UI.ManagePage
    {
        private string action = TWEnums.ActionEnum.Add.ToString(); //操作類型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = TWRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == TWEnums.ActionEnum.Edit.ToString())
            {
                this.action = TWEnums.ActionEnum.Edit.ToString();//修改類型
                this.id = TWRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("傳輸參數不正確！", "back");
                    return;
                }
                if (!new BLL.gift().Exists(this.id))
                {
                    JscriptMsg("記錄不存在或已被刪除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                for (int i = 1; i <= 12; i++)
                {
                    if (i < 10)
                    {
                        ddlMonth.Items.Add(new ListItem("0" + i.ToString(), "0" + i.ToString()));
                    }
                    else
                    {
                        ddlMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                }
                int year = System.DateTime.Now.Year;
                for (int i = 2018; i <= year + 1; i++)
                {

                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                //ChkAdminLevel("goods_gift", TWEnums.ActionEnum.View.ToString()); //檢查權限


                if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 賦值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.gift bll = new BLL.gift();
            Model.gift model = bll.GetModel(_id);
            try
            {
                ddlYear.SelectedValue = model.brand_id.ToString().Substring(1, 4);
                ddlMonth.SelectedValue = model.brand_id.ToString().Substring(4, 2);
            }
            catch (Exception eee) { }
            txtCode.Text = model.gift_code;
            txtTitle.Text = model.title;
            txtImgUrl.Text = model.img_url;
            ddlType.SelectedValue = model.type;
            article_list.Text = model.article_list;
            quantity.Text = model.quantity.ToString();
            amount.Text = model.amount.ToString();
            txtSortId.Text = model.sort_id.ToString();
            cbStatus.Checked = (model.status == 1);
            txtLeftQuantity.Text = model.left_quantity.ToString();
            txtContent.Value = model.content;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.gift model = new Model.gift();
            BLL.gift bll = new BLL.gift();
            model.brand_id = Utils.StrToInt((ddlYear.SelectedValue + ddlMonth.SelectedValue), 0);
            string type = ddlType.SelectedValue.Trim();
            model.title = txtTitle.Text.Trim();
            model.img_url = txtImgUrl.Text;
            model.type = type;
            //if (type == "2")
            //{
            //    model.article_list = ",0,";

            //    model.quantity = Utils.StrToInt(quantity.Text, 0);
            //    model.amount = 0M;
            //}
            //else 
            model.gift_code = txtCode.Text;
            model.article_list = article_list.Text;
            if (type == "1")
            {
                //model.article_list = ",0,";

                model.quantity = 0;
                model.amount = Utils.StrToDecimal(amount.Text, 0);
            }

            if (cbStatus.Checked)
            {
                model.status = 1;
            }
            else
            {
                model.status = 0;
            }
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.left_quantity = Utils.StrToInt(txtLeftQuantity.Text, 0);
            model.content = txtContent.Value;
            model.add_time = DateTime.Now;
            if (bll.Add(model) > 0)
            {
                AddAdminLog(TWEnums.ActionEnum.Add.ToString(), "添加贈品:" + model.title); //記錄日誌
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.gift bll = new BLL.gift();
            Model.gift model = bll.GetModel(_id);
            model.brand_id = Utils.StrToInt(ddlYear.SelectedValue + ddlMonth.SelectedValue, 0);

            model.gift_code = txtCode.Text;
            string type = ddlType.SelectedValue.Trim();
            model.title = txtTitle.Text.Trim();
            model.img_url = txtImgUrl.Text;
            model.type = type;
            //if (type == "2")
            //{
            //    model.article_list = ",0,";

            //    model.quantity = Utils.StrToInt(quantity.Text, 0);
            //    model.amount = 0M;
            //}
            //else
            model.article_list = article_list.Text;
            if (type == "1")
            {
                //model.article_list = ",0,";

                model.quantity = 0;
                model.amount = Utils.StrToDecimal(amount.Text, 0);
            }

            if (cbStatus.Checked)
            {
                model.status = 1;
            }
            else
            {
                model.status = 0;
            }
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);

            model.left_quantity = Utils.StrToInt(txtLeftQuantity.Text, 0);
            model.content = txtContent.Value;

            if (bll.Update(model))
            {

                AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "修改贈品:" + model.title); //記錄日誌
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
                ChkAdminLevelEdit("site_gift", "Edit");
                DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select * from shop_gift where brand_id=" + ddlYear.SelectedValue + ddlMonth.SelectedValue + " and id!=" + id + "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    JscriptMsg("該月份贈品已經存在！", string.Empty);
                    return;
                }
                //ChkAdminLevel("goods_gift", TWEnums.ActionEnum.Edit.ToString()); //檢查權限
                if (!DoEdit(this.id))
                {

                    JscriptMsg("保存过程中发生错误！", string.Empty);
                    return;
                }
               
                JscriptMsg("修改贈品信息成功！", "gift_list.aspx");
            }
            else //添加
            {
                ChkAdminLevelEdit("site_gift", "Edit");
                //ChkAdminLevel("goods_gift", TWEnums.ActionEnum.Add.ToString()); //檢查權限
                DataSet ds = Tea.DBUtility.DbHelperSQL.Query("select * from shop_gift where brand_id=" + ddlYear.SelectedValue + ddlMonth.SelectedValue + "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    JscriptMsg("該月份贈品已經存在！", string.Empty);
                    return;
                }
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", string.Empty);
                    return;
                }
              
                JscriptMsg("添加贈品成功！", "gift_list.aspx");
            }
        }
    }
}