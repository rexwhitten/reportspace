using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportSpace.Dashboard.modules
{
    public class SiteModule : NancyModule
    {
        public SiteModule()
            : base("/")
        {
            Get["/"] = _ => { return View["index.html"]; };
            Get["/chart/{chart_id}"] = _ => { return View["chart.html"]; };
        }
    }
}