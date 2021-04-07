# EventReceiver

## 🚀 Introdução
> API para processar o recebimento de eventos de sensores espalhados pelo Brasil.

## Problema

Imagine que você ficou responsável por construir um sistema que seja capaz de receber milhares de eventos por segundo de sensores espalhados pelo Brasil, nas regiões norte, nordeste, sudeste e sul. Seu cliente também deseja que na solução ele possa visualizar esses eventos de forma clara.

Um evento é defino por um JSON com o seguinte formato:

```json
{
   "timestamp": <Unix Timestamp ex: 1539112021301>,
   "tag": "<string separada por '.' ex: brasil.sudeste.sensor01 >",
   "valor" : "<string>"
}
```

Descrição:
 * O campo timestamp é quando o evento ocorreu em UNIX Timestamp.
 * Tag é o identificador do evento, sendo composto de pais.região.nome_sensor.
 * Valor é o dado coletado de um determinado sensor (podendo ser numérico ou string).

## Requisitos

* Sua solução deverá ser capaz de armazenar os eventos recebidos.

* Cada sensor envia um evento a cada segundo independente se seu valor foi alterado, então um sensor pode enviar um evento com o mesmo valor do segundo anterior.

* Cada evento poderá ter o estado processado ou erro, caso o campo valor chegue vazio, o status do evento será erro caso contrário processado.

* Para seu cliente, é muito importante que ele saiba o número de eventos que aconteceram por região e por sensor. Como no exemplo abaixo:
    * Região sudeste e sul ambas com dois sensores (sensor01 e sensor02):
        * brasil.sudeste - 1000
        * brasil.sudeste.sensor01 - 700
        * brasil.sudeste.sensor02 - 300
        * brasil.sul - 1500
        * brasil.sul.sensor01 - 1250
        * brasil.sul.sensor02 - 250


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
