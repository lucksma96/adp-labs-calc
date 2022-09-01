﻿using System;
using System.Numerics;

namespace API.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Operation { get; set; }
        public long Left { get; set; }
        public long Right { get; set; }
        public object Result { get; set; }
    }
}

