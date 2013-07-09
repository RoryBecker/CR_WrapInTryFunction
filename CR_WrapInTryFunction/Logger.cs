using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_WrapInTryFunction
{
    public class Logger
    {
        public static bool Enabled;
        public static void Log(string Message)
        {
            DevExpress.CodeRush.Diagnostics.Messages.Log.SendMsg(Message);
        }
    }
}
