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

namespace rfidBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sonuc = string.Format("INSERT INTO `rfidbd`.`datalar`(`uid`,`numara`,`kayit`)VALUES('{0}','{1}','{2}');", txt_uid.Text, txt_num.Text, DateTime.Now.ToString("dd-MM-yyyy"));
                string baglanti = @"server=127.0.0.1; database=rfidbd; User id=root; password=123456;";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(sonuc,baglanti);
                MySqlCommandBuilder comando = new MySqlCommandBuilder(adaptador);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                MessageBox.Show("okey");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sonuc = string.Format("SELECT * FROM rfidbd.datalar where uid = '{0}'", txt_uid.Text);
                string baglanti = @"server=127.0.0.1; database=rfidbd; User id=root; password=123456;";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(sonuc, baglanti);
                MySqlCommandBuilder top = new MySqlCommandBuilder(adaptador);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                MessageBox.Show(string.Format("id: {0} uid: {1} sayı: {2} bilgi: {3}", dt.Rows[0].ItemArray[0].ToString(), dt.Rows[0].ItemArray[1].ToString(), dt.Rows[0].ItemArray[2].ToString(), dt.Rows[0].ItemArray[3].ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
        

        private void Button3_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
            string entrada = serialPort1.ReadLine();
            serialPort1.Close();
            txt_uid.Text = entrada;
        }

        
        private void button3_Click_1(object sender, EventArgs e)
        {
            serialPort1.Open();
            string giris = serialPort1.ReadLine();
            serialPort1.Close();
            txt_uid.Text = giris;
        }
    }
}
