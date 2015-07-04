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
        int x;
        int y;

        int dx;
        int dy;

        int radius;

        int width;
        int height;

        public Circle(int x, int y, int radius)
        {
            this.x = x + radius;
            this.y = y + radius;
            this.radius = radius;
            this.width = radius;
            this.height = radius;
            this.dx = 5;
            this.dy = 5;
        }

        public override void Draw(Graphics e)
        {
            Pen pen = new Pen(Color.Yellow, 2);
            e.DrawEllipse(pen, new System.Drawing.Rectangle(this.x, this.y, this.radius, this.radius));
        }

        public override void Move(Graphics e, PictureBox p)
        {
            int w = this.width;
            int h = this.height;
            int x = this.x;
            int y = this.y;
            int dx = this.dx;
            int dy = this.dy;

            if (x + w >= p.Width || x + w <= w)
            {
                dx *= -1;
            }

            if (y + h >= p.Height || y + h <= h)
            {
                dy *= -1;
            }

            setCenter(x + dx, y + dy);
            SetStep(dx, dy);
            Draw(e);
        }

        private void setCenter(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override void SetStep(int dx, int dy)
        {
            this.dx = dx;
            this.dy = dy;
        }

        public override bool IsInRegion(int width, int height)
        {
            if ((this.x + radius) > width || (this.y + radius) > height)
                return false;
            else
                return true;
        }
    }
}
