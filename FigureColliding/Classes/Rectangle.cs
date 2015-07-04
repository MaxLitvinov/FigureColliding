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
            base.setCenter(x, y);
            base.X = x;
            base.Y = y;
            base.Width = width;
            base.Height = height;
        }

        public override void Draw(System.Drawing.Graphics e)
        {
            Pen pen = new Pen(Color.Red, 2);
            e.DrawRectangle(pen, new System.Drawing.Rectangle(base.X, base.Y, base.Width, base.Height));
        }

        public override void Move(System.Drawing.Graphics e, System.Windows.Forms.PictureBox p)
        {
            if (base.X + base.Width >= p.Width || base.X + base.Width <= base.Width)
            {
                Dx *= -1;
            }

            if (base.Y + base.Height >= p.Height || base.Y + base.Height <= base.Height)
            {
                Dy *= -1;
            }

            base.setCenter(base.X + base.Dy, base.Y + base.Dy);
            SetStep(Dx, Dy);
            Draw(e);
        }

        public override bool IsInRegion(int width, int height)
        {
            if ((X + Width / 2) > Width || (Y + Height) > Height)
                return false;
            else
                return true;
        }

        public override void SetStep(int dx, int dy)
        {
            Dx = dx;
            Dy = dy;
        }
    }
}
