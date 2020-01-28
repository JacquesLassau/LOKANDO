function SelecionarLocadorLinkModal(idLocador) {

    event.preventDefault();

    var item = document.getElementById(idLocador).value;

    $.get("/Locador/SelecionarLocadorJR?codigoLocador=" + item, function (data) {
        
        $("#txtNomeLocador").val(data.NomeLocador);
        $("#txtHabilitacaoLocador").val(data.HabilitacaoLocador);
        $("#txtCpfLocador").val(data.CpfLocador);
        $("#txtRgLocador").val(data.RgLocador);
        $("#txtNascimentoLocador").val(data.NascimentoLocadorStr);
        $("#txtEmailLocador").val(data.EmailLocador);
        $("#txtTelefoneLocador").val(data.TelefoneLocador);
        $("#txtEnderecoLocador").val(data.EnderecoLocador);
        $("#txtCidadeLocador").val(data.CidadeLocador);
        $("#selEstadoLocador").val(data.EstadoLocador);
        $("#txtCepLocador").val(data.CepLocador);
        $("#selSituacaoLocador").val(data.SituacaoLocador);
        $("#txtUltimaAtualizacaoLocador").val(data.HoraRegistroLocador);
        $("#listarLocadors").modal("hide");

    });

    document.getElementById("txtCodigoLocador").value = item;

}