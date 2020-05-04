using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Stock_PC : IObservable_PC
    {
        PC pC;
        List<IObserver> observers;

        public Stock_PC(PC PC)
        {
            observers = new List<IObserver>();
            pC = PC;
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update_PC(pC);
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
