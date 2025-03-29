

# RomanelDeveloperEvaluation - Cadastro de Clientes

CRUD Para cadastro de clientes, utilizando uma arquitetura baseada em **Domain-Driven Design (DDD)**, **CQRS** e **Event Sourcing**. A aplicação é construída com **C# .NET 8.0**, utiliza **SQL Server** e **Entity framework** .

## Estrutura do Projeto

Camadas baeadas no DDD:
```
Romanel.Evaluation/
├── Romanel.Evaluation.sln                    
├── Romanel.Evaluation.Domain/                
│   ├── Entities/                    
│   ├── Events/                      
│   ├── Interfaces/                  
│   └── Romanel.Evaluation.Domain.csproj
├── Romanel.Evaluation.Application/  
│   ├── Commands/                    
│   ├── Queries/                     
│   ├── Validators/                  
│   ├── Dtos/                        
│   ├── Interfaces/                  
│   └── Romanel.Evaluation.Application.csproj
├── Romanel.Evaluation.Infrastructure/ 
│   ├── Data/                        
│   ├── Repositories/                
│   ├── EventStore/                  
│   └── Romanel.Evaluation.Infrastructure.csproj
├── Romanel.Evaluation.API/          
│   ├── Controllers/                 
│   ├── Dockerfile                   
│   ├── Program.cs                   
│   ├── appsettings.json             
│   └── Romanel.Evaluation.API.csproj
├── Romanel.Evaluation.Tests/                 
│   └── Romanel.Evaluation.Tests.csproj
├── docker-compose.yml                
└── README.md                         
```

### Camadas
- **Domain**: Contém as entidades (`Cliente`, `Endereco`)
- **Application**: Orquestra comandos e consultas (CQRS), FluentValidation e DTOs
- **Infrastructure**: Implementa a conexao com o SQL Server
- **API**: Endpoints para criar e consultar clientes

---

## Componentes Utilizados

- **C# e .NET 8.0** 
- **Entity Framework Core**
- **MediatR**
- **FluentValidation**
- **SQL Server**
- **Docker e Docker Compose**
---


## Como executar o sistema


### 1. Subir os Containers da api e banco
Na raiz do projeto, onde está localizado o `docker-compose.yml`), rodar o comando no CMD:
```bash
docker-compose up --build
```
  - O container da API (`app`) na porta `57808`.


### 2. Subir o front-end
Na raiz do projeto Angular, rodar o comando no CMD:
```bash
npm install
```

```bash
ng serve
```

  - O front-end da aplicação ficará disponível na porta `4200`.