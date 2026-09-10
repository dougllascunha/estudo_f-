using CatalogoProdutos.Models;

namespace CatalogoProdutos.Services;

/// <summary>
/// Exercício 1 — switch expression com pelo menos 4 tipos de padrão:
/// type pattern, property pattern, relational pattern e list pattern,
/// além do tratamento explícito de null e do caso _ (exaustividade).
/// </summary>
public class ClassificadorPedidoService : IClassificadorPedidoService
{
    public string Classificar(object valor) => valor switch
    {
        // Trata o caso nulo explicitamente
        null => "Pedido nulo — não pode ser processado",

        // List pattern: valida quantidade mínima de itens
        Pedido { Itens.Length: 0 } => "Pedido inválido: nenhum item informado",

        // List pattern: valida quantidade máxima de itens
        Pedido { Itens.Length: > 10 } => "Pedido inválido: máximo de 10 itens excedido",

        // Property pattern + relational pattern combinados
        Pedido { Prioritario: true, Valor: > 1000 } =>
            "Atenção: pedido prioritário de alto risco financeiro",

        // Relational pattern isolado
        Pedido { Valor: > 1000 } =>
            "Alto risco financeiro — requer aprovação extra",

        // Property pattern simples
        Pedido { Prioritario: true } =>
            "Pedido prioritário dentro do padrão de valor",

        // List pattern capturando um único item
        Pedido { Itens: [var unicoItem] } =>
            $"Pedido simples com 1 item: {unicoItem}",

        // List pattern capturando primeiro e último elemento
        Pedido { Itens: [var primeiro, .., var ultimo] } p =>
            $"Pedido padrão com {p.Itens.Length} itens (de '{primeiro}' até '{ultimo}')",

        // Catch-all — garante exaustividade do switch
        _ => "Objeto não reconhecido como pedido"
    };
}
