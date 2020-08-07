using System.Globalization;
using System.Threading;

namespace AlbatrosSoft.PetMap.Web.Utils
{
    public class SessionHelper
    {
        public static string CurrentCultureName
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.Name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(value);
                    Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
                }
            }
        }
    }
}