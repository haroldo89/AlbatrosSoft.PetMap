// ===================================================================================================
// Desarrollado Por		    :   Harold Caicedo.
// Fecha de Creación		:   2014/03/07.
// Producto o sistema	    :   Wizenz.Navi
// Empresa			        :   Wizenz Technologies
// Proyecto			        :   NAVI30
// Cliente			        :   Wizenz Technologies
// ===================================================================================================
// Versión	        Descripción
// 1.0.0.0	        Utilidades generales para archivos.
//             
// ===================================================================================================
// HISTORIAL DE CAMBIOS:
// ===================================================================================================
// Ver.	 Fecha		    Autor					Descripción
// ---	 -------------	----------------------	------------------------------------------------------
// XX	 yyyy/MM/dd	    [Nombre Completo]	    [Razón del cambio realizado] 
// ===================================================================================================
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AlbatrosSoft.PetMap.Web.Utils
{
    public static class FileUtils
    {
        /// <summary>
        /// Obtener nombre del archivo en camel case.
        /// </summary>
        /// <param name="fileName">Nombre del archivo.</param>
        /// <returns></returns>
        public static string GetFileNameAsCamelCase(string fileName)
        {
            string fileNameValue = string.Empty;
            if (!string.IsNullOrEmpty(fileName))
            {
                string fileNameLowerCase = CultureInfo.CurrentCulture.TextInfo.ToLower(fileName);
                string fileNameCamelCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fileNameLowerCase);
                fileNameValue = fileNameCamelCase.Trim().Replace(" ", string.Empty);
            }
            return fileNameValue;
        }

        /// <summary>
        /// Permite eliminar archivos temporales del proyecto.
        /// </summary>
        /// <param name="fileName">Nombre del archivo</param>
        public static void DeleteTempFiles(string fileName)
        {
            //Validar si el archivo existe
            if (System.IO.File.Exists(fileName))
            {
                //eliminar archivo existente.
                System.IO.File.Delete(fileName);
            }
        }
    }
}