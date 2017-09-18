using System.Threading;

namespace Lab3_MPP
{
    public class Mutex
    {
        private Thread lockingThread;

        public void Lock()
        {
            while (Interlocked.CompareExchange(ref lockingThread, Thread.CurrentThread, null) != null)
                Thread.Yield();
        }

        public void Unlock()
        {
            Interlocked.Exchange(ref lockingThread, null);
        }
    }
}
