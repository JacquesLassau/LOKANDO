function SenhaCliente() {

    var senhaCliente = document.getElementById("txtSenhaCliente").value;
    var confirmaSenhaCliente = document.getElementById("txtConfirmaSenhaCliente").value;

    if ((senhaCliente != confirmaSenhaCliente) && (senhaCliente != "") && (confirmaSenhaCliente != "")) {
        alert("Os campos de senha não são iguais. Por favor, tente novamente!");

        var senha = document.querySelector("#validaSenha > #senha");
        var confirmaSenha = document.querySelector("#confirmaSenha > #senhaConfirma");

        if (senha) {
            $("#txtSenhaCliente").val(null);
            $("#txtConfirmaSenhaCliente").val(null);
        } else {
            $("#txtSenhaCliente").val(null);
            $("#txtConfirmaSenhaCliente").val(null);
            $("#validaSenha").append("<p id='senha' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
            $("#confirmaSenha").append("<p id='senhaConfirma' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
        }

    } else if ((senhaCliente == confirmaSenhaCliente) && (senhaCliente != "") && (confirmaSenhaCliente != "")) {

        $("#senha").remove();
        $("#senhaConfirma").remove();

    }

}

function ConfirmaSenhaCliente() {

    var senhaCliente = document.getElementById("txtSenhaCliente").value;
    var confirmaSenhaCliente = document.getElementById("txtConfirmaSenhaCliente").value;

    if ((senhaCliente != confirmaSenhaCliente) && (senhaCliente != "") && (confirmaSenhaCliente != "")) {
        alert("Os campos de senha não são iguais. Por favor, tente novamente!");

        var senha = document.querySelector("#validaSenha > #senha");
        var confirmaSenha = document.querySelector("#confirmaSenha > #senhaConfirma");

        if (senha) {
            $("#txtSenhaCliente").val(null);
            $("#txtConfirmaSenhaCliente").val(null);
        } else {
            $("#txtSenhaCliente").val(null);
            $("#txtConfirmaSenhaCliente").val(null);
            $("#validaSenha").append("<p id='senha' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
            $("#confirmaSenha").append("<p id='senhaConfirma' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
        }

    } else if ((senhaCliente == confirmaSenhaCliente) && (senhaCliente != "") && (confirmaSenhaCliente != "")) {

        $("#senha").remove();
        $("#senhaConfirma").remove();

    }

}