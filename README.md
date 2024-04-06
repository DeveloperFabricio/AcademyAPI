## AcademyAPI 🌐 

## ⚙️ Status: Completo e Funcionando.

#### Este projeto é uma API web que implementa um sistema de gerenciamento de uma Academia. 
#### A API permite que a Academia tenha controle total de: Instrutor, Alunos, Esportes e Pagamentos. 
#### A Academia: Cadastra Instrutor, ve se está disponivel na região e de acordo com a especialidade dele. 
#### O Instrutor: Monta o treino do Aluno, de acordo com a dificuldade e qual atividade escolhida pelo aluno. 
#### O Aluno: Recebe seus treinos e quando está perto de vencer ou já está vencida sua mensalidade, recebe um e-mail notificando do atraso. 
#### Pagamentos das mensalidades: Somente através do Cartão de Crédito. 

### Funcionalidades 🖥️  

- ☑ CRUD Instrutor 
- ☑ CRUD Alunos 
- ☑ CRUD Esportes 
- ☑ CRUD Pagamentos 
- ☑ Confirmação de atraso da mensalidade (E-mail). 
- ☑ Background Service rodando e notificando no dia anterior. 
- ☑ Autenticação e Autorização. 

### Tecnologias utilizadas 💡 

- ASP.NET Core 8: framework web para desenvolvimento de aplicações .NET 
- Entity Framework Core: persistência e consulta de dados. 
- SQL Server: banco de dados relacional. 
- RabbitMQ 

### Padrões, conceitos e arquitetura utilizada 📂 

- ☑ Fluent Validation 
- ☑ Padrão Repository 
- ☑ Middleware (Lidar com exceções) 
- ☑ InputModel, ViewModel 
- ☑ DTO’s 
- ☑ IEntityTipeConfiguration 
- ☑ Sql Server 
- ☑ Unit Of Work 
- ☑ HostedService 
- ☑ Domain Event 
- ☑ CQRS 
- ☑ Teste Unitários 
- ☑ Arquitetura Limpa 
- ☑ Microserviços 
- ☑ RabbitMQ 

## Instalação 

### Requisitos 

Antes de começar, verifique se você tem os seguintes requisitos instalados: 

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0): A versão do .NET Framework necessária para executar a API. 
- [SQL Server](https://www.microsoft.com/en-us/sql-server): O banco de dados utilizado para armazenar os dados. 

### Clone 

Clone o repositório do GitHub: 

```bash 
git clone https://github.com/[seu-usuário]/Academy.API.git 

 
