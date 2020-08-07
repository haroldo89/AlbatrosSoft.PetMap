// ===================================================================================================
// Desarrollado Por		    :   Hernando Velez.
// Fecha de Creación		:   2015/08/26.
// Producto o sistema	    :   Wizenz.Navi
// Empresa			        :   Wizenz Technologies
// Proyecto			        :   NAVI Parent Viewer
// Cliente			        :   Varios.
// ===================================================================================================
// Versión	        Descripción
// 1.0.0.0	        Funciones javascript de vista de Home.
// ===================================================================================================
// HISTORIAL DE CAMBIOS:
// ===================================================================================================
// Ver.	 Fecha		    Autor					Descripción
// ---	 -------------	----------------------	------------------------------------------------------
// XX	 yyyy/MM/dd	    [Nombre Completo]	    [Razón del cambio realizado] 
// ===================================================================================================

function Home() { }

//#region Variables Globales
//Mapa
Home.map = null;
//Layer de vehiculo
Home.mapVehicleLayer = new Microsoft.Maps.EntityCollection();
//Layer del recorrido del vehiculo
Home.mapBusStopLayer = new Microsoft.Maps.EntityCollection();
//Icono del vehiculo
Home.vehicleIcon = 'http://navistoragesvc.blob.core.windows.net/navi-vehiclestatus-icons/BusIcon.png';
//Informacion del vehiculo
Home.vehicleInfo = null;
//Informacion de la ruta del vehiculo
Home.busStopInfo = null;
//Informacion del resumen de la consulta de activdad
Home.vehicleSummaryDetailInfo = null;
//Posicion inicial del vehiculo
Home.vehicleRowIndex = 0;
//Estado actual del detalle
Home.tblDetailIsClose = true;

Home._vehicleLocation;
Home._busStopLocation;

Home.setVehicleLocation = function (vehicleInfo) {
    Home._vehicleLocation = BingMapHelper.createLocation(vehicleInfo.getLatitude(), vehicleInfo.getLongitude());
}
Home.getVehicleLocation = function () {
    return Home._vehicleLocation;
}

Home.setBusStopLocation = function (busStopInfo) {
    Home._busStopLocation = BingMapHelper.createLocation(busStopInfo.getLatitude(), busStopInfo.getLongitude());
}
Home.getBusStopLocation = function () {
    return Home._busStopLocation;
}

//#endregion Variables Globales

//#region Constantes
//#endregion Constantes

Home.initializeComponents = function () {
    //Cargar AutoComplete de vehiculos
    Home.loadParentStudentsDataSource();
    //Inicializa el mapa
    Home.initializeMap();
    //Evento change del control para el ddl de opcion de fecha
    $("#ddlParentStudents").change(Home.ddlStudents_IndexChange);
    //Evento Click para refrescar la informacion del mapa
    $("#imgReloadInfo").click(Home.imgReloadInfo_onClick);
    //Evento click para ver u ocultar el detalle del paradero
    $("#tdOpenBusStopDetail").click(Home.tdOpenBusStopDetail_Click);
    var title = $("#hdnTitle").val();
    $("#lblTitle").text(title);
}

//#region Creacion del data source de los estudiantes del padre de familia
Home.loadParentStudentsDataSource = function () {
    $.ajax({
        url: "Home/LoadParentStudentsDataSource",
        cache: false,
        dataType: "json",
        success: function (result) {
            Home.loadParentStudentsDataSource_onSuccess(result);
        },
        error: function (request, status, error) {
            Home.loadParentStudentsDataSource_onError(request, status, error);
        }
    });
}

Home.loadParentStudentsDataSource_onSuccess = function (result) {
    if (result.errorMessage == null) {
        var parentStudents = "";
        $.each(result.Students, function (i, option) {
            var parentListItem = String.format("<option value='{0}'>{1}</option>", option.Value, option.Text);
            parentStudents += parentListItem;
        });
        $('#ddlParentStudents').html(parentStudents);
        $('#ddlParentStudents').prop("selectedIndex", 0).selectmenu('refresh');
        Home.ddlStudents_IndexChange();
    }
    else {
        alert(result.errorMessage);
    }
}

Home.loadParentStudentsDataSource_onError = function (request, status, error) {
    console.error(error);
}
//#endregion Creacion del data source de los estudiantes del padre de familia

//#region Eventos Controles

//Evento asociado al input para establecer el rango de tiempo de la consulta
Home.ddlStudents_IndexChange = function () {
    var studentId = $("#ddlParentStudents").val();
    //Cambio el nombre del titulo
    var title = $("#hdnTitle").val();
    $("#lblTitle").text(title);
    //Limpia la informacion del paradero
    $('#lblbusStopNameValue').text('');
    $('#lblBusStopAddressValue').text('');
    $('#lblProgramedArrivalTimeValue').text('');
    //Limpia la información del mapa
    Home.removeVehiclePositionOnMap();
    Home.removeBusStopPositionOnMap();
    //Carga la información del viaje del estudiante
    Home.getStudentActiveTrip(studentId);
}

//Evento asociado al boton de refrecar
Home.imgReloadInfo_onClick = function () {
    var studentId = $("#ddlParentStudents").val();
    //Cambio el nombre del titulo
    var title = $("#hdnTitle").val();
    $("#lblTitle").text(title);
    //Limpia la informacion del paradero
    $('#lblbusStopNameValue').text('');
    $('#lblBusStopAddressValue').text('');
    $('#lblProgramedArrivalTimeValue').text('');    
    //Carga la información del viaje del estudiante
    Home.getStudentActiveTrip(studentId);
}

//Evento Evento click para ver u ocultar el detalle del paradero
Home.tdOpenBusStopDetail_Click = function () {
    if (Home.tblDetailIsClose) {
        LayoutHelper.setVisible('tbBusStopDetailContent', true);
        Home.tblDetailIsClose = false;
    }
    else {
        LayoutHelper.setVisible('tbBusStopDetailContent', false);
        Home.tblDetailIsClose = true;
    }

}

//#endregion Eventos Controles

//#region Funciones Mapa

//Inicializar mapa en el formulario.
Home.initializeMap = function () {
    //Inicializacion del mapa
    var mapContainer = $("#divVehicleInfoMapView");
    if (mapContainer) {
        //Opciones de inicializacion del mapa.
        var mapOptions = {
            //Llave de desarrollo
            credentials: 'Aq1RiYL--2XXCr-gA8_dYfqyapwvI4RXNn1bN9YGuc3F4_p8_BNjL1lVHuc-r8b3',
            //Centro inicial
            center: BingMapHelper.createLocation('4.70343635992291', '-74.0283223986625'),
            //Zoom Inicial
            zoom: 6,
            //Vista por defecto
            mapTypeId: Microsoft.Maps.MapTypeId.road,
            //Deshabilitar teclado.
            disableKeyboardInput: true,
            //Deshabilitar la opcion para seleccionar el tipo de mapa
            showDashboard: false
        }
        //Inicializar el mapa.
        Home.map = BingMapHelper.createMap(mapContainer[0], mapOptions)
        //Agregar layers al mapa
        Home.map.entities.push(Home.mapVehicleLayer);
        Home.map.entities.push(Home.mapBusStopLayer);
        //Evento mousemove sobre el mapa
        Microsoft.Maps.Events.addHandler(Home.map, "mousemove", Home.map_MouseMove);

        //Permite dibujar todos los objetos de georeferencia en un solo layer.
        Home.map.getMode().setOptions({ drawShapesInSingleLayer: true });
    }
};

//Comportamiento del mousemove sobre el mapa.
Home.map_MouseMove = function (e) {
    // Obtiene el elemento HTML que representa el mapa
    var mapElem = Home.map.getRootElement();
    if (e.targetType === "map") {
        // Mouse esta sobre el mapa
        mapElem.style.cursor = Home.DEFAULT_CURSOR;
    }
    else {
        // Mouse esta sobre Pushpin, Polyline, Polygon o otro elemento
        mapElem.style.cursor = "pointer";
    }
};

//Adiciona pushpin de la ubicacion actual del vehículo en el mapa.
Home.addVehiclePositionOnMap = function () {
    //Remover ubicacion de vehiculos anteriores.
    Home.removeVehiclePositionOnMap();
    var vehicleInfo = new VehicleInfo();
    vehicleInfo.setVehicleInfo(Home.vehicleInfo);
    //Asigna valores a la variable de la posicion del vehiculo
    Home.setVehicleLocation(vehicleInfo);
    //Crear punto
    var pushLocation = Home.getVehicleLocation();
    var iconHeight = 26;
    var iconWidth = 26;
    //Opciones del pushpin.
    var pushpinOptions =
    {
        anchor: new Microsoft.Maps.Point(13, 13),
        icon: Home.vehicleIcon,
        width: iconWidth,
        height: iconHeight,
        zIndex: 1,
        typeName: 'CustomTextPushpin'
    };
    //Crear pushpin
    var pushpin = BingMapHelper.createPushpin(pushLocation, pushpinOptions);
    Home.mapVehicleLayer.push(pushpin);
}

//Adiciona pushpin de la ubicacion del paradero de ruta en el mapa.
Home.addBusStopOnMap = function () {
    //Remover ubicacion de paraderos anteriores.
    Home.removeBusStopPositionOnMap();
    var busStop = new BusStopInfo();
    busStop.setBusStopInfo(Home.busStopInfo);
    //Asigna valores a la variable de la posicion del vehiculo
    Home.setBusStopLocation(busStop);
    //Crear punto
    var pushLocation = Home.getBusStopLocation();
    var iconHeight = 26;
    var iconWidth = 26;
    //Opciones del pushpin.
    var pushpinOptions =
    {
        anchor: new Microsoft.Maps.Point(13, 13),
        icon: busStop.getIconPath(),
        width: iconWidth,
        height: iconHeight,
        zIndex: 1,
        typeName: 'CustomTextPushpin'
    };
    //Crear pushpin
    var pushpin = BingMapHelper.createPushpin(pushLocation, pushpinOptions);
    Home.mapBusStopLayer.push(pushpin);
}

//Limpia toda la informacion de vehiculos del mapa
Home.removeVehiclePositionOnMap = function () {
    Home.mapVehicleLayer.clear();
};

//Limpia toda la informacion de la ruta del vehiculo del mapa
Home.removeBusStopPositionOnMap = function () {
    Home.mapBusStopLayer.clear();
};

//#endregion Funciones Mapa

//#region Carga la informacion del viaje del estudiante
Home.getStudentActiveTrip = function (studentId) {
    $.ajax({
        url: "Home/GetStudentActiveTrip",
        cache: false,
        dataType: "json",
        data: {
            studentId: studentId
        },
        success: function (result) {
            Home.getStudentActiveTrip_onSuccess(result);
        },
        error: function (request, status, error) {
            Home.getStudentActiveTrip_onError(request, status, error);
        }
    });
}

Home.getStudentActiveTrip_onSuccess = function (result) {
    if (!result.errorMessage) {
        $('#hdnActiveTripId').val(result.TripId);
        Home.getVehicleInfoDetails(result.VehicleId);
        $('#lblProgramedArrivalTimeValue').text(result.ProgramedArrivalDate);
    }
    else {
        alert(result.errorMessage);
    }
}

Home.getStudentActiveTrip_onError = function (request, status, error) {
    console.error(error);
}

//#endregion Carga la informacion del viaje del estudiante

//#region Carga la informacion de loa ubicacion de la ruta del estudiante
Home.getVehicleInfoDetails = function (vehicleId) {
    $.ajax({
        url: "Home/GetVehicleInfoDetails",
        cache: false,
        dataType: "json",
        data: {
            vehicleId: vehicleId
        },
        success: function (result) {
            Home.getVehicleInfoDetails_onSuccess(result);
        },
        error: function (request, status, error) {
            Home.getVehicleInfoDetails_onError(request, status, error);
        }
    });
}

Home.getVehicleInfoDetails_onSuccess = function (result) {
    if (!result.errorMessage) {
        $('#hdnVehicleInfo').val(result.viewVehicleInfo);
        Home.vehicleInfo = result.viewVehicleInfo;
        //Dibuja el vehiculo en el mapa
        Home.addVehiclePositionOnMap();
        //Obtiene la informacion del paradero del estudiante
        var studentId = $('#ddlParentStudents').val();
        Home.getStudentBusStopInfo(studentId);
    }
    else {
        alert(result.errorMessage);
    }
}

Home.getVehicleInfoDetails_onError = function (request, status, error) {
    console.error(error);
}

//#endregion Carga la informacion de loa ubicacion de la ruta del estudiante

//#region Carga la información del paradero del estudiante

Home.getStudentBusStopInfo = function (studentId) {
    var activeTripId = $('#hdnActiveTripId').val();
    $.ajax({
        url: "Home/GetBusStopInfo",
        cache: false,
        dataType: "json",
        data: {
            studentId: studentId,
            tripId: activeTripId
        },
        success: function (result) {
            Home.getStudentBusStopInfo_onSuccess(result);
        },
        error: function (request, status, error) {
            Home.getStudentBusStopInfo_onError(request, status, error);
        }
    });
}

Home.getStudentBusStopInfo_onSuccess = function (result) {
    if (!result.errorMessage) {
        //Convertir a objeto json string capturado del campo hidden.
        var busStopInfo = jQuery.parseJSON(result.ViewTripScaleLocationInfo);
        $('#hdnBusStopInfo').val(busStopInfo.viewTripScaleLocationInfo);
        Home.busStopInfo = busStopInfo.viewTripScaleLocationInfo;
        //Cambio el titulo por el nombre de la ruta
        $("#lblTitle").text(result.RouteName);
        //Dibuja el paradero de ruta en el mapa
        Home.addBusStopOnMap();
        //Centra el mapa con base a la posicion del vehiculo y el paradero del estudiante
        var points = new Array();
        points.push(Home.getBusStopLocation());
        points.push(Home.getVehicleLocation());
        BingMapHelper.boundCenterMap(Home.map, points);
        //Establece la informacion del paradero
        $('#lblbusStopNameValue').text(Home.busStopInfo.checkPointName);
        $('#lblBusStopAddressValue').text(Home.busStopInfo.checkPointAddress);
        $('#lblProgramedArrivalTimeValue').text(Home.busStopInfo.formatedProgrammedDepartureTime);
    }
    else {
        alert(result.errorMessage);
    }
}

Home.getStudentBusStopInfo_onError = function (request, status, error) {
    console.error(error);
}

//#endregion Carga la información del paradero del estudiante