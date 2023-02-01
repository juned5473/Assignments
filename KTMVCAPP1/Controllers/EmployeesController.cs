using KTMVCAPP1.Data;
using KTMVCAPP1.Models;
using KTMVCAPP1.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace KTMVCAPP1.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly IEmployeeRepository empRepository;

        public EmployeesController(IEmployeeRepository empRespositary)
        {
           empRepository = empRespositary;
        }

        public IActionResult Index()
        {
            /* IEnumerable<Employee> listOfEmployees = empRepository.GetEmployee();
             return View();*/
            var e = empRepository.GetEmployee();
            return View(e);
        }

        public ViewResult Details(int id)
        {
            Employee e = empRepository.GetEmployeeByID(id);
            return View(e);
        }

        public ActionResult Create()
        {
            return View(new Employee());
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empRepository.InsertEmployee(emp);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(emp);
        }


        public ActionResult Edit(int id)
        {
            Employee e = empRepository.GetEmployeeByID(id);
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empRepository.UpdateEmployee(emp);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(emp);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Employee emp = empRepository.GetEmployeeByID(id);
            return View(emp);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
           
                Employee emp = empRepository.GetEmployeeByID(id);
                empRepository.DeleteEmployee(id);
                return RedirectToAction("Index");
        }

       
    }
}
