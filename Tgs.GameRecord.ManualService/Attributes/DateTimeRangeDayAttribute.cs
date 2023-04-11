#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class DateTimeRangeDayAttribute : ValidationAttribute
{
    private int MaxLimitDay { get; set; }

    private string StartTime { get; set; }

    public DateTimeRangeDayAttribute(string startTime, int maxLimitDay)
    {
        StartTime = startTime;
        MaxLimitDay = maxLimitDay;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime endTime = (DateTime)value;

        DateTime startTime = (DateTime)validationContext.ObjectType.GetProperty(StartTime).GetValue(validationContext.ObjectInstance, null);

        TimeSpan diffTimeSpan = endTime.Subtract(startTime);

        return startTime < endTime && diffTimeSpan.TotalDays <= MaxLimitDay ?
            ValidationResult.Success :
            new ValidationResult($"The start time cannot be greater than the end time, and the time range is limited({MaxLimitDay}day).");
    }
}
