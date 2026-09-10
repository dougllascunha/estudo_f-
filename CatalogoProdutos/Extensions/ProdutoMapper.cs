using CatalogoProdutos.Models;
using CatalogoProdutos.Dtos;

namespace CatalogoProdutos.Extensions;

/// <summary>
/// Exercício 3 — mapeamento manual e explícito entre entidade e DTO.
/// Sem bibliotecas de mapeamento: dá para ver exatamente o que vai
/// (e o que NÃO vai) para fora da aplicação.
/// </summary>
public static class ProdutoMapper
{
    public static ProdutoDto ParaDto(this Produto p) => new(p.Id, p.Nome, p.Preco);
}
