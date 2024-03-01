using ITI.Library.Presentation.Validators;
using System.ComponentModel.DataAnnotations;

namespace ITI.Library.Presentation.Models
{
    public class BookCreateModel
    {
        [Required(ErrorMessage ="حقل مطلوب")]
        [MaxLength(600, ErrorMessage ="Can't be Exceed 600 Characters.")]
        [MinLength(3, ErrorMessage ="أكثر من ثلاثة أحرف")]
        public string Title { get; set; }
        [Required]
        [Display(Name ="Book Author")]
        public int AuthorID { get; set; }
        [Required(ErrorMessage ="*")]
        [MultineLine(LinesCount =2)]
        public string Description { get; set; }
    }
}
