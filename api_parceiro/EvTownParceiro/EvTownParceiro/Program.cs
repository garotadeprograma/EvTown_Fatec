using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer("server=localhost;database=EvTown;trusted_connection=true;Encrypt=False"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Produtos", (DataContext context) =>
{
    var produtos = context.Produto.ToList();
    return produtos;
});

app.MapPost("/Produtos", ([FromBody]Produto produto, DataContext context) =>
{
    context.Produto.Add(produto);
    context.SaveChanges();
    var produtos = context.Produto.ToList();
    return produtos;
});

app.MapGet("/Estoque", (DataContext context) =>
{
    return context.Estoque.ToList();
});

app.MapPost("/Estoque", (Estoque estoque, DataContext context) => 
{
    context.Estoque.Add(estoque);
    context.SaveChanges();
});

app.MapGet("/Movimentacao", (DataContext context) =>
{ 
    context.MovimentacaoEstoque.ToList();
});

app.MapPost("/Venda", (string eventoId, string parceiroId, decimal valor, List<VendaItem> itens, DataContext context) =>
{
    var venda = new Venda()
    {
        EventoId = eventoId,
        ParceiroId = parceiroId,
        Valor = valor,
        DataEvento = DateTime.Now
    };

    context.Venda.Add(venda);
    context.SaveChanges();

    foreach (var item in itens)
    {
        item.VendaId = venda.Id;
        context.VendaItem.Add(item);
        context.SaveChanges();

        var estoque = context.Estoque.Where(e => e.ProdutoId == Convert.ToString(venda.Id)).FirstOrDefault();
        if (estoque != null)
        {
            estoque.QuantidadeAtual -= item.Qtde;
            context.Estoque.Update(estoque);

            context.MovimentacaoEstoque.Add(new MovimentacaoEstoque() { QtdeMovimentacao = item.Qtde, UsuarioId = "123", VendaId = venda.Id});

            context.SaveChanges();
        }


    }
});
app.Run();

class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Produto> Produto { get; set; }

    public DbSet<Estoque> Estoque { get; set; }

    public DbSet<MovimentacaoEstoque> MovimentacaoEstoque { get; set; }

    public DbSet<Venda> Venda { get; set; }

    public DbSet<VendaItem> VendaItem { get; set; }
}

class Produto
{
    [JsonIgnore]
    public int Id { get; set; }

    public string Descricao { get; set; }

    public decimal Valor { get; set; }

    public string Categoria { get; set; }
}

class Estoque
{
    [JsonIgnore]

    public int Id { get; set; }

    public string ParceiroId { get; set; }

    public string ProdutoId { get; set; }

    public decimal QuantidadeInicial { get; set; }

    public decimal QuantidadeAtual { get; set; }
}

class MovimentacaoEstoque
{
    [JsonIgnore]

    public int Id { get; set; }

    public int VendaId { get; set; }

    public string UsuarioId { get; set; }

    public decimal QtdeMovimentacao { get; set; }
}

class Venda
{
    [JsonIgnore]
    public int Id { get; set; }

    public string EventoId { get; set; }

    public string ParceiroId { get; set; }

    public decimal Valor { get; set; }

    public DateTime DataEvento { get; set; }
}

class VendaItem
{
    [JsonIgnore]
    public int Id { get; set; }

    public int VendaId { get; set; }

    public string ProdutoId { get; set; }

    public decimal Qtde { get; set; }
}