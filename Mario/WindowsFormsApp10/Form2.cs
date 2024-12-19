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
    class Cimg2
    {
        public int X, Y;
        public List<Bitmap> img=new List<Bitmap>();
        public int iF=0;
        public int Speed = 5;
    }
    public partial class Form2 : Form
    {
        List<Cimg2> LBoxes = new List<Cimg2>();
        Bitmap off;
        Timer t = new Timer();
        public Form2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 1;
            t.Start();

        }
        void t_Tick(object sender, EventArgs e)
        {

        }
            void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int iss=Hit(e.X,e.Y,LBoxes);
                if(iss==0)
                {
                    Form1 f1=new Form1();  
                    this.Hide();
                    f1.Show();
                }
            }
        }
        int Hit(int XM, int YM, List<Cimg2> L)
        {
            for (int i = 0; i < L.Count; i++)
            {
                int xs = L[i].X;
                int xe = L[i].X + 300;
                int ys = L[i].Y;
                int ye = L[i].Y + 80;
                if (XM >= xs && XM <= xe && YM >= ys && YM <= ye)
                {
                    return i;
                }
            }
            return -1;
        }
        void create()
        {
            Cimg2 pnn;
            for (int i = 0; i < 3; i++)
            {
                pnn = new Cimg2();
                if (i == 0)
                {
                    pnn.Y = this.ClientSize.Height / 2 + 230;
                    pnn.X = this.ClientSize.Width / 2 - 170;
                    pnn.img.Add(new Bitmap("start-btn.png"));
                }
                if(i == 1)
                {
                    pnn.Y = this.ClientSize.Height / 2 + 230;
                    pnn.X = this.ClientSize.Width / 2 - 580;
                    pnn.img.Add(new Bitmap("mariof.png"));
                }
                if(i==2)
                {
                    pnn.Y = this.ClientSize.Height / 2 + 230;
                    pnn.X = this.ClientSize.Width / 2 +245;
                    pnn.img.Add(new Bitmap("editor-btn.png"));
                }
                LBoxes.Add(pnn);
            }
        }
        void createanimation()
        {

        }


        void Form2_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            create();
            DrawScene(this.CreateGraphics());
        }
        void DrawScene(Graphics g2)
        {
            g2.Clear(Color.White);
            g2.DrawImage(new Bitmap("start-screen.png"), 0, 0, this.ClientSize.Width, this.ClientSize.Height);
            for (int i = 0; i < LBoxes.Count; i++)
            {
                g2.DrawImage(LBoxes[i].img[LBoxes[i].iF], LBoxes[i].X, LBoxes[i].Y,300,80);
            }
        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}
