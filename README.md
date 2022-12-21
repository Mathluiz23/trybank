# Boas-vindas ao repositório TryBank

# Orientações

<details>
  <summary><strong>‼️ Para executar o projeto </strong></summary><br />

1. Clone o repositório

- Use o comando: `git clone git@github.com:Mathluiz23/trybank.git`.git`.
- Entre na pasta do repositório que você acabou de clonar:
  - `cd trybank`

2. Instale as dependências

- `dotnet restore`.

</details>

<details>
  <summary><strong>🛠 Testes</strong></summary><br />

### Executando todos os testes

Para executar os testes com o .NET, execute o comando dentro do diretório src.
```
dotnet test
```
</details>


# Projeto Trybank

Este projeto consite na implementação de um serviço de banco financeiro. Onde o objetivo é construir um banco que contenha contas de usuários. 
Sendo possível criar e validar os processos de cadastro, login, saque, depósito e transferência do saldo dessas contas.

## O Projeto foi estruturado da seguinte forma:

### Cadastrando novas contas

<details>
  <summary>O programa permite o cadastro de novas contas</summary><br />

Lógica implementada na função `RegisterAccount()`

Se essa combinação de **número e agência** já existir, é lançada uma exceção do tipo `ArgumentException` com a mensagem `A conta já está sendo usada!`.

Caso contrário, a função armazena os dados no array `Bank` na próxima posição disponível marcada por `registeredAccounts`

</details>

<details>
  <summary>Testes</summary><br />

Teste implementando para verificar se a função `RegisterAccount` cadastra os dados passados por parâmetro e se retorna uma exceção quando é passada uma conta que já existe.

</details>

### Login e Logout

Crie a lógica do seu requisito no arquivo src/trybank/Trybank.cs.

<details>
  <summary>O programa permite o Login da pessoa usuária</summary><br />

O estado de pessoa usuária logada é controlado pela variável `Logged`

- **Se já houver uma pessoa usuária logada**, irá lançar uma exceção do tipo `AccessViolationException` com a mensagem `Usuário já está logado`

  **Caso contrário**, a função irá procurar por essa combinação de número e agência.

- **Se encontrado e a senha for correta**, a função altera o estado da variável `Logged` e armazena a posição da pessoa usuária logada na variável `loggedUser`.

- **Se encontrado e a senha for incorreta**, irá lançar uma exceção do tipo `ArgumentException` com a mensagem `Senha incorreta`

- Se não for encontrada a combinação de `número e agência`, será lançada uma exceção do tipo `ArgumentException`com a mensagem `Agência + Conta não encontrada`

</details>

<details>
  <summary>O programa deve permitir o Logout do usário</summary><br />

O estado de pessoa usuária logada é controlado pela variável `Logged`

**Se não houver uma pessoa usuária logada**, você deverá lançar uma exceção do tipo `AccessViolationException` com a mensagem `Usuário não está logado`

**Caso contrário**, a função deve alterar o estado da variável `Logged` e o índice de pessoa usuária `loggedUser` de volta para `-99`

</details>

<details>
  <summary>Teste Login</summary><br />

Teste implementado para verificar se a função `Login` consegue alterar o estado da variável Logged. 
Se retorna uma exceção quando é executada com uma conta já logada, quando uma senha incorreta é informada ou quando uma combinação de número e agência não existe no array Bank.

</details>

<details>
  <summary>Testes Logout</summary><br />

Teste implementado para verificar se a função`Logout` consegue alterar o estado da variável Logged e se retorna uma exceção quando é executada sem uma conta já logada.

</details>

### Checar o saldo, depositar e sacar dinheiro

<details>
  <summary>O programa permite verificar o saldo na conta da pessoa usária logada</summary><br />

Lógica implementada na função `CheckBalance()`

**Se não houver uma pessoa usuária logada**, irá lançar uma exceção do tipo `AccessViolationException` com a mensagem `Usuário já está logado`

**Caso contrário**, a função irá retornar o saldo na conta da pessoa usuária logada.

</details>

<details>
  <summary>O programa deve permite o depósito de um valor na conta da pessoa usária logada</summary><br />

Lógica implementada na função `Deposit()`

**Se não houver uma pessoa usuária logada**, irá lançar uma exceção do tipo `AccessViolationException` com a mensagem `Usuário já está logado`

**Caso contrário**, a função irá adicionar o valor passado por parâmetro para o saldo da pessoa usuária logada.

</details>

<details>
  <summary>O programa também permite o saque de um valor na conta da pessoa usuária logada</summary><br />

Lógica implementada na função `Withdraw()`

**Se não houver uma pessoa usuária logada**, irá lançar uma exceção do tipo `AccessViolationException`, com a mensagem `Usuário já está logado`

**Caso contrário**, a função irá retirar o valor passado por parâmetro para o saldo da pessoa usuária logada.
Se o saldo da conta da pessoa usuária logada for insuficiente para fazer o saque, será lançada uma exceção do tipo `InvalidOperationException` com a mensagem `Saldo insuficiente`

</details>

<details>
  <summary>Testes para Checar o Saldo</summary><br />

Teste implementado para verificar se a função `CheckBalance` retorna corretamente o saldo de uma conta já logada e se retorna uma exceção quando é executada sem uma conta logada.

</details>

<details>
  <summary>Testes para o Deposito</summary><br />

Teste implementado para verificar se a função `Deposit`  altera o saldo de uma conta já logada e se retorna uma exceção quando é executada sem uma conta logada.

</details>

<details>
  <summary>Testes para o Saque</summary><br />

Teste implementado para verificar se a função `Withdraw` altera o saldo de uma conta já logada, se retorna uma exceção quando é executada sem uma conta logada ou quando o saldo da conta não é suficiente.

</details>

### Transferência entre contas

<details>
  <summary>O programa também permite a transferência de saldo entre uma pessoa usuária logada e uma conta existente</summary><br />

**Se não houver uma pessoa usuária logada**, será lançada uma exceção do tipo `AccessViolationException`, com a mensagem `Usuário já está logado`

Se o saldo da conta da pessoa usuária logada for insuficiente para fazer a transferência, será lançada uma exceção do tipo `InvalidOperationException` com a mensagem `Saldo insuficiente`

**Caso contrário**, a função irá transferir o valor passado por parâmetro do saldo da pessoa usuária logada para o saldo da conta passada por parâmetro.

</details>

<details>
  <summary>Testes de Transferência</summary><br />

Implementado teste para verificar se a função `Transfer` altera o saldo de uma conta já logada e move o valor para a conta passada por parâmetro, se retorna uma exceção quando é executada sem uma conta logada ou quando o saldo da conta logada não é suficiente.

</details>
