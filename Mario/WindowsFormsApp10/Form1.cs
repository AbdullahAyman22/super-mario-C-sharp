using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    class Crecs
    {
        public int x, y;
        public int w, h;
        public Color clr;
        //public List<CPengActor> LMine = new List<CPengActor>();
        public Brush brush;

    }

    class Cimg
    {
        public Rectangle rcDst;
        public Rectangle rcSrc;
        public int x, y;
        public Bitmap img;
        public List<Bitmap> im = new List<Bitmap>();
        public int iframe = 0;
        public bool d=false;
        public bool d2 = false;
        public bool d3 = false;
        public bool dd = false;
        public bool dd2 = false;
        public bool aa = false;
        public bool ww = false;
    }
    public partial class Form1 : Form
    {
        Bitmap off;
        List<Cimg> Lground = new List<Cimg>();
        List<Cimg> Lm4ground = new List<Cimg>();
        List<Cimg> Lobst = new List<Cimg>();
        List<Cimg> Lmario = new List<Cimg>();
        List<Cimg> Lbird = new List<Cimg>();
        List<Cimg> Lsword = new List<Cimg>();
        List<Cimg> Lworld = new List<Cimg>();
        List<Cimg> Lladd = new List<Cimg>();
        List<Cimg> Lbullet = new List<Cimg>();
        List<Cimg> Lmoraba3 = new List<Cimg>();
        List<Crecs> Llaser = new List<Crecs>();
        Timer t = new Timer();
        
        int a = 0;
        int xx=0;
        int ct=0;
        int ct2 = 0;
        int ct3 = 0;
        int ct4 = 0;
        int ct5 = 0;
        int flg = 0;
        int flg2 = 0;
        int flg3=0;
        int flg5 = 0;
        int x1 = 0;
        int ct6 = 1;
        bool de = true;
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            //this.Paint += new PaintEventHandler(Form1_Paint);
            this.Load += new EventHandler(Form1_Load);
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 1;
            t.Start();
           
        }
        int Hit2(int XM, int YM, List<Cimg> L)
        {
            for (int i = 0; i < L.Count; i++)
            {
                int xs = L[i].x;
                int xe = L[i].x + L[i].im[0].Width;
                int ys = L[i].y;
                int ye = L[i].y + L[i].im[0].Height;
                if (XM >= xs && XM <= xe && YM >= ys && YM <= ye)
                {
                    return i;
                }
            }
            return -1;
        }
        void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Llaser.Clear();
            //DrawDubb(this.CreateGraphics());
        }
        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (xx + 15 > (Lworld[0].img.Width - ClientSize.Width))
                {
                    createlaser(e.X, e.Y);
                    int iss3 = Hit2(e.X, e.Y,Lbird);
                    int iss4 = Hit2(e.X, e.Y, Lsword);
                    if (iss3 != -1)
                    {
                        Lbird.Clear();
                        Lbullet.Clear();
                        x1 += 100;
                    }
                    if (iss4 != -1)
                    {
                        Lsword.RemoveAt(iss4);
                        x1 += 1000;
                    }
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //MessageBox.Show("X: "+e.X+" , " +"Y: "+e.Y);
                int issss=Hit2(e.X, e.Y,Lground);
                MessageBox.Show(issss + "");
            }

            //DrawDubb(this.CreateGraphics());
        }
        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < Llaser.Count; i++)
            {
                Llaser[i].w = e.X;
                Llaser[i].h = e.Y;
            }
            //DrawDubb(this.CreateGraphics());

        }
        void alternatejumpframes()
        {
            if (Lmario[0].iframe < 2)
            {
                Lmario[0].iframe = 2;
            }

            if (Lmario[0].iframe > 3 && Lmario[0].iframe < 6)
            {
                Lmario[0].iframe = 6;
            }
        }
        void jump2()
        {
             if (Lmario[0].d == true && Lmario[0].d2 == false)
            {


                alternatejumpframes();

                Lmario[0].y -= 50;
                ct++;
            }

            if (Lmario[0].d2 == true)
            {
                alternatejumpframes();

                Lmario[0].y += 50;
                ct2++;
            }
            if (ct == 4)
            {
                if (Lmario[0].dd == true|| Lmario[0].dd2 == true)
                {
                    if (Lmario[0].x < this.ClientSize.Width / 2)
                    {
                        Lmario[0].x += 35;
                    }
                    else
                    {
                        for (int i = 0; i < Lground.Count; i++)
                        {
                            Lground[i].x -= 35;
                        }
                        Lladd[0].x -= 35;
                        Lladd[1].x -= 35;
                        for (int j = 0; j < Lmoraba3.Count; j++)
                        {
                            Lmoraba3[j].x -= 35;
                        }
                    }
                }
                if (Lmario[0].aa == true)
                {
                    if (Lmario[0].x < this.ClientSize.Width / 2)
                    {
                        Lmario[0].x -= 35;
                    }
                  
                }
                ct = 0;
                Lmario[0].d = false;
                Lmario[0].d2 = true;
            }

            for (int i = 0; i < Lground.Count; i++)
            {


                if (Lmario[0].y == Lground[i].y - 32)
                {
                    if (Lmario[0].x <= Lground[i].x + 200 && Lmario[0].x+32  >= Lground[i].x)
                    {
                        {
                            ct2 = 0;
                            if (Lmario[0].iframe == 2)
                            {
                                Lmario[0].iframe = 0;
                            }
                            if (Lmario[0].iframe == 6)
                            {
                                Lmario[0].iframe = 4;
                            }
                            Lmario[0].d2 = false;
                            //Lmario[0].d3 = true;
                            break;
                        }
                    }
                }
            }
        }
        //void jump()
        //{
        //    if (Lmario[0].d == true && Lmario[0].d2 == false)
        //    {


        //        alternatejumpframes();

        //        Lmario[0].y -= 50;
        //        ct++;
        //    }

        //    if (Lmario[0].d2 == true)
        //    {
        //        alternatejumpframes();
               
        //        Lmario[0].y += 50;
        //        ct2++;
        //    }
        //    if (ct == 4)
        //    {
        //        if (Lmario[0].dd == true)
        //        {
        //            if (Lmario[0].x < this.ClientSize.Width / 2)
        //            {
        //                Lmario[0].x += 35;
        //            }
        //            else
        //            {
        //                for (int i = 0; i < Lground.Count; i++)
        //                {
        //                    Lground[i].x -= 35;
        //                }
        //            }
        //        }
        //        if (Lmario[0].aa == true)
        //        {
        //            if (Lmario[0].x < this.ClientSize.Width / 2)
        //            {
        //                Lmario[0].x -= 35;
        //            }
                  
        //        }
        //        ct = 0;
        //        Lmario[0].d = false;
        //        Lmario[0].d2 = true;
        //    }
        //    if (ct2 >= 4)
        //    {
        //        ct2 = 0;
        //        if (Lmario[0].iframe == 2)
        //        {
        //            Lmario[0].iframe = 0;
        //        }
        //        if (Lmario[0].iframe== 6)
        //        {
        //            Lmario[0].iframe = 4;
        //        }
        //        Lmario[0].d2 = false;
        //    }
        //}
        void moveright()
        {
            for (int i = 0; i < Lm4ground.Count; i++)
            {
                if (Lmario[0].x + 35 >= Lm4ground[i].x&&Lmario[0].dd == true&&Lmario[0].y+16 >= Lm4ground[i].y&&Lmario[0].x<Lm4ground[0].x+200)
                {
                     Lmario[0].dd =false;
                    Lmario[0].dd2 = true;
                }
                else if(Lmario[0].y + 16 <= Lm4ground[i].y&& Lmario[0].dd2 == true)
                {
                    Lmario[0].dd = true;
                    Lmario[0].dd2 = false;
                }
              
               
            }
            if (Lmario[0].dd == true|| Lmario[0].dd2 == true)
            {
                
                if (Lmario[0].iframe != 1)
                {
                    Lmario[0].iframe = 1;
                    flg2 = 1;
                }
                if (Lmario[0].iframe == 1 && flg2 == 0)
                {
                    Lmario[0].iframe = 0;
                }
                flg2 = 0;
            }
            if (Lmario[0].dd == true)
            {
               
                if (Lmario[0].x < this.ClientSize.Width / 2|| xx + 15 > (Lworld[0].img.Width - ClientSize.Width))
                {
                    
                    Lmario[0].x += 25;
                }
                else
                {
                    for (int i = 0; i < Lground.Count; i++)
                    {
                        Lground[i].x -= 25;
                     
                    }
                    if (xx + 15 <= (Lworld[0].img.Width - ClientSize.Width))
                    {
                        xx += 15;
                    }

                    Lladd[0].x -= 25;
                    Lladd[1].x -= 25;
                    //for (int j = 0; j < Lbullet.Count; j++)
                    //{
                    //    Lbullet[j].x -= 25;
                    //}
                    for (int j = 0; j < Lmoraba3.Count; j++)
                    {
                        Lmoraba3[j].x -= 25;
                    }
                }
                //flg2 = 0;
            }
            //gravity();
        }
        void gravity()
        {

            for (int i = 0; i < Lground.Count; i++)
            {
                if (i != 5 && i != 6 && i != 7)
                {


                    if (Lmario[0].x+32 <= Lground[i].x + 200 && Lmario[0].x >= Lground[i].x)
                    {
                        if (Lmario[0].y < Lground[i].y - 32)
                        {
                            if (Lmario[0].d == false && Lmario[0].d2 == false&& Lmario[0].ww==false)
                            {
                                Lmario[0].d2 = true;
                            }
                        }
                    }
                }
            }


            for (int i = 0; i < Lobst.Count; i++)
            {
                if (Lmario[0].x+25 < Lobst[i].x + 65  && Lmario[0].x >= Lobst[i].x && Lmario[0].y > this.ClientSize.Height - 133)
                {
                    Lmario[0].y += 50;

                    Lmario[0].iframe = 3;
                   // DrawDubb(this.CreateGraphics());
                    de = false;
                }
            }

            if(Lmario[0].y> this.ClientSize.Height - 132)
            {
                Lmario[0].iframe = 3;
                de = false;
            }
            //}
        }
        void moveleft()
        {
            if (Lmario[0].aa == true)
            {
                if (Lmario[0].iframe != 5)
                {
                    Lmario[0].iframe = 5;
                    flg = 1;
                }
                if (Lmario[0].iframe == 5 && flg == 0)
                {
                    Lmario[0].iframe = 4;
                }
                    Lmario[0].x -= 25;          
                flg = 0;

            }
        }
        void climbladder()
        {
            Lmario[0].y-= 50;
            Lmario[0].iframe =7;
        }
        void laserfollowmario()
        {
            if (Llaser.Count > 0)
            {
                for (int i = 0; i < Llaser.Count; i++)
                {
                    Llaser[i].x = Lmario[0].x + 15;
                    Llaser[i].y = Lmario[0].y + 13;
                }
            }
        }

        void flyingbird()
        {

            if (Lbird[0].x  > 0&&flg3==0)
            {
                Lbird[0].x -= 25;
                if (Lbird[0].iframe < 13)
                {
                    Lbird[0].iframe++;
                }
                else
                {
                    Lbird[0].iframe = 0; 
                }
                //if (Lsword[0].iframe < 3)
                //{
                //    Lsword[0].iframe++;
                //}
                //else
                //{
                //    Lsword[0].iframe = 0;
                //}
            }
            else
            {
                if (Lbird[0].x <= 0)
                {
                    flg3 = 1;
                    Lbird[0].iframe = 14;
                }
            }
            if(Lbird[0].x < 1819 && flg3 == 1)
            {
                //flg3 = 1;
                Lbird[0].x += 25;
                if (Lbird[0].iframe < 27)
                {
                    Lbird[0].iframe++;
                }
                else
                {
                    Lbird[0].iframe = 14;
                }

            }
            else
            {
                if (Lbird[0].x+100 >= 1919)
                {
                    flg3 = 0;
                    Lbird[0].iframe = 0;
                }
            }
        }
        void moveeggs()
        {
            int flgg = 0;
            for (int i = 0; i < Lbullet.Count; i++)
            {
                if (i % 2 == 0 && flgg == 0)
                {
                    flgg = 1;
                    Lbullet[i].x -= 25;
                    Lbullet[i].y += 25;
                }
                if (i % 2 == 1)
                {
                    Lbullet[i].y += 25;
                }
                if (i % 2 == 0 && flgg == 1)
                {
                    flgg = 0;
                    Lbullet[i].x += 25;
                    Lbullet[i].y += 25;
                }
            }
        }
        void t_Tick(object sender, EventArgs e)
        {
            //gravity();
            //gravity();
            if (de == true)
            {
                moveright();
                moveleft();
                ModifyRects();



                jump2();
                gravity();
                //creatbirdenemy();
                if (Lbird.Count > 0)
                    {
                    Lbird[0].x++;
                    flyingbird();
                }
                if (ct3 % 5 == 0)
                {
                    if (Lbird.Count > 0)
                    {
                        createbirdbullett();
                    }
                }
                ct3++;

                moveeggs();
              

                laserfollowmario();

                int iss = Hit(Lladd);
                if (iss != -1)
                {
                    if (Lmario[0].ww)
                    {
                        climbladder();
                    }
                }
                int iss2 = Hit(Lmoraba3);
                if (iss2 != -1)
                {
                    Lmoraba3[iss2].iframe = 1;
                    x1 += 10;
                }
                if(xx + 15 > (Lworld[0].img.Width - ClientSize.Width))
                {
                    if(ct4%15==0)
                    {
                        creatswordenemy();
                    }
                    ct4++;
                    for(int i = 0; i < Lsword.Count; i++)
                    {
                        Lsword[i].x += 5;
                        if (Lsword[i].iframe < 3)
                        {
                            Lsword[i].iframe++;
                        }
                        else
                        {
                            Lsword[i].iframe=0;
                        }
                    }
                   
                }
                int is5=Hit3(Lbullet);
                if(is5 != -1)
                {
                    Lmario[0].iframe = 3;
                    de = false;
                }
                if (ct6 % 20 == 0)
                {
                    if (flg5 == 0)
                    {
                        Lground[27].y -= 50;
                        if (Lmario[0].x <= Lground[27].x + 200&& Lmario[0].x >= Lground[27].x )
                        {
                            Lmario[0].y -= 50;
                        }
                    }
                    else
                    {
                        Lground[27].y += 50;
                    }

                    ct5++;
                    if (ct5 == 3)
                    {
                        if (flg5 == 0)
                        {
                            flg5 = 1;
                        }
                        else
                        {
                            flg5 = 0;
                        }
                        ct5 = 0;
                    }
                }
                ct6++;
                int him = Hit3(Lsword);
                if (him != -1)
                {
                    Lmario[0].iframe = 3;
                    de = false;
                }

                if (x1>20000)
                {
                    de = false;
                    MessageBox.Show("you win");
                }
                DrawDubb(this.CreateGraphics());
            }
            //else
            //{
            //    Lmario.Clear();
            //    Lground.Clear();
            //    Lladd.Clear();
            //    Lmoraba3.Clear();
            //    createground();
            //    createmario();
            //    createladd();
            //    createfloos();
            //    xx=0;
            //    de = true;
            //}
          

            //else
            //{
            //    if (ct5 % 100 == 0)
            //    {
            //        Form1 f1 = new Form1();
            //        de = true;
            //        f1.Show();
            //        this.Close();

            //       // de = true;
            //        ct5 = 1;
            //    }
            //    ct5++;
            //}

        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
            switch (e.KeyCode)
            {
              
                case Keys.D:

                    Lmario[0].dd = true;
                    break;
             
                case Keys.A:
                    Lmario[0].aa = true;
                    break;
                case Keys.Space:
                    
                    Lmario[0].d = true;
                    break;
                case Keys.F:

                    //if (Lbird[0].iframe < 27)
                    //{
                    //    Lbird[0].iframe++;
                    //}
                    //else
                    //{
                    //    Lbird[0].iframe = 0; ;
                    //}
                    if (Lsword[0].iframe < 3)
                    {
                        Lsword[0].iframe++;
                    }
                    else
                    {
                        Lsword[0].iframe = 0;
                    }
                    break;
                case Keys.W:
                    Lmario[0].ww = true;
                    break;
            }
            
        }
        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.D)
            {
                Lmario[0].dd =false;
                Lmario[0].dd2 = false;
                Lmario[0].iframe = 0;
            }
            if (e.KeyCode == Keys.A)
            {
                Lmario[0].aa = false;
                Lmario[0].iframe = 4;
            }
            if (e.KeyCode == Keys.W)
            {
                Lmario[0].ww = false;
                //Lmario[0].iframe = 4;
            }

        }
        void createground()
        {
            Cimg pnn;
            int a = 0;
            for (int i = 0; i < 500; i++)
            {
                if(i==5|| i == 6|| i == 7)
                {
                    pnn = new Cimg();
                    pnn.x = a;
                    pnn.y = this.ClientSize.Height - 48;
                    pnn.im.Add(new Bitmap("pix.png"));
                    pnn.im[0].MakeTransparent(pnn.im[0].GetPixel(0, 0));
                    a += 65;
                    Lobst.Add(pnn);
                }
                else if(i==10)
                {
                    pnn = new Cimg();
                    pnn.x = a;
                    pnn.y = this.ClientSize.Height - 200;
                    pnn.im.Add(new Bitmap("elements1.png"));
                   // pnn.im[0].MakeTransparent(pnn.im[0].GetPixel(0, 0));
                    a += 200;
                    Lm4ground.Add(pnn);

                }
                else
                {
                pnn = new Cimg();
                pnn.x = a;
                pnn.y = this.ClientSize.Height -100;
                //if (i == 100)
                //{
                //    pnn.im.Add(new Bitmap("mario4.png"));
                //}
               
                    pnn.im.Add(new Bitmap("elements1.png"));
                    a += 200;
                    
                }
                Lground.Add(pnn);


            }
        }
        void createmario()
        {
            Cimg pnn;
            int a = 0;

            pnn = new Cimg();
            pnn.x = a;
            pnn.y = this.ClientSize.Height - 132;

            for (int i = 0; i < 8; i++)
            {
                pnn.im.Add(new Bitmap("mario" + (i + 1) + ".png"));
                //pnn.im[i].MakeTransparent(pnn.im[i].GetPixel(0, 0));
            }
            a += 32;
            Lmario.Add(pnn);

        }
        void creatbirdenemy()
        {
            Cimg pnn;
            int a = 0;

            pnn = new Cimg();
            pnn.x = 500;
            pnn.y = 100;

            for (int i = 0; i < 28; i++)
            {
                pnn.im.Add(new Bitmap((i + 11) + ".png"));
                pnn.im[i].MakeTransparent(pnn.im[i].GetPixel(0, 0));
            }
            //a += 32;
            Lbird.Add(pnn);
        }
        void createbirdbullett()
        {
            Cimg pnn;
            int a = 0;

            pnn = new Cimg();
            pnn.x = Lbird[0].x+50;
            pnn.y = Lbird[0].y+80;

         
                pnn.im.Add(new Bitmap("e1.bmp"));
                pnn.im[0].MakeTransparent(pnn.im[0].GetPixel(0, 0));
            
            //a += 32;
            Lbullet.Add(pnn);
        }
        void creatswordenemy()
        {
            Cimg pnn;
            int a = 0;

            pnn = new Cimg();
            pnn.x = 0;
            pnn.y = this.ClientSize.Height - 100-264;

            for (int i = 0; i < 4; i++)
            {
                pnn.im.Add(new Bitmap("oo"+(i + 1) + ".png"));
                pnn.im[i].MakeTransparent(pnn.im[i].GetPixel(0, 0));
            }
            //a += 32;
            Lsword.Add(pnn);
        }
        void createladd()
        {
            Cimg pnn;
            int a = this.ClientSize.Height - 200 - 150;
            for (int i = 0; i < 2; i++)
            {
                pnn = new Cimg();
                pnn.x = 1660;
                pnn.y = a;


                pnn.im.Add(new Bitmap("ladd.png"));
                pnn.im[0].MakeTransparent(pnn.im[0].GetPixel(0, 0));

                a -= pnn.im[0].Height;
                Lladd.Add(pnn);
            }
        }
        void createlaser(int XM, int YM)
        {
            Crecs pnn;
            int a = 0;

            pnn = new Crecs();
            pnn.x = Lmario[0].x+15;
            pnn.y = Lmario[0].y+13;
            pnn.w = XM;
            pnn.h = YM;

            a += 32;
            Llaser.Add(pnn);

        }
        void createscore()
        {

        }
        void createfloos()
        {

            Cimg pnn;
            int a = 50;
            for (int i = 0; i < 100; i++)
            {

                for (int k = 0; k < 5; k++)
                {
                    pnn = new Cimg();
                    pnn.x = a;
                    pnn.y = this.ClientSize.Height - 350;

                    for (int j = 0; j < 2; j++)
                    {
                        pnn.im.Add(new Bitmap("element" + (j + 1) + ".png"));
                        pnn.im[0].MakeTransparent(pnn.im[0].GetPixel(0, 0));
                    }

                    a += 32;
                    Lmoraba3.Add(pnn);
                    
                }
                a += 300;
            }
        }
        int Hit(List<Cimg> L)
        {
            int XM=Lmario[0].x+5;
            int YM=Lmario[0].y;
            int XM1 = Lmario[0].x+32;
           // int YM1 = Lmario[0].y;
            for (int i = 0; i < L.Count; i++)
            {
                int xs = L[i].x;
                int xe = L[i].x + L[i].im[0].Width;
                int ys = L[i].y;
                int ye = L[i].y + L[i].im[0].Height;
                if (XM >= xs && XM <= xe && YM >= ys && YM <= ye)
                {
                    return i;
                }
            }
            return -1;
        }
        int Hit3(List<Cimg> L)
        {
            int XM = Lmario[0].x + 16;
            int YM = Lmario[0].y;
            //int XM1 = Lmario[0].x + 32;
            // int YM1 = Lmario[0].y;
            for (int i = 0; i < L.Count; i++)
            {
                int xs = L[i].x;
                int xe = L[i].x + L[i].im[0].Width;
                int ys = L[i].y;
                int ye = L[i].y + L[i].im[0].Height;
                if (XM >= xs && XM <= xe && YM >= ys && YM <= ye)
                {
                    return i;
                }
            }
            return -1;
        }
        void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            
            CreateWorld();
            createground();
            createmario();
            creatbirdenemy();
            createfloos();

           // creatswordenemy();
            createladd();

            DrawScene(this.CreateGraphics());
        }
        void ModifyRects()
        {
            Lworld[0].rcSrc = new Rectangle(xx, 0, ClientSize.Width, ClientSize.Height);
        }
        void CreateWorld()
        {
            Cimg pnn = new Cimg();
            pnn.img = new Bitmap("waw.jpg");
            pnn.rcDst = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
           // pnn.x=0;
            pnn.rcSrc = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);

            Lworld.Add(pnn);

        }
        void DrawScene(Graphics g2)
        {
            g2.Clear(Color.White);
           
            for (int i = 0; i < Lworld.Count; i++)
            {
                g2.DrawImage(Lworld[i].img, Lworld[i].rcDst, Lworld[i].rcSrc, GraphicsUnit.Pixel);
            }
            // g2.DrawImage(new Bitmap("bg.png"), 0, 0, this.ClientSize.Width, this.ClientSize.Height);

            for (int i = 0; i < Lobst.Count; i++)
            {
                g2.DrawImage(Lobst[i].im[0], Lobst[i].x, Lobst[i].y);
            }
            for (int i = 0; i < Lground.Count; i++)
            {
                g2.DrawImage(Lground[i].im[0], Lground[i].x, Lground[i].y);
            }
            //for (int i = 0; i < Lobst.Count; i++)
            //{
            //    g2.DrawImage(Lobst[i].im[0], Lobst[i].x, Lobst[i].y);
            //}
           
            for (int i = 0; i < Lbird.Count; i++)
            {
                g2.DrawImage(Lbird[i].im[Lbird[i].iframe], Lbird[i].x, Lbird[i].y);
            }
            for (int i = 0; i < Lsword.Count; i++)
            {
                g2.DrawImage(Lsword[i].im[Lsword[i].iframe], Lsword[i].x, Lsword[i].y);
            }
            for (int i = 0; i < Lladd.Count; i++)
            {
                g2.DrawImage(Lladd[i].im[Lladd[i].iframe], Lladd[i].x, Lladd[i].y);
            }
            for (int i = 0; i < Lmoraba3.Count; i++)
            {
                g2.DrawImage(Lmoraba3[i].im[Lmoraba3[i].iframe], Lmoraba3[i].x, Lmoraba3[i].y);
            }
            for (int i = 0; i < Lmario.Count; i++)
            {
                g2.DrawImage(Lmario[i].im[Lmario[i].iframe], Lmario[i].x, Lmario[i].y);
            }
            for (int i = 0; i < Lbullet.Count; i++)
            {
                g2.DrawImage(Lbullet[i].im[Lbullet[i].iframe], Lbullet[i].x, Lbullet[i].y);
            }
            for (int i = 0; i < Llaser.Count; i++)
            {
                Pen P = new Pen(Color.Red, 5);
                //g2.FillRectangle(Brushes.Red, Llaser[i].x, Llaser[i].y, Llaser[i].w, Llaser[i].h);
                g2.DrawLine(P, Llaser[i].x, Llaser[i].y, Llaser[i].w, Llaser[i].h);
            }
            g2.DrawString("Score: ", new Font("Arial", 18), Brushes.White, new Point(0, 0));
            g2.DrawString(x1 + "", new Font("Arial", 18), Brushes.White, new Point(80, 0));
        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }

    }
}
