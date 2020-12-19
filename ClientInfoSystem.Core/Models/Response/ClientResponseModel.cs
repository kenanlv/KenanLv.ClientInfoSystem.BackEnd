using System;
using System.Collections.Generic;
using System.Text;

namespace ClientInfoSystem.Core.Models.Response
{
    public class ClientResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
