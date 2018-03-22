using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMCProj.Models.Request
{
    public class LinkAddRequest
    {
        [Required]
        public string Url { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int AccountId { get; set; }
    }
}
