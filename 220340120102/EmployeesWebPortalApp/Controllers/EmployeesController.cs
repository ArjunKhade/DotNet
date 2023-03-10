using EmployeesWebPortalApp.DataAccessLayer;
using EmployeesWebPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeesWebPortalApp.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employee/GetAllEmpDetails    
        public ActionResult GetAllEmpDetails()
        {

            EmpRepository EmpRepo = new EmpRepository();
            ModelState.Clear();
            return View(EmpRepo.GetAllEmployees());
        }
        // GET: Employee/AddEmployee    
        public ActionResult AddEmployee()
        {
            return View();
        }

        // POST: Employee/AddEmployee    
        [HttpPost]
        public ActionResult AddEmployee(Employee Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpRepository EmpRepo = new EmpRepository();

                    if (EmpRepo.AddEmployee(Emp))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/EditEmpDetails/5    
        public ActionResult EditEmpDetails(int id)
        {
            EmpRepository EmpRepo = new EmpRepository();



            return View(EmpRepo.GetAllEmployees().Find(Emp => Emp.EmpNo == id));

        }

        // POST: Employee/EditEmpDetails/5    
        [HttpPost]

        public ActionResult EditEmpDetails(int id, Employee obj)
        {
            try
            {
                EmpRepository EmpRepo = new EmpRepository();

                EmpRepo.UpdateEmployee(obj);
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/DeleteEmp/5    
        public ActionResult DeleteEmp(int id)
        {
            try
            {
                EmpRepository EmpRepo = new EmpRepository();
                if (EmpRepo.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllEmpDetails");

            }
            catch
            {
                return View();
            }
        }
    }
}