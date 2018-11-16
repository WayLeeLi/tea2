using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Common;

namespace Tea.Web.admin.article
{
    public partial class category_list : Web.UI.ManagePage
    {
        protected int channel_id;
        protected string channel_name = string.Empty; //頻道名稱

        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = TWRequest.GetQueryInt("channel_id");
            this.channel_name = new BLL.channel().GetChannelName(this.channel_id); //取得頻道名稱
            if (this.channel_id == 0)
            {
                JscriptMsg("頻道參數不正確！", "back");
                return;
            }
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("channel_" + this.channel_name + "_category", TWEnums.ActionEnum.View.ToString()); //檢查許可權
                RptBind();
            }
        }

        //資料綁定
        private void RptBind()
        {
            BLL.article_category bll = new BLL.article_category();
            DataTable dt = bll.GetList(0, this.channel_id);
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }

        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
                HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
                string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
                string LitImg1 = "<span class=\"folder-open\"></span>";
                string LitImg2 = "<span class=\"folder-line\"></span>";

                int classLayer = Convert.ToInt32(hidLayer.Value);
                if (classLayer == 1)
                {
                    LitFirst.Text = LitImg1;
                }
                else
                {
                    LitFirst.Text = string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1);
                }
            }
        }

        //儲存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("channel_" + this.channel_name + "_category", TWEnums.ActionEnum.Edit.ToString()); //檢查許可權
            BLL.article_category bll = new BLL.article_category();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sort_id=" + sortId.ToString());
            }
            AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "儲存" + this.channel_name + "頻道欄位分類排序"); //記錄日誌
            JscriptMsg("儲存排序成功！", Utils.CombUrlTxt("category_list.aspx", "channel_id={0}", this.channel_id.ToString()));
        }

        //刪除類別
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevelEdit("channel_goods_category", "Edit");
            //ChkAdminLevel("channel_" + this.channel_name + "_category", TWEnums.ActionEnum.Delete.ToString()); //檢查許可權
            BLL.article_category bll = new BLL.article_category();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "刪除" + this.channel_name + "頻道欄位分類資料"); //記錄日誌
            JscriptMsg("刪除資料成功！", Utils.CombUrlTxt("category_list.aspx", "channel_id={0}", this.channel_id.ToString()));
        }

        public string getnum(string id)
        {
            string str = "0";
            try
            {
                str = Tea.DBUtility.DbHelperSQL.Query("select count(id) from view_goods where category_id=" + id + " and wheresql='tuan'").Tables[0].Rows[0][0].ToString();
            }
            catch (Exception eee)
            { }
            return str;
        }
        protected void btnOnsale_Click(object sender, EventArgs e)
        {
            BLL.article_category bll = new BLL.article_category();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.UpdateField(id, "call_index='1'");
                }
            }
         
            JscriptMsg("成功送出！", Utils.CombUrlTxt("category_list.aspx", "channel_id={0}", this.channel_id.ToString()));
        }
        protected void btnOffsale_Click(object sender, EventArgs e)
        {
            BLL.article_category bll = new BLL.article_category();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.UpdateField(id,"call_index='0'");
                }
            }
            JscriptMsg("成功送出！", Utils.CombUrlTxt("category_list.aspx", "channel_id={0}", this.channel_id.ToString()));
        }
}
}
