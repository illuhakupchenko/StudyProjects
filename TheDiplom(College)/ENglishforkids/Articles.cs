using ENglishforkids.Properties;
using System;
using System.Drawing;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace ENglishforkids
{
    public partial class Articles : Form
    {
        int[] arr;
        Random random = new Random();
        Sounds sounds = new Sounds();
        int k = 0;//змінна для індекса масиву
        int m = 0;
        string sound;
        Bitmap myImage;
        ResourceManager rm = Resources.ResourceManager;
        MediaPlayer lala = new MediaPlayer();

        public Articles(string sound)
        {
            InitializeComponent();
            this.sound = sound;
            rand();
           // lala.Open(new Uri("C:\\Users\\areku\\Desktop\\Diplomniki\\Kuppchenko\\ENglishforkids\\ENglishforkids\\Resources\\fon.mp3", System.UriKind.Relative));
            lala.Open(new Uri("C:\\Users\\areku\\Desktop\\Diplomniki\\Kuppchenko\\ENglishforkids\\ENglishforkids\\Resources\\fon1.mp3", System.UriKind.Relative));
            lala.Volume = 0.3;
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            lala.Stop();
            this.Close();
            MainMenu mainMenu = new MainMenu(sound);
            mainMenu.Show();
        }

        private void rule_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            closerule.Visible = true;
            rule.Visible = false;
            task.Visible = false;
            pictureBox1.Visible = false;
            a.Visible = false;
            an.Visible = false;
            name.Visible = false;
            Exit.Visible = false;
        }

        private void play_Click(object sender, EventArgs e)
        {
            // this.BackgroundImage = Image.FromFile("startlearning.jpg");
            myImage = (Bitmap)rm.GetObject("startlearning");
            this.BackgroundImage = myImage;
            task.Visible = true;
            rule.Visible = true;
            a.Visible = true;
            an.Visible = true;
            choose(arr[k]);
            pictureBox1.Visible = true;
            name.Visible = true;
            play.Visible = false;
        }
        private void choose(int n)
        {
            a.ForeColor = System.Drawing.Color.White;
            an.ForeColor = System.Drawing.Color.White;
            switch (n)
            {
                case 0:
                    //pictureBox1.Load("..\\..\\an apple.png");
                    myImage = (Bitmap)rm.GetObject("an_apple");
                    pictureBox1.Image = myImage;
                    name.Text = "apple";
                    break;
                case 1:
                    //pictureBox1.Load("..\\..\\an umbrella.png");
                    myImage = (Bitmap)rm.GetObject("an_umbrella");
                    pictureBox1.Image = myImage;
                    name.Text = "umbrella";
                    break;
                case 2:
                    //pictureBox1.Load("..\\..\\an ice-cream.png");
                    myImage = (Bitmap)rm.GetObject("an_ice_cream");
                    name.Text = "ice-cream";
                    pictureBox1.Image = myImage;
                    break;
                case 3:
                    //pictureBox1.Load("..\\..\\an egg.png");
                    myImage = (Bitmap)rm.GetObject("an_egg");
                    name.Text = "egg";
                    pictureBox1.Image = myImage;
                    break;
                case 4:
                    //                  pictureBox1.Load("..\\..\\an ear.png");
                    myImage = (Bitmap)rm.GetObject("an_ear");
                    name.Text = "ear";
                    pictureBox1.Image = myImage;
                    break;
                case 5:
                    //pictureBox1.Load("..\\..\\an octopus.png");
                    myImage = (Bitmap)rm.GetObject("an_octopus");
                    name.Text = "octopus";
                    pictureBox1.Image = myImage;
                    break;
                case 7:
                    //pictureBox1.Load("..\\..\\a car.png");
                    myImage = (Bitmap)rm.GetObject("a_car");
                    name.Text = "car";
                    pictureBox1.Image = myImage;
                    break;
                case 6:
                    //pictureBox1.Load("..\\..\\an elephant.png");
                    myImage = (Bitmap)rm.GetObject("an_elephant");
                    name.Text = "elephant";
                    pictureBox1.Image = myImage;
                    break;
                case 8:
                    //pictureBox1.Load("..\\..\\a mouse.png");
                    myImage = (Bitmap)rm.GetObject("a_mouse");
                    name.Text = "mouse";
                    pictureBox1.Image = myImage;
                    break;
                case 9:
                    //pictureBox1.Load("..\\..\\a book.png");
                    myImage = (Bitmap)rm.GetObject("a_book");
                    name.Text = "book";
                    pictureBox1.Image = myImage;
                    break;
                case 10:
                    //pictureBox1.Load("..\\..\\a house.png");
                    myImage = (Bitmap)rm.GetObject("a_house");
                    name.Text = "house";
                    pictureBox1.Image = myImage;
                    break;
                case 11:
                    //pictureBox1.Load("..\\..\\a milk.png");
                    myImage = (Bitmap)rm.GetObject("a_milk");
                    name.Text = "milk";
                    pictureBox1.Image = myImage;
                    break;
                case 12:
                    //pictureBox1.Load("..\\..\\a tree.png");
                    myImage = (Bitmap)rm.GetObject("a_tree");
                    name.Text = "tree";
                    pictureBox1.Image = myImage;
                    break;
                case 13:
                    //pictureBox1.Load("..\\..\\a cat.png");
                    myImage = (Bitmap)rm.GetObject("a_cat");
                    name.Text = "cat";
                    pictureBox1.Image = myImage;
                    break;
            }
        }

        private void GrammarClick(object sender, EventArgs e)
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(800);
            });          
            if (sender == an)
            {
                k++;
                if (arr[k - 1] < 7)
                {
                    an.ForeColor = System.Drawing.Color.Green; sounds.soundPlay("click"); t.Wait();
                    if (k == 14)
                    {
                        t.Wait();
                        MessageBox.Show("You finished this task! You have " + m.ToString() + " mistake(s)!", "Congratulation!");
                        k = 0;
                        pictureBox2.Visible = false;
                        closerule.Visible = false;
                        rule.Visible = false;
                        task.Visible = false;
                        pictureBox1.Visible = false;
                        a.Visible = false;
                        an.Visible = false;
                        name.Visible = false;
                        play.Visible = true;
                        rand();
                        // this.BackgroundImage = this.BackgroundImage = Image.FromFile("..\\..\\grammar.jpg");
                        myImage = (Bitmap)rm.GetObject("grammar");
                        this.BackgroundImage = myImage;
                    }
                    choose(arr[k]);
                }
                else { m++; an.ForeColor = System.Drawing.Color.Red; sounds.soundPlay("click");
                    t.Wait(); an.ForeColor = System.Drawing.Color.White; sounds.soundPlay("wrong"); k--; }
            }
            if (sender == a)
            {
                k++;
                if (arr[k - 1] > 6)
                {
                    a.ForeColor = System.Drawing.Color.Green; sounds.soundPlay("click"); t.Wait();
                    if (k == 14)
                    {
                        t.Wait(); MessageBox.Show("You finished this task! You have " + m.ToString() + " mistake(s)!", "Congratulation!");
                        k = 0;
                        pictureBox2.Visible = false;
                        closerule.Visible = false;
                        rule.Visible = false;
                        task.Visible = false;
                        pictureBox1.Visible = false;
                        a.Visible = false;
                        an.Visible = false;
                        name.Visible = false;
                        play.Visible = true;
                        rand();
                        //this.BackgroundImage = this.BackgroundImage = Image.FromFile("..\\..\\grammar.jpg");
                        myImage = (Bitmap)rm.GetObject("grammar");
                        this.BackgroundImage = myImage;
                    }
                    choose(arr[k]);
                }
                else { m++; a.ForeColor = System.Drawing.Color.Red; sounds.soundPlay("click");
                    t.Wait(); a.ForeColor = System.Drawing.Color.White; sounds.soundPlay("wrong"); k--; }
            }
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            closerule.Visible = false;
            if(play.Visible == false)
            {
                rule.Visible = true;
                task.Visible = true;
                pictureBox1.Visible = true;
                a.Visible = true;
                an.Visible = true;
                name.Visible = true;
                Exit.Visible = true;
            }
        }

        private void Articles_Load(object sender, EventArgs e)
        {
            lala.Play();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
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
    }
}
