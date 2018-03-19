using System.ComponentModel.DataAnnotations;

namespace LMCProj.Models.Request
{
    public class PeopleUpdateRequest : PeopleAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
