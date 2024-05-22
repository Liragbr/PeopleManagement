using web;
using web.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Pessoa API",
        Version = "v1",
        Description = "API para gerenciamento de pessoas",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Seu Nome",
            Email = "seu.email@dominio.com"
        }
    });
});

// Register dependencies
builder.Services.AddSingleton<PessoaRepository>();
builder.Services.AddSingleton<ManagePessoa>(sp =>
    new ManagePessoa("caminho/para/seu/arquivo.csv", sp.GetRequiredService<ILogger<ManagePessoa>>()));

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pessoa API v1");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
