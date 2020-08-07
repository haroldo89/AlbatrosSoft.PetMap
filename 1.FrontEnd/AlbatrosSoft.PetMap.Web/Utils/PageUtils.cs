// ===================================================================================================
// Desarrollado Por		    :   Harold Caicedo.
// Fecha de Creación		:   2015/06/19.
// Producto o sistema	    :   Wizenz.Navi
// Empresa			        :   Wizenz Technologies
// Proyecto			        :   NAVI30
// Cliente			        :   Wizenz Technologies
// ===================================================================================================
// Versión	        Descripción
// 1.0.0.0	        Contiene una serie de utilidades generales para trabajar con formularios web..
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
using System.Web.UI;
using System.Web.UI.WebControls;
using AlbatrosSoft.PetMap.Domain.Bll;

namespace AlbatrosSoft.PetMap.Web.Utils
{
    /// <summary>
    /// Contiene una serie de utilidades generales para trabajar con formularios web.
    /// </summary>
    public static class PageUtils
    {
        #region Constantes
        private const string APLICATION_LANGUAGE_SETTING_NAME = "ApplicationLanguage";
        private const string DEFAULT_CODE_CULTURE_INFO = "es-CO";
        #endregion Constantes

        public static int NaviWebApplicationId
        {
            get
            {
                int applicationId = 0;
                int defaultApplicationId = 1;
                try
                {
                    //string applicationIdValue = CloudConfigurationManager.GetSetting("NaviWebApplicationId");
                    //applicationId = !string.IsNullOrEmpty(applicationIdValue) ? Convert.ToInt32(applicationIdValue, CultureInfo.InvariantCulture) : defaultApplicationId;
                }
                catch
                {
                    applicationId = defaultApplicationId;

                }
                return applicationId;
            }
        }

        [ThreadStatic]
        private static AppUserBll _AppUserBll;
        /// <summary>
        /// Bll de usuario
        /// </summary>
        private static AppUserBll AppUserBll
        {
            get
            {
                if (_AppUserBll == null)
                {
                    _AppUserBll = new AppUserBll();
                }
                return _AppUserBll;
            }
        }

        //[ThreadStatic]
        //private static ViewUserPermissionsBll _UserPermissionsBll;
        ////Bll de permisos de usuario
        //private static ViewUserPermissionsBll UserPermissionsBll
        //{
        //    get
        //    {
        //        if (_UserPermissionsBll == null)
        //        {
        //            _UserPermissionsBll = new ViewUserPermissionsBll();
        //        }
        //        return _UserPermissionsBll;
        //    }
        //}


        /// <summary>
        /// Permite limpiar los controles de una página.
        /// </summary>
        /// <param name="uiControls">Coleccion de controles de la página.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        public static void ClearControls(ControlCollection uiControls)
        {
            //var rootControls = controls.Cast<Control>().Where(c => c.Parent != null).Where(c => !c.Parent.GetType().Equals(typeof(GridView)));
            var rootControls = uiControls.Cast<Control>().Where(c => !c.Parent.GetType().Equals(typeof(GridView)));
            foreach (Control uiControl in rootControls)
            {
                if (uiControl is TextBox)
                {
                    (uiControl as TextBox).Text = string.Empty;
                }
                else if (uiControl is Label)
                {
                    ((Label)uiControl).Text = string.Empty;
                }
                else if (uiControl is DropDownList)
                {
                    ((DropDownList)uiControl).ClearSelection();
                }
                else if (uiControl is RadioButtonList)
                {
                    ((RadioButtonList)uiControl).ClearSelection();
                }
                else if (uiControl is CheckBoxList)
                {
                    ((CheckBoxList)uiControl).ClearSelection();
                }
                else if (uiControl is RadioButton)
                {
                    ((RadioButton)uiControl).Checked = false;
                }
                else if (uiControl is CheckBox)
                {
                    ((CheckBox)uiControl).Checked = false;
                }
                else if (uiControl.HasControls())
                {
                    ClearControls(uiControl.Controls);
                }
            }
        }

        /// <summary>
        /// Permite mostrar un mensaje en un Label y darle un formato al texto de acuerdo a su tipo (Informativo - Error).
        /// </summary>
        /// <param name="lbl">Control label que contiene el mensaje.</param>
        /// <param name="message">Texto del mensaje a mostrar.</param>
        /// <param name="isError">Indicador de si el mensaje es o no un error.</param>
        public static void ShowMessage(Label lbl, string message, bool isError)
        {
            if (lbl != null)
            {
                lbl.Text = message;
                lbl.Attributes.Add("class", isError ? "ErrorMessage" : "SucessMessage");
            }
        }

        /// <summary>
        /// Nombre de usuario actual en el sistema.
        /// </summary>
        public static string CurrentUserName
        {
            get
            {
                return HttpContext.Current.User.Identity.Name;
            }
        }

        /// <summary>
        /// Validar que el usuario autenticado tenga permisos para el modulo.
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        public static bool HasPermission(string moduleName)
        {
            bool hasPemission = false;
            try
            {
                ////Obtener permisos del usuario actual
                //var userPermissions = UserPermissionsBll.GetUserPermissions(CurrentUserName, NaviWebApplicationId);
                ////Evaluar si el usuario actual tiee permisos para utilizar el módulo
                //if (userPermissions.Any())
                //{
                //    hasPemission = userPermissions.Any(p => p.ModuleName.Trim()
                //        .Equals(moduleName.Trim(), StringComparison.OrdinalIgnoreCase));
                //}
            }
            catch
            {
                hasPemission = false;
            }
            return hasPemission;
        }

        /// <summary>
        /// Pagina Autorizada.
        /// </summary>
        /// <param name="moduleName">Nombre del modulo.</param>
        public static void AuthorizePage(string moduleName)
        {
            if (!HasPermission(moduleName))
            {
                HttpContext.Current.Response.Redirect("/Login/Index");
            }
        }

        /// <summary>
        /// Establecer valor de globalizacion de la aplicacion en una pagina aspx.
        /// </summary>
        public static void SetCurrentAppLanguage()
        {
            var sessionInfo = HttpContext.Current.Session;
            //string languageSettingValue = AppUserBll.GetUserSettingValue(APLICATION_LANGUAGE_SETTING_NAME, CurrentUserName);
            string languageSettingValue = string.Empty;
            if (string.IsNullOrEmpty(languageSettingValue))
            {
                languageSettingValue = DEFAULT_CODE_CULTURE_INFO;
            }
            //Variable session no tiene ningun datos
            if (sessionInfo == null || sessionInfo["CurrentCultureName"] == null)
            {
                sessionInfo["CurrentCultureName"] = languageSettingValue;
            }
            else
            {
                if (languageSettingValue.Equals(DEFAULT_CODE_CULTURE_INFO))
                {
                    languageSettingValue = (string)sessionInfo["CurrentCultureName"];
                }
                else
                {
                    sessionInfo["CurrentCultureName"] = languageSettingValue;
                }
            }
            SessionHelper.CurrentCultureName = languageSettingValue;
        }
    }
}