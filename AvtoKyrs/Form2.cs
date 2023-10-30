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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "avtoDataSet.Order". При необходимости она может быть перемещена или удалена.
                this.orderTableAdapter.Fill(this.avtoDataSet.Order);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "avtoDataSet.Car". При необходимости она может быть перемещена или удалена.
                this.carTableAdapter.Fill(this.avtoDataSet.Car);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && richTextBox1.Text != "")
            {
                avtoDataSet.Car.AddCarRow(richTextBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text);
                MessageBox.Show(" Данные успешно добавленны");
            }
            else
                MessageBox.Show(" Введены некорректные данные");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            carBindingSource.EndEdit();
            carTableAdapter.Update(this.avtoDataSet);
            this.carTableAdapter.Fill(this.avtoDataSet.Car);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверенны что хотите удалить данную запись?", "Удалить", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.JPG;*.PNG)|*.JPG;*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = "../../Img/" + openFileDialog1.SafeFileName;
            }
        }
    }
}
