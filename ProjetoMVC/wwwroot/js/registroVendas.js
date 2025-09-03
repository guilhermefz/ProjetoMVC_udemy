$(document).ready(function () {

    $("#btnAdicionarItem").click(function () {

        var produtoId = $("#itemProduto").val();
        var produtoNome = $("#itemProduto").find("option:selected").text();
        var quantidade = $("#itemQuantidade").val();
        var valor = $("#itemValor").val();

        if (!produtoId || !quantidade || !valor) {
            alert("Por favor, preencha todos os campos do item.");
            return;
        }

        var subtotal = quantidade * valor;

        var novaLinha = '<tr>'
            + '<td>' + produtoNome + '</td>'
            + '<td>' + quantidade + '</td>'
            + '<td>' + valor + '</td>'
            + '<td>' + subtotal.toFixed(2) + '</td>'
            + '<td><button type="button" class="btn btn-danger btn-sm">Remover</button></td>'
            + '</tr>';

        $("#tabelaItens").append(novaLinha);

        $("#itemProduto").val('');
        $("#itemQuantidade").val('');
        $("#itemValor").val('');
    });
});