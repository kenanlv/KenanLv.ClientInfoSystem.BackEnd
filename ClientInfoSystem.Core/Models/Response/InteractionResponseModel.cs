using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClientInfoSystem.Core.Models.Response
{
    public class InteractionResponseModel
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? EmpId { get; set; }
        public char? IntType { get; set; }
        [MaxLength(50)]
        public string Remarks { get; set; }
        public DateTime? IntDate { get; set; }
    }
}
