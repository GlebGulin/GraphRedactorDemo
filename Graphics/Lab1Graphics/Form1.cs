using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Xml;
using Microsoft.Win32;
using System.Media;





namespace Lab1Graphics
{
    public partial class Form1 : Form
    {
        Image imgPicture;
        Bitmap bmpPicture;
        System.Drawing.Imaging.ImageAttributes iaPicture;
        System.Drawing.Imaging.ColorMatrix cmPicture;
        Graphics gfxPicture;
        Rectangle rctPicture;
        public Form1()
        {
            InitializeComponent();
        }
        bool Drag = false;
        int NewX;
        int NewY;
        int oldX;
        int oldY;
        Bitmap bmp;



        //Инвертирование
        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Для начала выберите картинку", "Ошибка!!!");
            }
            
            else
            {
            PreparePicture();
            cmPicture = new System.Drawing.Imaging.ColorMatrix(new float[][]
            {
                new float[]{-1, 0, 0, 0, 0},
                new float[]{0, -1, 0, 0, 0},
                new float[]{0, 0, -1, 0, 0},
                new float[]{0, 0, 0, 1, 0},
                new float[]{1, 1, 1, 1, 1},               
            });
            FinalizePicture();

            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //Открытие файла
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
                imgPicture = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = imgPicture;
                pictureBox1.Size = pictureBox1.Image.Size;
                this.Size = pictureBox1.Image.Size;
                this.Width += 200;
                this.Height += 85;
            }

        }
        private void PreparePicture()
        {
            
            if (imgPicture != null)
            {
                bmpPicture = new Bitmap(imgPicture.Width, imgPicture.Height);
                iaPicture = new System.Drawing.Imaging.ImageAttributes();
            }
        }

        private void FinalizePicture()
        {
            iaPicture.SetColorMatrix(cmPicture);
            gfxPicture = Graphics.FromImage(bmpPicture);
            rctPicture = new Rectangle(0, 0, imgPicture.Width, imgPicture.Height);
            gfxPicture.DrawImage(imgPicture, rctPicture, 0, 0, imgPicture.Width, imgPicture.Height, GraphicsUnit.Pixel, iaPicture);
            pictureBox1.Image = bmpPicture;
        }
       


        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ещё не готово", "Ошибка!!!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ещё не готово", "Ошибка!!!");
        }

       // private void button6_Click(object sender, EventArgs e)
        /*{
            public class ColorDlgForm:System.Windows.Forms.Form
            {
                private System.Windows.Forms.ColorDialog();
                public ColorDlgForm()
                {
                    ColorDlgForm = new System.Windows.Forms.ColorDialog();
                    Text = "Click please";
                    this.MouseUp+ = new MouseEventHandler(this.ColorDlg_Mouse_Up);
                    }
                
}
                

        }*/

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image == null)
            {
                MessageBox.Show("Choose Image");
            }

            else
            {

                Image myBitmap = pictureBox1.Image;
                this.pictureBox1.Size = new Size(myBitmap.Width, myBitmap.Height);
                Size nSize = new Size(pictureBox1.Image.Width * 2, pictureBox1.Image.Height * 2);
                Image gdi = new Bitmap(nSize.Width, nSize.Height);
                Graphics ZoomInGraphics = Graphics.FromImage(gdi);
                ZoomInGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                ZoomInGraphics.DrawImage(pictureBox1.Image, new Rectangle(new Point(0, 0), nSize), new Rectangle(new Point(0, 0), pictureBox1.Image.Size), GraphicsUnit.Pixel);
                ZoomInGraphics.Dispose();
                pictureBox1.Image = gdi;
                pictureBox1.Size = gdi.Size;
                pictureBox1.Size = pictureBox1.Image.Size;
                this.Size = pictureBox1.Image.Size;
                this.Width += 200;
                this.Height += 85;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image == null)
            {
                MessageBox.Show("Choose Image");
            }

            else
            {

                Image myBitmap = pictureBox1.Image;
                this.pictureBox1.Size = new Size(myBitmap.Width, myBitmap.Height);
                Size nSize = new Size(pictureBox1.Image.Width /2, pictureBox1.Image.Height  /2);
                Image gdi = new Bitmap(nSize.Width, nSize.Height);
                Graphics ZoomInGraphics = Graphics.FromImage(gdi);
                ZoomInGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                ZoomInGraphics.DrawImage(pictureBox1.Image, new Rectangle(new Point(0, 0), nSize), new Rectangle(new Point(0, 0), pictureBox1.Image.Size), GraphicsUnit.Pixel);
                ZoomInGraphics.Dispose();
                pictureBox1.Image = gdi;
                pictureBox1.Size = gdi.Size;
            }
        }

        private void button10_Click(Graphics grfx, Color clr, double cx, double cy, EventArgs e)
        {
            /*if (pictureBox1.Image == null)
            {
                MessageBox.Show("Поле чистое!!!", "WARNING!!!");
            }

            else
            {
                Graphics g = this.CreateGraphics();
                g.Clear(this.BackColor);
                Bitmap imgPicture = new Bitmap(picture
);
                g.DrawImage(imgPicture, 0, 0, 200, 200);
                // Create a Matrix object, call its Rotate method,
                // and set it as Graphics.Transform
                Matrix X = new Matrix();
                X.Rotate(30);
                g.Transform = X;
                // Draw image
                g.DrawImage(imgPicture,
                new Rectangle(205, 0, 200, 200),
                0, 0, imgPicture.Width,
                imgPicture.Height,
                GraphicsUnit.Pixel);
                // Dispose of objects
                imgPicture.Dispose();
                g.Dispose(); 

    
            }  */


            
            
            /*Image bmp = Image.pictureBox1;
            Image image = null;
	    try { image = Image.createImage("/board.png"); }
	    catch (IOException ioe) { return null; }

	    TiledLayer tiledLayer = new TiledLayer(10, 10, image, 16, 16);

	    int[] map = {
		1,  1,  1,  1, 11,  0,  0,  0,  0,  0,
		0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
		0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
		0,  0,  0,  0,  9,  0,  0,  0,  0,  0,
		0,  0,  0,  0,  1,  0,  0,  0,  0,  0,
		0,  0,  0,  7,  1,  0,  0,  0,  0,  0,
		1,  1,  1,  1,  6,  0,  0,  0,  0,  0,
		0,  0,  0,  0,  0,  0,  0,  7, 11,  0,
		0,  0,  0,  0,  0,  0,  7,  6,  0,  0,
		0,  0,  0,  0,  0,  7,  6,  0,  0,  0
	    };

	    for (int i = 0; i < map.length; i++) {
		int column = i % 10;
		int row = (i - column) / 10;
		tiledLayer.setCell(column, row, map[i]);
	    }

	    return tiledLayer;



            */
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

        }

        

        //Градация серого
        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Для начала выберите картинку", "Ошибка!!!");
            }

            else
            {
                PreparePicture();
                cmPicture = new System.Drawing.Imaging.ColorMatrix(new float[][]
            {
                new float[]{0.3f, 0.3f, 0.3f, 0, 0},
                new float[]{0.59f, 0.59f, 0.59f, 0, 0},
                new float[]{0.11f, 0.11f, 0.11f, 0, 0},
                new float[]{0, 0, 0, 1, 0, 0},
                new float[]{0, 0, 0, 0, 1, 0},
               
            });
                FinalizePicture();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //GBR
        private void button11_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Для начала выберите картинку", "Ошибка!!!");
            }

            else
            {
                PreparePicture();
                cmPicture = new System.Drawing.Imaging.ColorMatrix(new float[][]
            {                
                new float[]{0, 1, 0, 0, 0},
                new float[]{0, 0, 1, 0, 0},
                new float[]{1, 0, 0, 0, 0},
                new float[]{0, 0, 0, 1, 0},
                new float[]{0, 0, 0, 0, 1},               
            });
                FinalizePicture();
            }
        }

        //BRG
        private void button12_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Для начала выберите картинку", "Ошибка!!!");
            }

            else
            {
                PreparePicture();
                cmPicture = new System.Drawing.Imaging.ColorMatrix(new float[][]
            {                
                new float[]{0, 0, 1, 0, 0},
                new float[]{1, 0, 0, 0, 0},
                new float[]{0, 1, 0, 0, 0},
                new float[]{0, 0, 0, 1, 0},
                new float[]{0, 0, 0, 0, 1},               
            });
                FinalizePicture();
            }
        }
        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                imgPicture = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = imgPicture;
                pictureBox1.Size = pictureBox1.Image.Size;
                this.Size = pictureBox1.Image.Size;
                this.Width += 200;
                this.Height += 85;
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Файл не открыт!", "Ошибка!!!");
            }

            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "Сохранить картинку как ...";
                saveFileDialog1.OverwritePrompt = true;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.Filter =
                    "Файлы *.bmp фомата|*.bmp|" +
                    "Файлы *.jpg формата|*.jpg|" +
                    "Файл *.gif|*.gif|" +
                    "Файл *.png|*.png";
                saveFileDialog1.ShowHelp = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog1.FileName;
                    string strFilExtn =
                    fileName.Remove(0, fileName.Length - 3);
                    switch (strFilExtn)
                    {
                        case "bmp":
                            pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case "jpg":
                            pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "gif":
                            pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case "tif":
                            pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                            break;
                        case "png":
                            pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        default:
                            break;
                    }


                }
            }
            
        

        
        }

        
        private void button15_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Поле чистое!!!", "WARNING!!!");
            }

            else
            {
                pictureBox1.Image = null;
            }

        }

        //Меню Выход
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Для начала выберите картинку", "Ошибка!!!");
            }

            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "Сохранить картинку как ...";
                saveFileDialog1.OverwritePrompt = true;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.Filter =
                    "Файлы *.bmp фомата|*.bmp|" +
                    "Файлы *.jpg формата|*.jpg|" +
                    "Файл *.gif|*.gif|" +
                    "Файл *.png|*.png";
                saveFileDialog1.ShowHelp = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog1.FileName;
                    string strFilExtn =
                    fileName.Remove(0, fileName.Length - 3);
                    switch (strFilExtn)
                    {
                        case "bmp":
                            pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case "jpg":
                            pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "gif":
                            pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case "tif":
                            pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                            break;
                        case "png":
                            pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        default:
                            break;
                    }


                }
            }
        }

        //Закрыть окно
        private void button14_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void закрытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Поле чистое!!!", "WARNING!!!");
            }

            else
            {
                pictureBox1.Image = null;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            NewX = e.X;
            NewY = e.Y;
        }

        private void button7_Click(object sender, EventArgs e)
            {
            colorDialog1.Color = button7.BackColor; // устанавливаем цвет фишки в диалоге выбора цвета
           
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color; // устанавливаем выбранный цвет на кнопку
               // mLineColor = ColorDialog1.Color;
               // currentColor = colorDialog1.Color;
              /*  Pen pen;
                pen.Color = colorDialog1.Color;*/
                

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = button16.BackColor; // устанавливаем цвет фишки в диалоге выбора цвета

            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color; // устанавливаем выбранный цвет на кнопку
               /* Brush brush;
                brush.Color = colorDialog1.Color;*/
            }








            /*  private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
              {
                  PreparePicture();
                  Pen blackPen = new Pen(currentColor, 1);

            
                  Graphics g = Graphics.FromImage(pictureBox1.Image);

                  g.DrawLine(blackPen, PreviousPoint, point);

                  blackPen.Dispose();
                  g.Dispose();

                  pictureBox1.Invalidate();
                  FinalizePicture();
          }*/


        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            Pen currentPen = new Pen(colorDialog1.Color);


            if (Drag == true)
            {
                g.DrawLine(currentPen, oldX, oldY, e.X, e.Y);
                oldX = e.X;
                oldY = e.Y;
            }
            oldX = e.X;
            oldY = e.Y;

           

           
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Drag = false;
            pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Поле чистое!!!", "WARNING!!!");
            }

            else
            {
                pictureBox1.Image = imgPicture;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Поле чистое!!!", "WARNING!!!");
            }

            else
            {
                pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                
                pictureBox1.Refresh();
                //pictureBox1.Image.Save(@"C:\\FlipY.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
               /* Graphics g = this.CreateGraphics();
                g.Clear(this.BackColor);
                pictureBox1.Image = imgPicture;
                g.DrawImage(imgPicture, 0, 0, 200, 200);

                Matrix X = new Matrix();
                X.Rotate(50);
                g.Transform = X;
                // Draw image
                g.DrawImage(imgPicture,
                new Rectangle(205, 0, 200, 200),
                0, 0, imgPicture.Width,
                imgPicture.Height,
                GraphicsUnit.Pixel);
                // Dispose of objects
                imgPicture.Dispose();
                g.Dispose(); */
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Поле чистое!!!", "WARNING!!!");
            }

            else
            {
                
                pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBox1.Refresh();
               
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Поле чистое!!!", "WARNING!!!");
            }

            else
            {
                
                pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                pictureBox1.Refresh();
                
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Поле чистое!!!", "WARNING!!!");
            }

            else
            {
                pictureBox1.Image = imgPicture;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Поле чистое!!!", "WARNING!!!");
            }

            else
            {
                pictureBox1.Image = null;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Для начала выберите картинку", "Ошибка!!!");
            }

            else
            {
                PreparePicture();
                cmPicture = new System.Drawing.Imaging.ColorMatrix(new float[][]
            {
                new float[]{0.3f, 0.3f, 0.3f, 0, 0},
                new float[]{0.59f, 0.59f, 0.59f, 0, 0},
                new float[]{0.11f, 0.11f, 0.11f, 0, 0},
                new float[]{0, 0, 0, 1, 0, 0},
                new float[]{0, 0, 0, 0, 1, 0},
               
            });
                FinalizePicture();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Для начала выберите картинку", "Ошибка!!!");
            }

            else
            {
                PreparePicture();
                cmPicture = new System.Drawing.Imaging.ColorMatrix(new float[][]
            {
                new float[]{-1, 0, 0, 0, 0},
                new float[]{0, -1, 0, 0, 0},
                new float[]{0, 0, -1, 0, 0},
                new float[]{0, 0, 0, 1, 0},
                new float[]{1, 1, 1, 1, 1},               
            });
                FinalizePicture();

            }

        }

        private void зеркалоПоYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Поле чистое!!!", "WARNING!!!");
            }

            else
            {
                
                pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                pictureBox1.Refresh();
                
            }

        }

        private void зеркалоПоХToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Поле чистое!!!", "WARNING!!!");
            }

            else
            {
               
                pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBox1.Refresh();
                
            }
        }


}
    
}
