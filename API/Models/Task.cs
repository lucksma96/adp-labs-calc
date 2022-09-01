using System;

namespace API.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Operation { get; set; }
        public long Left { get; set; }
        public long Right { get; set; }
        public float Result { get; set; }
    }
}

