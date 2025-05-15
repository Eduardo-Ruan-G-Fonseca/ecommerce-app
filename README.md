# 🛒 EcommerceApp

Sistema de e-commerce real baseado em microserviços com ASP.NET Core 8 e React, seguindo boas práticas de escalabilidade, segurança e arquitetura moderna.

---

## 🔧 Tecnologias e Padrões Utilizados

- ASP.NET Core 8
- React (em breve)
- Clean Architecture (API, Application, Domain, Infrastructure)
- CQRS com MediatR
- Autenticação com ASP.NET Identity + JWT
- Swagger com autenticação Bearer
- MySQL + EF Core + Migrations
- RabbitMQ (em breve)
- Docker Compose (em breve)

---

## 🧱 Estrutura atual de microserviços

<pre> ### 🧱 Estrutura atual de microserviços ``` ├── Services/ │ ├── Catalog/ │ │ ├── Ecommerce.Catalog.API │ │ ├── Ecommerce.Catalog.Application │ │ ├── Ecommerce.Catalog.Domain │ │ └── Ecommerce.Catalog.Infrastructure │ ├── Customers/ │ │ ├── Ecommerce.Customers.API │ │ ├── Ecommerce.Customers.Application │ │ ├── Ecommerce.Customers.Domain │ │ └── Ecommerce.Customers.Infrastructure │ ├── Identity/ │ │ └── Ecommerce.Identity.API │ ├── Cart/ │ │ ├── Ecommerce.Cart.API │ │ ├── Ecommerce.Cart.Application │ │ ├── Ecommerce.Cart.Domain │ │ └── Ecommerce.Cart.Infrastructure ├── BuildingBlocks/ │ ├── Ecommerce.Auth │ └── (outros em breve) ``` </pre>

---

## ✅ Funcionalidades implementadas até agora

### 🔐 Autenticação (Identity)
- Registro e login de usuários
- Geração e validação de JWT
- Configuração centralizada em `Ecommerce.Auth`

### 👤 Clientes (Customers)
- CRUD completo de dados pessoais do usuário autenticado
- Endpoints protegidos via token
- Repositório com EF Core
- CQRS + MediatR

### 📦 Catálogo de Produtos (Catalog)
- CRUD de categorias e produtos
- Relacionamento entre entidades
- Proteção de endpoints com JWT
- Repositórios implementados

### 🛒 Carrinho (Cart)
- Entidades `Carrinho` e `ItemCarrinho`
- Adicionar, remover item, apagar e consultar carrinho
- Total do carrinho calculado
- CRUD completo via CQRS
- JWT + Swagger configurado

---

## 🛠️ Como rodar o projeto

# Clonar o repositório
git clone https://github.com/seu-usuario/EcommerceApp.git

# Abrir a solution no Visual Studio 2022

# Configurar o appsettings.json com a sua connection string MySQL

# Aplicar migrations (exemplo Cart)
dotnet ef database update --project src/Services/Cart/Ecommerce.Cart.Infrastructure --startup-project src/Services/Cart/Ecommerce.Cart.API

# Executar a aplicação
dotnet run --project src/Services/Cart/Ecommerce.Cart.API

📌 Próximas etapas
 Microserviço de Pedidos (Orders)

 Publicação de eventos entre serviços com RabbitMQ

 API Gateway com YARP

 Integração com front-end React

 Docker Compose para orquestração

📁 License
MIT © Ruan — 2024
