// ===================================================================================================
// Desarrollado Por		    :   Harold Caicedo.
// Fecha de Creación		:   2014/03/10.
// Producto o sistema	    :   Wizenz.Navi
// Empresa			        :   Wizenz Technologies
// Proyecto			        :   NAVI30
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

function Header() { }

Header.TimerClock = null;

Header.monthNamesShort = new Array(Resources.Formated_monthNamesShort_January, Resources.Formated_monthNamesShort_Febrary, Resources.Formated_monthNamesShort_March,
    Resources.Formated_monthNamesShort_April, Resources.Formated_monthNamesShort_May, Resources.Formated_monthNamesShort_June, Resources.Formated_monthNamesShort_July,
    Resources.Formated_monthNamesShort_Augost, Resources.Formated_monthNamesShort_September, Resources.Formated_monthNamesShort_October,
    Resources.Formated_monthNamesShort_November, Resources.Formated_monthNamesShort_December);

Header.dayNamesShort = new Array(Resources.Formated_dayNamesShort_Sunday, Resources.Formated_dayNamesShort_Monday, Resources.Formated_dayNamesShort_Tuesday,
    Resources.Formated_dayNamesShort_Wednesday, Resources.Formated_dayNamesShort_Thursday, Resources.Formated_dayNamesShort_Friday, Resources.Formated_dayNamesShort_Saturday);

//$(document).ready(function () {
//    startClock();
//});

Header.startClock = function () {
    Header.TimerClock = setInterval(function () {
        //refreshTime();
        Header.refreshFormatedTime();
    }, 1000);
}

Header.refreshFormatedTime = function () {
    var currentDate = new Date();
    var currentMonth = currentDate.getMonth();
    var currentDay = currentDate.getDay();
    var currentDateText = String.format("{0} {1} {2}", Header.dayNamesShort[currentDay], currentDate.format("dd"), Header.monthNamesShort[currentMonth]);
    var currentHourText = String.format("{0}", currentDate.format("hh:mm:ss"));
    var fullDateText = String.format("{0} {1}", currentDateText, currentHourText);
    //$("#lblHour").text(currentHourText);
    $("#lblDate").text(fullDateText);
}