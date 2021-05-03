using Microsoft.AspNetCore.Mvc;
using MVCIntroductionSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCIntroductionSample.Controllers
{
    public class DataController : Controller
    {
        //Die Aufgaben des Controllers:

        // 1) Daten an View durchreichen
        private IList<Person> persons = new List<Person>();

        //ctor + tab + tab ->Constructor-Shortcut
        public DataController()
        {
            //Liste kommt aus ServiceLayer (WebAPI, WCF)
            persons.Add(new Person { Id = 1, FirstName = "Kevin", LastName = "Winter" });
            persons.Add(new Person { Id = 2, FirstName = "Frauke", LastName = "Muster" });
            persons.Add(new Person { Id = 3, FirstName = "Karin", LastName = "Sommer" });
            persons.Add(new Person { Id = 4, FirstName = "Hannes", LastName = "Preishuber" });
        }

        //GET
        [HttpGet]
        public IActionResult Index() //Darstellen einer List in Form einer Tabelle
        {
            //Liste wird an View übergeben
            return View(persons);
        }

        //GET
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            Person currentPerson = persons.Single(n => n.Id == id.Value);

            if (currentPerson == null)
                return NotFound();

            return View(currentPerson);
        }


        #region First Formular Sample
        //Get Methode
        public IActionResult FormularSample()
        {
            return View();
        }

        [HttpPost]
        //Post-Methode
        public IActionResult ProcessFormular(string submit)
        {
            switch(submit)
            {
                case "Save":
                    //Machwas
                    break;
                case "Cancel":
                    break;
            }

            return RedirectToAction("Index");
        }


        #endregion

        //Get Methode
        public IActionResult SecondFormularSample()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveForm()
        {
            //Machwas

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CancelForm()
        {
            //Machwas
            return RedirectToAction("Index");
        }
    }
}
