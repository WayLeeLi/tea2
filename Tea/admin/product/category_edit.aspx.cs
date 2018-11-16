using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.article
{
    public partial class category_edit : Web.UI.ManagePage
    {
        private string action = TWEnums.ActionEnum.Add.ToString(); //操作類型
        protected string channel_name = string.Empty; //頻道名稱
        protected int channel_id;
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = TWRequest.GetQueryString("action");
            this.channel_id = TWRequest.GetQueryInt("channel_id");
            this.id = TWRequest.GetQueryInt("id");

            if (this.channel_id == 0)
            {
                JscriptMsg("頻道參數不正確！", "back");
                return;
            }
            this.channel_name = new BLL.channel().GetChannelName(this.channel_id); //取得頻道名稱
            if (!string.IsNullOrEmpty(_action) && _action == TWEnums.ActionEnum.Edit.ToString())
            {
                this.action = TWEnums.ActionEnum.Edit.ToString();//修改類型
                if (this.id == 0)
                {
                    JscriptMsg("傳輸參數不正確！", "back");
                    return;
                }
                if (!new BLL.article_category().Exists(this.id))
                {
                    JscriptMsg("類別不存在或已被刪除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("channel_" + this.channel_name + "_category", TWEnums.ActionEnum.View.ToString()); //檢查許可權
                TreeBind(this.channel_id); //綁定類別
                if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    if (this.id > 0)
                    {
                        this.ddlParentId.SelectedValue = this.id.ToString();
                    }
                }
            }
        }

        #region 綁定類別=================================
        private void TreeBind(int _channel_id)
        {
            BLL.article_category bll = new BLL.article_category();
            DataTable dt = bll.GetList(0, _channel_id);

            this.ddlParentId.Items.Clear();
            this.ddlParentId.Items.Add(new ListItem("無父級分類", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 賦值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.article_category bll = new BLL.article_category();
            Model.article_category model = bll.GetModel(_id);

            ddlParentId.SelectedValue = model.parent_id.ToString();
            if (model.call_index == "1")
            {
                cbIsLock.Checked = true;
            }
            txtTitle.Text = model.title;
            txtSortId.Text = model.sort_id.ToString();
            txtSeoTitle.Text = model.seo_title;
            txtSeoKeywords.Text = model.seo_keywords;
            txtSeoDescription.Text = model.seo_description;
            txtLinkUrl.Text = model.link_url;
            txtImgUrl.Text = model.img_url;
            txtContent.Value = model.content;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            try
            {
                Model.article_category model = new Model.article_category();
                BLL.article_category bll = new BLL.article_category();
                model.channel_id = this.channel_id;
                if (cbIsLock.Checked)
                { model.call_index = "1"; }
                else
                { model.call_index = "0"; }
                model.title = txtTitle.Text.Trim();
                model.parent_id = int.Parse(ddlParentId.SelectedValue);
                model.sort_id = int.Parse(txtSortId.Text.Trim());
                model.seo_title = txtSeoTitle.Text;
                model.seo_keywords = txtSeoKeywords.Text;
                model.seo_description = txtSeoDescription.Text;
                model.link_url = txtLinkUrl.Text.Trim();
                model.img_url = txtImgUrl.Text.Trim();
                model.content = txtContent.Value;
             
                if (bll.Add(model) > 0)
                {
                    AddAdminLog(TWEnums.ActionEnum.Add.ToString(), "添加" + this.channel_name + "頻道欄位分類:" + model.title); //記錄日誌
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            try
            {
                BLL.article_category bll = new BLL.article_category();
                Model.article_category model = bll.GetModel(_id);

                int parentId = int.Parse(ddlParentId.SelectedValue);
                model.channel_id = this.channel_id;
                if (cbIsLock.Checked)
                { model.call_index = "1"; }
                else
                { model.call_index = "0"; }
                model.title = txtTitle.Text.Trim();
                //如果選擇的父ID不是自己,則更改
                if (parentId != model.id)
                {
                    model.parent_id = parentId;
                }
                model.sort_id = int.Parse(txtSortId.Text.Trim());
                model.seo_title = txtSeoTitle.Text;
                model.seo_keywords = txtSeoKeywords.Text;
                model.seo_description = txtSeoDescription.Text;
                model.link_url = txtLinkUrl.Text.Trim();
                model.img_url = txtImgUrl.Text.Trim();
                model.content = txtContent.Value;
                if (bll.Update(model))
                {
                    AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "修改" + this.channel_name + "頻道欄位分類:" + model.title); //記錄日誌
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        //儲存類別
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevelEdit("channel_goods_category", "Edit");
                //ChkAdminLevel("channel_" + this.channel_name + "_category", TWEnums.ActionEnum.Edit.ToString()); //檢查許可權
                if (!DoEdit(this.id))
                {

                    JscriptMsg("儲存過程中發生錯誤！", "");
                    return;
                }
                JscriptMsg("修改類別成功！", "category_list.aspx?channel_id=" + channel_id);
            }
            else //添加
            {
                ChkAdminLevelEdit("channel_goods_category", "Edit");
                //ChkAdminLevel("channel_" + this.channel_name + "_category", TWEnums.ActionEnum.Add.ToString()); //檢查許可權
                if (!DoAdd())
                {
                    JscriptMsg("儲存過程中發生錯誤！", "");
                    return;
                }
                JscriptMsg("添加類別成功！", "category_list.aspx?channel_id=" + channel_id);
            }
        }

    }
}
