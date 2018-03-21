using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMCProj.Models.Request
{
    public class TaskUpdateRequest : TaskAddRequest
    {
        public int Id { get; set; }
    }
}
