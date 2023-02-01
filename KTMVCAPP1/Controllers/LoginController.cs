using KTMVCAPP1.Data;
using KTMVCAPP1.Models;
using KTMVCAPP1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KTMVCAPP1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IEmployeeRepository empRepository;

        public LoginController(IEmployeeRepository empRespositary)
        {
            empRepository = empRespositary;
        }
        public IActionResult Login(string Email, string Password,int id1,Employee emp)
        {
            var linq = from n in empRepository.GetEmployee()
                       where Email == n.Email && Password == n.Password
                       select n;
            if (linq.Count().Equals(0))
            {
                ViewBag.Message = "NO User Found";
                return View();
              
            }


                     
            return RedirectToAction("Index", "Employees", new { id = id1 } ,null);
       
  
        }

        
    }
}
