# Associação Produto/Plano de Fabrico

## Análise 

- Produto
    - Id
    - InfoProduto
    - É mostrado apenas o nome do cliente selecionado.

- Foi criada uma nova classe, OrdemFabrico, usada para criar uma lista de operações necessárias para a criação de um produto

    - Id_operaçao

- PlanoFabrico
	- Id
	- Id_produto
	- OrdemFabrico [] operaçoes