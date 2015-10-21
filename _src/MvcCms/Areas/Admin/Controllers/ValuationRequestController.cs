using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCms.Areas.Admin.Controllers
{
    // /admin/post
    [RouteArea("Admin")]
    [RoutePrefix("valuationrequest")]
    //[Authorize]
    public class ValuationRequestController : Controller
    {
        // GET: Admin/ValuationRequest
        public ActionResult Index()
        {
            return View();
        }
    }
}