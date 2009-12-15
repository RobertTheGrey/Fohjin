using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Fohjin.DDD.MVC2Beta.Controllers
{
    public partial class HomeController : BaseController
    {
        public virtual ActionResult Show()
        {
            return View();
        }

    }
}
