let valor;
let pacote;

function CompraPct() {

    alert("Você precisa está logado para realizar uma comprar.");


}

function Contato() {
    let msg = document.getElementById("msg");


    for (let i = 0; i < msg.lenght; i++) {
        msg.innerText = " ";
    }


    alert("Entraremos em contato em breve.")
}

function Pacote(id) {

    pacote = document.getElementById("" + id).children;
    document.getElementById("idpacote").value = pacote[0].innerHTML;
    document.getElementById("valor").value = pacote[2].innerHTML;
    document.getElementById("destino").value = pacote[3].innerHTML;
    document.getElementById("dataida").value = pacote[4].innerHTML;
    document.getElementById("datavolta").value = pacote[5].innerHTML;

    valor = pacote[2].innerHTML;

    if (valor.length >= 6) {
        valor = valor.substring(0, valor.indexOf("."));
    }


}

function Desconto() {
    let cupom = document.getElementById("cupom").value;
    let descontoAplicado = false;
    valor = valor.replace(/,/g, "").replace(/\./g, "");

    let valorNovo = parseInt(valor);



    if ((cupom.toUpperCase() === "SOMOSTODOSTRIBO") && (valorNovo <= 1000)) {
        valorNovo = valorNovo - (valorNovo * 0.05);
        descontoAplicado = true;

    } else if ((cupom.toUpperCase() === "INDIO") && (valorNovo > 1000) && (valorNovo <= 2000)) {
        valorNovo = valorNovo - (valorNovo * 0.10);
        descontoAplicado = true;

    } else if ((cupom.toUpperCase() === "MAISCULTURA") && (valorNovo > 2000) && (valorNovo <= 3000)) {
        valorNovo = valorNovo - (valorNovo * 0.15);
        descontoAplicado = true;

    } else if ((cupom.toUpperCase() === "CLIENTEVIP") && (valorNovo > 3000) && (valorNovo <= 3500)) {
        valorNovo = valorNovo - (valorNovo * 0.20);
        descontoAplicado = true;

    } else {
        document.getElementById("AspCp").innerHTML = "Cupom Inválido - Verifique Seu Cupom";

    }

    if (descontoAplicado == true) {


        var resultado = " " + valorNovo;

        console.log(resultado);

        if (resultado.length > 4) {
            resultado = resultado.substr(1, 1) + "." + resultado.substr(2, resultado.length);
            resultado += ",00"
        } else if (resultado.length <= 4) {

            resultado += ",00"
        }

        document.getElementById("valor").value = resultado;
        document.getElementById("AspCp").innerHTML = "Cupom Aplicado - Aproveite bem sua Viagem";


    }
}

$(function () {

    var ModalShow = $('#ModalAqui');

    $('button[data-bs-toggle="modalAjax"]').click(function (event) {

        var url = $(this).data('url');
        var decodeUrl = decodeURIComponent(url);

        $.get(decodeUrl).done(function (data) {
            ModalShow.html(data);
            ModalShow.find('.modal').modal('show');
        })

    })


    ModalShow.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attrt('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {
            ModalShow.find('.modal').modalViagem('hide');

        })
    })



})

