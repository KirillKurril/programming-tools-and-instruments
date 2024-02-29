using System.Diagnostics;
using System.Data;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MLWD
{
    public class Integrator : INotifyPropertyChanged
    {
        private int bottom;
        private int top;
        private double progress;
        private double step;
        private double result;

        public double Progress
        {
            get => progress;
            set
            {
                progress = value;
                OnPropertyChanged();
            }
        }
        public double Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public Integrator() => (bottom, top, Result, step) = (0, 1, 0, 0.002);

        public async Task CalculateIntegral(CancellationToken token)
        {
            Progress = bottom;
            Result = 0;


            while (Progress < top)
            {
                await Task.Delay(1, token);
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }

                Result += Math.Sin(Progress) * step;
                Progress += step;

                double percent = Math.Floor((Progress - bottom) / (top - bottom) * 100) / 100;
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
