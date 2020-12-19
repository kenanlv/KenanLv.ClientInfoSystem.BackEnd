using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ClientInfoSystem.Core.Models.Request
{
    public class InteractionCreateRequestModel
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? EmpId { get; set; }
        public char IntType { get; set; }
        [MaxLength(50)]
        public string Remarks{ get; set; }
        public DateTime? IntDate { get; set; }
    }
}
