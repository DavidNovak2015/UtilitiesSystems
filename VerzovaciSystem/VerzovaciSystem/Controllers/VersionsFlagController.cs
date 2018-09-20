using System.Web.Mvc;
using VerzovaciSystem.Models;

namespace VerzovaciSystem.Controllers
{
    public class VersionsFlagController : Controller
    {
        VersionsFlagViewModel versionsFlagViewModel = new VersionsFlagViewModel();

        // zobrazí události k požadovanému číslu verze z VERSION_LOG 
        public ActionResult GetFlagVersions(long versionLogId)
        {
            versionsFlagViewModel.GetEventsToVersion(versionLogId);

            return View(versionsFlagViewModel);
        }

        // zobrazí obsah log souboru k požadovanému číslu z VERSION_FLAG 
        public ActionResult GetLogFile(long versionFlagId)
        {
            versionsFlagViewModel.GetLogFile(versionFlagId);

            return View(versionsFlagViewModel);
        }
    }
}