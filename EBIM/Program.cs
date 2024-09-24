using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EBIM.DB;
using EBIM.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure the database context
builder.Services.AddDbContext<AppDb>(options =>
	options.UseSqlServer("Server=LAPTOP-VSKL4UUN\\SQLEXPRESS;Database=EBIM;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"));

// Configure Identity
builder.Services.AddIdentity<User, IdentityRole<int>>() // If you're using int as key
	.AddEntityFrameworkStores<AppDb>()
	.AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
	// Password and other settings
	options.Password.RequireDigit = true;
	options.Password.RequiredLength = 8;
	options.Password.RequireUppercase = true;
	options.User.RequireUniqueEmail = true;
	options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.AddControllers();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
