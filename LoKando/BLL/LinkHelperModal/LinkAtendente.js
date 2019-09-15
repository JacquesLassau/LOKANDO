function SelecionarAtendenteLinkModal(idAtendente) {

    event.preventDefault();

    var item = document.getElementById(idAtendente).value;

    $.get("/Atendente/SelecionarAtendenteJR?codigoAtendente=" + item, function (data) {
        $("#listarAtendentes").modal("hide");
        $("#txtNomeAtendente").val(data.NomeAtendente);
        $("#txtEmailAtendente").val(data.EmailAtendente);
        $("#selSituacaoAtendente").val(data.SituacaoAtendente);
        $("#txtUltimaAtualizacao").val(data.HoraRegistroAtendente);
    });

    document.getElementById("txtCodigoAtendente").value = item;
}