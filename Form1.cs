using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows;
using System.Drawing.Design;
using System.Drawing.Printing;

namespace پروژه_ترم_دوم_paint
{
    public partial class Form1 : Form
    {
        int shomarande,w,h;
        Pen pen1 = new Pen(Color.Black, 1);
        Graphics g;
        string job;
        Boolean fill;
        Point startpoint, endpoint, noghte, change;
        SolidBrush brush1 = new SolidBrush(Color.Black);
        Bitmap mainbmp = new Bitmap(1099, 491);
        Bitmap blankbmp = new Bitmap(1099, 491);
        Bitmap change1 = new Bitmap(1099, 491);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graphics g2;
            Bitmap blankbitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g2 = Graphics.FromImage(blankbitmap);// /////////////////////////////////////////////////////////////////
            g2.SmoothingMode = SmoothingMode.HighQuality;// /////////////////////////////////////////////////////////
            g2.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = blankbitmap;
            pen1.Color = color1.BackColor;
            brush1.Color = color1.BackColor;
            job = "medad";
            fill = false;
            mainbmp = blankbitmap;
            blankbmp = blankbitmap;
        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Size size1 = new Size(pictureBox1.Width, pictureBox1.Height);
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "انتخاب عکس";
            dlg.Filter = "jpeg files |*.jpg| bitmap files |*.bmp| All files |*.*";
            dlg.ShowDialog();
            pictureBox1.Image = new Bitmap(dlg.FileName);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap mm = new Bitmap(dlg.FileName);
            mainbmp = new Bitmap(mm,size1);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "ذخیره عکس";
            sfd.Filter = "jpeg files |*.jpg| bitmap file |*.bmp";
            sfd.ShowDialog();
            switch (Path.GetExtension(sfd.FileName))
            {
                case ".jpg":
                    pictureBox1.Image.Save(sfd.FileName, ImageFormat.Jpeg); break;
                case ".bmp":
                    pictureBox1.Image.Save(sfd.FileName, ImageFormat.Bmp); break;
            }
        }
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            switch(MessageBox.Show("آیا میخواهید بدون ذخیره خارج شوید؟", "هشدار?", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    Close();
                    break;
                case DialogResult.No:
                    object o = new object();
                    EventArgs rr = new EventArgs();
                    saveToolStripMenuItem_Click(o, rr);
                    Close();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g2;
            Bitmap blankbitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g2 = Graphics.FromImage(blankbitmap);
            g2.SmoothingMode = SmoothingMode.HighQuality;
            g2.FillRectangle(Brushes.White,0,0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = blankbitmap;
            mainbmp = blankbitmap;
            //pictureBox1.ImageLocation = null;
            //pictureBox1.Image.Dispose();
            //PictureBox pb1 = new PictureBox();
            //pictureBox1.Image = pb1.Image;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void panel2_Click(object sender, EventArgs e)
        {
            Panel pp = new Panel();
            pp = (Panel)sender;
            color1.BackColor = pp.BackColor;
            pen1.Color = color1.BackColor;
            brush1.Color = color1.BackColor;
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Color c = new Color();
            c = color1.BackColor;
            color1.BackColor = color2.BackColor;
            color2.BackColor = c;
            pen1.Color = color1.BackColor;
            brush1.Color = color1.BackColor;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel30_Click(object sender, EventArgs e)
        {
            Panel pp = new Panel();
            pp = (Panel)sender;
            panel30.BorderStyle = panel31.BorderStyle = panel32.BorderStyle = panel33.BorderStyle = panel34.BorderStyle = panel35.BorderStyle = BorderStyle.None;
            pp.BorderStyle = BorderStyle.FixedSingle;
            pen1.Width = Convert.ToInt32(pp.Tag.ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shomarande = 1;
            Button b1 = new Button();
            b1 = (Button)sender;
            if (b1 == button3 || b1 == button5 || b1 == button9)
                fill = true;
            else
                fill = false;
            job = b1.Tag.ToString();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startpoint.X = e.X;
            startpoint.Y = e.Y;
            if (job == "chand")
            {
                g = Graphics.FromImage(mainbmp);
                g.SmoothingMode = SmoothingMode.HighQuality;
                if (shomarande == 1)
                {
                    noghte.X = e.X;
                    noghte.Y = e.Y;
                    shomarande++;
                }
                else
                {
                    g.DrawLine(pen1, noghte, startpoint);
                    noghte = startpoint;
                }
                pictureBox1.Image = mainbmp;
            }
            if (job == "tashkhis rang")
            {
                color1.BackColor = Color.FromArgb(mainbmp.GetPixel(e.X, e.Y).R,mainbmp.GetPixel(e.X, e.Y).G,mainbmp.GetPixel(e.X, e.Y).B);
                pen1.Color = color1.BackColor;
                brush1.Color = color1.BackColor;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            endpoint.X = e.X;
            endpoint.Y = e.Y;
            if (endpoint.X >= startpoint.X)
                w = endpoint.X - startpoint.X;
            else
            {
                w = startpoint.X - endpoint.X;
                change.X = startpoint.X;
                startpoint.X = endpoint.X;
                endpoint.X = change.X;
            }
            if (endpoint.Y >= startpoint.Y)
                h = endpoint.Y - startpoint.Y;
            else
            {
                h = startpoint.Y - endpoint.Y;
                change.Y = startpoint.Y;
                startpoint.Y = endpoint.Y;
                endpoint.Y = change.Y;
            }
            g = Graphics.FromImage(mainbmp);
            g.SmoothingMode = SmoothingMode.HighQuality;
            switch (job)
            {
                case"dayere":
                    if (fill)
                        g.FillEllipse(brush1, startpoint.X, startpoint.Y, (w + h) / 2, (w + h) / 2);
                    else
                        g.DrawEllipse(pen1, startpoint.X, startpoint.Y, (w + h) / 2, (w + h) / 2);
                    break;
                case"beyzi":
                    if (fill)
                        g.FillEllipse(brush1, startpoint.X, startpoint.Y, w, h);
                    else
                        g.DrawEllipse(pen1, startpoint.X, startpoint.Y, w, h);
                    break;
                case"mostatil":
                    if (fill)
                        g.FillRectangle(brush1, startpoint.X, startpoint.Y, w, h);
                    else
                        g.DrawRectangle(pen1, startpoint.X, startpoint.Y, w, h);
                   
                    break;
                
            }
                    pictureBox1.Image = mainbmp;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point ee = new Point();
            Point start2 = new Point();
            start2 = startpoint;
            ee.X = e.X;
            ee.Y = e.Y;
            if (ee.X >= start2.X)
                w = ee.X - start2.X;
            else
            {
                w = start2.X - ee.X;
                change.X = start2.X;
                start2.X = ee.X;
                ee.X = change.X;
            }
            if (ee.Y >= start2.Y)
                h = ee.Y - start2.Y;
            else
            {
                h = start2.Y - ee.Y;
                change.Y = start2.Y;
                start2.Y = ee.Y;
                ee.Y = change.Y;
            }
                if (job == "medad")
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        g = Graphics.FromImage(mainbmp);
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.DrawLine(pen1, startpoint.X, startpoint.Y, e.X, e.Y);
                        pictureBox1.Image = mainbmp;
                        startpoint.X = e.X;
                        startpoint.Y = e.Y;
                    }
                }
                if (job == "pak kon")
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        pen1.Color = Color.White;
                        g = Graphics.FromImage(mainbmp);
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.DrawLine(pen1, startpoint.X, startpoint.Y, e.X, e.Y);
                        pictureBox1.Image = mainbmp;
                        startpoint.X = e.X;
                        startpoint.Y = e.Y;
                        pen1.Color = color1.BackColor;
                    }
                }
                if (job == "mostatil")
                    if (e.Button == MouseButtons.Left)
                    {
                        {

                            pictureBox1.Refresh();
                            Graphics g3;
                            g3 = pictureBox1.CreateGraphics();
                            if (fill)
                                g3.FillRectangle(brush1, start2.X, start2.Y, w, h);
                            else
                                g3.DrawRectangle(pen1, start2.X, start2.Y, w, h);
                        }
                    }
                if (job == "dayere")
                    if (e.Button == MouseButtons.Left)
                    {
                        {

                            pictureBox1.Refresh();
                            Graphics g3;
                            g3 = pictureBox1.CreateGraphics();
                            if (fill)
                                g3.FillEllipse(brush1, start2.X, start2.Y, (w+h) / 2, (w+h) / 2);
                            else
                                g3.DrawEllipse(pen1, start2.X, start2.Y, (w+h) / 2, (w+h) / 2);
                        }
                    }
                if (job == "beyzi")
                    if (e.Button == MouseButtons.Left)
                    {
                        {

                            pictureBox1.Refresh();
                            Graphics g3;
                            g3 = pictureBox1.CreateGraphics();
                            if (fill)
                                g3.FillEllipse(brush1, start2.X, start2.Y, w, h);
                            else
                                g3.DrawEllipse(pen1, start2.X, start2.Y, w, h);
                        }
                    }
        }

        private void color1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            color1.BackColor = cd.Color;
            pen1.Color = color1.BackColor;
            brush1.Color = color1.BackColor;
            button6.BackColor = cd.Color;
        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            Panel pp = new Panel();
            pp = (Panel)sender;
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            color1.BackColor = cd.Color;
            pen1.Color = color1.BackColor;
            brush1.Color = color1.BackColor;
            pp.BackColor = cd.Color;
        }
    }
}
