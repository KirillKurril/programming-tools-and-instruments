using System.Threading;

namespace MLWD;

public partial class ProgressBarPage : ContentPage
{
    CancellationTokenSource? cancellationTokenSource;
    Integrator integrator;
    CancellationToken cancellationToken;

    public ProgressBarPage()
    {
        InitializeComponent();
        integrator = new Integrator();

    }

    private async void StartProgressBar(object sender, EventArgs e)
    {
        cancellationTokenSource = new CancellationTokenSource();
        cancellationToken = cancellationTokenSource.Token;
        Status.BindingContext = integrator;
        Status.SetBinding(Label.TextProperty, "Result", stringFormat: "Результат вычислений: {0}");

        Binding percentBinding = new Binding { Source = integrator, Path = "Progress" };
        Bar.SetBinding(ProgressBar.ProgressProperty, percentBinding);

        StartButton.IsEnabled = false;
        CancelButton.IsEnabled = true;

        try
        {
            await integrator.CalculateIntegral(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            Bar.Progress = 0;
        }
        StartButton.IsEnabled = true;
        CancelButton.IsEnabled = false;
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