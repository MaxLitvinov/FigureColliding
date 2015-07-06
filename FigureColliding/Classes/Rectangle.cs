using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureColliding.Classes
{
    class Rectangle : Figure
    {
        public Rectangle(int x, int y, int width, int height)
        {
            SetCenter(x, y);
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public override void Draw(System.Drawing.Graphics e)
        {
            Pen pen = new Pen(Color.Red, 2);
            e.DrawRectangle(pen, new System.Drawing.Rectangle(X, Y, Width, Height));
        }
    }
}
