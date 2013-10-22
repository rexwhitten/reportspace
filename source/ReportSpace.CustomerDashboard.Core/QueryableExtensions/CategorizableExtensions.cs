namespace ReportSpace.CustomerDashboard.Core.QueryableExtensions
{
    using System.Linq;

    using ReportSpace.CustomerDashboard.Core.Models;

    public static class CategorizableExtensions
    {
         public static IQueryable<T> FilterByCategory<T>(this IQueryable<T> value, string categoryName)
             where T : class, ICategorizable
         {
             if (!string.IsNullOrEmpty(categoryName))
             {
                 value = value.Where(c => c.Category == categoryName);
             }
             
             return value;
         }
    }
}