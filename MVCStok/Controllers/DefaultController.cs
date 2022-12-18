using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStok.Controllers
{
    public class DefaultController : Controller
    {
        //1.ADIM : Defalt Controller açarız.

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
    }
}