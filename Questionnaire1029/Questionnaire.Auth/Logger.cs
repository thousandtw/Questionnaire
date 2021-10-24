using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Auth
{
    public class Logger
    {
        public static void Writelog(Exception ex)
        {
            throw ex;
        }

        internal static void WriteLog(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
