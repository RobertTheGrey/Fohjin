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
namespace Fohjin.DDD.MVC.Controllers {
    public partial class ClientController {

        [CompilerGenerated]
        protected ClientController(Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }

        [NonAction]
        public System.Web.Mvc.ActionResult Details() {
            return new T4MVC_ActionResult(Name, Actions.Details);
        }

        [NonAction]
        public System.Web.Mvc.ActionResult ClientChangeName() {
            return new T4MVC_ActionResult(Name, Actions.ClientChangeName);
        }


        [CompilerGenerated]
        public readonly string Name = "Client";

        static readonly ActionNames s_actions = new ActionNames();
        [CompilerGenerated]
        public ActionNames Actions { get { return s_actions; } }
        [CompilerGenerated]
        public class ActionNames {
            public readonly string Index = "Index";
            public readonly string Details = "Details";
            public readonly string Create = "Create";
            public readonly string ClientChangeName = "ClientChangeName";
        }


        static readonly ViewNames s_views = new ViewNames();
        [CompilerGenerated]
        public ViewNames Views { get { return s_views; } }
        [CompilerGenerated]
        public class ViewNames {
            public readonly string ClientChangeName = "ClientChangeName";
            public readonly string Create = "Create";
            public readonly string Details = "Details";
            public readonly string List = "List";
        }
    }
}

namespace T4MVC {
    [CompilerGenerated]
    public class T4MVC_ClientController: Fohjin.DDD.MVC.Controllers.ClientController {
        public T4MVC_ClientController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index() {
            var callInfo = new T4MVC_ActionResult("Client", Actions.Index);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Details(System.Guid id) {
            var callInfo = new T4MVC_ActionResult("Client", Actions.Details);
            callInfo.RouteValues.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Create() {
            var callInfo = new T4MVC_ActionResult("Client", Actions.Create);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Create(Fohjin.DDD.Reporting.Dto.ClientDetailsReport clientDetailsReport) {
            var callInfo = new T4MVC_ActionResult("Client", Actions.Create);
            callInfo.RouteValues.Add("clientDetailsReport", clientDetailsReport);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ClientChangeName(System.Guid id) {
            var callInfo = new T4MVC_ActionResult("Client", Actions.ClientChangeName);
            callInfo.RouteValues.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult ClientChangeName(Fohjin.DDD.Reporting.Dto.ClientReport clientReport) {
            var callInfo = new T4MVC_ActionResult("Client", Actions.ClientChangeName);
            callInfo.RouteValues.Add("clientReport", clientReport);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
