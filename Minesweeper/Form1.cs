using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Text;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        static int m = 20, n = 20, MineCount = m * n / 7, ButtttonSize = 32;
        bool FirstStep = true;
        byte Grid = 1;
        int[,] Field = new int[m, n];
        ImageList ImageList = new ImageList();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel.Width = n * (ButtttonSize + Grid) + 4;
            panel.Height = m * (ButtttonSize + Grid) + 4;

            this.Height = m * (ButtttonSize + Grid) + 53;
            this.Width = n * (ButtttonSize + Grid) + 34;
            this.Left = Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2;
            this.Top = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2;

            LoadResources();
        }

        private void LoadResources()
        {
            ImageList.Images.Add(Properties.Resources._0);
            ImageList.Images.Add(Properties.Resources._1);
            ImageList.Images.Add(Properties.Resources._2);
            ImageList.Images.Add(Properties.Resources._3);
            ImageList.Images.Add(Properties.Resources._4);
            ImageList.Images.Add(Properties.Resources._5);
            ImageList.Images.Add(Properties.Resources._6);
            ImageList.Images.Add(Properties.Resources._7);
            ImageList.Images.Add(Properties.Resources._8);
            ImageList.Images.Add(Properties.Resources.Mine_Boom);
            ImageList.Images.Add(Properties.Resources.Mine_Flag);
            ImageList.Images.Add(Properties.Resources.Mine_Defused);
            ImageList.Images.Add(Properties.Resources.Button);

            ImageList.ImageSize = new Size(ButtttonSize, ButtttonSize);
        }

        private void GenerateField(int FirstClick_X, int FirstClick_Y)
        {
            Random Rnd = new Random();
            int M = 0;
            while (M < MineCount)
            {
                int x = Rnd.Next(n);
                int y = Rnd.Next(m);

                if (Field[y, x] != 9 && (FirstClick_X != x || FirstClick_Y != y))
                {
                    M++;
                    Field[y, x] = 9; //Mine


                    if (x == 0)
                    {
                        if (Field[y, x + 1] != 9) Field[y, x + 1] += 1; // 4

                        if (y == 0)
                        {
                            if (Field[y + 1, x + 1] != 9) Field[y + 1, x + 1] += 1; // 5
                            if (Field[y + 1, x] != 9) Field[y + 1, x] += 1; // 6
                        }

                        if (y > 0 && y < m - 1)
                        {
                            if (Field[y - 1, x] != 9) Field[y - 1, x] += 1; // 2
                            if (Field[y - 1, x + 1] != 9) Field[y - 1, x + 1] += 1; // 3
                            if (Field[y + 1, x + 1] != 9) Field[y + 1, x + 1] += 1; // 5
                            if (Field[y + 1, x] != 9) Field[y + 1, x] += 1; // 6
                        }

                        if (y == m - 1)
                        {
                            if (Field[y - 1, x] != 9) Field[y - 1, x] += 1; // 2
                            if (Field[y - 1, x + 1] != 9) Field[y - 1, x + 1] += 1; // 3
                        }
                    }

                    if (x > 0 && x < n - 1)
                    {
                        if (Field[y, x + 1] != 9) Field[y, x + 1] += 1; // 4
                        if (Field[y, x - 1] != 9) Field[y, x - 1] += 1; // 8

                        if (y == 0)
                        {
                            if (Field[y + 1, x + 1] != 9) Field[y + 1, x + 1] += 1; // 5
                            if (Field[y + 1, x] != 9) Field[y + 1, x] += 1; // 6
                            if (Field[y + 1, x - 1] != 9) Field[y + 1, x - 1] += 1; // 7
                        }

                        if (y > 0 && y < m - 1)
                        {
                            if (Field[y - 1, x - 1] != 9) Field[y - 1, x - 1] += 1; // 1
                            if (Field[y - 1, x] != 9) Field[y - 1, x] += 1; // 2
                            if (Field[y - 1, x + 1] != 9) Field[y - 1, x + 1] += 1; // 3
                            if (Field[y + 1, x + 1] != 9) Field[y + 1, x + 1] += 1; // 5
                            if (Field[y + 1, x] != 9) Field[y + 1, x] += 1; // 6
                            if (Field[y + 1, x - 1] != 9) Field[y + 1, x - 1] += 1; // 7
                        }

                        if (y == m - 1)
                        {
                            if (Field[y - 1, x - 1] != 9) Field[y - 1, x - 1] += 1; // 1
                            if (Field[y - 1, x] != 9) Field[y - 1, x] += 1; // 2
                            if (Field[y - 1, x + 1] != 9) Field[y - 1, x + 1] += 1; // 3
                        }
                    }

                    if (x == n - 1)
                    {
                        if (Field[y, x - 1] != 9) Field[y, x - 1] += 1; // 8

                        if (y == 0)
                        {
                            if (Field[y + 1, x] != 9) Field[y + 1, x] += 1; // 6
                            if (Field[y + 1, x - 1] != 9) Field[y + 1, x - 1] += 1; // 7
                        }

                        if (y > 0 && y < m - 1)
                        {
                            if (Field[y - 1, x - 1] != 9) Field[y - 1, x - 1] += 1; // 1
                            if (Field[y - 1, x] != 9) Field[y - 1, x] += 1; // 2
                            if (Field[y + 1, x] != 9) Field[y + 1, x] += 1; // 6
                            if (Field[y + 1, x - 1] != 9) Field[y + 1, x - 1] += 1; // 7
                        }

                        if (y == m - 1)
                        {
                            if (Field[y - 1, x - 1] != 9) Field[y - 1, x - 1] += 1; // 1
                            if (Field[y - 1, x] != 9) Field[y - 1, x] += 1; // 2
                        }
                    }
                }
            }
        }

        private int FieldToImageIndex(int i, int j)
        {
            if (Field[j, i] < 10)
                return 12;
            else if (Field[j, i] >= 10 && Field[j, i] < 20)
                return Field[j, i] - 10;
            else if (Field[j, i] >= 20 && Field[j, i] < 30)
                return 10;
            else return 11;
        }

        private void DrawImage(int x, int y)
        {
            Graphics G = panel.CreateGraphics();
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ImageList.Draw(G, x * (ButtttonSize + Grid), y * (ButtttonSize + Grid), FieldToImageIndex(x, y));
            G.Dispose();
        }

        private void FieldAutoClean(int x, int y)
        {
            if (Field[y, x] == 10)
            {
                int i_start, i_finish, j_start, j_finish;

                if (x == 0) i_start = 0;
                else i_start = -1;
                if (x == n - 1) i_finish = 1;
                else i_finish = 2;

                if (y == 0) j_start = 0;
                else j_start = -1;
                if (y == m - 1) j_finish = 1;
                else j_finish = 2;

                for (int j = j_start; j < j_finish; j++)
                {
                    for (int i = i_start; i < i_finish; i++)
                    {
                        if (Field[y + j, x + i] < 10)
                        {
                            Field[y + j, x + i] += 10;
                            DrawImage(x + i, y + j);
                            FieldAutoClean(x + i, y + j);
                        }
                    }
                }
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    DrawImage(i, j);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            //    /* 0	Button
            //     * 1-8	Digits
            //     * 9	Mine_Boom

            //     * 10	Button_Pressed
            //     * 11-18	Digits_Pressed
            //     * 19	Mine_Pressed

            //     * 20-29	Flag*/

            int x = e.X / (ButtttonSize + Grid);
            int y = e.Y / (ButtttonSize + Grid);
            if (x >= n || y >= m)
                goto EndOfFunction;

            if (FirstStep == true)
            {
                FirstStep = false;
                GenerateField(x, y);
            }

            if (e.Button == MouseButtons.Left && Field[y, x] < 10)
            {
                Field[y, x] += 10;
                DrawImage(x, y);

                FieldAutoClean(x, y);

                if (Field[y, x] == 19)
                {
                    MessageBox.Show("Lose =(");
                    this.Close();
                }
            }

            else if (e.Button == MouseButtons.Right && (Field[y, x] <= 9 || Field[y, x] >= 19))
            {
                if (Field[y, x] <= 9)
                    Field[y, x] += 20;
                else
                    Field[y, x] -= 20;
                DrawImage(x, y);
            }

            int F = 0;
            foreach (int val in Field)
            {
                if (val < 9 || val > 19 && val < 29)
                    F++;
            }

            if (F == 0)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (Field[j, i] == 9 || Field[j, i] == 29)
                            Field[j, i] = 30;
                        DrawImage(i, j);
                    }
                }
                MessageBox.Show("You WIN!!! =)*");
                this.Close();
            }

        EndOfFunction: ;
        }
    }
}
