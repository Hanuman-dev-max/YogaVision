namespace YogaVision.Extensions
{
    using System.Security.Claims;
    /// <summary>
    /// Extension for ClaimsPrincipal
    /// </summary>
    public static class ClaimsPrincipalExtension
    {
        /// <summary>
        /// Return the Id of the ApplicationUser
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
