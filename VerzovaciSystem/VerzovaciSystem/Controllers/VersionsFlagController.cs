using System.Web.Mvc;
using VerzovaciSystem.Models;

namespace VerzovaciSystem.Controllers
{
    public class VersionsFlagController : Controller
    {
        public ActionResult GetFlagVersions(long versionLogId)
        {
            VersionsFlagViewModel versionsFlagViewModel = new VersionsFlagViewModel(versionLogId);
            return View(versionsFlagViewModel);
        }
    }
}