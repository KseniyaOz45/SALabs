using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Handler
    {
        public void Message_PC()
        {
            Console.WriteLine("pC.Size_HDD = "+PC.Size_HDD);
        }

        public void Message_Mobile()
        {
            Console.WriteLine("mobile.Internal_Memory = " + Mobile.Internal_Memory);
        }

        public void Message_Console()
        {
            Console.WriteLine("console.Size_HDD = " + Game_Console.Size_HDD);
        }
    }
}
