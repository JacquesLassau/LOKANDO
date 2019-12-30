function ValidaCnpjLocador() {

    var cpf = document.getElementById("txtCnpjLocador").value;

    if (cpf.length !== 18) {
        $("#valCnpjLocador").remove();
        alert("Cnpj inválido!");
        document.getElementById("txtCnpjLocador").value = "";
        $("#validaCnpjLocador").append("<p id='valCnpjLocador' style='color:red;margin-top:2px;'>Deve ser preenchido corretamente</p>");
    }
    else {
        $("#valCnpjLocador").remove();
    }
}