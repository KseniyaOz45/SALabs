using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Watcher_Console : IObserver
    {
        public string Name;
        IObservable_Console stock;

        public delegate void MethodContainer();
        public event MethodContainer onCount;

        public Watcher_Console(string name, IObservable_Console obs)
        {
            this.Name = name;
            stock = obs;
            stock.RegisterObserver(this);
        }

        public int Update_Console(object ob)
        {
            Game_Console console = (Game_Console)ob;
            Handler handler = new Handler();
            Show(this, handler);
            return Game_Console.Size_HDD;
        }

        public int Update_Mobile(object ob)
        {
            Game_Console console = (Game_Console)ob;
            Handler handler = new Handler();
            Show(this, handler);
            return Game_Console.Size_HDD;
        }

        public int Update_PC(object ob)
        {
            Game_Console console = (Game_Console)ob;
            Handler handler = new Handler();
            Show(this, handler);
            return Game_Console.Size_HDD;
        }

        public void Stop()
        {
            stock.RemoveObserver(this);
            stock = null;
        }

        public void Show(Watcher_Console sender, Handler e)
        {
            sender.onCount();
        }
    }
}
