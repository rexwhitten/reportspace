namespace ReportSpace.CustomerDashboard.Core.QueryableExtensions
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using ReportSpace.CustomerDashboard.Core.Models;

    public static class RoleBasedExtensions
    {
         public static IQueryable<T> FilterByUserRoles<T>(this IQueryable<T> query, IList<string> roles)
             where T : class, IRoleBased
         {
             query = query.Include(e => e.Roles);

             if (!roles.Contains("Administrator"))
             {
                 query = query.Where(e => e.Roles.Any(r => roles.Contains(r.Name)));
             }

             return query;
         }

        public static T GetWithRoles<T>(this IQueryable<T> query, int id)
            where T : class, IRoleBased, IIdentifiable
        {
            return query.Include(r => r.Roles).First(r => r.Id == id);
        }
    }
}