using System.Reflection;
using System.Text;
using Entities.Models;

namespace Repository.Extensions.Utility;

public static class OrderQueryBuilder
{
    public static string CreateOrderQuery<T>(string orderByQueryString)
    {
        string[] orderParams = orderByQueryString.Trim().Split(',');
        PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        StringBuilder orderQueryBuilder = new StringBuilder();

        foreach (string param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;

            string propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

            if (objectProperty == null)
                continue;

            string direction = param.EndsWith(" desc") ? "descending" : "ascending";

            orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, ");
        }

        string orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

        return orderQuery;
    }
}