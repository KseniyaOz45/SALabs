using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public interface IGame_Functions
    {
        void Obl_Zapis(string ID,string Password,Game game);
        bool Save_Game(Game game);
        bool Load_Game(Game game);
        void Exit_Game(Game game);
        void Set_Raiting(Game game,float Raiting);
        void Start_Game_PC(List<Game> all_games,int Game_Number,PC pC);
        void Start_Game_Mobile(List<Game> all_games, int Game_Number,Mobile mobile);
        void Start_Game_Console(List<Game> all_games, int Game_Number, Game_Console console);
    }
}
