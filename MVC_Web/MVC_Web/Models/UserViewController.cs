using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Web.Models
{
    public class UserViewController : Controller
    {
        public string UserName { get;  set; }
        public string Password { get;  set; }


        // GET: UserView
        public ActionResult Index()
        {
            return View();
        }
        public class LoginViewModel
        {
            [Required]
            [Display(Name = "UserName")]
          
            public string UserName { get; set; }

            [Required] 
            [Display(Name = "Password")]
            public string Password { get; set; }
 
        }

    }
}