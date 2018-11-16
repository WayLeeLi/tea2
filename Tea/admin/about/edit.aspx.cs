using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using Tea.Common;

namespace Tea.Web.admin.about
{
    public partial class article_edit : Web.UI.ManagePage
    {
        private string action = TWEnums.ActionEnum.Add.ToString(); //操作类型
        protected string channel_name = string.Empty; //频道名称
        protected int channel_id;
        private int id = 0;

        //页面初始化事件
        protected void Page_Init(object sernder, EventArgs e)
        {
            this.channel_id = TWRequest.GetQueryInt("channel_id");
        }

        //页面加载事件
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = TWRequest.GetQueryString("action");

            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back");
                return;
            }
            this.channel_name = new BLL.channel().GetChannelName(this.channel_id); //取得频道名称

            //如果是编辑或复制则检查信息是否存在
            if (_action == TWEnums.ActionEnum.Edit.ToString() || _action == TWEnums.ActionEnum.Copy.ToString())
            {
                this.action = _action;//修改类型
                this.id = TWRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back");
                    return;
                }
                if (!new BLL.about().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.View.ToString()); //检查权限
 
                TreeBind(this.channel_id); //绑定类别
                if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }
 
        #region 绑定类别=================================
        private void TreeBind(int _channel_id)
        {
            if (_channel_id == 1)
            {
                ddlCategoryId.DataSource = new Tea.BLL.basic().GetList(0, "basic_where='about'", "basic_sort");
                ddlCategoryId.DataTextField = "basic_label";
                ddlCategoryId.DataValueField = "basic_value";
                ddlCategoryId.DataBind();
            }
            ddlCategoryId.Items.Insert(0, new ListItem("請選擇...", "0"));
        }
        #endregion
 
        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.about bll = new BLL.about();
            Model.about model = bll.GetModel(_id);

            ddlCategoryId.SelectedValue = model.category_id.ToString();
            txtCallIndex.Text = model.call_index;
            txtTitle.Text = model.title;
            txtLinkUrl.Text = model.link_url;
            //不是相册图片就绑定
            string filename = model.img_url.Substring(model.img_url.LastIndexOf("/") + 1);
            if (!filename.StartsWith("thumb_"))
            {
                txtImgUrl.Text = model.img_url;
            }
            txtSeoTitle.Text = model.seo_title;
            txtSeoKeywords.Text = model.seo_keywords;
            txtSeoDescription.Text = model.seo_description;
            txtZhaiyao.Text = model.zhaiyao;
            txtContent.Value = model.content;
            txtSortId.Text = model.sort_id.ToString();
            txtClick.Text = model.click.ToString();
            rblStatus.SelectedValue = model.status.ToString();
            if (action == TWEnums.ActionEnum.Edit.ToString())
            {
                txtAddTime.Text = model.add_time.ToString("yyyy-MM-dd");
            }
            if (model.is_msg == 1)
            {
                cblItem.Items[0].Selected = true;
            }
           
            if (model.is_slide == 1)
            {
                cblItem.Items[1].Selected = true;
            }
          
  
        }
        #endregion
 
        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.about model = new Model.about();
            BLL.about bll = new BLL.about();

            model.channel_id = this.channel_id;
            model.category_id = Utils.StrToInt(ddlCategoryId.SelectedValue, 0);
            model.call_index = txtCallIndex.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.img_url = txtImgUrl.Text;
            model.seo_title = txtSeoTitle.Text.Trim();
            model.seo_keywords = txtSeoKeywords.Text.Trim();
            model.seo_description = txtSeoDescription.Text.Trim();
            //内容摘要提取内容前255个字符
            if (string.IsNullOrEmpty(txtZhaiyao.Text.Trim()))
            {
                model.zhaiyao = Utils.DropHTML(txtContent.Value, 255);
            }
            else
            {
                model.zhaiyao = Utils.DropHTML(txtZhaiyao.Text, 255);
            }
            model.content = txtContent.Value;
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.click = int.Parse(txtClick.Text.Trim());
            model.status = Utils.StrToInt(rblStatus.SelectedValue, 0);
            model.is_msg = 0;
         
            model.is_slide = 0;
            if (cblItem.Items[0].Selected == true)
            {
                model.is_msg = 1;
            }
            
            if (cblItem.Items[1].Selected == true)
            {
                model.is_slide = 1;
            }
            model.is_sys = 1; //管理员发布
            model.user_name = GetAdminInfo().user_name; //获得当前登录用户名
            model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim());

            if (bll.Add(model) > 0)
            {
                AddAdminLog(TWEnums.ActionEnum.Add.ToString(), "添加" + this.channel_name + "频道内容:" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.about bll = new BLL.about();
            Model.about model = bll.GetModel(_id);

            model.channel_id = this.channel_id;
            model.category_id = Utils.StrToInt(ddlCategoryId.SelectedValue, 0);
            model.call_index = txtCallIndex.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.img_url = txtImgUrl.Text;
            model.seo_title = txtSeoTitle.Text.Trim();
            model.seo_keywords = txtSeoKeywords.Text.Trim();
            model.seo_description = txtSeoDescription.Text.Trim();
            //内容摘要提取内容前255个字符
            if (string.IsNullOrEmpty(txtZhaiyao.Text.Trim()))
            {
                model.zhaiyao = Utils.DropHTML(txtContent.Value, 255);
            }
            else
            {
                model.zhaiyao = Utils.DropHTML(txtZhaiyao.Text, 255);
            }
            model.content = txtContent.Value;
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.click = int.Parse(txtClick.Text.Trim());
            model.status = Utils.StrToInt(rblStatus.SelectedValue, 0);
            model.is_msg = 0;
       
            model.is_slide = 0;
            if (cblItem.Items[0].Selected == true)
            {
                model.is_msg = 1;
            }
            
            if (cblItem.Items[1].Selected == true)
            {
                model.is_slide = 1;
            }
            model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim());
            model.update_time = DateTime.Now;
            if (bll.Update(model))
            {

                AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "修改" + this.channel_name + "频道内容:" + model.title); //记录日志
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
                ChkAdminLevelEdit("site_about", "Edit");
                //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("儲存过程中发生错误啦！", string.Empty);
                    return;
                }
                JscriptMsg("修改信息成功！", "list.aspx?channel_id=" + this.channel_id);
            }
            else //添加
            {
                ChkAdminLevelEdit("site_about", "Edit");
                //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("儲存过程中发生错误！", string.Empty);
                    return;
                }
                JscriptMsg("添加信息成功！", "list.aspx?channel_id=" + this.channel_id);
            }
        }

    }
}