using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO.Ports;

namespace arduino_localhost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SerialPort puerto;
       // MySqlConnection db = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=roostec_system");
        int tiempo = 0;
        string[] datos;
        string insert;

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString();
           try
            {
                puerto = new SerialPort("COM9", 9600, Parity.None, 8, StopBits.One);
                puerto.Open();
                timer1.Start();
                label1.Text = "Obteniendo datos...";
                textBox1.Text = "Recibiendo...";
            }
            catch
            {
                MessageBox.Show("Revise la conexion del dispositivo y reinicie el programa.");
                label1.Text = "Reinicie el programa.";
                textBox1.Text = "No hay datos disponibles";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString();
            string cad;
            char[] separar = { ',' };
            while (puerto.BytesToRead > 0 )
            {
                cad = puerto.ReadExisting();
                datos = cad.Split(separar);
                textBox1.Text = cad;
                tiempo++;
                /*if (tiempo > 2)
                {
                    try
                    {
                        insert = "INSERT INTO variable_ambiental (id_dato,pa,temperatura,altitud,fecha,nombre_sistema) VALUES (''," + datos[1] + "," + datos[0] + "," + datos[2] + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "','Colima')";
                        db.Open();
                        MySqlCommand command = new MySqlCommand(insert, db);
                        command.ExecuteNonQuery();
                        db.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    for(int i = 0; i < datos.Length; i++)
                    {
                        datos[i] = "";
                    }
                    tiempo = 0;
                }*/
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
