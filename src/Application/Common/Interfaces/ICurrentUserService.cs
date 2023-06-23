namespace dotnet_clean_arch.Application.Common.Interfaces;

public interface ICurrentUserService
{
    string? UserId { get; }
}
