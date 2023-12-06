using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Magazin : Form
    {
        private List<Product> products = new List<Product>();
        bool a;
        public Magazin(bool a)
        {

            InitializeComponent();
            this.a = a;
            openFileDialog1.Filter = "image files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All files (*.*)|*.*";

        }

        private void Magazin_Load_1(object sender, EventArgs e)
        {
            if (a == true)
            {
                panel1.Visible = true;
            }
            else { panel1.Visible = false; }
            using (StreamReader streamReader = new StreamReader("Control.txt"))
            {
                //products.Clear();
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] spliteline = line.Split(';');
                    int id = int.Parse(spliteline[0]);
                    string name = spliteline[1];
                    string desc = spliteline[2];
                    string price = spliteline[3];
                    string imagePath = spliteline[4];
                    Product product = new Product(id, name, desc, price, imagePath);
                    products.Add(product);
                }
            }
            FillPanel();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            string path = openFileDialog1.FileName;
            pictureBox1.ImageLocation = path;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            int id = 0;
            if (this.products.Count > 0)
            {
                id = this.products[this.products.Count - 1].id + 1;
            }
            string name = textBoxName.Text;
            string desc = textBoxDesc.Text;
            string price = textBoxPrice.Text;
            string imagePath = pictureBox1.ImageLocation;
            Product product = new Product(id, name, desc, price, imagePath);
            products.Add(product);

            ClearData();
            FillPanel();
            using (StreamWriter streamWriter = new StreamWriter("Control.txt", true))
            {
                streamWriter.WriteLine($"{id};{name};{desc};{price};{imagePath}");
            }



        }
        private void ClearData()
        {


            pictureBox1.Image = null;
            textBox1.Text = null;

        }

        private void FillPanel()
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < products.Count; i++)
            {
                flowLayoutPanel1.Controls.Add(new MyUserControl1(products[i]));
            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы вышли");
            this.Hide();
            FormAuthorization formAuthorization = new FormAuthorization();
            formAuthorization.ShowDialog();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Magazin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


            Form1 form1 = new Form1(a);
            form1.Show();

        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int indexdelet = Convert.ToInt32(textBox1.Text);

            if (indexdelet >= 0 && indexdelet < products.Count)
            {
                products.RemoveAt(indexdelet);

                
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
    
