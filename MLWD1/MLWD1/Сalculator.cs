using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLWD1
{
    internal class Calculator
    {
        public double firstOperand { get; set; }
        public bool OperatorExpected { get; set; }
        public double MemoryValue { get; set; }
        public bool IsClear { get; set; }
        public bool MemoryIsEmpty { get; set; }
        public string LastPostfix { get; set; }
        public Calculator()
            => (firstOperand, OperatorExpected, MemoryValue, IsClear, MemoryIsEmpty, LastPostfix)
            = (0, true, 0, true, true, "");
        public void ClearMemory()
            => MemoryValue = 0;
        public void AddMemory(double val)
            => MemoryValue += val;
        public void SubstractMemory(double val)
            => MemoryValue -= val;

    }
}
