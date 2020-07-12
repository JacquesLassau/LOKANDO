function TxtPesquisarCliente() {

    event.preventDefault();
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
                $("#txtBairroCliente").val(data.BairroCliente);
                $("#txtCidadeCliente").val(data.CidadeCliente);
                $("#selEstadoCliente").val(data.EstadoCliente);
                $("#txtCepCliente").val(data.CepCliente);
                $("#selSituacaoCliente").val(data.SituacaoCliente);
                $("#txtUltimaAtualizacaoCliente").val(data.HoraRegistroCliente);

            });
        } 
    });
}

function BtnPesquisarCliente() {    

    document.getElementById("txtCodigoCliente").value = null;
    document.getElementById("txtNomeCliente").value = null;
    document.getElementById("txtHabilitacaoCliente").value = null;
    document.getElementById("txtCpfCliente").value = null;
    document.getElementById("txtRgCliente").value = null;
    document.getElementById("txtNascimentoCliente").value = null;
    document.getElementById("txtEmailCliente").value = null;
    document.getElementById("txtTelefoneCliente").value = null;
    document.getElementById("txtEnderecoCliente").value = null;
    document.getElementById("txtBairroCliente").value = null;
    document.getElementById("txtCidadeCliente").value = null;
    document.getElementById("selEstadoCliente").value = null;
    document.getElementById("txtCepCliente").value = null;
    document.getElementById("selSituacaoCliente").value = null;
    document.getElementById("txtUltimaAtualizacaoCliente").value = null;

}

