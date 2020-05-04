using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Game_Actions : IGame_Functions
    {
        static void Main(string[] args)
        {
           
        } 
        public void Exit_Game(Game game)
        {
            game.Started = false;
        }

        public bool Load_Game(Game game)
        {
            bool Game_Memory_State = false;
            if (game.Game_Memory!=0)
            {
                Game_Memory_State = true;
            }
            return Game_Memory_State;
        }

        public void Obl_Zapis(string ID, string Password, Game game)
        {

            if (!game.Autoriz) {
                game.ID = ID;
                game.Password = Password;
                game.Autoriz = true;

            }
            else
            {
                if (game.ID == ID && game.Password == Password)
                {
                    game.Autoriz = true;
                }
            }

        }

        public void Set_Raiting(Game game,float Raiting)
        {
            game.Raiting = Raiting;
        }

        public bool Save_Game(Game game)
        {
            game.Game_Memory += 1;
            return true;
        }

        public void Start_Game_PC(List<Game> all_games, int Game_Number,PC pC)
        {
            
                if (all_games[Game_Number].Ganres.Contains("Online adventures"))
                {
                    if (pC.Internet)
                    {
                        if (!all_games[Game_Number].Started)
                        {
                            if (pC.Processor >= all_games[Game_Number].Processor[0] && pC.Oper_Memory >= all_games[Game_Number].Oper_memory[0] &&
                            pC.Video_Card >= all_games[Game_Number].Video_cart[0]) //&& pC.Size_HDD >= game.Sise_HDD[0])
                            {
                                all_games[Game_Number].Started = true;
                            }
                        }
                    }
                }
                else
                {
                    if(pC.games[Game_Number].Installed)
                    {
                        if (!pC.games[Game_Number].Started) {
                            if (pC.Processor >= pC.games[Game_Number].Processor[0] && pC.Oper_Memory >= pC.games[Game_Number].Oper_memory[0] &&
                                pC.Video_Card >= pC.games[Game_Number].Video_cart[0])// && pC.Size_HDD >= game.Sise_HDD[0])
                            {
                                pC.games[Game_Number].Started = true;
                            }
                        }
                    }
                }
            
        }

        public void Start_Game_Mobile(List<Game> all_games, int Game_Number, Mobile mobile)
        {
            
                if (all_games[Game_Number].Ganres.Contains("Online adventures"))
                {
                    if (mobile.Internet)
                    {
                        if (!all_games[Game_Number].Started)
                        {
                            if (mobile.Processor >= all_games[Game_Number].Processor[0] && mobile.Oper_Memory >= all_games[Game_Number].Oper_memory[0] &&
                            mobile.Video_Chip >= all_games[Game_Number].Video_cart[0])// && mobile.Internal_Memory >= game.Sise_HDD[1])
                            {
                                all_games[Game_Number].Started = true;
                            }
                        }
                    }
                }
                else
                {
                    if (mobile.games[Game_Number].Installed)
                    {
                        if (!mobile.games[Game_Number].Started)
                        {
                            if (mobile.Processor >= mobile.games[Game_Number].Processor[0] && mobile.Oper_Memory >= mobile.games[Game_Number].Oper_memory[0] &&
                            mobile.Video_Chip >= mobile.games[Game_Number].Video_cart[0])// && mobile.Internal_Memory >= game.Sise_HDD[1])
                            {
                                mobile.games[Game_Number].Started = true;
                            }
                        }
                    }
                }
            
        }

        public void Start_Game_Console( List<Game> all_games,int Game_Number,Game_Console console)
        {
            
                if (all_games[Game_Number].Ganres.Contains("Online adventures"))
                {
                    if (console.Internet)
                    {
                        if (!all_games[Game_Number].Started)
                        {
                            if (console.Processor >= all_games[Game_Number].Processor[0] && console.Oper_Memory >= all_games[Game_Number].Oper_memory[0] &&
                            console.PZU >= all_games[Game_Number].Video_cart[0])// && console.Size_HDD >= game.Sise_HDD[2])
                            {
                                all_games[Game_Number].Started = true;
                            }
                        }
                    }
                }
                else
                {
                    if (console.games[Game_Number].Installed)
                    {
                        if (!console.games[Game_Number].Started)
                        {
                            if (console.Processor >= console.games[Game_Number].Processor[0] && console.Oper_Memory >= console.games[Game_Number].Oper_memory[0] &&
                            console.PZU >= console.games[Game_Number].Video_cart[0])// && console.Size_HDD >= game.Sise_HDD[2])
                            {
                                console.games[Game_Number].Started = true;
                            }
                        }
                    }
                }
            
        }
    }
}
