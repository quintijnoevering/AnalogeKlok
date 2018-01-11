using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockAnaloge
{
    public partial class AnalogeKlok : Form
    {
        public AnalogeKlok(){        
            InitializeComponent();
        }

        int straal;

        Graphics HetForm;
        Draw Tekenen = new Draw();
        SetPoint MakePoint = new SetPoint();
        Point puntMid, puntUur, puntMin, puntSec, puntUurOld, puntMinOld, MiddelPunt;

        private void AnalogeKlok_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            
            tijd.Start();
            label1.Text = DateTime.Now.ToString("h:mm:ss tt");
            straal = this.Width / 4;
            HetForm = this.CreateGraphics();
        }

        private void tijd_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("h:mm:ss tt");

            //Teken over oude lijnen met witte lijnen
            HetForm.DrawLine(new Pen(BackColor, 2), MiddelPunt, puntSec);
            HetForm.DrawLine(new Pen(BackColor, 2), MiddelPunt, puntMinOld);
            HetForm.DrawLine(new Pen(BackColor, 3), MiddelPunt, puntUurOld);

            //Maak buiten punten van lijnen (Seconden, minuten en uren)
            puntSec = MakePoint.DrawSecondenEnMinuten(MiddelPunt, DateTime.Now.Second, straal);
            puntMin = MakePoint.DrawSecondenEnMinuten(MiddelPunt, DateTime.Now.Minute, straal);
            puntUur = MakePoint.DrawUren(MiddelPunt, DateTime.Now.Hour % 12, DateTime.Now.Minute, straal / 2);

            puntMinOld = puntMin;
            puntUurOld = puntUur;

            //Teken de lijnen
            HetForm.DrawLine(new Pen(Color.Red, 2), MiddelPunt, puntSec);
            HetForm.DrawLine(new Pen(Color.Gray, 2), MiddelPunt, puntMin);
            HetForm.DrawLine(new Pen(Color.Gray, 3), MiddelPunt, puntUur);
        }

        private void AnalogeKlok_Paint(object sender, PaintEventArgs e)
        {
            MiddelPunt = new Point(Width / 2, Height / 2);
            Tekenen.DrawCircel(this, MiddelPunt, straal);

            //Draw Small lines at every minute
            for (int i = 1; i <= 60; i++)
            {
                puntMin = MakePoint.DrawSecondenEnMinuten(MiddelPunt, i, straal + 5);
                puntMid = MakePoint.DrawSecondenEnMinuten(MiddelPunt, i, straal - 5);

                HetForm.DrawLine(new Pen(Color.Black, 1), puntMid.X, puntMid.Y, puntMin.X, puntMin.Y);
            }

            //Labels tekenen
            for (int i = 1; i <= 12; i++)
            {
                puntUur = MakePoint.DrawBigLines(MiddelPunt, i, straal + 20);
                Tekenen.DrawLabels(this, puntUur, straal, i);

                puntMin = MakePoint.DrawBigLines(MiddelPunt, i, straal + 10);
                puntMid = MakePoint.DrawBigLines(MiddelPunt, i, straal - 10);

                HetForm.DrawLine(new Pen(Color.Black, 2), puntMid.X, puntMid.Y, puntMin.X, puntMin.Y);
            }
        }

        private void AnalogeKlok_Resize_1(object sender, EventArgs e)
        {
            if (this.Width > this.Height) straal = this.Height / 4;
            else straal = this.Width / 4;
            HetForm = this.CreateGraphics();
            HetForm.Clear(this.BackColor);
        }
    }
}
