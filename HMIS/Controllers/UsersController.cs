using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMIS.Controllers
{
   
    public class UsersController : Controller
    {
        public IActionResult UserList()
        {
            return View();
        }
        public IActionResult AddUser()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
