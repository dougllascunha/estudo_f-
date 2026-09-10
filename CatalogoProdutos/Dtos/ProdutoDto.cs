namespace CatalogoProdutos.Dtos;

/// <summary>
/// Exercício 3 — contrato exposto para fora da aplicação (Views/API).
/// Repare que não existe o campo Estoque aqui — ele é um detalhe interno
/// do domínio que a camada de apresentação não precisa (nem deve) conhecer.
/// </summary>
public record ProdutoDto(int Id, string Nome, decimal Preco);
