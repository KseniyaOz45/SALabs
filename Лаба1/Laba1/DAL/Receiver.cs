using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Command_commands;

namespace DAL
{
    public class Receiver
    {
        Command command = new Add_Elem();
        Command command2 = new Delete_Elem();

        public void Run_Command_Add()
        {
            command.Execute();
        }

        public void Run_Command_Del()
        {
            command2.Execute();
        }

    }
}
