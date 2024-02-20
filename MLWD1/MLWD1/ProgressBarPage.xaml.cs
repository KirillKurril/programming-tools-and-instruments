using System.Threading;

namespace MLWD1;

public partial class ProgressBarPage : ContentPage
{
	CancellationTokenSource cancellationTokenSource;
	Integrator integrator;
	CancellationToken cancellationToken;

    public ProgressBarPage()
	{
		InitializeComponent();
        cancellationTokenSource = new CancellationTokenSource();
        integrator = new Integrator();
        cancellationToken = cancellationTokenSource.Token;

		integrator.ProgressChanged += (sender, percent)
			=> { 
                Bar.Progress = percent;
				Status.Text = "Вычисление";
			};

		integrator.CalculationCompleted += (sender, result)
			=> Status.Text = $"Результат вычислений: {result}";
    }

	private void StartProgressBar(object sender, EventArgs e)
    {
        Task.Run(async () =>
        {
            try
            {
                await integrator.CalculateIntegral(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                Status.Text = "Вычисление прервано";
                Bar.Progress = 0;
            }
        });
    }
	private void CancelProgressBar(object sender, EventArgs e)
	{
        cancellationTokenSource.Cancel();
    }
}