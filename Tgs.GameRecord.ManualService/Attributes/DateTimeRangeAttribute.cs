#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class DateTimeRangeAttribute : ValidationAttribute
{
    private int MaxLimitSeconds { get; set; }

    private string StartDateTime { get; set; }

    public DateTimeRangeAttribute(string startDateTime, int maxLimitSeconds)
    {
        StartDateTime = startDateTime;
        MaxLimitSeconds = maxLimitSeconds;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime endDateTime = (DateTime)value;

        DateTime startDateTime = (DateTime)validationContext.ObjectType.GetProperty(StartDateTime).GetValue(validationContext.ObjectInstance, null);

        TimeSpan diffTimeSpan = endDateTime.Subtract(startDateTime);

        return startDateTime < endDateTime && diffTimeSpan.TotalSeconds <= MaxLimitSeconds ?
            ValidationResult.Success :
            new ValidationResult($"The start time cannot be greater than the end time, and the time range is limited ({MaxLimitSeconds}s).");
    }
}
