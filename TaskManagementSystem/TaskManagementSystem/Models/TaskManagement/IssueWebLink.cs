﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    [Table("Task_IssueWebLink")]
    [ClassName("Issue Web Link")]
    public class IssueWebLink
    {
        [Key]
        public int Id { get; set; }
        public int IssueId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
 