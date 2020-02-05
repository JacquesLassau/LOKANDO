function PesquisarCliente() {

    event.preventDefault();

    document.getElementById("txtNomeCliente").value = null;
    document.getElementById("txtEmailCliente").value = null;
    document.getElementById("selSituacaoCliente").value = null;
    document.getElementById("txtUltimaAtualizacaoCliente").value = null;

    var item = document.getElementById("txtCodigoCliente").value;

    if (item == "")
        item = 0;

    $.get("/Cliente/SelecionarClienteJR?codigoCliente=" + item, function (data) {

        if (data.EmailCliente != null) {

            $(function () {

                $("#listarCliente").modal("hide");
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

            });

        } else {

            $(function () {
                
                $("#txtNomeCliente").val(null);
                $("#txtHabilitacaoCliente").val(null);
                $("#txtCpfCliente").val(null);
                $("#txtRgCliente").val(null);
                $("#txtNascimentoCliente").val(null);
                $("#txtEmailCliente").val(null);
                $("#txtTelefoneCliente").val(null);
                $("#txtEnderecoCliente").val(null);
                $("#txtCidadeCliente").val(null);
                $("#selEstadoCliente").val(null);
                $("#txtCepCliente").val(null);
                $("#selSituacaoCliente").val(null);
                $("#txtUltimaAtualizacaoCliente").val(null);
                $("#listarCliente").modal("show");

            });
        }
    });
}

