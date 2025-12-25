namespace EMS.Domain.Common;

public static class Env
{
    public static string GetJwtKey()
    {
        return Environment.GetEnvironmentVariable("JWT_KEY") ?? "7ycNTKMz9dWdQU9l5E80rGLj50AJ4lCL";
    }

    public static string GetJwtRefreshKey()
    {
        return Environment.GetEnvironmentVariable("JWT_REFRESH_KEY") ?? "1BlxQAebHlRAD5vpGdSWYNA9hVyh6poz";
    }

    public static string GetSalt()
    {
        return Environment.GetEnvironmentVariable("SALT") ?? "fRRfulbPp1jvR1pU1JXA8nOYO9f9g6xS";
    }

    public static string GetDefaultPassword()
    {
        return Environment.GetEnvironmentVariable("DEFAULT_PASSWORD") ?? "Abcd@1234";
    }
}
