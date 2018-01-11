using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ClockAnaloge
{
    class Draw
    {
        AnalogeKlok thisForm = null;
        public void DrawCircel(AnalogeKlok form, Point middle, int straal)
        {
            thisForm = form;
            Graphics HetForm = thisForm.CreateGraphics();
            Pen JeTekenPen = new Pen(Color.Black, 2);

            HetForm.DrawEllipse(JeTekenPen, middle.X - straal, middle.Y - straal, straal *2, straal *2);
        }

        public void DrawLabels(AnalogeKlok form, Point puntUur, int straal, int i)
        {
            thisForm = form;
            int stringWidth = 50;

            string uur = i.ToString();
            Graphics g = thisForm.CreateGraphics();
            SolidBrush sbr = new SolidBrush(Color.Black);
            Font font = new System.Drawing.Font("Ariel", 10);
            SizeF stringSize = new SizeF();
            stringSize = g.MeasureString(uur, font, stringWidth);
            g.DrawString(uur, font, sbr, puntUur.X - (stringSize.Width / 2), puntUur.Y - (stringSize.Height / 2));
        }
    }
}
