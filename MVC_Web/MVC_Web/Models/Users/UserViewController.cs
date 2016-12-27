using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Web.Models.Users
{
    public class UserViewController : Controller
    {
        // GET: UserView
        public ActionResult Index()
        {
            return View();
        }

        public int UserId;

        [StringLength(150)]
        public string UserName { get; set; }


        [StringLength(100)]
        public string NickName { get; set; }


        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
    }
}
 