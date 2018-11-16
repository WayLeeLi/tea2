using System;
using System.Xml;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.order
{
    public partial class payment_edit : Web.UI.ManagePage
    {
        private int id = 0;
        protected Model.payment model = new Model.payment();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = TWRequest.GetQueryInt("id");
            if (this.id == 0)
            {
                JscriptMsg("傳輸參數不正確！", "back");
                return;
            }
            if (!new BLL.payment().Exists(this.id))
            {
                JscriptMsg("付款方式不存在或已刪除！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("order_payment", TWEnums.ActionEnum.View.ToString()); //檢查許可權
                ShowInfo(this.id);
            }
        }

        #region 賦值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.payment bll = new BLL.payment();
            model = bll.GetModel(_id);
            txtTitle.Text = model.title;
            rblType.SelectedValue = model.type.ToString();
            rblType.Enabled = false;
            if (model.is_lock == 0)
            {
                cbIsLock.Checked = true;
            }
            else
            {
                cbIsLock.Checked = false;
            }
            txtSortId.Text = model.sort_id.ToString();
            rblPoundageType.SelectedValue = model.poundage_type.ToString();
            txtPoundageAmount.Text = model.poundage_amount.ToString();
            txtImgUrl.Text = model.img_url;
            txtRemark.Text = model.remark;
            if (model.api_path.ToLower() == "alipaypc")
            {
                //支付寶
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/alipaypc.config"));
                txtAlipayPartner.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
                txtAlipayKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
                txtAlipaySellerEmail.Text = doc.SelectSingleNode(@"Root/email").InnerText;
                rblAlipayType.SelectedValue = doc.SelectSingleNode(@"Root/type").InnerText;
            }
            else if (model.api_path.ToLower() == "tenpaypc")
            {
                //財付通
                XmlDocument doc = XmlHelper.LoadXmlDoc(Utils.GetMapPath(siteConfig.webpath + "xmlconfig/tenpaypc.config"));
                txtTenpayBargainorId.Text = doc.SelectSingleNode(@"Root/partner").InnerText;
                txtTenpayKey.Text = doc.SelectSingleNode(@"Root/key").InnerText;
                rblTenpayType.SelectedValue = doc.SelectSingleNode(@"Root/type").InnerText;
            }
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.payment bll = new BLL.payment();
            Model.payment model = bll.GetModel(_id);

            model.title = txtTitle.Text.Trim();
            if (cbIsLock.Checked == true)
            {
                model.is_lock = 0;
            }
            else
            {
                model.is_lock = 1;
            }
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.poundage_type = int.Parse(rblPoundageType.SelectedValue);
            model.poundage_amount = decimal.Parse(txtPoundageAmount.Text.Trim());
            model.img_url = txtImgUrl.Text.Trim();
            model.remark = txtRemark.Text;
            if (model.api_path.ToLower() == "alipaypc")
            {
                //支付寶
                string alipayFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/alipaypc.config");
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/partner", txtAlipayPartner.Text);
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/key", txtAlipayKey.Text);
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/email", txtAlipaySellerEmail.Text);
                XmlHelper.UpdateNodeInnerText(alipayFilePath, @"Root/type", rblAlipayType.SelectedValue);
            }
            else if (model.api_path.ToLower() == "tenpaypc")
            {
                //財付通
                string tenpayFilePath = Utils.GetMapPath(siteConfig.webpath + "xmlconfig/tenpaypc.config");
                XmlHelper.UpdateNodeInnerText(tenpayFilePath, @"Root/partner", txtTenpayBargainorId.Text);
                XmlHelper.UpdateNodeInnerText(tenpayFilePath, @"Root/key", txtTenpayKey.Text);
                XmlHelper.UpdateNodeInnerText(tenpayFilePath, @"Root/type", rblTenpayType.SelectedValue);
            }

            if (bll.Update(model))
            {
                AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "修改付款方式:" + model.title); //記錄日誌
                result = true;
            }

            return result;
        }
        #endregion

        //儲存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("order_payment", "Edit");
            //ChkAdminLevel("order_payment", TWEnums.ActionEnum.Edit.ToString()); //檢查許可權
            if (!DoEdit(this.id))
            {
                JscriptMsg("儲存過程中發生錯誤！", string.Empty);
                return;
            }
            JscriptMsg("修改設定成功！", "payment_list.aspx");
        }

    }
}
