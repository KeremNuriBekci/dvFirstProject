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
using System.Configuration;

namespace dvFirstProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataReader dr;
        Oogrenci o = new Oogrenci();
        List<Ooogrenci> liste = new List<Ooogrenci>();


        private void button1_Click(object sender, EventArgs e)
        {
            o.ad = textBox1.Text;
            o.soyad = textBox2.Text;
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            baglanti.Open();
            command.CommandText = "insert into ogrenci values (@p1,@p2)";
            command.Parameters.AddWithValue("@p1", o.ad);
            command.Parameters.AddWithValue("@p2", o.soyad);

            command.Connection = baglanti;
            command.ExecuteNonQuery();

            MessageBox.Show("Kayıt Edildi");

            baglanti.Close();
                              
                                        
                                     
                                      
        
        
        
        
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
           
            baglanti.Open();
            
            command = new SqlCommand();
            
            command.CommandText = "select * from ogrenci";
            
            command.Connection = baglanti;
           
            dr = command.ExecuteReader();



            if (dr.HasRows)
            {
                while (dr.Read())
                {
                   
                    Ooogrenci ogrenci = new Ooogrenci();
                   
                    ogrenci.id = Convert.ToInt32(dr["id"]);
                    
                    ogrenci.ad = dr["ad"].ToString();
                    
                    ogrenci.soyad = dr["soyad"].ToString();
                   
                    liste.Add(ogrenci);

                }









            }
            else
            {
        
                MessageBox.Show("hiç kayıt eklenmemiş");

            }
           
            
            baglanti.Close();


            dataGridView1.DataSource = null;
            dataGridView1.DataSource = liste;

        }
    }
}
