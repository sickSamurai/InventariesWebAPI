using InventariesWebAPI.Database;
using InventariesWebAPI.Services.BillsService.cs;
using InventariesWebAPI.Services.CategoriesService;
using InventariesWebAPI.Services.CustomerService.cs;
using InventariesWebAPI.Services.DailyReportService.cs;
using InventariesWebAPI.Services.ProductsService;
using InventariesWebAPI.Services.TransactionsService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<InventariesDbContext>(builder.Configuration.GetConnectionString("Inventaries"));
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IBillsService, BillsService>();
builder.Services.AddScoped<ITransactionsService, TransactionsService>();
builder.Services.AddScoped<IDailyReportService, DailyReportService>();

builder.Services.AddCors(options => {
  options.AddPolicy("MyPolicy", policy => {
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod();
  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
