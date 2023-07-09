using Attendance_Management_System.Models;
using Attendance_Management_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attendance_Management_System.Controllers
{ 
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        UserDAL userDAL = new UserDAL();
        public ActionResult ReportAPage()
        {
            var data = userDAL.GetReportAUsers();
            return View(data);
        }
        public ActionResult ReportBPage()
        {
            List<LocalModel> localData = userDAL.GetLocalData();
            List<BasModel> basData = userDAL.GetBASData();
            List<LocalModel> setDifference = localData.Where(l => !basData.Any(b => IsLocalEqual(b, l))).ToList();
            return View(setDifference);
        }
        public bool IsLocalEqual(BasModel bas, LocalModel local)
        {
            return bas.ID == local.ID && bas.EMP_ID == local.EMP_ID && bas.EMP_NAME == local.EMP_NAME
                && bas.ATTEND_DATE == local.ATTEND_DATE && bas.BAS_INTIME == local.LOCAL_INTIME
                && bas.BAS_OUTTIME == local.LOCAL_OUTTIME;
        }
    }
    public class LocalComparer : IEqualityComparer<LocalModel>
    {
        public bool Equals(LocalModel x, LocalModel y)
        {
            return x.ID == y.ID && x.EMP_ID == y.EMP_ID && x.EMP_NAME == y.EMP_NAME
                && x.ATTEND_DATE == y.ATTEND_DATE && x.LOCAL_INTIME == y.LOCAL_INTIME
                && x.LOCAL_OUTTIME == y.LOCAL_OUTTIME;
        }

        public int GetHashCode(LocalModel obj)
        {
            return obj.ID.GetHashCode() ^ obj.EMP_ID.GetHashCode() ^ obj.EMP_NAME.GetHashCode()
                ^ obj.ATTEND_DATE.GetHashCode() ^ obj.LOCAL_INTIME.GetHashCode()
                ^ obj.LOCAL_OUTTIME.GetHashCode();
        }
    }
}