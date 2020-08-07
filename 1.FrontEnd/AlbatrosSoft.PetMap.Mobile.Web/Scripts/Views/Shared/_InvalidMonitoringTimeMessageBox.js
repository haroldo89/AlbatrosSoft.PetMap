// ===================================================================================================
// Desarrollado Por		    :   Hernando Velez.
// Fecha de Creación		:   2015/08/25.
// Producto o sistema	    :   Wizenz.Navi
// Empresa			        :   Wizenz Technologies
// Proyecto			        :   NAVI30 Parent Viewer
// Cliente			        :   Varios.
// ===================================================================================================
// Versión	        Descripción
// 1.0.0.0	        Funciones javascript de formulario index de la vista Login.
// ===================================================================================================
// HISTORIAL DE CAMBIOS:
// ===================================================================================================
// Ver.	 Fecha		    Autor					Descripción
// ---	 -------------	----------------------	------------------------------------------------------
// XX	 yyyy/MM/dd	    [Nombre Completo]	    [Razón del cambio realizado] 
// ===================================================================================================

function InvalidMonitoringTimeMessageBox() { }

//Timer global del Alertas
InvalidMonitoringTimeMessageBox.validMonitoringHourTimer = null;

InvalidMonitoringTimeMessageBox.initializeComponets = function () {
    $("#divInvalidMonitoringTimeMessageBox").enhanceWithin().popup();
    //Evento click del boton del dialog
    $("#btnInvalidMonitoringTimeMessageBoxOk").click(InvalidMonitoringTimeMessageBox.btnInvalidMonitoringTimeMessageBoxMessageBoxOk_Click);
    //Detener timer
    InvalidMonitoringTimeMessageBox.stopValidMonitoringHourTimer();
    //Inicializar timer
    InvalidMonitoringTimeMessageBox.startValidMonitoringHour();
}

//Funcion para detener el timer.
InvalidMonitoringTimeMessageBox.stopValidMonitoringHourTimer = function () {
    if (InvalidMonitoringTimeMessageBox.validMonitoringHourTimer != null) {
        //Detener timer de detalles de vehiculo.
        window.clearInterval(InvalidMonitoringTimeMessageBox.validMonitoringHourTimer);
    }
}

//Funcion para iniciar el timer
InvalidMonitoringTimeMessageBox.startValidMonitoringHour = function () {
    var DEFAULT_TIMESPAN = 60 * 1000;
    //Inicializar timer de obtener informacion de cliente.
    InvalidMonitoringTimeMessageBox.validMonitoringHourTimer = window.setInterval(InvalidMonitoringTimeMessageBox.getValidMonitoringHour, DEFAULT_TIMESPAN);
}

//Funcion para establecer si el padre de familia se encuentra monitoreando en una hora valida
InvalidMonitoringTimeMessageBox.getValidMonitoringHour = function () {
    $.ajax({
        url: "/Base/GetMonitoringValidHourInfo",
        cache: false,
        dataType: "json",
        success: function (result) {
            InvalidMonitoringTimeMessageBox.getValidMonitoringHour_onSuccess(result);
        },
        error: function (request, status, error) {
            InvalidMonitoringTimeMessageBox.getValidMonitoringHour_onError(request, status, error);
        }
    });
}

InvalidMonitoringTimeMessageBox.getValidMonitoringHour_onSuccess = function (result) {
    //Estado de facturacion es diferente a activo
    if (!CommonUtils.isNullOrEmpty(result.Message)) {
        //Abrir ventana modal.
        InvalidMonitoringTimeMessageBox.show(result.Message);
    }
}

InvalidMonitoringTimeMessageBox.getValidMonitoringHour_onError = function (request, status, error) {
    console.error(error);
}

InvalidMonitoringTimeMessageBox.show = function (message) {
    if (!CommonUtils.isNullOrEmpty(message)) {
        InvalidMonitoringTimeMessageBox.show_onOpen(message);
    }
    else {
        console.error("el valor de mensaje no puede ser nulo o vacio");
    }
}

InvalidMonitoringTimeMessageBox.show_onOpen = function (message) {
    $("#lblInvalidMonitoringTimeMessageBox").text(message);
    $("#divInvalidMonitoringTimeMessageBox").popup("open");
}

InvalidMonitoringTimeMessageBox.show_onClose = function () {
    $("#divInvalidMonitoringTimeMessageBox").popup("close");
    //Redirige a la pagina del login.
    window.parent.location = '/Login/LogOff';
}

InvalidMonitoringTimeMessageBox.btnInvalidMonitoringTimeMessageBoxMessageBoxOk_Click = function () {
    InvalidMonitoringTimeMessageBox.show_onClose();
}