using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeDemoSolution.Web.Controllers
{
    public class TodoListController : Controller
    {
        [HttpGet]
        public ActionResult GetAllLists()
        {

            return View();
        }
    }
}