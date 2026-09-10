namespace CatalogoProdutos.Models;

/// <summary>
/// Exercício 1 — record de domínio usado no classificador de pedidos
/// com pattern matching avançado.
/// </summary>
public record Pedido(decimal Valor, bool Prioritario, string[] Itens);
