﻿function ValidaCpf(){

    var cpf = document.getElementById("txtCpfCliente").value;

    if (cpf.length !== 14) {
        $("#valCpf").remove();
        alert("Cpf inválido!");
        $("#txtCpfCliente").val("");
        $("#validaCpf").append("<p id='valCpf' style='color:red;margin-top:2px;'>Deve ser preenchido corretamente</p>");
    }
    else {
        $("#valCpf").remove();
    }
}