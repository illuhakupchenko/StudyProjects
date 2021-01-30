using ENglishforkids.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace ENglishforkids
{
    public partial class Plural : Form
    {
        string sound;
        string plural;

        int[] arr;
        Random random = new Random();
        Sounds sounds = new Sounds();
        int k = 0;//змінна для індекса масиву
        Bitmap myImage;
        ResourceManager rm = Resources.ResourceManager;
        MediaPlayer lala = new MediaPlayer();

        public Plural(string sound)
        {
            InitializeComponent();
            this.sound = sound;
            rand();
            lala.Open(new Uri("C:\\Users\\areku\\Desktop\\Diplomniki\\Kuppchenko\\ENglishforkids\\ENglishforkids\\Resources\\fon1.mp3", System.UriKind.Relative));
            lala.Volume = 0.1;
        }

        private void rand()
        {
            arr = new int[14];
            for (int i = 0; i < 14; i++)
            {
                arr[i] = random.Next(0, 14);
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] == arr[i]) { i--; continue; }
                }
            }
        }

        private void Plural_Load(object sender, EventArgs e)
        {
            choose(arr[k]);
            lala.Play();
        }

        private void choose(int n)
        {
            switch (n)
            {
                case 0:
                  //  pictureBox1.Load("apples");
                    plural = "apples";
                    name.Text = "apple";
                    break;
                case 1:
                  //  pictureBox1.Load("dogs");
                    plural = "dogs";
                    name.Text = "dog";
                    break;
                case 2:
                   // pictureBox1.Load("books");
                    plural = "books";
                    name.Text = "book";
                    break;
                case 3:
                   // pictureBox1.Load("wolves");
                    plural = "wolves";
                    name.Text = "wolf";
                    break;
                case 4:
                  //  pictureBox1.Load("foxes");
                    name.Text = "fox";
                    plural = "foxes";
                    break;
                case 5:
                  //  pictureBox1.Load("turtles");
                    plural = "turtles";
                    name.Text = "turtle";
                    break;
                case 7:
                    //pictureBox1.Load("giraffes");
                    plural = "giraffes";
                    name.Text = "giraffe";
                    break;
                case 6:
                  //  pictureBox1.Load("clouds");
                    name.Text = "cloud";
                    plural = "clouds";
                    break;
                case 8:
                 //   pictureBox1.Load("shelves");
                    plural = "shelves";
                    name.Text = "shelf";
                    break;
                case 9:
                 //   pictureBox1.Load("children");
                    plural = "children";
                    name.Text = "child";
                    break;
                case 10:
                  //  pictureBox1.Load("feet");
                    plural = "feet";
                    name.Text = "foot";
                    break;
                case 11:
                   // pictureBox1.Load("mice");
                    plural = "mice";
                    name.Text = "mouse";
                    break;
                case 12:
                  //  pictureBox1.Load("fish");
                    plural = "fish2";
                    name.Text = "fish";
                    break;
                case 13:
                   // pictureBox1.Load("babies");
                    plural = "babies";
                    name.Text = "baby";
                    break;
            }
            myImage = (Bitmap)rm.GetObject(plural);
            pictureBox1.Image = myImage;
            if(plural == "fish2") { plural = "fish"; }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            lala.Stop();
            this.Close();
       
            MainMenu mainMenu = new MainMenu(sound);
            mainMenu.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("Enter the word!", "Attention!"); }
            else
            {
                if (textBox1.Text == plural)
                {
                    k++;
                    if (k == 14) { var result = MessageBox.Show("You have learned the plural! Do you want to replay?", "Congratulations!", MessageBoxButtons.YesNo); k = 0;
                        if (result == DialogResult.Yes) { textBox1.Text = "";choose(arr[k]); }
                    }
                    else choose(arr[k]); textBox1.Text = "";
                }
                else { MessageBox.Show("You entered incorrect word!", "Attention"); }
            }    
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            task.Visible = true;
            name.Visible = true;
            textBox1.Visible = true;
            label2.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            pictureBox3.Visible = true;
            label2.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            label2.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            switch (pictureBox5.Tag)
            {
                case "on":
                    //Sound.Load("..\\..\\soundoff.png");
                    myImage = (Bitmap)rm.GetObject("soundoff");
                    pictureBox5.Image = myImage;
                    lala.Stop(); pictureBox5.Tag = "off";
                    break;
                case "off":
                    //Sound.Load("..\\..\\soundon.png");
                    myImage = (Bitmap)rm.GetObject("soundon");
                    pictureBox5.Image = myImage;
                    lala.Play(); pictureBox5.Tag = "on";
                    break;
            }
        }
    }
}
