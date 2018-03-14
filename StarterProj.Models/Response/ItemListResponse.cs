using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterProj.Models.Response
{
    public class ItemListResponse<T> : SuccessResponse
    {
        public List<T> Items { get; set; }
    }
}
