using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    public class PoliceStation
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string PoliceStationName { get; set; }
        [Required]
        public int DistrictId { get; set; }
        
    }
}
