using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace T1809E_Project_Sem3.Models
{
    public class PaypalLogger
    {
        public static string LogDirecttoryPath = Environment.CurrentDirectory;

        public static void Log (String messages)
        {
            try
            {
                StreamWriter strw = new StreamWriter(LogDirecttoryPath + "\\PaypalError.log", true);
                strw.WriteLine("{0}--->{1}", DateTime.Now.ToString("MM/dd/yyy HH:mm:ss"), messages);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}