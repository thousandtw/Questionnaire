using Questionnaire.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Auth
{
    public class AuthManager
    {
        public static List<Theme> GetThemeByDate( DateTime startTime, DateTime endTime)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.Themes
                                 where item.T_end <= endTime && item.T_start >= startTime
                                 select item);

                    var list = query.ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.Writelog(ex);
                    return null;
                }
            }
        }

        public static List<Theme> GetThemesByHeader(string header)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.Themes
                                 where item.T_title== header
                                 select item);

                    var list = query.ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.Writelog(ex);
                    return null;
                }
            }
        }

        public static List<Theme> GeThemeList_OrderByTime()
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.Themes
                                 orderby item.T_start descending
                                 select item);

                    var list = query.ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.Writelog(ex);
                    return null;
                }
            }
        }

        /// <summary> 嘗試登入 </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static bool TryLogin(string account, string pwd, out string errorMsg)
        {
            // 檢查空白
            if (string.IsNullOrWhiteSpace(account) ||
                string.IsNullOrWhiteSpace(pwd))
            {
                errorMsg = "<span style='color:red'>請輸入帳號/密碼</span>";
                return false;
            }

            // 讀取和檢查資料庫
            var userInfo = UserInfoManager.GetUserInfobyAccount_ORM(account);

            // 檢查 Null
            if (userInfo == null)
            {
                errorMsg = $"<span style='color:red'>帳號: {account} 輸入錯誤</span>";
                return false;
            }

            // 檢查帳號/密碼
            if (string.Compare(userInfo.User_account, account, true) == 0 &&
                string.Compare(userInfo.User_password, pwd, false) == 0)
            {
                //HttpContext.Current.Session["UserLoginInfo"] = userInfo.Account;
                errorMsg = string.Empty;
                return true;
            }
            else
            {
                errorMsg = "<span style='color:red'>登入失敗，請重新確認帳號/密碼</span>";
                return false;
            }
        }
    }
}
