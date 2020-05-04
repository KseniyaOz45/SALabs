using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public interface IConsole_Functions
    {
        bool Install_Game_PC(Game game, PC pC);
        bool Install_Game_Mobile(Game game, Mobile mobile);
        bool Install_Game_Console(Game game, Game_Console console);
        void On_Off_Internet_PC(PC pC);
        void On_Off_Internet_Mobile(Mobile mobile);
        void On_Off_Internet_Console(Game_Console console);
    }
}
