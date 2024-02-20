namespace MLWD1
{
    public partial class MainPage : ContentPage
    {
        private Calculator calculator;

        public MainPage()
        {
            InitializeComponent();
            calculator = new Calculator();
        }

        private void Evaluate()
        {
            NCalc.Expression expr = new NCalc.Expression(Screen.Text.Replace(',', '.'));
            calculator.firstOperand = Convert.ToDouble(expr.Evaluate());
            Screen.Text = $"{calculator.firstOperand}";
            calculator.OperatorExpected = true;
        }

        private void ClearScreen()
        {
            Screen.Text = "";
            calculator.firstOperand = 0;
            calculator.IsClear = true;
        }

        private void InvalidExpression()
        {
            Screen.Text = "Incorrect expression";
            calculator.firstOperand = 0;
            calculator.IsClear = true;
        }
        private bool SecondOperandExpected() => Screen.Text.Length == calculator.firstOperand.ToString().Length + 3;

        private void OneOperandFunction(Func<double, double> func)
        {
            if (!calculator.IsClear)
            {
                if (calculator.OperatorExpected)
                {
                    calculator.firstOperand = func(Convert.ToDouble(Screen.Text));
                    if (double.IsNaN(calculator.firstOperand))
                    {
                        InvalidExpression();
                        return;
                    }
                    Screen.Text = calculator.firstOperand.ToString();
                }
                else if (SecondOperandExpected())
                    Screen.Text += func(calculator.firstOperand).ToString();
                else
                    if (Screen.Text[Screen.Text.LastIndexOf(' ') + 1] != '(')
                {
                    Screen.Text = Screen.Text.Substring(0, Screen.Text.LastIndexOf(" ")) + ' ' +
                        func(Convert.ToDouble(Screen.Text.Substring(Screen.Text.LastIndexOf(" ") + 1,
                    Screen.Text.Length - Screen.Text.LastIndexOf(" ") - 1))).ToString();
                }
                else
                    InvalidExpression();
            }
        }

        private void NumberButtonClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Screen.Text) && char.IsLetter(Screen.Text[0]))
                ClearScreen();
            Screen.Text += ((Button)sender).Text;
            if (calculator.IsClear)
                calculator.IsClear = false;
        }


        private void TwoOperandsAction(object sender, EventArgs e)
        {
            if (!SecondOperandExpected() && !calculator.IsClear)
            {
                if (calculator.OperatorExpected)
                {
                    calculator.firstOperand = Convert.ToDouble(Screen.Text);
                    Screen.Text += $" {((Button)sender).Text} ";
                    calculator.OperatorExpected = false;
                }
                else
                {
                    Evaluate();
                    TwoOperandsAction(sender, e);
                }
            }
        }

        private void Equals(object sender, EventArgs e)
        {
            if (!calculator.IsClear)
            {
                if (calculator.OperatorExpected)
                    Screen.Text += calculator.LastPostfix;
                else
                    calculator.LastPostfix = Screen.Text.Substring(Screen.Text.IndexOf(' '), Screen.Text.Length - calculator.firstOperand.ToString().Length);
                Evaluate();
            }
        }
        private void Percent(object sender, EventArgs e)
        {
            if (calculator.OperatorExpected)
                InvalidExpression();
            else
            {
                string expr = Screen.Text;
                string SecondOperand = expr.Substring(expr.LastIndexOf(" ") + 1);
                Screen.Text = expr.Substring(0, expr.LastIndexOf(" ")) + ' ' + (calculator.firstOperand * Convert.ToDouble(SecondOperand) / 100).ToString();
            }
        }
        private void ClearEntry(object sender, EventArgs e)
        {
            if (calculator.OperatorExpected)
                ClearScreen();
            else
                Screen.Text = Screen.Text.Substring(0, Screen.Text.LastIndexOf(' '));
        }
        private void Clear(object sender, EventArgs e) => ClearScreen();
        private void RemoveLastSymbol(object sender, EventArgs e)
        {
            if (!calculator.IsClear)
                Screen.Text = Screen.Text.Substring(0, Screen.Text.Length - 1);
        }
        private void Reciprocal(object sender, EventArgs e) => OneOperandFunction((x) => 1 / x);
        private void SquarePower(object sender, EventArgs e) => OneOperandFunction((x) => Math.Pow(x, 2));
        private void SquareRoot(object sender, EventArgs e) => OneOperandFunction((x) => Math.Sqrt(x));
        private void ChangeSign(object sender, EventArgs e)
        {
            if (!calculator.IsClear)
            {
                if (calculator.OperatorExpected)
                {
                    if (Screen.Text[0] == '-')
                        Screen.Text = Screen.Text.Substring(1, Screen.Text.Length - 1);
                    else
                        Screen.Text = '-' + Screen.Text;
                }
                else
                {
                    int SecOpInd = Screen.Text.LastIndexOf(' ');
                    int PostfixLenght = Screen.Text.Length - SecOpInd - 1;
                    if (Screen.Text[SecOpInd - 1] == '-')
                        Screen.Text = Screen.Text.Substring(0, SecOpInd - 1) + "+" + Screen.Text.Substring(SecOpInd);
                    else if (Screen.Text[SecOpInd - 1] == '+')
                        Screen.Text = Screen.Text.Substring(0, SecOpInd - 1) + "-" + Screen.Text.Substring(SecOpInd);
                    else
                        Screen.Text = Screen.Text.Substring(0, SecOpInd + 1) + "(-" + Screen.Text.Substring(SecOpInd + 1) + ")";
                }
            }
        }
        private void Comma(object sender, EventArgs e)
        { if (!calculator.IsClear && Screen.Text.IndexOf(',') == -1) Screen.Text += ","; }

        private void MemoryClear(object sender, EventArgs e) => calculator.MemoryIsEmpty = true;
        private void MemoryGet(object sender, EventArgs e)
        {
            if (!calculator.MemoryIsEmpty)
            {
                if (SecondOperandExpected())
                    Screen.Text += calculator.MemoryValue.ToString();
                else
                {
                    ClearScreen();
                    Screen.Text = calculator.MemoryValue.ToString();
                }
            }
        }
        private void MemoryAdd(object sender, EventArgs e)
        {
            if (!calculator.IsClear)
            {
                calculator.MemoryIsEmpty = false;
                if (Screen.Text.Length > calculator.firstOperand.ToString().Length + 2)
                    calculator.MemoryValue += Convert.ToDouble(Screen.Text.Substring(Screen.Text.LastIndexOf(' ')));
                else if (Screen.Text.Length > calculator.firstOperand.ToString().Length)
                    calculator.MemoryValue += Convert.ToDouble(Screen.Text.Substring(0, Screen.Text.IndexOf(' ')));
                else
                    calculator.MemoryValue += Convert.ToDouble(Screen.Text);
            }
        }
        private void MemorySub(object sender, EventArgs e)
        {
            if (!calculator.IsClear)
            {
                calculator.MemoryIsEmpty = false;
                if (Screen.Text.Length > calculator.firstOperand.ToString().Length + 2)
                    calculator.MemoryValue -= Convert.ToDouble(Screen.Text.Substring(Screen.Text.LastIndexOf(' ')));
                else if (Screen.Text.Length > calculator.firstOperand.ToString().Length)
                    calculator.MemoryValue -= Convert.ToDouble(Screen.Text.Substring(0, Screen.Text.IndexOf(' ')));
                else
                    calculator.MemoryValue -= Convert.ToDouble(Screen.Text);
            }
        }
        private void MemorySet(object sender, EventArgs e)
        {
            if (!calculator.IsClear)
            {
                calculator.MemoryIsEmpty = false;
                if (Screen.Text.Length > calculator.firstOperand.ToString().Length + 2)
                    calculator.MemoryValue = Convert.ToDouble(Screen.Text.Substring(Screen.Text.LastIndexOf(' ')));
                else if (Screen.Text.Length > calculator.firstOperand.ToString().Length && Screen.Text.IndexOf(' ') > 0)
                    calculator.MemoryValue = Convert.ToDouble(Screen.Text.Substring(0, Screen.Text.IndexOf(' ')));
                else
                    calculator.MemoryValue = Convert.ToDouble(Screen.Text);
            }
        }
        private void TwoPower(object sender, EventArgs e) => OneOperandFunction((x) => Math.Pow(2, x));
    }

}
