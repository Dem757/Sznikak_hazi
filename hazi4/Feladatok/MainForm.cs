namespace MultiThreadedApp
{
    public partial class MainForm : Form
    {
        private ManualResetEvent mre = new ManualResetEvent(false);
        private AutoResetEvent msync = new AutoResetEvent(false);
        private long stepCount = 0;
        private object lockObj = new object();
        private int start;

        public MainForm()
        {
            InitializeComponent();

            // Elmentjük a kezdõ pontot.
            start = bBike1.Left;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void BikeThreadFunction(object param)
        {
            try
            {
                Button bike = (Button)param;
                bike.Tag = Thread.CurrentThread;

                // Elmegyünk a startig.
                while (bike.Left < pStart.Left)
                {
                    MoveBike(bike);
                    Thread.Sleep(100);
                }

                // Várunk ameddig nem nyomják meg a gombot.
                mre.WaitOne();

                // Tovább megyünk a depoig.
                while (bike.Left < pDepo.Left)
                {
                    MoveBike(bike);
                    Thread.Sleep(100);
                }

                // Várunk gomb nyomásra.
                msync.WaitOne();

                // Elmegyünk a célig.
                while (bike.Left < pTarget.Left)
                {
                    MoveBike(bike);
                    Thread.Sleep(100);
                }
            }
            catch (ThreadInterruptedException)
            {
                // Lenyeljük, de szigorúan kizárólag a ThreadInterruptedException-t.
                // Ha nem kezelnénk az Interrupt hatására a szállfüggvényünk
                // és az alkalmazásunk is csúnyán "elszállna".
            }
        }

        Random random = new Random();

        public void MoveBike(Button bike)
        {
            if (InvokeRequired)
            {
                Invoke(MoveBike, bike);
            }
            else
            {
                int tmp = random.Next(2, 8);
                IncreasePixels(tmp);
                bike.Left += tmp;
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            StartBike(bBike1);
            StartBike(bBike2);
            StartBike(bBike3);

            bStart.Enabled = false;
        }

        private void StartBike(Button bBike)
        {
            var t = new Thread(BikeThreadFunction)
            {
                IsBackground = true, // Ne blokkolja a szál a processz megszûnését
            };

            bBike.Tag = t;
            t.Start(bBike);
        }

        private void bStep1_Click(object sender, EventArgs e)
        {
            mre.Set();
        }

        private void bStep2_Click(object sender, EventArgs e)
        {
            msync.Set();
        }

        void IncreasePixels(long step)
        {
            lock (lockObj)
            {
                stepCount += step;
            }
        }

        long GetPixels()
        {
            lock (lockObj)
            {
                return stepCount;
            }
        }

        private void bFinish_Click(object sender, EventArgs e)
        {
            bFinish.Text = GetPixels().ToString();
        }

        private void Bike_Click(object sender, EventArgs e)
        {
            Button bike = (Button)sender;
            Thread thread = (Thread)bike.Tag;

            // Ha még nem indítottuk ez a szálat, ez null.
            if (thread == null)
                return;

            // Megszakítjuk a szál várakozását,
            // ez az adott szálban egy ThreadInterruptedException-t fog kiváltani
            // A függvény leírásáról részleteket az elõadás anyagaiban találsz
            thread.Interrupt();

            // Megvárjuk, amíg a szál leáll
            thread.Join();

            // Újraindítjuk az eventet.
            mre.Reset();

            // Beállítjuk a start pozícióra.
            bike.Left = start;

            // Elindítjuk a biciklit.
            StartBike(bike);
        }
    }
}