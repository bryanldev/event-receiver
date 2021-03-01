# EventReceiver

## 🚀 Introdução
> API para processar o recebimento de eventos de sensores espalhados pelo Brasil.

## 🔧 Tecnologias Utilizadas
 - .NET5
 - EntityFramework Core (Code First)
 - Flunt Validation
 - Swagger
 - Injeção de Dependência (nativa)
 - NUnit
 - Moq
 - AutoMapper
 - SQLite.


## Getting Started
Este projeto foi construído em cima do servidor web Kestrel. Para que o projeto rode em sua máquina, execute os seguintes comandos em seu terminal:


**1. Clone este repositório**

```
$ git clone https://gitlab.com/bryanlds/event-receiver.git

$ cd event-receiver/src/Server
```

**2. Para baixar os pacotes adicionais necessários:**
```shell
dotnet restore
```
**3. Para rodar a aplicação:**
```shell
dotnet run --project API
```

A porta padrão selecionada é a 5001 ou 5000 (ex.: https://localhost:5001/)

Caso use uma IDE como o Visual Studio, simplesmente abra a solução EventReceiver.sln e rode a aplicação.

## Documentação
A aplicação fornece suporte ao Swagger, que é aberto no início da aplicação. Nele é possível ter uma descrição sobre os endpoints fornecidos pela solução, a saber:

**Retorna todos os eventos.**
```
/api/event/all
```
Exemplo de resposta:
```json
    {
    "timestamp": "1539112021301",
    "tag": "brasil.nordeste.sensor02 >",
    "valor" : "665487",
    "status": "Processed"
    }
```

**Salva um novo evento.**
```
/api/event/save
```
Exemplo de requisição:
```json
    {
    "timestamp": "1539112021301",
    "tag": "brasil.sul.sensor01 >",
    "valor" : "k84a471"
    }
```

**Retorna todos os eventos por região.**
```
/api/event/region/{region}
```
Exemplo de resposta:
```json
    {
        "country": "brasil",
        "region": "sul",
        "total" : "7"
    }
```

**Retorna todos os eventos por nome do sensor.**
```
/api/event/sensor/{region}
```
Exemplo de resposta:
```json
    {
        "country": "brasil",
        "region": "sul",
        "sensorName": "sensor01",
        "total": 5
    },
    {
        "country": "brasil",
        "region": "sul",
        "sensorName": "sensor02",
        "total": 2
    }
```
## Pendências

  - [ ] Front-end
  - [x] Back-end
  - [ ] Docker
