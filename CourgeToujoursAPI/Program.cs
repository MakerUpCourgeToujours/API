using CourgeToujoursAPI.BLL.Interfaces.login;
using CourgeToujoursAPI.BLL.Interfaces.Subscribe;
using CourgeToujoursAPI.BLL.Services;
using CourgeToujoursAPI.BLL.Services.login;
using CourgeToujoursAPI.BLL.Services.Subscribe;
using CourgeToujoursAPI.DAL.Interfaces.Login;
using CourgeToujoursAPI.DAL.Interfaces.Subscribe;
using CourgeToujoursAPI.DAL.Repositories;
using CourgeToujoursAPI.DAL.Repositories.Login;
using CourgeToujoursAPI.DAL.Repositories.Subscribe;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inject connection for the db 
builder.Services.AddTransient<NpgsqlConnection>(service =>
{
    string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new NpgsqlConnection(connectionString);
});

/*------------------------------------------------BLL----------------------------------------------------------------*/
builder.Services.AddScoped<ISubTypeService, SubTypeService>();
builder.Services.AddScoped<IDepotGasapService, DepotGasapService>();
builder.Services.AddScoped<IUserService, UserService>();


/*-------------------------------------------------DAL---------------------------------------------------------------*/
builder.Services.AddScoped<ISubTypeRepository, SubTypeRepository>();
builder.Services.AddScoped<IDepotGasapRepository, DepotGasapRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


// Dev Mod for front 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseCors("AllowAngularClient");
app.UseHttpsRedirection();
app.UseRouting();  // Ajouté
app.UseAuthorization();  // Ajouté

app.MapControllers();

app.Run();