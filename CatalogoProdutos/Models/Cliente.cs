using CatalogoProdutos.Attributes;

namespace CatalogoProdutos.Models;

/// <summary>
/// Exercício 2 — classe de domínio com propriedades marcadas via
/// atributo customizado [Sensivel], lidas depois por reflexão controlada.
/// </summary>
public class Cliente
{
    public string Nome { get; set; } = "";

    [Sensivel(3)]
    public string CPF { get; set; } = "";

    [Sensivel(2)]
    public string Email { get; set; } = "";

    public string Cidade { get; set; } = "";
}
