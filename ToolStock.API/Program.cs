using Microsoft.EntityFrameworkCore;
using ToolStock.Data;
using ToolStock.Logic.Service;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ToolStock.Data")));

builder.Services.AddScoped<MaterialService>();
builder.Services.AddScoped<ToolService>();
builder.Services.AddScoped<ToolAssignmentService>();
builder.Services.AddScoped<UserService>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; // Ez egy név, amit használunk a CORS szabályainknál
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        // Engedélyezzük, hogy a React frontend hozzáférhessen a backendhez
        policy.WithOrigins("http://localhost:5173") // A frontend URL-je
              .AllowAnyHeader() // Minden fejlécet engedünk
              .AllowAnyMethod(); // Minden HTTP metódust (GET, POST, PUT, DELETE) engedünk
    });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
