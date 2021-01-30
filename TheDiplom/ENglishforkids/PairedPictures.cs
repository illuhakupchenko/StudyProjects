using ENglishforkids.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace ENglishforkids
{
    public partial class PairedPictures : Form
    {
        int[] arr = new int[10];
        int[] arrNum = new int[20];
        Random random = new Random();
        int temp;//змінна для запам'ятовування індексу масива картинки, що співпала з іншою
        int temp2 = 0;//змінна для підрахунку кількості картинок, що співпали
        int open = 0;
        bool kek = false;
        private Point mouseOffset;//змінні для перетягування форми без рамок
        private bool isMouseDown = false;//змінні для перетягування форми без рамок
        PictureBox[] pictureBox = new PictureBox[20];
        Sounds sounds = new Sounds();
        string sound;
        MediaPlayer lala = new MediaPlayer();
        ResourceManager rm = Resources.ResourceManager;
        Bitmap myImage;

        public PairedPictures(string sound)
        {
            InitializeComponent();
            this.sound = sound;
            randPictures();
            choice();
            lala.Open(new Uri("C:\\Users\\areku\\Desktop\\Diplomniki\\Kuppchenko\\ENglishforkids\\ENglishforkids\\Resources\\fon3.mp3", System.UriKind.Relative));
            lala.Volume = 0.7;
        }

        private void pictureBoxes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                if (pictureBox[i].Tag != "done")
                {
                    if (sender == pictureBox[i])
                    {
                        sounds.soundPlay("click");
                        openImages(i);
                        if (kek == true) { openImages(temp); sounds.soundPlay("wrong"); kek = false; open = 0; }
                        break;
                    }
                }
                else { if (sender == pictureBox[i]) sounds.soundPlay("_"+ arr[arrNum[i]]); }
            }
        }

        private void randPictures()//рандом 10 випадкових картинок з 26
        {
            superRandom(arr, 1, 27);
        }

        private void superRandom(int[] array, int a, int b)//метод для рандому масивів
        {
            for (int i = 0; i < 10; i++)
            {
                array[i] = random.Next(a, b);
                for (int j = 0; j < i; j++)
                {
                    if (array[j] == array[i]) { i--; continue; }
                }

            }
        }

        private void choice()//метод для рандому розташування картинок
        {
            int[] arr1 = new int[10];
            int[] arr2 = new int[10];

            superRandom(arr1, 0, 10);
            superRandom(arr2, 0, 10);
            arrNum = arr1.Concat(arr2).ToArray();
        }

        private void restart()
        {
            for (int i = 0; i < 20; i++)
            {
                //image1 = "..\\..\\default.jpg";
                myImage = (Bitmap)rm.GetObject("_default");
                pictureBox[i].Image = myImage;
                pictureBox[i].Tag = "";
            }
        }

        private void openImages(int number)//метод відкриття картинок
        {
            if (temp == number) { open = 0; }
            open++;
            if (open < 2) temp = number;
            myImage = (Bitmap)rm.GetObject("_"+arr[arrNum[number]].ToString()+"p");
           // image1 = "..\\..\\" + arr[arrNum[number]].ToString() + ".jpg";

            if (open == 2 && arr[arrNum[temp]] == arr[arrNum[number]])
            {
                sounds.soundPlay("click");
                var t = Task.Run(async delegate
                {
                    await Task.Delay(400);
                });
                t.Wait();
                open = 0;
                sounds.soundPlay("_" + arr[arrNum[number]].ToString());
                pictureBox[number].Tag = "done";
                pictureBox[temp].Tag = "done";
                temp2++;
            }
            if (open == 1 && kek == true)
            {/* image1 = "..\\..\\default.jpg";*/ myImage = (Bitmap)rm.GetObject("_default"); }
            for (int i = 0; i < 2; i++)
            {
                // pictureBox[number].Load(image1);
                pictureBox[number].Image = myImage;
                if (open == 2 && arr[arrNum[temp]] != arr[arrNum[number]])
                {

                    var t = Task.Run(async delegate
                    {
                        await Task.Delay(400);
                    });                   
                    t.Wait();
                    //image1 = "..\\..\\default.jpg";
                    myImage = (Bitmap)rm.GetObject("_default");
                    open = 0; kek = true;
                }
            }
            if (temp2 == 10)
            {
                var t = Task.Run(async delegate
                {
                    await Task.Delay(1500);
                });
                for(int i = 0; i < 20; i++)
                {
                    Thread.Sleep(1);
                    pictureBox[i].Visible = false;
                }
                t.Wait();
                var result = MessageBox.Show("Congratulations! You completed the assignment! " +
                    "Do you want replay?", "Message!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    randPictures(); choice(); restart(); temp2 = 0;
                    for(int i = 0; i < 20; i++)
                    {
                        pictureBox[i].Visible = true;
                    }
                }
            }
        }

        private void PairedPictures_Load(object sender, EventArgs e)
        {
            lala.Play();
            pictureBox[0] = pictureBox1;
            pictureBox[1] = pictureBox2;
            pictureBox[2] = pictureBox3;
            pictureBox[3] = pictureBox4;
            pictureBox[4] = pictureBox5;
            pictureBox[5] = pictureBox6;
            pictureBox[6] = pictureBox7;
            pictureBox[7] = pictureBox8;
            pictureBox[8] = pictureBox9;
            pictureBox[9] = pictureBox10;
            pictureBox[10] = pictureBox11;
            pictureBox[11] = pictureBox12;
            pictureBox[12] = pictureBox13;
            pictureBox[13] = pictureBox14;
            pictureBox[14] = pictureBox15;
            pictureBox[15] = pictureBox16;
            pictureBox[16] = pictureBox17;
            pictureBox[17] = pictureBox18;
            pictureBox[18] = pictureBox19;
            pictureBox[19] = pictureBox20;
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            lala.Stop();
            this.Close();
            MainMenu mainMenu = new MainMenu(sound);
            mainMenu.Show();
        }

        private void pictureBox21_Click_1(object sender, EventArgs e)
        {
            switch (pictureBox21.Tag)
            {
                case "on":
                    //Sound.Load("..\\..\\soundoff.png");
                    myImage = (Bitmap)rm.GetObject("soundoff");
                    pictureBox21.Image = myImage;
                    lala.Stop(); pictureBox21.Tag = "off";
                    break;
                case "off":
                    //Sound.Load("..\\..\\soundon.png");
                    myImage = (Bitmap)rm.GetObject("soundon");
                    pictureBox21.Image = myImage;
                    lala.Play(); pictureBox21.Tag = "on";
                    break;
            }
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            int temp2 = 0;//змінна для підрахунку кількості картинок, що співпали
            int open = 0;
            bool kek = false;
            randPictures();
            restart();
            choice();
            lala.Open(new Uri("C:\\Users\\areku\\Desktop\\Diplomniki\\Kuppchenko\\ENglishforkids\\ENglishforkids\\Resources\\fon3.mp3", System.UriKind.Relative));
            lala.Volume = 0.077;
            myImage = (Bitmap)rm.GetObject("_default");
            for (int i = 0; i < 20; i++)
            {
                pictureBox[i].Visible = true;
                pictureBox[i].Image = myImage;
            }
        }
    }
}
