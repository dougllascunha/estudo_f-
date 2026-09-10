namespace CatalogoProdutos.Attributes;

/// <summary>
/// Exercício 2 — atributo customizado que marca propriedades sensíveis
/// para fins de auditoria. Só guarda dado (o nível), não faz lógica.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class SensivelAttribute : Attribute
{
    public int Nivel { get; }

    public SensivelAttribute(int nivel) => Nivel = nivel;
}
