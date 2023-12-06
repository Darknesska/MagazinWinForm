using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
            textBoxPassword.UseSystemPasswordChar = checkBoxPassword.Checked;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = checkBoxPassword.Checked;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text) 
                || string.IsNullOrEmpty(textBoxPassword.Text))
                return;

            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            bool isCorrect = false;
            using(StreamReader streamReader = new StreamReader("users.txt"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null){
                    string[] splitedLine = line.Split(';');
                    if (splitedLine[0] == login && splitedLine[1] == password) 
                    { 
                        isCorrect = true;
                        break;
                    }
                }
            }
            if (isCorrect)
            {
                MessageBox.Show("Вход выполнен.");
                textBoxLogin.Text = "";
                textBoxPassword.Text = "";
                this.Hide();
                bool a = true;
                Magazin magazin = new Magazin(a);
                magazin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegistration formRegistration = new FormRegistration();
            formRegistration.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormAuthorization_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вход выполнен.");
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
            this.Hide();
            bool a =false;
            Magazin magazin = new Magazin(a);
            magazin.ShowDialog();
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormAuthorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
