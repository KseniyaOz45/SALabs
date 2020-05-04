using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DAL
{
    public class Game
    {
        public string Name;
        public List<string> Ganres;
        public List<string> Platforms;
        public List<int> Processor;
        public List<int> Oper_memory;
        public List<int> Video_cart;
        public List<int> Sise_HDD;
        public string ID;
        public string Password;
        public bool Installed;
        public bool Started;
        public bool Autoriz;
        public float Raiting;
        public int Game_Memory;

        public Game(string name)
        {
            Name = name;
            Ganres = new List<string>();
            Platforms = new List<string>();
            Processor = new List<int>();
            Oper_memory = new List<int>();
            Video_cart = new List<int>();
            Sise_HDD = new List<int>();
        }

        //public Game(string[] ganr, string name)
        //{
        //    Ganres = ganr;
        //    Name = name;
        //}
    }
        
    
}
