using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix
{
    
    public partial class Form1 : Form
    {

        string user_name = "test";
        string history; 

        public Form1()
        {
            InitializeComponent();
        }

        private void sumButton_Click(object sender, EventArgs e)
        {
            if(CheckMatrix_2(dgv1_1,dgv1_2))
            {            
                for (int i = 0; i < dgv1_3.ColumnCount; i++)
                {
                    for (int j = 0; j < dgv1_3.RowCount; j++)
                    {
                        dgv1_3[i, j].Value = Int32.Parse(dgv1_1[i, j].Value.ToString()) + Int32.Parse(dgv1_2[i, j].Value.ToString());
                    }
                }
            } 
        }

        private void subButton_Click(object sender, EventArgs e)
        {
            if (CheckMatrix_2(dgv1_1, dgv1_2))
            {
                for (int i = 0; i < dgv1_3.ColumnCount; i++)
                {
                    for (int j = 0; j < dgv1_3.RowCount; j++)
                    {
                        dgv1_3[i, j].Value = Int32.Parse(dgv1_1[i, j].Value.ToString()) - Int32.Parse(dgv1_2[i, j].Value.ToString());
                    }
                }
            }
        }

        private void szieButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int Column = 0;
                int Row = 0;
                if (!Int32.TryParse(size1_1.Text, out Column) || !Int32.TryParse(size1_2.Text, out Row))
                    throw new Exception("Введите числовое значение размерности");
                if (Column > 10 || Column < 1 || Row > 10 || Row < 1)
                    throw new Exception("Размер матриц не должен превышать 10х10");
                dgv1_1.ColumnCount = Column;
                dgv1_1.RowCount = Row;
                dgv1_2.ColumnCount = Column;
                dgv1_2.RowCount = Row;
                dgv1_3.ColumnCount = Column;
                dgv1_3.RowCount = Row;
                int rowHeight = dgv1_1.Size.Height / dgv1_1.RowCount;
                dgv1_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv1_2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv1_3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv1_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgv1_2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgv1_3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                for (int i = 0; i < dgv1_1.RowCount; i++)
                {
                    dgv1_1.Rows[i].Height = rowHeight - 1;
                    dgv1_2.Rows[i].Height = rowHeight - 1;
                    dgv1_3.Rows[i].Height = rowHeight - 1;
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(
               ex.Message,
               "Ошибка",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
            }
        }

        public bool CheckMatrix_2(DataGridView dgv1, DataGridView dgv2)
        {
            bool flag = true;
            try
            {
                for (int i = 0; i < dgv1.ColumnCount; i++)
                {
                    for (int j = 0; j < dgv1.RowCount; j++)
                    {
                        int temp;
                        if(dgv1[i, j].Value == null)
                            throw new Exception("Все ячейки должны быть заполнены");
                        if (!Int32.TryParse(dgv1[i, j].Value.ToString(), out temp))
                            throw new Exception("Введите числовое значение");
                    }
                }
                for (int i = 0; i < dgv2.ColumnCount; i++)
                {
                    for (int j = 0; j < dgv2.RowCount; j++)
                    {
                        int temp;
                        if (dgv2[i, j].Value == null)
                            throw new Exception("Все ячейки должны быть заполнены");
                        if (!Int32.TryParse(dgv2[i, j].Value.ToString(), out temp))
                            throw new Exception("Введите числовое значение");
                    }
                }
            }
            catch(Exception ex)
            {
                flag = false;
                MessageBox.Show(
               ex.Message,
               "Ошибка",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
            }
            return flag;
        }
        public bool CheckMatrix_1(DataGridView dgv1)
        {
            bool flag = true;
            try
            {
                for (int i = 0; i < dgv1.ColumnCount; i++)
                {
                    for (int j = 0; j < dgv1.RowCount; j++)
                    {
                        int temp;
                        if (dgv1[i, j].Value == null)
                            throw new Exception("Все ячейки должны быть заполнены");
                        if (!Int32.TryParse(dgv1[i, j].Value.ToString(), out temp))
                            throw new Exception("Введите числовое значение");
                    }
                }
            }
            catch (Exception ex)
            {
                flag = false;
                MessageBox.Show(
               ex.Message,
               "Ошибка",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
            }
            return flag;
        }
        private void dgv1_1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ((DataGridView)sender).SelectedCells[0].Selected = false;
            }
            catch { }
        }
        private void sizeButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int Column = 0;
                int Row = 0;
                if (!Int32.TryParse(size2_1.Text, out Column) || !Int32.TryParse(size2_2.Text, out Row))
                    throw new Exception("Введите числовое значение размерности");
                if (Column > 10 || Column < 1 || Row > 10 || Row < 1)
                    throw new Exception("Размер матриц не должен превышать 10х10");
                dgv2_1.ColumnCount = Column;
                dgv2_1.RowCount = Row;
                dgv2_2.ColumnCount = 1;
                dgv2_2.RowCount = Column;
                dgv2_3.ColumnCount = 1;
                dgv2_3.RowCount = Row;
                int rowHeight = dgv2_1.Size.Height / dgv2_1.RowCount;
                int rowHeight1 = dgv2_2.Size.Height / dgv2_2.RowCount;
                dgv2_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv2_2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv2_3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv2_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgv2_2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgv2_3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                for (int i = 0; i < dgv2_1.RowCount; i++)
                {
                    dgv2_1.Rows[i].Height = rowHeight - 1;
                    dgv2_3.Rows[i].Height = rowHeight - 1;
                }
                for (int i = 0; i < dgv2_2.RowCount; i++)
                {
                    dgv2_2.Rows[i].Height = rowHeight1 - 1;
                   
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
        }

        private void vectorButton_Click(object sender, EventArgs e)
        {
            if (CheckMatrix_2(dgv2_1, dgv2_2))
            {
                for (int i = 0; i < dgv2_3.RowCount; i++)
                {
                    dgv2_3[0, i].Value = 0;
                }
                for (int i = 0; i < dgv2_1.RowCount; i++)
                {
                    for (int j = 0; j < dgv2_1.ColumnCount; j++)
                    {
                        dgv2_3[0, i].Value = Int32.Parse(dgv2_3[0, i].Value.ToString()) + Int32.Parse(dgv2_1[j, i].Value.ToString()) * Int32.Parse(dgv2_2[0, j].Value.ToString());
                    }
                }
            }
        }

        private void sizeButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int Column = 0;
                int Row = 0;
                if (!Int32.TryParse(size3_1.Text, out Column) || !Int32.TryParse(size3_2.Text, out Row))
                    throw new Exception("Введите числовое значение размерности");
                if (Column > 10 || Column < 1 || Row > 10 || Row < 1)
                    throw new Exception("Размер матриц не должен превышать 10х10");
                dgv3_1.ColumnCount = Column;
                dgv3_1.RowCount = Row;
                dgv3_3.ColumnCount = Row;
                dgv3_3.RowCount = Column;
                int rowHeight1 = dgv3_1.Size.Height / dgv3_1.RowCount;
                int rowHeight3 = dgv3_3.Size.Height / dgv3_3.RowCount;
                dgv3_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv3_3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv3_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgv3_3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                for (int i = 0; i < dgv3_1.RowCount; i++)
                {
                    dgv3_1.Rows[i].Height = rowHeight1 - 1;  
                }
                for (int i = 0; i < dgv3_3.RowCount; i++)
                {
                    dgv3_3.Rows[i].Height = rowHeight3 - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
        }

        private void transpButton_Click(object sender, EventArgs e)
        {
            if (CheckMatrix_1(dgv3_1))
            {
                for (int i = 0; i < dgv3_3.RowCount; i++)
                {
                    for (int j = 0; j < dgv3_3.ColumnCount; j++)
                    {
                        dgv3_3[j, i].Value = dgv3_1[i, j].Value;
                    }
                }
            }
        }

        private void sizeButton4_Click(object sender, EventArgs e)
        {
            try
            {
                int Column = 0;
                int Row = 0;
                if (!Int32.TryParse(size4_1.Text, out Column) || !Int32.TryParse(size4_2.Text, out Row))
                    throw new Exception("Введите числовое значение размерности");
                if (Column > 10 || Column < 1 || Row > 10 || Row < 1)
                    throw new Exception("Размер матриц не должен превышать 10х10");
                dgv4_1.ColumnCount = Column;
                dgv4_1.RowCount = Row;
                int rowHeight = dgv4_1.Size.Height / dgv4_1.RowCount;
                dgv4_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv4_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                for (int i = 0; i < dgv4_1.RowCount; i++)
                {
                    dgv4_1.Rows[i].Height = rowHeight - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
        }

        private void normaButton_Click(object sender, EventArgs e)
        {
            if (CheckMatrix_1(dgv4_1))
            {
                int[] max1 = new int[dgv4_1.RowCount];
                for (int i = 0; i < dgv4_1.RowCount; i++)
                {
                    for (int j = 0; j < dgv4_1.ColumnCount; j++)
                    {
                        max1[i] += Int32.Parse(dgv4_1[j, i].Value.ToString());
                    }
                }
                int maximum1 = max1[0];
                for (int i = 0; i < dgv4_1.RowCount; i++)
                {
                    if (maximum1 < max1[i])
                        maximum1 = max1[i];
                }

                int[] max2 = new int[dgv4_1.ColumnCount];
                for (int i = 0; i < dgv4_1.ColumnCount; i++)
                {
                    for (int j = 0; j < dgv4_1.RowCount; j++)
                    {
                        max2[i] += Int32.Parse(dgv4_1[i, j].Value.ToString());
                    }
                }
                int maximum2 = max2[0];
                for (int i = 0; i < dgv4_1.ColumnCount; i++)
                {
                    if (maximum2 < max2[i])
                        maximum2 = max2[i];
                }

                label16.Text = "{||A1|| = " + maximum1 + "; ||A2|| = " + maximum2 + "}";
            }
        }

        private void sizeButton5_Click(object sender, EventArgs e)
        {
            try
            {  
                int Column = 0;
                int Row = 0;
                if (!Int32.TryParse(size5_1.Text, out Column) || !Int32.TryParse(size5_2.Text, out Row))
                    throw new Exception("Введите числовое значение размерности");
                if (Column > 10 || Column < 1 || Row > 10 || Row < 1)
                    throw new Exception("Размер матриц не должен превышать 10х10");
                dgv5_1.ColumnCount = Column;
                dgv5_1.RowCount = Row;
                dgv5_3.ColumnCount = Row;
                dgv5_3.RowCount = Column;
                int rowHeight = dgv5_1.Size.Height / dgv5_1.RowCount;
                dgv5_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv5_3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv5_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgv5_3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                for (int i = 0; i < dgv5_1.RowCount; i++)
                {
                    dgv5_1.Rows[i].Height = rowHeight - 1;
                    dgv5_3.Rows[i].Height = rowHeight - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
        }

        private void text_changed(object sender, EventArgs e)
        {
            try
            {
                size5_2.Text = size5_1.Text;
            }
            catch { }
        }
        private void text_changed_2(object sender, EventArgs e)
        {
            try
            {
                size8_2.Text = size8_1.Text;
            }
            catch { }
        }
        private void text_changed_3(object sender, EventArgs e)
        {
            try
            {
                size6_2.Text = size6_1.Text;
            }
            catch { }
        }
        private void glavnaya_diagonal_Click(object sender, EventArgs e)
        {
            if (CheckMatrix_1(dgv5_1))
            {
                for (int i = 0; i < dgv5_1.ColumnCount; i++)
                {
                    for (int j = 0; j < dgv5_1.RowCount; j++)
                    {
                        if (i == j)
                            dgv5_3[i, j].Value = dgv5_1[i, j].Value;
                        else
                            dgv5_3[i, j].Value = 0;
                    }
                }
            }
        }

        private void pobochnaya_diagonal_Click(object sender, EventArgs e)
        {
            if (CheckMatrix_1(dgv5_1))
            {
                for (int i = 0; i < dgv5_1.ColumnCount; i++)
                {
                    for (int j = 0; j < dgv5_1.RowCount; j++)
                    {
                        if (j == (dgv5_1.ColumnCount - i - 1))
                            dgv5_3[i, j].Value = dgv5_1[i, j].Value;
                        else
                            dgv5_3[i, j].Value = 0;
                    }
                }
            }
        }

        private void sizeButton8_Click(object sender, EventArgs e)
        {
            try
            {
                int Column = 0;
                int Row = 0;
                if (!Int32.TryParse(size8_1.Text, out Column) || !Int32.TryParse(size8_2.Text, out Row))
                    throw new Exception("Введите числовое значение размерности");
                if (Column > 10 || Column < 1 || Row > 10 || Row < 1)
                    throw new Exception("Размер матриц не должен превышать 10х10");
                dgv8_1.ColumnCount = Column;
                dgv8_1.RowCount = Row;
                int rowHeight = dgv8_1.Size.Height / dgv8_1.RowCount;
                dgv8_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv8_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                for (int i = 0; i < dgv8_1.RowCount; i++)
                {
                    dgv8_1.Rows[i].Height = rowHeight - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
        }

        private void opredelitelButton_Click(object sender, EventArgs e)
        {
            double opredelitel;
            if (CheckMatrix_1(dgv8_1))
            {
                opredelitel = Opredelitel(dgv8_1.ColumnCount, dgv8_1);
                label22.Text = Math.Round(opredelitel, 2).ToString();
            }
        }

        public double Opredelitel(int size, DataGridView dgv1)
        {
            double tmp;
            
            List<List<double>> dgv = new List<List<double>>();
            for(int i = 0; i < dgv1.RowCount; i++)
            {
                List<double> data = new List<double>();
                for (int j = 0; j < dgv1.RowCount; j++)
                {
                    data.Add(Int32.Parse(dgv1[j, i].Value.ToString()));
                }
                dgv.Add(data);
            }

            for (int k = 0; k < size - 1; k++)
            {
                for (int i = k + 1; i < size; i++)
                {
                    tmp = -dgv[i][k] / dgv[k][k];
                    for (int j = 0; j < size; j++)
                    {
                        double tmp2;
                        tmp2 = dgv[i][j] + dgv[k][j] * tmp;
                        dgv[i][j] = tmp2;
                    }
                }
            }
            double opredelitel = 1;
            for (int i = 0; i < size; i++)
            {
                opredelitel *= dgv[i][i];
            }

            return opredelitel;
        }

        private void sizeButton6_Click(object sender, EventArgs e)
        {
            try
            {
                int Column = 0;
                int Row = 0;
                if (!Int32.TryParse(size6_1.Text, out Column) || !Int32.TryParse(size6_2.Text, out Row))
                    throw new Exception("Введите числовое значение размерности");
                if (Column > 10 || Column < 2 || Row > 10 || Row < 2)
                    throw new Exception("Размер матриц не должен превышать 10х10");
                dgv6_1.ColumnCount = Column;
                dgv6_1.RowCount = Row;
                dgv6_3.ColumnCount = Row;
                dgv6_3.RowCount = Column;
                int rowHeight = dgv6_1.Size.Height / dgv6_1.RowCount;
                dgv6_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv6_3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv6_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgv6_3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                for (int i = 0; i < dgv6_1.RowCount; i++)
                {
                    dgv6_1.Rows[i].Height = rowHeight - 1;
                    dgv6_3.Rows[i].Height = rowHeight - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
        }

        private void obratnayaButton_Click(object sender, EventArgs e)
        {
            double opredelitel;
            if (CheckMatrix_1(dgv6_1))
            {
                opredelitel = Opredelitel(dgv6_1.ColumnCount, dgv6_1);
                if (opredelitel == 0)
                {
                    MessageBox.Show(
                "Обратной матрицы не существует, т.к. определитель равен нулю.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                }
                else
                {
                    int[,] matr = new int[dgv6_1.ColumnCount, dgv6_1.RowCount];
                    for (int i = 0; i < dgv6_1.ColumnCount; i++)
                    {
                        for (int j = 0; j < dgv6_1.ColumnCount; j++)
                        {
                            matr[i, j] = Int32.Parse(dgv6_1[i, j].Value.ToString());
                        }
                    }

                    double[,] obr_matr = new double[dgv6_1.ColumnCount, dgv6_1.ColumnCount];
                    for (int i = 0; i < dgv6_1.ColumnCount; i++)
                    {
                        for (int j = 0; j < dgv6_1.ColumnCount; j++)
                        {
                            int m = dgv6_1.ColumnCount - 1;
                            int[,] temp_matr = new int[m, m];
                            Get_matr(matr, dgv6_1.ColumnCount, temp_matr, i, j);

                            DataGridView temp = new DataGridView();
                            temp.RowCount = m;
                            temp.ColumnCount = m;
                            for (int k = 0; k < m; k++)
                            {
                                for (int l = 0; l < m; l++)
                                {
                                    temp[k, l].Value = temp_matr[k, l];
                                }
                            }
                            obr_matr[i, j] = Math.Pow(-1.0, i + j + 2) * Opredelitel(m, temp) / opredelitel;
                        }
                    }

                    for (int i = 0; i < dgv6_3.RowCount; i++)
                    {
                        for (int j = 0; j < dgv6_3.ColumnCount; j++)
                        {
                            dgv6_3[j, i].Value = Math.Round(obr_matr[i, j]);
                        }
                    }
                }
            }
        }

        static public int[,] GetMinorMatrix(int[,] matrix, int row, int col)
        {
            int[,] result = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int m = 0, k;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == row) continue;
                k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == col) continue;
                    result[m, k++] = matrix[i, j];
                }
                m++;
            }
            return result;
        }

        public void Get_matr(int[,] matr, int n, int[,] temp_matr, int indRow, int indCol)
        {
            int ki = 0;
            for (int i = 0; i < n; i++)
            {
                if (i != indRow)
                {
                    for (int j = 0, kj = 0; j < n; j++)
                    {
                        if (j != indCol)
                        {
                            temp_matr[ki,kj] = matr[i,j];
                            kj++;
                        }
                    }
                    ki++;
                }
            }
        }

        private void sizeButton7_Click(object sender, EventArgs e)
        {
            try
            {
                int Column = 0;
                int Row = 0;
                if (!Int32.TryParse(size7_1.Text, out Column) || !Int32.TryParse(size7_2.Text, out Row))
                    throw new Exception("Введите числовое значение размерности");
                if (Column > 10 || Column < 2 || Row > 10 || Row < 2)
                    throw new Exception("Размер матриц не должен превышать 10х10");
                dgv7_1.ColumnCount = Column;
                dgv7_1.RowCount = Row;
                dgv7_3.ColumnCount = Column;
                dgv7_3.RowCount = Row;
                int rowHeight = dgv7_1.Size.Height / dgv7_1.RowCount;
                dgv7_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv7_3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv7_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgv7_3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                for (int i = 0; i < dgv7_1.RowCount; i++)
                {
                    dgv7_1.Rows[i].Height = rowHeight - 1;
                    dgv7_3.Rows[i].Height = rowHeight - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message,
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
        }

        private void skalyarButton_Click(object sender, EventArgs e)
        {
            int temp;
            if (!Int32.TryParse(size7_3.Text, out temp))
            {
                MessageBox.Show(
                "Введите числовое значение скаляра",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                return;
            }

            if (CheckMatrix_1(dgv7_1))
            {
                for (int i = 0; i < dgv7_1.ColumnCount; i++)
                {
                    for (int j = 0; j < dgv7_1.RowCount; j++)
                    {
                        dgv7_3[i, j].Value = Int32.Parse(dgv7_1[i, j].Value.ToString()) * Int32.Parse(size7_3.Text);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Size == panel1.MinimumSize)
            {
                panel1.Size = panel1.MaximumSize;
                panel1.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                panel1.Size = panel1.MinimumSize;
                panel1.BorderStyle = BorderStyle.None;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            panel1.Size = panel1.MinimumSize;
            panel1.BorderStyle = BorderStyle.None;
            string data;
            try
            {
                int selectedIndex = tabControl1.SelectedIndex;
                /*history = "history\\" + user_name + ".txt";
                bool m2 = false;
                bool m3 = false;
                bool value = false;
                bool result_value = false;*/
                
                List<DataGridView> matrices = new List<DataGridView>();
                string[] matrixSizes;
                switch (selectedIndex)
                {
                    case 0:

                        matrixSizes = new string[] { size1_1.Text + "x" + size1_2.Text, size1_1.Text + "x" + size1_2.Text, size1_1.Text + "x" + size1_2.Text };
                        matrices.Add(dgv1_1);
                        matrices.Add(dgv1_2);
                        matrices.Add(dgv1_3);
                        data = $"Панель: {selectedIndex}\n";
                        data += $"Матрица1: {matrixSizes[0]}\n";
                        data += $"Матрица2: {matrixSizes[1]}\n";
                        data += $"Матрица3: {matrixSizes[2]}\n";
                        //data += $"Результат_ответ: {answerResult}\n";

                        for (int i = 0; i < matrices.Count; i++)
                        {
                            DataGridView matrix = matrices[i];
                            data += $"Результат_матрица{i + 1}:\n";
                            for (int row = 0; row < matrix.RowCount; row++)
                            {
                                for (int col = 0; col < matrix.ColumnCount; col++)
                                {
                                    data += matrix[col, row].Value.ToString();
                                    if (col < matrix.ColumnCount - 1)
                                        data += "|";
                                }
                                data += "\n";
                            }
                        }
                        break;

                    case 1:

                        matrixSizes = new string[] { size2_1.Text + "x" + size2_2.Text, "1x" + size2_1.Text, "1x" + size2_2.Text };
                        matrices.Add(dgv2_1);
                        matrices.Add(dgv2_2);
                        matrices.Add(dgv2_3);

                        data = $"Панель: {selectedIndex}\n";
                        data += $"Матрица1: {matrixSizes[0]}\n";
                        data += $"Матрица2: {matrixSizes[1]}\n";
                        data += $"Матрица3: {matrixSizes[2]}\n";

                        for (int i = 0; i < matrices.Count; i++)
                        {
                            DataGridView matrix = matrices[i];
                            data += $"Результат_матрица{i + 1}:\n";
                            for (int row = 0; row < matrix.RowCount; row++)
                            {
                                for (int col = 0; col < matrix.ColumnCount; col++)
                                {
                                    data += matrix[col, row].Value.ToString();
                                    if (col < matrix.ColumnCount - 1)
                                        data += "|";
                                }
                                data += "\n";
                            }
                        }
                        break;

                    case 2:

                        matrixSizes = new string[] { size3_1.Text + "x" + size3_2.Text, size3_2.Text + "x" + size3_1.Text };
                        matrices.Add(dgv3_1);
                        matrices.Add(dgv3_3);

                        data = $"Панель: {selectedIndex}\n";
                        data += $"Матрица1: {matrixSizes[0]}\n";
                        data += $"Матрица3: {matrixSizes[1]}\n";

                        for (int i = 0; i < matrices.Count; i++)
                        {
                            DataGridView matrix = matrices[i];
                            data += $"Результат_матрица{i + 1}:\n";
                            for (int row = 0; row < matrix.RowCount; row++)
                            {
                                for (int col = 0; col < matrix.ColumnCount; col++)
                                {
                                    data += matrix[col, row].Value.ToString();
                                    if (col < matrix.ColumnCount - 1)
                                        data += "|";
                                }
                                data += "\n";
                            }
                        }
                        break;

                    case 3:

                        matrixSizes = new string[] { size4_1.Text + "x" + size4_2.Text };
                        matrices.Add(dgv4_1);

                        data = $"Панель: {selectedIndex}\n";
                        data += $"Матрица1: {matrixSizes[0]}\n";
                        data += $"Результат_ответ: {label16.Text}\n";
                        break;

                    case 4:

                        matrixSizes = new string[] { size5_1.Text + "x" + size5_2.Text, size5_1.Text + "x" + size5_2.Text };
                        matrices.Add(dgv5_1);
                        matrices.Add(dgv5_3);

                        data = $"Панель: {selectedIndex}\n";
                        data += $"Матрица1: {matrixSizes[0]}\n";
                        data += $"Матрица3: {matrixSizes[1]}\n";

                        for (int i = 0; i < matrices.Count; i++)
                        {
                            DataGridView matrix = matrices[i];
                            data += $"Результат_матрица{i + 1}:\n";
                            for (int row = 0; row < matrix.RowCount; row++)
                            {
                                for (int col = 0; col < matrix.ColumnCount; col++)
                                {
                                    data += matrix[col, row].Value.ToString();
                                    if (col < matrix.ColumnCount - 1)
                                        data += "|";
                                }
                                data += "\n";
                            }
                        }
                        break;

                    case 5:

                        matrixSizes = new string[] { size6_1.Text + "x" + size6_2.Text, size6_1.Text + "x" + size6_2.Text };
                        matrices.Add(dgv6_1);
                        matrices.Add(dgv6_3);

                        data = $"Панель: {selectedIndex}\n";
                        data += $"Матрица1: {matrixSizes[0]}\n";
                        data += $"Матрица3: {matrixSizes[1]}\n";

                        for (int i = 0; i < matrices.Count; i++)
                        {
                            DataGridView matrix = matrices[i];
                            data += $"Результат_матрица{i + 1}:\n";
                            for (int row = 0; row < matrix.RowCount; row++)
                            {
                                for (int col = 0; col < matrix.ColumnCount; col++)
                                {
                                    data += matrix[col, row].Value.ToString();
                                    if (col < matrix.ColumnCount - 1)
                                        data += "|";
                                }
                                data += "\n";
                            }
                        }
                        break;

                    case 6:

                        matrixSizes = new string[] { size7_1.Text + "x" + size7_2.Text, size7_1.Text + "x" + size7_2.Text };
                        matrices.Add(dgv7_1);
                        matrices.Add(dgv7_3);

                        data = $"Панель: {selectedIndex}\n";
                        data += $"Матрица1: {matrixSizes[0]}\n";
                        data += $"Матрица3: {matrixSizes[1]}\n";
                        data += $"Переменная: {size7_3.Text}\n";
                        for (int i = 0; i < matrices.Count; i++)
                        {
                            DataGridView matrix = matrices[i];
                            data += $"Результат_матрица{i + 1}:\n";
                            for (int row = 0; row < matrix.RowCount; row++)
                            {
                                for (int col = 0; col < matrix.ColumnCount; col++)
                                {
                                    data += matrix[col, row].Value.ToString();
                                    if (col < matrix.ColumnCount - 1)
                                        data += "|";
                                }
                                data += "\n";
                            }
                        }
                        break;

                    case 7:

                        matrixSizes = new string[] { size8_1.Text + "x" + size8_2.Text };
                        matrices.Add(dgv8_1);

                        data = $"Панель: {selectedIndex}\n";
                        data += $"Матрица1: {matrixSizes[0]}\n";
                        data += $"Результат_ответ: {label22.Text}\n";
                        break;

                    default:
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при считывании данных: " + ex.Message);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.FileName = "output.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    File.WriteAllText(filePath, data);
                    MessageBox.Show("Данные успешно записаны в файл.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при записи данных в файл: " + ex.Message);
                    return;
                }
            }
            
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            panel1.Size = panel1.MinimumSize;
            panel1.BorderStyle = BorderStyle.None;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);
                string[] lines = fileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                int selectedIndex = 0;
                string[] matrixSizes = new string[3];
                int variableValue = 0;
                int answerResult = 0;
                int currentMatrixIndex = 0;
                int[] size = new int[2];
                int temp = 0;
                try
                { 
                    dgv1_1.Rows.Clear();
                    dgv1_2.Rows.Clear();
                    dgv1_3.Rows.Clear();


                    foreach (string line in lines)
                    {
                        if (line.StartsWith("Панель:"))
                        {
                            selectedIndex = int.Parse(line.Substring(line.IndexOf(":") + 1).Trim());
                        }
                        else if (line.StartsWith("Матрица"))
                        {
                            int matrixIndex = int.Parse(line.Substring(line.IndexOf("ц") + 2, 1));
                            matrixSizes[matrixIndex - 1] = line.Substring(line.IndexOf(":") + 1).Trim();
                        }
                        else if (line.StartsWith("Переменная:"))
                        {
                            variableValue = int.Parse(line.Substring(line.IndexOf(":") + 1).Trim());
                        }
                        else if (line.StartsWith("Результат_ответ:"))
                        {
                            answerResult = int.Parse(line.Substring(line.IndexOf(":") + 1).Trim());
                        }
                        else if (line.StartsWith("Результат_матрица"))
                        {
                            
                            currentMatrixIndex = int.Parse(line.Substring(line.IndexOf("ц") + 2, 1));
                            size = matrixSizes[currentMatrixIndex - 1].Split('x').Select(x => int.Parse(x)).ToArray();
                            if (currentMatrixIndex == 1)
                            {
                                dgv1_1.ColumnCount = size[0];
                                dgv1_1.RowCount = size[1];
                            }
                                
                            if (currentMatrixIndex == 2)
                            {
                                dgv1_2.ColumnCount = size[0];
                                dgv1_2.RowCount = size[1];
                            }
                                
                            if (currentMatrixIndex == 3)
                            {
                                dgv1_3.ColumnCount = size[0];
                                dgv1_3.RowCount = size[1];
                            }
               
                        }
                        else if (!string.IsNullOrWhiteSpace(line))
                        {
                            string[] matrixValues = line.Split('|');             
                            if (currentMatrixIndex == 1)
                            {
                                for (int i = 0; i < matrixValues.Length; i++)
                                {
                                    dgv1_1[i, temp].Value = matrixValues[i];
                                }
                            }
                            if (currentMatrixIndex == 2)
                            {
                                for (int i = 0; i < matrixValues.Length; i++)
                                {
                                    dgv1_2[i, temp - dgv1_1.RowCount].Value = matrixValues[i];
                                }
                            }
                            if (currentMatrixIndex == 3)
                            {
                                for (int i = 0; i < matrixValues.Length; i++)
                                {
                                    dgv1_3[i, temp - dgv1_1.RowCount - dgv1_2.RowCount].Value = matrixValues[i];
                                }    
                            }
                            temp++;
                        }
                    }

                    //switch (selectedIndex) { }

                    size1_1.Text = dgv1_1.ColumnCount.ToString();
                    size1_2.Text = dgv1_1.RowCount.ToString();
                    int rowHeight = dgv1_1.Size.Height / dgv1_1.RowCount;
                    dgv1_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv1_2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv1_3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv1_1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                    dgv1_2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                    dgv1_3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                    for (int i = 0; i < dgv1_1.RowCount; i++)
                    {
                        dgv1_1.Rows[i].Height = rowHeight - 1;
                        dgv1_2.Rows[i].Height = rowHeight - 1;
                        dgv1_3.Rows[i].Height = rowHeight - 1;
                    }
                }
                catch (Exception ex)
                {
                    dgv1_1.Rows.Clear();
                    dgv1_2.Rows.Clear();
                    dgv1_3.Rows.Clear();
                    size1_1.Text = "";
                    size1_2.Text = "";
                    MessageBox.Show("Произошла ошибка при чтении файла: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel3.Size == panel3.MinimumSize)
            {
                panel3.Size = panel3.MaximumSize;
                panel3.BorderStyle = BorderStyle.FixedSingle;
            }

            else
            {
                panel3.Size = panel3.MinimumSize;
                panel3.BorderStyle = BorderStyle.None;
            }
        }

        private void journalButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {

        }

        const int WM_PARENTNOTIFY = 0x210;
        const int WM_LBUTTONDOWN = 0x201;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN || (m.Msg == WM_PARENTNOTIFY &&
                (int)m.WParam == WM_LBUTTONDOWN))
            {
                if (!panel1.ClientRectangle.Contains(panel1.PointToClient(Cursor.Position)) &&
                    (!button1.ClientRectangle.Contains(button1.PointToClient(Cursor.Position))))
                {
                    panel1.Size = panel1.MinimumSize;
                    panel1.BorderStyle = BorderStyle.None;
                }
                    
                if (!panel3.ClientRectangle.Contains(panel3.PointToClient(Cursor.Position)) &&
                    (!button3.ClientRectangle.Contains(button3.PointToClient(Cursor.Position))))
                {
                    panel3.Size = panel3.MinimumSize;
                    panel3.BorderStyle = BorderStyle.None;
                }
                    
            }

            base.WndProc(ref m);
        }
    }
}
