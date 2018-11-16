using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using Tea.Common;

namespace Tea.Web.admin.product
{
    public partial class edit : Web.UI.ManagePage
    {
        private string action = TWEnums.ActionEnum.Add.ToString(); //操作類型
        protected string channel_name = string.Empty; //頻道名稱
        protected int channel_id;
        private int id = 0;
        protected string url;
        //頁面初始化事件
        protected void Page_Init(object sernder, EventArgs e)
        {
            this.channel_id = TWRequest.GetQueryInt("channel_id");

        }

        //頁面載入事件
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = TWRequest.GetQueryString("action");
            url = TWRequest.GetQueryString("url");
            if (this.channel_id == 0)
            {
                JscriptMsg("頻道參數不正確！", "back");
                return;
            }
            this.channel_name = new BLL.channel().GetChannelName(this.channel_id); //取得頻道名稱

            //如果是編輯或複製則檢查資料是否存在
            if (_action == TWEnums.ActionEnum.Edit.ToString() || _action == TWEnums.ActionEnum.Copy.ToString())
            {
                this.action = _action;//修改類型
                this.id = TWRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("傳輸參數不正確！", "back");
                    return;
                }
                if (!new BLL.article().Exists(this.id))
                {
                    JscriptMsg("資訊不存在或已被刪除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                txtAddTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.View.ToString()); //檢查許可權
 
                GroupBind("1=2"); //綁定用戶組
                TreeBind(this.channel_id); //綁定類別
              
               
                if (action == TWEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 綁定類別=================================
        private void TreeBind(int _channel_id)
        {
            BLL.article_category bll = new BLL.article_category();
            DataTable dt = bll.GetList(0, _channel_id);

            this.ddlCategoryId.Items.Clear();
            this.ddlCategoryId.Items.Add(new ListItem("請選擇類別...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
            }

            cbMore.DataSource = dt;
            cbMore.DataTextField = "title";
            cbMore.DataValueField = "id";
            cbMore.DataBind();

        }
        #endregion

        #region 綁定會員組===============================
        private void GroupBind(string strWhere)
        {
            //檢查網站是否開啟會員功能
            if (siteConfig.memberstatus == 0)
            {
                return;
            }
            //檢查該頻道是否開啟會員組價格
            Model.channel model = new BLL.channel().GetModel(this.channel_id);
            if (model == null || model.is_spec == 0)
            {
                return;
            }
            BLL.user_groups bll = new BLL.user_groups();
            DataSet ds = bll.GetList(0, strWhere, "grade asc,id desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.rptPrice.DataSource = ds;
                this.rptPrice.DataBind();
            }
        }
        #endregion

        #region 賦值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.article bll = new BLL.article();
            Model.article model = bll.GetModel(_id);

            ddlCategoryId.SelectedValue = model.category_id.ToString();
            ddlType.SelectedValue = model.brand_id.ToString();
         
            txtCallIndex.Text = model.call_index;
            txtTitle.Text = model.title;
            txtLinkUrl.Text = model.link_url;
            //不是相冊圖片就綁定
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
                txtBeginTime.Text = model.begin_time.ToString("yyyy-MM-dd");
                txtEndTime.Text = model.end_time.ToString("yyyy-MM-dd");
                if (model.update_time != null)
                {
                    txtUpdate.Text = model.update_time.GetValueOrDefault().ToString("yyyy-MM-dd");
                }
                if (model.xia_date != null)
                {
                    txt_Xia_Date.Text = model.xia_date.GetValueOrDefault().ToString("yyyy-MM-dd");
                }
            }
            if (model.is_tui == 1)
            {
                cblItem.Items[0].Selected = true;
            }

            if (model.is_zhe == 1)
            {
                cblItem.Items[1].Selected = true;
            }
 
            //擴展欄位賦值

            txtGuige.Text = model.guige;
          
            txtGuigeMore.Value = model.guigemore;
            txtShuo.Value = model.shuoming;

            IList _list = model.more_type.Split(',');
            foreach (ListItem li in cbMore.Items)
            {
                if (_list.Contains(li.Value))
                {
                    li.Selected = true;
                }
            }
      
            txtSub_title.Text = model.sub_title;
            txtPoint.Text = model.point.ToString();
            txtSell_price.Text = model.sell_price.ToString("0.");
            txtMarket_price.Text = model.market_price.ToString("0.");
            
            txtGoods_no.Text = model.goods_no;

            data_list.DataSource = new Tea.BLL.goods().GetList("parent_id=" + id + "");
            data_list.DataBind();
            txtZhuyi.Text = model.zhuyi.Replace("|", "/s");
            if (model.is_msg == 1)
            {
                cbIsLock.Checked = true;
            }
            try
            {
                txtTag.Text = model.tags.Split('$')[0].ToString();
                txtTag1.Text = model.tags.Split('$')[1].ToString();
                txtTag2.Text = model.tags.Split('$')[2].ToString();
            }
            catch (Exception eee) { }
            //連結圖片相冊
            if (filename.StartsWith("thumb_"))
            {
                hidFocusPhoto.Value = model.img_url; //封面圖片
            }
            rptAlbumList.DataSource = model.albums;
            rptAlbumList.DataBind();
     
            //賦值用戶組價格
            if (model.group_price != null)
            {
                for (int i = 0; i < this.rptPrice.Items.Count; i++)
                {
                    int hideId = Convert.ToInt32(((HiddenField)this.rptPrice.Items[i].FindControl("hideGroupId")).Value);
                    foreach (Model.user_group_price modelt in model.group_price)
                    {
                        if (hideId == modelt.group_id)
                        {
                            ((HiddenField)this.rptPrice.Items[i].FindControl("hidePriceId")).Value = modelt.id.ToString();
                            ((TextBox)this.rptPrice.Items[i].FindControl("txtGroupPrice")).Text = modelt.price.ToString();
                        }
                    }
                }
            }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.article model = new Model.article();
            BLL.article bll = new BLL.article();
            model.wheresql = "tuan";
            model.channel_id = this.channel_id;
            model.category_id = Utils.StrToInt(ddlCategoryId.SelectedValue, 0);
            model.brand_id = Utils.StrToInt(ddlType.SelectedValue, 0);
           
            model.call_index = txtCallIndex.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.img_url = txtImgUrl.Text;
            model.seo_title = txtSeoTitle.Text.Trim();
            model.seo_keywords = txtSeoKeywords.Text.Trim();
            model.seo_description = txtSeoDescription.Text.Trim();
 
            //內容摘要提取內容前255個字元
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
            model.is_tui = 0;
            model.is_zhe = 0;
            if (cblItem.Items[0].Selected == true)
            {
                model.is_tui = 1;
            }
            if (cblItem.Items[1].Selected == true)
            {
                model.is_zhe = 1;
            }
            model.user_name = GetAdminInfo().user_name; //獲得當前登錄用戶名
            model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim());
            model.begin_time = Utils.StrToDateTime(txtBeginTime.Text.Trim());
            model.end_time = Utils.StrToDateTime(txtEndTime.Text.Trim());
            DateTime _end_time;
            if (DateTime.TryParse(txtUpdate.Text.Trim(), out _end_time))
            {
                model.update_time = _end_time;
            }
            DateTime __end_time;
            if (DateTime.TryParse(txt_Xia_Date.Text.Trim(), out __end_time))
            {
                model.xia_date = __end_time;
            }
            if (cbIsLock.Checked)
            {
                model.is_msg = 1;
            }
            else
            {
                model.is_msg = 0;
            }
            //分表
            model.sell_price = Utils.StrToDecimal(txtSell_price.Text, 0);
            model.market_price = Utils.StrToDecimal(txtMarket_price.Text, 0);
            model.point = Utils.StrToInt(txtPoint.Text, 0);
         
            model.goods_no = txtGoods_no.Text;
            model.update_time = DateTime.Now;
            model.guige = txtGuige.Text;
            model.sub_title = txtSub_title.Text;
            model.guigemore = txtGuigeMore.Value;
            model.shuoming = txtShuo.Value;
            model.zhuyi = txtZhuyi.Text.Replace("/s", "|");
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(',');
            foreach (ListItem li in cbMore.Items)
            {
                if (li.Selected)
                {
                    sb.AppendFormat("{0},", li.Value);
                }
            }
            model.more_type = sb.ToString();
            model.tags = txtTag.Text + "$" + txtTag1.Text + "$" + txtTag2.Text;
            #region 儲存相冊====================
            //檢查是否有自訂圖片
            if (txtImgUrl.Text.Trim() == "")
            {
                model.img_url = hidFocusPhoto.Value;
            }
            string[] albumArr = Request.Form.GetValues("hid_photo_name");
            string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
            if (albumArr != null && albumArr.Length > 0)
            {
                List<Model.article_albums> ls = new List<Model.article_albums>();
                for (int i = 0; i < albumArr.Length; i++)
                {
                    string[] imgArr = albumArr[i].Split('|');
                    if (imgArr.Length == 3)
                    {
                        if (!string.IsNullOrEmpty(remarkArr[i]))
                        {
                            ls.Add(new Model.article_albums { original_path = imgArr[1], thumb_path = imgArr[2], remark = remarkArr[i] });
                        }
                        else
                        {
                            ls.Add(new Model.article_albums { original_path = imgArr[1], thumb_path = imgArr[2] });
                        }
                    }
                }
                model.albums = ls;
            }
            #endregion
 
            //#region 儲存會員組價格==============
            //List<Model.user_group_price> priceList = new List<Model.user_group_price>();
            //for (int i = 0; i < rptPrice.Items.Count; i++)
            //{
            //    int _groupid = Convert.ToInt32(((HiddenField)rptPrice.Items[i].FindControl("hideGroupId")).Value);
            //    decimal _price = Convert.ToDecimal(((TextBox)rptPrice.Items[i].FindControl("txtGroupPrice")).Text.Trim());
            //    priceList.Add(new Model.user_group_price { group_id = _groupid, price = _price });
            //}
            //model.group_price = priceList;
            //#endregion
            if (Request.Form.GetValues("item_goods_no")==null || Request.Form.GetValues("item_goods_no").Length < 1)
            {
                JscriptMsg("請設定商品規格！", string.Empty);
                return false;
            }
            if (model.brand_id == 3)
            {
                if (string.IsNullOrEmpty(txtGuige.Text.Trim()) || txtGuige.Text.Trim().Length < 1)
                {
                    JscriptMsg("請輸入活動編號！", string.Empty);
                    return false;
                }
            }
            int aid = bll.Add(model);
            if (aid > 0)
            {
                #region 儲存子件==============
                BLL.goods bll_goods = new BLL.goods();
                string[] goods_no = Request.Form.GetValues("item_goods_no");
                string[] color = Request.Form.GetValues("item_color");
                string[] imgurl = Request.Form.GetValues("item_imgurl");
                string[] market_price = Request.Form.GetValues("item_market_price");
                string[] sell_price = Request.Form.GetValues("item_sell_price");
                string[] stock_quantity = Request.Form.GetValues("item_stock_quantity");
                string[] chang = Request.Form.GetValues("item_chang");
                string[] kuan = Request.Form.GetValues("item_kuan");
                string[] gao = Request.Form.GetValues("item_gao");
                string[] zhong = Request.Form.GetValues("item_zhong");
                if (goods_no != null && goods_no.Length > 0)
                {

                    for (int i = 0; i < goods_no.Length; i++)
                    {
                        Model.goods model_goods = new Model.goods();
                        model_goods.parent_id = aid;
                        model_goods.img_url = imgurl[i].ToString();
                        model_goods.market_price = Utils.StrToDecimal(market_price[i].ToString(),0);
                        model_goods.goods_no = goods_no[i].ToString();
                        model_goods.sell_price = Utils.StrToDecimal(sell_price[i].ToString(),0);
                        model_goods.stock_quantity = Utils.StrToInt(stock_quantity[i].ToString(),0);
                        model_goods.color = color[i].ToString();
                        model_goods.guige = color[i].ToString();
                        model_goods.chang = Utils.StrToDecimal(chang[i].ToString(), 0);
                        model_goods.kuan = Utils.StrToDecimal(kuan[i].ToString(), 0);
                        model_goods.gao = Utils.StrToDecimal(gao[i].ToString(), 0);
                        model_goods.zhong = Utils.StrToDecimal(zhong[i].ToString(), 0);
                        int newid = bll_goods.Add(model_goods);
                        if (newid > 0 && i == 0)
                        {
                            bll.UpdateField(aid, "sales_id=" + newid + "");
                        }
                    }

                }
                #endregion

                AddAdminLog(TWEnums.ActionEnum.Add.ToString(), "添加" + this.channel_name + "頻道內容:" + model.title); //記錄日誌
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.article bll = new BLL.article();
            Model.article model = bll.GetModel(_id);

            model.channel_id = this.channel_id;
            model.category_id = Utils.StrToInt(ddlCategoryId.SelectedValue, 0);
            model.brand_id = Utils.StrToInt(ddlType.SelectedValue, 0);
          
            model.call_index = txtCallIndex.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.img_url = txtImgUrl.Text;
            model.seo_title = txtSeoTitle.Text.Trim();
            model.seo_keywords = txtSeoKeywords.Text.Trim();
            model.seo_description = txtSeoDescription.Text.Trim();
 
            //內容摘要提取內容前255個字元
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
            model.is_tui = 0;
            model.is_zhe = 0;
            if (cblItem.Items[0].Selected == true)
            {
                model.is_tui = 1;
            }
            if (cblItem.Items[1].Selected == true)
            {
                model.is_zhe = 1;
            }
            model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim());
            model.begin_time = Utils.StrToDateTime(txtBeginTime.Text.Trim());
            model.end_time = Utils.StrToDateTime(txtEndTime.Text.Trim());
            DateTime _end_time;
            if (DateTime.TryParse(txtUpdate.Text.Trim(), out _end_time))
            {
                model.update_time = _end_time;
            }
            DateTime __end_time;
            if (DateTime.TryParse(txt_Xia_Date.Text.Trim(), out __end_time))
            {
                model.xia_date = __end_time;
            }
            if (cbIsLock.Checked)
            {
                model.is_msg = 1;
            }
            else
            {
                model.is_msg = 0;
            }
            //分表
            model.sell_price = Utils.StrToDecimal(txtSell_price.Text, 0);
            model.market_price = Utils.StrToDecimal(txtMarket_price.Text, 0);
            model.point = Utils.StrToInt(txtPoint.Text, 0);
 
            model.goods_no = txtGoods_no.Text;
            model.guige = txtGuige.Text;
            model.sub_title = txtSub_title.Text;
            model.guigemore = txtGuigeMore.Value;
            model.shuoming = txtShuo.Value;
            model.zhuyi = txtZhuyi.Text.Replace("/s", "|");
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(',');
            foreach (ListItem li in cbMore.Items)
            {
                if (li.Selected)
                {
                    sb.AppendFormat("{0},", li.Value);
                }
            }
            model.more_type = sb.ToString();

            model.tags = txtTag.Text + "$" + txtTag1.Text + "$" + txtTag2.Text;
            #region 儲存相冊====================
            //檢查是否有自訂圖片
            if (txtImgUrl.Text.Trim() == "")
            {
                model.img_url = hidFocusPhoto.Value;
            }
            if (model.albums != null)
            {
                model.albums.Clear();
            }
            string[] albumArr = Request.Form.GetValues("hid_photo_name");
            string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
            if (albumArr != null)
            {
                List<Model.article_albums> ls = new List<Model.article_albums>();
                for (int i = 0; i < albumArr.Length; i++)
                {
                    string[] imgArr = albumArr[i].Split('|');
                    int img_id = Utils.StrToInt(imgArr[0], 0);
                    if (imgArr.Length == 3)
                    {
                        if (!string.IsNullOrEmpty(remarkArr[i]))
                        {
                            ls.Add(new Model.article_albums { id = img_id, article_id = _id, original_path = imgArr[1], thumb_path = imgArr[2], remark = remarkArr[i] });
                        }
                        else
                        {
                            ls.Add(new Model.article_albums { id = img_id, article_id = _id, original_path = imgArr[1], thumb_path = imgArr[2] });
                        }
                    }
                }
                model.albums = ls;
            }
            #endregion
 
            //#region 儲存會員組價格==============
            //List<Model.user_group_price> priceList = new List<Model.user_group_price>();
            //for (int i = 0; i < rptPrice.Items.Count; i++)
            //{
            //    int hidPriceId = 0;
            //    if (!string.IsNullOrEmpty(((HiddenField)rptPrice.Items[i].FindControl("hidePriceId")).Value))
            //    {
            //        hidPriceId = Convert.ToInt32(((HiddenField)rptPrice.Items[i].FindControl("hidePriceId")).Value);
            //    }
            //    int hidGroupId = Convert.ToInt32(((HiddenField)rptPrice.Items[i].FindControl("hideGroupId")).Value);
            //    decimal _price = Convert.ToDecimal(((TextBox)rptPrice.Items[i].FindControl("txtGroupPrice")).Text.Trim());
            //    priceList.Add(new Model.user_group_price { id = hidPriceId, article_id = _id, group_id = hidGroupId, price = _price });
            //}
            //model.group_price = priceList;
            //#endregion
            if (Request.Form.GetValues("item_goods_no") == null || Request.Form.GetValues("item_goods_no").Length < 1)
            {
                JscriptMsg("請設定商品規格！", string.Empty);
                return false;
            }
            #region 儲存子件==============
            BLL.goods bll_goods = new BLL.goods();
            StringBuilder idList = new StringBuilder();
            string[] itemid = Request.Form.GetValues("item_id");
            string[] goods_no = Request.Form.GetValues("item_goods_no");
            string[] color = Request.Form.GetValues("item_color");
            string[] imgurl = Request.Form.GetValues("item_imgurl");
            string[] market_price = Request.Form.GetValues("item_market_price");
            string[] sell_price = Request.Form.GetValues("item_sell_price");
            string[] stock_quantity = Request.Form.GetValues("item_stock_quantity");
            string[] chang = Request.Form.GetValues("item_chang");
            string[] kuan = Request.Form.GetValues("item_kuan");
            string[] gao = Request.Form.GetValues("item_gao");
            string[] zhong = Request.Form.GetValues("item_zhong");


            if (goods_no != null && goods_no.Length > 0)
            {

                for (int i = 0; i < goods_no.Length; i++)
                {
                    Model.goods model_goods = null;
                    int id = int.Parse(itemid[i].ToString());
                    bool update = true;
                    if (id == 0)
                    {
                        model_goods = new Model.goods();
                        update = false;
                    }
                    else
                    {
                        model_goods = bll_goods.GetModel(id);
                    }

                    model_goods.parent_id = model.id;
                    model_goods.img_url = imgurl[i].ToString();
                    model_goods.market_price = Utils.StrToDecimal(market_price[i].ToString(), 0);
                    model_goods.goods_no = goods_no[i].ToString();
                    model_goods.sell_price = Utils.StrToDecimal(sell_price[i].ToString(), 0);
                    model_goods.stock_quantity = Utils.StrToInt(stock_quantity[i].ToString(), 0);
                    model_goods.color = color[i].ToString();
                    model_goods.guige = color[i].ToString();
                    model_goods.chang = Utils.StrToDecimal(chang[i].ToString(), 0);
                    model_goods.kuan = Utils.StrToDecimal(kuan[i].ToString(), 0);
                    model_goods.gao = Utils.StrToDecimal(gao[i].ToString(), 0);
                    model_goods.zhong = Utils.StrToDecimal(zhong[i].ToString(), 0);
                    if (update)
                    {
                        bll_goods.Update(model_goods);
                        idList.Append(model_goods.id + ",");
                    }
                    else
                    {
                        int a = bll_goods.Add(model_goods);
                        idList.Append(a + ",");
                    }

                }

            }


            string id_list = Utils.DelLastChar(idList.ToString(), ",");
            if (!string.IsNullOrEmpty(id_list))
            {
                Tea.DBUtility.DbHelperSQL.ExecuteSql("delete from shop_goods where parent_id=" + model.id + " and id not in(select id from shop_goods where id in(" + id_list + "))");
            }
            #endregion

            if (bll.Update(model))
            {
                AddAdminLog(TWEnums.ActionEnum.Edit.ToString(), "修改" + this.channel_name + "頻道內容:" + model.title); //記錄日誌
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
                ChkAdminLevelEdit("channel_goods", "Edit");
                //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.Edit.ToString()); //檢查許可權
                if (!DoEdit(this.id))
                {
                    JscriptMsg("儲存過程中發生錯誤！", string.Empty);
                    return;
                }
                JscriptMsg("修改資料成功！", "tuan_list.aspx?channel_id=" + this.channel_id + "&" + url.Replace("|", "=").Replace("-", "&"));
            }
            else //添加
            {
                ChkAdminLevelEdit("channel_goods", "Edit");
                //ChkAdminLevel("channel_" + this.channel_name + "_list", TWEnums.ActionEnum.Add.ToString()); //檢查許可權
                if (!DoAdd())
                {
                    JscriptMsg("儲存過程中發生錯誤！", string.Empty);
                    return;
                }
                JscriptMsg("添加資料成功！", "tuan_list.aspx?channel_id=" + this.channel_id);
            }
        }

    
    }
}
