using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineRadarAI.Api.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSuccesful { get; set; } = true;

        public string Message { get; set; } = string.Empty;
    }
}