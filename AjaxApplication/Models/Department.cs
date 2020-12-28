using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AjaxApplication.Models
{
    public class Department
    {

        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Type your Department Name")]
        [Display(Name = "Dept Name")]
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee> Employees { get; set;}


       
    }
}