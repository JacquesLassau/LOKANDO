function ValidaHabilitacao() {
    
    var habilitacao = document.getElementById("txtHabilitacaoCliente").value;

    if (habilitacao.lenth != 11) {
        $("#valHabilitacao").remove();
        alert("Habilitação inválida!");
        document.getElementById("txtHabilitacaoCliente").value = "";
        $("#validaHabilitacao").append("<p id='valHabilitacao' style='color:red;margin-top:2px;'>Deve ser preenchido corretamente</p>");
    }
    else
    {
        $("#valHabilitacao").remove();
    }
}