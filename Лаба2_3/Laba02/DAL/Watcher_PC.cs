using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Watcher_PC : IObserver
    {
        public string Name;
        IObservable_PC stock;

        public delegate void MethodContainer();
        public event MethodContainer onCount;

        public Watcher_PC(string name,IObservable_PC obs)
        {
            this.Name = name;
            stock = obs;
            stock.RegisterObserver(this);
        }

        public int Update_Console(object ob)
        {
            PC pC = (PC)ob;
            Handler handler = new Handler();
            Show(this, handler);
            return PC.Size_HDD;
        }

        public int Update_Mobile(object ob)
        {
            PC pC = (PC)ob;
            Handler handler = new Handler();
            Show(this, handler);
            return PC.Size_HDD;
        }

        public int Update_PC(object ob)
        {
            PC pC = (PC)ob;
            Handler handler = new Handler();
            Show(this,handler);
            return PC.Size_HDD;
        }

        public void Stop()
        {
            stock.RemoveObserver(this);
            stock = null;
        }

        public void Show(Watcher_PC sender, Handler e)
        {
            sender.onCount();
        }
    }
}
