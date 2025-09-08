document.addEventListener('DOMContentLoaded', () => {

    const selectProduto = document.getElementById('itemProduto');
    const inputQuantidade = document.getElementById('itemQuantidade');
    const labelValor = document.getElementById('itemValor');
    const btnAdicionarItem = document.getElementById('btnAdicionarItem');
    console.log("Elemento do botão:", btnAdicionarItem);

    const tabelaItens = document.getElementById('tabelaItens');
    const form = document.querySelector('form');

    const getDadosDoItem = () => {
        const produtoId = selectProduto.value;
        const quantidade = parseFloat(inputQuantidade.value);

        if (!produtoId || isNaN(quantidade) || quantidade <= 0) {
            return null; 
        }

        return {
            produtoId,
            quantidade
        };
    };

    const calcularTotal = () => {
        const dadosDoItem = getDadosDoItem();

        if (!dadosDoItem) {
            labelValor.innerText = 'R$ 0,00';
            return;
        }

        const produtoEncontrado = produtosDisponiveis.find(p => p.id === dadosDoItem.produtoId);

        if (produtoEncontrado) {
            const total = produtoEncontrado.preco * dadosDoItem.quantidade;
            labelValor.innerText = 'R$ ' + total.toFixed(2).replace('.', ',');
        } else {
            labelValor.innerText = 'R$ 0,00';
        }
    };

    if (selectProduto && inputQuantidade) {
        selectProduto.addEventListener('change', calcularTotal);
        inputQuantidade.addEventListener('input', calcularTotal);
    }

    if (btnAdicionarItem) {
        btnAdicionarItem.addEventListener('click', (event) => {
            console.log("O botão foi clicado!");
            const dadosDoItem = getDadosDoItem();

            if (!dadosDoItem) {
                alert("Por favor, selecione um produto e insira uma quantidade válida.");
                return;
            }

            const produtoEncontrado = produtosDisponiveis.find(p => p.id === parseInt(dadosDoItem.produtoId, 10));

            if (produtoEncontrado) {
                const produtoNome = produtoEncontrado.nome;
                const valorUnitario = produtoEncontrado.preco;
                const subtotal = valorUnitario * dadosDoItem.quantidade;
                const novaLinha = document.createElement('tr');
                novaLinha.innerHTML = `
                    <td>${produtoNome}</td>
                    <td>${dadosDoItem.quantidade}</td>
                    <td>R$ ${valorUnitario.toFixed(2).replace('.', ',')}</td>
                    <td>R$ ${subtotal.toFixed(2).replace('.', ',')}</td>
                    <td><button type="button" class="btn btn-danger btn-sm">Remover</button></td>
                `;

                tabelaItens.appendChild(novaLinha);

                selectProduto.value = '';
                inputQuantidade.value = '';
                labelValor.innerText = 'R$ 0,00';
            } else
                alert("Produto não encontrado.");

            if (tabelaItens) {
                tabelaItens.addEventListener('click', (event) => {
                    console.log("Algo foi clicado na tabela!");
                });
            }


        });
    }
});