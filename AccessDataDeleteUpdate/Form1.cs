using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AccessDataDeleteUpdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Eren\\Documents\\Database1.mdb");
        OleDbCommand komut3 = new OleDbCommand();
        private void Goster()
        {
            listView1.Items.Clear();
            baglan.Open();
            OleDbCommand komut1 = new OleDbCommand();
            komut1.Connection = baglan;
            komut1.CommandText = ("Select * from bp");
            //SqlCommand komut1=new SqlCommand("Select *from Satis",baglan);
            OleDbDataReader oku = komut1.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Id"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["Semt"].ToString());
                ekle.SubItems.Add(oku["Ucret"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Goster();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand komut2 = new OleDbCommand("Insert Into bp(Id,Ad,Soyad,Semt,Ucret) Values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "')", baglan);
            komut2.ExecuteNonQuery();
            baglan.Close();
            Goster();
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            comboBox1.Text = " ";
            comboBox2.Text = " ";
          
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            komut3.Connection = baglan;
            komut3.CommandText= "Delete from bp where Id= '" + textBox4.Text+ "' ";
            komut3.ExecuteNonQuery();
            baglan.Close();
            Goster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = " ";
            comboBox2.Text= " ";
           
            textBox4.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            komut3.Connection = baglan;
            komut3.CommandText = "Update bp set Ad= '" + textBox2.Text.ToString() + "',Soyad='" + textBox3.Text.ToString() + "',Semt='" + comboBox1.Text.ToString() + "',Ucret='" + comboBox2.Text.ToString() + "'where Id='" + textBox1.Text.ToString() + "'";
            komut3.ExecuteNonQuery();
            baglan.Close();
            Goster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = " ";
            comboBox2.Text = " ";
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
