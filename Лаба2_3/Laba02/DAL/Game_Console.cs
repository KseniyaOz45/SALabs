using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Game_Console:Console_Rod
    {
        public int PZU;
        public static int Size_HDD;
        public bool Controller; 

        public Game_Console()
        {
            games = new List<Game>();
            Controller = false;
        }
    }
}
