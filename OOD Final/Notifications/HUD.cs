using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Final.Interfaces;

namespace OOD_Final.Notifications
{
    public class HUD : IObserver
    {
        public void Update(string eventNotification)
        {
            Console.WriteLine($"HUD Notification: {eventNotification}");
        }
    }
}
