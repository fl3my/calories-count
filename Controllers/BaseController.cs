using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaloriesCount.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public virtual ActionResult Calories()
        {
            return PartialView("_CaloriesPartial");
        }
    }
}