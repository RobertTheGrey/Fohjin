// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Fohjin.DDD.MVC2Beta.Areas.Client.Controllers {
    [CompilerGenerated]
    public partial class ListController {
        protected ListController(Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }


        public readonly string Area = "Client";
        public readonly string Name = "List";

        static readonly ActionNames s_actions = new ActionNames();
        public ActionNames Actions { get { return s_actions; } }
        public class ActionNames {
            public readonly string Show = "Show";
        }


        static readonly ViewNames s_views = new ViewNames();
        public ViewNames Views { get { return s_views; } }
        public class ViewNames {
            public readonly string Show = "~/Areas/Client/Views/List/Show.aspx";
        }
    }

    [CompilerGenerated]
    public class T4MVC_ListController: Fohjin.DDD.MVC2Beta.Areas.Client.Controllers.ListController {
        public T4MVC_ListController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Show() {
            var callInfo = new T4MVC_ActionResult(Area, Name, Actions.Show);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
