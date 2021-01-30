using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptography
{
    public partial class CryptographyForm : Form
    {
        public CryptographyForm()
        {
            InitializeComponent();
        }


        private void CryptographyForm_Load(object sender, EventArgs e)
        {
            textBox1.Width = Width / 2 - 50;
            textBox2.Width = Width / 2 - 50;
            comboBox1.Left = Width / 2;
            textBox1.Height = 269;
            textBox2.Height = 269;
        }

        private void CryptographyForm_Resize(object sender, EventArgs e)
        {
            textBox1.Width = Width / 2 - 50;
            textBox2.Width = Width / 2 - 50;
            comboBox1.Left = Width / 2;
            textBox1.Height = 269;
            textBox2.Height = 269;
        }

        public string Cesar_Code()
        {
            char[] alphabet = new char [] {'а', 'б', 'в', 'г', 'д', 'е', 'є', 'ж', 'з', 'и', 'і', 'ї', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
            'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ю', 'я' };

            int yourkey = Convert.ToInt32(textBox3.Text);

            string shifrString = textBox1.Text;
            char temp;
            string res = "";

            for(int i = 0; i < shifrString.Length; i++)
            {
                temp = shifrString[i];
                for(int j = 0; j < alphabet.Length; j++)
                {   
                    if(alphabet[j] == shifrString[i])
                    {
                        if (yourkey > 33)
                        {
                            if (yourkey % 32 - 1 > j && j >= 0)
                            {
                                temp = alphabet[Math.Abs(32 + j - yourkey % 32 + 1)];
                            }

                            else if (j - yourkey % 32 + 1 <= 0)
                            {
                                temp = alphabet[32 + j - yourkey % 32];
                            }

                            else
                            {
                                temp = alphabet[j - yourkey % 32];
                            }
                        }
                        else if (yourkey - 1 > j && j >= 0)
                        {
                            temp = alphabet[Math.Abs(32 + j - yourkey + 1)];
                        }

                        else if (j - yourkey + 1 <= 0)
                        {
                            temp = alphabet[32 + j - yourkey];
                        }

                        else
                        {
                            temp = alphabet[j - yourkey];
                        }

                        break;
                    }
                }
                res += temp;
            }

            return res;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Введіть текст у відповідне поле!!!", "УВАГА!");
                    }
                    else if (textBox3.Text == "")
                    {
                        MessageBox.Show("Введіть ключ шифрування!!!", "УВАГА!");
                    }
                    else
                    {
                        textBox2.Text = Cesar_Code();
                        textBox2.Enabled = true;
                    }
                    break;
                case 1:
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Введіть текст у відповідне поле!!!", "УВАГА!");
                    }
                    else if (textBox3.Text == "")
                    {
                        MessageBox.Show("Введіть ключ шифрування!!!", "УВАГА!");
                    }
                    else
                    {
                        textBox2.Text = Vizhinera_Code();
                        textBox2.Enabled = true;
                    }
                    break;
                default:
                    MessageBox.Show("Оберіть тип шифрування!!!", "УВАГА!");
                    break;
            }

        }

        public string Vizhinera_Code()
        {
            string str = textBox1.Text;
            string str1 = textBox1.Text;
            const double indexCoincidence = 0.0553;
            int yourkey = Convert.ToInt32(textBox3.Text);
            string temp;
            int ind = 0;
            int counter, max = 0;



            while (ind < yourkey)
            { 
                temp = str1[0].ToString();
                str1 = str1.Remove(0, 1);
                str1 = str1.Insert(str1.Length, temp);
                ind++;
            }

            int ind1 = 0;
            int ind2 = 0;
            List<string> list = new List<string>();//список, що зберігає окремі частини тексту
            List<string> list1 = new List<string>();//список, що зберігає найбільш повторювані символи кожної частини списку


            while (ind1 < yourkey)
            {
                temp = "";
                for (int i = ind1; i < str.Length; i += yourkey)
                {
                    temp += str[i];
                }
                list.Add(temp);
                ind1++;
            }

            for(int i = 0; i < yourkey; i++)
            {
                temp = list[i];
                max = 0;
                for(int j = 0; j < temp.Length; j++)
                {
                    counter = 0;
                    for(int q = 0; q < temp.Length; q++)
                    {
                        if (temp[j] == temp[q])
                        {
                            counter++;
                        }
                    }
                    if (max < counter)
                    {
                        max = counter;
                        ind2 = j;
                    }
                }
                list1.Add(temp[ind2].ToString());
            }

            return list[0]+ Environment.NewLine + Environment.NewLine + list[1] + " " + max.ToString() + " " + list1[0] + " " + list1[1] + " " + list1[2] + " " + list1[3];
        }
    }
}
