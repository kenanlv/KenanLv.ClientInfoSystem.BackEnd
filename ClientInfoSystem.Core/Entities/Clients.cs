using System;
using System.Collections.Generic;
using System.Text;

namespace ClientInfoSystem.Core.Entities
{
    public class Clients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? AddedOn { get; set; }
        public Interactions Interactions { get; set; }
    }
}
