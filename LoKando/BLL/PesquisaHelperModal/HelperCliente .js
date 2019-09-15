function PesquisarCliente() {

    event.preventDefault();

    document.getElementById("txtNomeCliente").value = null;
    document.getElementById("txtRgCliente").value = null;
    document.getElementById("txtNascimentoCliente").value = null;
    document.getElementById("txtTelefoneCliente").value = null;
    document.getElementById("txtEnderecoCliente").value = null;
    document.getElementById("txtCidadeCliente").value = null;
    document.getElementById("txtEstadoCliente").value = null;
    document.getElementById("txtCepCliente").value = null;
    document.getElementById("txtSituacaoCliente").value = null;
    document.getElementById("txtUltimaAtualizacao").value = null;

    var item = document.getElementById("txtCodigoCliente").value;

    if (item == "")
        item = 0;

    $.get("/Cliente/SelecionarClienteJR?codigoCliente=" + item, function (data) {

        if (data.EmailCliente != null) {

            $(function () {

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

        } else {

            $(function () {

                $("#txtNomeCliente").val(null);
                $("#txtRgCliente").val(null);
                $("#txtNascimentoCliente").val(null);
                $("#txtTelefoneCliente").val(null);
                $("#txtEnderecoCliente").val(null);
                $("#txtCidadeCliente").val(null);
                $("#txtEstadoCliente").val(null);
                $("#txtCepCliente").val(null);
                $("#txtSituacaoCliente").val(null);
                $("#txtUltimaAtualizacao").val(null);
                $("#listarClientes").modal("show");

            });
        }
    });
}

