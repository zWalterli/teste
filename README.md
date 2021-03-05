# NovaWeb.API
Esta é uma API REST para consultar dados de um Contato com um ou vários telefones. 

Tabela de conteúdos
=================
<!--ts-->
   * [Features](#features)
   * [Tecnologias](#tecnologias)
   * [Instalação](#instalação)
   * [Como usar](#como-usar)
   * [Aplicação](#aplicação)
   * [Sobre](#autor)
<!--te-->

### Features

- [x] CRUD de Contatos
- [x] CRUD de Telefone
- [ ] Autenticação via JWT

### Tecnologias
As seguintes ferramentas foram usadas na construção do projeto:

- [ASP.NET Core](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-5.0)
- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/)
- [NuGet](https://www.nuget.org/)
- [GitHub Actions](https://www.docker.com/)
- [Azure](https://azure.microsoft.com/)
- [Docker](https://www.docker.com/)

### Instalação

## Clone esse repositório
    git clone https://github.com/zWalterli/NovaWeb.API.git
    
## Navegue para a pasta baixada
    cd NovaWeb.API/NovaWeb.API/
    
## Execute a API
    dotnet run -p "NovaWeb.API"

### Features
- [x] CRUD de Contatos
- [x] CRUD de Telefones
- [ ] Autenticação via JWT


### Como Usar
A seguir o exemplo de como utilizar esta API:

### URL para utilizar o Swagger

    http://localhost:5000/swagger/index.html

## Get lista de Contato

## Request
`GET /Contato/`
    
    curl -X GET "http://localhost:5000/api/v1/Contato" -H  "accept: text/plain"
    
### Response
    content-type: text/json; charset=utf-8 
    date: Fri05 Mar 2021 19:23:08 GMT 
    server: Kestrel 
    transfer-encoding: chunked 

    []

## Get Contato Específico

## Request
`GET /Contato/{id}`
    
    curl -X GET "http://localhost:5000/api/v1/Contato/{id}" -H  "accept: text/plain"
    
### Response
    content-type: application/json; charset=utf-8 
    date: Fri05 Mar 2021 19:33:26 GMT 
    server: Kestrel 
    transfer-encoding: chunked 

    {
      "contatoId": 1,
      "email": "teste@teste.com",
      "firstName": "Teste",
      "lastName": "de Teste",
      "telefones": [
        {
          "telefoneId": 1,
          "contatoId": 1,
          "numero": "32123456789"
        },
        {
          "telefoneId": 2,
          "contatoId": 1,
          "numero": "32987654321"
        }
      ]
    }

## Criar novo Contato

## Request
`POST /Contato/`

    curl -X POST "http://localhost:5000/api/v1/Contato" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"email\":\"teste@gmail.com\",\"firstName\":\"Teste\",\"lastName\":\"de Teste\",\"telefones\":[{\"numero\":\"32999999999\"}]}"

### Response
    access-control-allow-origin: * 
    content-type: application/json; charset=utf-8 
    date: Fri05 Mar 2021 19:29:25 GMT 
    server: Kestrel 
    transfer-encoding: chunked 


## Atualizar dados de um Contato

### Request

`PUT /Contato/`

    curl -X PUT "http://localhost:5000/api/v1/Contato" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"contatoId\":4,\"email\":\"teste@gmail.com\",\"firstName\":\"Teste\",\"lastName\":\"de Teste\",\"telefones\":[{\"telefoneId\":24,\"contatoId\":4,\"numero\":\"32888888888\"}]}"

### Response

    access-control-allow-origin: * 
    content-type: application/json; charset=utf-8 
    date: Fri05 Mar 2021 19:36:20 GMT 
    server: Kestrel 
    transfer-encoding: chunked 

    {
      "contatoId": 4,
      "email": "teste@gmail.com",
      "firstName": "Teste",
      "lastName": "de Teste",
      "telefones": [
        {
          "telefoneId": 24,
          "contatoId": 4,
          "numero": "32888888888"
        }
      ]
    }

## Deletar um Contato

### Request

`DELETE /Contato/{id}`

    curl -X DELETE "http://localhost:5000/api/v1/Contato/{id}" -H  "accept: */*"

### Response

    HTTP/1.1 204 No Content
    Date: Thu, 24 Feb 2011 12:36:32 GMT
    Status: 204 No Content
    Connection: close


### Aplicação

Para testar a aplicação <a href="https://zuuh-api-server.azurewebsites.net/swagger/index.html">click aqui.</a>

### Autor
---

<a href="https://www.linkedin.com/in/walterli-valadares-j%C3%BAnior-39807a165/">
 <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/u/46723190?s=460&u=9e52942eb8201675f594e1b24eae0afa22f1aef3&v=4" width="200px;" alt=""/>
 <br />
 <sub><b>Walterli Valadares Junior</b></sub></a> <a href="https://www.linkedin.com/in/walterli-valadares-j%C3%BAnior-39807a165/" title="Linkdlin">🚀</a>


Feito com ❤️ por Walterli Valadares
<br />👋🏽 Entre em contato!
