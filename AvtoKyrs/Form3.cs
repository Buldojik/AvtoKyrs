using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvtoKyrs
{
    public partial class Form3 : Form
    {
        string Id_user;
        public Form3()
        {
            InitializeComponent();
            label2.Visible = false;
            label3.Visible = false;
        }
        public string Txt
        {
            get { return Id_user; }
            set { Id_user = value; }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "avtoDataSet.Order". При необходимости она может быть перемещена или удалена.
                this.orderTableAdapter.Fill(this.avtoDataSet.Order);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "avtoDataSet.Car". При необходимости она может быть перемещена или удалена.
                this.carTableAdapter.Fill(this.avtoDataSet.Car);
            }
            catch 
            {
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label2.Visible = true;
                label3.Visible = true;
                richTextBox1.Text = Convert.ToString(((DataRowView)carBindingSource.Current).Row["Description"]);
                label2.Text = Convert.ToString(((DataRowView)carBindingSource.Current).Row["Price"]) + "Р";
                label3.Text = Convert.ToString(((DataRowView)carBindingSource.Current).Row["Mark"]);
                pictureBox1.ImageLocation = Convert.ToString(((DataRowView)carBindingSource.Current).Row["Img"]);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Server=DESKTOP-7N1VDUN\SQLEXPRESS01;Database=Avto;Trusted_Connection=true");
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "Select ID_Buyer From Buyer where (Name = '" + Id_user + "')";
                int result = Convert.ToInt32(comm.ExecuteScalar());
                orderTableAdapter.Insert(result, Convert.ToInt32(listBox1.SelectedValue), null, DateTime.Now);
                MessageBox.Show("заявка отправленна");
            }
            catch { }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // try
            {
                SqlConnection conn = new SqlConnection(@"Server=DESKTOP-7N1VDUN\SQLEXPRESS01;Database=Avto;Trusted_Connection=true");
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "Select ID_Car From Car where (Mark = '" + textBox1.Text + "')";
                string res = comm.ExecuteScalar().ToString();
                int foundIndex = carBindingSource.Find("Id_Car", res);
                carBindingSource.Position = foundIndex;
            }
            //catch { }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @"опоп\Справка.chm");
        }
    }
}
