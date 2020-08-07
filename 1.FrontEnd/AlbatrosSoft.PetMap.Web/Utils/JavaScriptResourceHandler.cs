// ===================================================================================================
// Desarrollado Por		    :   Harold Caicedo.
// Fecha de Creación		:   2015/06/22.
// Producto o sistema	    :   Wizenz.Navi
// Empresa			        :   Wizenz Technologies
// Proyecto			        :   NAVI30
// Cliente			        :   Wizenz Technologies
// ===================================================================================================
// Versión	        Descripción
// 1.0.0.0	        Manejador que permite tener acceso a las propiedades del archivo resources dependiento del idioma/cultura 
//                  seleccionada en la aplicacion y serializarlo en formato json.
//             
// ===================================================================================================
// HISTORIAL DE CAMBIOS:
// ===================================================================================================
// Ver.	 Fecha		    Autor					Descripción
// ---	 -------------	----------------------	------------------------------------------------------
// XX	 yyyy/MM/dd	    [Nombre Completo]	    [Razón del cambio realizado] 
// ===================================================================================================

using Resources;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web.Script.Serialization;

namespace AlbatrosSoft.PetMap.Web.Utils
{
    /// <summary>
    /// Manejador que permite tener acceso a las propiedades del archivo resources dependiento del idioma/cultura 
    /// seleccionada en la aplicacion y serializarlo en formato json.
    /// </summary>
    public class JavaScriptResourceHandler
    {
        /// <summary>
        /// Cargar en formato json el archivo resource dependiento de la cultura/idioma de la aplicacion.
        /// </summary>
        /// <returns></returns>
        public string LoadResources()
        {
            var resources = this.ReadResources();
            var jsSerializer = new JavaScriptSerializer();
            var jsResources = jsSerializer.Serialize(resources);
            return jsResources;
        }

        /// <summary>
        /// Leer el archivo resources dependiendo de la cultura/idioma cargada en la aplicacion
        /// </summary>
        /// <returns></returns>
        private Dictionary<object, object> ReadResources()
        {
            //Obtener propiedades del archivo de configuracion de idioma segun el idioma seleccionado en la aplicacion
            ResourceSet resourceSet = LanguageSettings.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            var resources = new Dictionary<object, object>();
            //Crear diccionario con llave y valor.
            resources = resourceSet.Cast<DictionaryEntry>().ToDictionary(x => x.Key, x => x.Value);
            return resources;
        }
    }
}