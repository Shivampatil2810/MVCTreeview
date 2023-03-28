using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTreeview.Controllers
{
    public class TreeviewController : Controller
    {
        // GET: Treeview
        public ActionResult Simple()
        {
            List<NodeDetail> all = new List<NodeDetail>();
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                all = dc.NodeDetails.OrderBy(a => a.ParentNodeId).ToList();
            }
            return View(all);
        }
    }
}