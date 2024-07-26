
using ExcelDataApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton(new ExcelService("C:\\Users\\mdfai\\OneDrive\\Desktop\\data.xlsx")); 

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();
app.MapControllers();

app.Run();
