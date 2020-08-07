// ===================================================================================================
// Desarrollado Por		    :   Harold Caicedo.
// Fecha de Creación		:   2016/10/16.
// Producto o sistema	    :   AlbatrosSoft.PetMap
// Empresa			        :   AlbatrosSoft
// Proyecto			        :   PetMap10
// ===================================================================================================
// Versión	        Descripción
// 1.0.0.0	        Controlador base de toda la aplicacion.
//             
// ===================================================================================================
// HISTORIAL DE CAMBIOS:
// ===================================================================================================
// Ver.	 Fecha		    Autor					Descripción
// ----- -------------	----------------------	------------------------------------------------------   
// ===================================================================================================
using AlbatrosSoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlbatrosSoft.PetMap.Web.Controllers
{
    public class BaseController : Controller
    {
        #region Constantes
        private readonly string APLICATION_LANGUAGE_SETTING_NAME = "ApplicationLanguage";
        private readonly string DEFAULT_CODE_CULTURE_INFO = "es-CO";
        #endregion Constantes

        /// <summary>
        /// Obtiene el nombre del controlador asociado al módulo.
        /// </summary>
        protected virtual string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Usuario autenticado en la aplicacion
        /// </summary>
        public string CurrentUser
        {
            get
            {
                return this.User.Identity.Name;
            }
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            ////Obtener permisos del usuario autenticado.
            //this.LoadUserPermissions();
            ////Obtener servicios del modulo de configuración del usuario
            //this.LoadConfigurationModuleServices();
            ////Obtener idiomas soportados por la aplicacion
            //this.LoadAppLanguages();
            ////Establecer el lenguage de la aplicacion.
            //this.SetCurrentAppLanguage(filterContext);
            //Version de la aplicacion
            this.ViewBag.appVersion = CommonUtils.GetAppVersion();
        }

        private void SetCurrentAppLanguage(ActionExecutingContext filterContext)
        {
            //if (filterContext != null)
            //{
            //    var sessionInfo = filterContext.HttpContext.Session;
            //    string languageSettingValue = this.AppUserBll.GetUserSettingValue(this.APLICATION_LANGUAGE_SETTING_NAME, this.CurrentUser);
            //    if (string.IsNullOrEmpty(languageSettingValue))
            //    {
            //        languageSettingValue = DEFAULT_CODE_CULTURE_INFO;
            //    }
            //    //Variable session no tiene ningun datos
            //    if (sessionInfo == null || sessionInfo["CurrentCultureName"] == null)
            //    {
            //        sessionInfo["CurrentCultureName"] = languageSettingValue;
            //    }
            //    else
            //    {
            //        //languageSettingValue = (string)sessionInfo["CurrentCultureName"];
            //        if (languageSettingValue.Equals(DEFAULT_CODE_CULTURE_INFO))
            //        {
            //            languageSettingValue = (string)sessionInfo["CurrentCultureName"];
            //        }
            //        else
            //        {
            //            sessionInfo["CurrentCultureName"] = languageSettingValue;
            //        }
            //    }
            //    SessionHelper.CurrentCultureName = languageSettingValue;
            //}
        }

        /// <summary>
        /// Permite cambiar el idioma por codigo de culura
        /// </summary>
        /// <param name="cultureCode">Codigo de cultura</param>
        /// <returns></returns>
        public ActionResult ChangeCurrentCultureByCodeName(string cultureCode)
        {
            ////Cambia el hilo de currentCulture para el usuario Change the current culture for this user.
            //SessionHelper.CurrentCultureName = cultureCode;
            ////Guarda el nuevo currentCulture en la session del usuario
            //Session["CurrentCultureName"] = cultureCode;
            ////Cambiar la configuracion de idioma para el usuario.
            //this.ChangeAppUserSetting(this.CurrentUser, this.APLICATION_LANGUAGE_SETTING_NAME, cultureCode);
            //Redirecciona a la misma pagina de donde se hizo el request
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
