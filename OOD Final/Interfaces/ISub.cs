using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final.Interfaces
{
    public abstract class ISub
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void AddSub(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveSub(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string eventMess)
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(eventMess);
            }
        }
    }
}
