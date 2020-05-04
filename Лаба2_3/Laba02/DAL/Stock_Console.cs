using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Stock_Console : IObservable_Console
    {
        Game_Console console;
        List<IObserver> observers;

        public Stock_Console(Game_Console console)
        {
            observers = new List<IObserver>();
            this.console = console;
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update_Console(console);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Start_Notify()
        {
            NotifyObservers();
        }
    }
}
