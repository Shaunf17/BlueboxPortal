using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueboxPortal.Models
{
    public class ServiceRun
    {
        public Airline airline { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int NewFiles { get; set; }

        public int DuplicateFiles { get; set; }

        public int UniqueDevices { get; set; }

        public int NewDevices { get; set; }

        public int CDRCount { get; set; }
    }
}