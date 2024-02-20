using System.Threading;

namespace MLWD1;

public partial class ProgressBarPage : ContentPage
{
	CancellationTokenSource? cancellationTokenSource;
	Integrator integrator;
	CancellationToken cancellationToken;

    public ProgressBarPage()
	{
		InitializeComponent();
        integrator = new Integrator();
        cancellationTokenSource = new CancellationTokenSource();
        cancellationToken = cancellationTokenSource.Token;

        StartButton.IsEnabled = true;
        CancelButton.IsEnabled = false;

        Status.BindingContext = integrator;
        Status.SetBinding(Label.TextProperty, "Result", stringFormat: "Результат вычислений: {0}");

        Binding percentBinding = new Binding { Source = integrator, Path = "Progress" };
        Bar.SetBinding(ProgressBar.ProgressProperty, percentBinding);
    }

	private async void StartProgressBar(object sender, EventArgs e)
    {
      
            try
            {
                await integrator.CalculateIntegral(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                Bar.Progress = 0;
            }
    }
	private void CancelProgressBar(object sender, EventArgs e)
	{
        cancellationTokenSource?.Cancel();
        Status.Text = "Вычисление прервано!";
        CancelButton.IsEnabled = false;
        StartButton.IsEnabled = true;
    }
}



/*integrator.ProgressChanged += (sender, percent)
			=> { 
                Bar.Progress = percent;
				Status.Text = "Вычисление";
			};

integrator.CalculationCompleted += (sender, result)
    => Status.Text = $"Результат вычислений: {result}";*/