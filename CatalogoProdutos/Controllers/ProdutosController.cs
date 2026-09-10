using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Models;
using CatalogoProdutos.Extensions;

namespace CatalogoProdutos.Controllers;

public class ProdutosController : Controller
{
    // Em um projeto real, isso viria de um repositório/banco de dados —
    // aqui está fixo só para reaproveitar o exemplo da aula.
    private static readonly List<Produto> _catalogo = new()
    {
        new Produto(1, "Mouse Gamer", 150.00m, 40),
        new Produto(2, "Teclado Mecânico", 320.00m, 15),
        new Produto(3, "Monitor 24\"", 890.00m, 8),
    };

    public IActionResult Catalogo()
    {
        // Regra de ouro do MVC: a View NUNCA recebe a entidade de domínio.
        // Ela recebe o DTO, mapeado explicitamente aqui no Controller.
        var dtos = _catalogo.Select(p => p.ParaDto()).ToList();
        return View(dtos);
    }

    [HttpPost]
    public IActionResult AplicarDesconto(int id, decimal percentual)
    {
        var produto = _catalogo.FirstOrDefault(p => p.Id == id);
        if (produto is null) return NotFound();

        // 'with' cria uma cópia com desconto — o objeto original na
        // lista _catalogo não é alterado por essa operação.
        var comDesconto = produto with { Preco = produto.Preco * (1 - percentual) };

        return Json(new
        {
            original = produto.ParaDto(),
            comDesconto = comDesconto.ParaDto()
        });
    }
}
