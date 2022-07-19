using WebShop_DataAccess.Context.Entities;

namespace SGT2_WebShop.Extensions
{
    public static class UserSessionExtensions
    {
        public static void SetSession (this ISession session, User user)
        {
            session.SetInt32("Id", user.Id);
            session.SetString("Name", user.Name);
            session.SetString("Email", user.Email);
            session.SetInt32("UserType", (int)user.UserType);
        }

        public static string? GetUserName (this ISession session)
        {
            return session.GetString("Name");
        }

        public static int? GetUserId(this ISession session)
        {
            return session.GetInt32("Id");
        }

        public static int? GetUserType(this ISession session)
        {
            return session.GetInt32("UserType");
        }
    }
}
