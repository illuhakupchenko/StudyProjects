using ENglishforkids.Properties;
using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Media;

namespace ENglishforkids
{
    public partial class EnglishWords : Form
    {
        Sounds sounds = new Sounds();
        Random random = new Random();
        int[] arr;
        int k = 0;
        string sound;
        string category;
        int wordcounts = 0;
        string name;
        ResourceManager rm = Resources.ResourceManager;
        Bitmap myImage;
        MediaPlayer lala = new MediaPlayer();
        string[] pets = { "dog", "cat", "hamster", "parrot", "turtle", "fish", "frog", "rabbit", "lizard", "chameleon" };
        string[] family = { "mother", "father", "son", "daughter", "grandmother", "grandfather", "uncle", "aunt" };
        string[] colours = { "red", "green", "yellow", "blue", "pink", "black", "white", "orange", "gray", "brown", "purple" };
        string[] weather = { "hot", "cold", "warm", "foggy", "cloudy", "rainy", "snowy", "sunny" };
        string[] vegetables = { "potato", "tomato", "cucumber", "onion", "carrot", "cabbage", "corn", "radish", "pea", "beetroot", "broccoli" };
        string[] fruits = { "apple", "orange", "banana", "mandarin", "pineapple", "lemon", "pear", "peach", "plum", "apricot", "avocado" };
        string[] wildanimals = { "lion", "elephant", "tiger", "monkey", "panda", "shark", "giraffe", "bear", "camel", "wolf", "fox", "hare", "leopard", "zebra", "kangaroo", "hippopotamus", "crocodile", "horse" };
        string[] bodyparts = { "head", "hair", "ear", "eye", "nose", "lip", "arm", "hand", "finger", "leg", "knee", "foot", "mouth", "tooth", "tongue" };
        string[] mainArray;

        public EnglishWords(string sound, int wordscount, string category)
        {
            InitializeComponent();
            wordcounts = wordscount;
            this.sound = sound;
            this.name = category;
            rand();
            fillingArray();
            lala.Open(new Uri("C:\\Users\\areku\\Desktop\\Diplomniki\\Kuppchenko\\ENglishforkids\\ENglishforkids\\Resources\\fon2.mp3", System.UriKind.Relative));
            lala.Volume = 0.3;
        }

        private void fillingArray()
        {
            mainArray = new string[wordcounts];
            switch (name)
            {
                case "a": mainArray = family; category = "Family"; break;
                case "b": mainArray = pets; category = "Pets"; break;
                case "c": mainArray = weather; category = "Weather"; break;
                case "d": mainArray = colours; category = "Colours"; break;
                case "e": mainArray = fruits; category = "Fruits"; break;
                case "f": mainArray = vegetables; category = "Vegetables"; break;
                case "g": mainArray = wildanimals; category = "Wild animals"; break;
                case "h": mainArray = bodyparts; category = "Body parts"; break;
            }
        }

        private void rand()
        {
            arr = new int[wordcounts];
            for (int i = 0; i < wordcounts; i++)
            {
                arr[i] = random.Next(0, wordcounts);
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] == arr[i]) { i--; continue; }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            Next.Visible = false;
            Preview.Visible = false;
            picturesname.Visible = false;
           // picturesname.Visible = true;
           // pictureBox1.Load("..\\..\\" + mainArray[arr[k]] + ".jpg");
            //sounds.soundPlay("..\\..\\" + mainArray[arr[k]] + ".wav");
           // picturesname.Text = mainArray[arr[k]];
            if (Listening.Visible == true && Writting.Visible == true && textBox1.Visible == true)
            { textBox1.Visible = false; Listening.Visible = false; Writting.Visible = false; }
            else { Writting.Visible = true; Listening.Visible = true; }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            k++;
            if(k < wordcounts)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == mainArray[arr[k - 1]].ToString())
                    {
                        // pictureBox1.Load("..\\..\\" + mainArray[arr[k]] + ".jpg");
                        myImage = (Bitmap)rm.GetObject(mainArray[arr[k]].ToString()+"1");
                        pictureBox1.Image = myImage;
                        picturesname.Text = mainArray[arr[k]];
                        sounds.soundPlay(mainArray[arr[k]]); textBox1.Text = "";
                    }
                    else
                    {
                        if (textBox1.Text == "") MessageBox.Show("Enter the name of image!", "Attention!");
                        else { MessageBox.Show("You entered incorrect word!", "Attention!"); }
                        k--;
                    }
                }
                else
                {
                    // pictureBox1.Load("..\\..\\" + mainArray[arr[k]] + ".jpg");
                    myImage = (Bitmap)rm.GetObject(mainArray[arr[k]].ToString() + "1");
                    pictureBox1.Image = myImage;
                    sounds.soundPlay(mainArray[arr[k]].ToString());
                    picturesname.Text = mainArray[arr[k]];
                }               
            }
            if (k >= wordcounts)
            {
                k--;
                var result = MessageBox.Show("You have learned " + wordcounts + " new words! Do you want replay?", "Congratulations!", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    rand();
                    fillingArray();
                    k = 0;
                    // pictureBox1.Load("..\\..\\" + mainArray[arr[k]] + ".jpg");
                    myImage = (Bitmap)rm.GetObject(mainArray[arr[k]].ToString() + "1");
                    pictureBox1.Image = myImage;
                    sounds.soundPlay( mainArray[arr[k]]);
                    textBox1.Text = "";
                    picturesname.Text = mainArray[arr[k]];
                }
            }
        }

        private void Preview_Click(object sender, EventArgs e)
        {
            k--;
            if (k >= 0)
            {
                //pictureBox1.Load("..\\..\\" + mainArray[arr[k]] + ".jpg");
                myImage = (Bitmap)rm.GetObject(mainArray[arr[k]].ToString() + "1");
                pictureBox1.Image = myImage;
                sounds.soundPlay( mainArray[arr[k]]);
                picturesname.Text = mainArray[arr[k]];
            }
            else k = wordcounts - 1;
        }

        private void Listening_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            Next.Visible = true;
            Preview.Visible = true;
            pictureBox1.Visible = true;
            picturesname.Visible = true;
            picturesname.Visible = true;
            //pictureBox1.Load("..\\..\\" + mainArray[arr[k]] + ".jpg");
            myImage = (Bitmap)rm.GetObject(mainArray[arr[k]].ToString() + "1");
            pictureBox1.Image = myImage;
            sounds.soundPlay( mainArray[arr[k]]);
            picturesname.Text = mainArray[arr[k]];
        }

        private void Writing_Click(object sender, EventArgs e)
        {
            if (textBox1.Visible == true) { textBox1.Visible = false; }
            else { textBox1.Visible = true; }
            picturesname.Visible = false;
            Next.Visible = true;
            Preview.Visible = false;
            pictureBox1.Visible = true;
            //pictureBox1.Load("..\\..\\" + mainArray[arr[k]] + ".jpg");
            myImage = (Bitmap)rm.GetObject(mainArray[arr[k]].ToString()+"1");
            pictureBox1.Image = myImage;
            sounds.soundPlay( mainArray[arr[k]]);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            sounds.soundPlay( mainArray[arr[k]]);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sounds.soundPlay( mainArray[arr[k]]);
        }

        private void EnglishWords_Load(object sender, EventArgs e)
        {
            label1.Text = category;
            lala.Play();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(sound);
            lala.Stop();
            this.Close();
            mainMenu.Show();
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
    }
}
