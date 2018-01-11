using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClockAnaloge
{
    class SetPoint
    {
        Point p = new Point();

        public Point DrawSecondenEnMinuten(Point middle, int Seconden, int straal)
        {
            p.X = middle.X + (int)(straal * Math.Sin(Math.PI * Seconden / 30));
            p.Y = middle.Y - (int)(straal * Math.Cos(Math.PI * Seconden / 30));

            return p;
        }

        public Point DrawBigLines(Point middle, int Uren, int straal)
        {
            p.X = middle.X + (int)(straal * Math.Sin(Math.PI * Uren / 6));
            p.Y = middle.Y - (int)(straal * Math.Cos(Math.PI * Uren / 6));

            return p;
        }

        public Point DrawUren(Point middle, int Uren, int M, int straal)
        {
            double Tijd = (double)(Uren * 30) + (M * 0.5);
            p.X = middle.X + (int)(straal * Math.Sin(Math.PI * Tijd / 180));
            p.Y = middle.Y - (int)(straal * Math.Cos(Math.PI * Tijd / 180));

            return p;
        }
    }
}
