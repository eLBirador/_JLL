using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCms.Models
{
    public class ValuationRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Geocode { get; set; }

        [Display(Name = "Date Created")]
        public DateTime Created { get; set; }

        public string OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual CmsUser Owner { get; set; }

        public string AssignedAdminId { get; set; }
        [ForeignKey("AssignedAdminId")]
        public virtual CmsUser AssignedAdmin { get; set; }
    }
}