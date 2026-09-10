namespace CatalogoProdutos.Services;

public interface IAuditoriaService
{
    IReadOnlyList<(string Nome, int Nivel)> ListarCamposSensiveis<T>();
}
