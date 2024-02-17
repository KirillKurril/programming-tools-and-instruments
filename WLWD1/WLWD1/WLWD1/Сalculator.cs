using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLWD1
{
    internal class Calculator
    {
        private double firstOperand { get; set; }
        private bool secondOperatorExpected { get; set; }

        private char lastOperator;
        private double memoryValue { get; set; }
        public Calculator()
            => (firstOperand, secondOperatorExpected, lastOperator) = (0, false, '\0');
        public void ClearMemory()
            => memoryValue = 0;
        public void AddMemory(double val)
            => memoryValue += val;
        public void SubstractMemory(double val)
            => memoryValue -= val;


    }
}
