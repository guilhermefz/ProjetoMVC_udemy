document.addEventListener('DOMContentLoaded', () => {

    const selectProduto = document.getElementById('itemProduto');
    const inputQuantidade = document.getElementById('itemQuantidade');
    const btnAdicionarItem = document.getElementById('btnAdicionarItem');
    const successModal = document.getElementById('successModal');
    const modalMessageElement = document.getElementById('modalMessage');
    const modalButton = document.getElementById('modalButton')

    const showSuccessModal = (message) => {
        modalMessageElement.innerText = message; 
        successModal.style.display = 'flex';  
    };
    if (modalButton) {
        modalButton.addEventListener('click', () => {
            setTimeout(() => {
                window.location.href = '/RegistroVendas';
            }, 500);
        });
    }
    console.log("Elemento do parágrafo da mensagem:", modalMessage);
    

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

    if (btnAdicionarItem) {
        btnAdicionarItem.addEventListener('click', (event) => {
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
                novaLinha.dataset.produtoId = produtoEncontrado.id; 

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
            } else {
                alert("Produto não encontrado.");
            }
        });
    }
            if (tabelaItens) {
                tabelaItens.addEventListener('click', (event) => {
                    const elementoClicado = event.target;
                    if (elementoClicado.classList.contains('btn-danger')) {
                        const linhaParaRemover = elementoClicado.closest('tr');
                        if (linhaParaRemover) {
                            linhaParaRemover.remove();
                            console.log('removido!');
                        }
                    }
                });
            }
    if (form) {
        form.addEventListener('submit', (event) => {
            debugger;
            event.preventDefault();

            const linhasDaTabela = tabelaItens.querySelectorAll('tbody tr');
            const itensDaVenda = [];

            linhasDaTabela.forEach(linha => {
                const produtoId = linha.dataset.produtoId; 
                const nomeDoProduto = linha.cells[0].innerText;
                const quantidade = linha.cells[1].innerText;

                const item = {
                    produtoId: parseInt(produtoId, 10), 
                    quantidade: parseFloat(quantidade)  
                };
                itensDaVenda.push(item);
            });
            const vendedorId = document.getElementById('VendedorId').value;
            const dataOriginal = document.getElementById('Data').value;
            const partesDaData = dataOriginal.split('/'); 
            const dataFormatada = `${partesDaData[2]}-${partesDaData[1]}-${partesDaData[0]}`;

            const dadosDaVenda = {
                vendedorId: parseInt(vendedorId, 10),
                data: dataFormatada,
                itens: itensDaVenda
            };

            console.log("Pacote de dados completo:", dadosDaVenda);

            
            fetch('/RegistroVendas/SalvarVenda', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(dadosDaVenda)
            }).then(response => response.json())
                .then(data => {
                console.log("Objeto 'data' recebido do servidor:", data);
                    showSuccessModal(data.mensagem); 
            })

            if (itensDaVenda.length === 0) {
                alert("Por favor, adicione pelo menos um item à venda.");
                return;
            }
            
        });
    }


});