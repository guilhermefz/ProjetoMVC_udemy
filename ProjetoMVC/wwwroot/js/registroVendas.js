document.addEventListener('DOMContentLoaded', (event) => {
    const selectProduto = document.getElementById('itemProduto');
    const inputQuantidade = document.getElementById('itemQuantidade');

    if (selectProduto && inputQuantidade) {
        selectProduto.addEventListener('change', CalculoValor);
        inputQuantidade.addEventListener('input', CalculoValor);
    }


    function CalculoValor() {
        const produtoIdCalculo = document.getElementById('itemProduto').value;
        const quantCalculo = parseFloat(document.getElementById('itemQuantidade').value)

        if (!produtoIdCalculo || isNaN(quantCalculo) || quantCalculo <= 0) {
            document.getElementById('itemValor').innerText = 'R$0,00';
            return;
        }

        const produtoEncontrado = produtosDisponiveis.find(produto => produto.id === produtoIdCalculo);

        if (produtoEncontrado) {
            const total = produtoEncontrado.valor * quantCalculo;
            document.getElementById('itemValor').innerText = 'R$ ' + total.toFixed(2).replace('.', ',');
        }

    }

    const btnAdicionarItem = document.getElementById('btnAdicionarItem');
    btnAdicionarItem.addEventListener('click', function () {

        const selectProduto = document.getElementById('itemProduto');
        const produtoId = selectProduto.value;
        const produtoNome = selectProduto.options[selectProduto.selectedIndex].text;
        const quantidade = document.getElementById('itemQuantidade').value;
        const valor = document.getElementById('itemValor').innerText;

        if (!produtoId || !quantidade || !valor) {
            alert("Por favor, preencha todos os campos do item.");
            return;
        }

        const subtotal = quantidade * valor;

        const novaLinha = document.createElement('tr');
        novaLinha.innerHTML = `
            <td>${produtoNome}</td>
            <td>${quantidade}</td>
            <td>${valor}</td>
            <td>${subtotal.toFixed(2)}</td>
            <td><button type="button" class="btn btn-danger btn-sm">Remover</button></td>
        `;

        const tabelaItens = document.getElementById('tabelaItens');
        tabelaItens.appendChild(novaLinha);

        document.getElementById('itemProduto').value = '';
        document.getElementById('itemQuantidade').value = '';
        document.getElementById('itemValor').value = '';
    });

