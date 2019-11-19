function PesquisarAtendente() {

    event.preventDefault();    
    
    document.getElementById("txtNomeAtendente").value = null;
    document.getElementById("txtEmailAtendente").value = null;
    document.getElementById("selSituacaoAtendente").value = null;
    document.getElementById("txtUltimaAtualizacao").value = null;  

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

        } else {

            $(function () {

                $("#txtNomeAtendente").val(null);
                $("#txtEmailAtendente").val(null);
                $("#selSituacaoAtendente").val(null);
                $("#txtUltimaAtualizacao").val(null);
                $("#listarAtendentes").modal("show");

            });
        }
    });
}

