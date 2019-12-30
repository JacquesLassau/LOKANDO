function SenhaLocador() {

    var senhaLocador = document.getElementById("txtSenhaLocador").value;
    var confirmaSenhaLocador = document.getElementById("txtConfirmaSenhaLocador").value;

    if ((senhaLocador != confirmaSenhaLocador) && (senhaLocador != "") && (confirmaSenhaLocador != "")) {
        alert("Os campos de senha não são iguais. Por favor, tente novamente!");

        var senha = document.querySelector("#validaSenha > #senha");
        var confirmaSenha = document.querySelector("#confirmaSenha > #senhaConfirma");

        if (senha) {
            $("#txtSenhaLocador").val(null);
            $("#txtConfirmaSenhaLocador").val(null);
        } else {
            $("#txtSenhaLocador").val(null);
            $("#txtConfirmaSenhaLocador").val(null);
            $("#validaSenha").append("<p id='senha' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
            $("#confirmaSenha").append("<p id='senhaConfirma' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
        }

    } else if ((senhaLocador == confirmaSenhaLocador) && (senhaLocador != "") && (confirmaSenhaLocador != "")) {

        $("#senha").remove();
        $("#senhaConfirma").remove();

    }

}

function ConfirmaSenhaLocador() {

    var senhaLocador = document.getElementById("txtSenhaLocador").value;
    var confirmaSenhaLocador = document.getElementById("txtConfirmaSenhaLocador").value;

    if ((senhaLocador != confirmaSenhaLocador) && (senhaLocador != "") && (confirmaSenhaLocador != "")) {
        alert("Os campos de senha não são iguais. Por favor, tente novamente!");

        var senha = document.querySelector("#validaSenha > #senha");
        var confirmaSenha = document.querySelector("#confirmaSenha > #senhaConfirma");

        if (senha) {
            $("#txtSenhaLocador").val(null);
            $("#txtConfirmaSenhaLocador").val(null);
        } else {
            $("#txtSenhaLocador").val(null);
            $("#txtConfirmaSenhaLocador").val(null);
            $("#validaSenha").append("<p id='senha' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
            $("#confirmaSenha").append("<p id='senhaConfirma' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
        }

    } else if ((senhaLocador == confirmaSenhaLocador) && (senhaLocador != "") && (confirmaSenhaLocador != "")) {

        $("#senha").remove();
        $("#senhaConfirma").remove();

    }

}