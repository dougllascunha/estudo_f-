using CatalogoProdutos.Services;

var builder = WebApplication.CreateBuilder(args);

// --- MVC ---
builder.Services.AddControllersWithViews();

// --- Injeção de dependência dos serviços criados nos exercícios ---

// Exercício 1: Pattern matching avançado
// Scoped = uma instância por requisição (não guarda estado entre chamadas).
builder.Services.AddScoped<IClassificadorPedidoService, ClassificadorPedidoService>();

// Exercício 2: Atributos + reflexão controlada
// Singleton = uma única instância para a aplicação inteira, o que faz o
// cache de reflexão (_cache) realmente valer a pena entre requisições.
builder.Services.AddSingleton<IAuditoriaService, AuditoriaService>();

// Exercício 4: Span/Memory + ArrayPool
builder.Services.AddScoped<IParserCsvService, ParserCsvService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Erro");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
