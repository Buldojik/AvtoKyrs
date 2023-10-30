using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvtoKyrs
{
    public partial class Form4 : Form
    {
        string Id_user;
        public Form4()
        {
            InitializeComponent();
        }
        public string Txt
        {
            get { return Id_user; }
            set { Id_user = value; }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "avtoDataSet.Order". При необходимости она может быть перемещена или удалена.
                this.orderTableAdapter.Fill(this.avtoDataSet.Order);
            }
            catch { }
        }
        /// <summary>
        /// Вывод клиента и машины 
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Server=DESKTOP-7N1VDUN\SQLEXPRESS01;Database=Avto;Trusted_Connection=true");
                conn.Open();
                SqlCommand Comm = conn.CreateCommand();
                Comm.CommandText = "SELECT Name,phone from Buyer where ID_Buyer = " + Convert.ToString(((DataRowView)orderBindingSource.Current).Row["ID_Buyer"]) + "";
                SqlDataReader reader = Comm.ExecuteReader();
                while (reader.Read())
                {
                    label5.Text = reader["Name"].ToString();
                    label6.Text = reader["phone"].ToString();
                }
                reader.Close();
                SqlCommand Commm = conn.CreateCommand();
                Commm.CommandText = "SELECT Mark,Price from Car where ID_Car = " + Convert.ToString(((DataRowView)orderBindingSource.Current).Row["ID_Car"]) + "";
                SqlDataReader reader2 = Commm.ExecuteReader();
                while (reader2.Read())
                {
                    label3.Text = reader2["Mark"].ToString();
                    label4.Text = reader2["Price"].ToString() + "Р";
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                object oMissing = Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

                Microsoft.Office.Interop.Word._Application appw = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word._Document dw;
                appw.Visible = true;
                dw = appw.Documents.Add(typeof(Program).Assembly.Location + "/../../../" + "Карточка.docx", Visible: true);
                //студент
                dw.Bookmarks["ФИО"].Range.Text = label5.Text;
                dw.Bookmarks["Телефон"].Range.Text = label6.Text;
                dw.Bookmarks["Марка"].Range.Text = label3.Text;
                dw.Bookmarks["Цена"].Range.Text = label4.Text;
                SqlConnection conn = new SqlConnection(@"Server=DESKTOP-7N1VDUN\SQLEXPRESS01;Database=Avto;Trusted_Connection=true");
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "Select phone From Seller where (Name = '" + Id_user + "')";
                string result = comm.ExecuteScalar().ToString();
                dw.Bookmarks["ФИОМ"].Range.Text = Id_user;
                dw.Bookmarks["ТелефонМ"].Range.Text = result;
                dw.Bookmarks["Дата"].Range.Text = Convert.ToString(((DataRowView)orderBindingSource.Current).Row["Data"]).Remove(10, 8);
                comm.CommandText = "Select Img From Car where (Id_Car = '" + Convert.ToString(((DataRowView)orderBindingSource.Current).Row["ID_Car"]) + "')";
                string b = comm.ExecuteScalar().ToString();
                dw.Bookmarks["Фото"].Range.InlineShapes.AddPicture(Path.Combine(Environment.CurrentDirectory, b));
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
            this.Show();
        }
    }
}
