using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KoTSaver
{
    internal class MySqlData
    {
        private delegate string MethodDelegate(Form f);

        public string LongRunningMethod(Form f)
        {
            string connStr = "server=db4free.net;user=kotdb_admin;database=kotdb;port=3306;password=kotdb_admin;";
            string sql = "SELECT * FROM Test where Id=2";
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader;
            command.Connection.Open();
            reader = command.ExecuteReader();
            string sss = "";
            while (reader.Read())
            {
                sss += reader["Message"];
                //f.Invoke(new Action<string>(s => f.Text += s), reader["Message"]);
                //f.Text += reader["Message"];
                //MessageBox.Show(reader["Message"].ToString());
            }

            conn.Close();
            return sss;
        }

        public void DemoCallback(Form f)
        {
            MethodDelegate dlgt = new MethodDelegate(LongRunningMethod);
            string s;
            int iExecThread;

            // Create the callback delegate.
            AsyncCallback cb = new AsyncCallback(MyAsyncCallback);

            // Initiate the Asynchronous call passing in the callback delegate
            // and the delegate object used to initiate the call.
            IAsyncResult ar = dlgt.BeginInvoke(f, cb, dlgt);
        }

        public void MyAsyncCallback(IAsyncResult ar)
        {
            string s;
            int iExecThread;

            // Because you passed your original delegate in the asyncState parameter
            // of the Begin call, you can get it back here to complete the call.
            MethodDelegate dlgt = (MethodDelegate) ar.AsyncState;

            // Complete the call.
            s = dlgt.EndInvoke(ar);
            MessageBox.Show(s);
        }
    }
}