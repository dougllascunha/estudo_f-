namespace CatalogoProdutos.Models;

/// <summary>
/// Exercício 4 — resultado do parsing de uma linha de CSV via Span,
/// sem alocação de substrings intermediárias.
/// </summary>
public readonly record struct ProdutoLinha(int Id, string Nome, decimal Preco);
