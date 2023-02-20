using System;
using System.Text;

namespace slp_bitu_minifikatorius
{
    internal class Skaiciai
    {
        public string[] dvej { get; set; }
        public int n { get; set; }
        private int Cn = 500;
        public string minitxt { get; set; }
        public string[] ogsk { get; set; }
        public Skaiciai()
        {
            n = 0;
            dvej = new string[Cn];
            ogsk = new string[Cn];
            minitxt = "";
        }
        public void Deti(string input, string sk)
        {
            dvej[n] = input;
            ogsk[n] = sk;
            n++;

        }
        public string Skaityti(int pos)
        {
            return dvej[pos];
        }
        public void Istrinti(int pos)
        {
            for (int i = pos; i < n - 1; i++)
            {
                dvej[i] = dvej[i + 1];
                ogsk[i] = ogsk[i + 1];
            }
            n--;
        }
        public int Mini2()
        {
            int trigger = 0;
            for(int i=0;i<n;i++)
            {
                int test = 0;
                for (int l = 0; l < n; l++)
                {
                    int tmp = FindGoodDif(dvej[i], dvej[l]);
                    if(tmp>-1)
                    {
                        test++;
                        minitxt = minitxt + String.Format("{0} su {1} ({2} + {3}) ", dvej[i], dvej[l], ogsk[i], ogsk[l]);
                        StringBuilder laikinas = new StringBuilder(dvej[l]);
                        ogsk[l] = string.Format("({0} + {1})", ogsk[i], ogsk[l]);
                        laikinas[tmp] = '-';
                        dvej[l] = laikinas.ToString();
                        minitxt = minitxt + string.Format("= {0}", dvej[l]) + "\n";
                        trigger++;
                    }
                }
                if (test > 0)
                {
                    Istrinti(i);
                    i--;
                }
            }
            return trigger;
        }
        public int Minimizuoti()
        {
            int trigger = 0;
            for (int i = 0; i < n; i++)
            {
                for (int l = 0; l < n; l++)
                {
                    int tmp = FindGoodDif(dvej[i], dvej[l]);
                    if (tmp > -1)
                    {
                        minitxt = minitxt + String.Format("{0} su {1} ({2} + {3}) ", dvej[i], dvej[l], ogsk[i], ogsk[l]);
                        StringBuilder laikinas = new StringBuilder(dvej[i]);
                        ogsk[i] = string.Format("({0} + {1})", ogsk[i], ogsk[l]);
                        Istrinti(l);
                        laikinas[tmp] = '-';
                        dvej[i] = laikinas.ToString();
                        minitxt = minitxt + string.Format("= {0}", dvej[i])+"\n";
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
            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i].CompareTo(a2[i]) != 0)
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
}