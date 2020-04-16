using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Filters;
using NLog;

namespace MvcMusicStore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomExceptionFilterAttribute());
        }
    }
}
