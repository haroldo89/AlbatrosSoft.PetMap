using AlbatrosSoftPetMap.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbatrosSoft.PetMap.Data.Repository
{
    /// <summary>
    /// Proporciona un mecanismo de acceso común a los objetos que establecen comunicación con los medios de persistencia de información del sistema.
    /// </summary>
    internal static class DataContextProvider
    {

        [ThreadStatic]
        private static PetMapModelContainer _PetMapContext;

        /// <summary>
        /// Representa el contexto de comunicación con la base de datos central del sistema de monitoreo NAVI.
        /// </summary>
        internal static PetMapModelContainer PetMapContext
        {
            get
            {
                if (_PetMapContext == null)
                {
                    _PetMapContext = new PetMapModelContainer();
                }
                return _PetMapContext;
            }
        }

    }
}
