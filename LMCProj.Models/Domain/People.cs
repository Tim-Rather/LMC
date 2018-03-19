using LMCProj.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMCProj.Models.Domain
{
    public class People : PeopleUpdateRequest
    {
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}
