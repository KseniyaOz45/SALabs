using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PC:Console_Rod
    {
        public int Video_Card;
        public static int Size_HDD;


        public PC()
        {
            games = new List<Game>();
        }

    }
}
