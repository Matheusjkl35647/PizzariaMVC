using System.Web;
using System.Web.Mvc;

namespace Pizzaria_6320048
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
