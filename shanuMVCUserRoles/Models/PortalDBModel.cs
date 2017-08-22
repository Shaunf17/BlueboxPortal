using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlueboxPortal.Models;
using System.Threading;
using System.Collections;

namespace BlueboxPortal.Models
{
    public class PortalDBModel
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Airline> Airlines { get; set; } 
        public List<ServiceRun> ServiceRuns { get; set; }

        public PortalDBModel()
        {
            //Airlines = new List<Airline>();
            Airlines = db.Airline.ToList();
            ServiceRuns = new List<ServiceRun>();
        }

        public void populateServiceRuns()
        {
            Random rnd = new Random();
            

            foreach(var airline in Airlines)
            {
                var now = DateTime.Now.AddSeconds(rnd.Next(0, 1000));
                ServiceRuns.Add(new ServiceRun
                {
                    Start = now,
                    End = now.AddSeconds(rnd.Next(0, 1000)),
                    airline = airline,
                    CDRCount = rnd.Next(900, 9000),
                    DuplicateFiles = rnd.Next(0, 50),
                    NewDevices = rnd.Next(0, 15),
                    NewFiles = rnd.Next(0,55),
                    UniqueDevices = rnd.Next(0, 150)
                });
            }  
        }

        public ServiceRun getServiceRunForAirline(Airline candidate)
        {
            foreach(var sr in ServiceRuns)
            {
                if (sr.airline.Name.Equals(candidate.Name))
                {
                    return sr;
                }
            }
            return null;
        }
    }
}