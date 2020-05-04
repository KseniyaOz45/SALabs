using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Mobile:Console_Rod
    {
        public int Video_Chip;
        public static int Internal_Memory;

        public Mobile()
        {
            games = new List<Game>();
        }
    }
}
