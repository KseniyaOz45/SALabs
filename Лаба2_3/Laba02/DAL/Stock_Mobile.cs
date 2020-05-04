using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Stock_Mobile : IObservable_Mobile
    {
        Mobile mobile;
        List<IObserver> observers;

        public Stock_Mobile(Mobile mobile)
        {
            observers = new List<IObserver>();
            this.mobile = mobile;
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update_Mobile(mobile);
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
