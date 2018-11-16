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
    public partial class sales_edit : Web.UI.ManagePage
    {
        private string action = TWEnums.ActionEnum.Add.ToString(); //操作類型
        private int id = 0;
        Tea.BLL.goods_sales bll_list = new BLL.goods_sales();
        Tea.BLL.article bll_article = new BLL.article();
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = TWRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == TWEnums.ActionEnum.Edit.ToString())
            {
                this.action = TWEnums.ActionEnum.Edit.ToString();//修改類型
                this.id = TWRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("傳輸參數不正確！", "back", "Error");
                    return;
                }
                if (!new BLL.sales().Exists(this.id))
                {
                    JscriptMsg("記錄不存在或已被刪除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
 
                ////ChkAdminLevel("goods_sales", TWEnums.ActionEnum.View.ToString()); //檢查權限
                if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 賦值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.sales bll = new BLL.sales();
            Model.sales model = bll.GetModel(_id);

            txtTitle.Text = model.title;
            txtSubTitle.Text = model.sub_title;
            txtImgUrl.Text = model.img_url;
          
            ddlType.SelectedValue = model.type;

            company.SelectedValue = model.company.ToString();
            txtStartTime.Text = model.start_time.ToString("yyyy-M-d");
            if (model.end_time != null)
            {
                txtEndTime.Text = model.end_time.GetValueOrDefault().ToString("yyyy-M-d");
            }
            txtSortId.Text = model.sort_id.ToString();
            cbStatus.Checked = (model.status == 1);
            txtZhaiyao.Text = model.summary;
            txtContent.Value = model.content;


            rptGroup.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from view_goods where yu_lock=" + id + "");
            rptGroup.DataBind();


            data_zhe1.DataSource = bll_list.GetList("main_id=" + id + "");
            data_zhe1.DataBind();

        
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.sales model = new Model.sales();
            BLL.sales bll = new BLL.sales();

            string type = ddlType.SelectedValue.Trim();
            model.title = txtTitle.Text.Trim();
            model.sub_title = txtSubTitle.Text.Trim();
            model.img_url = txtImgUrl.Text;
            model.company =Utils.StrToInt(company.SelectedValue,1);
            model.type = type;


            model.start_time = Utils.StrToDateTime(txtStartTime.Text.Trim());
            DateTime _end_time;
            if (DateTime.TryParse(txtEndTime.Text.Trim(), out _end_time))
            {
                model.end_time = _end_time;
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

            //內容摘要提取內容前255個字元
            if (string.IsNullOrEmpty(txtZhaiyao.Text.Trim()))
            {
                model.summary = Utils.DropHTML(txtContent.Value, 255);
            }
            else
            {
                model.summary = Utils.DropHTML(txtZhaiyao.Text, 255);
            }
            model.content = txtContent.Value;
          
 
            int a = bll.Add(model);


            #region 促銷組合==============
            string[] parentid = Request.Form.GetValues("goods_id");
            if (parentid != null && parentid.Length > 0)
            {
                for (int i = 0; i < parentid.Length; i++)
                {
                    new Tea.BLL.goods().UpdateField(int.Parse(parentid[i].ToString()), "yu_lock=" + a + "");
                }
            }
            #endregion

 
            #region 減折==============
            string[] zhe1moeny = Request.Form.GetValues("zhe1_moeny");
            string[] zhe1num = Request.Form.GetValues("zhe1_num");
            if (zhe1moeny != null && zhe1moeny.Length > 0 && zhe1num != null && zhe1num.Length > 0)
            {
                for (int i = 0; i < zhe1moeny.Length; i++)
                {
                    try
                    {
                        Model.goods_sales model_list = new Model.goods_sales();
                        model_list.main_id = a;
                        model_list.parent_id = int.Parse(zhe1moeny[i].ToString());
                        model_list.goods_id = int.Parse(zhe1num[i].ToString());

                        bll_list.Add(model_list);
                    }
                    catch (Exception eee) { }
                }
            }
            #endregion

    

            if (a > 0)
            {
                AddAdminLog(TWEnums.ActionEnum.Add.ToString(), "添加銷售活動:" + model.title); //記錄日誌
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.sales bll = new BLL.sales();
            Model.sales model = bll.GetModel(_id);

            string type = ddlType.SelectedValue.Trim();
            model.title = txtTitle.Text.Trim();
            model.sub_title = txtSubTitle.Text.Trim();
            model.img_url = txtImgUrl.Text;
            model.company = Utils.StrToInt(company.SelectedValue, 1);
            model.type = type;

            model.start_time = Utils.StrToDateTime(txtStartTime.Text.Trim());
            DateTime _end_time;
            if (DateTime.TryParse(txtEndTime.Text.Trim(), out _end_time))
            {
                model.end_time = _end_time;
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

            //內容摘要提取內容前255個字元
            if (string.IsNullOrEmpty(txtZhaiyao.Text.Trim()))
            {
                model.summary = Utils.DropHTML(txtContent.Value, 255);
            }
            else
            {
                model.summary = Utils.DropHTML(txtZhaiyao.Text, 255);
            }
            model.content = txtContent.Value;
         
 
         

            #region 促銷組合==============
            StringBuilder idListA = new StringBuilder();
            string[] parentid = Request.Form.GetValues("goods_id");
            if (parentid != null && parentid.Length > 0)
            {
                for (int i = 0; i < parentid.Length; i++)
                {
                    new Tea.BLL.goods().UpdateField(int.Parse(parentid[i].ToString()), "yu_lock=" + id + "");
                    idListA.Append(parentid[i].ToString() + ",");
                }
            }
            string id_listA = Utils.DelLastChar(idListA.ToString(), ",");
            if (!string.IsNullOrEmpty(id_listA))
            {
                Tea.DBUtility.DbHelperSQL.ExecuteSql("update shop_goods set yu_lock=0  where  yu_lock=" + model.id + " and id not in(select id from shop_goods where id in(" + id_listA + "))");
            }
            else
            {
                Tea.DBUtility.DbHelperSQL.ExecuteSql("update shop_goods set yu_lock=0 where yu_lock=" + model.id + "");
            }
            #endregion

   
            #region 減折==============
            StringBuilder idList1 = new StringBuilder();
            string[] item1id = Request.Form.GetValues("item1_id");
            string[] zhe1moeny = Request.Form.GetValues("zhe1_moeny");
            string[] zhe1num = Request.Form.GetValues("zhe1_num");
            if (zhe1moeny != null && zhe1moeny.Length > 0 && zhe1num != null && zhe1num.Length > 0)
            {
                for (int i = 0; i < zhe1moeny.Length; i++)
                {
                    try
                    {
                        Model.goods_sales model_list = null;
                        int id = int.Parse(item1id[i].ToString());
                        bool update = true;
                        if (id == 0)
                        {
                            model_list = new Model.goods_sales();
                            update = false;
                        }
                        else
                        {
                            model_list = bll_list.GetModel(id);
                        }
                        model_list.main_id = model.id;
                        model_list.parent_id = int.Parse(zhe1moeny[i].ToString());
                        model_list.goods_id = int.Parse(zhe1num[i].ToString());

                        if (update)
                        {
                            bll_list.Update(model_list);
                            idList1.Append(model_list.id + ",");
                        }
                        else
                        {
                            int a = bll_list.Add(model_list);
                            idList1.Append(a + ",");
                        }
                    }
                    catch (Exception eee) { }
                }
            }
            string id_list1 = Utils.DelLastChar(idList1.ToString(), ",");
            if (!string.IsNullOrEmpty(id_list1))
            {
                Tea.DBUtility.DbHelperSQL.ExecuteSql("delete from shop_goods_sales where main_id=" + model.id + " and id not in(select id from shop_goods_sales where id in(" + id_list1 + "))");
            }
            else
            {
                Tea.DBUtility.DbHelperSQL.ExecuteSql("delete from shop_goods_sales where main_id=" + model.id + "");
            }
            #endregion
 

            if (bll.Update(model))
            {
                AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "修改銷售活動:" + model.title); //記錄日誌
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
                ChkAdminLevelEdit("sys_goods", "Edit");
                if (!DoEdit(this.id))
                {
                    JscriptMsg("儲存過程中發生錯誤！", "", "Error");
                    return;
                }
                JscriptMsg("修改銷售活動成功！", "sales_list.aspx");
            }
            else //添加
            {
                ChkAdminLevelEdit("sys_goods", "Edit");
                if (!DoAdd())
                {
                    JscriptMsg("儲存過程中發生錯誤！", "", "Error");
                    return;
                }
                JscriptMsg("添加銷售活動成功！", "sales_list.aspx");
            }
        }

        public string getgift(string gid)
        {
            string str = "-";
            try
            {
                str = new Tea.BLL.gift().GetModel(int.Parse(gid)).title;
            }
            catch (Exception eee) { }
            return str;
        }
    }
  
}