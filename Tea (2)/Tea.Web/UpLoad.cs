using System;
using System.Collections;
using System.Web;
using System.IO;
using System.Drawing;
using System.Net;
using System.Configuration;
using Tea.Common;

namespace Tea.Web.UI
{
    public class UpLoad
    {
        private Model.siteconfig siteConfig;

        public UpLoad()
        {
            siteConfig = new BLL.siteconfig().loadConfig();
        }

        /// <summary>
        /// 裁剪圖片並儲存
        /// </summary>
        public bool cropSaveAs(string fileName, string newFileName, int maxWidth, int maxHeight, int cropWidth, int cropHeight, int X, int Y)
        {
            string fileExt = Utils.GetFileExt(fileName); //文件副檔名，不含“.”
            if (!IsImage(fileExt))
            {
                return false;
            }
            string newFileDir = Utils.GetMapPath(newFileName.Substring(0, newFileName.LastIndexOf(@"/") + 1));
            //檢查是否有該路徑，沒有則創建
            if (!Directory.Exists(newFileDir))
            {
                Directory.CreateDirectory(newFileDir);
            }
            try
            {
                string fileFullPath = Utils.GetMapPath(fileName);
                string toFileFullPath = Utils.GetMapPath(newFileName);
                return Thumbnail.MakeThumbnailImage(fileFullPath, toFileFullPath, 180, 180, cropWidth, cropHeight, X, Y);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 檔上傳方法
        /// </summary>
        /// <param name="postedFile">文件流</param>
        /// <param name="isThumbnail">是否生成縮略圖</param>
        /// <param name="isWater">是否加浮水印</param>
        /// <returns>上傳後檔案資訊</returns>
        public string fileSaveAs(HttpPostedFile postedFile, bool isThumbnail, bool isWater)
        {
            try
            {
                string fileExt = Utils.GetFileExt(postedFile.FileName); //文件副檔名，不含“.”
                int fileSize = postedFile.ContentLength; //獲得檔案大小，以位元組為單位
                string fileName = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf(@"\") + 1); //取得原檔案名
                string newFileName = Utils.GetRamCode() + "." + fileExt; //隨機生成新的檔案名
                string newThumbnailFileName = "thumb_" + newFileName; //隨機生成縮略圖檔案名
                string upLoadPath = GetUpLoadPath(); //上傳目錄相對路徑
                string fullUpLoadPath = Utils.GetMapPath(upLoadPath); //上傳目錄的物理路徑
                string newFilePath = upLoadPath + newFileName; //上傳後的路徑
                string newThumbnailPath = upLoadPath + newThumbnailFileName; //上傳後的縮略圖路徑

                //檢查檔案副檔名是否合法
                if (!CheckFileExt(fileExt))
                {
                    return "{\"status\": 0, \"msg\": \"不允許上傳" + fileExt + "類型的檔案！\"}";
                }
                //檢查檔案大小是否合法
                if (!CheckFileSize(fileExt, fileSize))
                {
                    return "{\"status\": 0, \"msg\": \"檔案超過限制的大小！\"}";
                }
                //檢查上傳的物理路徑是否存在，不存在則創建
                if (!Directory.Exists(fullUpLoadPath))
                {
                    Directory.CreateDirectory(fullUpLoadPath);
                }

                //儲存檔案
                postedFile.SaveAs(fullUpLoadPath + newFileName);
                //如果是圖片，檢查圖片是否超出最大尺寸，是則裁剪
                if (IsImage(fileExt) && (this.siteConfig.imgmaxheight > 0 || this.siteConfig.imgmaxwidth > 0))
                {
                    Thumbnail.MakeThumbnailImage(fullUpLoadPath + newFileName, fullUpLoadPath + newFileName,
                        this.siteConfig.imgmaxwidth, this.siteConfig.imgmaxheight);
                }
                //如果是圖片，檢查是否需要生成縮略圖，是則生成
                if (IsImage(fileExt) && isThumbnail && this.siteConfig.thumbnailwidth > 0 && this.siteConfig.thumbnailheight > 0)
                {
                    Thumbnail.MakeThumbnailImage(fullUpLoadPath + newFileName, fullUpLoadPath + newThumbnailFileName,
                        this.siteConfig.thumbnailwidth, this.siteConfig.thumbnailheight, "Cut");
                }
                else
                {
                    newThumbnailPath = newFilePath; //不生成縮略圖則返回原圖
                }
                //如果是圖片，檢查是否需要打浮水印
                if (IsWaterMark(fileExt) && isWater)
                {
                    switch (this.siteConfig.watermarktype)
                    {
                        case 1:
                            WaterMark.AddImageSignText(newFilePath, newFilePath,
                                this.siteConfig.watermarktext, this.siteConfig.watermarkposition,
                                this.siteConfig.watermarkimgquality, this.siteConfig.watermarkfont, this.siteConfig.watermarkfontsize);
                            break;
                        case 2:
                            WaterMark.AddImageSignPic(newFilePath, newFilePath,
                                this.siteConfig.watermarkpic, this.siteConfig.watermarkposition,
                                this.siteConfig.watermarkimgquality, this.siteConfig.watermarktransparency);
                            break;
                    }
                }
                //處理完畢，返回JOSN格式的檔資訊
                return "{\"status\": 1, \"msg\": \"上傳檔案成功！\", \"name\": \""
                    + fileName + "\", \"path\": \"" + newFilePath + "\", \"thumb\": \""
                    + newThumbnailPath + "\", \"size\": " + fileSize + ", \"ext\": \"" + fileExt + "\"}";
            }
            catch
            {
                return "{\"status\": 0, \"msg\": \"上傳過程中發生意外錯誤！\"}";
            }
        }

        /// <summary>
        /// 儲存遠端檔到本地
        /// </summary>
        /// <param name="fileUri">URI地址</param>
        /// <returns>上傳後的路徑</returns>
        public string remoteSaveAs(string fileUri)
        {
            WebClient client = new WebClient();
            string fileExt = string.Empty; //文件副檔名，不含“.”
            if (fileUri.LastIndexOf(".") == -1)
            {
                fileExt = "gif";
            }
            else
            {
                fileExt = Utils.GetFileExt(fileUri);
            }
            string newFileName = Utils.GetRamCode() + "." + fileExt; //隨機生成新的檔案名
            string upLoadPath = GetUpLoadPath(); //上傳目錄相對路徑
            string fullUpLoadPath = Utils.GetMapPath(upLoadPath); //上傳目錄的物理路徑
            string newFilePath = upLoadPath + newFileName; //上傳後的路徑
            //檢查上傳的物理路徑是否存在，不存在則創建
            if (!Directory.Exists(fullUpLoadPath))
            {
                Directory.CreateDirectory(fullUpLoadPath);
            }

            try
            {
                client.DownloadFile(fileUri, fullUpLoadPath + newFileName);
                //如果是圖片，檢查是否需要打浮水印
                if (IsWaterMark(fileExt))
                {
                    switch (this.siteConfig.watermarktype)
                    {
                        case 1:
                            WaterMark.AddImageSignText(newFilePath, newFilePath,
                                this.siteConfig.watermarktext, this.siteConfig.watermarkposition,
                                this.siteConfig.watermarkimgquality, this.siteConfig.watermarkfont, this.siteConfig.watermarkfontsize);
                            break;
                        case 2:
                            WaterMark.AddImageSignPic(newFilePath, newFilePath,
                                this.siteConfig.watermarkpic, this.siteConfig.watermarkposition,
                                this.siteConfig.watermarkimgquality, this.siteConfig.watermarktransparency);
                            break;
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
            client.Dispose();
            return newFilePath;
        }

        #region 私有方法
        /// <summary>
        /// 返回上傳目錄相對路徑
        /// </summary>
        /// <param name="fileName">上傳檔案名</param>
        private string GetUpLoadPath()
        {
            string path = siteConfig.webpath + siteConfig.filepath + "/"; //網站目錄+上傳目錄
            switch (this.siteConfig.filesave)
            {
                case 1: //按年月日每天一個資料夾
                    path += DateTime.Now.ToString("yyyyMMdd");
                    break;
                default: //按年月/日存入不同的資料夾
                    path += DateTime.Now.ToString("yyyyMM") + "/" + DateTime.Now.ToString("dd");
                    break;
            }
            return path + "/";
        }

        /// <summary>
        /// 是否需要打浮水印
        /// </summary>
        /// <param name="_fileExt">文件副檔名，不含“.”</param>
        private bool IsWaterMark(string _fileExt)
        {
            //判斷是否開啟浮水印
            if (this.siteConfig.watermarktype > 0)
            {
                //判斷是否可以打浮水印的圖片類型
                ArrayList al = new ArrayList();
                al.Add("bmp");
                al.Add("jpeg");
                al.Add("jpg");
                al.Add("png");
                if (al.Contains(_fileExt.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否為圖片檔
        /// </summary>
        /// <param name="_fileExt">文件副檔名，不含“.”</param>
        private bool IsImage(string _fileExt)
        {
            ArrayList al = new ArrayList();
            al.Add("bmp");
            al.Add("jpeg");
            al.Add("jpg");
            al.Add("gif");
            al.Add("png");
            if (al.Contains(_fileExt.ToLower()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 檢查是否為合法的上傳檔案
        /// </summary>
        private bool CheckFileExt(string _fileExt)
        {
            //檢查危險檔案
            string[] excExt = { "asp", "aspx", "ashx", "asa", "asmx", "asax", "php", "jsp", "htm", "html" };
            for (int i = 0; i < excExt.Length; i++)
            {
                if (excExt[i].ToLower() == _fileExt.ToLower())
                {
                    return false;
                }
            }
            //檢查合法檔案
            string[] allowExt = (this.siteConfig.fileextension + "," + this.siteConfig.videoextension).Split(',');
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i].ToLower() == _fileExt.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 檢查檔大小是否合法
        /// </summary>
        /// <param name="_fileExt">文件副檔名，不含“.”</param>
        /// <param name="_fileSize">文件大小(B)</param>
        private bool CheckFileSize(string _fileExt, int _fileSize)
        {
            //將視頻副檔名轉換成ArrayList
            ArrayList lsVideoExt = new ArrayList(this.siteConfig.videoextension.ToLower().Split(','));
            //判斷是否為圖片檔
            if (IsImage(_fileExt))
            {
                if (this.siteConfig.imgsize > 0 && _fileSize > this.siteConfig.imgsize * 1024)
                {
                    return false;
                }
            }
            else if (lsVideoExt.Contains(_fileExt.ToLower()))
            {
                if (_fileSize > this.siteConfig.videosize * 1024)
                {
                    return false;
                }
            }
            else
            {
                if (this.siteConfig.attachsize > 0 && _fileSize > this.siteConfig.attachsize * 1024)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

    }
}
