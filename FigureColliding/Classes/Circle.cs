using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FigureColliding.Classes
{
    class Circle : Figure
    {
        public Circle(int x, int y, int diameter)
        {
            X = x;
            Y = y;
            Width = diameter;
            Height = diameter;
        }

        public override void Draw(Graphics e)
        {
            Pen pen = new Pen(Color.Yellow, 2);
            e.DrawEllipse(pen, new System.Drawing.Rectangle(X, Y, Width, Height));
        }
    }
}
