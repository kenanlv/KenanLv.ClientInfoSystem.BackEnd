using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ClientInfoSystem.Core.Models.Response
{
    public class EmployeeResponseModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Designation { get; set; }
    }
}
