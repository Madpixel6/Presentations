using System;
using System.Threading;

namespace MemLeakEvents.LiveStack
{
    public class TicksCounter : IDisposable
    {
        private int _tickCounter = 0;
        public TicksCounter()
        {
            var timer = new Timer(PushTick);
            timer.Change(TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(3));
        }
        private void PushTick(object state)
        {
            _tickCounter++;
        }
        public int GetTicks()
            => _tickCounter;

        public void Dispose()
        {
        }
    }
}