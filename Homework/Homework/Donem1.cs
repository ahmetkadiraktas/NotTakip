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


namespace Homework
{
    public partial class Donem1 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;

        void Datacome()
        {
            baglanti = new SqlConnection("server=DESKTOP-EKVTTMM;Initial Catalog=Donem1;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT *FROM Donem1",baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        public Donem1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
        //only number
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Donem1_Load(object sender, EventArgs e)
        {
            Datacome();
        }

        private void Donem1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
        //only number
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        //only number
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        //only later
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mid = Convert.ToInt32(textBox4.Text);
            int fin = Convert.ToInt32(textBox5.Text);
            double ort = (mid + fin) / 2;
            textBox8.Text = Convert.ToString(ort);
            double gpa = 4 * ort / 100;
            textBox10.Text = Convert.ToString(gpa);
            if (ort >= 90)
            {
                textBox7.Text = "AA";
            }
            else if (ort < 90 && ort >= 85)
            {
                textBox7.Text = "BA";
            }
            else if (ort < 85 && ort >= 80)
            {
                textBox7.Text = "BB";
            }
            else if (ort < 80 && ort >= 75)
            {
                textBox7.Text = "CB";
            }
            else if (ort < 75 && ort >= 65)
            {
                textBox7.Text = "CC";
            }
            else if (ort < 64 && ort >= 60)
            {
                textBox7.Text = "DC";
            }
            else if (ort < 59 && ort >= 55)
            {
                textBox7.Text = "DD";
            }
            else if (ort < 54 && ort >= 50)
            {
                textBox7.Text = "FD";
            }
            else if(ort < 00 && ort >= 49)
            {
                textBox7.Text = "FF";
            }


            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Please fill in all sections");
            }
            else
            {
                

                string sorgu = "INSERT INTO Donem1(CourseCode,CourseName,ECTScredits,MidTerm,Final,Lettergrade,GPA,Term,GPAL) VALUES (@CourseCode,@CourseName,@ECTScredits,@MidTerm,@Final,@Lettergrade,@GPA,@Term,@GPAL)";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@CourseCode", textBox1.Text);
                komut.Parameters.AddWithValue("@CourseName", textBox2.Text);
                komut.Parameters.AddWithValue("@ECTScredits", Convert.ToInt32(textBox3.Text));
                komut.Parameters.AddWithValue("@MidTerm", Convert.ToInt32(textBox4.Text));
                komut.Parameters.AddWithValue("@Final", Convert.ToInt32(textBox5.Text));
                komut.Parameters.AddWithValue("@Lettergrade", textBox7.Text);
                komut.Parameters.AddWithValue("@GPA", Convert.ToInt32(textBox8.Text));
                komut.Parameters.AddWithValue("@Term", Convert.ToInt32(comboBox1.Text));
                komut.Parameters.AddWithValue("@GPAL", Convert.ToDouble(textBox10.Text));
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                Datacome();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorg = "Delete from Donem1 where StudentNumber=@StudentNumber";
            komut = new SqlCommand(sorg, baglanti);
            komut.Parameters.AddWithValue("@StudentNumber", Convert.ToInt32(textBox6.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Datacome();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int mid = Convert.ToInt32(textBox4.Text);
            int fin = Convert.ToInt32(textBox5.Text);
            double ort = (mid + fin) / 2;
            textBox8.Text = Convert.ToString(ort);
            double gpa = 4 * ort / 100;
            textBox10.Text = Convert.ToString(gpa);
            string sorgu = "UPDATE Donem1 SET CourseCode=@CourseCode,CourseName=@CourseName,ECTScredits=@ECTScredits,MidTerm=@MidTerm,Final=@Final,Lettergrade=@Lettergrade,GPA=@GPA,Term=@Term,GPAL=@GPAL WHERE StudentNumber=@StudentNumber";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@StudentNumber", Convert.ToInt32(textBox6.Text));
            komut.Parameters.AddWithValue("@CourseCode", textBox1.Text);
            komut.Parameters.AddWithValue("@CourseName", textBox2.Text);
            komut.Parameters.AddWithValue("@ECTScredits", Convert.ToInt32(textBox3.Text));
            komut.Parameters.AddWithValue("@MidTerm", Convert.ToInt32(textBox4.Text));
            komut.Parameters.AddWithValue("@Final", Convert.ToInt32(textBox5.Text));
            komut.Parameters.AddWithValue("@Lettergrade", textBox7.Text);
            komut.Parameters.AddWithValue("@GPA", Convert.ToInt32(textBox8.Text));
            komut.Parameters.AddWithValue("@Term", Convert.ToInt32(comboBox1.Text));
            komut.Parameters.AddWithValue("@GPAL", Convert.ToDouble(textBox10.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Datacome();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string serch = "SELECT * FROM Donem1 WHERE CourseName=@CourseName";
            komut = new SqlCommand(serch, baglanti);
            komut.Parameters.AddWithValue("@CourseName", textBox9.Text);
            da =new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string serch = "SELECT * FROM Donem1 WHERE Term=@Term";
            komut = new SqlCommand(serch, baglanti);
            komut.Parameters.AddWithValue("@Term", comboBox2.Text);
            da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT ROUND(CAST(SUM(ECTScredits*GPA) AS float) / CAST(SUM(ECTScredits) AS float), 2) AS Avr FROM Donem1");
            baglanti.Open();
            int value = command.ExecuteNonQuery();

            textBox11.Text = Convert.ToString(value);
        }


    }
}
