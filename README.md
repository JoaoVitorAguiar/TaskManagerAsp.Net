# TaskManager

Bem-vindo à documentação da API ASP.NET do TaskManager. Esta API permite gerenciar tarefas em uma aplicação de lista de afazeres. Ela oferece operações para listar, criar, atualizar e excluir tarefas.



## Modelos de Dados

### TarefaRegisterViewModel

Este modelo é usado para criar ou atualizar uma tarefa.

```json
{
    "Title": "string",
    "Description": "string",
    "CreatedDate": "datetime",
    "Status": "string"
}
```
* Title (obrigatório, string): O título da tarefa.
* Description (obrigatório, string): A descrição da tarefa.
* CreatedDate (obrigatório, datetime): A data de criação da tarefa.
* Status (obrigatório, string): O status da tarefa, deve ser um dos seguintes valores: "Pendente", "Em Progresso" ou "Concluída".

## Endpoints
### Listar Tarefas
URL: /v1/Tarefas

Método: GET

Descrição: Retorna uma lista de todas as tarefas disponíveis.

Exemplo de Solicitação:
```bash
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
        "Status": "Pendente"
    },
    {
        "Id": 2,
        "Title": "Pagar contas",
        "Description": "Pagar todas as contas pendentes.",
        "CreatedDate": "2023-09-10T15:30:00",
        "Status": "Concluída"
    }
]
```
