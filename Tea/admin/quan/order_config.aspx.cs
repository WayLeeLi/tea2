using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.order
{
    public partial class order_config : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("order_config", TWEnums.ActionEnum.View.ToString()); //檢查許可權
                ShowInfo();
            }
        }

        #region 賦值操作=================================
        private void ShowInfo()
        {
            BLL.orderconfig bll = new BLL.orderconfig();
            Model.orderconfig model = bll.loadConfig();
            maned.Text = model.maned.ToString();
            zhekou.Text = model.zhekou.ToString();
            quanguan.Text = model.quanguan.ToString();
            yunfei.Text = model.yunfei.ToString();
            yunmian.Text = model.yunmian.ToString();

            mebegin.Text = model.mebegin.GetValueOrDefault().ToString("yyyy-MM-dd");
            meend.Text = model.meend.GetValueOrDefault().ToString("yyyy-MM-dd");
            metype.SelectedValue = model.metype.ToString();
            zkjin.Text = model.zkjin.ToString();


            qgbegin.Text = model.qgbegin.GetValueOrDefault().ToString("yyyy-MM-dd");
            qgend.Text = model.qgend.GetValueOrDefault().ToString("yyyy-MM-dd");
            qgtype.SelectedValue = model.qgtype.ToString();
            quanguanjin.Text = model.quanguanjin.ToString();

 
        }
        #endregion

        //儲存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("sys_quan", "Edit");
            //ChkAdminLevel("order_config", TWEnums.ActionEnum.Edit.ToString()); //檢查許可權
            BLL.orderconfig bll = new BLL.orderconfig();
            Model.orderconfig model = bll.loadConfig();
            try
            {

                model.maned = Utils.StrToInt(maned.Text, 0);
                model.zhekou = Utils.StrToInt(zhekou.Text, 0);
                model.quanguan = Utils.StrToDecimal(quanguan.Text.Trim(), 0);
                model.yunfei = Utils.StrToInt(yunfei.Text, 0);
                model.yunmian = Utils.StrToInt(yunmian.Text, 0);

                model.mebegin = Utils.StrToDateTime(mebegin.Text);
                model.meend = Utils.StrToDateTime(meend.Text);
                model.metype = Utils.StrToInt(metype.SelectedValue, 0);
                model.zkjin = Utils.StrToInt(zkjin.Text, 0);

                model.qgbegin = Utils.StrToDateTime(qgbegin.Text);
                model.qgend = Utils.StrToDateTime(qgend.Text);
                model.qgtype = Utils.StrToInt(qgtype.SelectedValue, 0);
                model.quanguanjin = Utils.StrToInt(quanguanjin.Text, 0);

                bll.saveConifg(model);
                AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "修改折扣設定資料"); //記錄日誌
                JscriptMsg("修改折扣設定成功！", "order_config.aspx");
            }
            catch
            {
                JscriptMsg("檔寫入失敗，請檢查是否有許可權！", string.Empty);
            }
        }

    }
}
