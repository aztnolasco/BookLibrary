using Application.Shared.DependencyInjection;
using Application.Queries.DependencyInjection;

IConfiguration configuration = null;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host
.UseDefaultServiceProvider((context,options) =>{
    configuration = context.Configuration;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediator();
builder.Services.AddRepositories();
builder.Services.AddContext(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

