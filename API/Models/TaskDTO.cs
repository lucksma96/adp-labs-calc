using System;
using System.Numerics;
using API.Utils;

namespace API.Models
{
    public class TaskDTO
    {
        public Guid Id { get; set; }
        public string Operation { get; set; }
        public long Left { get; set; }
        public long Right { get; set; }
        public object Result { get; set; }
    }
}

