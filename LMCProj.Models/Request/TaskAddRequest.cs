using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMCProj.Models.Request
{
    public class TaskAddRequest
    {
        [Required]
        public int AccountId { get; set; }
        [Required, MaxLength(256)]
        public string Title { get; set; }
        [Required, MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
