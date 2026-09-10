using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Models;
using System.Diagnostics;

namespace CatalogoProdutos.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();

    public IActionResult Erro() =>
        View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
