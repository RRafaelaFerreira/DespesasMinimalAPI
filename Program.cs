using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
DespesasRepository.CriarBanco();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddDbContext<ApplicationDbContext>();

app.MapGet("/", () => "Hello World!");

//achando Despesa por data
/*   localhost/getDespesas/acharPorData?dtInicial=2025-06-01&dtFinal=2025-06-03   */
app.MapGet("/getDespesas/acharPorData", ([FromQuery]string dtInicial, [FromQuery] string dtFinal)=>
{
    if (!DateTime.TryParse(dtInicial, out var dataInicial) || !DateTime.TryParse(dtFinal, out var dataFinal))
    {
        return Results.BadRequest("Datas inválidas. Use o formato yyyy-mm-dd");
    }

    var despesasFiltradas = DespesasRepository.Despesa?
    .Where(d => d.Data.Date >= dataInicial.Date && d.Data.Date <= dataFinal.Date)
    .ToList();

    return Results.Ok(despesasFiltradas);
});


//acha despesa por ID
/*getDespesas/Id*/
app.MapGet("/getDespesas/{id}", ([FromRoute] int Id) =>
{
    var despesa = DespesasRepository.AcharPorId(Id);
    return despesa;
});

/* aparentemente está dando erro
//Achar despesa por valor
   /getDespesas/AcharPorValor?menorValor=10.00&maiorValor=200.00 */ 
app.MapGet("/getDespesas/AcharPorValor", ([FromQuery] double? menorValor, [FromQuery] double? maiorValor) =>
{
    if (menorValor is null || maiorValor is null)
        return Results.BadRequest("Parâmetros 'menorValor' e 'maiorValor' são obrigatórios.");

    var despesasFiltradas = DespesasRepository.Despesa?
        .Where(d => d.Valor >= menorValor && d.Valor <= maiorValor)
        .ToList();

    return despesasFiltradas is not null && despesasFiltradas.Any()
        ? Results.Ok(despesasFiltradas)
        : Results.NotFound("Nenhuma despesa encontrada no intervalo de valores especificado.");
});



//retorna todas as despesas
/*getDespesas*/
app.MapGet("/getDespesas", () =>
{
    var despesas = DespesasRepository.Despesa;
    return despesas is not null && despesas.Any() ? Results.Ok(despesas) : Results.NotFound("Nenhuma despesa encontrada");

});

app.Run();