function ValidaDataNasimento(){    

    var data = document.getElementById("txtNascimentoCliente").value;
    data = data.replace(/\//g, "-");
    var data_array = data.split("-");

    if (data_array[0].length != 4) {
        data = data_array[2] + "-" + data_array[1] + "-" + data_array[0];
    }

    var hoje = new Date();
    var nasc = new Date(data);
    var idade = hoje.getFullYear() - nasc.getFullYear();
    var m = hoje.getMonth() - nasc.getMonth();
    if (m < 0 || (m === 0 && hoje.getDate() < nasc.getDate())) idade--;

    if (idade < 18) {
        $("#valNasc").remove();
        alert("Pessoas menores de 18 anos não podem ser clientes!");
        document.getElementById("txtNascimentoCliente").value = "";
        $("#validaNascimento").append("<p id='valNasc' style='color:red;margin-top:2px;'>Apenas maiores de 18 anos</p>");
    } else if (idade > 120) {
        $("#valNasc").remove();
        alert("Pessoas maiores de 120 anos não estão autorizadas a alugar um veículo!");
        document.getElementById("txtNascimentoCliente").value = "";
        $("#validaNascimento").append("<p id='valNasc' style='color:red;margin-top:2px;'>Não é aconselhado idosos dirigirem</p>");
    } else {
        $("#valNasc").remove();
    }
}
