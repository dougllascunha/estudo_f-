using System.Reflection;
using CatalogoProdutos.Attributes;

namespace CatalogoProdutos.Services;

/// <summary>
/// Exercício 2 — varredura de propriedades marcadas com [Sensivel] via
/// reflexão, com cache por tipo. Registrado como Singleton no Program.cs,
/// então o dicionário _cache vive durante toda a vida da aplicação —
/// é o equivalente, dentro do MVC, ao "static readonly" usado no
/// exercício original solto.
/// </summary>
public class AuditoriaService : IAuditoriaService
{
    private readonly Dictionary<Type, List<(string, int)>> _cache = new();

    public IReadOnlyList<(string Nome, int Nivel)> ListarCamposSensiveis<T>()
    {
        var tipo = typeof(T);

        if (_cache.TryGetValue(tipo, out var cacheado))
            return cacheado; // 2ª chamada em diante: zero reflexão nova

        var resultado = tipo.GetProperties()
            .Select(p => new { Prop = p, Attr = p.GetCustomAttribute<SensivelAttribute>() })
            .Where(x => x.Attr is not null)
            .Select(x => (x.Prop.Name, x.Attr!.Nivel))
            .ToList();

        _cache[tipo] = resultado;
        return resultado;
    }
}
