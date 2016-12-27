namespace MVC_Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(150)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string NickName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public DateTime LastLoginDate { get; set; }
    }
}
