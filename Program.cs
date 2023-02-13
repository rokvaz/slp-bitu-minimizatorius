using System;
using System.ComponentModel.Design;
using System.IO;
using System.Text;

namespace slp_ez
{
    class Skaiciai
    {
        public string[] dvej { get; set; }
        public int n { get; set; }
        private int Cn = 500;
        public int mini = -1;
        public Skaiciai()
        {
            n = 0;
            dvej = new string[Cn];
        }
        public void Deti(int input)
        {
            dvej[n++] = Convert.ToString(input, 2).PadLeft(6, '0');

        }
        public string Skaityti(int pos)
        {
            return dvej[pos];
        }
        public void Istrinti(int pos)
        {
            for(int i=pos;i<n-1;i++)
            {
                dvej[i] = dvej[i + 1];
            }
            n--;
        }
        public int Minimizuoti()
        {
            int trigger = 0;
            for(int i=0;i<n;i++)
            {
                for(int l=0;l<n;l++)
                {
                    int tmp = FindGoodDif(dvej[i], dvej[l]);
                    //Console.WriteLine("TEST {0} {1} {2}", tmp, dvej[i], dvej[l]);
                    if(tmp>-1)
                    {
                        StringBuilder laikinas=new StringBuilder(dvej[i]);
                        Istrinti(l);
                        laikinas[tmp] = '-';
                        dvej[i]= laikinas.ToString();
                        trigger++;

                    }

                }
            }
            return trigger;

        }
        private int FindGoodDif(string a1, string a2)
        {
            int ats = 0;
            int pos = -1;
            for(int i=0;i<a1.Length;i++)
            {
                if (a1[i].CompareTo(a2[i])!=0)
                {
                    ats++;
                    pos = i;
                }
            }
            if (ats == 1)
                return pos;
            else
                return -1;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Skaiciai skaiciai = new Skaiciai();
            using (StreamReader reader = new StreamReader("..//..//data.txt"))
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(',');
                for (int i = 0; i < parts.Length; i++)
                {
                    skaiciai.Deti(int.Parse(parts[i]));
                    //Console.WriteLine(skaiciai.Skaityti(skaiciai.n-1));
                }
                //Console.WriteLine("");
            }
            int trigger = skaiciai.Minimizuoti();
            while (trigger!=0)
            {
                for (int i = 0; i < skaiciai.n; i++)
                {
                    //Console.WriteLine(skaiciai.Skaityti(i));
                }
                //Console.WriteLine("");
                trigger = skaiciai.Minimizuoti();
            }
            using (var fr = File.CreateText("..//..//output.txt"))
            {
                for (int i = 0; i < skaiciai.n; i++)
                {
                    fr.WriteLine(skaiciai.Skaityti(i));
                }
            }

        }
    }
}
