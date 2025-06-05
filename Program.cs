using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//acha Despesa por data
app.MapGet("/getDespesas", ([FromQuery]string dtInicial, [FromQuery] string dtFinal)=>
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
app.MapGet("/getDespesas/{id}", ([FromRoute] int Id) =>
{
    var despesa = DespesasRepository.AcharPorId(Id);
    return despesa;
});

//retorna todas as despesas
app.MapGet("getDespesas", () =>
{
    var despesas = DespesasRepository.Despesa;
    return despesas is not null && despesas.Any() ? Results.Ok(despesas) : Results.NotFound("Nenhuma despesa encontrada");

});


DespesasRepository.CriarBanco();
app.Run();
