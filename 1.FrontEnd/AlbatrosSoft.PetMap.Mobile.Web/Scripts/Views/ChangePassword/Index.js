// ===================================================================================================
// Desarrollado Por		    :   Harold Caicedo.
// Fecha de Creación		:   2015/01/30.
// Producto o sistema	    :   Wizenz.Navi
// Empresa			        :   Wizenz Technologies
// Proyecto			        :   NAVI30
// Cliente			        :   Varios.
// ===================================================================================================
// Versión	        Descripción
// 1.0.0.0	        Funciones javascript de formulario index de la vista ChangePassword.
// ===================================================================================================
// HISTORIAL DE CAMBIOS:
// ===================================================================================================
// Ver.	 Fecha		    Autor					Descripción
// ---	 -------------	----------------------	------------------------------------------------------
// XX	 yyyy/MM/dd	    [Nombre Completo]	    [Razón del cambio realizado] 
// ===================================================================================================

function ChangePassword() { }

ChangePassword.initializeComponents = function () {
    //Evento de boton clic de cambio de contraseña.
    $("#btnChangePassword").click(ChangePassword.btnChangePassword_onClick);
    //Evento de boton cancelar.
    $("#btnCancel").click(ChangePassword.btnCancel_onClick);
};


ChangePassword.btnChangePassword_onClick = function (e) {
    $("#lblResultMessage").text('');
    $("#formChangeUserPassword").validationEngine({ promptPosition: "topLeft" })
    if (!$('#formChangeUserPassword').validationEngine('validate')) {
        e.preventDefault();
    }
}

ChangePassword.btnCancel_onClick = function (e) {
    $("#lblResultMessage").text('');
    window.self.history.back();
    e.preventDefault();
};