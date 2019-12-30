function CriarCpf() {
    $("#cpfLocador").remove();
    $("#cnpjLocador").remove();
    $("#validaCpfLocador").remove();
    $("#validaCnpjLocador").remove();
    $("#documentosLocador").append("<div class='form-group' id='cpfLocador'><label for='lblCpfLocador'>Cpf: </label><input class='form-control' type='text' id='txtCpfLocador' name='txtCpfLocador' placeholder = 'preencha aqui' required = 'required' onfocusout = 'ValidaCpfLocador()'></div><div id='validaCpfLocador' style='margin-top:-12px;;'></div></div>");
}

function CriarCnpj() {
    $("#cpfLocador").remove();
    $("#cnpjLocador").remove();
    $("#validaCpfLocador").remove();
    $("#validaCnpjLocador").remove();
    $("#documentosLocador").append("<div class = 'form-group' id='cnpjLocador'><label for='lblCnpjLocador'>Cnpj: </label><input class='form-control' type='text' id='txtCnpjLocador' name='txtCnpjLocador' placeholder = 'preencha aqui' required = 'required' onfocusout = 'ValidaCnpjLocador()'></div><div id='validaCnpjLocador' style='margin-top:-12px;'></div></div>");
}