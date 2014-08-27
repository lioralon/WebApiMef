using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiInterface;

namespace WebApiMef.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        [Import(typeof(IMEFInterface))]
        public IMEFInterface MefInstance { get; set; }
        public ActionResult Index()
        {
            string name = MefInstance.GetName("Pc");
            return View();
        }
    }
}
