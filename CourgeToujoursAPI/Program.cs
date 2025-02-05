using System.Text;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
    
});

builder.Services.AddAuthentication(option =>
    {
        // Indique que le système d'authentification et de permission va se baser sur le schema du JWT Bearer
        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(option =>
        {
            // Configure la validation du token
            option.TokenValidationParameters = new TokenValidationParameters
            {
                // Vérifie que la clé utilisée pour signer le token est valide (TRUE ! Important !)
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),

                // Vérifie que le token provient du bon émetteur (optionnel)
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],

                // Vérifie que le token provient du bon public (optionnel)
                ValidateAudience = true,
                ValidAudience = builder.Configuration["Jwt:Audience"],

                // Vérifie que le token n'a pas encore expiré
                ValidateLifetime = true,
                //ClockSkew = TimeSpan.Zero

            };
        }
    );





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
builder.Services.AddScoped<IAuthService, AuthService>();


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
app.UseRouting(); 
app.UseAuthorization();  

app.MapControllers();

app.Run();