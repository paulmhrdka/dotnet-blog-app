using dotnet_clean_arch.Application.Common.Interfaces;

namespace dotnet_clean_arch.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
