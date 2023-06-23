using dotnet_clean_arch.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace dotnet_clean_arch.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
