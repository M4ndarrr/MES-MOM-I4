using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES_2.Common
{
    public class LoggingService
    {
        private static LoggingService instance;

        public static LoggingService Instance
        {
            get
            {
                if (instance == null) instance = new LoggingService();
                return instance;
            }
        }
        /*public static void WriteToFile(List<ILoggable> changedItems)
        {
            foreach (var item in changedItems)
            {
                Console.WriteLine(item.Log());
            }
        }*/

        private StreamWriter sw;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public LoggingService()
        {

        }

        public void Open(string fileName)
        {
            sw = new StreamWriter(fileName);
        }

        public void Close()
        {
            sw.Close();
        }

        public static void Log(object sender, String e)
        {
            Instance._Log(sender, e);
        }

        public void _Log(object sender, String e)
        {
            if (sw == null) return;
            sw.WriteLine("{0}: {1}<BR>", DateTime.Now.ToLongTimeString(),e);
            //sw.Flush();
        }

        public void Log(object sender, Exception e)
        {

        }
    }
}
