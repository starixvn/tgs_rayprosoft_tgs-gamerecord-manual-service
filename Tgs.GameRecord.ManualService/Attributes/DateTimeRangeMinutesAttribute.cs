#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class DateTimeRangeMinutesAttribute : ValidationAttribute
{
    private int MaxLimitMinutes { get; set; }

    private string StartTime { get; set; }

    public DateTimeRangeMinutesAttribute(string startTime, int maxLimitMinutes)
    {
        StartTime = startTime;
        MaxLimitMinutes = maxLimitMinutes;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime endTime = (DateTime)value;

        DateTime startTime = (DateTime)validationContext.ObjectType.GetProperty(StartTime).GetValue(validationContext.ObjectInstance, null);

        TimeSpan diffTimeSpan = endTime.Subtract(startTime);

        return startTime < endTime && diffTimeSpan.TotalMinutes <= MaxLimitMinutes ?
            ValidationResult.Success :
            new ValidationResult($"The start time cannot be greater than the end time, and the time range is limited({MaxLimitMinutes}m).");
    }
}
