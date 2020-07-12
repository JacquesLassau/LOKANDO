function TxtPesquisarAtendente() {

    event.preventDefault();
    var item = document.getElementById("txtCodigoAtendente").value;

    if (item == "")
        item = 0;

    $.get("/Atendente/SelecionarAtendenteJR?codigoAtendente=" + item, function (data) {

        if (data.EmailAtendente != null) {

            $(function () {

                $("#listarAtendentes").modal("hide");
                $("#txtNomeAtendente").val(data.NomeAtendente);
                $("#txtEmailAtendente").val(data.EmailAtendente);
                $("#selSituacaoAtendente").val(data.SituacaoAtendente);
                $("#txtUltimaAtualizacao").val(data.HoraRegistroAtendente);

            });
        }
    });
}

function BtnPesquisarAtendente() {

    document.getElementById("txtNomeAtendente").value = null;
    document.getElementById("txtEmailAtendente").value = null;
    document.getElementById("selSituacaoAtendente").value = null;
    document.getElementById("txtUltimaAtualizacao").value = null;
    document.getElementById("txtCodigoAtendente").value = null;

}

