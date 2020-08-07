using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Serialization;
//using Microsoft.Azure;

namespace AlbatrosSoft.PetMap.Domain.Dto.GeoreferencesModel
{
    /// <summary>
    /// Representa la información de un punto de control o referencia.
    /// </summary>
    [XmlRoot("checkPoint")]
    [DataContract(Name = "checkPoint")]
    public partial class CheckPoint : LocationPoint
    {
        /// <summary>
        /// Ruta de acceso al contenedor de archivos de íconos.
        /// </summary>
        private string PointTypesIconsPath
        {
            get
            {
                const string DEFAULT_POINT_TYPES_ICONS_PATH = "http://navistoragesvc.blob.core.windows.net/navi-pointtype-icons";
                string pointTypesIconsPath = string.Empty;
                try
                {
                    //string rootPath = CloudConfigurationManager.GetSetting("BlobRootPath");
                    //string containerName = CloudConfigurationManager.GetSetting("PointTypesIconsContainerName");
                    //pointTypesIconsPath = string.Format(CultureInfo.InvariantCulture, "{0}/{1}", rootPath, containerName);
                }
                catch
                {
                    pointTypesIconsPath = DEFAULT_POINT_TYPES_ICONS_PATH;
                }
                return pointTypesIconsPath;
            }
        }
        
        /// <summary>
        /// Id del punto de control.
        /// </summary>
        [DataMember(Name = "checkPointId")]
        public int CheckPointId { get; set; }

        /// <summary>
        /// Dirección del punto de control.
        /// </summary>
        [DataMember(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Tipo de punto de control.
        /// </summary>
        [DataMember(Name = "checkPointTypeId")]
        public int CheckPointTypeId { get; set; }

        /// <summary>
        /// Nombre del archivo de ícono que representa al punto en el mapa.
        /// </summary>
        public string IconName { get; set; }

        /// <summary>
        /// Url de acceso al archivo de ícono del punto.
        /// </summary>
        [DataMember(Name = "iconPath")]
        public string IconPath 
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}/{1}", this.PointTypesIconsPath, this.IconName);
            }
            set 
            { 
            } 
        }

        /// <summary>
        /// Id de cliente al que pertenece el punto de control.
        /// </summary>
        [DataMember(Name = "customerId")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Radio del punto de control.
        /// </summary>
        [DataMember(Name = "radius")]
        public int Radius { get; set; }

        public CheckPoint()
        {

        }

        //public CheckPoint(ViewActivePoint point)
        //{
        //    if (point == null)
        //    {
        //        throw new ArgumentNullException("point", "Instancia del punto no puede ser un valor nulo.");
        //    }
        //    var checkPoint = LocationPoint.Parse(point.GeoText);
        //    if (checkPoint != null)
        //    {
        //        this.Latitude = checkPoint.Latitude;
        //        this.Longitude = checkPoint.Longitude;
        //        this.CheckPointId = point.CheckPointId;
        //        this.Name = point.Name;
        //        this.Address = point.Address;
        //        this.CheckPointTypeId = point.CheckPointTypeId;
        //        this.IconName = point.IconName;
        //        this.Radius = point.Radius;
        //    }
        //}

        //public CheckPoint(ViewCheckPointInfo point)
        //{
        //    if (point == null)
        //    {
        //        throw new ArgumentNullException("point", "Instancia del punto no puede ser un valor nulo.");
        //    }
        //    this.Latitude = point.Latitude.Value;
        //    this.Longitude = point.Longitude.Value;
        //    this.CheckPointId = point.CheckPointId;
        //    this.Name = point.Name;
        //    this.Address = point.Address;
        //    this.CheckPointTypeId = point.CheckPointTypeId;
        //    this.IconName = point.IconName;
        //    this.Radius = point.Radius;
        //}
    }
}
