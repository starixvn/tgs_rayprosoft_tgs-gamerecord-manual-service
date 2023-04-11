#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class DateTimeRangeDayAttribute : ValidationAttribute
{
    private int _maxLimitDay { get; set; }

    private string _startTime { get; set; }

    public DateTimeRangeDayAttribute(string startTime, int maxLimitDay)
    {
        _startTime = startTime;
        _maxLimitDay = maxLimitDay;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime endTime = (DateTime)value;

        DateTime startTime = (DateTime)validationContext.ObjectType.GetProperty(_startTime).GetValue(validationContext.ObjectInstance, null);

        TimeSpan diffTimeSpan = endTime.Subtract(startTime);

        return startTime < endTime && diffTimeSpan.TotalMinutes <= _maxLimitDay ?
            ValidationResult.Success :
            new ValidationResult($"The start time cannot be greater than the end time, and the time range is limited({_maxLimitDay}d).");
    }
}
