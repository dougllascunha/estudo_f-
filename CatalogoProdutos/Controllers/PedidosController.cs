using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Models;
using CatalogoProdutos.Services;

namespace CatalogoProdutos.Controllers;

public class PedidosController : Controller
{
    private readonly IClassificadorPedidoService _classificador;

    // O Controller recebe o serviço pronto via injeção de dependência —
    // ele não sabe (nem precisa saber) COMO a classificação é feita.
    public PedidosController(IClassificadorPedidoService classificador)
    {
        _classificador = classificador;
    }

    [HttpGet]
    public IActionResult Classificar()
    {
        var exemplo = new Pedido(2500m, true, new[] { "Notebook", "Mouse" });
        ViewBag.Resultado = _classificador.Classificar(exemplo);
        return View(exemplo);
    }

    [HttpPost]
    public IActionResult ClassificarAjax(decimal valor, bool prioritario, string itens)
    {
        var arrayItens = (itens ?? "")
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var pedido = new Pedido(valor, prioritario, arrayItens);
        var resultado = _classificador.Classificar(pedido);

        return Json(new { resultado });
    }
}
