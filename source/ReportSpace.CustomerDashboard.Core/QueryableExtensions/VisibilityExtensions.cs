namespace ReportSpace.CustomerDashboard.Core.QueryableExtensions
{
    using System.Linq;

    using ReportSpace.CustomerDashboard.Core.Models;

    public static class VisibilityExtensions
    {
        public static IQueryable<T> FilterByVisibility<T>(this IQueryable<T> value, bool canSeeHidden)
            where T : class, IVisibility
        {
            if (!canSeeHidden)
            {
                value = value.Where(v => !v.IsHidden);
            }

            return value;
        }
    }
}