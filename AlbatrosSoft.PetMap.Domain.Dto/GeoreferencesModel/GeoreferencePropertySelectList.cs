using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlbatrosSoft.PetMap.Domain.Dto.GeoreferencesModel
{
    public partial class GeoreferencePropertySelectList
    {
        /// <summary>
        /// Texto a mostrar de la lista.
        /// </summary>
        [DataMember(Name = "displayText")]
        public string DisplayText { get; set; }

        /// <summary>
        /// Valor del item de la lista.
        /// </summary>
        [DataMember(Name = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Estado del item de la lista.
        /// </summary>
        [DataMember(Name = "selected")]
        public bool Selected { get; set; }

    }

}
