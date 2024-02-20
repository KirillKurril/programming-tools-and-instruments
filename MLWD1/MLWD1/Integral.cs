using System.Diagnostics;
using System.Data;
using System.Threading;

namespace MLWD1
{
    public class Integrator
    {
        public event EventHandler<double> CalculationCompleted;
        public event EventHandler<double> ProgressChanged;

        private int bottom;
        private int top;
        private double step;

        public Integrator() => (bottom, top, step) = (0, 1, 0.00005);

        public async Task /*void*/ CalculateIntegral(CancellationToken token)
        {
            double progress = bottom;
            double result = 0;

            await Task.Run(() =>
            {
                while (progress < top)
                {
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }

                    result += Math.Sin(progress) * step;
                    progress += step;

                    double percent = Math.Floor((progress - bottom) / (top - bottom) * 100) / 100;

                    OnProgressChanged(percent);
                }
            }, token);

            OnCalculationCompleted(result);
        }
        private void OnCalculationCompleted(double result)
            => CalculationCompleted?.Invoke(this, result);

        private void OnProgressChanged(double percent)
            => ProgressChanged?.Invoke(this, percent);
    }
}
