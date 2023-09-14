# TaskManager

Bem-vindo à documentação da API ASP.NET do TaskManager. Esta API permite gerenciar tarefas em uma aplicação de lista de afazeres. Ela oferece operações para listar, criar, atualizar e excluir tarefas.


## Configuração

Para testar esse projeto precisa baixar ele na sua máquina e fazer algumas alterações.

Utilizei uma abordagem code first, ou seja, uma vez criado o modelo de dados e configurado o contextpo de dados, basta utilizar as migrações. Para isso o comando *update-database* no Package Manager Console do Visual Studio aplica essa migração, e consequentemente cria ou autualiza o banco.

Utilizei para o banco de dados o SqlServer, por isso a string de conexão deve ser modificada de acordo com as configurações do seu dispositivo. Para modificá-la basta ir em *appsettings.json*. E adequar o *DefaultConnection*.
```json
{
  
    "ConnectionStrings": {
      "DefaultConnection": "Data Source=ENIAC\\SQLEXPRESS;Initial Catalog=TaskManager;Integrated Security=True;TrustServerCertificate=True"
    },
    "Logging": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
      }
    },
    "AllowedHosts": "*"
  }
```

## Tecnologias Utilizadas

A seguir estão as principais tecnologias e ferramentas utilizadas neste projeto, juntamente com suas versões:

- **Plataforma**: .NET 7.0
- **ASP.NET Core 6**
- **Entity Framework Core 7**
- **SQL Server 16**


## Como Executar o Projeto

Para executar este projeto em sua máquina local, siga as etapas abaixo:

1. Clone o repositório:

```bash
git clone https://github.com/JoaoVitorAguiar/TaskManagerAsp.Net.git



## Modelos de Dados

### TarefaRegisterViewModel

Este modelo é usado para criar ou atualizar uma tarefa.

```json
{
    "Title": "string",
    "Description": "string",
    "CreatedDate": "datetime",
    "Status": int
}
```
* Title (obrigatório, string): O título da tarefa.
* Description (obrigatório, string): A descrição da tarefa.
* CreatedDate (obrigatório, datetime): A data de criação da tarefa.
* Status (obrigatório, int): O status da tarefa que é um enumerador, deve ser um dos seguintes valores: 0: "Pendente", 1: "Em Progresso" ou 2: "Concluída".

## Endpoints
### Listar Tarefas
URL: /v1/Tarefas

Método: GET

Descrição: Retorna uma lista de todas as tarefas disponíveis.

Exemplo de Solicitação:
```http
GET https://seu-domínio.com/v1/Tarefas
```
Resposta de Exemplo:
```json
[
    {
        "Id": 1,
        "Title": "Comprar leite",
        "Description": "Ir ao mercado e comprar leite.",
        "CreatedDate": "2023-09-11T10:00:00",
        "Status": 0
    },
    {
        "Id": 2,
        "Title": "Pagar contas",
        "Description": "Pagar todas as contas pendentes.",
        "CreatedDate": "2023-09-10T15:30:00",
        "Status": 2
    }
]
```


### Criar Tarefa
URL: /v1/Tarefas

Método: POST

Descrição: Cria uma nova tarefa.

Corpo da Solicitação:
```json
{
    "Title": "Ir à academia",
    "Description": "Fazer exercícios na academia.",
    "CreatedDate": "2023-09-12T08:00:00",
    "Status": 1
}

```
Exemplo de Solicitação:

```http
POST https://seu-domínio.com/v1/Tarefas
Content-Type: application/json

{
    "Title": "Ir à academia",
    "Description": "Fazer exercícios na academia.",
    "CreatedDate": "2023-09-12T08:00:00",
    "Status": 1
}

```

Resposta de Exemplo:
```json
{
    "Id": 3,
    "Title": "Ir à academia",
    "Description": "Fazer exercícios na academia.",
    "CreatedDate": "2023-09-12T08:00:00",
    "Status": 1
}


```
### Atualizar Tarefa
URL: /v1/Tarefas/{id:int}

Método: PUT

Descrição: Atualiza uma tarefa existente pelo seu ID.

Corpo da Solicitação:

```json
{
    "Title": "Ir à academia - Atualizado",
    "Description": "Fazer exercícios na academia - Atualizado",
    "CreatedDate": "2023-09-12T08:00:00",
    "Status": 2
}
```
Exemplo de Solicitação:

```http
PUT https://seu-domínio.com/v1/Tarefas/3
Content-Type: application/json

{
    "Title": "Ir à academia - Atualizado",
    "Description": "Fazer exercícios na academia - Atualizado",
    "CreatedDate": "2023-09-12T08:00:00",
    "Status": 2
}
```
Resposta de Exemplo:

```json
{
    "Id": 3,
    "Title": "Ir à academia - Atualizado",
    "Description": "Fazer exercícios na academia - Atualizado",
    "CreatedDate": "2023-09-12T08:00:00",
    "Status": 2
}
```

### Excluir Tarefa
URL: /v1/Tarefas/{id:int}

Método: DELETE

Descrição: Exclui uma tarefa pelo seu ID.

Exemplo de Solicitação:

```http
DELETE https://seu-domínio.com/v1/Tarefas/3
```
Resposta de Exemplo:

```json
{
    "mensagem": "Tarefa excluída com sucesso."
}
```

## Erros
A API pode retornar os seguintes códigos de erro:

* 400 Bad Request: Quando a solicitação está ausente de dados obrigatórios ou contém dados inválidos.
* 404 Not Found: Quando um recurso solicitado não existe.
* 500 Internal Server Error: Para erros inesperados no servidor.
