using WebShop_DataAccess.Context.Entities;

namespace SGT2_WebShop.Extensions
{
    public static class UserSessionExtension
    {
        public static void SetSession (this ISession session, User user)
        {
            session.SetInt32("Id", user.Id);
            session.SetString("Name", user.Name);
            session.SetString("Email", user.Email);
        }

        public static string? GetUserName (this ISession session)
        {
            return session.GetString("Name");
        }
    }
}
