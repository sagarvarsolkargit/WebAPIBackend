using System.Text;
using EmpSkills.Data;
using EmpSkills.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddScoped<SkillRepository>();
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<EmployeeSkillRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<SearchRepository>();
builder.Services.AddSingleton<JwtTokenService>();

// JWT config
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});
builder.Services.AddAuthorization();

var app = builder.Build();
app.UseCors("AllowAll"); 

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthentication();  
app.UseAuthorization();

app.MapControllers(); // This maps attribute-based controllers

app.Run();
 
 
