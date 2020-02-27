function SelecionarVeiculoLocadorLinkModal(placaVeiculo) {

    event.preventDefault();

    var item = document.getElementById(placaVeiculo).value;

    $.get("/Veiculo/SelecionarVeiculoLocadorJR?placaVeiculo=" + item, function (data) {
        
        $("#listarVeiculoLocador").modal("hide");           
        $("#txtCodigoLocador").val(data.CodigoLocadorVeiculo);        
        $("#selTipoVeiculo").val(data.TipoVeiculo);
        $("#txtMarcaVeiculo").val(data.MarcaVeiculo);
        $("#txtModeloVeiculo").val(data.ModeloVeiculo);
        $("#txtCorVeiculo").val(data.CorVeiculo);
        $("#selCombustivelVeiculo").val(data.CombustivelVeiculo);
        $("#txtPlacaVeiculo").val(data.PlacaVeiculo);
        $("#txtRenavamVeiculo").val(data.RenavamVeiculo);
        $("#txtValorDiariaVeiculo").val(data.ValorDiaVeiculo);
        $("#selSituacaoVeiculo").val(data.SituacaoVeiculo);
        $("#txtAtualizacaoVeiculo").val(data.HoraRegistroVeiculo);

    });
}