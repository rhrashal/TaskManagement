using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    public class District
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string DistrictName { get; set; }
        [Required]
        public int DivisionId { get; set; }        

    }
}
