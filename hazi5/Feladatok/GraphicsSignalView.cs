using Signals.DocView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signals
{
    public partial class GraphicsSignalView : UserControl, IView
    {
        // SignalDocument változó a leírásnak megfelelően.
        SignalDocument document;

        // Skálatényezők
        private double pixelsPerSecond;
        private int pixelsPerValue;

        // Zoom tényező, alapból 1
        private double zoom = 1;

        public GraphicsSignalView()
        {
            InitializeComponent();
        }

        // Konstruktor a leírásból másolva.
        public GraphicsSignalView(SignalDocument document)
            : this()
        {
            this.document = document;
        }

        // DemoView-ból másolva
        public int ViewNumber { get; set; }

        // DemoView-ból másolva
        public Document GetDocument()
        {
            return document;
        }

        // DemoView-ból másolva
        public new void Update()
        {
            Invalidate();
        }

        // Rajzolás
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Feladatleíársból a használandó pen
            var pen = new Pen(Color.Blue, 2)
            {
                DashStyle = DashStyle.Dot,
                EndCap = LineCap.ArrowAnchor,
            };

            // X tengely kirajzolása, lekérjük az ablak magasságát majd kipontozzuk addig a tengelyt.
            e.Graphics.DrawLine(pen, new Point(2, (int)(ClientSize.Height * zoom)), new Point(2, 0));

            //Y tengely kirajzolása, lekérjük az ablak magasságát, a felétől kezdünk rajzolni egészen az ablak szélességéig mindig a magasság feléig.
            e.Graphics.DrawLine(pen, new Point(0, (int)(ClientSize.Height * zoom / 2)), new Point((int)(ClientSize.Width * zoom), (int)(ClientSize.Height * zoom / 2)));

            // Megnézzük mennyi a legutolsó és a legelső közötti különbség, a legjobb megjelenítés érdekében.
            var timeDelta = document.Signals.Last().TimeStamp - document.Signals.First().TimeStamp;

            // Másodpercenkénti pixelarány
            pixelsPerSecond = (ClientSize.Width * zoom) / (timeDelta.Ticks / 1000000);

            // Értékek szerinti pixelarány
            pixelsPerValue = (int)((ClientSize.Height * zoom / 2) / document.Signals.Max(x => Math.Abs(x.Value)));

            // Jelenlegi x koordináta
            int x = 0;

            // Utolsó kirajzolt idő (jelen esetben ez az első)
            var lastTime = document.Signals.First().TimeStamp;

            // Pontok tárolása
            var points = new List<Point>();

            // Ciklus a pontok kirajzolására.
            foreach (var signal in document.Signals)
            {
                // Előző pont óta eltelt idő számítása
                var d = (signal.TimeStamp - lastTime).Ticks / 1000000;
                // Adott pont x koordinátájának kiszámítása.
                x += (int)(pixelsPerSecond * d);
                // Az adott pont y koordinátájának kiszámítása
                int y = (int)((ClientSize.Height * zoom / 2) - (signal.Value * pixelsPerValue));
                // Pont hozzáadása a listához
                points.Add(new Point(x, y));
                // Pont kirajzolása
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(x, y, 3, 3));
                // Utolsó kirajzolt idő
                lastTime = signal.TimeStamp;
            }
            // Utoljára kirajzolt pont (az elsővel kezdjük)
            var lastPoint = points.First();
            // Ciklus a vonalak kirajzolására.
            foreach (var point in points)
            {
                if (point != lastPoint)
                {
                    // Vonal kirajzolása két pont között
                    e.Graphics.DrawLine(new Pen(Color.Blue, 1), lastPoint, point);
                    // Utolsó kirajzol pont tárolása.
                    lastPoint = point;
                }
            }
        }

        // Nagyítás gomb
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            // 1.2-szeres nagyítás
            zoom *= 1.2;
            Invalidate();
        }

        // Kicsinyítés gomb
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            // 1.2-szeres kicsinyítés
            zoom /= 1.2;
            Invalidate();
        }
    }
}
