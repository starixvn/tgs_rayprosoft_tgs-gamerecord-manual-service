#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class DateTimeRangeAttribute : ValidationAttribute
{
    private int MaxLimitSeconds { get; set; }

    private string StartTime { get; set; }

    public DateTimeRangeAttribute(string startTime, int maxLimitSeconds)
    {
        StartTime = startTime;
        MaxLimitSeconds = maxLimitSeconds;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime endTime = (DateTime)value;

        DateTime startTime = (DateTime)validationContext.ObjectType.GetProperty(StartTime).GetValue(validationContext.ObjectInstance, null);

        TimeSpan diffTimeSpan = endTime.Subtract(startTime);

        return startTime < endTime && diffTimeSpan.TotalSeconds <= MaxLimitSeconds ?
            ValidationResult.Success :
            new ValidationResult($"The start time cannot be greater than the end time, and the time range is limited ({MaxLimitSeconds}s).");
    }
}
