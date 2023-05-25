using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace stajyertakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         public SqlConnection con = new SqlConnection("Data Source=LAPTOP-RTSA2NN0\\SQLEXPRESS;Initial Catalog=stajtakip;Integrated Security=True");

        void gridWiewDoldur()
        {
            con.Open();
            SqlDataAdapter da=new SqlDataAdapter("Select *from kisi",con);
            DataSet ds=new DataSet();
            da.Fill(ds,"kisi");
            dataGridView1.DataSource = ds.Tables["kisi"];
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridWiewDoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into kisi(StajyerId, TCNo, AdSoyad, TelefonNumarasi, Adres) values('"+
                textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            gridWiewDoldur();
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from kisi where StajyerId='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            gridWiewDoldur();
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update kisi set StajyerId= '" + textBox1.Text + "', TCNo='" + textBox2.Text + "', AdSoyad='" +
                textBox3.Text + "', TelefonNumarasi='" +
                textBox4.Text + "', Adres='" + textBox5.Text + "' where StajyerId= '" + textBox1.Text + "' ";
            cmd.ExecuteNonQuery();
            con.Close();
            gridWiewDoldur();
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
        }
    }
}
