using AjaxApplication.DB;
using AjaxApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllEmployee());
        }
        //using that like interface .....
        IEnumerable<Employee> GetAllEmployee()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Employees.Include(d => d.Department).ToList<Employee>();
            }

        }
        public ActionResult AddorEdit(int id = 0)
        {
            Employee emp = new Employee();
            if (id != 0)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    emp = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault<Employee>();
                }
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", emp.DepartmentID);
            return View(emp);

        }
        [HttpPost]
        public ActionResult AddorEdit(Employee emp)
        {
            try
            {
                if (emp.Imageupload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.Imageupload.FileName);
                    string extension = Path.GetExtension(emp.Imageupload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.Image = "~/AppFiles/Images/" + fileName;
                    emp.Imageupload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    if (emp.EmployeeId == 0)
                    {
                        db.Employees.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", emp.DepartmentID);
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    Employee emp = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault<Employee>();
                    db.Employees.Remove(emp);
                    db.SaveChanges();
                }

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}