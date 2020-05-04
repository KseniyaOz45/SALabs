using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Watcher_Mobile : IObserver
    {
        public string Name;
        IObservable_Mobile stock;

        public delegate void MethodContainer();
        public event MethodContainer onCount;

        public Watcher_Mobile(string name, IObservable_Mobile obs)
        {
            this.Name = name;
            stock = obs;
            stock.RegisterObserver(this);
        }

        public int Update_Console(object ob)
        {
            Mobile mobile = (Mobile)ob;
            Handler handler = new Handler();
            Show(this, handler);
            return PC.Size_HDD;
        }

        public int Update_Mobile(object ob)
        {
            Mobile mobile = (Mobile)ob;
            Handler handler = new Handler();
            Show(this, handler);
            return PC.Size_HDD;
        }

        public int Update_PC(object ob)
        {
            Mobile mobile = (Mobile)ob;
            Handler handler = new Handler();
            Show(this, handler);
            return PC.Size_HDD;
        }

        public void Stop()
        {
            stock.RemoveObserver(this);
            stock = null;
        }

        public void Show(Watcher_Mobile sender, Handler e)
        {
            sender.onCount();
        }
    }
}
