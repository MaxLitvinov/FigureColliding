using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FigureColliding.Classes;

namespace FigureColliding
{
    public partial class MainForm : Form
    {
        List<Figure> figureList;
        Random random;

        public MainForm()
        {
            InitializeComponent();
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            int radius;
            int x;
            int y;
            Figure circle; 
            while (true)
            {
                radius = random.Next(25, 100);
                x = random.Next(0, pictureBox1.Width);
                y = random.Next(0, pictureBox1.Height);
                circle = new Circle(x, y, radius);
                if (circle.IsInRegion(pictureBox1.Width, pictureBox1.Height))
                    break;
            }
            figureList.Add(circle);
            pictureBox1.Invalidate();
        }

        private void triangleButton_Click(object sender, EventArgs e)
        {

        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            Figure rectangle = new FigureColliding.Classes.Rectangle(10, 10, 100, 100);
            figureList.Add(rectangle);
            pictureBox1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            String s = "";
            foreach (var figure in figureList)
            {
                s += figure.GetType().Name.ToString() + "\n";
            }
            MessageBox.Show(s);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(pictureBox1.BackColor);
            
            // here should be Draw method

            Graphics graphics = e.Graphics;

            foreach (Figure figure in figureList)
            {
                figure.Draw(graphics);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            foreach (Figure figure in figureList)
            {
                figure.Move(graphics, pictureBox1);
            }
            pictureBox1.Refresh();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            figureList = new List<Figure>();
            random = new Random();
        }
    }
}
