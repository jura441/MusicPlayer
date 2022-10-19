using System.Runtime.InteropServices;
using System.Text;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        Mp3Player _mp3Player;
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("winmm.dll")]
        public static extern long mciSendString(
            string lpstrCommand,
            StringBuilder lpstrReturnString,
            int uReturnLength,
            IntPtr hwndCallback);

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            ofd.Filter = "mp3file | *.mp3";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                _mp3Player = new Mp3Player(path);
            }
        }
        private void btn_Play
    }

    class Mp3Player
    {
        public bool Repeat { get; set; }
        public Mp3Player(string path)
        {
            const string FORMAT  = @"open ""{0}"" type mpegvideo alias MediaFile";
            string command = String.Format(FORMAT, path);   
            Form1.mciSendString(command, new StringBuilder(),0, IntPtr.Zero);
        }
        public void Play()
        {
            string command = "play MediaFile";
            Form1.mciSendString(command, new StringBuilder(),0, IntPtr.Zero);
        }
        public void Stop()
        {
            string command = "stop MediaFile";
            Form1.mciSendString(command, new StringBuilder(), 0, IntPtr.Zero);
        }
    }

}