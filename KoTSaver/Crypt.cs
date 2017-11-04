using System;
using System.Globalization;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;


namespace KoTSaver
{
    public static class Crypt
    {
        public static void Check()
        {
            string currentkey = GetKey();
            if (currentkey == null)
            {
                currentkey = Encrypt(GetTime());
                SetKey(currentkey);
            }
            DateTime decryptKey = Decrypt(currentkey);
            MessageBox.Show(decryptKey.ToString());
        }

        private static string Encrypt(DateTime dateTime)
        {
            StringBuilder encryptString = new StringBuilder();
            encryptString.Append(dateTime.Year);
            if (dateTime.Month.ToString().Length == 1)
            {
                encryptString.Append(0);
            }
            encryptString.Append(dateTime.Month);
            if (dateTime.Day.ToString().Length == 1)
            {
                encryptString.Append(0);
            }
            encryptString.Append(dateTime.Day);
            if (dateTime.Hour.ToString().Length==1)
            {
                encryptString.Append(0);
            }
            encryptString.Append(dateTime.Hour);
            if (dateTime.Minute.ToString().Length == 1)
            {
                encryptString.Append(0);
            }
            encryptString.Append(dateTime.Minute);
            if (dateTime.Second.ToString().Length == 1)
            {
                encryptString.Append(0);
            }
            encryptString.Append(dateTime.Second);
            encryptString.Append(dateTime.Millisecond);
            
            var encryptkey = Int64.Parse(encryptString.ToString());
            return Convert.ToString(encryptkey, 16);
        }

        private static DateTime Decrypt(string key)
        {
            long decryptKey = Int64.Parse(key, NumberStyles.AllowHexSpecifier);
            string s = decryptKey.ToString();
            int year = int.Parse(s.Substring(0, 4));
            int month = int.Parse(s.Substring(4, 2));
            int day = int.Parse(s.Substring(6, 2));
            int hour = int.Parse(s.Substring(8, 2));
            int minute = int.Parse(s.Substring(10, 2));
            int second = int.Parse(s.Substring(12, 2));
            int millisecond = int.Parse(s.Substring(14));

            DateTime dateTime = new DateTime(year, month, day,hour,minute,second,millisecond);
            return dateTime;
        }

        private static string GetKey()
        {
            RegistryKey reg = Registry.CurrentUser;
            reg = reg.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\KoTSaver");
            return reg == null ? null : (string) reg.GetValue(("Key"));
        }

        private static void SetKey(string encryptKey)
        {
            RegistryKey reg = Registry.CurrentUser;
            reg = reg.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\KoTSaver");
            reg.SetValue("Key", encryptKey);
            reg.Close();
        }

        private static DateTime GetTime()
        {
            DateTime dateTime = DateTime.Now;
            try
            {
                var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
                var response = myHttpWebRequest.GetResponse();
                string todaysDates = response.Headers["date"];
                dateTime = DateTime.ParseExact(todaysDates, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal);
            }
            catch (Exception)
            {
                MessageBox.Show("Please, check the Internet connection!");
                Environment.Exit(0);
            }

            return dateTime;
        }

        public static int Trial()
        {
            DateTime endDate = new DateTime(2017,7,25);
            DateTime curentDate = GetTime();
            if (endDate.CompareTo(curentDate) == -1)
            {
                MessageBox.Show("Trial time ended!");
                Environment.Exit(0);
            }

            return endDate.Subtract(curentDate).Days;
        }
    }
}
