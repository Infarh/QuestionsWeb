using Microsoft.AspNetCore.Identity;

namespace QuestionsWeb.Domain.Entities.Identity;

public class User : IdentityUser
{
    public const string Administrator = "Admin";

    public const string DefaultAdminPassword = "AdPAss_123";
}