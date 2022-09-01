using System;
using API.Utils;

namespace API.Utils
{
    public class OperationType : Enumeration
    {
        public static OperationType Addition = new OperationType(1, "addition");
        public static OperationType Subtraction = new OperationType(2, "subtraction");
        public static OperationType Multiplication = new OperationType(3, "multiplication");
        public static OperationType Remainder = new OperationType(4, "remainder");
        public static OperationType Division = new OperationType(5, "division");

        public OperationType(int id, string name) : base(id, name) { }
    }
}

