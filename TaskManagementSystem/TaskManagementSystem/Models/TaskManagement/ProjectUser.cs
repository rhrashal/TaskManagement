using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    [Table("Task_ProjectUsers")]
    [ClassName("Project Users")]
    public class ProjectUsers : Entity
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; } //Fk
        public string UserId { get; set; } //Fk
    }
}
