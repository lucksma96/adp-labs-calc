using System;
using System.Numerics;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class TaskResultDTO
    {
        public Guid Id { get; set; }
        public object Result { get; set; }
    }
}

