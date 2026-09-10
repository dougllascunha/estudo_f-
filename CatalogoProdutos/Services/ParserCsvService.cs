using System.Buffers;
using System.Globalization;
using CatalogoProdutos.Models;

namespace CatalogoProdutos.Services;

/// <summary>
/// Exercício 4 — parsing de linha via ReadOnlySpan&lt;char&gt; (sem Split
/// e sem substrings intermediárias) + leitura de arquivo usando um
/// buffer alugado do ArrayPool&lt;byte&gt;, devolvido no finally.
/// </summary>
public class ParserCsvService : IParserCsvService
{
    public ProdutoLinha ParseLinha(ReadOnlySpan<char> linha)
    {
        // 1º fatiamento: encontra o primeiro ';' sem alocar nada
        int primeiroSeparador = linha.IndexOf(';');
        ReadOnlySpan<char> idSpan = linha[..primeiroSeparador];

        // 2º fatiamento: continua fatiando o restante, ainda sem alocar
        ReadOnlySpan<char> resto = linha[(primeiroSeparador + 1)..];
        int segundoSeparador = resto.IndexOf(';');
        ReadOnlySpan<char> nomeSpan = resto[..segundoSeparador];
        ReadOnlySpan<char> precoSpan = resto[(segundoSeparador + 1)..];

        // A conversão para os tipos finais só acontece aqui, no fim do parsing
        int id = int.Parse(idSpan);
        decimal preco = decimal.Parse(precoSpan, CultureInfo.InvariantCulture);

        // Única alocação necessária: o nome precisa existir como string
        // de verdade no objeto de retorno (record struct não guarda Span).
        string nome = nomeSpan.ToString();

        return new ProdutoLinha(id, nome, preco);
    }

    public async Task<List<ProdutoLinha>> ProcessarArquivoAsync(Stream arquivo)
    {
        var pool = ArrayPool<byte>.Shared;
        byte[] buffer = pool.Rent(1024); // aluga o buffer, não aloca do zero
        var resultado = new List<ProdutoLinha>();

        try
        {
            using var reader = new StreamReader(arquivo);
            string? linha;
            while ((linha = await reader.ReadLineAsync()) is not null)
            {
                if (string.IsNullOrWhiteSpace(linha)) continue;
                resultado.Add(ParseLinha(linha.AsSpan()));
            }
        }
        finally
        {
            pool.Return(buffer, clearArray: true); // devolve o buffer ao pool
        }

        return resultado;
    }
}
