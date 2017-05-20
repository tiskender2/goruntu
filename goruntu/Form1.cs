using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace goruntu
{
    public partial class Form1 : Form
    {
        int[] kirmizi;
        int[] yesil;
        int[] mavi;
        PictureBox picturebox3;
        PictureBox picturebox2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public static Bitmap SiyahBeyaz(Bitmap resim)
        {
            for (int i = 0; i < resim.Width; i++)
            {
                for (int j = 0; j < resim.Height; j++)
                {
                    int rgb = (resim.GetPixel(i, j).R + resim.GetPixel(i, j).G + resim.GetPixel(i, j).B) /3;
                    resim.SetPixel(i, j, Color.FromArgb(rgb, rgb, rgb));
                }
            }
            return resim;
        }

        public static Bitmap Kabartma(Bitmap resim)
        {

            Color renk1, renk2, renk3;
            int r, g, b;
            for (int i = 0; i < resim.Width-2; i++)
            {
                for (int j = 0; j < resim.Height-2; j++)
                {
                    renk1 = resim.GetPixel(i, j);
                    renk2 = resim.GetPixel(i + 1, j + 1);
                    r = Math.Abs((int)(renk1.R) - renk2.R) + 128;
                    if (r > 255)
                        r = 255;
                    g = Math.Abs((int)(renk1.G) - renk2.G) + 128;
                    if (g > 255)
                        g = 255;
                    b = Math.Abs((int)(renk1.B) - renk2.B) + 128;
                    if (b > 255)
                        b = 255;
                    renk3 = Color.FromArgb(r, g, b);
                    resim.SetPixel(i, j, renk3);
                    
                }

            }
            return resim;


        }
        public static Bitmap Negatif(Bitmap resim)
        {
     
          
                int i, j;
                Color r;
            
              
                for (i = 0; i <= resim.Width - 1; i++)
                {
                    for (j = 0; j <= resim.Height - 1; j++)
                    {
                        r = resim.GetPixel(i, j);
                        r = Color.FromArgb(r.A, (byte)~r.R, (byte)~r.G, (byte)~r.B);
                        resim.SetPixel(i, j, r);
                       
                    }
            }
            return resim;



        }
        public static Bitmap TersCevir(Bitmap resim)
        {
            Color r,t,p;
            for (int i = 0; i < resim.Width; i++)
            {
                for (int j = 0; j < resim.Height/2; j++)
                {
                    r = resim.GetPixel(i, j);
                    
                    p=resim.GetPixel( i, (resim.Height - 1) - j);
                    resim.SetPixel(i,j,p);
                    resim.SetPixel(  i, (resim.Height - 1)-j,r);
                    
                   

                }
            }

            return resim;
        }
        public static Bitmap Aynala(Bitmap resim)
        {
            Color r, t, p;
            for (int i = 0; i < resim.Width/2; i++)
            {
                for (int j = 0; j < resim.Height ; j++)
                {
                    r = resim.GetPixel(i, j);
                    t = r;
                    p = resim.GetPixel((resim.Width - 1)-i,  j);
                    resim.SetPixel(i, j, p);
                    resim.SetPixel((resim.Width - 1)-i,   j, t);



                }
            }

            return resim;
        }
        public static Bitmap Shift(Bitmap resim)
        {
            Color r, t, p;
            Bitmap kopya = new Bitmap(resim.Width,resim.Height);
            for (int i = 0; i < resim.Width; i++)
            {
                for (int j = 0; j < resim.Height; j++)
                {


                    r = resim.GetPixel(i, j);
                  
                    if ((i + 100 < resim.Width) && (j + 100 < resim.Height))
                    {
                        p = resim.GetPixel(i + 100, j + 100);
                      
                        kopya.SetPixel(i + 100, j + 100, r);
                    }
                    
                    


                }
            }

            return kopya;
        }
        public static Bitmap Yakınlastırma(Bitmap resim)
        {
            Bitmap yeni = new Bitmap(resim.Width * 2, resim.Height * 2);
            int x=0,y=0;
            for (int i = 0; i < resim.Width*2; i+=2)
            {
                for (int j = 0; j < resim.Height*2; j+=2)
                {
                    if ((i+1)<yeni.Width && (j+1)<yeni.Height)
                    {
                        yeni.SetPixel(i, j, resim.GetPixel(x, y));
                        yeni.SetPixel(i, j+1, resim.GetPixel(x, y));
                        yeni.SetPixel(i+1, j, resim.GetPixel(x, y));
                        yeni.SetPixel(i+1, j+1, resim.GetPixel(x, y));
                    }
                    y++;
                }
                x++;
                y = 0;
            }

             return yeni;
        }
        public static Bitmap Uzaklastirma(Bitmap resim)
        {
            Bitmap yeni = new Bitmap(resim.Width / 2, resim.Height / 2);
            int x = 0, y = 0;
            
            int a, b, c;
            for (int i = 0; i < yeni.Width; i++)
            {
                for (int j = 0; j <yeni.Height; j++)
                {
                    a = (resim.GetPixel(x, y).R + resim.GetPixel(x, y+1).R + resim.GetPixel(x + 1, y ).R + resim.GetPixel(x + 1, y+1).R) / 4;
                    b = (resim.GetPixel(x, y).G + resim.GetPixel(x, y+1).G + resim.GetPixel(x + 1, y ).G + resim.GetPixel(x + 1, y+1).G) / 4;
                    c = (resim.GetPixel(x, y).B + resim.GetPixel(x, y+1).B + resim.GetPixel(x + 1, y ).B + resim.GetPixel(x + 1, y+1).B) / 4;

                 
                    yeni.SetPixel(i,j,Color.FromArgb(a,b,c));
                    y+=2;
                }
                x+=2;
                y = 0;
            }
            
            return yeni;
        }

        public static Bitmap ParlaklıkArttır(Bitmap resim)
        {
            Color r;
            int R,G,B;
            for (int i = 0; i < resim.Width; i++)
            {
                for (int j = 0; j < resim.Height; j++)
                {
                    R = (resim.GetPixel(i, j).R + 50);
                    G = (resim.GetPixel(i, j).G + 50);
                    B = (resim.GetPixel(i, j).B + 50);
                    if (R>255)
                    {
                        R = 255;
                    }
                    if (G > 255)
                    {
                        G = 255;
                    }
                    if (B > 255)
                    {
                        B = 255;
                    }

                    resim.SetPixel(i, j, Color.FromArgb(R, G, B));

                }
            }


            return resim;
        }

        public static Bitmap ParlaklıkAzalt(Bitmap resim)
        {
            Color r;
            int R, G, B;
            for (int i = 0; i < resim.Width; i++)
            {
                for (int j = 0; j < resim.Height; j++)
                {
                    R = (resim.GetPixel(i, j).R - 50);
                    G = (resim.GetPixel(i, j).G - 50);
                    B = (resim.GetPixel(i, j).B - 50);
                    if (R < 0)
                    {
                        R = 0;
                    }
                    if (G < 0)
                    {
                        G = 0;
                    }
                    if (B < 0)
                    {
                        B = 0;
                    }

                    resim.SetPixel(i, j, Color.FromArgb(R, G, B));

                }
            }


            return resim;
        }
        public static Bitmap KontrastArttır(Bitmap resim)
        {
            Color r;
            int R, G, B;
            for (int i = 0; i < resim.Width; i++)
            {
                for (int j = 0; j < resim.Height; j++)
                {
                    R = (resim.GetPixel(i, j).R * 2);
                    G = (resim.GetPixel(i, j).G * 2);
                    B = (resim.GetPixel(i, j).B * 2);
                    if (R > 255)
                    {
                        R = 255;
                    }
                    if (G > 255)
                    {
                        G = 255;
                    }
                    if (B > 255)
                    {
                        B = 255;
                    }

                    resim.SetPixel(i, j, Color.FromArgb(R, G, B));

                }
            }


            return resim;
        }
        public static Bitmap KontrastAzalt(Bitmap resim)
        {
            Color r;
            int R, G, B;
            for (int i = 0; i < resim.Width; i++)
            {
                for (int j = 0; j < resim.Height; j++)
                {
                    R = (resim.GetPixel(i, j).R * (-1));
                    G = (resim.GetPixel(i, j).G * (-1));
                    B = (resim.GetPixel(i, j).B * (-1));
                    if (R < 0 )
                    {
                        R = 80;
                    }
                    if (G < 0)
                    {
                        G = 90;
                    }
                    if (B < 0)
                    {
                        B = 100;
                    }
                    

                    resim.SetPixel(i, j, Color.FromArgb(R, G, B));

                }
            }


            return resim;
        }

        public  Bitmap HistogramCıkar(Bitmap resim)
        {
            kirmizi = new int[256];
            yesil = new int[256];
            mavi = new int[256];
            this.Histogram.Series["Kırmızı"].Points.Clear();
            this.Histogram.Series["Yeşil"].Points.Clear();
            this.Histogram.Series["Mavi"].Points.Clear();





            for (int i = 0; i < resim.Width; i++)
            {
                for (int j = 0; j < resim.Height; j++)
                {
                    Color renk = resim.GetPixel(i, j);

                    kirmizi[renk.R]++;
                    yesil[renk.G]++;
                    mavi[renk.B]++;
                 
                  
                }
            }
              for (int t = 1; t < 255; t++)
            {

                        this.Histogram.Series["Kırmızı"].Points.AddXY(t, kirmizi[t]);
                        this.Histogram.Series["Yeşil"].Points.AddXY(t, yesil[t]);
                        this.Histogram.Series["Mavi"].Points.AddXY(t, mavi[t]);
                    }
              
            return resim;
        }
        public Bitmap Suzgec(Bitmap resim)
        {
            Random rnd = new Random();
            int[,] suzgec = new int[resim.Width, resim.Height];

            for (int m = 0; m <suzgec.GetLength(0); m++)
            {
                for (int n = 0; n < suzgec.GetLength(1); n++)
                {
                    suzgec[m,n] = rnd.Next(1, 10);
                }
            }


            for (int i = 0; i < resim.Width; i++)
            {
                for (int j = 0; j < resim.Height; j++)
                {
                    Color renk = resim.GetPixel(i, j);



                }
            }
            for (int k = 0; k < resim.Width; k++)
            {
                for (int t = 0; t < resim.Height; t++)
                {
                    
                }
            }

            return resim;
        }
        public Bitmap Tresholding(Bitmap resim,int T)
        {
            int R, G, B;
           
            for (int i = 0; i < resim.Width; i++)
            {
                for (int j = 0; j < resim.Height; j++)
                {
                    R = (resim.GetPixel(i, j).R );
                    G = (resim.GetPixel(i, j).G );
                    B = (resim.GetPixel(i, j).B );
                    int gri = (R + G + B) / 3;

                    if (gri < T)
                    {
                      gri = 0;
                    }
                    else
                    {
                        gri = 255;
                    }
                    resim.SetPixel(i, j, Color.FromArgb(gri, gri, gri));
                }
            }




            return resim;
        }
        public Bitmap picture(Bitmap resim)
        {
            this.Controls.Remove(pictureBox2);
            this.Controls.Remove(picturebox2);
            this.Controls.Remove(picturebox3);
            picturebox3 = new PictureBox();
            this.Controls.Add(picturebox3);
            picturebox3.SetBounds(773,53,474,402);
            picturebox3.Image = resim;
            return resim;
        }
        public Bitmap picture2(Bitmap resim)
        {

           
            this.Controls.Remove(picturebox3);
            this.Controls.Remove(pictureBox2);
            this.Controls.Remove(picturebox2);

            picturebox2 = new PictureBox();
            this.Controls.Add(picturebox2);
            this.picturebox2.SizeMode = PictureBoxSizeMode.StretchImage;
            picturebox2.SetBounds(773, 53, 474, 402);

            picturebox2.Image = resim;
           
            return resim;
        }


        private void button1_Click(object sender, EventArgs e)
        {

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Seçiniz";
            openFileDialog1.Filter = "Text files (*.jpg)|*.*|Tüm dosyalar (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.OpenFile());
                Histogram.Visible = true;
                HistogramCıkar(new Bitmap(openFileDialog1.OpenFile()));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void aSAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            Bitmap bmp = new Bitmap((Bitmap)pictureBox1.Image);
            bmp = SiyahBeyaz(bmp);
            HistogramCıkar(bmp);
            picture2(bmp);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            Bitmap bmp = new Bitmap((Bitmap)pictureBox1.Image);
            bmp = Kabartma(bmp);
            HistogramCıkar(bmp);
            picture2(bmp);
        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            Bitmap bmp = new Bitmap((Bitmap)pictureBox1.Image);
            bmp = Negatif(bmp);
            HistogramCıkar(bmp);
            picture2(bmp);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            Bitmap bmp = new Bitmap((Bitmap)pictureBox1.Image);
            bmp = TersCevir(bmp);

            picture2(bmp);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            Bitmap bmp = new Bitmap((Bitmap)pictureBox1.Image);
            bmp = Aynala(bmp);

            picture2(bmp);
        }

        private void shiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            Bitmap bmp = new Bitmap((Bitmap)pictureBox1.Image);
            bmp = Shift(bmp);
            picture2(bmp);
        }

        private void closeupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            Bitmap bmp= new Bitmap((Bitmap)pictureBox1.Image);
            bmp = Yakınlastırma(bmp);
            picture(bmp);

        }

        private void removalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            Bitmap bmp = new Bitmap((Bitmap)pictureBox1.Image);
            bmp = Uzaklastirma(bmp);
            picture(bmp);
            
           
        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            Bitmap bmp = new Bitmap((Bitmap)pictureBox1.Image);
            bmp = ParlaklıkArttır(bmp);
            picture2(bmp);
        }

        private void brightnessToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            Bitmap bmp = new Bitmap((Bitmap)pictureBox1.Image);
            bmp = ParlaklıkAzalt(bmp);
            picture2(bmp);

        }

        private void kontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            Bitmap bmp = new Bitmap((Bitmap)pictureBox1.Image);
            bmp = KontrastArttır(bmp);
            picture2(bmp);
        }

        private void kontrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
              pictureBox2.Image = null;
            Bitmap bmp = new Bitmap((Bitmap)pictureBox1.Image);
            bmp = KontrastAzalt(bmp);
            picture2(bmp);
        }

     

        private void tresholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void butonTresh_Click(object sender, EventArgs e)
        {
            int Tresh=Convert.ToInt32(kopekTresh.Text);

            pictureBox2.Image = null;
            Bitmap bmp = new Bitmap((Bitmap)pictureBox1.Image);
            bmp = Tresholding(bmp, Tresh);
            picture2(bmp);
        }
    }
}
