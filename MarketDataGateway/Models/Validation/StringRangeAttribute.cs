using System.ComponentModel.DataAnnotations;

namespace MarketDataGateway.Models
{
    public class StringRangeAttribute : ValidationAttribute
    {
        public StringRangeAttribute()
        {
            AllowableValues = Array.Empty<string>();
        }

        public string[] AllowableValues { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (AllowableValues.Contains(value?.ToString()) == true)
            {
                return ValidationResult.Success;
            }

            var msg = $"Please enter one of the allowed values: {string.Join(", ", AllowableValues)}.";
            return new ValidationResult(msg);
        }
    }
}
