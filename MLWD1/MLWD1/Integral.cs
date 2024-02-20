using System.Diagnostics;
using System.Data;
using System.Diagnostics;
using System.Threading;

namespace MLWD1
{
    public class Integrator
    {
        public event EventHandler<double> CalculationCompleted;
        public event EventHandler<double> ProgressChanged;

        private int bottom = 0;
        private int top = 1;
        private double step = 0.000001;

        public Integrator() { }

        public async Task CalculateIntegral(CancellationToken token)
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

                    double percent = (progress - bottom) / (top - bottom);

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
