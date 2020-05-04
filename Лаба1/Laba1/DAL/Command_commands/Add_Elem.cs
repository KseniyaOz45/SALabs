using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Command_commands
{
    public class Add_Elem : Command
    {
        public void Execute()
        {
            for (int i = 0; i < Objects.array.Length; i++)
            {
                Objects.array[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}
