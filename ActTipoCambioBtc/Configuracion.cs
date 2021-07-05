using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActTipoCambioBtc
{
    public partial class Configuracion : Form
    {

        public Configuracion()
        {
            InitializeComponent();
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(txtClave.Text);
            result = Convert.ToBase64String(encryted);
            try
            {
                var query = "DELETE FROM CONFIGURACION";
                var ctx = GetInstance();
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.ExecuteNonQuery();
                }
                var query2 = "INSERT INTO CONFIGURACION (servidor,basedatos,usuario,clave,webservice,intervalo,CodMoneda,codcia) VALUES ('" + txtServ.Text + "','" + txtBaseDatos.Text + "','" + txtUser.Text + "','" + result + "','"+txtWebService.Text+"','"+txtIntervaloHr.Text+"','"+txtCodMoneda.Text+"','"+txtCodCia.Text+"')";
                using (var command2 = new SQLiteCommand(query2, ctx))
                {
                    command2.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            lblNotificador.Text = "Claves Guardadas con exito";
        }

        private void btnTest_Click(object sender, EventArgs e)
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
                        }
                    }
                }


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        MessageBox.Show("Conexion Valida");

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);

                    }
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Configuracion_Load(object sender, EventArgs e)
        {

        }
    }

}