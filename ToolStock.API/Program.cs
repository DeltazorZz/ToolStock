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

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; // Ez egy n�v, amit haszn�lunk a CORS szab�lyainkn�l
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        // Enged�lyezz�k, hogy a React frontend hozz�f�rhessen a backendhez
        policy.WithOrigins("http://localhost:5173") // A frontend URL-je
              .AllowAnyHeader() // Minden fejl�cet enged�nk
              .AllowAnyMethod(); // Minden HTTP met�dust (GET, POST, PUT, DELETE) enged�nk
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
