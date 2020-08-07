// ===================================================================================================
// Desarrollado Por		    :   Harold Caicedo.
// Fecha de Creación		:   2015/05/04.
// Producto o sistema	    :   Wizenz.Navi
// Empresa			        :   Wizenz Technologies
// Proyecto			        :   NAVI30
// Cliente			        :   Varios.
// ===================================================================================================
// Versión	        Descripción
// 1.0.0.0	        Ventana modal para informacion de estado de pago del cliente.
// ===================================================================================================
// HISTORIAL DE CAMBIOS:
// ===================================================================================================
// Ver.	 Fecha		    Autor					Descripción
// ---	 -------------	----------------------	------------------------------------------------------
// XX	 yyyy/MM/dd	    [Nombre Completo]	    [Razón del cambio realizado] 
// ===================================================================================================
function BillingStatusMessageBox() { }

//Timer global del Alertas
BillingStatusMessageBox.billingStatusTimer = null;
//Estado de facturacion del cliente.
BillingStatusMessageBox.selectedBillingStatusId = null;
//URL de sonido
BillingStatusMessageBox.ALERT_SOUND_URL = "http://navistoragesvc.blob.core.windows.net/navi-appsounds/AppCriticalError.mp3";
//Estado de cuenta activa
BillingStatusMessageBox.ACTIVE_BILLING_STATUS_ID = 1;
//Estado de cuenta en mora.
BillingStatusMessageBox.LATE_PAYMENT_BILLING_STATUS_ID = 2;
//Estado de cuenta suspendida.
BillingStatusMessageBox.SUSPENDED_BILLING_STATUS_ID = 3;

BillingStatusMessageBox.initializeComponets = function () {
    $("#divBillingStatusMessageBox").enhanceWithin().popup();
    //Estableces valor de Timespan de stado de facturacion
    var billingStatusTimespan = $("#hdnBillingStatusTimespan").val();
    if (!CommonUtils.isNullOrEmpty(billingStatusTimespan)) {
        //Guardar en variable de session valor de timespan de estado de facturacion.
        sessionStorage.setItem('billingStatusTimespan', billingStatusTimespan);
    }
    $("#btnBillingStatusMessageBoxOk").click(BillingStatusMessageBox.btnBillingStatusMessageBoxOk_Click)
    //Detener timer
    BillingStatusMessageBox.stopBillingStatusTimer();
    //Inicializar timer
    BillingStatusMessageBox.startBillingStatusTimer();
    //Obtener informacion de cliente.
    BillingStatusMessageBox.getCustomerInfo();
}

//Permite detener el timer de detalle de vehiculo seleccionado.
BillingStatusMessageBox.stopBillingStatusTimer = function () {
    if (BillingStatusMessageBox.billingStatusTimer != null) {
        //Detener timer de detalles de vehiculo.
        window.clearInterval(BillingStatusMessageBox.billingStatusTimer);
    }
}


BillingStatusMessageBox.startBillingStatusTimer = function () {
    //Obtener valor de timesapan de refresco
    var vehicleAlertsInfoRefreshTimeSpan = BillingStatusMessageBox.getCustomerInfoRefreshTimeSpan();
    //Inicializar timer de obtener informacion de cliente.
    BillingStatusMessageBox.billingStatusTimer = window.setInterval(BillingStatusMessageBox.billingStatusTimer_Tick, vehicleAlertsInfoRefreshTimeSpan);
}


BillingStatusMessageBox.billingStatusTimer_Tick = function () {
    BillingStatusMessageBox.getCustomerInfo();
}

//Obtener informacion de cliente asociado al nombre de usuario
BillingStatusMessageBox.getCustomerInfo = function () {
    $.ajax({
        url: "/Base/GetCustomerInfo",
        cache: false,
        dataType: "json",
        success: function (result) {
            BillingStatusMessageBox.getCustomerInfo_onSuccess(result);
        },
        error: function (request, status, error) {
            BillingStatusMessageBox.getCustomerInfo_onError(request, status, error);
        }
    });
}

BillingStatusMessageBox.getCustomerInfo_onSuccess = function (result) {
    if (result.errorMessage == null) {
        BillingStatusMessageBox.selectedBillingStatusId = result.viewCustomerInfo.billingStatusId;
        //Estado de facturacion es diferente a activo
        if (BillingStatusMessageBox.selectedBillingStatusId != BillingStatusMessageBox.ACTIVE_BILLING_STATUS_ID) {
            //Abrir ventana modal.
            BillingStatusMessageBox.show();
          
        }
    }
    else {
        console.error(result.errorMessage);
    }
}

BillingStatusMessageBox.getCustomerInfo_onError = function (request, status, error) {
    console.error("Error desconocido obteniendo informacion del cliente en estado de facturacion.");
}

//Obtener intervalo de tiempo de refresco de informacion de vehiculos en las vista de mapa y tabla.
BillingStatusMessageBox.getCustomerInfoRefreshTimeSpan = function () {
    //30 segundos por defecto
    var DEFAULT_TIMESPAN = 30 * 1000;
    //Obtener valor de refresco de consulta de facturacion del cliente.
    var billingStatusTimespan = sessionStorage.getItem('billingStatusTimespan');
    if (!CommonUtils.isNullOrEmpty(billingStatusTimespan)) {
        var billingStatusTimespanValue = parseInt(billingStatusTimespan) * 1000;
        return billingStatusTimespanValue;
    }
    return DEFAULT_TIMESPAN;
}

//Ventana modal Alert Generico.
//Param<"Message">Mensaje a mostrar en ventana modal.</Param>
//Param<"title">Titulo de la ventana modal.</Param>
BillingStatusMessageBox.show = function () {
    if (BillingStatusMessageBox.selectedBillingStatusId) {
        BillingStatusMessageBox.show_onOpen();
    }
    else {
        console.error("el valor de mensaje no puede ser nulo o vacio")
    }
}

BillingStatusMessageBox.show_onOpen = function () {
    BillingStatusMessageBox.getDealerInfo();
}

BillingStatusMessageBox.show_onClose = function () {
    $("#divBillingStatusMessageBox").popup("close");
    //Valida si la cuenta del usuario se encuentra suspendida.
    if (BillingStatusMessageBox.selectedBillingStatusId == BillingStatusMessageBox.SUSPENDED_BILLING_STATUS_ID) {
        window.parent.location = '/Login/LogOff';
    }
}

//Obtener informacion de distribuidor.
BillingStatusMessageBox.getDealerInfo = function () {
    $.ajax({
        url: "/Base/GetDealerInfo",
        cache: false,
        dataType: "json",
        success: function (result) {
            BillingStatusMessageBox.getDealerInfo_onSuccess(result);
        },
        error: function (request, status, error) {
            BillingStatusMessageBox.getDealerInfo_onError(request, status, error);
        }
    });
}

BillingStatusMessageBox.getDealerInfo_onSuccess = function (result) {
    if (result) {
        if (result.errorMessage == null) {
            //Obtener informacion de distribuidor.
            var dealerInfo = result.viewDealerInfo;
            var dealerName = dealerInfo.dealerName;
            var dealerPhone = dealerInfo.phone;
            var dealerEmail = dealerInfo.email;
            switch (BillingStatusMessageBox.selectedBillingStatusId) {
                case BillingStatusMessageBox.LATE_PAYMENT_BILLING_STATUS_ID:
                    //Establecer mensaje a ventana modal
                    $("#lblBillingStatusMessageBox").text(String.format(Resources.Customer_Late_Payment_Billing_Status_Info, dealerName));
                    $("#lblBillingstatusDealerTelephone").text(dealerPhone);
                    $("#lblBillingStatusDealerEmail").text(dealerEmail);
                    break;
                case BillingStatusMessageBox.SUSPENDED_BILLING_STATUS_ID:
                    //Establecer mensaje a ventana modal
                    $("#lblBillingStatusMessageBox").text(String.format(Resources.Customer_Suspended_Billing_Status_Info, dealerName));
                    $("#lblBillingstatusDealerTelephone").text(dealerPhone);
                    $("#lblBillingStatusDealerEmail").text(dealerEmail);
                    break;
                default:
                    //Establecer mensaje a ventana modal
                    $("#lblBillingStatusMessageBox").text(String.format(Resources.Customer_Late_Payment_Billing_Status_Info, dealerName));
                    $("#lblBillingstatusDealerTelephone").text(dealerPhone);
                    $("#lblBillingStatusDealerEmail").text(dealerEmail);
                    break;
            }
            $("#divBillingStatusMessageBox").popup("open")
            //Ejecutar sonido de alerta.
            LayoutHelper.playSound("audBillingStatus", BillingStatusMessageBox.ALERT_SOUND_URL);
        }
        else {
            console.error(result.errorMessage);
            //MessageBox.show(result.errorMessage);
        }
    }
}

BillingStatusMessageBox.getDealerInfo_onError = function (request, status, error) {
    console.error("Error desconocido obteniendo informacion de distribuidor");
}

BillingStatusMessageBox.btnBillingStatusMessageBoxOk_Click = function () {
    BillingStatusMessageBox.show_onClose();
}