using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Final.Interfaces;
using OOD_Final.Notifications;

namespace OOD_Final
{
    public class EventNotifier : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            if (observer == null) throw new ArgumentNullException(nameof(observer));
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(string eventMessage, bool isDeathNofication = false)
        {
            bool dead = isDeathNofication;
            foreach (var observer in _observers)
            {
                if (observer is Sound && !dead)
                {
                    continue; // skip sound notification for non-death
                }

                if (observer is HUD && dead)
                {
                    continue; // skip hud notification for death
                }

                observer.Update(eventMessage);
            }
        }
    }
}
