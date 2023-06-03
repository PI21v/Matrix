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

namespace Matrix
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private bool VerifyCredentials(string enteredName, string enteredPassword)
        {
            string filePath = "data.txt";
            
            try
            {
                string fileContent = File.ReadAllText(filePath);

                string[] lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < lines.Length; i += 2)
                {
                    string name = lines[i].Substring(5);
                    string password = lines[i + 1].Substring(8);

                    if (enteredName == name && enteredPassword == password)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения файла: " + ex.Message);
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя и пароль.");
                return;
            }
            if(textBox1.Text == "admin" && textBox2.Text == "12345")
            {
                Global.user_name = textBox1.Text;
                Global.is_admin = true;
                Global.form1.UserName();
                Global.form1.Show();
                this.Hide();
            }
            else if (VerifyCredentials(textBox1.Text, textBox2.Text))
            {
                Global.user_name = textBox1.Text;
                Global.is_admin = false;
                Global.form1.UserName();
                Global.form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(
               "Данного пользователя не существует.",
               "Ошибка",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string enteredName = textBox1.Text;
            string enteredPassword = textBox2.Text;

            string filePath = "data.txt";

            try
            {
                if (string.IsNullOrEmpty(enteredName) || string.IsNullOrEmpty(enteredPassword))
                {
                    MessageBox.Show("Пожалуйста, введите имя и пароль.");
                    return;
                }
                if (enteredName == "admin" && enteredPassword == "12345")
                {
                    MessageBox.Show("Пожалуйста, введите имя и пароль.");
                    return;
                }
                char[] invalidChars = Path.GetInvalidFileNameChars();
                if (enteredName.Intersect(invalidChars).Any())
                {
                    MessageBox.Show("Имя содержит недопустимые символы.");
                    return;
                }
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine("Имя: " + enteredName);
                    sw.WriteLine("Пароль: " + enteredPassword);
                    sw.WriteLine();
                }

                MessageBox.Show("Пользователь добавлен в систему.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления пользователя: " + ex.Message);
            }
        }
    }
}
