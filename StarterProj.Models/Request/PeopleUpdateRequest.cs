using System.ComponentModel.DataAnnotations;

namespace StarterProj.Models.Request
{
    public class PeopleUpdateRequest : PeopleAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
