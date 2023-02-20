using System;
using System.Windows.Forms;

namespace slp_bitu_minifikatorius
{
    public partial class Form1 : Form
    {
        Skaiciai skaiciai;
        Lentele lentele;
        int algoritmas = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Convert.ToString(input, 2).PadLeft(6, '0')
            skaiciai = ReadToBit(textBox1.Text,6);
            richTextBox1.Text = "";
            for (int i = 0; i < skaiciai.n; i++)
            {
                richTextBox1.Text = richTextBox1.Text + skaiciai.Skaityti(i) + " (" + skaiciai.ogsk[i] + ")" + "\n";
            }
        }
        static Skaiciai ReadToBit(string line, int pad)
        {
            Skaiciai skaiciai = new Skaiciai();
            if (line.Length > 0)
            {
                string[] parts = line.Split(',');
                for (int i = 0; i < parts.Length; i++)
                {
                    skaiciai.Deti(Convert.ToString(int.Parse(parts[i]), 2).PadLeft(pad, '0'), parts[i]);
                }
            }
            return skaiciai;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // pain
            skaiciai = ReadToBit(textBox1.Text,6);
            lentele = WriteToTable(skaiciai);
            PrintTable(richTextBox1, lentele);
        }

        static Lentele WriteToTable(Skaiciai skaiciai)
        {
            Lentele lentele = new Lentele();
            for (int i = 0; i < skaiciai.n; i++)
            {
                string tmp = skaiciai.Skaityti(i);
                int x = 100 * int.Parse(tmp[0].ToString()) + 10 * int.Parse(tmp[1].ToString()) + int.Parse(tmp[2].ToString());
                int y = 100 * int.Parse(tmp[3].ToString()) + 10 * int.Parse(tmp[4].ToString()) + int.Parse(tmp[5].ToString());
                lentele.data[y, x]++; // fucked up isvesty tai atvirksciai
            }
            return lentele;
        }
        static void PrintTable(RichTextBox output, Lentele lentele)
        {
            string tmp = "";
            string line = "";
            line = line + string.Format("{0,5}|{1,5}|{2,5}|{3,5}|{4,5}|{5,5}|{6,5}|{7,5}|{8,5}|", "X", "000", "001", "011", "010", "110", "111", "101", "100") + "\n";
            line = line + tmp + "\n";
            line = line + string.Format("{0,5}|{1,5}|{2,5}|{3,5}|{4,5}|{5,5}|{6,5}|{7,5}|{8,5}|", "000", lentele.data[0, 0], lentele.data[0, 1], lentele.data[0, 11], lentele.data[0, 10], lentele.data[0, 110], lentele.data[0, 111], lentele.data[0, 101], lentele.data[0, 100]) + "\n";
            line = line + tmp + "\n";
            line = line + string.Format("{0,5}|{1,5}|{2,5}|{3,5}|{4,5}|{5,5}|{6,5}|{7,5}|{8,5}|", "001", lentele.data[1, 0], lentele.data[1, 1], lentele.data[1, 11], lentele.data[1, 10], lentele.data[1, 110], lentele.data[1, 111], lentele.data[1, 101], lentele.data[1, 100]) + "\n";
            line = line + tmp + "\n";
            line = line + string.Format("{0,5}|{1,5}|{2,5}|{3,5}|{4,5}|{5,5}|{6,5}|{7,5}|{8,5}|", "011", lentele.data[11, 0], lentele.data[11, 1], lentele.data[11, 11], lentele.data[11, 10], lentele.data[11, 110], lentele.data[11, 111], lentele.data[11, 101], lentele.data[11, 100]) + "\n";
            line = line + tmp + "\n";
            line = line + string.Format("{0,5}|{1,5}|{2,5}|{3,5}|{4,5}|{5,5}|{6,5}|{7,5}|{8,5}|", "010", lentele.data[10, 0], lentele.data[10, 1], lentele.data[10, 11], lentele.data[10, 10], lentele.data[10, 110], lentele.data[10, 111], lentele.data[10, 101], lentele.data[10, 100]) + "\n";
            line = line + tmp + "\n";
            line = line + string.Format("{0,5}|{1,5}|{2,5}|{3,5}|{4,5}|{5,5}|{6,5}|{7,5}|{8,5}|", "110", lentele.data[110, 0], lentele.data[110, 1], lentele.data[110, 11], lentele.data[110, 10], lentele.data[110, 110], lentele.data[110, 111], lentele.data[110, 101], lentele.data[110, 100]) + "\n";
            line = line + tmp + "\n";
            line = line + string.Format("{0,5}|{1,5}|{2,5}|{3,5}|{4,5}|{5,5}|{6,5}|{7,5}|{8,5}|", "111", lentele.data[111, 0], lentele.data[111, 1], lentele.data[111, 11], lentele.data[111, 10], lentele.data[111, 110], lentele.data[111, 111], lentele.data[111, 101], lentele.data[111, 100]) + "\n";
            line = line + tmp + "\n";
            line = line + string.Format("{0,5}|{1,5}|{2,5}|{3,5}|{4,5}|{5,5}|{6,5}|{7,5}|{8,5}|", "101", lentele.data[101, 0], lentele.data[101, 1], lentele.data[101, 11], lentele.data[101, 10], lentele.data[101, 110], lentele.data[101, 111], lentele.data[101, 101], lentele.data[101, 100]) + "\n";
            line = line + tmp + "\n";
            line = line + string.Format("{0,5}|{1,5}|{2,5}|{3,5}|{4,5}|{5,5}|{6,5}|{7,5}|{8,5}|", "100", lentele.data[100, 0], lentele.data[100, 1], lentele.data[100, 11], lentele.data[100, 10], lentele.data[100, 110], lentele.data[100, 111], lentele.data[100, 101], lentele.data[100, 100]) + "\n";
            output.Text = line;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            algoritmas = 0;
            skaiciai = ReadToBit(textBox1.Text,6);
            int kiekis = minifikacijafast(ref skaiciai,algoritmas);
            richTextBox1.Text = String.Format("Minifikacija atlikta {0} kartu/s", kiekis) + "\n";
            for (int i = 0; i < skaiciai.n; i++)
            {
                richTextBox1.Text = richTextBox1.Text + skaiciai.Skaityti(i) + "\n";
            }

        }

        static int minifikacijafast(ref Skaiciai skaiciai, int algoritmas)
        {
            int trigger;
            if (algoritmas == 0)
                trigger = skaiciai.Minimizuoti();
            else
                trigger = skaiciai.Mini2();
            int kiekis = trigger;
            while (trigger != 0)
            {
                //Console.WriteLine("");
                if (algoritmas == 0)
                    trigger = skaiciai.Minimizuoti();
                else
                    trigger = skaiciai.Mini2();
                kiekis =kiekis+trigger;
            }
            return kiekis;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            algoritmas = 0;
            skaiciai = ReadToBit(textBox1.Text,6);
            int kiekis = minifikacijafast(ref skaiciai,algoritmas);
            richTextBox1.Text = skaiciai.minitxt;
            richTextBox1.Text = richTextBox1.Text + "\n";
            richTextBox1.Text = richTextBox1.Text + String.Format("Minifikacija atlikta {0} karta/us", kiekis) + "\n";
            for (int i = 0; i < skaiciai.n; i++)
            {
                richTextBox1.Text = richTextBox1.Text + skaiciai.Skaityti(i) + "\n";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // readbits
            algoritmas = 0;
            Skaiciai skaiciai = new Skaiciai();
            if (textBox1.Text.Length > 0)
            {
                string[] parts = textBox1.Text.Split(' ');
                for (int i = 0; i < parts.Length; i++)
                {
                    skaiciai.Deti(parts[i],"-1");
                }
            }
            int kiekis = minifikacijafast(ref skaiciai,algoritmas);
            richTextBox1.Text = String.Format("Minifikacija atlikta {0} kartu/s", kiekis) + "\n";
            for (int i = 0; i < skaiciai.n; i++)
            {
                richTextBox1.Text = richTextBox1.Text + skaiciai.Skaityti(i) + "\n";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            algoritmas = 1;
            skaiciai = ReadToBit(textBox1.Text, 6);
            int kiekis = minifikacijafast(ref skaiciai,algoritmas);
            richTextBox1.Text = String.Format("Minifikacija atlikta {0} kartu/s", kiekis) + "\n";
            for (int i = 0; i < skaiciai.n; i++)
            {
                richTextBox1.Text = richTextBox1.Text + skaiciai.Skaityti(i) + "\n";
            }
            algoritmas = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            algoritmas = 1;
            skaiciai = ReadToBit(textBox1.Text, 6);
            int kiekis = minifikacijafast(ref skaiciai,algoritmas);
            richTextBox1.Text = skaiciai.minitxt;
            richTextBox1.Text = richTextBox1.Text + "\n";
            richTextBox1.Text = richTextBox1.Text + String.Format("Minifikacija atlikta {0} karta/us", kiekis) + "\n";
            for (int i = 0; i < skaiciai.n; i++)
            {
                richTextBox1.Text = richTextBox1.Text + skaiciai.Skaityti(i) + "\n";
            }
            algoritmas = 0;
        }
    }
}
