# Projeto de Ganho de Capital
Este projeto consiste em um programa de linha de comando (CLI) que calcula o imposto a ser pago sobre lucros ou prejuízos de operações no mercado financeiro de ações.

## Funcionalidades
- O programa recebe listas de operações do mercado financeiro de ações em formato JSON.
- Cada operação contém os campos: operation, unit-cost, e quantity.
- O programa calcula o imposto a ser pago sobre as operações de venda com base nas regras do Ganho de Capital.
- O imposto é de 20% sobre o lucro obtido na operação de venda.
- O programa calcula o preço médio ponderado das ações compradas e deduz prejuízos dos lucros futuros.
- Não há imposto a ser pago se o valor total da operação for menor ou igual a R$ 20000,00.

## Estrutura do Projeto
- **TaxCalculator**: Classe responsável por calcular o imposto a ser pago.
- **TaxCalculatorService**: Classe que gerencia o cálculo do imposto e a média ponderada das ações.
- **OperationEntity**: Classe que representa uma operação no mercado financeiro.
- **TaxOutputEntity**: Classe que representa a saída do imposto pago em uma operação.
- **Program**: Classe principal que lida com a entrada e saída do programa.

## Como Executar
1. Clone o repositório.
2. Compile o código.
3. Execute o programa e insira as operações do mercado financeiro de ações em formato JSON.
4. O programa calculará o imposto a ser pago e exibirá a saída.

## Exemplos de Uso
- **Caso #1**
  - **Entrada**:\
    `[{"operation":"buy", "unit-cost":10.00, "quantity": 100}, {"operation":"sell", "unit-cost":15.00, "quantity": 50}, {"operation":"sell", "unit-cost":15.00, "quantity": 50}]`
  - **Saída**:\
    `[{"tax": 0.00},{"tax": 0.00},{"tax": 0.00}]`
- **Caso #2**
  - **Entrada**:\
    `[{"operation":"buy", "unit-cost":10.00, "quantity": 10000}, {"operation":"sell", "unit-cost":20.00, "quantity": 5000}, {"operation":"sell", "unit-cost":5.00, "quantity": 5000}]`
  - **Saída**:\
    `[{"tax": 0.00},{"tax": 10000.00},{"tax": 0.00}]`

## Oportunidades de melhoria
- Melhoria no tratamento de erros, como tratamento para dados inconsistentes e formato inválido de dados de entrada.
- Leitura de arquivo em formato json como uma opção de entrada para o Sistema.

## Considerações Finais
Este projeto foi desenvolvido para calcular o imposto a ser pago sobre operações no mercado financeiro de ações, seguindo as regras do Ganho de Capital. Ele oferece uma solução simples para lidar com as transações financeiras e o cálculo de impostos.
