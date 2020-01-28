function PesquisarLocador() {

    event.preventDefault();

    document.getElementById("txtRzScLocador").value = null;
    document.getElementById("txtNmFsLocador").value = null;
    document.getElementById("txtEmailLocador").value = null;
    document.getElementById("txtDocumentoLocador").value = null;
    document.getElementById("txtTelefoneLocador").value = null;
    document.getElementById("txtEnderecoLocador").value = null;
    document.getElementById("txtCidadeLocador").value = null;
    document.getElementById("selEstadoLocador").value = null;
    document.getElementById("txtCepLocador").value = null;
    document.getElementById("selSituacaoLocador").value = null;
    document.getElementById("txtUltimaAtualizacaoLocador").value = null;

    var item = document.getElementById("txtCodigoLocador").value;

    if (item == "")
        item = 0;

    $.get("/Locador/SelecionarLocadorJR?codigoLocador=" + item, function (data) {

        if (data.EmailLocador != null) {

            $(function () {

                $("#listarLocador").modal("hide");
                $("#txtRzScLocador").val(data.RazaoSocialLocador);
                $("#txtNmFsLocador").val(data.NomeFantasiaLocador);
                $("#txtEmailLocador").val(data.EmailLocador);
                $("#txtDocumentoLocador").val(data.CpfCnpjLocador);               
                $("#txtTelefoneLocador").val(data.TelefoneLocador);
                $("#txtEnderecoLocador").val(data.EnderecoLocador);
                $("#txtCidadeLocador").val(data.CidadeLocador);
                $("#selEstadoLocador").val(data.EstadoLocador);
                $("#txtCepLocador").val(data.CepLocador);
                $("#selSituacaoLocador").val(data.SituacaoLocador);
                $("#txtUltimaAtualizacaoLocador").val(data.HoraRegistroLocador);

            });

        } else {

            $(function () {
                
                $("#txtRzScLocador").val(null);
                $("#txtNmFsLocador").val(null);
                $("#txtEmailLocador").val(null);
                $("#txtDocumentoLocador").val(null);
                $("#txtNascimentoLocador").val(null);
                $("#txtEmailLocador").val(null);
                $("#txtTelefoneLocador").val(null);
                $("#txtEnderecoLocador").val(null);
                $("#txtCidadeLocador").val(null);
                $("#selEstadoLocador").val(null);
                $("#txtCepLocador").val(null);
                $("#selSituacaoLocador").val(null);
                $("#txtUltimaAtualizacaoLocador").val(null);
                $("#listarLocador").modal("show");

            });
        }
    });
}

