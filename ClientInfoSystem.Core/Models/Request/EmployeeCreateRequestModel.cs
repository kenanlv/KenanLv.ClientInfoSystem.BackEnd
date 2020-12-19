using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ClientInfoSystem.Core.Models.Request
{
    public class EmployeeCreateRequestModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string Designation { get; set; }
    }
}
