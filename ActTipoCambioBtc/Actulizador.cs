using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActTipoCambioBtc
{
    public partial class Actulizador : Form
    {
        public Actulizador()
        {
            InitializeComponent();
        }
        public class Bitcoin
        {
            public decimal usd { get; set; }
        }

        public class RootObject
        {
            public Bitcoin bitcoin { get; set; }
        }

        private void Actulizador_Load(object sender, EventArgs e)
        {
            //var timer = new System.Timers.Timer(TimeSpan.FromMinutes(2).TotalMilliseconds);
            //timer.Elapsed += async (sender, e) => {
            timer1.Start();
            //};
            //timer.Start(); // indicamos que unicie
        }

        public void Actulizar ()
        {
            var url = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody

                            var result = JsonConvert.DeserializeObject<RootObject>(responseBody);
                            lblPrecioActual.Text = "Tipo de Cambio Actual: " + result.bitcoin.usd.ToString()+" Actulizado a las " + System.DateTime.Now;
                            Conexion(result.bitcoin.usd.ToString());
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }
        public static SQLiteConnection GetInstance()
        {
            string cs = @"..\..\Util\database.sql";
            var db = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", cs)
            );

            db.Open();

            return db;
        }
        public void Conexion(string valorbtc)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            using (var ctx = GetInstance())
            {
                var query = "SELECT * FROM CONFIGURACION";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            builder.DataSource = reader["servidor"].ToString();
                            builder.InitialCatalog = reader["basedatos"].ToString();
                            builder.UserID = reader["usuario"].ToString();

                            string result = string.Empty;
                            byte[] decryted = Convert.FromBase64String(reader["clave"].ToString());
                            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
                            result = System.Text.Encoding.Unicode.GetString(decryted);
                            builder.Password = result;
                            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                                {
                                try
                                    {
                                        connection.Open();
                                    var querysql = "INSERT INTO '"+ reader["codcia"].ToString() + "'.MONEDA_HIST (MONEDA,FECHA,USUARIO,MONTO) VALUES ('"+ reader["CodMoneda"].ToString() + "','"+System.DateTime.Now+"','BTCLO','"+valorbtc+"')";
                                    SqlCommand command1 = new SqlCommand(querysql,connection);
                                    command1.ExecuteNonQuery();
                                    }
                                    catch (Exception exception)
                                    {
                                        MessageBox.Show(exception.Message);
                                    }
                                }

                        }
                    }
                }


               
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Actulizar();
        }
    }
}
