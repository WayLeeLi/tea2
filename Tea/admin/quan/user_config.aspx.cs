using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.users
{
    public partial class user_config : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("user_config", TWEnums.ActionEnum.View.ToString()); //檢查許可權
                ShowInfo();
            }
        }

        #region 賦值操作=================================
        private void ShowInfo()
        {
            BLL.userconfig bll = new BLL.userconfig();
            Model.userconfig model = bll.loadConfig();
 
            pint_mane.Text = model.pint_mane.ToString();
            money_pint.Text = model.money_pint.ToString();
            pint_yong.Text = model.pint_yong.ToString();
            pint_money.Text = model.pint_money.ToString();
        }
        #endregion

        //儲存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("quan_zhe_num", "Edit");
            //ChkAdminLevel("user_config", TWEnums.ActionEnum.Edit.ToString()); //檢查許可權
            BLL.userconfig bll = new BLL.userconfig();
            Model.userconfig model = bll.loadConfig();
            try
            {
             
                model.pint_mane = Utils.StrToInt(pint_mane.Text.Trim(), 0);
                model.money_pint = Utils.StrToDecimal(money_pint.Text.Trim(), 0);
                model.pint_yong = Utils.StrToInt(pint_yong.Text.Trim(), 0);
                model.pint_money = Utils.StrToInt(pint_money.Text.Trim(), 0);
                bll.saveConifg(model);
                AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "修改紅利配置資訊"); //記錄日誌
                JscriptMsg("修改紅利配置成功！", "user_config.aspx");
            }
            catch
            {
                JscriptMsg("檔寫入失敗，請檢查是否有許可權！", string.Empty);
            }
        }

    }
}
