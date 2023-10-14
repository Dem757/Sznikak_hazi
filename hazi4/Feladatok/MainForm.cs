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

            // Elmentj�k a kezd� pontot.
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

                // Elmegy�nk a startig.
                while (bike.Left < pStart.Left)
                {
                    MoveBike(bike);
                    Thread.Sleep(100);
                }

                // V�runk ameddig nem nyomj�k meg a gombot.
                mre.WaitOne();

                // Tov�bb megy�nk a depoig.
                while (bike.Left < pDepo.Left)
                {
                    MoveBike(bike);
                    Thread.Sleep(100);
                }

                // V�runk gomb nyom�sra.
                msync.WaitOne();

                // Elmegy�nk a c�lig.
                while (bike.Left < pTarget.Left)
                {
                    MoveBike(bike);
                    Thread.Sleep(100);
                }
            }
            catch (ThreadInterruptedException)
            {
                // Lenyelj�k, de szigor�an kiz�r�lag a ThreadInterruptedException-t.
                // Ha nem kezeln�nk az Interrupt hat�s�ra a sz�llf�ggv�ny�nk
                // �s az alkalmaz�sunk is cs�ny�n "elsz�llna".
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
                IsBackground = true, // Ne blokkolja a sz�l a processz megsz�n�s�t
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

            // Ha m�g nem ind�tottuk ez a sz�lat, ez null.
            if (thread == null)
                return;

            // Megszak�tjuk a sz�l v�rakoz�s�t,
            // ez az adott sz�lban egy ThreadInterruptedException-t fog kiv�ltani
            // A f�ggv�ny le�r�s�r�l r�szleteket az el�ad�s anyagaiban tal�lsz
            thread.Interrupt();

            // Megv�rjuk, am�g a sz�l le�ll
            thread.Join();

            // �jraind�tjuk az eventet.
            mre.Reset();

            // Be�ll�tjuk a start poz�ci�ra.
            bike.Left = start;

            // Elind�tjuk a biciklit.
            StartBike(bike);
        }
    }
}