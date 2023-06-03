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
    public partial class Form2 : Form
    {
        int index = -1;
        public Form2()
        {
            InitializeComponent();

            if (Global.is_admin)
            {
                panel1.AutoScroll = true;
                panel1.VerticalScroll.Visible = false;
                string directoryPath = "history\\";
                string[] startNames = {" Сложение и вычитание"," Векторное умножение"," Транспонирование"," Норма"," Формирование диагональных матриц"," Обратная матрица", " Скалярное умножение"," Определитель" };

                List<string> files = new List<string>();

                foreach (string startName in startNames)
                {
                    string[] matchingFiles = Directory.GetFiles(directoryPath, "*" + startName + "*", SearchOption.AllDirectories);
                    files.AddRange(matchingFiles);
                }

                foreach (string filePath in files)
                {
                    string fileName = Path.GetFileName(filePath);

                    Button newButton = new Button();
                    newButton.Text = fileName;
                    newButton.Size = new Size(410, 50);

                    if (panel1.Controls.Count == 0)
                    {
                        newButton.Location = new Point(0, 0);
                    }
                    else
                    {
                        Button lastButton = (Button)panel1.Controls[panel1.Controls.Count - 1];
                        int newY = lastButton.Location.Y + lastButton.Height + 0;
                        newButton.Location = new Point(0, newY);
                    }
                    newButton.Font = new Font(newButton.Font.FontFamily, 12);
                    panel1.Controls.Add(newButton);
                    newButton.Click += NewButton_Click;
                }
            }
            else
            {
                panel1.AutoScroll = true;
                panel1.VerticalScroll.Visible = false;
                string user = Global.user_name;
                string directoryPath = "history\\";
                string[] startNames = { user + " Сложение и вычитание", user + " Векторное умножение", user + " Транспонирование", user + " Норма", user + " Формирование диагональных матриц", user + " Обратная матрица", user + " Скалярное умножение", user + " Определитель" };

                List<string> files = new List<string>();

                foreach (string startName in startNames)
                {
                    string[] matchingFiles = Directory.GetFiles(directoryPath, startName + "*");
                    files.AddRange(matchingFiles);
                }

                foreach (string filePath in files)
                {
                    string fileName = Path.GetFileName(filePath);

                    Button newButton = new Button();
                    newButton.Text = fileName;
                    newButton.Size = new Size(410, 50);

                    if (panel1.Controls.Count == 0)
                    {
                        newButton.Location = new Point(0, 0);
                    }
                    else
                    {
                        Button lastButton = (Button)panel1.Controls[panel1.Controls.Count - 1];
                        int newY = lastButton.Location.Y + lastButton.Height + 0;
                        newButton.Location = new Point(0, newY);
                    }
                    newButton.Font = new Font(newButton.Font.FontFamily, 12);
                    panel1.Controls.Add(newButton);
                    newButton.Click += NewButton_Click;
                }
            }

        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            Global.form1.Load_func("history\\" + clickedButton.Text);
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.form1.Show();
        }
    }
}
