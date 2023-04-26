using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace otelll
{
    public partial class Rezervasyon : Form
    {

        SqlConnection con;
        SqlCommand cnn;
        SqlDataAdapter da;

        public Rezervasyon()
        {
            InitializeComponent();
        }

        private void Rezervasyon_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=CGAMZENURDEMIR\SQLEXPRESS;Initial Catalog=otel;Integrated Security=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into Otel_rezerve Values(@id,@adsoyad,@telefonNo,@odaNo)",con);

            cnn.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@adsoyad", (textBox2.Text));
            cnn.Parameters.AddWithValue("@telefonNo", (textBox3.Text));
            cnn.Parameters.AddWithValue("@odaNo", int.Parse(textBox4.Text));

            cnn.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Rezervasyon oluşturuldu");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=CGAMZENURDEMIR\SQLEXPRESS;Initial Catalog=otel;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Otel_rezerve", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd); // cmd değişkenini SqlDataAdapter'a parametre olarak veriyoruz
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
