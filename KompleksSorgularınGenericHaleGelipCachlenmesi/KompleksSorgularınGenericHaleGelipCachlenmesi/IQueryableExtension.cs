using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KompleksSorgularınGenericHaleGelipCachlenmesi
{
    public static class IQueryableExtension
    {
        public static List<T> GetCache<T>(this IQueryable<T> query)
        {
            string sql = ((ObjectQuery)query).ToTraceString();
            if (HttpContext.Current.Cache[sql] == null)
            {
                List<T> list = query.ToList();
                HttpContext.Current.Cache.Insert(sql, list)
            }
            return HttpContext.Current.Cache[sql] as List<T>;
        }
    }
}
