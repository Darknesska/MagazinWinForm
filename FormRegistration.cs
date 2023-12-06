using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FormRegistration : Form
    {
        public FormRegistration()
        {
            InitializeComponent();
            textBoxPassword.UseSystemPasswordChar = checkBoxPassword.Checked;
            textBoxRepeatPassword.UseSystemPasswordChar = checkBoxPassword.Checked;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = checkBoxPassword.Checked;
            textBoxRepeatPassword.UseSystemPasswordChar = checkBoxPassword.Checked;
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string repeatPassword = textBoxRepeatPassword.Text;

            if (string.IsNullOrEmpty(login)
                || string.IsNullOrEmpty(password)
                || string.IsNullOrEmpty(repeatPassword))
            {
                MessageBox.Show("Введены пустые данные!");
                return;
            }

            if (!password.Equals(repeatPassword))
            {
                MessageBox.Show("Пароли не свопадают!");
                return;
            }

            bool isCorrect = false;
            using (StreamReader streamReader = new StreamReader("users.txt"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] splitedLine = line.Split(';');
                    if (splitedLine[0] == login)
                    {
                        isCorrect = true;
                        break;
                    }
                }
            }
            if (isCorrect)
            {
                MessageBox.Show("Пользователь с таким логином уже зарегистрирован!");
                return;
            }

            using (StreamWriter streamWriter = new StreamWriter("users.txt", true))
            {
                streamWriter.WriteLine($"{login};{password}");
            }

            MessageBox.Show("Пользователь успешно зарегистрирован!");
            this.Close();
        }

        private void FormRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Show();
        }

        private void FormRegistration_Load(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
