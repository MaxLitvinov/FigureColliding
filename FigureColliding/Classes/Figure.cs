using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FigureColliding.Classes
{
    abstract class Figure
    {
        private int x;
        private int y;

        private int dx;
        private int dy;

        private int width;
        private int height;

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public int Dx
        {
            get { return this.dx; }
            set { this.dx = value; }
        }

        public int Dy
        {
            get { return this.dy; }
            set { this.dy = value; }
        }

        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public void SetCenter(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool IsInRegion(int width, int height)
        {
            if ((X + Width) > width || (Y + Height) > height)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SetStep(int dx, int dy)
        {
            Dx = dx;
            Dy = dy;
        }

        public abstract void Draw(Graphics e);

        public void Move(Graphics e, PictureBox p)
        {
            int w = Width;
            int h = Height;
            int x = X;
            int y = Y;
            int dx = Dx;
            int dy = Dy;

            if (x + w >= p.Width || x + w <= w)
            {
                dx *= -1;
            }

            if (y + h >= p.Height || y + h <= h)
            {
                dy *= -1;
            }

            SetCenter(x + dx, y + dy);
            SetStep(dx, dy);
            Draw(e);
        }
    }
}
