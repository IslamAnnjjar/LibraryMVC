using System.ComponentModel.DataAnnotations;

namespace ITI.Library.Presentation.Models
{
    public class RoleCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}
