using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AjaxApplication.Models
{
    public class Employee
    {

        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        public Nullable<int> Salary { get; set; }
        [Required]
        public string Office { get; set; }
        [Required]
        public string Postion { get; set; }
        public string Image { get; set; }
        public int DepartmentID { get; set; }

        public Department Department { get; set; }

        [NotMapped]

        public HttpPostedFileBase Imageupload { get; set; }


        public Employee()
        {
            Image = "~/AppFiles/Images/user.png";
            
        }



    }
}