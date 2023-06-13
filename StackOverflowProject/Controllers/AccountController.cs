using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverflowProject.ViewModels;
using StackOverflowProject.ServiceLayer;

namespace StackOverflowProject.Controllers
{
    public class AccountController : Controller
    {
        IUSersService us;

        public AccountController(UsersService us)
        {
            this.us = us;
        }
    
        public ActionResult Index()
        {
            return View();
        }
    }
}