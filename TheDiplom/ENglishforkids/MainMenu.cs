using System;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;
using ENglishforkids.Properties;

namespace ENglishforkids
{
    public partial class MainMenu : Form
    {
        Sounds sounds = new Sounds();
        int wordscount;
        string name;
        Bitmap myImage;
        ResourceManager rm = Resources.ResourceManager;
        private Point mouseOffset;//змінні для перетягування форми без рамок
        private bool isMouseDown = false;//змінні для перетягування форми без рамок


        public MainMenu (string sound)
        {
            InitializeComponent();
            Sound.Tag = sound;           
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {        
            if (Sound.Tag == "on") sounds.soundPlay("mainsong");
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel1.Tag != "open")
            {
                panel1.Height += 15;
                if (panel1.Height > 180) { timer1.Stop(); panel1.Tag = "open"; }
            }
            if (panel1.Tag == "open")
            {
                panel1.Height -= 15;
                if (panel1.Height <= 54) { timer1.Stop(); panel1.Tag = "close"; }
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent ;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.GreenYellow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panel2.Tag != "open")
            {
                panel2.Height += 15;
                if (panel2.Height > 524) { timer2.Stop(); panel2.Tag = "open"; }
            }
            if (panel2.Tag == "open")
            {
                panel2.Height -= 15;
                if (panel2.Height <= 54) { timer2.Stop(); panel2.Tag = "close"; }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            button13.Visible = true;
            if (panel3.Tag != "open")
            {
                panel3.Height += 15;
                if (panel3.Height > 180) { timer3.Stop(); panel3.Tag = "open"; }
            }
            if (panel3.Tag == "open")
            {
                panel3.Height -= 15;
                if (panel3.Height <= 64) { timer3.Stop(); button13.Visible = false; panel3.Tag = "close"; }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            timer3.Start();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            switch (Sound.Tag)
            {
                case "on":
                    //Sound.Load("..\\..\\soundoff.png");
                    myImage = (Bitmap)rm.GetObject("soundoff");
                    Sound.Image = myImage;
                    sounds.soundStop(); Sound.Tag = "off";
                    break;
                case "off":
                    //Sound.Load("..\\..\\soundon.png");
                    myImage = (Bitmap)rm.GetObject("soundon");
                    Sound.Image = myImage;
                    sounds.soundPlay("mainsong"); Sound.Tag = "on";
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Labyrinth f = new Labyrinth(Sound.Tag.ToString());
            sounds.soundStop();
            this.Hide();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PairedPictures twoPictures = new PairedPictures(Sound.Tag.ToString());
            sounds.soundStop();
            this.Hide();
            twoPictures.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (sender == a) { wordscount = 8; name = "a"; }
            if (sender == b) { wordscount = 10; name = "b"; }
            if (sender == c) { wordscount = 8; name = "c"; }
            if (sender == d) { wordscount = 11; name = "d"; }
            if (sender == ee) { wordscount = 11; name = "e"; }
            if (sender == f) { wordscount = 11; name = "f"; }
            if (sender == g) { wordscount = 18; name = "g"; }
            if (sender == h) { wordscount = 15; name = "h"; }
            EnglishWords englishWords = new EnglishWords(Sound.Tag.ToString(), wordscount, name);
            sounds.soundStop();
            this.Hide();
            englishWords.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Articles grammar = new Articles(Sound.Tag.ToString());
            this.Hide();
            sounds.soundStop();
            grammar.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Plural plural = new Plural(Sound.Tag.ToString());
            this.Hide();
            sounds.soundStop();
            plural.Show();
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackColor = Color.GreenYellow;
        }

        private void button14_MouseHover(object sender, EventArgs e)
        {
            button14.BackColor = Color.GreenYellow;
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {
            button14.BackColor = Color.Transparent;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.Transparent;
        }

        private void MainMenu_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight -
                    SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void MainMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void MainMenu_MouseUp(object sender, MouseEventArgs e)
        {
            // Changes the isMouseDown field so that the form does
            // not move unless the user is pressing the left mouse button.
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
    }
}
