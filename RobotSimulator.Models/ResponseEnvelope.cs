using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Models
{
    public class ResponseEnvelope<T> where T : class, new()
    {
        public Boolean Flag { get; set; }
        public T ResponseBody { get; set; }
    }
}
