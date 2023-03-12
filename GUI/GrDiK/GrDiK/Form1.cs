using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrDiK
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        public Form1()
        {
            InitializeComponent();

            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");

            fileItem.DropDownItems.Add("Загрузить");
            fileItem.DropDownItems.Add(new ToolStripMenuItem("Сохранить"));

            menuStrip1.Items.Add(fileItem);

            ToolStripMenuItem aboutItem = new ToolStripMenuItem("О программе");
            aboutItem.Click += aboutItem_Click;
            menuStrip1.Items.Add(aboutItem);

            ToolStripMenuItem account = new ToolStripMenuItem("Аккаунт");

            account.DropDownItems.Add("Журнал действий");
            account.DropDownItems.Add(new ToolStripMenuItem("Выйти из аккаунта"));
            menuStrip1.Items.Add(account);

            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            tabPage1.Text = "Сложение";
            tabPage1.Size = new System.Drawing.Size(1000, 800);
            tabPage3.Text = "Вычитание";
            tabPage3.Size = new System.Drawing.Size(1000, 800);
            tabPage3.TabIndex = 2;
            tabPage2.Text = "Умножение";
            tabPage2.Size = new System.Drawing.Size(1000, 800);
            tabPage2.TabIndex = 1;
            tabPage1.TabIndex = 0;
            tabPage4.Text = "Нормирование";
            tabPage4.Size = new System.Drawing.Size(1000, 800);
            tabPage5.Text = "Транспонирование";
            tabPage5.Size = new System.Drawing.Size(1000, 800);
            tabPage5.TabIndex = 4;
            tabPage6.Text = "Диагональная матрица";
            tabPage6.Size = new System.Drawing.Size(1000, 800);
            tabPage6.TabIndex = 5;
            tabPage4.TabIndex = 3;
            this.tabControl1 = new System.Windows.Forms.TabControl();
            tabControl1.Location = new System.Drawing.Point(10, 40);
            tabControl1.Size = new System.Drawing.Size(1000, 800);
            tabControl1.SelectedIndex = 0;
            tabControl1.TabIndex = 0;
            this.Controls.Add(this.tabControl1);
            tabControl1.Controls.Add(this.tabPage1);
            tabControl1.Controls.Add(this.tabPage2);
            tabControl1.Controls.Add(this.tabPage3);
            tabControl1.Controls.Add(this.tabPage4);
            tabControl1.Controls.Add(this.tabPage5);
            tabControl1.Controls.Add(this.tabPage6);
        }
        void aboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("О программе");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
