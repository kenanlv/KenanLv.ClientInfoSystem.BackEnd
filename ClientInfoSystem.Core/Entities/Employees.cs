using System;
using System.Collections.Generic;
using System.Text;

namespace ClientInfoSystem.Core.Entities
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
        public Interactions Interactions{ get; set; }
    }
}
