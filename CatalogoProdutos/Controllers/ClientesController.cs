using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Models;
using CatalogoProdutos.Services;

namespace CatalogoProdutos.Controllers;

public class ClientesController : Controller
{
    private readonly IAuditoriaService _auditoria;

    public ClientesController(IAuditoriaService auditoria)
    {
        _auditoria = auditoria;
    }

    public IActionResult Auditoria()
    {
        // 1ª chamada nesta aplicação: roda reflexão e preenche o cache.
        // Recarregue a página (F5): será a 2ª chamada, usando o cache —
        // o resultado visual é o mesmo, mas o custo de reflexão não se repete.
        var campos = _auditoria.ListarCamposSensiveis<Cliente>();
        return View(campos);
    }
}
