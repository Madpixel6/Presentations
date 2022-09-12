using System;
using System.Threading;

namespace MemLeakEvents.LiveStack
{
    public class NotificationsPusher
    {
        public NotificationsPusher()
        {
            var timer = new Timer(PushTick);
            timer.Change(TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(3));
        }
        private static void PushTick(object state)
        {
        
        }

    }
}