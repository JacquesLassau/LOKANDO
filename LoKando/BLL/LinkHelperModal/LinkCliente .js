function SelecionarClienteLinkModal(idCliente) {

    event.preventDefault();

    var item = document.getElementById(idCliente).value;

    $.get("/Cliente/SelecionarClienteJR?codigoCliente=" + item, function (data) {
        $("#listarClientes").modal("hide");
        $("#txtNomeCliente").val(data.NomeCliente);
        $("#txtHabilitacaoCliente").val(data.HabilitacaoCliente);
        $("#txtCpfCliente").val(data.CpfCliente);
        $("#txtRgCliente").val(data.RgCliente);
        $("#txtNascimentoCliente").val(data.NascimentoCliente);
        $("#txtEmailCliente").val(data.EmailCliente);
        $("#txtTelefoneCliente").val(data.TelefoneCliente);        
        $("#txtEnderecoCliente").val(data.EnderecoCliente);
        $("#txtCidadeCliente").val(data.CidadeCliente);
        $("#txtEstadoCliente").val(data.EstadoCliente);
        $("#txtCepCliente").val(data.CepCliente);
        $("#txtSituacaoCliente").val(data.SituacaoCliente);
        $("#txtUltimaAtualizacao").val(data.HoraRegistroCliente);
    });
    
    document.getElementById("txtCodigoCliente").vallue = item;
}