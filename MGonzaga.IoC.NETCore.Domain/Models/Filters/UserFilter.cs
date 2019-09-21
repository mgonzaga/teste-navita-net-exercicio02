
using MGonzaga.IoC.NETCore.Domain.Models;
using System.Linq;

namespace MGonzaga.IoC.NETCore.Domain.Models.Filters
{
    public static class UserFilter
    {
        public static IQueryable<User> ContainsFullName(this IQueryable<User> query, string fullName)
        {
            if (!string.IsNullOrEmpty(fullName)) {
                query = query.Where(_ => _.FullName.Contains(fullName));
            }
            return query;
        }
        public static IQueryable<User> WithEmail(this IQueryable<User> query, string email)
        {
            if (!string.IsNullOrEmpty(email)) query = query.Where(_ => _.Email == email);
            return query;
        }
        public static IQueryable<User> WithConfirmedEmail(this IQueryable<User> query, bool? confirmedEmail)
        {
            if (confirmedEmail != null) query = query.Where(_ => _.ConfirmedEmail == confirmedEmail);
            return query;
        }
    }
}
