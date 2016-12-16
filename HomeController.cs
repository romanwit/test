using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rate_client.Models;
  
namespace rate_client.Controllers
{
    public class HomeController : Controller
    {
        RateContext db = new RateContext();
        
        /// <summary>
        /// main method to show a view
        /// </summary>
        /// <returns>view index.cshtml</returns>
        public ActionResult Index()
        {
            IEnumerable<Rate> Rates = db.Rates;
            ViewBag.Rates = Rates;            
            Rate LastRow = Rates.Last();
            float CurrentRate = LastRow.CurrentRate;
            return View();
        }

        /// <summary>
        /// POST method to save new currency rate to DB
        /// </summary>
        /// <returns>response to client browser with 200 code</returns>
        [HttpPost]
        public ActionResult SaveRate(float _CurrentRate, DateTime _RateDate)
        {
            db.Rates.Add(new Rate
            {
                RateDate = _RateDate,
                CurrentRate = _CurrentRate
            });
            db.SaveChanges();
            return Json(new { DateTime.Now });
            
        }

  
    }
}