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
            int diameter;
            int x;
            int y;
            Figure circle; 
            while (true)
            {
                diameter = random.Next(25, 150);
                x = random.Next(1, pictureBox1.Width);
                y = random.Next(1, pictureBox1.Height);
                circle = new Circle(x, y, diameter);
                if (circle.IsInRegion(pictureBox1.Width, pictureBox1.Height))
                    break;
            }
            circle.SetStep(random.Next(1, 5), random.Next(1, 5));
            figureList.Add(circle);
            treeView1.Nodes.Add(circle.GetType().Name.ToString() + " " + circle.X + "; " + circle.Y);
            pictureBox1.Invalidate();
        }
        
        private void triangleButton_Click(object sender, EventArgs e)
        {
            int width;
            int height;
            int x;
            int y;
            Figure triangle;
            while (true)
            {
                width = random.Next(50, 100);
                height = random.Next(50, 100);
                x = random.Next(1, pictureBox1.Width);
                y = random.Next(1, pictureBox1.Height);
                triangle = new Triangle(x, y, width, height);
                if (triangle.IsInRegion(pictureBox1.Width, pictureBox1.Height))
                    break;
            }
            triangle.SetStep(random.Next(1, 5), random.Next(1, 5));
            figureList.Add(triangle);
            treeView1.Nodes.Add(triangle.GetType().Name.ToString() + " " + triangle.X + "; " + triangle.Y);
            pictureBox1.Invalidate();
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            int width;
            int height;
            int x;
            int y;
            Figure rectangle;
            while (true)
            {
                width = random.Next(50, 100);
                height = random.Next(50, 100);
                x = random.Next(1, pictureBox1.Width);
                y = random.Next(1, pictureBox1.Height);
                rectangle = new FigureColliding.Classes.Rectangle(x, y, width, height);
                if (rectangle.IsInRegion(pictureBox1.Width, pictureBox1.Height))
                    break;
            }
            rectangle.SetStep(random.Next(1, 5), random.Next(1, 5));
            figureList.Add(rectangle);
            treeView1.Nodes.Add(rectangle.GetType().Name.ToString() + " " + rectangle.X + "; " + rectangle.Y);
            pictureBox1.Invalidate();
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            if (moveButton.Text == "Start")
            {
                moveButton.Text = "Stop";
                timer1.Enabled = true;
            }
            else
            {
                moveButton.Text = "Start";
                timer1.Enabled = false;
                treeView1.Nodes.Clear();
                foreach (Figure figure in figureList)
                {
                    treeView1.Nodes.Add(figure.GetType().Name.ToString() + " " + figure.X + "; " + figure.Y);
                }
            }
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            figureList = new List<Figure>();
            random = new Random();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string s = e.Node.Text;
            string x = "";
            string y = "";
            foreach (var str in s)
            {
                if (str.Equals(Char.IsNumber(str)))
                {
                    x += str.ToString();
                }
                if (str.Equals(";"))
                {
                    x += str;
                }
            }
            MessageBox.Show(x);
        }
    }
}
