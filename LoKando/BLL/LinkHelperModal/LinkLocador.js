function SelecionarLocadorLinkModal(idLocador) {

    event.preventDefault();

    var item = document.getElementById(idLocador).value;

    $.get("/Locador/SelecionarLocadorJR?codigoLocador=" + item, function (data) {
        
        $("#listarLocador").modal("hide");
        $("#txtRzScLocador").val(data.RazaoSocialLocador);
        $("#txtNmFsLocador").val(data.NomeFantasiaLocador);
        $("#txtEmailLocador").val(data.EmailLocador);
        $("#txtDocumentoLocador").val(data.CpfCnpjLocador);
        $("#txtTelefoneLocador").val(data.TelefoneLocador);
        $("#txtEnderecoLocador").val(data.EnderecoLocador);
        $("#txtBairroLocador").val(data.BairroLocador);
        $("#txtCidadeLocador").val(data.CidadeLocador);
        $("#selEstadoLocador").val(data.EstadoLocador);
        $("#txtCepLocador").val(data.CepLocador);
        $("#selSituacaoLocador").val(data.SituacaoLocador);
        $("#txtUltimaAtualizacaoLocador").val(data.HoraRegistroLocador);

    });

    document.getElementById("txtCodigoLocador").value = item;

}