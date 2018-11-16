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
            string[] newprice = Request.Form.GetValues("new_price");
            if (parentid != null && parentid.Length > 0 && newprice != null && newprice.Length > 0)
            {
                for (int i = 0; i < parentid.Length; i++)
                {
 
                    new Tea.BLL.goods().UpdateField(int.Parse(parentid[i].ToString()), "yu_lock=" + a + ",yu_num=" + newprice[i].ToString() + "");
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
         
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (ListItem li in cblItem.Items)
            {
                if (li.Selected)
                {
                    sb.AppendFormat("{0},", li.Value);
                }
            }
         

            #region 促銷組合==============
            StringBuilder idListA = new StringBuilder();
            string[] parentid = Request.Form.GetValues("goods_id");
            string[] newprice = Request.Form.GetValues("new_price");
            if (parentid != null && parentid.Length > 0 && newprice != null && newprice.Length > 0)
            {
                for (int i = 0; i < parentid.Length; i++)
                {
                    new Tea.BLL.goods().UpdateField(int.Parse(parentid[i].ToString()), "yu_lock=" + id + ",yu_num=" + newprice[i].ToString() + "");
                    idListA.Append(parentid[i].ToString() + ",");
                }
            }
            string id_listA = Utils.DelLastChar(idListA.ToString(), ",");
            if (!string.IsNullOrEmpty(id_listA))
            {
                Tea.DBUtility.DbHelperSQL.ExecuteSql("update shop_goods set yu_lock=0,yu_num=0  where  yu_lock=" + model.id + " and id not in(select id from shop_goods where id in(" + id_listA + "))");
            }
            else
            {
                Tea.DBUtility.DbHelperSQL.ExecuteSql("update shop_goods set yu_lock=0,yu_num=0 where yu_lock=" + model.id + "");
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