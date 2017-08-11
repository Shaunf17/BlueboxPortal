using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Web.Mvc;
using BlueboxPortal4.Models;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace BlueboxPortal4.Controllers
{
    public class AirlineController : Controller
    {
        AirlineContext context;

        public AirlineController()
        {
            context = new AirlineContext();
        }

        // GET: Airline
        public ActionResult Index()
        {
            return View();
        }

        // GET: AirlineModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AirlineModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,NameAlias,FriendlyName,DisplayName,DbName,SSRSFolder")] Airline airlineModels)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Airline.Add(airlineModels);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }

            return View(airlineModels);
        }
    }
}