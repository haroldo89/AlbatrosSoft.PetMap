/*Modelo del mapa*/
function MapInfo() {

    //Recuperar clave de acceso a los servicios de Bing Maps.
    var bingMapKey = sessionStorage.getItem('BingMapKey');
    //Clave de acceso a los servicios de Bing Maps
    MapInfo.BING_MAP_KEY = bingMapKey;
    //Cursor por defecto del mapa
    MapInfo.DEFAULT_CURSOR = 'url("http://ecn.dev.virtualearth.net/mapcontrol/v7.0/cursors/grab.cur"), move';

    //Propiedades privadas
    var _zoomLevel;
    var _latitude;
    var _longitude;

    //Getters y Setters
    this.getZoomLevel = function () {
        return _zoomLevel;
    }

    this.setZoomLevel = function (value) {
        _zoomLevel = value;
    }

    this.getLatitude = function () {
        return _latitude;
    }

    this.setLatitude = function (value) {
        _latitude = value;
    }

    this.getLongitude = function () {
        return _longitude;
    }

    this.setLongitude = function (value) {
        _longitude = value;
    }

    //Mètodos públicos
    this.setLocation = function (geoText) {
        //Obtener latitud apartir del punto geografico.
        var latitude = CommonUtils.getLatitude(geoText);
        //Obtener Longitud apartir del punto geografico.
        var longitude = CommonUtils.getLongitude(geoText);
        //Latitud
        this.setLatitude(latitude);
        //Longitud
        this.setLongitude(longitude);
    }
}

/*Representa la información del vehiculo que pertenece a una ruta que es visualizado en un mapa.*/
function VehicleInfo() {

    /*---Properties---*/

    var _vehicleId;
    var _vehicleName;
    var _vehiclePlate;
    var _latitude;
    var _longitude;
    var _address;
    var _speed;
    var _dateTimeUTC;
    var _iconName;
    var _engineStatus;
    var _odometer;
    var _fleetName;
    var _allowMaxSpeed;

    /*---Setters---*/

    this.setVehicleId = function (vehicleId) {
        _vehicleId = vehicleId;
    }

    this.setVehicleName = function (vehicleName) {
        _vehicleName = vehicleName;
    }

    this.setVehiclePlate = function (vehiclePlate) {
        _vehiclePlate = vehiclePlate;
    }

    this.setLatitude = function (latitude) {
        _latitude = latitude;
    }

    this.setLongitude = function (longitude) {
        _longitude = longitude;
    }

    this.setAddress = function (address) {
        _address = address;
    }

    this.setSpeed = function (speed) {
        _speed = speed;
    }

    this.setDateTimeUTC = function (dateTimeUTC) {
        _dateTimeUTC = dateTimeUTC;
    }

    this.setIconName = function (iconName) {
        _iconName = iconName;
    }

    this.setEngineStatus = function (engineStatus) {
        _engineStatus = engineStatus;
    }

    this.setOdometer = function (odometer) {
        _odometer = odometer;
    }

    this.setFleetName = function (fleetName) {
        _fleetName = fleetName;
    }

    this.setAllowMaxSpeed = function (allowMaxSpeed) {
        _allowMaxSpeed = allowMaxSpeed;
    }

    /*---Getters---*/

    this.getVehicleId = function () {
        return _vehicleId;
    }

    this.getVehicleName = function () {
        return _vehicleName;
    }

    this.getVehiclePlate = function () {
        return _vehiclePlate;
    }

    this.getLatitude = function () {
        return _latitude;
    }

    this.getLongitude = function () {
        return _longitude;
    }

    this.getAddress = function () {
        return _address;
    }

    this.getSpeed = function () {
        return _speed;
    }

    this.getDateTimeUTC = function () {
        return _dateTimeUTC;
    }

    this.getIconName = function () {
        return _iconName;
    }

    this.getEngineStatus = function () {
        return _engineStatus;
    }

    this.getOdometer = function () {
        return _odometer;
    }

    this.getFleetName = function () {
        return _fleetName;
    }

    this.getAllowMaxSpeed = function () {
        return _allowMaxSpeed;
    }

    this.setVehicleInfo = function (viewVehicleInfo) {
        if (viewVehicleInfo != null) {
            this.setVehicleId(viewVehicleInfo.vehicleId);
            this.setVehicleName(viewVehicleInfo.displayName);
            this.setVehiclePlate(viewVehicleInfo.plate);
            this.setLatitude(viewVehicleInfo.latitude);
            this.setLongitude(viewVehicleInfo.longitude);
            this.setAddress(viewVehicleInfo.address);
            this.setSpeed(viewVehicleInfo.speed);
            this.setDateTimeUTC(viewVehicleInfo.dateTimeString);
            this.setIconName(viewVehicleInfo.iconFullPath);
            this.setEngineStatus(viewVehicleInfo.engineStatus);
            this.setOdometer(viewVehicleInfo.odometer);
            this.setFleetName(viewVehicleInfo.fleetName);
            this.setAllowMaxSpeed(viewVehicleInfo.allowMaxSpeed);
        }
    }
}

/*Representa la información de un paradero de ruta o referencia que es visualizado en un mapa.*/
function BusStopInfo() {
    /*Propiedades*/
    var _checkPointId;
    var _checkPointName;
    var _latitude;
    var _longitude;
    var _checkPointAddress;
    var _checkPointTypeId;
    var _iconPath;

    /*Getters y Setters*/
    this.getCheckPointId = function () {
        return _checkPointId;
    }

    this.setCheckPointId = function (checkPointId) {
        _checkPointId = checkPointId;
    }

    this.getName = function () {
        return _checkPointName;
    }

    this.setName = function (name) {
        _checkPointName = name;
    }

    this.getLatitude = function () {
        return _latitude;
    }

    this.setLatitude = function (latitude) {
        _latitude = latitude;
    }

    this.getLongitude = function () {
        return _longitude;
    }

    this.setLongitude = function (longitude) {
        _longitude = longitude;
    }

    this.getAddress = function () {
        return _checkPointAddress;
    }

    this.setAddress = function (address) {
        _checkPointAddress = address;
    }

    this.getCheckPointTypeId = function () {
        return _checkPointTypeId;
    }

    this.setCheckPointTypeId = function (checkPointTypeId) {
        _checkPointTypeId = checkPointTypeId;
    }

    this.getIconPath = function () {
        return _iconPath;
    }

    this.setIconPath = function (iconPath) {
        _iconPath = iconPath;
    }

    /*Establecer propiedaades del paradero de ruta*/
    this.setBusStopInfo = function (checkPoint) {
        if (checkPoint) {
            this.setCheckPointId(checkPoint.checkPointId);
            this.setLatitude(checkPoint.latitude);
            this.setLongitude(checkPoint.longitude);
            this.setName(checkPoint.checkPointName);
            this.setAddress(checkPoint.checkPointAddress);
            this.setCheckPointTypeId(checkPoint.checkPointTypeId);
            this.setIconPath(checkPoint.fullIconPath);
        }
    }
}

//Representa la información de una ruta que es representado en un mapa.
function RouteInfo() {

    /*--properties--*/
    var _routeId;
    var _routeName;
    var _routeDescription;
    var _routeTypeId;
    var _routeTypeName;
    var _routeColor;
    var _points;

    /*--setters--*/

    this.setRouteId = function (routeId) {
        _routeId = routeId;
    }

    this.setRouteName = function (routeName) {
        _routeName = routeName;
    }

    this.setRouteDescription = function (routeDescription) {
        _routeDescription = routeDescription;
    }

    this.setRouteColor = function (routeColor) {
        _routeColor = routeColor;
    }

    /*Establecer Puntos de geocerca*/
    this.setPoints = function (points) {
        _points = new Array();
        points.forEach(function (point) {
            var location = BingMapHelper.createLocation(point.latitude, point.longitude);
            _points.push(location);
        });
    }

    /*--getters--*/

    /*Obtener puntos de geocerca*/

    this.getRouteId = function () {
        return _routeId;
    }

    this.getRouteName = function () {
        return _routeName;
    }

    this.getRouteDescription = function () {
        return _routeDescription;
    }

    this.getRouteColor = function () {
        return _routeColor;
    }

    this.getPoints = function () {
        return _points;
    }

    /*Establecer propiedades de geocerca*/
    this.setRouteInfo = function (routeInfo) {
        if (routeInfo) {
            this.setRouteId(routeInfo.routeId);
            this.setRouteName(routeInfo.routeName);
            this.setRouteDescription(routeInfo.routeDescription);
            this.setRouteColor(routeInfo.routeColor);
            this.setPoints(routeInfo.routePoints);
        }
    }
}