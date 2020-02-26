using System;
using System.IO;

namespace SimpleX
{
    public class Logger {

        private static StreamWriter sw;

        public Logger () {
            if (!Directory.Exists (AppContext.BaseDirectory + "/Logs/"))
                Directory.CreateDirectory (AppContext.BaseDirectory + "/Logs");
            sw = new StreamWriter (AppContext.BaseDirectory + "/Logs/" + DateTime.Now.ToString ("h/mm/ss") + "_" + DateTime.Now.Date.ToString ("d/m/y") + ".log");

        }

        public void LogInfo (string text) {
            sw.WriteLine ("[" + DateTime.Now.ToString ("h:mm:ss tt") + "- INFO]" + text);
            sw.Flush ();
        }

        public void LogWarn (string text) {
            sw.WriteLine ("[" + DateTime.Now.ToString ("h:mm:ss tt") + "- WARN]" + text);
            sw.Flush ();
        }

        public void LogError (Exception e) {
            sw.WriteLine ($"[{DateTime.Now.ToString("h:mm:ss tt")}- ERROR]{e.Message}\nMore info: \n{e.GetBaseException()}\n");
            sw.Close();
        }
        public void LogError (string text) {
            sw.WriteLine ($"[{DateTime.Now.ToString("h:mm:ss tt")}- ERROR]{text}");
            sw.Flush ();
        }

    }
}