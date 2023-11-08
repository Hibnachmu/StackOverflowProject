using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StackOverflowProject.ServiceLayer;
using StackOverflowProject.ViewModels;
namespace StackOverflowProject.ApiControllers
{
    public class AccountController : ApiController
    {
        IUSersService us;

        public AccountController(IUSersService us)
        {
            this.us = us;           
        }

        public string Get(string email)
        {
            if(this.us.GetUsersByEmail(email)!= null)
            {
                return "Found";
            }
            else
            {
                return "Not Found";
            }
        }

    }
}
