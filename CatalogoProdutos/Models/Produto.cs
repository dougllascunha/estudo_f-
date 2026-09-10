namespace CatalogoProdutos.Models;

/// <summary>
/// Exercício 3 — record de domínio imutável. Nunca é exposto diretamente
/// para as Views; sempre é mapeado para ProdutoDto antes disso.
/// </summary>
public record Produto(int Id, string Nome, decimal Preco, int Estoque);
