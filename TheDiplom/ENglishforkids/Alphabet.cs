using ENglishforkids.Properties;
using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace ENglishforkids
{
    public partial class Alphabet : Form
    {
        public Alphabet()
        {
            InitializeComponent();
        }
        int k = 1;
        Sounds sounds = new Sounds();
        ResourceManager rm = Resources.ResourceManager;
        Bitmap myImage;
        private void timer1_Tick(object sender, EventArgs e)
        {
            myImage = (Bitmap)rm.GetObject("_4380");

            if (k == 27)
            {
                this.BackgroundImage = myImage;
                timer1.Stop();
                var t = System.Threading.Tasks.Task.Run(async delegate
                {
                    await System.Threading.Tasks.Task.Delay(15000);
                });
                t.Wait();
                this.Close();
            }
            else
            {
                myImage = (Bitmap)rm.GetObject("_" + k + "a");
                this.BackgroundImage = myImage;
                k++;
                if (k == 2) { timer1.Interval = 600; }
                if (k == 8) { timer1.Interval = 900; }
                if (k == 9) { timer1.Interval = 800; }
                if(k == 11) { timer1.Interval = 750; }
            }
        }

        private void Alphabet_Load(object sender, EventArgs e)
        {
            sounds.soundPlay("alphabetsong");
            timer1.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            sounds.soundStop();
        }
    }
}
