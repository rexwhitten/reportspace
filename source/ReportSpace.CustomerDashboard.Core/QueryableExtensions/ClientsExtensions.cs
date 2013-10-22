namespace ReportSpace.CustomerDashboard.Core.QueryableExtensions
{
    using System.Collections.Generic;
    using System.Linq;
    using ReportSpace.CustomerDashboard.Core.Models;

    public static class ClientsExtensions
    {
        public static IQueryable<T> FilterByName<T>(this IQueryable<T> query, string filterValue)
            where T : class, INamed
        {
            return query.Where(c => c.Name != null && c.Name.Contains(filterValue));
        }

        public static IQueryable<T> FilterByListOfIds<T>(this IQueryable<T> query, IList<int> ids)
            where T : class, IIdentifiable
        {
            return query.Where(c => ids.Contains(c.Id));
        }
    }
}