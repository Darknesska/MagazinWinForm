using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    public partial class MyUserControl1 : UserControl
    {
        private Product product;
        public MyUserControl1(Product product)
        {
            

            InitializeComponent();
            this.product = product;
            FillData();

            label1.Text = Convert.ToString(product.id);
        }
        private void FillData()
        {
            if (!string.IsNullOrEmpty(product.imagePath))
            {
                pictureBoxImage.Image = new Bitmap(product.imagePath);
                labelDescription.Text = product.GetDescription();
            }
            else
            {
                pictureBoxImage.Image = new Bitmap(@"C:\Users\Darknes\Downloads\1486903752_инвокер.jpg");
                labelDescription.Text = product.GetDescription();
            }
            
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void labelDescription_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDownCount_ValueChanged(object sender, EventArgs e)
        {
           

        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы купили товар");
            
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}


