using CourgeToujoursAPI.BLL.Interfaces.Subscribe;
using CourgeToujoursAPI.BLL.Services.Subscribe;
using CourgeToujoursAPI.DAL.Interfaces.Subscribe;
using CourgeToujoursAPI.DAL.Repositories.Subscribe;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
//inject connection for the db 
builder.Services.AddTransient<NpgsqlConnection>(service =>
{
    string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new NpgsqlConnection(connectionString);
});


/*------------------------------------------------BLL----------------------------------------------------------------*/

//inject BLL service - Sub
builder.Services.AddScoped<ISubTypeService, SubTypeService>();


/*-------------------------------------------------DAL---------------------------------------------------------------*/

//inject DAL - Sub
builder.Services.AddScoped<ISubTypeRepository, SubTypeRepository>();


/*----------------------------------------------------------------------------------------------------------------*/

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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAngularClient");
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
