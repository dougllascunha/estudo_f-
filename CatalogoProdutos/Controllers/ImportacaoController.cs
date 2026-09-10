using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Services;

namespace CatalogoProdutos.Controllers;

public class ImportacaoController : Controller
{
    private readonly IParserCsvService _parser;

    public ImportacaoController(IParserCsvService parser)
    {
        _parser = parser;
    }

    public IActionResult Upload() => View();

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile arquivoCsv)
    {
        if (arquivoCsv is null || arquivoCsv.Length == 0)
        {
            ModelState.AddModelError("", "Nenhum arquivo enviado.");
            return View();
        }

        await using var stream = arquivoCsv.OpenReadStream();
        var produtos = await _parser.ProcessarArquivoAsync(stream);

        return View("Resultado", produtos);
    }
}
