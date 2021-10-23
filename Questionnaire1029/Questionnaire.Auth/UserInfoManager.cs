using Questionnaire.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Auth
{
    public class UserInfoManager
    {
        public static Userinfo GetUserInfobyAccount_ORM(string account)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Userinfoes
                         where item.User_account == account
                         select item);

                    var obj = query.FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Logger.Writelog(ex);
                return null;
            }
        }
    }
}
