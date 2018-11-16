using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.users
{
    public partial class user_edit : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0|0|0"; //預設顯示密碼
        protected string action = TWEnums.ActionEnum.Add.ToString(); //操作類型
        private int id = 0;
        protected string uid, user_name;
        protected int cid;
        protected string guo,area, city, zip;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                TreeBind("is_lock=0"); //綁定類別
                if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                data_guo.DataSource = Tea.DBUtility.DbHelperSQL.Query("select * from shop_basic where basic_where='city' order by basic_sort");
                data_guo.DataBind();
            }
        }

        #region 綁定類別=================================
        private void TreeBind(string strWhere)
        {
            BLL.user_groups bll = new BLL.user_groups();
            DataTable dt = bll.GetList(0, strWhere, "grade asc,id asc").Tables[0];

            this.ddlGroupId.Items.Clear();
            this.ddlGroupId.Items.Add(new ListItem("請選擇組別...", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlGroupId.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
            }
        }
        #endregion

        #region 賦值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.users bll = new BLL.users();
            Model.users model = bll.GetModel(_id);
            user_name = model.user_name;
            ddlGroupId.SelectedValue = model.group_id.ToString();
            rblStatus.SelectedValue = model.status.ToString();
            txtUserName.Text = model.user_name;
            txtUserName.ReadOnly = true;
            txtUserName.Attributes.Remove("ajaxurl");
            if (!string.IsNullOrEmpty(model.password))
            {
                txtPassword.Attributes["value"] = txtPassword1.Attributes["value"] = defaultpassword;
            }
            txtEmail.Text = model.email;
            txtNickName.Text = model.nick_name;
            txtAvatar.Text = model.avatar;
            rblSex.SelectedValue = model.sex;
            if (model.birthday != null)
            {
                txtBirthday.Text = model.birthday.GetValueOrDefault().ToString("yyyy-M-d");
            }
            txtTelphone.Text = model.telphone;
            txtMobile.Text = model.mobile;
          
            
            txtAddress.Text = model.address;
            txtAmount.Text = model.amount.ToString();
            txtPoint.Text = model.point.ToString();
            txtCompany.Text = model.company.ToString();
            txtExp.Text = model.exp.ToString();
            lblRegTime.Text = model.reg_time.ToString();
            lblRegIP.Text = model.reg_ip.ToString();
            if (model.exp == 1)
            {
                cbExp.Checked = true;
            }
            try
            {
                guo = model.area.Split(',')[0].ToString();
                area=model.area.Split(',')[1].ToString();
                city=model.area.Split(',')[2].ToString();
                zip=model.qq;
            }
            catch(Exception eee){}
            //查找最近登錄資訊
            Model.user_login_log logModel = new BLL.user_login_log().GetLastModel(model.user_name);
            if (logModel != null)
            {
                lblLastTime.Text = logModel.login_time.ToString();
                lblLastIP.Text = logModel.login_ip;
            }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.users model = new Model.users();
            BLL.users bll = new BLL.users();

            model.group_id = int.Parse(ddlGroupId.SelectedValue);
            model.status = int.Parse(rblStatus.SelectedValue);
            //檢測用戶名是否重複
            if (bll.Exists(txtUserName.Text.Trim()))
            {
                return false;
            }
            model.user_name = Utils.DropHTML(txtUserName.Text.Trim());
            //獲得6位的salt加密字串
            model.salt = Utils.GetCheckCode(6);
            //以隨機生成的6位字串做為金鑰加密
            model.password = DESEncrypt.Encrypt(txtPassword.Text.Trim(), model.salt);
            model.email = Utils.DropHTML(txtEmail.Text);
            model.nick_name = Utils.DropHTML(txtNickName.Text);
            model.avatar = Utils.DropHTML(txtAvatar.Text);
            model.sex = rblSex.SelectedValue;
            DateTime _birthday;
            if (DateTime.TryParse(txtBirthday.Text.Trim(), out _birthday))
            {
                model.birthday = _birthday;
            }
            model.telphone = Utils.DropHTML(txtTelphone.Text.Trim());
            model.mobile = Utils.DropHTML(txtMobile.Text.Trim());
          
            model.address = Utils.DropHTML(txtAddress.Text.Trim());
            model.amount = Utils.StrToInt(txtAmount.Text.Trim(),0);
            model.point = Utils.StrToInt(txtPoint.Text.Trim(),0);
        
            model.reg_time = DateTime.Now;
            model.reg_ip = TWRequest.GetIP();
            if (TWRequest.GetFormString("txt_guo") == "台灣")
            {
                model.area = TWRequest.GetFormString("txt_guo") + "," + TWRequest.GetFormString("txt_state") + "," + TWRequest.GetFormString("txt_city");
            }
            else
            {
                model.area = TWRequest.GetFormString("txt_guo") + "," + TWRequest.GetFormString("txt_state1") + "," + TWRequest.GetFormString("txt_city1");
            }
            model.qq = TWRequest.GetFormString("txt_zip");
            if (cbExp.Checked)
            {
                model.exp = 1;
            }
            else
            {
                model.exp = 0;
            }
            if (bll.Add(model) > 0)
            {
                AddAdminLog(TWEnums.ActionEnum.Add.ToString(), "添加用戶:" + model.user_name); //記錄日誌
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.users bll = new BLL.users();
            Model.users model = bll.GetModel(_id);

            model.group_id = int.Parse(ddlGroupId.SelectedValue);
            model.status = int.Parse(rblStatus.SelectedValue);
            //判斷密碼是否更改
            if (txtPassword.Text.Trim() != defaultpassword)
            {
                //獲取用戶已生成的salt作為金鑰加密
                model.password = DESEncrypt.Encrypt(txtPassword.Text.Trim(), model.salt);
            }
            model.email = Utils.DropHTML(txtEmail.Text);
            model.nick_name = Utils.DropHTML(txtNickName.Text);
            model.avatar = Utils.DropHTML(txtAvatar.Text);
            model.sex = rblSex.SelectedValue;
            DateTime _birthday;
            if (DateTime.TryParse(txtBirthday.Text.Trim(), out _birthday))
            {
                model.birthday = _birthday;
            }
            model.telphone = Utils.DropHTML(txtTelphone.Text.Trim());
            model.mobile = Utils.DropHTML(txtMobile.Text.Trim());
          
            model.address = Utils.DropHTML(txtAddress.Text.Trim());
            model.amount = Utils.StrToDecimal(txtAmount.Text.Trim(), 0);
            model.point = Utils.StrToInt(txtPoint.Text.Trim(), 0);
            model.exp = Utils.StrToInt(txtExp.Text.Trim(), 0);
            if (TWRequest.GetFormString("txt_guo") == "台灣")
            {
                model.area = TWRequest.GetFormString("txt_guo") + "," + TWRequest.GetFormString("txt_state") + "," + TWRequest.GetFormString("txt_city");
            }
            else
            {
                model.area = TWRequest.GetFormString("txt_guo") + "," + TWRequest.GetFormString("txt_state1") + "," + TWRequest.GetFormString("txt_city1");
            }
            model.qq = TWRequest.GetFormString("txt_zip");
            if (cbExp.Checked)
            {
                model.exp = 1;
            }
            else
            {
                model.exp = 0;
            }
            if (bll.Update(model))
            {
                AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "修改使用者資料:" + model.user_name); //記錄日誌
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
                JscriptMsg("修改會員成功！", "user_list.aspx");
            }
            else //添加
            {
                ChkAdminLevelEdit("user_list", "Edit");
                //ChkAdminLevel("user_list", TWEnums.ActionEnum.Add.ToString()); //檢查許可權
                if (!DoAdd())
                {
                    JscriptMsg("儲存過程中發生錯誤！", "");
                    return;
                }
                JscriptMsg("添加會員成功！", "user_list.aspx");
            }
        }

 
    }
}
