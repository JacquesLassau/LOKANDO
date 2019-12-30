function ValidaCpfLocador(){

    var cpf = document.getElementById("txtCpfLocador").value;

    if (cpf.length !== 14) {
        $("#valCpfLocador").remove();
        alert("Cpf Locador inválido!");
        document.getElementById("txtCpfLocador").value = "";
        $("#validaCpfLocador").append("<p id='valCpfLocador' style='color:red;margin-top:2px;'>Deve ser preenchido corretamente</p>");
    }
    else {
        $("#valCpfLocador").remove();
    }
}