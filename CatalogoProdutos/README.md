# Projeto Aula — C# Avançado & .NET (ASP.NET Core MVC)
### ADS — UNIP | Professor: Fabricio Freire

Projeto MVC completo e executável com os 4 exercícios da aula já organizados
na estrutura de pastas discutida em sala (`Models`, `Dtos`, `Attributes`,
`Extensions`, `Services`, `Controllers`, `Views`).

## Como rodar

Pré-requisito: **.NET 8 SDK** instalado.

```bash
cd CatalogoProdutos
dotnet restore
dotnet run
```

O terminal vai mostrar a URL local (algo como `http://localhost:5xxx`).
Abra no navegador — a página inicial tem links para as 4 demonstrações.

## Onde está cada exercício

| Exercício | Rota | Arquivos principais |
|---|---|---|
| 1 — Pattern Matching | `/Pedidos/Classificar` | `Models/Pedido.cs`, `Services/ClassificadorPedidoService.cs`, `Controllers/PedidosController.cs` |
| 2 — Atributos & Reflexão | `/Clientes/Auditoria` | `Attributes/SensivelAttribute.cs`, `Models/Cliente.cs`, `Services/AuditoriaService.cs`, `Controllers/ClientesController.cs` |
| 3 — Records & DTOs | `/Produtos/Catalogo` | `Models/Produto.cs`, `Dtos/ProdutoDto.cs`, `Extensions/ProdutoMapper.cs`, `Controllers/ProdutosController.cs` |
| 4 — Span & ArrayPool | `/Importacao/Upload` | `Models/ProdutoLinha.cs`, `Services/ParserCsvService.cs`, `Controllers/ImportacaoController.cs` |

Use o arquivo `produtos-exemplo.csv`, incluso na raiz do projeto, para testar
o Exercício 4 (upload de CSV).

## Injeção de dependência (Program.cs)

```csharp
builder.Services.AddScoped<IClassificadorPedidoService, ClassificadorPedidoService>();
builder.Services.AddSingleton<IAuditoriaService, AuditoriaService>(); // cache vive na app inteira
builder.Services.AddScoped<IParserCsvService, ParserCsvService>();
```

O `AuditoriaService` é o único registrado como `Singleton` — é o que faz o
cache de reflexão (visto no Exercício 2) realmente persistir entre requisições,
igual ao `static readonly` do exercício original, só que gerenciado pelo
container de DI do ASP.NET Core.

## Se você já tinha um projeto criado antes

Este pacote usa o namespace `CatalogoProdutos` (igual a um projeto criado com
`dotnet new mvc -n CatalogoProdutos`). Se for **substituir** um projeto que
você já tinha:

1. Apague as pastas `bin/` e `obj/` do projeto antigo antes de rodar de novo
   — o compilador da Razor mantém cache e pode acusar erro em tipos que já
   nem existem mais.
2. Se for mesclar (copiar arquivo por arquivo) em vez de substituir tudo,
   garanta que **todo** arquivo `.cs` deste pacote (`Models`, `Dtos`,
   `Attributes`, `Extensions`, `Services`) foi copiado — e não só as `Views`.
   Um erro de "tipo não encontrado" numa View quase sempre significa que o
   `.cs` correspondente não chegou a ser copiado, ou que o namespace dele
   ficou diferente do que está em `Views/_ViewImports.cshtml`.
3. O `Views/Shared/Error.cshtml` e `Models/ErrorViewModel.cs` inclusos aqui
   são a versão padrão gerada pelo `dotnet new mvc` — se o seu projeto já
   tinha essa dupla de arquivos, pode manter a sua versão sem problema.

