<h1 align="center">
    <br>Microservice - Maestro Pedidos<br/> 
</h1>

## Descrição
Microserviço responsável por receber as solitições de pedidos enviados pelo BFF, processar o pedido e enviar as
mensagens relacioadas ao pedido para os serviços de Pagamento e Backoffice.

## Tech Stack

- **Languages**
  - C#, SQL
- **Frameworks**
  - EntityFramework Code-First and Migrations
  - NET Core 8.x
  - Testcontainers, XUnit, FluentAssertions, NSubstitute
- **Message Broker**
  - RabbitMQ
- **Observability**
  - Jaeger Dashboard
- **Architecture**
  - Clean source code
  - Domain Driven Design + Vertical Slice Architecture
  - Dependency injection

## Application

- **Host**: http://localhost:5000
- **Swagger API**: http://localhost:5000/swagger/index.html

## Usage

1. Clone the repo
2. Execute ```docker compose -f docker-compose.yaml```
3. Use Application.