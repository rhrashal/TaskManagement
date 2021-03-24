using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    [Table("Task_IssueStatus")]
    [ClassName("IssueStatus")]
    public class IssueStatus : Entity
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; }
    }
}
