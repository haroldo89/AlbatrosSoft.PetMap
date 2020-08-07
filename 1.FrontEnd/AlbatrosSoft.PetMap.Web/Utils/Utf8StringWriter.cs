using System.Globalization;
using System.IO;
using System.Text;

namespace AlbatrosSoft.PetMap.Web.Utils
{
    /// <summary>
    /// StringWriter UTF-8
    /// </summary>
    public class Utf8StringWriter : StringWriter
    {

        public Utf8StringWriter()
            : base(CultureInfo.InvariantCulture)
        {

        }

        /// <summary>
        /// Encoding UTF-8
        /// </summary>
        public override Encoding Encoding { get { return Encoding.UTF8; } }
    }
}