using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureColliding.Classes
{
    class Triangle : Figure
    {
        public Triangle(int x, int y, int foundation, int height)
        {
            X = x;
            Y = y;
            Width = foundation;
            Height = height;
        }

        public override void Draw(System.Drawing.Graphics e)
        {
            Pen pen = new Pen(Color.Blue, 2);
            e.DrawLine(pen, X, Y + Height, X + Width, Y + Height);
            e.DrawLine(pen, X, Y + Height, X + Width / 2, Y);
            e.DrawLine(pen, X + Width / 2, Y, X + Width, Y + Height);
        }
    }
}
