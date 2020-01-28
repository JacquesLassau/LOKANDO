function ValidaDocumentoLocador(){

    var documento = document.getElementById("txtDocumentoLocador").value;
    
    if ((documento.length !== 14) && (documento.length !== 18)) {
        $("#valDocumentoLocador").remove();
        alert("Documento Locador inválido!");
        document.getElementById("txtDocumentoLocador").value = "";
        $("#validaDocumentoLocador").append("<p id='valDocumentoLocador' style='color:red;margin-top:2px;'>Deve ser preenchido corretamente</p>");
    }
    else {
        $("#valDocumentoLocador").remove();
    }
}