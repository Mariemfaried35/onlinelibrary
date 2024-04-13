using Microsoft.Extensions.Configuration;
using OlineLibrary.Data;
using OlineLibrary.Repository;
using Microsoft.EntityFrameworkCore;
using OlineLibrary.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IBookRepository, BookRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OnlineLibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineLibrary")));
builder.Services.AddCors(P => P.AddPolicy("CorsPolicy",build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
