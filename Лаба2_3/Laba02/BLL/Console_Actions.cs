using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Console_Actions : IConsole_Functions
    {
        public bool Install_Game_Console(Game game, Game_Console console)
        {
            bool Inst = false;
            if (Game_Console.Size_HDD >= game.Sise_HDD[0])
            {
                Game_Console.Size_HDD -= game.Sise_HDD[0];
                game.Installed = true;
                console.games.Add(game);
                Inst = true;
            }
            return Inst;
            
        }

        public bool Install_Game_Mobile(Game game, Mobile mobile)
        {
            bool Inst = false;
            if (Mobile.Internal_Memory >= game.Sise_HDD[0])
            {
                Mobile.Internal_Memory -= game.Sise_HDD[0];
                game.Installed = true;
                mobile.games.Add(game);
                Inst = true;
            }
            return Inst;
        }

        public bool Install_Game_PC(Game game, PC pC)
        {
            bool Inst = false;
            if (PC.Size_HDD >= game.Sise_HDD[0])
            {
                PC.Size_HDD -= game.Sise_HDD[0];
                game.Installed = true;
                pC.games.Add(game);
                Inst = true;
            }
            return Inst;
        }

        public void On_Off_Internet_PC(PC pC)
        {
            if (!pC.Internet)
            {
                pC.Internet = true;
            }
            else if(pC.Internet)
            {
                pC.Internet = false;
            }
            
        }

        public void On_Off_Internet_Mobile(Mobile mobile)
        {
            if (!mobile.Internet)
            {
                mobile.Internet = true;
            }
            else if (mobile.Internet)
            {
                mobile.Internet = false;
            }
        }

        public void On_Off_Internet_Console(Game_Console console)
        {
            if (!console.Internet)
            {
                console.Internet = true;
            }
            else if (console.Internet)
            {
                console.Internet = false;
            }
        }
    }
}
