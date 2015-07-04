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

        private int dx = 5;
        private int dy = 5;

        private int width;
        private int height;

        public void setCenter(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

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
              
        public abstract void Draw(Graphics e);

        public abstract void Move(Graphics e, PictureBox p);

        public abstract bool IsInRegion(int width, int height);

        public abstract void SetStep(int dx, int dy);
    }
}
