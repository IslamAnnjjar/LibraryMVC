using System.ComponentModel.DataAnnotations;

namespace ITI.Library.Presentation.Validators
{
    public class MultineLine : ValidationAttribute
    {
        public int LinesCount { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult("Empty Entry");
            if(value.ToString()
                .Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries )
                .Length < LinesCount)
                return new ValidationResult("Must Be More Than Or Equals 3 Lines");

            return ValidationResult.Success;
        }
        
    }
}
