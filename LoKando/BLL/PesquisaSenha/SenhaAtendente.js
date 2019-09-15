function SenhaAtendente() {

    var senhaAtendente = document.getElementById("txtSenhaAtendente").value;
    var confirmaSenhaAtendente = document.getElementById("txtConfirmaSenhaAtendente").value;

    if ((senhaAtendente != confirmaSenhaAtendente) && (senhaAtendente != "") && (confirmaSenhaAtendente != "")) {
        alert("Os campos de senha não são iguais. Por favor, tente novamente!");
        
        var senha = document.querySelector("#validaSenha > #senha");
        var confirmaSenha = document.querySelector("#confirmaSenha > #senhaConfirma");

        if (senha) {
            $("#txtSenhaAtendente").val(null);
            $("#txtConfirmaSenhaAtendente").val(null);
        } else {
            $("#txtSenhaAtendente").val(null);
            $("#txtConfirmaSenhaAtendente").val(null);            
            $("#validaSenha").append("<p id='senha' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
            $("#confirmaSenha").append("<p id='senhaConfirma' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
        }
        
    } else if ((senhaAtendente == confirmaSenhaAtendente) && (senhaAtendente != "") && (confirmaSenhaAtendente != "")) {
        
        $("#senha").remove();
        $("#senhaConfirma").remove();

    }

}

function ConfirmaSenhaAtendente() {

    var senhaAtendente = document.getElementById("txtSenhaAtendente").value;
    var confirmaSenhaAtendente = document.getElementById("txtConfirmaSenhaAtendente").value;    

    if ((senhaAtendente != confirmaSenhaAtendente) && (senhaAtendente != "") && (confirmaSenhaAtendente != "")) {
        alert("Os campos de senha não são iguais. Por favor, tente novamente!");        
        
        var senha = document.querySelector("#validaSenha > #senha");
        var confirmaSenha = document.querySelector("#confirmaSenha > #senhaConfirma");

        if (senha) {
            $("#txtSenhaAtendente").val(null);
            $("#txtConfirmaSenhaAtendente").val(null);
        } else {
            $("#txtSenhaAtendente").val(null);
            $("#txtConfirmaSenhaAtendente").val(null);
            $("#validaSenha").append("<p id='senha' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
            $("#confirmaSenha").append("<p id='senhaConfirma' style='color:red;margin-top:2px;'>Senhas não são iguais</p>");
        }

    } else if ((senhaAtendente == confirmaSenhaAtendente) && (senhaAtendente != "") && (confirmaSenhaAtendente != "")) {

        $("#senha").remove();
        $("#senhaConfirma").remove();

    }

}