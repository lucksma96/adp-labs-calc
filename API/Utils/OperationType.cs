using System;
using API.Utils;
using System.Numerics;

namespace API.Utils
{
    public class OperationType : Enumeration
    {
        public Func<long, long, object> DoOperation { get; set; }

        public static OperationType Addition = new OperationType(1, "addition", (a, b) => a + b);
        public static OperationType Subtraction = new OperationType(2, "subtraction", (a, b) => a - b);
        public static OperationType Multiplication = new OperationType(3, "multiplication", (a, b) => BigInteger.Multiply(a, b));
        public static OperationType Remainder = new OperationType(4, "remainder", (a, b) => a % b);
        public static OperationType Division = new OperationType(5, "division", (a, b) => a / (decimal)b);

        public OperationType(int id, string name, Func<long, long, object> operationFunc)
            : base(id, name)
        {
            DoOperation = operationFunc;
        }
    }
}

