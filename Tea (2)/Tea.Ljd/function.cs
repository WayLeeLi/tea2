using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Globalization;
using System.Web.SessionState;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net.Mime;
using Microsoft.Win32;
using System.Collections;
using System.Net;
using System.Data;
namespace ljd
{
    public class function
    {

        protected function()
        {
            ;
        }
        static function()
        {
            char[] desc = new char[] { 'a', 'x', 'y', 'c', 'b', 'w', 'z', 'd', 'e', 'g', 'f', '2', 'p', 'o', '3', 'r', '1', 'u', '4', 'i', 'h', '8', 'k', 'm', 'l', '7', 'n', '5', 'v', 's', 'j', 't', '0', '9', 'q', '6' };
            int i = 0;
            for (char a = '0'; a <= '9'; a++)
            {
                ht.Add(a, desc[i++]);
            }
            for (char a = 'a'; a <= 'z'; a++)
            {
                ht.Add(a, desc[i++]);
            }
        }
        //补齐4位码
        public static string bunum(string x)
        {
            string str = "";
            int q = 5 - x.Length;
            for (int i = 0; i < q; i++)
            {
                str = str + "0";
            }
            return str + x;
        }

        #region "js信息提示框"
        /// <summary>
        /// js信息提示框
        /// </summary>
        /// <param name="Message">提示信息文字</param>
        /// <param name="ReturnUrl">返回地址</param>
        /// <param name="rq"></param>
        public static void MessBox(string Message, string ReturnUrl, HttpContext rq)
        {
            System.Text.StringBuilder msgScript = new System.Text.StringBuilder();
            msgScript.Append("<script language=JavaScript>\n");
            msgScript.Append("alert(\"" + Message + "\");\n");
            msgScript.Append("parent.location.href='" + ReturnUrl + "';\n");
            msgScript.Append("</script>\n");
            rq.Response.Write(msgScript.ToString());
            rq.Response.End();
        }

        /// <summary>
        /// 弹出Alert信息窗
        /// </summary>
        /// <param name="Message">信息内容</param>
        public static void MessBox(string Message)
        {
            System.Text.StringBuilder msgScript = new System.Text.StringBuilder();
            msgScript.Append("<script language=JavaScript>\n");
            msgScript.Append("alert(\"" + Message + "\");\n");
            msgScript.Append("</script>\n");
            HttpContext.Current.Response.Write(msgScript.ToString());
        }

        #endregion

        #region 格式化字符串,符合SQL语句
        /// <summary>
        /// 格式化字符串,符合SQL语句
        /// </summary>
        /// <param name="formatStr">需要格式化的字符串</param>
        /// <returns>字符串</returns>
        public static string inSQL(string formatStr)
        {
            string rStr = formatStr;
            if (formatStr != null && formatStr != string.Empty)
            {
                rStr = rStr.Replace("'", "''");
                rStr = rStr.Replace("\"", "\"\"");
            }
            return rStr;
        }
        /// <summary>
        /// 格式化字符串,是inSQL的反向
        /// </summary>
        /// <param name="formatStr"></param>
        /// <returns></returns>
        public static string outSQL(string formatStr)
        {
            string rStr = formatStr;
            if (rStr != null)
            {
                rStr = rStr.Replace("''", "'");
                rStr = rStr.Replace("\"\"", "\"");
            }
            return rStr;
        }

        /// <summary>
        /// 查询SQL语句,删除一些SQL注入问题
        /// </summary>
        /// <param name="formatStr">需要格式化的字符串</param>
        /// <returns></returns>
        public static string querySQL(string formatStr)
        {
            string rStr = formatStr;
            if (formatStr != null && formatStr != string.Empty)
            {
                rStr = rStr.Trim().ToLower();
                rStr = rStr.Replace("'", "''");
                rStr = rStr.Replace(";--", "");
                rStr = rStr.Replace("--", "");
                rStr = rStr.Replace("\"", "\"\"");
                rStr = rStr.Replace("=", "");
                rStr = rStr.Replace("and", "");
                rStr = rStr.Replace("exec", "");
                rStr = rStr.Replace("insert", "");
                rStr = rStr.Replace("select", "");
                rStr = rStr.Replace("delete", "");
                rStr = rStr.Replace("update", "");
                rStr = rStr.Replace("chr", "");
                rStr = rStr.Replace("mid", "");
                rStr = rStr.Replace("master", "");
                rStr = rStr.Replace("or", "");
                rStr = rStr.Replace("truncate", "");
                rStr = rStr.Replace("char", "");
                rStr = rStr.Replace("declare", "");
                rStr = rStr.Replace("join", "");
                rStr = rStr.Replace("count", "");
                rStr = rStr.Replace("*", "");
                rStr = rStr.Replace("%", "");
                rStr = rStr.Replace("union", "");
            }

            return rStr;
        }
        #endregion

        #region 截取字符串
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str_value"></param>
        /// <param name="str_len"></param>
        /// <returns></returns>
        public static string leftx(string str_value, int str_len, string omit)
        {
            int p_num = 0;
            int i;
            string New_Str_value = "";

            if (str_value == "")
            {
                New_Str_value = "";
            }
            else
            {
                int Len_Num = str_value.Length;
                for (i = 0; i <= Len_Num - 1; i++)
                {
                    if (i > Len_Num) break;
                    char c = Convert.ToChar(str_value.Substring(i, 1));
                    if (((int)c > 255) || ((int)c < 0))
                        p_num = p_num + 2;
                    else
                        p_num = p_num + 1;



                    if (p_num >= str_len)
                    {

                        New_Str_value = str_value.Substring(0, i + 1) + omit;
                        break;
                    }
                    else
                    {
                        New_Str_value = str_value;
                    }

                }

            }
            return New_Str_value;
        }
        #endregion

        #region 检测用户提交页面
        /// <summary>
        /// 检测用户提交页面
        /// </summary>
        /// <param name="rq"></param>
        public static void Check_Post_Url(HttpContext rq)
        {
            string WebHost = "";
            if (rq.Request.ServerVariables["SERVER_NAME"] != null)
            {
                WebHost = rq.Request.ServerVariables["SERVER_NAME"].ToString();
            }

            string From_Url = "";
            if (rq.Request.UrlReferrer != null)
            {
                From_Url = rq.Request.UrlReferrer.ToString();
            }

            if (From_Url == "" || WebHost == "")
            {
                rq.Response.Write("禁止外部提交数据!");
                rq.Response.End();
            }
            else
            {
                WebHost = "HTTP://" + WebHost.ToUpper();
                From_Url = From_Url.ToUpper();
                int a = From_Url.IndexOf(WebHost);
                if (From_Url.IndexOf(WebHost) < 0)
                {
                    rq.Response.Write("禁止外部提交数据!");
                    rq.Response.End();
                }
            }

        }
        #endregion

        #region 日期处理
        /// <summary>
        /// 格式化日期为2006-12-22
        /// </summary>
        /// <param name="dTime"></param>
        /// <returns></returns>
        public static string formatDate(DateTime dTime)
        {
            string rStr;
            rStr = dTime.Year + "-" + dTime.Month + "-" + dTime.Day;
            return rStr;
        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <param name="sDate"></param>
        /// <returns></returns>
        public static string getWeek(DateTime sDate)
        {
            Calendar myCal = CultureInfo.InvariantCulture.Calendar;


            string rStr = "";
            switch (myCal.GetDayOfWeek(sDate).ToString())
            {
                case "Sunday":
                    rStr = "星期日";
                    break;
                case "Monday":
                    rStr = "星期一";
                    break;
                case "Tuesday":
                    rStr = "星期二";
                    break;
                case "Wednesday":
                    rStr = "星期三";
                    break;
                case "Thursday":
                    rStr = "星期四";
                    break;
                case "Friday":
                    rStr = "星期五";
                    break;
                case "Saturday":
                    rStr = "星期六";
                    break;
            }
            return rStr;
        }
        #endregion

        #region 随机颜色数据

        /// <summary>
        /// 随机颜色数据
        /// </summary>
        /// <returns></returns>
        public static string getStrColor()
        {
            int length = 6;
            byte[] random = new Byte[length / 2];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(random);

            StringBuilder sb = new StringBuilder(length);
            int i;
            for (i = 0; i < random.Length; i++)
            {
                sb.Append(String.Format("{0:X2}", random[i]));
            }
            return sb.ToString();
        }
        #endregion

        #region "隐藏IP地址最后一位用*号代替"
        /// <summary>
        /// 隐藏IP地址最后一位用*号代替
        /// </summary>
        /// <param name="Ipaddress">IP地址:192.168.34.23</param>
        /// <returns></returns>
        public static string HidenLastIp(string Ipaddress, string user)
        {
            if (Ipaddress.Contains("."))
            {
                return Ipaddress.Substring(0, Ipaddress.LastIndexOf(".")) + ".*";
            }
            else
            {
                return "<A href=\"user-" + Ipaddress + ".aspx\">" + user + "</a>";
            }
        }
        #endregion

        #region "防刷新检测"
        /// <summary>
        /// 防刷新检测
        /// </summary>
        /// <param name="Second">访问间隔秒</param>
        /// <param name="UserSession"></param>
        public static bool CheckRefurbish(int Second, HttpSessionState UserSession)
        {

            bool i = true;
            if (UserSession["RefTime"] != null)
            {
                DateTime d1 = Convert.ToDateTime(UserSession["RefTime"]);
                DateTime d2 = Convert.ToDateTime(DateTime.Now.ToString());
                TimeSpan d3 = d2.Subtract(d1);
                if (d3.Seconds < Second)
                {
                    i = false;
                }
                else
                {
                    UserSession["RefTime"] = DateTime.Now.ToString();
                }
            }
            else
            {
                UserSession["RefTime"] = DateTime.Now.ToString();
            }

            return i;
        }
        #endregion

        #region "判断是否是Decimal类型"
        /// <summary>
        /// 判断是否是Decimal类型
        /// </summary>
        /// <param name="TBstr0">判断数据字符</param>
        /// <returns>true是false否</returns>
        public static bool IsDecimal(string TBstr0)
        {
            bool IsBool = false;
            string Intstr0 = "1234567890";
            string IntSign0, StrInt, StrDecimal;
            int IntIndex0, IntSubstr, IndexInt;
            int decimalbool = 0;
            int db = 0;
            bool Bf, Bl;
            if (TBstr0.Length > 2)
            {
                IntIndex0 = TBstr0.IndexOf(".");
                if (IntIndex0 != -1)
                {
                    string StrArr = ".";
                    char[] CharArr = StrArr.ToCharArray();
                    string[] NumArr = TBstr0.Split(CharArr);
                    IndexInt = NumArr.GetUpperBound(0);
                    if (IndexInt > 1)
                    {
                        decimalbool = 1;
                    }
                    else
                    {
                        StrInt = NumArr[0].ToString();
                        StrDecimal = NumArr[1].ToString();
                        //--- 整数部分－－－－－
                        if (StrInt.Length > 0)
                        {
                            if (StrInt.Length == 1)
                            {
                                IntSubstr = Intstr0.IndexOf(StrInt);
                                if (IntSubstr != -1)
                                {
                                    Bf = true;
                                }
                                else
                                {
                                    Bf = false;
                                }
                            }
                            else
                            {
                                for (int i = 0; i <= StrInt.Length - 1; i++)
                                {
                                    IntSign0 = StrInt.Substring(i, 1).ToString();
                                    IntSubstr = Intstr0.IndexOf(IntSign0);
                                    if (IntSubstr != -1)
                                    {
                                        db = db + 0;
                                    }
                                    else
                                    {
                                        db = i + 1;
                                        break;
                                    }
                                }

                                if (db == 0)
                                {
                                    Bf = true;
                                }
                                else
                                {
                                    Bf = false;
                                }
                            }
                        }
                        else
                        {
                            Bf = true;
                        }
                        //----小数部分－－－－
                        if (StrDecimal.Length > 0)
                        {
                            for (int j = 0; j <= StrDecimal.Length - 1; j++)
                            {
                                IntSign0 = StrDecimal.Substring(j, 1).ToString();
                                IntSubstr = Intstr0.IndexOf(IntSign0);
                                if (IntSubstr != -1)
                                {
                                    db = db + 0;
                                }
                                else
                                {
                                    db = j + 1;
                                    break;
                                }
                            }
                            if (db == 0)
                            {
                                Bl = true;
                            }
                            else
                            {
                                Bl = false;
                            }
                        }
                        else
                        {
                            Bl = false;
                        }
                        if ((Bf && Bl) == true)
                        {
                            decimalbool = 0;
                        }
                        else
                        {
                            decimalbool = 1;
                        }

                    }

                }
                else
                {
                    decimalbool = 1;
                }

            }
            else
            {
                decimalbool = 1;
            }

            if (decimalbool == 0)
            {
                IsBool = true;
            }
            else
            {
                IsBool = false;
            }

            return IsBool;
        }
        #endregion

        #region "获取随机数"
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="length">随机数长度</param>
        /// <returns></returns>
        public static string GetRandomPassword(int length)
        {
            byte[] random = new Byte[length / 2];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(random);

            StringBuilder sb = new StringBuilder(length);
            int i;
            for (i = 0; i < random.Length; i++)
            {
                sb.Append(String.Format("{0:X2}", random[i]));
            }
            return sb.ToString();
        }
        #endregion

        #region "获取用户IP地址"
        /// <summary>
        /// 获取用户IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {

            string user_IP = string.Empty;
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    user_IP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else
                {
                    user_IP = System.Web.HttpContext.Current.Request.UserHostAddress;
                }
            }
            else
            {
                user_IP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            return user_IP;
        }
        #endregion

        #region "3des加密字符串"


        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptString(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }
        #endregion

        #region "3des解密字符串"
        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptString(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                byte[] rgbIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        #endregion

        #region "MD5加密"
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <param name="code">加密位数16/32</param>
        /// <returns></returns>
        public static string md5(string str, int code)
        {
            string strEncrypt = string.Empty;
            if (code == 16)
            {
                strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
            }

            if (code == 32)
            {
                strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            }

            return strEncrypt;
        }
        #endregion

        #region 脚本提示信息,并且跳转到最上层框架
        /// <summary>
        /// 脚本提示信息
        /// </summary>
        /// <param name="Msg">信息内容,可以为空,为空表示不出现提示窗口</param>
        /// <param name="Url">跳转地址</param>
        public static string Hint(string Msg, string Url)
        {
            System.Text.StringBuilder rStr = new System.Text.StringBuilder();

            rStr.Append("<script language='javascript'>");
            if (Msg != "")
                rStr.Append("	alert('" + Msg + "');");

            if (Url != "")
                rStr.Append("	window.top.location.href = '" + Url + "';");

            rStr.Append("</script>");

            return rStr.ToString();
        }
        #endregion

        #region 脚本提示信息,并且跳转到最上层框架
        /// <summary>
        /// 脚本提示信息
        /// </summary>
        /// <param name="Msg">信息内容,可以为空,为空表示不出现提示窗口</param>
        /// <param name="Url">跳转地址</param>
        public static string Hintopen(string Url)
        {
            System.Text.StringBuilder rStr = new System.Text.StringBuilder();

            rStr.Append("<script language='javascript'>");
           ;

            if (Url != "")
                rStr.Append(" window.top.location.href = '" + Url + "';");

            rStr.Append("</script>");

            return rStr.ToString();
        }
        #endregion

        #region 脚本提示信息,并且跳转到当前框架内
        /// <summary>
        /// 脚本提示信息
        /// </summary>
        /// <param name="Msg">信息内容,可以为空,为空表示不出现提示窗口</param>
        /// <param name="Url">跳转地址,自已可以写入脚本</param>
        /// <returns></returns>
        public static string LocalHintJs(string Msg, string Url)
        {
            System.Text.StringBuilder rStr = new System.Text.StringBuilder();

            rStr.Append("<script language='JavaScript'>\n");
            if (Msg != "")
                rStr.AppendFormat("	alert('{0}');\n", Msg);

            if (Url != "")
                rStr.Append(Url + "\n");
            rStr.Append("</script>");

            return rStr.ToString();
        }

        #endregion

        #region 脚本提示信息,并且跳转到当前框架内,地址为空时,返回上页
        /// <summary>
        /// 脚本提示信息
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static string LocalHint(string Msg, string Url)
        {
            System.Text.StringBuilder rStr = new System.Text.StringBuilder();

            rStr.Append("<script language='JavaScript'>\n");
            if (Msg != "")
                rStr.AppendFormat("	alert('{0}');\n", Msg);

            if (Url != "")
                rStr.AppendFormat("	window.location.href = '" + Url + "';\n");
            else
                rStr.AppendFormat(" window.history.back();");

            rStr.Append("</script>\n");

            return rStr.ToString();
        }
        #endregion

        #region "按当前日期和时间生成随机数"
        /// <summary>
        /// 按当前日期和时间生成随机数
        /// </summary>
        /// <param name="Num">附加随机数长度</param>
        /// <returns></returns>
        public static string sRndNum(int Num)
        {
            string sTmp_Str = System.DateTime.Today.Year.ToString() + System.DateTime.Today.Month.ToString("00") + System.DateTime.Today.Day.ToString("00") + System.DateTime.Now.Hour.ToString("00") + System.DateTime.Now.Minute.ToString("00") + System.DateTime.Now.Second.ToString("00");
            return (sTmp_Str + RndNum(Num)).ToString().Substring(0, Num);
        }
        #endregion

        #region 生成0-9随机数
        /// <summary>
        /// 生成0-9随机数
        /// </summary>
        /// <param name="VcodeNum">生成长度</param>
        /// <returns></returns>
        public static string RndNum(int VcodeNum)
        {
            StringBuilder sb = new StringBuilder(VcodeNum);
            Random rand = new Random();
            for (int i = 1; i < VcodeNum + 1; i++)
            {
                int t = rand.Next(9);
                sb.AppendFormat("{0}", t);
            }
            return sb.ToString();

        }
        #endregion

        #region "通过RNGCryptoServiceProvider 生成随机数 0-9"
        /// <summary>
        /// 通过RNGCryptoServiceProvider 生成随机数 0-9 
        /// </summary>
        /// <param name="length">随机数长度</param>
        /// <returns></returns>
        public static string RndNumRNG(int length)
        {
            byte[] bytes = new byte[16];
            RNGCryptoServiceProvider r = new RNGCryptoServiceProvider();
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                r.GetBytes(bytes);
                sb.AppendFormat("{0}", (int)((decimal)bytes[0] / 256 * 10));
            }
            return sb.ToString();

        }
        #endregion

        #region "在当前路径上创建日期格式目录(20060205)"
        /// <summary>
        /// 在当前路径上创建日期格式目录(20060205)
        /// </summary>
        /// <param name="sPath">返回目录名</param>
        /// <returns></returns>
        public static string CreateDir(string sPath, string file)
        {
            string sTemp = "";
            if (!string.IsNullOrEmpty(file))
            {
                sTemp = file;
            }
            else
            {
                sTemp = System.DateTime.Today.Year.ToString() + System.DateTime.Today.Month.ToString("00");
            }
            sPath += sTemp;
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@sPath); //构造函数创建目录
            if (di.Exists == false)
            {
                di.Create();
            }

            return sTemp;
        }
        #endregion

        #region "检测是否为有效邮件地址格式"
        /// <summary>
        /// 检测是否为有效邮件地址格式
        /// </summary>
        /// <param name="strIn">输入邮件地址</param>
        /// <returns></returns>
        public static bool IsValidEmail(string strIn)
        {
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        #endregion

        #region "邮件发送"
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="strto">接收邮件地址</param>
        /// <param name="strSubject">主题</param>
        /// <param name="strBody">内容</param>
        public static void SendSMTPEMail(string strto, string strSubject, string strBody)
        {
            string SMTPHost = ConfigurationManager.AppSettings["SMTPHost"];
            string SMTPPort = ConfigurationManager.AppSettings["SMTPPort"];
            string SMTPUser = ConfigurationManager.AppSettings["SMTPUser"];
            string SMTPPassword = ConfigurationManager.AppSettings["SMTPPassword"];
            string MailFrom = ConfigurationManager.AppSettings["MailFrom"];
            string MailSubject = ConfigurationManager.AppSettings["MailSubject"];

            SmtpClient client = new SmtpClient(SMTPHost);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage message = new MailMessage(SMTPUser, strto, strSubject, strBody);
            message.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");
            message.IsBodyHtml = true;

            client.Send(message);
        }
        #endregion

        #region "转换编码"
        /// <summary>
        /// 转换编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encode(string str)
        {
            if (str == null)
            {
                return "";
            }
            else
            {

                return System.Web.HttpUtility.UrlEncode(Encoding.GetEncoding(54936).GetBytes(str));
            }
        }
        #endregion

        #region "获取登陆用户UserID"
        /// <summary>
        /// 获取登陆用户UserID,如果未登陆为0
        /// </summary>
        public static int Get_UserID
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated ? Convert.ToInt32(HttpContext.Current.User.Identity.Name) : 0;
            }

        }
        #endregion

        #region "获取当前用户SessionID"
        /// <summary>
        /// 获取当前用户SessionID
        /// </summary>
        public static string Get_SessionID
        {
            get
            {
                return HttpContext.Current.Session.SessionID;
            }
        }
        #endregion

        #region "获取当前Cookies名称"
        /// <summary>
        /// "获取当前Cookies名称
        /// </summary>
        public static string Get_CookiesName
        {
            get
            {
                return "FrameWork_YOYO_Lzppcc";
            }
        }
        #endregion

        #region "获取WEBCache名称前辍"
        /// <summary>
        /// 获取WEBCache名称前辍
        /// </summary>
        public static string Get_WebCacheName
        {
            get
            {
                return "FrameWork_YOYO_Lzppcc";
            }
        }
        #endregion

        #region "设置页面不被缓存"
        /// <summary>
        /// 设置页面不被缓存
        /// </summary>
        public static void SetPageNoCache()
        {

            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.AddHeader("Pragma", "No-Cache");
        }
        #endregion

        #region "获取页面url"
        /// <summary>
        /// 获取当前访问页面地址
        /// </summary>
        public static string GetScriptName
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            }
        }

        /// <summary>
        /// 检测当前url是否包含指定的字符
        /// </summary>
        /// <param name="sChar">要检测的字符</param>
        /// <returns></returns>
        public static bool CheckScriptNameChar(string sChar)
        {
            bool rBool = false;
            if (GetScriptName.ToLower().LastIndexOf(sChar) >= 0)
                rBool = true;
            return rBool;
        }

        /// <summary>
        /// 获取当前页面的扩展名
        /// </summary>
        public static string GetScriptNameExt
        {
            get
            {
                return GetScriptName.Substring(GetScriptName.LastIndexOf(".") + 1);
            }
        }

        /// <summary>
        /// 获取当前访问页面地址参数
        /// </summary>
        public static string GetScriptNameQueryString
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["QUERY_STRING"].ToString();
            }
        }

        /// <summary>
        /// 获取当前访问页面Url
        /// </summary>
        //public static string GetScriptUrl
        //{
        //    get
        //    {
        //        return Common.GetScriptNameQueryString == "" ? Common.GetScriptName : string.Format("{0}?{1}", Common.GetScriptName, Common.GetScriptNameQueryString);
        //    }
        //}

        /// <summary>
        /// 返回当前页面目录的url
        /// </summary>
        /// <param name="FileName">文件名</param>
        /// <returns></returns>
        //public static string GetHomeBaseUrl(string FileName)
        //{
        //    string Script_Name = Common.GetScriptName;
        //    return string.Format("{0}/{1}", Script_Name.Remove(Script_Name.LastIndexOf("/")), FileName);
        //}

        /// <summary>
        /// 返回当前网站网址
        /// </summary>
        /// <returns></returns>
        public static string GetHomeUrl()
        {
            return HttpContext.Current.Request.Url.Authority;
        }

        /// <summary>
        /// 获取当前访问文件物理目录
        /// </summary>
        /// <returns>路径</returns>
        public static string GetScriptPath
        {
            get
            {
                string Paths = HttpContext.Current.Request.ServerVariables["PATH_TRANSLATED"].ToString();
                return Paths.Remove(Paths.LastIndexOf("\\"));
            }
        }
        #endregion

        #region "按字符串位数补0"
        /// <summary>
        /// 按字符串位数补0
        /// </summary>
        /// <param name="CharTxt">字符串</param>
        /// <param name="CharLen">字符长度</param>
        /// <returns></returns>
        public static string FillZero(string CharTxt, int CharLen)
        {
            if (CharTxt.Length < CharLen)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < CharLen - CharTxt.Length; i++)
                {
                    sb.Append("0");
                }
                sb.Append(CharTxt);
                return sb.ToString();
            }
            else
            {
                return CharTxt;
            }
        }

        #endregion

        #region "替换JS中特殊字符"
        /// <summary>
        /// 将JS中的特殊字符替换
        /// </summary>
        /// <param name="str">要替换字符</param>
        /// <returns></returns>
        public static string ReplaceJs(string str)
        {

            if (str != null)
            {
                str = str.Replace("\"", "&quot;");
                str = str.Replace("(", "&#40;");
                str = str.Replace(")", "&#41;");
                str = str.Replace("%", "&#37;");
            }

            return str;

        }
        #endregion

        #region "正式表达式验证"
        /// <summary>
        /// 正式表达式验证
        /// </summary>
        /// <param name="C_Value">验证字符</param>
        /// <param name="C_Str">正式表达式</param>
        /// <returns>符合true不符合false</returns>
        public static bool CheckRegEx(string C_Value, string C_Str)
        {
            Regex objAlphaPatt;
            objAlphaPatt = new Regex(C_Str, RegexOptions.Compiled);


            return objAlphaPatt.Match(C_Value).Success;
        }
        #endregion

        #region "检测当前字符是否在以,号分开的字符串中(xx,sss,xaf,fdsf)"
        /// <summary>
        /// 检测当前字符是否在以,号分开的字符串中(xx,sss,xaf,fdsf)
        /// </summary>
        /// <param name="TempChar">需检测字符</param>
        /// <param name="TempStr">待检测字符串</param>
        /// <returns>存在true,不存在false</returns>
        public static bool Check_Char_Is(string TempChar, string TempStr)
        {
            bool rBool = false;
            if (TempChar != null && TempStr != null)
            {
                string[] TempStrArray = TempStr.Split(',');
                for (int i = 0; i < TempStrArray.Length; i++)
                {
                    if (TempChar == TempStrArray[i].Trim())
                    {
                        rBool = true;
                        break;
                    }
                }
            }
            return rBool;
        }
        #endregion

        #region "上传文件配置"
        /// <summary>
        /// 上传目录设置
        /// </summary>
        public static string UpLoadDir
        {
            get
            {
                try
                {
                    return new System.Web.UI.Control().ResolveUrl("~/Public/");
                }
                catch
                {
                    return "/Public/";
                }
            }
        }

        /// <summary>
        /// 图片缩图高度
        /// </summary>
        //public static int UpImgHeight
        //{
        //    get
        //    {
        //        //return Convert.ToInt32(ConfigurationManager.AppSettings["UpImgHeight"]);
        //        //return FrameSystemInfo.GetSystemInfoTable.S_SystemConfigData.C_UpImgHeight;
        //    }
        //}
        /// <summary>
        /// 图片缩图宽度
        /// </summary>
        //public static int UpImgWidth
        //{
        //    get
        //    {
        //        //return Convert.ToInt32(ConfigurationManager.AppSettings["UpImgWidth"]);
        //       // return FrameSystemInfo.GetSystemInfoTable.S_SystemConfigData.C_UpImgWidth;
        //    }
        //}
        #endregion

        #region "前台设置"

        /// <summary>
        /// 菜单风格 0:经典 1:流行 2:朴素
        /// </summary>
        public static int MenuStyle
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["MenuStyle"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(HttpContext.Current.Request.Cookies["MenuStyle"].Value);
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["MenuStyle"].Value = value.ToString();
            }
        }

        /// <summary>
        /// 分页每页记录数(默认10)
        /// </summary>
        public static int PageSize
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["PageSize"] == null)
                {
                    return 10;
                }
                else
                {
                    return Convert.ToInt32(HttpContext.Current.Request.Cookies["PageSize"].Value);
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["PageSize"].Value = value.ToString();
            }
        }

        /// <summary>
        /// 表格样式(默认default)
        /// </summary>
        public static string TableSink
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["TableSink"] == null)
                {
                    return "default";
                }
                else
                {
                    return HttpContext.Current.Request.Cookies["TableSink"].Value.ToString();
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["TableSink"].Value = value;
            }
        }

        /// <summary>
        /// 用户在线过期时间 (分)默认30分 如果用户在当前设定的时间内没有任何操作,将会被系统自动退出
        /// </summary>
        public static int OnlineMinute
        {
            get
            {
                try
                {
                    return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["OnlineMinute"]);
                }
                catch
                {
                    return 30;
                }
            }
        }

        #endregion

        #region "数据库设置"

        /// <summary>
        /// 获取数据库类型
        /// </summary>
        public static string GetDBType
        {
            get
            {
                return ConfigurationManager.AppSettings["DBType"];
            }
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        public static string GetConnString
        {
            get
            {
                return ConfigurationManager.AppSettings[GetDBType];
            }
        }
        #endregion

        #region "产生GUID"
        /// <summary>
        /// 获取一个GUID的HashCode
        /// </summary>
        public static int GetGUIDHashCode
        {
            get
            {
                return GetGUID.GetHashCode();
            }
        }
        /// <summary>
        /// 获取一个GUID字符串
        /// </summary>
        public static string GetGUID
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }


        public static string getUUIDString(int length)
        {
            System.Guid gid = Guid.NewGuid();
            System.Random rand = new Random();
            string ret = gid.ToString().Replace("-", Convert.ToString(rand.Next(100, 999)));
            if (length > ret.Length)
            {
                gid = Guid.NewGuid();
                string temp = gid.ToString().Replace("-", "a" + Convert.ToString(rand.Next(10, 100)));
                int s = length - ret.Length;
                if (s <= temp.Length)
                {
                    return ret + temp.Substring(0, s);
                }
                return ret + temp;
            }
            return ret.Substring(0, length);
        }
        #endregion

        #region "生成Cookies存储的GUID hashCode"
        /// <summary>
        /// 生成Cookies存储的GUID hashCode
        /// </summary>
        public static int CookiesGuid
        {
            get
            {
                string cookiesname = Get_CookiesName + "CookiesGuid";
                int rInt = GetGUIDHashCode;
                if (HttpContext.Current.Request.Cookies[cookiesname] == null)
                {
                    HttpContext.Current.Response.Cookies[cookiesname].Value = rInt.ToString();
                }
                else
                {
                    rInt = Convert.ToInt32(HttpContext.Current.Request.Cookies[cookiesname].Value);

                }
                return rInt;
            }
            set
            {
                string cookiesname = Get_CookiesName + "CookiesGuid";
                if (value == 0)
                    HttpContext.Current.Response.Cookies[cookiesname].Expires = DateTime.Now.AddDays(-30);
                else
                    HttpContext.Current.Response.Cookies[cookiesname].Value = value.ToString();
            }
        }
        #endregion

        #region "生成刷新部门列表js"
        /// <summary>
        /// 生成刷新部门列表js
        /// </summary>
        public static string BuildJs
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<script language=javascript>");
                sb.Append("window.parent.leftbody.location.reload();");
                sb.Append("</script>");

                return sb.ToString();
            }
        }
        #endregion

        #region "获取服务器IP"
        /// <summary>
        /// 获取服务器IP
        /// </summary>
        public static string GetServerIp
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"].ToString();
            }
        }
        #endregion

        #region "获取服务器操作系统"
        /// <summary>
        /// 获取服务器操作系统
        /// </summary>
        public static string GetServerOS
        {
            get
            {
                return Environment.OSVersion.VersionString;
            }
        }
        #endregion

        #region "获取服务器域名"
        /// <summary>
        /// 获取服务器域名
        /// </summary>
        public static string GetServerHost
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToString();
            }
        }
        #endregion

        #region "显示出错详细信息在用户页面(用户开发调试,在生产环境请设置为false)"
        /// <summary>
        /// 显示出错详细信息在用户页面(用户开发调试,在生产环境请设置为false)
        /// </summary>
        public static bool DispError
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["DispError"]);
            }
        }
        #endregion

        #region "根据IP获取IP查询Url地址"
        /// <summary>
        /// 根据IP获取IP查询Url地址
        /// </summary>
        /// <param name="IP">IP地址</param>
        /// <returns>查询url</returns>
        //public static string GetIPLookUrl(string IP)
        //{
        //    return string.Format("<a href='" + FrameSystemInfo.GetSystemInfoTable.S_SystemConfigData.C_IPLookUrl + "' target='_blank'>{0}</a>", IP);
        //}
        #endregion

        #region "根据文件扩展名获取当前目录下的文件列表"
        /// <summary>
        /// 根据文件扩展名获取当前目录下的文件列表
        /// </summary>
        /// <param name="FileExt">文件扩展名</param>
        /// <returns>返回文件列表</returns>
        public static List<string> GetDirFileList(string FileExt)
        {
            List<string> FilesList = new List<string>();
            string[] Files = Directory.GetFiles(GetScriptPath, string.Format("*.{0}", FileExt));
            foreach (string var in Files)
            {
                FilesList.Add(System.IO.Path.GetFileName(var).ToLower());
            }
            return FilesList;
        }
        #endregion

        #region "根据文件相对路径生成下载Url地址"
        /// <summary>
        /// 根据文件相对路径生成下载Url地址
        /// </summary>
        /// <param name="FilePath">文件相对路径</param>
        /// <returns>加密后Url地址</returns>
        //public static string BuildDownFileUrl(string FilePath)
        //{
        //    string MKey = EncryptString(FilePath, FrameSystemInfo.GetSystemInfoTable.S_FrameWorkInfo.S_RegsionGUID);
        //    MKey = HttpContext.Current.Server.UrlEncode(MKey);
        //    return string.Format("{0}?FileName={1}", new System.Web.UI.Control().ResolveUrl("~/DownLoadfile.aspx"), MKey);
        //}
        #endregion

        #region "根据文件扩展名获得文件的content-type"
        /// <summary>
        /// 根据文件扩展名获得文件的content-type
        /// </summary>
        /// <param name="fileextension">文件扩展名如.gif</param>
        /// <returns>文件对应的content-type 如:application/gif</returns>
        public static string GetFileMIME(string fileextension)
        {
            //set the default content-type
            const string DEFAULT_CONTENT_TYPE = "application/unknown";

            RegistryKey regkey, fileextkey;
            string filecontenttype;

            //the file extension to lookup


            try
            {
                //look in HKCR
                regkey = Registry.ClassesRoot;

                //look for extension
                fileextkey = regkey.OpenSubKey(fileextension);

                //retrieve Content Type value
                filecontenttype = fileextkey.GetValue("Content Type", DEFAULT_CONTENT_TYPE).ToString();

                //cleanup
                fileextkey = null;
                regkey = null;
            }
            catch
            {
                filecontenttype = DEFAULT_CONTENT_TYPE;
            }

            return filecontenttype;
        }
        #endregion

        #region "返回状态字符"
        /// <summary>
        /// 根据状态值返回状态字符
        /// </summary>
        /// <param name="i">状态值</param>
        /// <returns>返回字符</returns>
        public static string ReturnStatusInt(int i)
        {
            string rString = "未知";
            switch (i)
            {
                case 0:
                    rString = "正常";
                    break;
                case 1:
                    rString = "禁用";
                    break;
            }
            return rString;
        }
        #endregion

        #region "根据bool输出判断"
        /// <summary>
        /// 获得操作系统
        /// </summary>
        /// <returns>操作系统名称</returns>
        public static string ljdishow(string isshow, string yes, string no)
        {
            if (isshow == "0")
            {
                return no;
            }
            else
            {
                return yes;
            }
        }


        #endregion

        #region "根据图片是否存在输出默认图片还是原来图片"
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string ljdpic(string pic, string defaultpic)
        {
            if (string.IsNullOrEmpty(pic))
            {
                return defaultpic;
            }
            else
            {
                return pic;
            }
        }


        #endregion

        #region "取上传文件后缀"
        /// <summary>
        /// 取上传文件后缀
        /// </summary>
        /// <param name="file_name">要上传的文件名字</param>
        public static string FileExtendName(string file_name)
        {
            string ExtendName = "";
            ExtendName = file_name.Substring(file_name.LastIndexOf(".") + 1, file_name.Length - file_name.LastIndexOf(".") - 1).ToLower();
            return ExtendName;
        }
        #endregion

        #region "获得操作系统"
        /// <summary>
        /// 获得操作系统
        /// </summary>
        /// <returns>操作系统名称</returns>
        public static string GetSystem
        {
            get
            {
                string s = HttpContext.Current.Request.UserAgent.Trim().Replace("(", "").Replace(")", "");
                string[] sArray = s.Split(';');
                switch (sArray[2].Trim())
                {
                    case "Windows 4.10":
                        s = "Windows 98";
                        break;
                    case "Windows 4.9":
                        s = "Windows Me";
                        break;
                    case "Windows NT 5.0":
                        s = "Windows 2000";
                        break;
                    case "Windows NT 5.1":
                        s = "Windows XP";
                        break;
                    case "Windows NT 5.2":
                        s = "Windows 2003";
                        break;
                    case "Windows NT 6.0":
                        s = "Windows Vista";
                        break;
                    default:
                        s = "Other";
                        break;
                }
                return s;
            }
        }


        #endregion

        #region "根据日期判断显示的内容"
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string ljd_date_str(DateTime date, string news_str, string default_str)
        {
            DateTime today = DateTime.Now;
            TimeSpan ts = date.Subtract(today);

            if (int.Parse(ts.Days.ToString()) >= 0)
            {
                return news_str;
            }
            else
            {
                return default_str;
            }

        }


        #endregion

        #region "判断是否是可以上传的文件格式"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pic"></param>
        public static bool ljd_check_pic(string pic)
        {
            bool str_bool = true;
            string[] picstr = new string[] { ".jpg", ".gif", ".png" };
            IList pic_str = new ArrayList(picstr);


            if (pic_str.Contains(pic.ToLower()))
            {
                str_bool = false;
            }

            return str_bool;
        }


        #endregion

        #region "检查sql注入"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        public static string ljd_sql(string sql)
        {
            return sql.Replace("'", "").Replace("or", "").Replace("-", "").Replace("=", "").Replace("insert", "").Replace("update", "").Trim();
        }

        public static string ljd_Split(string inputString) //防止SQL注入方法
        {
            string rStr = inputString;
            if (inputString != null && inputString != string.Empty)
            {
                rStr = rStr.Trim().ToLower();
                rStr = rStr.Replace("'", "");
                rStr = rStr.Replace(";--", "");
                rStr = rStr.Replace("--", "");
                rStr = rStr.Replace("\"", "");
                rStr = rStr.Replace("=", "");
                rStr = rStr.Replace("and", "");
                rStr = rStr.Replace("exec", "");
                rStr = rStr.Replace("insert", "");
                rStr = rStr.Replace("select", "");
                rStr = rStr.Replace("delete", "");
                rStr = rStr.Replace("update", "");
                rStr = rStr.Replace("chr", "");
                rStr = rStr.Replace("mid", "");
                rStr = rStr.Replace("master", "");
                rStr = rStr.Replace("or", "");
                rStr = rStr.Replace("truncate", "");
                rStr = rStr.Replace("char", "");
                rStr = rStr.Replace("declare", "");
                rStr = rStr.Replace("join", "");
                rStr = rStr.Replace("count", "");
                rStr = rStr.Replace("*", "");
                rStr = rStr.Replace("%", "");
                rStr = rStr.Replace("union", "");
            }

            return rStr;
        }

        #endregion

        #region "根据不同的值显示不同值显示不同的内容"
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string ljdgrade(string grade)
        {
            string str = "";

            switch (grade)
            {
                case "0":
                    str = "pic/00.gif";
                    break;
                case "1":
                    str = "pic/01.gif";
                    break;
                case "2":
                    str = "pic/02.gif";
                    break;
                case "3":
                    str = "pic/03.gif";
                    break;
                case "4":
                    str = "pic/04.gif";
                    break;
                case "5":
                    str = "pic/05.gif";
                    break;
                case "6":
                    str = "pic/06.gif";
                    break;
                case "7":
                    str = "pic/07.gif";
                    break;
                case "8":
                    str = "pic/08.gif";
                    break;
                case "9":
                    str = "pic/09.gif";
                    break;

            }

            return str;
        }


        #endregion

        #region "MD5加密"
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected static Hashtable ht = new Hashtable();
        public static string ljdmd5(string src)
        {

            string md5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(src, "MD5").ToLower();



            char[] c = md5.ToCharArray();
            char aa = c[5];
            char ab = c[7];
            char ac = c[17];
            char ad = c[26];
            c[5] = (char)ht[aa];
            c[7] = (char)ht[ab];
            c[17] = (char)ht[ac];
            c[26] = (char)ht[ad];
            return new string(c);
        }
        #endregion

        #region "特殊显示一个链接的样式"
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string ljd_css(string show, string link)
        {
            string str = link;

            if (show == "1")
            {
                str = "<span style=\"color: #FF0000\">" + link + "</span>";
            }

            return str;
        }


        #endregion

        #region "去除文本中的标签包括空格"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string ljd_html(string strHtml)
        {


            Regex objRegExp = new Regex("<(.|\n)+?>");
            string strOutput = objRegExp.Replace(strHtml, "");

            Regex regex = new Regex("\\s+");

            string str = regex.Replace(strOutput, "");
            strOutput = strOutput.Replace("<", "&lt;");
            strOutput = strOutput.Replace(">", "&gt;");
            return str.Replace("&nbsp;", "");
        }
        #endregion

        #region "去除文本中的标签"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        private static string ljdhtml(string strHtml)
        {
            Regex objRegExp = new Regex("<(.|\n)+?>");
            string strOutput = objRegExp.Replace(strHtml, "");
            strOutput = strOutput.Replace("<", "&lt;");
            strOutput = strOutput.Replace(">", "&gt;");
            return strOutput;
        }
        #endregion


        /// <summary>
        /// 去掉便签 返回字符串
        /// </summary>
        /// <param name="str_value"></param>
        /// <param name="str_len"></param>
        /// <returns></returns>
        public static string left_css(string str_value, int str_len)
        {
            string str = "";
            string vl = ljd_html(str_value).Replace("&nbsp;", "");
            if (vl.Length > str_len)
            {
                str = vl.Substring(0, str_len) + "...";
            }
            else
            {
                str = vl;
            }

            return str;
        }



        /// <summary>
        /// 读取页面
        /// </summary>
        /// <param name="url"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public static string GetPage(string url, out string err)
        {
            err = "";

            //Stream outstream = null;

            Stream instream = null;

            StreamReader sr = null;

            HttpWebResponse response = null;

            HttpWebRequest request = null;

            Encoding encoding = Encoding.GetEncoding("UTF-8");



            // 准备请求...

            //try
            //{

            // 设置参数

            request = WebRequest.Create(url) as HttpWebRequest;

            // CookieContainer cookieContainer = new CookieContainer();

            //  request.CookieContainer = cookieContainer;

            request.AllowAutoRedirect = true;

            //request.Method = "POST";

            //request.ContentType = "application/x-www-form-urlencoded";



            //outstream = request.GetRequestStream();



            //outstream.Close();

            //发送请求并获取相应回应数据

            response = request.GetResponse() as HttpWebResponse;

            //直到request.GetResponse()程序才开始向目标网页发送Post请求


            instream = response.GetResponseStream();

            sr = new StreamReader(instream, encoding);

            //返回结果网页（html）代码

            string content = sr.ReadToEnd();

            err = string.Empty;

            return content;

            //}

            //catch (Exception ex)
            //{

            //    err = ex.Message;

            //    return string.Empty;

            //}

        }

        public static string checkname(string name, int len)
        {
            string str = "**";
            if (name.Trim().Length > len)
            {
                str = name.Substring(0, len) + "**";
            }

            return str;
        }

        #region "根据不同等级显示不同的图片"
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string ljd_dengji(int grade)
        {
            string str = "";

            if (grade > 0 && grade < 50)
            {
                str = "/templet/img/6.gif";
            }
            else if (grade > 50 && grade < 100)
            { str = "/templet/img/7.gif"; }
            else if (grade > 100 && grade < 200)
            { str = "/templet/img/8.gif"; }
            else if (grade > 200 && grade < 500)
            { str = "/templet/img/9.gif"; }
            else if (grade > 500 && grade < 1000)
            { str = "/templet/img/10.gif"; }

            return str;
        }
        public static string ljd_email(string email)
        {
            string str = "";
            try
            {
                str = "*****" + email.Split('@')[1].ToString();
            }
            catch (Exception eee) { }
            return str;
        }
        public static string ljd_tel(string tel)
        {
            string str = "";
            try
            {
                str = tel.Substring(0, 7) + "****";
            }
            catch (Exception eee) { }

            return str;
        }
        #endregion

        #region "根据不同等级显示会员等级的图片"
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string ljd_vip(string grade, string file)
        {
            string str = "";

            if (!string.IsNullOrEmpty(grade))
            {
                str = file + "/" + grade + ".gif";
            }

            return str;
        }


        #endregion

        #region "如果是空返回0"
        /// <summary>
        /// 如果是空返回 “0”
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string getcount(string c)
        {
            string str = "";

            if (!string.IsNullOrEmpty(c))
            {
                str = c;
            }
            else
            {
                str = "0";
            }
            return str;
        }

        #endregion


        #region "文件读取"
        public static string readFile(string filename, string _encoding)
        {
            string sb = "";

            StreamReader sr = new StreamReader(filename, Encoding.GetEncoding(_encoding));
            try
            {
                sb = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sr.Close();
            }
            return sb;
        }
        #endregion

        public static string ljdmoney(string m)
        {
            string xx = "";
            string x = m;
            if (m.Contains("."))
            {
                x = m.Split('.')[0].ToString();
                xx = "." + m.Split('.')[1].ToString();
            }

            string str = "";
            int a = x.Length;
            if (a > 3)
            {
                if (a == 4)
                {
                    str = x.Insert(1, ",");
                }
                if (a == 5)
                {
                    str = x.Insert(2, ",");
                }
                if (a == 6)
                {
                    str = x.Insert(3, ",");
                }
                if (a == 7)
                {
                    str = x.Insert(1, ",").Insert(5, ",");
                }
                if (a == 8)
                {
                    str = x.Insert(2, ",").Insert(6, ",");
                }
                if (a == 9)
                {
                    str = x.Insert(3, ",").Insert(7, ",");
                }
                if (a == 10)
                {
                    str = x.Insert(1, ",").Insert(5, ",").Insert(9, ",");
                }
                if (a == 11)
                {
                    str = x.Insert(2, ",").Insert(6, ",").Insert(10, ",");
                }
                if (a == 12)
                {
                    str = x.Insert(3, ",").Insert(7, ",").Insert(11, ",");
                }

                if (a > 12)
                {
                    str = x;
                }
            }
            else
            {
                str = x;
            }
            return str + xx;
        }
        public static string ljdmoney(double m)
        {
            string x = m.ToString("0.");
            string str = "";
            int a = x.Length;
            if (a > 3)
            {
                if (a == 4)
                {
                    str = x.Insert(1, ",");
                }
                if (a == 5)
                {
                    str = x.Insert(2, ",");
                }
                if (a == 6)
                {
                    str = x.Insert(3, ",");
                }
                if (a == 7)
                {
                    str = x.Insert(1, ",").Insert(5, ",");
                }
                if (a == 8)
                {
                    str = x.Insert(2, ",").Insert(6, ",");
                }
                if (a == 9)
                {
                    str = x.Insert(3, ",").Insert(7, ",");
                }
                if (a == 10)
                {
                    str = x.Insert(1, ",").Insert(5, ",").Insert(9, ",");
                }
                if (a == 11)
                {
                    str = x.Insert(2, ",").Insert(6, ",").Insert(10, ",");
                }
                if (a == 12)
                {
                    str = x.Insert(3, ",").Insert(7, ",").Insert(11, ",");
                }

                if (a > 12)
                {
                    str = x;
                }
            }
            else
            {
                str = x;
            }
            return str;
        }
        public static string ljdmoney(decimal m)
        {
            string x = m.ToString("0.");
            string str = "";
            int a = x.Length;
            if (a > 3)
            {
                if (a == 4)
                {
                    str = x.Insert(1, ",");
                }
                if (a == 5)
                {
                    str = x.Insert(2, ",");
                }
                if (a == 6)
                {
                    str = x.Insert(3, ",");
                }
                if (a == 7)
                {
                    str = x.Insert(1, ",").Insert(5, ",");
                }
                if (a == 8)
                {
                    str = x.Insert(2, ",").Insert(6, ",");
                }
                if (a == 9)
                {
                    str = x.Insert(3, ",").Insert(7, ",");
                }
                if (a == 10)
                {
                    str = x.Insert(1, ",").Insert(5, ",").Insert(9, ",");
                }
                if (a == 11)
                {
                    str = x.Insert(2, ",").Insert(6, ",").Insert(10, ",");
                }
                if (a == 12)
                {
                    str = x.Insert(3, ",").Insert(7, ",").Insert(11, ",");
                }

                if (a > 12)
                {
                    str = x;
                }
            }
            else
            {
                str = x;
            }
            return str;
        }
        public static string ljdmoney(int m)
        {
            string x = m.ToString(".");
            string str = "";
            int a = x.Length;
            if (a > 3)
            {
                if (a == 4)
                {
                    str = x.Insert(1, ",");
                }
                if (a == 5)
                {
                    str = x.Insert(2, ",");
                }
                if (a == 6)
                {
                    str = x.Insert(3, ",");
                }
                if (a == 7)
                {
                    str = x.Insert(1, ",").Insert(5, ",");
                }
                if (a == 8)
                {
                    str = x.Insert(2, ",").Insert(6, ",");
                }
                if (a == 9)
                {
                    str = x.Insert(3, ",").Insert(7, ",");
                }
                if (a == 10)
                {
                    str = x.Insert(1, ",").Insert(5, ",").Insert(9, ",");
                }
                if (a == 11)
                {
                    str = x.Insert(2, ",").Insert(6, ",").Insert(10, ",");
                }
                if (a == 12)
                {
                    str = x.Insert(3, ",").Insert(7, ",").Insert(11, ",");
                }

                if (a > 12)
                {
                    str = x;
                }
            }
            else
            {
                str = x;
            }
            return str;
        }

    }

}