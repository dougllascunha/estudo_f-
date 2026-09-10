using CatalogoProdutos.Models;

namespace CatalogoProdutos.Services;

public interface IParserCsvService
{
    ProdutoLinha ParseLinha(ReadOnlySpan<char> linha);
    Task<List<ProdutoLinha>> ProcessarArquivoAsync(Stream arquivo);
}
