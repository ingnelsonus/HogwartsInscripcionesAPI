using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsSchool.Api.Bussiness.Models
{
    public class ApiStandardResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public long Count { get; set; }
    }
}
