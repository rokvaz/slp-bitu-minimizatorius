using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slp_bitu_minifikatorius
{
    internal class Lentele
    {
        public int[,] data { get; set; }

        public Lentele()
        {
            data = new int[112, 112];
            for (int i=0;i<112;i++)
                for(int j=0;j<112;j++)
                    data[i, j] = 0;
        }
    }
}
