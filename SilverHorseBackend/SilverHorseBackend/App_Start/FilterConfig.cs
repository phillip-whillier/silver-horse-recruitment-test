using System.Web;
using System.Web.Mvc;
using SilverHorseBackend.App_Start;

namespace SilverHorseBackend
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
