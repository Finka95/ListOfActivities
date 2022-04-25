#nullable disable
using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class ValidDateAttribute : ValidationAttribute
{
    private DateTime _minimumDate = DateTime.Now;

    public ValidDateAttribute()
        : base() { }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (!(value is DateTime))
        {
            throw new ArgumentException(null, nameof(value));
        }

        var enteredDate = (DateTime)value;

        if (enteredDate < _minimumDate)
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        return ValidationResult.Success;
    }
}