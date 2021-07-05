using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActTipoCambioBtc
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            string cs = @"..\..\Util\database.sql";
            if (!File.Exists(Path.GetFullPath(cs)))
            {
                SQLiteConnection.CreateFile(cs);
            }


            using var con = new SQLiteConnection("Data Source = "+ cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            //cmd.CommandText = "DROP TABLE IF NOT EXISTS CONFIGURACION";
            //cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS  CONFIGURACION(id INTEGER PRIMARY KEY,
            servidor TEXT, basedatos TEXT,usuario TEXT,clave TEXT, webservice TEXT,intervalo INT,CodMoneda TEXT,codcia TEXT)";
            cmd.ExecuteNonQuery();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());


        }
    }
}
