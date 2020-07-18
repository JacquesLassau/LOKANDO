function SenhaUsuario() {

    var senhaUsuario = document.getElementById("txtNovaSenhaUsuario").value;
    var confirmaSenhaUsuario = document.getElementById("txtConfirmaNovaSenhaUsuario").value;

    if ((senhaUsuario != confirmaSenhaUsuario) && (senhaUsuario != "") && (confirmaSenhaUsuario != "")) {
        alert("Os campos de senha não são iguais. Por favor, tente novamente!");

        var senha = document.querySelector("#validaSenha > #senha");
        var confirmaSenha = document.querySelector("#confirmaSenha > #senhaConfirma");

        if (senha) {
            $("#txtNovaSenhaUsuario").val(null);
            $("#txtConfirmaNovaSenhaUsuario").val(null);
        } else {
            $("#txtNovaSenhaUsuario").val(null);
            $("#txtConfirmaNovaSenhaUsuario").val(null);
            $("#validaSenha").append("<p id='senha' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
            $("#confirmaSenha").append("<p id='senhaConfirma' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
        }

    } else if ((senhaUsuario == confirmaSenhaUsuario) && (senhaUsuario != "") && (confirmaSenhaUsuario != "")) {

        $("#senha").remove();
        $("#senhaConfirma").remove();

    }

}

function ConfirmaSenhaUsuario() {

    var senhaUsuario = document.getElementById("txtNovaSenhaUsuario").value;
    var confirmaSenhaUsuario = document.getElementById("txtConfirmaNovaSenhaUsuario").value;

    if ((senhaUsuario != confirmaSenhaUsuario) && (senhaUsuario != "") && (confirmaSenhaUsuario != "")) {
        alert("Os campos de senha não são iguais. Por favor, tente novamente!");

        var senha = document.querySelector("#validaSenha > #senha");
        var confirmaSenha = document.querySelector("#confirmaSenha > #senhaConfirma");

        if (senha) {
            $("#txtNovaSenhaUsuario").val(null);
            $("#txtConfirmaNovaSenhaUsuario").val(null);
        } else {
            $("#txtNovaSenhaUsuario").val(null);
            $("#txtConfirmaNovaSenhaUsuario").val(null);
            $("#validaSenha").append("<p id='senha' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
            $("#confirmaSenha").append("<p id='senhaConfirma' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
        }

    } else if ((senhaUsuario == confirmaSenhaUsuario) && (senhaUsuario != "") && (confirmaSenhaUsuario != "")) {

        $("#senha").remove();
        $("#senhaConfirma").remove();

    }

}