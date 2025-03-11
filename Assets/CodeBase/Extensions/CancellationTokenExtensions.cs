using System.Threading;

namespace CodeBase.Extensions
{
    public static class CancellationTokenExtensions
    {
        public static void Cleanup(this CancellationTokenSource cancellationTokenSource)
        {
            if (cancellationTokenSource != null)
            {
                if (!cancellationTokenSource.IsCancellationRequested)
                    cancellationTokenSource.Cancel();

                cancellationTokenSource.Dispose();
            }
        }

        
        public static CancellationTokenSource PutOn(this CancellationTokenSource cancellationTokenSource)
        {
            if (cancellationTokenSource == null || cancellationTokenSource.IsCancellationRequested)
                cancellationTokenSource = new();

            return cancellationTokenSource;
        }
    }
}