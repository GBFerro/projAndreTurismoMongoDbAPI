using Microsoft.Extensions.Options;
using projAndreTurismoMongoDbAPI.Config;
using projAndreTurismoMongoDbAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ProjATMSettings>(builder.Configuration.GetSection("ProjAndreTurismoMongoDb"));
builder.Services.AddSingleton<IProjATMSettings>(s => s.GetRequiredService<IOptions<ProjATMSettings>>().Value);
builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<AddressService>();
builder.Services.AddSingleton<CityService>();

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
