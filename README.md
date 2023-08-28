# Projeto de apresentação CRUD de Produtos em .Net 6

Mini Projeto de apresentação - CRUD de Produtos em .Net 6

**Configurações:**

- Foi utilizado o swagger para documentação adicionando descrições em cada endpoint
- Foi feito uma configuração na classe program para mostrar os enums como strings no swagger para melhor visualização

**Padrões Utilizados:**

- CQRS
- DDD
- Mediator Pattern
- Repository Pattern

**Banco de Dados:**

- Foi criado uma instância do SQLServer no Docker (via Docker-Compose)
- Entity Framework Code First
- Foi criado uma Migration (SeedProdutos) para popular a base de dados com 5 produtos
- Foi feita a configuração na Classe Program para rodar as Migrations pendentes ao iniciar a aplicação

**Testes:**
- Foram feito testes de unitade e integração utilizando a biblioteca do XUnit e FluentAssertions
- Foi utilizado o modelo Triple A

**Observações:**

- Commands : Foi utilizado a biblioteca FluentValidation para as regras/validações das propriedades
- Update: Foi optado por permitir apenas a atualização da quantidade em estoque e o valor do produto, feitos em endpoints distintos
