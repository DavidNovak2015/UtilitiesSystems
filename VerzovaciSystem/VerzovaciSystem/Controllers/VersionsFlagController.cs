using System.Web.Mvc;
using VerzovaciSystem.Models;

namespace VerzovaciSystem.Controllers
{
    public class VersionsFlagController : Controller
    {
        // zobrazí události k požadovanému číslu verze z VERSION_LOG 
        public ActionResult GetFlagVersions(long versionLogId)
        {
            VersionsFlagViewModel versionsFlagViewModel = new VersionsFlagViewModel(versionLogId);
            return View(versionsFlagViewModel);
        }

        // zobrazí obsah log souboru k požadovanému číslu z VERSION_FLAG 
        public ActionResult GetLogFile(long versionFlagId)
        {
            return View();
        }
    }
}