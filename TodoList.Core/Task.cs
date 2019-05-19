using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoList.Core
{
    public class Task
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(512)]
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
