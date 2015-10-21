using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCms.Models
{
    public class CmsUser : IdentityUser
    {
        public string DisplayName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide last name")]
        public string LastName { get; set; }

        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
    }
}