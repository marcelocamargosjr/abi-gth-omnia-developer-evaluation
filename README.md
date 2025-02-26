# Manual de Uso da API de Vendas

## Tecnologias Utilizadas

### Backend
- **.NET 8.0**: Plataforma gratuita, multiplataforma e de código aberto para desenvolvimento de vários tipos de aplicações.  
  [GitHub](https://github.com/dotnet/core)
- **C#**: Linguagem de programação moderna e orientada a objetos desenvolvida pela Microsoft.  
  [GitHub](https://github.com/dotnet/csharplang)

### Testes
- **xUnit**: Ferramenta gratuita, de código aberto e voltada para testes unitários no .NET Framework.  
  [GitHub](https://github.com/xunit/xunit)

### Frontend
- **Angular**: Plataforma para construção de aplicações web móveis e desktop.  
  [GitHub](https://github.com/angular/angular)

### Bancos de Dados
- **PostgreSQL**: Sistema de banco de dados relacional de código aberto e altamente poderoso.  
  [GitHub](https://github.com/postgres/postgres)
- **MongoDB**: Banco de dados distribuído, baseado em documentos e de uso geral.  
  [GitHub](https://github.com/mongodb/mongo)

---

## Como Executar a Aplicação

### 1. Clonar o Repositório
```sh
git clone <URL_DO_REPOSITORIO>
cd <NOME_DO_REPOSITORIO>
```

### 2. Configurar e Executar via Docker
A aplicação pode ser executada utilizando **Docker** e **Docker Compose**, garantindo um ambiente de desenvolvimento padronizado.

#### 2.1 Iniciar os containers
```sh
docker-compose up -d
```

Isso criará e iniciará os seguintes serviços:
- **API:** `ambev_developer_evaluation_webapi` rodando nas portas `8080` (HTTP) e `8081` (HTTPS).
- **Banco de Dados PostgreSQL:** `ambev_developer_evaluation_database` rodando na porta `5432`.
- **MongoDB:** `ambev_developer_evaluation_nosql` rodando na porta `27017`.
- **Redis:** `ambev_developer_evaluation_cache` rodando na porta `6379`.

#### 2.2 Verificar os containers em execução
```sh
docker ps
```

#### 2.3 Parar os containers
```sh
docker-compose down
```

### 3. Executar Migrations do Banco de Dados
#### 3.1 Criar uma nova Migration
```sh
dotnet ef migrations add AddSalesAndSaleItemsTables --context DefaultContext --project ../Ambev.DeveloperEvaluation.ORM --startup-project ../Ambev.DeveloperEvaluation.WebApi --output-dir Migrations
```

#### 3.2 Aplicar Migrations ao Banco de Dados
```sh
dotnet ef database update --context DefaultContext --project ../Ambev.DeveloperEvaluation.ORM --startup-project ../Ambev.DeveloperEvaluation.WebApi
```

---

## APIs Disponíveis

### 1. Listar Vendas
**Método:** `GET`

**Descrição:** Obtém uma lista paginada de vendas, ordenada por `SaleNumber`.

**Exemplo de requisição:**
```sh
curl -X 'GET' \  
  'https://localhost:8080/api/Sales?Page=1&Size=10&Order=SaleNumber%20asc' \  
  -H 'accept: text/plain'
```

### 2. Criar uma Nova Venda
**Método:** `POST`

**Descrição:** Cria uma nova venda com os dados especificados.

**Exemplo de requisição:**
```sh
curl -X 'POST' \  
  'https://localhost:8080/api/Sales' \  
  -H 'accept: text/plain' \  
  -H 'Content-Type: application/json' \  
  -d '{
  "saleNumber": "001",
  "saleDate": "2025-02-26T04:15:44.657Z",
  "customerId": "CUST-001",
  "branch": "BR-001",
  "items": [
    {
      "productId": "PROD-001",
      "quantity": 4,
      "unitPrice": 50.00
    }
  ]
}'
```

### 3. Obter uma Venda Específica
**Método:** `GET`

**Descrição:** Obtém os detalhes de uma venda específica com base no `ID`.

**Exemplo de requisição:**
```sh
curl -X 'GET' \  
  'https://localhost:8080/api/Sales/75c861de-1e43-44e6-8709-380ed9b747cf' \  
  -H 'accept: text/plain'
```

### 4. Atualizar uma Venda
**Método:** `PUT`

**Descrição:** Atualiza os detalhes de uma venda existente.

**Exemplo de requisição:**
```sh
curl -X 'PUT' \  
  'https://localhost:8080/api/Sales/75c861de-1e43-44e6-8709-380ed9b747cf' \  
  -H 'accept: text/plain' \  
  -H 'Content-Type: application/json' \  
  -d '{
      "id": "75c861de-1e43-44e6-8709-380ed9b747cf",
      "saleNumber": "001",
      "saleDate": "2025-02-26T04:15:44.657Z",
      "customerId": "CUST-001",
      "totalAmount": 180,
      "branch": "BR-001",
      "items": [
        {
          "productId": "PROD-001",
          "quantity": 4,
          "unitPrice": 50,
          "discount": 0.1,
          "totalAmount": 200,
          "id": "ac7e806e-5757-4da8-bd09-861e1271a62e"
        }
      ],
      "isCancelled": false
    }'
```

### 5. Excluir uma Venda
**Método:** `DELETE`

**Descrição:** Remove uma venda específica com base no `ID`.

**Exemplo de requisição:**
```sh
curl -X 'DELETE' \  
  'https://localhost:8080/api/Sales/75c861de-1e43-44e6-8709-380ed9b747cf' \  
  -H 'accept: text/plain'
```

---

## Considerações Finais
- Certifique-se de que o servidor da API esteja em execução antes de realizar as requisições.
- Use ferramentas como `Postman` ou `Insomnia` para testar as requisições de forma mais intuitiva.
- Para produção, altere a URL base para um ambiente adequado.