function SelecionarClienteLinkModal(idCliente) {

    event.preventDefault();

    var item = document.getElementById(idCliente).value;

    $.get("/Cliente/SelecionarClienteJR?codigoCliente=" + item, function (data) {
        
        $("#txtNomeCliente").val(data.NomeCliente);
        $("#txtHabilitacaoCliente").val(data.HabilitacaoCliente);
        $("#txtCpfCliente").val(data.CpfCliente);
        $("#txtRgCliente").val(data.RgCliente);
        $("#txtNascimentoCliente").val(data.NascimentoClienteStr);
        $("#txtEmailCliente").val(data.EmailCliente);
        $("#txtTelefoneCliente").val(data.TelefoneCliente);
        $("#txtEnderecoCliente").val(data.EnderecoCliente);
        $("#txtCidadeCliente").val(data.CidadeCliente);
        $("#selEstadoCliente").val(data.EstadoCliente);
        $("#txtCepCliente").val(data.CepCliente);
        $("#selSituacaoCliente").val(data.SituacaoCliente);
        $("#txtUltimaAtualizacaoCliente").val(data.HoraRegistroCliente);
        $("#listarClientes").modal("hide");

    });

    document.getElementById("txtCodigoCliente").value = item;
}