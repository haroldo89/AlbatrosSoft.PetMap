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

function Login() { }

Login.initializeComponents = function () {
    //Limpiar variables de session
    Login.clearSessionData();
    //Foco en el input usuario
    document.getElementById("txtUsername").focus();
    $.get('http://jsonip.com/', function (r) {
        $("#hdnClientIpAddress").val(r.ip);
    });
    $("#txtUsername").blur(Login.txtUsername_Blur)
    $("#btnLogin").click(Login.btnLogin_Click);
    $("#lnkUser").click(Login.lnkUser_Click);
}

Login.txtUsername_Blur = function () {
    $.get('http://jsonip.com/', function (r) {
        $("#hdnClientIpAddress").val(r.ip);
    });
}

//Permite eliminar el contenido de las variables de session.
Login.clearSessionData = function () {
    sessionStorage.clear();
}

Login.btnLogin_Click = function (e) {
    $("#lblResultMessage").text('');
    $("#frmLogin").validationEngine({ promptPosition: "topLeft" })
    if (!$('#frmLogin').validationEngine('validate')) {
        //Formulario no hace submit.
        e.preventDefault();
    }
}

Login.lnkUser_Click = function (event) {
    event.preventDefault();
    var href = $(this).attr('href');
    $.mobile.changePage(href, { role: 'dialog', transition: 'pop' });
    $("#dialogPage").dialog({
        corners: false,
        closeBtn: "right",
        closeBtnText: "Cerrar"
    });
}
