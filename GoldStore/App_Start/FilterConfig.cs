using System.Web;
using System.Web.Mvc;

namespace GoldStore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //https://www.youtube.com/watch?v=nNEjXCSnw6w
            //https://www.youtube.com/watch?v=eJMUhW72l6g
        }
    }
}
