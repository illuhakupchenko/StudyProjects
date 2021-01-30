using ENglishforkids.Properties;
using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Media;

namespace ENglishforkids
{
    public partial class Labyrinth : Form
    {
        PictureBox[] pictureBox = new PictureBox[26];
        string sound;
        Sounds sounds = new Sounds();
        int k = 0;
        Bitmap bitmap;
        System.Drawing.Color first, color;
        MediaPlayer lala = new MediaPlayer();
        ResourceManager rm = Resources.ResourceManager;
        Bitmap myImage;

        public Labyrinth(string sound)
        {
            InitializeComponent();
            this.sound = sound;
            lala.Open(new Uri("C:\\Users\\areku\\Desktop\\Diplomniki\\Kuppchenko\\ENglishforkids\\ENglishforkids\\Resources\\fon.mp3", System.UriKind.Relative));
            lala.Volume = 0.3;
            
        }

       

        private void takeLetter()
        {
            
            for (int i = 0; i < 26; i++)
            {
               
                if ((pictureBox[i].Visible == true && pictureBox28.Location.X <= pictureBox[i].Location.X+pictureBox[i].Width &&
                    pictureBox28.Location.X >= pictureBox[i].Location.X && pictureBox28.Location.Y + 90 >= pictureBox[i].Location.Y &&
                    pictureBox28.Location.Y +90 <= pictureBox[i].Location.Y + pictureBox[i].Height)||(pictureBox[i].Visible == true &&
                    pictureBox28.Location.X + pictureBox28.Width >= pictureBox[i].Location.X && pictureBox28.Location.X + pictureBox28.Width <= pictureBox[i].Location.X + pictureBox[i].Width &&
                    pictureBox28.Location.Y +90>= pictureBox[i].Location.Y && pictureBox28.Location.Y +90 <= pictureBox[i].Location.Y + pictureBox[i].Height))
                {
                    pictureBox[i].Visible = false;
            
                    sounds.soundPlay("_" + (i + 1));
                    k++;
                    if (k == 26)
                    {
                         Alphabet alphabet = new Alphabet();
                         alphabet.ShowDialog();
                         var result = MessageBox.Show("Congratulations! You collected all the letters! " +
                    "Do you want to replay?", "Message!", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            k = 0;
                            for (int j = 0; j < 26; j++)
                            {
                                pictureBox[j].Visible = true;
                                lala.Play();

                            }
                            pictureBox28.Location = new Point(1119, 758);
                        }
                    }
                }
            }
            if(pictureBox28.Location.X > 940 && pictureBox28.Location.X < 999 && pictureBox28.Location.Y + 95 > 555 && pictureBox28.Location.Y + 95 < 605)
            {
                var result = MessageBox.Show("Do you really want to Exit?", "Message!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                    MainMenu mainMenu = new MainMenu(sound);
                    mainMenu.Show();
                }
            }
        }

        private void Labirinth_KeyDown(object sender, KeyEventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox4.Visible = false;
            color = new System.Drawing.Color();
            color = bitmap.GetPixel(pictureBox28.Location.X + 15, pictureBox28.Location.Y + 93);
            takeLetter();
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (color == first)
                        {
                            pictureBox28.Location = new Point(pictureBox28.Location.X, pictureBox28.Location.Y - 5);
                        }

                        color = bitmap.GetPixel(pictureBox28.Location.X + 15, pictureBox28.Location.Y + 93);
                        if (color != first)//допоміжна перевірка, у разі виходу за межі доріжки
                        {
                            pictureBox28.Location = new Point(pictureBox28.Location.X, pictureBox28.Location.Y + 5);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (color == first)
                        {
                            pictureBox28.Location = new Point(pictureBox28.Location.X, pictureBox28.Location.Y + 5);
                        }

                        color = bitmap.GetPixel(pictureBox28.Location.X + 15, pictureBox28.Location.Y + 93);
                        if (color != first)
                        {
                            pictureBox28.Location = new Point(pictureBox28.Location.X, pictureBox28.Location.Y - 5);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        pictureBox28.Image = Properties.Resources.mann;
                        if (color == first)
                        {
                            pictureBox28.Location = new Point(pictureBox28.Location.X - 5, pictureBox28.Location.Y);
                        }

                        color = bitmap.GetPixel(pictureBox28.Location.X + 15, pictureBox28.Location.Y + 93);
                        if (color != first)
                        {
                            pictureBox28.Location = new Point(pictureBox28.Location.X + 5, pictureBox28.Location.Y);
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        pictureBox28.Image = Properties.Resources.mannright;
                        if (color == first)
                        {
                            pictureBox28.Location = new Point(pictureBox28.Location.X + 5, pictureBox28.Location.Y);
                        }

                        color = bitmap.GetPixel(pictureBox28.Location.X + 15, pictureBox28.Location.Y + 93);
                        if (color != first)
                        {
                            pictureBox28.Location = new Point(pictureBox28.Location.X - 5, pictureBox28.Location.Y);
                        }
                        break;
                    }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you really want to Exit?", "Message!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                lala.Stop();
                this.Close();
                MainMenu mainMenu = new MainMenu(sound);
                mainMenu.Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox4.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            switch (pictureBox3.Tag)
            {
                case "on":
                    //Sound.Load("..\\..\\soundoff.png");
                    myImage = (Bitmap)rm.GetObject("soundoff");
                    pictureBox3.Image = myImage;
                    lala.Stop(); pictureBox3.Tag = "off";
                    break;
                case "off":
                    //Sound.Load("..\\..\\soundon.png");
                    myImage = (Bitmap)rm.GetObject("soundon");
                    pictureBox3.Image = myImage;
                    lala.Play(); pictureBox3.Tag = "on";
                    break;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            lala.Open(new Uri("C:\\Users\\areku\\Desktop\\Diplomniki\\Kuppchenko\\ENglishforkids\\ENglishforkids\\Resources\\fon.mp3", System.UriKind.Relative));
            lala.Volume = 0.077;
            for(int i = 0; i < 26; i++)
            {
                pictureBox[i].Visible = true;
            }
            pictureBox28.Location = new Point(1119, 758);
        }

        private void Labirinth_Load(object sender, EventArgs e)
        {
            lala.Play();
           
            this.BackgroundImage = Properties.Resources.Pushka;
            pictureBox28.Location = new Point(1119,758);
            /*Заповнюєм масив PictureBox для зручної роботи методу takeletter()*/
            pictureBox[0] = a;
            pictureBox[1] = b;
            pictureBox[2] = c;
            pictureBox[3] = d;
            pictureBox[4] = ee;
            pictureBox[5] = f;
            pictureBox[6] = g;
            pictureBox[7] = h;
            pictureBox[8] = i;
            pictureBox[9] = j;
            pictureBox[10] = kk;
            pictureBox[11] = l;
            pictureBox[12] = m;
            pictureBox[13] = n;
            pictureBox[14] = o;
            pictureBox[15] = p;
            pictureBox[16] = q;
            pictureBox[17] = r;
            pictureBox[18] = s;
            pictureBox[19] = t;
            pictureBox[20] = u;
            pictureBox[21] = v;
            pictureBox[22] = w;
            pictureBox[23] = x;
            pictureBox[24] = y;
            pictureBox[25] = z;

            first = new System.Drawing.Color();
            bitmap = new Bitmap(BackgroundImage);
            /*зчитуєм колір пікселя, де розташований герой*/
            first = bitmap.GetPixel(pictureBox28.Location.X, pictureBox28.Location.Y);
        }
    }
}
