using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Web.Models.Users
{
    public class RoleViewController : Controller
    {
        // GET: RoleView
        public ActionResult Index()
        {
            return View();
        }

        public int RoleId;


        [StringLength(100)]
        public string RoleName { get; set; }

    }
}