using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvtoKyrs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox3.Visible = false;
            button2.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "avtoDataSet.Seller". При необходимости она может быть перемещена или удалена.
                this.sellerTableAdapter.Fill(this.avtoDataSet.Seller);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "avtoDataSet.Buyer". При необходимости она может быть перемещена или удалена.
                this.buyerTableAdapter.Fill(this.avtoDataSet.Buyer);
                radioButton1.Checked = true;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null && textBox2.Text != null)
                {
                    if (textBox1.Text == "admin" && textBox2.Text == "admin")
                    {
                        sellerBindingSource.Filter = "(Name = '" + textBox1.Text + "') and (Password = '" + textBox2.Text + "')";
                        Form4 form4 = new Form4();
                        form4.Txt = this.textBox1.Text;
                        this.Hide();
                        form4.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        buyerBindingSource.Filter = "(Name = '" + textBox1.Text + "') and (Password = '" + textBox2.Text + "')";
                        MessageBox.Show("Вход выполнен");
                        Form3 form3 = new Form3();
                        form3.Txt = this.textBox1.Text;
                        this.Hide();
                        form3.ShowDialog();
                        this.Show();
                    }
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null && textBox2.Text != null)
                {
                    buyerTableAdapter.Insert(textBox1.Text, textBox3.Text, textBox2.Text);
                    MessageBox.Show("Регистрация завершена");
                }
            }
            catch { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar) textBox2.UseSystemPasswordChar = false;
            else textBox2.UseSystemPasswordChar = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Visible = false;
            button2.Visible = false;
            button1.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Visible = true;
            button2.Visible = true;
            button1.Visible = false;
            label1.Text = "Регистрация";
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
        }
    }
}
