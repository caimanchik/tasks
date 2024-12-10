using Core.DateTimeLogic.Base.Interfaces;

namespace Core.DateTimeLogic.Base;

internal class DateTimeBase : ICurrentDateTime
{
    /// <inheritdoc />
    public DateTime GetCurrentDateTime() => DateTime.UtcNow;
}