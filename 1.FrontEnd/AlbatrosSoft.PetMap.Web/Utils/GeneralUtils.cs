﻿// ===================================================================================================
// Desarrollado Por		    :   Harold Caicedo.
// Fecha de Creación		:   2014/03/07.
// Producto o sistema	    :   Wizenz.Navi
// Empresa			        :   Wizenz Technologies
// Proyecto			        :   NAVI30
// Cliente			        :   Wizenz Technologies
// ===================================================================================================
// Versión	        Descripción
// 1.0.0.0	        Utilidades generales de la aplicación.
//             
// ===================================================================================================
// HISTORIAL DE CAMBIOS:
// ===================================================================================================
// Ver.	 Fecha		    Autor					Descripción
// ---	 -------------	----------------------	------------------------------------------------------
// XX	 yyyy/MM/dd	    [Nombre Completo]	    [Razón del cambio realizado] 
// ===================================================================================================
using AlbatrosSoft.Common;
using AlbatrosSoft.PetMap.Domain.Dto.GeoreferencesModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AlbatrosSoft.PetMap.Web.Utils
{
    /// <summary>
    /// Utilidades generales de la aplicación.
    /// </summary>
    public static class GeneralUtils
    {
        private const string DEFAULT_ITEM_VALUE = "0";
        private const string DEFAULT_ITEM_TEXT = "";
        private const int APPLICATION_DATETIME_OFFSET_SETTING_ID = 2;
        private const string MULTILINESTRING_CLASS_NAME = "MULTILINESTRING";

        public static SelectListItem CreateDefaultItem()
        {
            return new SelectListItem { Text = DEFAULT_ITEM_TEXT, Value = DEFAULT_ITEM_VALUE, Selected = true };
        }

        public static SelectListItem CreateDefaultItem(bool isSelected)
        {
            return new SelectListItem { Text = DEFAULT_ITEM_TEXT, Value = DEFAULT_ITEM_VALUE, Selected = isSelected };
        }

        public static SelectListItem CreateDefaultItem(string displayText)
        {
            return new SelectListItem { Text = displayText, Value = DEFAULT_ITEM_VALUE, Selected = true };
        }

        /// <summary>
        /// Obtener fecha actual en formato texto.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentTimestampString()
        {
            string timestamp = string.Empty;
            timestamp = CommonUtils.GetCurrentDate().ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
            return timestamp;
        }

        /// <summary>
        /// Obtener puntos de cerca apartir de un texto geografico.
        /// </summary>
        /// <param name="geoText"></param>
        /// <returns></returns>
        public static IEnumerable<LocationPoint> GetGeofencePoints(string geoText)
        {
            NumberStyles numberStyle = NumberStyles.Any;
            List<LocationPoint> geofencePoints = new List<LocationPoint>();
            const string POINT_SEPARATOR = ",";
            const string COORDINATE_SEPARATOR = " ";
            if (!string.IsNullOrEmpty(geoText))
            {
                //Obtener texto con las coordenadas de los puntos
                var pointsText = StringUtils.GetStringInBetween("((", "))", geoText);
                var points = pointsText.Split(new char[] { Convert.ToChar(POINT_SEPARATOR, CultureInfo.InvariantCulture) }, StringSplitOptions.RemoveEmptyEntries);
                if (points.Any())
                {
                    foreach (var pointInfo in points)
                    {
                        //Obtener coordenadas del punto
                        var pointCoordinates = pointInfo.Split(new char[] { Convert.ToChar(COORDINATE_SEPARATOR, CultureInfo.InvariantCulture) }, StringSplitOptions.RemoveEmptyEntries);
                        if (pointCoordinates.Any())
                        {
                            //Construir punto
                            double latitude = 0, longitude = 0;
                            var latitudeResult = double.TryParse(pointCoordinates.LastOrDefault(), numberStyle, CultureInfo.InvariantCulture, out latitude);
                            var longitudeResult = double.TryParse(pointCoordinates.FirstOrDefault(), numberStyle, CultureInfo.InvariantCulture, out longitude);
                            if (latitudeResult && longitudeResult)
                            {
                                LocationPoint vertex = new LocationPoint(latitude, longitude);
                                if (vertex != null)
                                {
                                    //Agregar punto a los vertices de la geocerca
                                    geofencePoints.Add(vertex);
                                }
                            }
                        }
                    }
                }
            }
            return geofencePoints;
        }

        /// <summary>
        /// Obtiene el conjunto de puntos que forman una linea que representa una vía.
        /// </summary>
        /// <param name="geoText">Texto geográfico que representa la vía (LINESTRING).</param>
        /// <returns>Conjunto de puntos o vertices que forman la vía.</returns>
        public static IEnumerable<LocationPoint> GetRoutePoints(string geoText)
        {
            List<LocationPoint> routePoints = null;
            if (!string.IsNullOrEmpty(geoText))
            {
                //Obtener lista de puntos.
                routePoints = geoText.Contains(MULTILINESTRING_CLASS_NAME) ? GetMultiPolylinePoints(geoText).ToList() : GetPolylinePoints(geoText).ToList();
            }
            return routePoints;
        }

        /// <summary>
        /// Obtener lista de punto para mostrar en mapa si el objeto geografico es multipolilinea.
        /// </summary>
        /// <param name="geoText">Texto geografico que forma la via</param>
        /// <returns>Conjunto de puntos o vertices que forman la via</returns>
        private static IEnumerable<LocationPoint> GetMultiPolylinePoints(string geoText)
        {
            List<LocationPoint> routePoints = null;
            const string POLYLINE_SEPARATOR = "),";
            if (!string.IsNullOrEmpty(geoText))
            {
                //Obtener texto con las coordenadas de las rutas.
                string polylinesText = StringUtils.GetStringInBetween("((", "))", geoText, false, false);
                polylinesText = string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", "(", polylinesText, ")");
                //Obtener lista de polilineas
                string[] polylines = polylinesText.Split(new string[] { Convert.ToString(POLYLINE_SEPARATOR, CultureInfo.InvariantCulture) }, StringSplitOptions.RemoveEmptyEntries);
                if (polylines.Any())
                {
                    //Obtener los puntos de la ruta.
                    routePoints = new List<LocationPoint>();
                    //Obtener ultima ruta.
                    string lastPolyline = polylines.Last();
                    foreach (var polyline in polylines)
                    {
                        string polylineValue = polyline;
                        if (!lastPolyline.Equals(polylineValue))
                        {
                            polylineValue = string.Format(CultureInfo.InvariantCulture, "{0}{1}", polylineValue, ")");
                        }
                        //Agregar puntos de ruta a la lista de puntos de las rutas.
                        routePoints.AddRange(GetPolylinePoints(polylineValue).ToList());
                    }
                }
            }
            return routePoints;
        }

        /// <summary>
        /// Obtener lista de punto para mostrar en mapa si el objeto geografico es polilinea.
        /// </summary>
        /// <param name="geoText">Texto geografico que forma la via</param>
        /// <returns>Conjunto de puntos o vertices que forman la via</returns>
        private static IEnumerable<LocationPoint> GetPolylinePoints(string geoText)
        {
            NumberStyles numberStyle = NumberStyles.Any;
            List<LocationPoint> routePoints = null;
            const string POINT_SEPARATOR = ",";
            const string COORDINATE_SEPARATOR = " ";
            if (!string.IsNullOrEmpty(geoText))
            {
                //Obtener texto con las coordenadas de los puntos
                var pointsText = StringUtils.GetStringInBetween("(", ")", geoText);
                var points = pointsText.Split(new char[] { Convert.ToChar(POINT_SEPARATOR, CultureInfo.InvariantCulture) }, StringSplitOptions.RemoveEmptyEntries);
                if (points.Any())
                {
                    //Obtener los puntos de la vía.
                    routePoints = new List<LocationPoint>();
                    foreach (var pointInfo in points)
                    {
                        //Obtener coordenadas del punto
                        var pointCoordinates = pointInfo.Split(new char[] { Convert.ToChar(COORDINATE_SEPARATOR, CultureInfo.InvariantCulture) }, StringSplitOptions.RemoveEmptyEntries);
                        if (pointCoordinates.Any())
                        {
                            //Construir punto
                            double latitude = 0, longitude = 0;
                            var latitudeResult = double.TryParse(pointCoordinates.LastOrDefault(), numberStyle, CultureInfo.InvariantCulture, out latitude);
                            var longitudeResult = double.TryParse(pointCoordinates.FirstOrDefault(), numberStyle, CultureInfo.InvariantCulture, out longitude);
                            if (latitudeResult && longitudeResult)
                            {
                                LocationPoint pointLocation = new LocationPoint(latitude, longitude);
                                if (pointLocation != null)
                                {
                                    //Agregar punto a la vía.
                                    routePoints.Add(pointLocation);
                                }
                            }
                        }
                    }
                }
            }
            return routePoints;
        }

        /// <summary>
        /// Obtener puntos de cerca apartir de un texto geografico.
        /// </summary>
        /// <param name="locationPointsText"></param>
        /// <returns></returns>
        public static IEnumerable<LocationPoint> GetLocationPointsFromText(string locationPointsText)
        {
            NumberStyles numberStyle = NumberStyles.Any;
            List<LocationPoint> geofencePoints = new List<LocationPoint>();
            const string POINT_SEPARATOR = ",";
            const string COORDINATE_SEPARATOR = ",";
            if (!string.IsNullOrEmpty(locationPointsText))
            {
                //Obtener texto con las coordenadas de los puntos
                var pointsText = locationPointsText.Split(new char[] { Convert.ToChar(POINT_SEPARATOR, CultureInfo.InvariantCulture) }, StringSplitOptions.RemoveEmptyEntries);
                if (pointsText.Any())
                {
                    foreach (var pointInfo in pointsText)
                    {
                        //Obtener texto con las coordenadas de los puntos
                        var pointInfoCoordintes = StringUtils.GetStringInBetween(" ", "", pointInfo);
                        //Obtener coordenadas del punto
                        var pointCoordinates = pointInfoCoordintes.Split(new char[] { Convert.ToChar(COORDINATE_SEPARATOR, CultureInfo.InvariantCulture) }, StringSplitOptions.RemoveEmptyEntries);
                        if (pointCoordinates.Any())
                        {
                            //Construir punto
                            double latitude = 0, longitude = 0;
                            var latitudeResult = double.TryParse(pointCoordinates.LastOrDefault(), numberStyle, CultureInfo.InvariantCulture, out latitude);
                            var longitudeResult = double.TryParse(pointCoordinates.FirstOrDefault(), numberStyle, CultureInfo.InvariantCulture, out longitude);
                            if (latitudeResult && longitudeResult)
                            {
                                LocationPoint vertex = new LocationPoint(latitude, longitude);
                                if (vertex != null)
                                {
                                    //Agregar punto a los vertices de la geocerca
                                    geofencePoints.Add(vertex);
                                }
                            }
                        }
                    }
                }
            }
            return geofencePoints;
        }

        /// <summary>
        /// Permite obtener la definición de una polilinea de geocerca en formato de texto geográfico de SQL Server Spatial Data a partir de
        /// los vertices que la forman.
        /// </summary>
        /// <param name="polygonPoints">Conjunto de vértices que forman el polígono de la geocerca.</param>
        /// <returns>Texto geográfico que representa a la geocerca.</returns>
        public static string ToPolylineGeoText(IEnumerable<LocationPoint> polylinePoints)
        {
            string geoText = string.Empty;
            const string POINT_SEPARATOR = ",";
            if (polylinePoints != null && polylinePoints.Any())
            {
                StringBuilder sbGeoText = new StringBuilder();
                foreach (LocationPoint point in polylinePoints)
                {
                    sbGeoText.AppendFormat("{0} {1}{2} ", point.Longitude.ToString("G", CultureInfo.InvariantCulture), point.Latitude.ToString("G", CultureInfo.InvariantCulture), POINT_SEPARATOR);
                }
                geoText = string.Format(CultureInfo.InvariantCulture, "LINESTRING({0})", sbGeoText.ToString());
                geoText = geoText.Replace(", )", ")");
            }
            return geoText;
        }

        /// <summary>
        /// Permite obtener la definición de un polígono de geocerca en formato de texto geográfico de SQL Server Spatial Data a partir de
        /// los vertices que la forman.
        /// </summary>
        /// <param name="polygonPoints">Conjunto de vértices que forman el polígono de la geocerca.</param>
        /// <returns>Texto geográfico que representa a la geocerca.</returns>
        public static string ToPolygonGeoText(IEnumerable<LocationPoint> polygonPoints)
        {
            string geoText = string.Empty;
            const string POINT_SEPARATOR = ",";
            if (polygonPoints != null && polygonPoints.Any())
            {
                StringBuilder sbGeoText = new StringBuilder();
                foreach (LocationPoint point in polygonPoints)
                {
                    sbGeoText.AppendFormat("{0} {1}{2} ", point.Longitude.ToString("G", CultureInfo.InvariantCulture), point.Latitude.ToString("G", CultureInfo.InvariantCulture), POINT_SEPARATOR);
                }
                //Agregar el vertice inicial para cerrar el polígono
                var firstVertexPoint = polygonPoints.FirstOrDefault();
                sbGeoText.AppendFormat("{0} {1}", firstVertexPoint.Longitude.ToString("G", CultureInfo.InvariantCulture), firstVertexPoint.Latitude.ToString("G", CultureInfo.InvariantCulture));
                geoText = string.Format(CultureInfo.InvariantCulture, "POLYGON(({0}))", sbGeoText.ToString());
            }
            return geoText;
        }

        /// <summary>
        /// Generar string de titulo para la grafica svg
        /// </summary>
        /// <param name="chartTitle">Titulo</param>
        /// <returns></returns>
        public static string GetChartTitleSvgElement(string chartTitle)
        {
            string titleElementText = string.Empty;
            StringBuilder sbChartTitleElement = new StringBuilder();
            //Etiqueta
            sbChartTitleElement.Append("<text ");
            //coordenada x
            sbChartTitleElement.AppendFormat("x={0}", StringUtils.InQuotes("150"));
            //coordenada y
            sbChartTitleElement.AppendFormat(" y={0}", StringUtils.InQuotes("20"));
            //Tipo de fuente
            sbChartTitleElement.AppendFormat(" font-family={0}", StringUtils.InQuotes("Calibri"));
            sbChartTitleElement.AppendFormat(" font-weight={0}", StringUtils.InQuotes("bold"));
            //Tamaño de la fuente
            sbChartTitleElement.AppendFormat(" font-size={0}", StringUtils.InQuotes("15"));
            //NameSpace
            sbChartTitleElement.AppendFormat(" xmlns={0}", StringUtils.InQuotes("http://www.w3.org/2000/svg"));
            //Cerrar etiqueta
            sbChartTitleElement.AppendFormat(" >{0}</text>", chartTitle);
            titleElementText = sbChartTitleElement.ToString();
            return titleElementText;
        }

        /// <summary>
        /// Obtener el valor de tiempo de  offset de la aplicacion por usuario.
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public static int GetApplicationDateTimeOffset(string userName)
        {
            int applicationDatetimeOffset = -5;
            //AppUserBll AppUserBll = new AppUserBll();
            //IEnumerable<ViewAppUserSetting> userSettings = AppUserBll.GetUserSettings(userName);
            //if (userSettings != null && userSettings.Any())
            //{
            //    var userSettingsValue = userSettings.FirstOrDefault(u => u.SettingId.Equals(APPLICATION_DATETIME_OFFSET_SETTING_ID));
            //    if (userSettingsValue != null)
            //    {
            //        applicationDatetimeOffset = Convert.ToInt32(userSettingsValue.SettingValue, CultureInfo.InvariantCulture);
            //    }
            //}
            return applicationDatetimeOffset;
        }

    }
}