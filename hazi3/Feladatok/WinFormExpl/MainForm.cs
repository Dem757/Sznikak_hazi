namespace WinFormExpl
{
    public partial class MainForm : Form
    {
        private DirectoryInfo mCurrentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
        private FileInfo loadedFile = null;
        int counter;
        readonly int counterInitialValue;

        public MainForm()
        {
            InitializeComponent();
            counterInitialValue = 60;
        }

        private void miExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            var dlg = new InputDialog() { Path = mCurrentDir.FullName };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string result = dlg.Path;
                mCurrentDir = new DirectoryInfo(result);
                UpdateDirectoryView();

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                var file = new FileInfo(listView1.SelectedItems[0].SubItems[2].Text);
                lName.Text = file.Name;
                lCreated.Text = file.CreationTime.ToString();
            }
        }

        private void UpdateDirectoryView()
        {
            listView1.Items.Clear();

            try
            {
                foreach (FileInfo fi in mCurrentDir.GetFiles())
                {
                    listView1.Items.Add(
                        new ListViewItem(new string[]
                        {
                            fi.Name,
                            fi.Length.ToString(),
                            fi.FullName
                        }));
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                var fullName = listView1.SelectedItems[0].SubItems[2].Text;
                tContent.Text = File.ReadAllText(fullName);
                reloadTimer.Start();
                counter = counterInitialValue;
                loadedFile = new FileInfo(fullName);
            }
        }

        private void reloadTimer_Tick(object sender, EventArgs e)
        {
            counter--;

            detailsPanel.Invalidate();

            if (counter <= 0)
            {
                counter = counterInitialValue;
                tContent.Text = File.ReadAllText(loadedFile.FullName);
            }
        }

        private void detailsPanel_Paint(object sender, PaintEventArgs e)
        {
            if (loadedFile != null)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Brown), new Rectangle(0, 0, (int)(125 * ((float)counter / (float)counterInitialValue)), 5));
            }
        }
    }
}